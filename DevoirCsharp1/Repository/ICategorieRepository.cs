using System.Collections.Generic;
using Entity;

namespace Repositories
{
    public interface ICategorieRepository
    {
        Categorie Add(Categorie categorie);
        IEnumerable<Categorie> GetAll();
        Categorie GetById(int id);
    }
}
