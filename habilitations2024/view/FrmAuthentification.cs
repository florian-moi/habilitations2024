using habilitations2024.Controller;
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

namespace habilitations2024.view
{
   
    public partial class FrmAuthentification : Form
    {
        FrmAuthentificationController frmAuthentificationController = new FrmAuthentificationController();
        public FrmAuthentification()
        {
            InitializeComponent();
        }

        private void FrmAuthentification_Load(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" &&  textBox2.Text !="" &&  textBox3.Text != "")
            {
                string lnom = textBox1.Text;
                string lprenom = textBox2.Text;
                string lpwd = textBox3.Text;

                Admin ad = new Admin(lnom, lprenom, lpwd);
                frmAuthentificationController.ControleAuthentification(ad);
                FrmHabilitations frmHabilitations = new FrmHabilitations();
                if (frmAuthentificationController.ControleAuthentification(ad))
                {
                    this.Hide();
                    frmHabilitations.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects, veuillez réessayer.");
                }


            }
        }
    }
}
