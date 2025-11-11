using System.Collections.Generic;
using ProjetCsharp1.Entity;

namespace Repositories
{
    public interface ICategorieRepository
    {
        Categorie Add(Categorie categorie);
        IEnumerable<Categorie> GetAll();
        Categorie GetById(int id);
    }
}
