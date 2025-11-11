using System.Collections.Generic;
using System.Linq;
using Entity;

namespace Repositories
{
    public class ProduitRepository : Repositories.IProduitRepository
    {
        private readonly List<Produit> _storage = new();
        private int _nextId = 1;

        public Produit Add(Produit produit)
        {
            if (produit == null) throw new System.ArgumentNullException(nameof(produit));
            produit.Id = _nextId++;
            _storage.Add(produit);
            return produit;
        }

        public IEnumerable<Produit> GetAll() => _storage.ToList();

        public IEnumerable<Produit> GetByCategorieId(int categorieId)
            => _storage.Where(p => p.Categorie != null && p.Categorie.Id == categorieId).ToList();
    }
}
