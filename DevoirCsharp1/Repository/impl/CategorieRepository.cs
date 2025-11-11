using System.Collections.Generic;
using System.Linq;
using ProjetCsharp1.Entity;

namespace Repositories
{
    public class CategorieRepository : Repositories.ICategorieRepository
    {
        private readonly List<Categorie> _storage = new();
        private int _nextId = 1;

        public Categorie Add(Categorie categorie)
        {
            if (categorie == null) throw new System.ArgumentNullException(nameof(categorie));
            categorie.Id = _nextId++;
            _storage.Add(categorie);
            return categorie;
        }

        public IEnumerable<Categorie> GetAll() => _storage.ToList();

        public Categorie GetById(int id) => _storage.FirstOrDefault(c => c.Id == id);
    }
}
