using System;

namespace Entity
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public Categorie() { }

        public Categorie(int id, string libelle)
        {
            Id = id;
            Libelle = libelle ?? throw new ArgumentNullException(nameof(libelle));
        }

        public override string ToString() => $"{Id} - {Libelle}";
    }
}
