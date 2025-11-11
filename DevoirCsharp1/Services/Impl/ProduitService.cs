using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Repositories;

namespace Services
{
    public class ProduitService : Services.IProduitService
    {
        private readonly IProduitRepository _prodRepo;
        private readonly ICategorieRepository _catRepo;

        public ProduitService(IProduitRepository prodRepo, ICategorieRepository catRepo)
        {
            _prodRepo = prodRepo;
            _catRepo = catRepo;
        }

        public Produit AjouterProduit(string libelle, decimal prix, int quantite, int categorieId)
        {
            if (string.IsNullOrWhiteSpace(libelle)) throw new ArgumentException("Libellé invalide", nameof(libelle));
            if (prix < 0) throw new ArgumentException("Prix invalide", nameof(prix));
            if (quantite < 0) throw new ArgumentException("Quantité invalide", nameof(quantite));

            var cat = _catRepo.GetById(categorieId) ?? throw new InvalidOperationException("Catégorie introuvable.");

            var p = new Produit
            {
                Libelle = libelle.Trim(),
                Prix = prix,
                QuantiteEnStock = quantite,
                Categorie = cat
            };

            return _prodRepo.Add(p);
        }

        public IEnumerable<Produit> ListerProduits() => _prodRepo.GetAll();

        public IEnumerable<Produit> ListerParCategorie(int categorieId) => _prodRepo.GetByCategorieId(categorieId);

        public Produit ProduitLePlusCher()
        {
            return _prodRepo.GetAll().OrderByDescending(p => p.Prix).FirstOrDefault();
        }
    }
}
