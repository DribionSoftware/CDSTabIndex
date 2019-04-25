using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CDSTabIndexPackage.CDSTabIndex
{
    public partial class frmTabIndex : Form
    {
        public bool Aplicar;
        public int ControleAtual;
        public DataTable tbControle;
        public EventHandler Evento;

        public frmTabIndex()
        {
            InitializeComponent();
        }

        private void frmTabIndex_Load(object sender, EventArgs e)
        {
            lstTab.DataSource = tbControle;
            lstTab.DisplayMember = "Nome";
            lstTab.SelectedIndex = -1;
        }

        private void btnAplica_Click(object sender, EventArgs e)
        {
            Aplicar = true;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Aplicar = false;
            Close();
        }

        private void btnAcima_Click(object sender, EventArgs e)
        {
            int index = lstTab.SelectedIndex;
            if (index == 0)
            {
                return;
            }
            string NomeAtual = tbControle.Rows[index]["Nome"].ToString();
            string PosicaoAtual = tbControle.Rows[index]["Posicao"].ToString();
            string NomeNovo = tbControle.Rows[index - 1]["Nome"].ToString();
            string PosicaoNovo = tbControle.Rows[index - 1]["Posicao"].ToString();

            tbControle.Rows[index]["Nome"] = NomeNovo;
            tbControle.Rows[index]["Posicao"] = PosicaoNovo;
            tbControle.Rows[index - 1]["Nome"] = NomeAtual;
            tbControle.Rows[index - 1]["Posicao"] = PosicaoAtual;

            lstTab.SelectedIndex = index - 1;
        }

        private void btnAbaixo_Click(object sender, EventArgs e)
        {
            int index = lstTab.SelectedIndex;
            if (index == lstTab.Items.Count - 1)
            {
                return;
            }

            string NomeAtual = tbControle.Rows[index]["Nome"].ToString();
            string PosicaoAtual = tbControle.Rows[index]["Posicao"].ToString();
            string NomeNovo = tbControle.Rows[index + 1]["Nome"].ToString();
            string PosicaoNovo = tbControle.Rows[index + 1]["Posicao"].ToString();

            tbControle.Rows[index]["Nome"] = NomeNovo;
            tbControle.Rows[index]["Posicao"] = PosicaoNovo;
            tbControle.Rows[index + 1]["Nome"] = NomeAtual;
            tbControle.Rows[index + 1]["Posicao"] = PosicaoAtual;

            lstTab.SelectedIndex = index + 1;
        }

        private void lstTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Evento != null && lstTab.SelectedIndex != -1)
            {
                ControleAtual = int.Parse(tbControle.Rows[lstTab.SelectedIndex]["Posicao"].ToString()); // lstTab.Items[lstTab.SelectedIndex].ToString();
                Evento(this, e);
            }
        }

        private void frmTabIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
            {
                btnAbaixo_Click(sender, new EventArgs());
            }
            if (e.KeyChar == '-')
            {
                btnAcima_Click(sender, new EventArgs());
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process procExecute = new Process();
            ProcessStartInfo procInfo = new ProcessStartInfo(linkLabel1.Text, "");
            procExecute.StartInfo = procInfo;
            procExecute.Start();
            procExecute.Close();
        }
    }
}
