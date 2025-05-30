﻿using Microsoft.EntityFrameworkCore;
using SenaiNotas.Context;
using SenaiNotas.DTO;
using SenaiNotas.Interfaces;
using SenaiNotas.Models;

namespace SenaiNotas.Repositories
{
    public class NotaRepository : IAnotacaoRepository
    {
        private readonly ITagRepository _tagRepository;

        private readonly SenaiNotesContext _context;

        public NotaRepository(SenaiNotesContext context, ITagRepository tagRepository)
        {
            _context = context; 
            _tagRepository = tagRepository;
        }

        public async Task AtualizarNota(int IdNota, AtualizarNotaDTO nota)
        {
            var anotacao = await _context.Notas.FindAsync(IdNota);
            if (anotacao is null)
            {
                throw new ArgumentException("Nota nao encontrada");
            }

            anotacao.Titulo = nota.Titulo;
            anotacao.Conteudo = nota.Conteudo;
            anotacao.ImagemUrl = nota.Imagem;
            anotacao.UltimoRefresh = DateTime.Now;
           
            await _context.SaveChangesAsync();
        }

        public async Task<NotaCriadaDTO> CadastrarNota(CadastroAnotacaoDto anotacao)
        {
            List<int> idTags = new List<int>();

            foreach (var item in anotacao.Tags)
            {
                var tag = await _tagRepository.BuscarPorUsuarioeId(anotacao.IdUsuario, item);

                if (tag is null)
                {
                    tag = new Tag
                    {
                        Nome = item,
                        IdUsuario = anotacao.IdUsuario
                    };

                    await _context.AddAsync(tag);
                }
                await _context.SaveChangesAsync();
                idTags.Add(tag.IdTag);

            }

            var novaAnotacao = new Nota
            {
                Titulo = anotacao.Titulo,
                Conteudo = anotacao.Conteudo,
                UltimoRefresh = DateTime.Now,
                DataCriacao = DateTime.Now,
                ImagemUrl = anotacao.Imagem,
                Arquivado = false,
                IdUsuario = anotacao.IdUsuario,


            };
            await _context.Notas.AddAsync(novaAnotacao);
            await _context.SaveChangesAsync();

            foreach (var item in idTags)
            {
                var notaTag = new NotaTag
                {
                    IdNota = novaAnotacao.IdNota,
                    IdTag = item
                };
                await _context.NotaTags.AddAsync(notaTag);
                await _context.SaveChangesAsync();
            }
            return new NotaCriadaDTO
            {
                IdNota = novaAnotacao.IdNota,
                Titulo = novaAnotacao.Titulo,
                Conteudo = novaAnotacao.Conteudo,
                Imagem = novaAnotacao.ImagemUrl,
                DataCriacao = novaAnotacao.DataCriacao
            };
        }








        public async Task DeletaNota(int idNota)
        {
            // Verifica se a nota existe
            var nota = await _context.Notas.FirstOrDefaultAsync(n => n.IdNota == idNota);
            if (nota == null)
            {
                throw new Exception("Nota não encontrada.");
            }

            // Busca e remove os relacionamentos da tabela NotaTag
            var notaTags = _context.NotaTags.Where(nt => nt.IdNota == idNota);
            _context.NotaTags.RemoveRange(notaTags);

            // Remove a nota
            _context.Notas.Remove(nota);

            // Salva todas as alterações
            await _context.SaveChangesAsync();
        }


        public async Task<List<ListarNotaDTO>> ListarAnotacoesPorUserId(int IdUsuario)
        {
            var notaPorId = await _context.Notas.Where(c => c.IdUsuario == IdUsuario).ToListAsync(); //revisar para buscar todas de um user ID

            if (!notaPorId.Any())
                return new List<ListarNotaDTO>();

            return notaPorId.Select(n => new ListarNotaDTO
            {
                Titulo = n.Titulo,
                Conteudo = n.Conteudo,
                Arquivado = n.Arquivado,
                Imagem = n.ImagemUrl, 
                UltimoRefresh = n.UltimoRefresh,
                DataCriacao = n.DataCriacao
            }).ToList();
        }




        public async Task<Nota> ArquivarAnotacao(int IdNota) 
        {
            // Find the note
            var anotacao = await _context.Notas.FindAsync(IdNota);

            if (anotacao is null)
            {
                throw new ArgumentException("Nota nao encontrado");
            }

        
            anotacao.Arquivado = !anotacao.Arquivado;

            await _context.SaveChangesAsync();

            return anotacao;
        }
    }
}