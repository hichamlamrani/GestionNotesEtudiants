using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    class Notes
    {
        private Etudiant etudiant;
        public Cours cours;
        public double note;

        public Notes(Etudiant etudiant, Cours cours, double note)
        {
            this.etudiant = etudiant;
            this.cours = cours;
            this.note = note;
        }

        // Getters & Setters
        public Etudiant getEtudiant() { return this.etudiant; }
        public void setEtudiant(Etudiant etudiant) { this.etudiant = etudiant; }
        public Cours getCours() { return this.cours; }
        public void setCours(Cours cours) { this.cours = cours; }
        public double getNote() { return this.note; }
        public void setNote(double note) { this.note = note; }

        public override string ToString()
        {
            return $"Resultat pour l'etudiant {this.etudiant.getNom()} {this.etudiant.getPrenom()}, pour le cours : {this.cours.getTitle()}, avec une note : {this.note}";
        }

        public override bool Equals(object obj)
        {
            var notes = obj as Notes;
            return notes != null &&
                   EqualityComparer<Etudiant>.Default.Equals(etudiant, notes.etudiant) &&
                   EqualityComparer<Cours>.Default.Equals(cours, notes.cours) &&
                   note == notes.note;
        }

        public override int GetHashCode()
        {
            var hashCode = -1525875473;
            hashCode = hashCode * -1521134295 + EqualityComparer<Etudiant>.Default.GetHashCode(etudiant);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cours>.Default.GetHashCode(cours);
            hashCode = hashCode * -1521134295 + note.GetHashCode();
            return hashCode;
        }
    }
}
