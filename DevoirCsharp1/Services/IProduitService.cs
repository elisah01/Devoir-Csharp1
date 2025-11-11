using System.Collections.Generic;
using Entity;

namespace Services
{
    public interface IProduitService
    {
        Produit AjouterProduit(string libelle, decimal prix, int quantite, int categorieId);
        IEnumerable<Produit> ListerProduits();
        IEnumerable<Produit> ListerParCategorie(int categorieId);
        Produit ProduitLePlusCher();
    }
}
