using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    class Cours
    {
        private static int counter = 0;
        public int numeroCours { get; set; }
        public string code { get; set; }
        public string title { get; set; }

        public Cours()
        {
            this.numeroCours = ++Cours.counter;
        }

        public Cours(string code, string title) : this()
        {
            this.code = code;
            this.title = title;
        }

        public void setTitle(string title) { this.title = title; }
        public void setCode(string code) { this.code = code; }

        public string getTitle() { return this.title; }
        public string getCode() { return this.code; }




        public override bool Equals(object obj)
        {
            var cours = obj as Cours;
            return cours != null &&
                   numeroCours == cours.numeroCours;
        }

        public override int GetHashCode()
        {
            var hashCode = 261742114;
            hashCode = hashCode * -1521134295 + numeroCours.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            return hashCode;
        }
    }
}
