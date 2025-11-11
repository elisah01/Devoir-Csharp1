using System;
using Repositories;
using Services;
using Views;

namespace ProjetCsharp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple DI wiring
            ICategorieRepository categorieRepo = new CategorieRepository();
            IProduitRepository produitRepo = new ProduitRepository();

            ICategorieService categorieService = new CategorieService(categorieRepo);
            IProduitService produitService = new ProduitService(produitRepo, categorieRepo);

            var view = new ConsoleView(categorieService, produitService);

            // Optionnel: seed rapide pour démo
            var cat1 = categorieService.AjouterCategorie("Electronique");
            var cat2 = categorieService.AjouterCategorie("Alimentation");

            produitService.AjouterProduit("Téléviseur", 450000m, 2, cat1.Id);
            produitService.AjouterProduit("Pain", 300m, 50, cat2.Id);
            produitService.AjouterProduit("Ordinateur", 750000m, 1, cat1.Id);

            view.Run();
        }
    }
}
