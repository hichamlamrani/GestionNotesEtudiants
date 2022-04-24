using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    class Etudiant
    {
        private static int counter = 0;
        public int numeroEtudiant;
        public string nom;
        public string prenom;

        public Etudiant()
        {
            this.numeroEtudiant = ++Etudiant.counter;
        }

        public Etudiant(string nom, string prenom) : this()
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        // Getter & Setter
        public int getNumeroEtudiant() { return this.numeroEtudiant; }
        public string getNom() { return this.nom; }
        public void setNom(string nom) { this.nom = nom; }
        public string getPrenom() { return this.prenom; }
        public void setPrenom(string prenom) { this.prenom = prenom; }

        //public string getFullName() { return this.nom + " " + this.prenom;  }


        public override bool Equals(object obj)
        {
            var etudiant = obj as Etudiant;
            return etudiant != null &&
                   numeroEtudiant == etudiant.numeroEtudiant;
        }

        public override string ToString()
        {
            return $"Etudiant : {this.nom} {this.prenom}, numero : {this.numeroEtudiant}";
        }

        public override int GetHashCode()
        {
            var hashCode = -2063406774;
            hashCode = hashCode * -1521134295 + numeroEtudiant.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(prenom);
            return hashCode;
        }
    }
}
