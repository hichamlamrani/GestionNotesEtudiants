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
        public List<Notes> listeNotes;

        public Etudiant()
        {
            this.numeroEtudiant = ++Etudiant.counter;
            this.listeNotes = new List<Notes>();
        }

        public Etudiant(string nom, string prenom) : this()
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        // Getter & Setter
        public int getNumeroEtudiant() { return this.numeroEtudiant; }
        // public void setNumeroEtudiant(int numeroEtudiant) { this.numeroEtudiant = numeroEtudiant; }
        public string getNom() { return this.nom; }
        public void setNom(string nom) { this.nom = nom; }
        public string getPrenom() { return this.prenom; }
        public void setPrenom(string prenom) { this.prenom = prenom; }

        public List<Notes> getListeNotes() { return this.listeNotes; }

        //public string getFullName() { return this.nom + " " + this.prenom;  }


        public void addNewNotes(Cours cour, double note)
        {
            this.listeNotes.Add(new Notes(this, cour, note));
        }

        public void updateNotes(Cours cour, double newNote)
        {
            Notes note = this.listeNotes.Where((e) => e.getCours().Equals(cour)).First();
            if (note != null) note.setNote(newNote);
        }

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
