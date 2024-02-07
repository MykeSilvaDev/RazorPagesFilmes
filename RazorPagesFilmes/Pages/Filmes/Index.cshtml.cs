
                                        // Aula 54 Criando Funcionalidades
                                        // Aula 55 Criando a funcionalidade Buscar com o Campo Select/option

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
// (1-54) Renderização
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilmes.Data;
using RazorPagesFilmes.Modelo;

namespace RazorPagesFilmes.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFilmes.Data.RazorPagesFilmesContext _context;

        public IndexModel(RazorPagesFilmes.Data.RazorPagesFilmesContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;


        // (2-54) Termo Busca
        [BindProperty(SupportsGet = true)]
        public String TermoBusca { get; set; }
        [BindProperty(SupportsGet = true)]
        public String FilmeGenero { get; set; }
        public SelectList Generos { get; set; }




        public async Task OnGetAsync()
        {
            // (3-54)
            var filmes = from m in _context.Filme select m;
            // Vou fazer uma verificação se teve algo digitado pelo usuário (Se termoBusca for diferente de nulo)
            if (!string.IsNullOrWhiteSpace(TermoBusca))
            {
                filmes = filmes.Where(f => f.Titulo.Contains(TermoBusca));
            }

            // (4-55) Vou fazer uma verificação e buscar os filmes por (GENERO)
            if (!string.IsNullOrWhiteSpace(FilmeGenero)) 
            {
                filmes = filmes.Where(f => f.Genero == FilmeGenero);
            }

            // (5-55) Buscar o Genero no banco de dados mas usando o (Distinct) que faz a distinção e não repete o mesmo genero 2 vezes
            Generos = new SelectList(await _context.Filme.Select(o => o.Genero).Distinct().ToListAsync());
            Filme = await filmes.ToListAsync();
        }
    }
}
