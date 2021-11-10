using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aplicativoMVC_V1.controle;
using aplicativoMVC_V1.modelo;

namespace Tela_Desk_V1
{
    public partial class Form1 : Form
    {
        private Gerenciador gerenciador;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gerenciador = new Gerenciador(BancoDeDados.SqlServer);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Pessoa> pessoas;
            if (TxtNome.Text.Equals(""))
            {
                pessoas = gerenciador.dao.Consulte();
            }
            else
            {
                pessoas = gerenciador.dao.Consulte(TxtNome.Text);
            }
            IbAgenda.Items.Clear();
            foreach (Pessoa p in pessoas)
            {
                IbAgenda.Items.Add(p.ToString());
            }
        }

        private void btnInserir_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.nome = TxtNome.Text;
            p.telefone = Convert.ToInt32(TxtTelefone.Text);
            gerenciador.dao.Insira(p);
            TxtNome.Text = "";
            TxtTelefone.Text = "";
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.nome = TxtNome.Text;
            p.telefone = Convert.ToInt32(TxtTelefone.Text);
            gerenciador.dao.Altere(p);
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            Pessoa p = new Pessoa();
            p.nome = TxtNome.Text;
            p.telefone = Convert.ToInt32(TxtTelefone.Text);
            gerenciador.dao.Exclua(p);
        }
    }
}