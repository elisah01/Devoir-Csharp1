using System.Collections.Generic;
using Entity;

namespace Services
{
    public interface ICategorieService
    {
        Categorie AjouterCategorie(string libelle);
        IEnumerable<Categorie> ListerCategories();
        Categorie GetById(int id);
    }
}
