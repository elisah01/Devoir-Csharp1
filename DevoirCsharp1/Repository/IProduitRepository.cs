using System.Collections.Generic;
using Entity;

namespace Repositories
{
    public interface IProduitRepository
    {
        Produit Add(Produit produit);
        IEnumerable<Produit> GetAll();
        IEnumerable<Produit> GetByCategorieId(int categorieId);
    }
}
