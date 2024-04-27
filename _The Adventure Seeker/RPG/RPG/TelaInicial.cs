using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace RPG
{
    public partial class TelaInicial : Form
    {
        Sobre about = new Sobre();
        Configuracoes c = new Configuracoes();
        Jogador j = new Jogador();
        public TelaInicial()
        {
            InitializeComponent();
            lblTituloDoJogo.Parent = FundoTelaInicial;

            #region Add Font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"A Goblin Appears!.ttf");
            pfc.AddFontFile(@"Ancient Modern Tales.ttf");

            foreach (Control c in this.Controls)
            {
                lblTituloDoJogo.Font = new Font(pfc.Families[1], 120, FontStyle.Regular);
                btnNovoJogo.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
                btnConfig.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
                btnSobre.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
                btnSair.Font = new Font(pfc.Families[0], 20, FontStyle.Regular);
            }
            #endregion

            #region Música
            c.MusicaGeral.SoundLocation = "";
            c.MusicaGeral.PlayLooping();
            #endregion
        }

        #region Botão Configurações
        private void btnConfig_Click(object sender, EventArgs e)
        {
            c.ShowDialog();
        }
        #endregion

        #region Botão Novo Jogo
        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Jogadores Jogadores = new Jogadores();
            Jogadores.Closed += (s, args) => this.Close();
            Jogadores.Show();
        }
        #endregion

        #region Botão Sobre
        private void btnSobre_Click(object sender, EventArgs e)
        {
            about.ShowDialog();
        }
        #endregion

        #region Botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            j.saida();
        }
        #endregion
    }
}
