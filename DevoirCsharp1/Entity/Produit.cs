using System;

namespace Entity
{
    public class Produit
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteEnStock { get; set; }
        public Categorie Categorie { get; set; }

        public decimal MontantEnStock => Prix * QuantiteEnStock;

        public Produit() { }

        public Produit(int id, string libelle, decimal prix, int quantite, Categorie categorie)
        {
            Id = id;
            Libelle = libelle ?? throw new ArgumentNullException(nameof(libelle));
            Prix = prix;
            QuantiteEnStock = quantite;
            Categorie = categorie ?? throw new ArgumentNullException(nameof(categorie));
        }

        public override string ToString()
        {
            return $"{Id} | {Libelle} | Prix: {Prix:F2} | Qté: {QuantiteEnStock} | Cat: {Categorie.Libelle} | MontantStock: {MontantEnStock:F2}";
        }
    }
}
