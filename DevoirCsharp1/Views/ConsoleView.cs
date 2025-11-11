using System;
using System.Globalization;
using Services;
using Entity;
using System.Linq;

namespace Views
{
    public class ConsoleView
    {
        private readonly ICategorieService _categorieService;
        private readonly IProduitService _produitService;

        public ConsoleView(ICategorieService categorieService, IProduitService produitService)
        {
            _categorieService = categorieService;
            _produitService = produitService;
        }

        public void Run()
        {
            while (true)
            {
                AfficherMenu();
                var choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        AjouterCategorie();
                        break;
                    case "2":
                        ListeCategories();
                        break;
                    case "3":
                        AjouterProduit();
                        break;
                    case "4":
                        ListerProduits();
                        break;
                    case "5":
                        ListerProduitsParCategorie();
                        break;
                    case "6":
                        ProduitPlusCher();
                        break;
                    case "7":
                        Console.WriteLine("Au revoir.");
                        return;
                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                Console.WriteLine("\nAppuyez sur Entrée pour continuer...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void AfficherMenu()
        {
            Console.WriteLine("=== Gestion Produits ===");
            Console.WriteLine("1. Ajouter Categorie");
            Console.WriteLine("2. Liste Categorie");
            Console.WriteLine("3. Ajouter Produit");
            Console.WriteLine("4. Lister Produit");
            Console.WriteLine("5. Lister les produits par catégorie");
            Console.WriteLine("6. Produit le plus cher");
            Console.WriteLine("7. Quitter");
            Console.Write("Choix: ");
        }

        private void AjouterCategorie()
        {
            Console.Write("Libellé catégorie: ");
            var lib = Console.ReadLine();
            try
            {
                var c = _categorieService.AjouterCategorie(lib);
                Console.WriteLine($"Catégorie ajoutée: {c}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
        }

        private void ListeCategories()
        {
            var cats = _categorieService.ListerCategories().ToList();
            if (!cats.Any())
            {
                Console.WriteLine("Aucune catégorie.");
                return;
            }

            Console.WriteLine("Id | Libellé");
            foreach (var c in cats) Console.WriteLine(c);
        }

        private void AjouterProduit()
        {
            Console.Write("Libellé produit: ");
            var lib = Console.ReadLine();

            Console.Write("Prix: ");
            if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out var prix))
            {
                Console.WriteLine("Prix invalide.");
                return;
            }

            Console.Write("Quantité en stock: ");
            if (!int.TryParse(Console.ReadLine(), out var qte))
            {
                Console.WriteLine("Quantité invalide.");
                return;
            }

            var cats = _categorieService.ListerCategories().ToList();
            if (!cats.Any())
            {
                Console.WriteLine("Aucune catégorie. Ajoutez une catégorie d'abord.");
                return;
            }

            Console.WriteLine("Catégories disponibles:");
            foreach (var c in cats) Console.WriteLine(c);

            Console.Write("Id catégorie: ");
            if (!int.TryParse(Console.ReadLine(), out var catId))
            {
                Console.WriteLine("Id invalide.");
                return;
            }

            try
            {
                var p = _produitService.AjouterProduit(lib, prix, qte, catId);
                Console.WriteLine($"Produit ajouté: {p}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur: {ex.Message}");
            }
        }

        private void ListerProduits()
        {
            var prods = _produitService.ListerProduits().ToList();
            if (!prods.Any()) { Console.WriteLine("Aucun produit."); return; }

            Console.WriteLine("Liste produits:");
            foreach (var p in prods) Console.WriteLine(p);
        }

        private void ListerProduitsParCategorie()
        {
            var cats = _categorieService.ListerCategories().ToList();
            if (!cats.Any()) { Console.WriteLine("Aucune catégorie."); return; }

            Console.WriteLine("Catégories:");
            foreach (var c in cats) Console.WriteLine(c);

            Console.Write("Id catégorie: ");
            if (!int.TryParse(Console.ReadLine(), out var catId)) { Console.WriteLine("Id invalide."); return; }

            var prods = _produitService.ListerParCategorie(catId).ToList();
            if (!prods.Any()) { Console.WriteLine("Aucun produit pour cette catégorie."); return; }

            Console.WriteLine($"Produits pour la catégorie {catId}:");
            foreach (var p in prods) Console.WriteLine(p);
        }

        private void ProduitPlusCher()
        {
            var p = _produitService.ProduitLePlusCher();
            if (p == null) Console.WriteLine("Aucun produit enregistré.");
            else
            {
                Console.WriteLine("Produit le plus cher:");
                Console.WriteLine(p);
            }
        }
    }
}
