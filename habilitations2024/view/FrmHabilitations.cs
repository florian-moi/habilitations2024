using habilitations2024.dal;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using habilitations2024.Controller;

namespace habilitations2024.view
{
    public partial class FrmHabilitations : Form
    {

        FrmHabilitationsController controller = new FrmHabilitationsController();
        bool modifOn = false;

        public FrmHabilitations()
        {
            InitializeComponent();
        }

        private void FrmHabilitations_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            List<Developpeur> lesDeveloppeurs = controller.GetDeveloppeurs();
            lesDeveloppeurs = lesDeveloppeurs.OrderBy(de => de.Nom).ToList();
            dataGridView1.DataSource = lesDeveloppeurs;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["IdDeveloppeur"].Visible = false;
            dataGridView1.Columns["MotDePasse"].Visible = false;
            comboBox1.DataSource = controller.GetProfils();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textpwd.PasswordChar = '*';
            textpwd2.PasswordChar = '*';
            comboBox2.DataSource = new List<Profil> { new Profil(0, "") }.Concat(controller.GetProfils()).ToList();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                groupBox3.Text = "Modifier un developpeur";
                modifOn = true;
                Developpeur dev = dataGridView1.SelectedRows[0].DataBoundItem as Developpeur;
                groupBox1.Enabled = false;
                Console.WriteLine("Selected Developpeur: " + dev.Nom + " " + dev.Prenom + " " + dev.Profil.IdProfil);
                textnom.Text = dev.Nom;
                textprenom.Text = dev.Prenom;
                textmail.Text = dev.Tel;
                texttel.Text = dev.Email;
                comboBox1.SelectedIndex = dev.Profil.IdProfil - 1;






            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Voulez-vous vraiment annuler l'ajout/modification en cours ?",
                 "Confirmation",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question
             );
            if (result == DialogResult.Yes)
            {
                groupBox1.Enabled = true;
                textnom.Clear();
                textprenom.Clear();
                textmail.Clear();
                texttel.Clear();
                comboBox1.SelectedIndex = 0;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show(
                    "Voulez-vous vraiment supprimer ce développeur ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Developpeur dev = dataGridView1.SelectedRows[0].DataBoundItem as Developpeur;
                    controller.DelDeveloppeur(dev);
                    // Rafraîchir la liste après suppression
                    dataGridView1.DataSource = controller.GetDeveloppeurs().OrderBy(de => de.Nom).ToList();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textnom.Text != "" && textprenom.Text != "" && textmail.Text != "" && texttel.Text != "")
            {
                Profil pro = comboBox1.SelectedItem as Profil;

                if (modifOn)
                {
                    Developpeur dev = dataGridView1.SelectedRows[0].DataBoundItem as Developpeur;
                    dev.Nom = textnom.Text;
                    dev.Prenom = textprenom.Text;
                    dev.Tel = texttel.Text;
                    dev.Email = textmail.Text;
                    dev.Profil = pro;
                    controller.UpdateDeveloppeur(dev);
                    groupBox1.Enabled = true;
                    groupBox3.Text = "Ajouter un developpeur";
                    modifOn = false;
                    textnom.Clear();
                    textprenom.Clear();
                    textmail.Clear();
                    texttel.Clear();
                    comboBox1.SelectedIndex = 0;

                }
                else
                {
                    Developpeur newDev = new Developpeur(0, textnom.Text, textprenom.Text, texttel.Text, textmail.Text, pro);
                    controller.AddDeveloppeur(newDev);
                    dataGridView1.DataSource = controller.GetDeveloppeurs().OrderBy(de => de.Nom).ToList();
                    textnom.Clear();
                    textprenom.Clear();
                    textmail.Clear();
                    texttel.Clear();
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((textpwd.Text != "" && textpwd2.Text != "") && (textpwd.Text == textpwd2.Text))
            {
                string mdp = textpwd.Text;
                Developpeur dev = dataGridView1.SelectedRows[0].DataBoundItem as Developpeur;
                dev.MotDePasse = mdp;
                controller.UpadatePwdDeveloppeur(dev, mdp);
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;
                groupBox3.Enabled = true;
                textpwd.Clear();
                textpwd2.Clear();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textpwd.Clear();
            textpwd2.Clear();
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Profil pro = comboBox2.SelectedItem as Profil;
            int idProfil = pro.IdProfil;
            if (pro.Nom =="")
            {
                var dev = controller.GetDeveloppeurs();
                dataGridView1.DataSource = dev;
            }
            else
            {
                var dev2 = controller.GetDeveloppeurs(pro);
                dataGridView1.DataSource = dev2;
            }
        }


    }
}
