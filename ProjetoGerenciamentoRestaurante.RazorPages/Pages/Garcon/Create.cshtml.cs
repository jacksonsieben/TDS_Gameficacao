using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjetoGerenciamentoRestaurante.RazorPages.Data;
using ProjetoGerenciamentoRestaurante.RazorPages.Models;

namespace ProjetoGerenciamentoRestaurante.RazorPages.Pages.Garcon
{
    public class Create : PageModel
    {
        private readonly AppDbContext _context;
            [BindProperty]
            public GarconModel GarconModel { get; set; } = new();
            public Create(AppDbContext context){
                _context = context;
            }
        
        public async Task<IActionResult> OnPostAsync(int id){
            if(!ModelState.IsValid){
                return Page();
            }

            // var emptyGarcon = new GarconModel();

            try{
                _context.Add(GarconModel);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Garcon/Index");
            } catch(DbUpdateException){
                return Page();
            }

            // if(await TryUpdateModelAsync<GarconModel>(emptyGarcon, "garcon",
            // e => e.Nome,
            // e => e.Sobrenome, 
            // e => e.Cpf, 
            // e => e.Telefone 
            // )){
            //     var entry = _context.Add(emptyGarcon);
            //     await _context.SaveChangesAsync();
            //     return RedirectToPage("/Garcon/Index");
            // }
        }
    }
}