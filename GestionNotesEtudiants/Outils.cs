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
        public static Etudiant loadEtudiantFromFile(int numero)
        {
            Directory.CreateDirectory(Outils.DataFolder);
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, Outils.DataFolder);
            string filePath = Path.Combine(path, numero.ToString()) + ".json";

            if (!File.Exists(filePath)) return null;
            Etudiant e;
            //Etudiant e = JsonConvert.DeserializeObject<Etudiant>(File.ReadAllText(filePath));
            using (StreamReader file = File.OpenText(@filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                e = (Etudiant)serializer.Deserialize(file, typeof(Etudiant));
                foreach (Notes note in e.getListeNotes())
                {
                    note.setEtudiant(e);
                }
            }
            return e;

        }
        public static List<Etudiant> loadDataFromFiles()
        {
            List<Etudiant> _ret = new List<Etudiant>();
            string currentDirectory = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(Outils.DataFolder);
            string path = Path.Combine(currentDirectory, Outils.DataFolder);
            DirectoryInfo files = new DirectoryInfo(path);
            foreach (FileInfo file in files.GetFiles(".json"))
            {
                //var fileWriter = File.CreateText(file.ToString());
                var fileWriter = new StreamReader(file.ToString());
                var serializer = new JsonSerializer();
                Etudiant e = (Etudiant)serializer.Deserialize(fileWriter, typeof(Etudiant));
                foreach (Notes note in e.getListeNotes())
                {
                    note.setEtudiant(e);
                }
                _ret.Add(e);

            }

            return _ret;
        }

        public static string getReleve(Etudiant etudiant)
        {

            string releve = $"Releve des notes pour l'etudiant : {etudiant} \n";
            foreach (Notes note in etudiant.getListeNotes())
            {
                releve += $"{note.ToString()}\n";
            }
            return releve;
        }



    }
}
