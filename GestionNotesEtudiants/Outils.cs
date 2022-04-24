using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    class Outils
    {
        static string DataFolder = "DataFolder";

        public static void saveDataToFile(Etudiant etudiant)
        {
            Directory.CreateDirectory(Outils.DataFolder);
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(Path.Combine(currentDirectory, Outils.DataFolder), etudiant.getNumeroEtudiant().ToString()) + ".json";

            string serializedEtudiant = JsonConvert.SerializeObject(etudiant);
            File.WriteAllText(@path, serializedEtudiant);
        }

        public static void saveListDataToFiles(List<Etudiant> etudiants)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            foreach (Etudiant etudiant in etudiants)
            {
                Outils.saveDataToFile(etudiant);
            }
        }

        

    }
}
