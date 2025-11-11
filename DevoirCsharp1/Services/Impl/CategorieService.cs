using System.Collections.Generic;
using Entity;
using Repositories;

namespace Services
{
    public class CategorieService : Services.ICategorieService
    {
        private readonly ICategorieRepository _repo;

        public CategorieService(ICategorieRepository repo)
        {
            _repo = repo;
        }

        public Categorie AjouterCategorie(string libelle)
        {
            if (string.IsNullOrWhiteSpace(libelle))
                throw new System.ArgumentException("Libellé invalide.", nameof(libelle));

            var cat = new Categorie { Libelle = libelle.Trim() };
            return _repo.Add(cat);
        }

        public IEnumerable<Categorie> ListerCategories() => _repo.GetAll();

        public Categorie GetById(int id) => _repo.GetById(id);
    }
}
