using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionNotesEtudiants
{
    public partial class Form1 : Form
    {
        private List<Etudiant> etudiants;
        public Form1()
        {
            InitializeComponent();
            buildGrid();
        }
        private void buildGrid()
        {
            etudiantsDataGridView.ColumnCount = 3;
            etudiantsDataGridView.Columns[0].Name = "Numero Etudiant";
            etudiantsDataGridView.Columns[1].Name = "Nom Etudiant";
            etudiantsDataGridView.Columns[2].Name = "Prénom Etudiant";
            //etudiantsDataGridView.Columns[3].Name = "Edit";
            //tudiantsDataGridView.Columns[4].Name = "Delete";

            etudiantsDataGridView.Columns[0].ReadOnly = true;
            //etudiantsDataGridView.Columns[3].ReadOnly = true;
            //etudiantsDataGridView.Columns[4].ReadOnly = true;


            etudiantsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            etudiantsDataGridView.CellClick += dataGridView_CellClick;
            //generateTestData();
            loadData();
        }
        private void  generateTestData()
        {
            List<Etudiant> temp = new List<Etudiant>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add( new Etudiant(nom: "Nom " + i, prenom: "Prenom " + i));
            }
            Outils.saveListDataToFiles(temp);
        }
        private void loadData()
        {
            // Load data from files
            this.etudiants = Outils.loadDataFromFiles();
            foreach(Etudiant e in this.etudiants)
            {
             //   Etudiant e = new Etudiant(nom: "Nom " + i, prenom: "Prenom " + i);
               // etudiants.Add(e);
                etudiantsDataGridView.Rows.Add(e.getNumeroEtudiant(), e.getNom(), e.getPrenom());
                DataGridViewButtonColumn editButton= new DataGridViewButtonColumn();
                DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();

                editButton.Name = "Edit";
                editButton.Text = "Edit";
                
                if (etudiantsDataGridView.Columns["Edit"] == null)
                {
                    etudiantsDataGridView.Columns.Insert(3, editButton);
                }
                deleteButton.Name = "Delete";
                deleteButton.Text = "Delete";
                
                if (etudiantsDataGridView.Columns["Delete"] == null)
                {
                    etudiantsDataGridView.Columns.Insert(4, deleteButton);
                }


            }
            // dataGridView.DataSource = this.etudiants;
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == etudiantsDataGridView.Columns["Edit"].Index)
            {
                //TODO Go to Etudiant detail panel.
                MessageBox.Show("Edit Etudiant" + this.etudiants);
                
            }
            else if(e.ColumnIndex == etudiantsDataGridView.Columns["Delete"].Index)
            {
                // TODO delete the item
                MessageBox.Show("Delete Etudiant");

            }
        }
    }
}
