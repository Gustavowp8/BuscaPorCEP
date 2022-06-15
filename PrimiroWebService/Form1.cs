using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimiroWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCep.Text)){

                using(var ws = new WSCorreiros.AtendeClienteClient())
                try
                {
                    var consulta = ws.consultaCEP(txtCep.Text.Trim());

                        txtEstado.Text = consulta.uf;
                        txtRua.Text = consulta.end;
                        txtCidade.Text = consulta.cidade;
                        txtBairro.Text = consulta.bairro;
                }
                catch(Exception exeption)
                {
                        MessageBox.Show(exeption.Message, this.Text, MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Informe um CEP valiédo", this.Text, MessageBoxButtons.OK);
            }
        }

        private void limpar_Click(object sender, EventArgs e)
        {
            txtEstado.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
