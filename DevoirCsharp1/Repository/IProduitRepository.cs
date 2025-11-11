using System.Collections.Generic;
using ProjetCsharp1.Entity;

namespace Repositories
{
    public interface IProduitRepository
    {
        Produit Add(Produit produit);
        IEnumerable<Produit> GetAll();
        IEnumerable<Produit> GetByCategorieId(int categorieId);
    }
}
