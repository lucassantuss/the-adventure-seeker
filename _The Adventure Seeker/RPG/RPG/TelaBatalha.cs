using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RPG
{
    public partial class TelaBatalha : Form
    {
        #region Variáveis
        Configuracoes c = new Configuracoes();
        Jogador j = new Jogador();
        Jogadores j1 = new Jogadores();
        AtributosJogador p1 = new AtributosJogador();
        AtributosJogador p2 = new AtributosJogador();
        AtributosJogador p3 = new AtributosJogador();
        AtributosJogador p4 = new AtributosJogador();
        AtributosJogador p5 = new AtributosJogador();

        ClassBanco bd = new ClassBanco();
        StringBuilder strQuery = new StringBuilder();
        ClassColunasBD ccbd = new ClassColunasBD();
        MySqlDataReader objDados;

        int AtivarSeleçãoDosInimigos = 0;
        string idPartida;
        string TotalJogadores;
        int player = 1;

        Random rnd = new Random();
        #endregion

        #region Inicializar
        public TelaBatalha()
        {
            InitializeComponent();

            #region Música
            c.MusicaGeral.SoundLocation = "";
            c.MusicaGeral.PlayLooping();
            #endregion

            #region Pesquisar Jogador 1 (Quando inicia)
            ccbd.IdJogador = 1;
            player = 1;
            bd.PesquisarJogador(ccbd.IdJogador);
            objDados = bd.PesquisarJogador(ccbd.IdJogador);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Jogador não existente!!!",
                    "*** JOGADOR INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                objDados.Read();
                idPartida = objDados["idPartida"].ToString();
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
            #endregion

            VerificarTotalJogadores();
        }

        private void TelaBatalha_Load(object sender, EventArgs e)
        {
            switch (int.Parse(TotalJogadores))
            {
                case 1:
                    PanelPeq2.Visible = false;
                    PanelPeq3.Visible = false;
                    PanelPeq4.Visible = false;
                    PanelPeq5.Visible = false;

                    PF2.Visible = false;
                    PT1.Visible = false;
                    PT2.Visible = false;
                    PT3.Visible = false;

                    p1.BuscarJogador(1);
                    break;

                case 2:
                    PanelPeq3.Visible = false;
                    PanelPeq4.Visible = false;
                    PanelPeq5.Visible = false;

                    PT1.Visible = false;
                    PT2.Visible = false;
                    PT3.Visible = false;

                    p1.BuscarJogador(1);
                    p2.BuscarJogador(2);

                    break;

                case 3:
                    PanelPeq4.Visible = false;
                    PanelPeq5.Visible = false;

                    PT2.Visible = false;
                    PT3.Visible = false;

                    p1.BuscarJogador(1);
                    p2.BuscarJogador(2);
                    p3.BuscarJogador(3);
                    break;

                case 4:
                    PanelPeq5.Visible = false;

                    PT3.Visible = false;

                    p1.BuscarJogador(1);
                    p2.BuscarJogador(2);
                    p3.BuscarJogador(3);
                    p4.BuscarJogador(4);
                    break;

                case 5:
                    p1.BuscarJogador(1);
                    p2.BuscarJogador(2);
                    p3.BuscarJogador(3);
                    p4.BuscarJogador(4);
                    p5.BuscarJogador(5);
                    break;
            }

            lblPersAtual.Text = p1.NomePersonagem;
            lblPersonagem2.Text = p2.NomePersonagem;
            lblPersonagem3.Text = p3.NomePersonagem;
            lblPersonagem4.Text = p4.NomePersonagem;
            lblPersonagem5.Text = p5.NomePersonagem;

            PbGHP.Value = p1.HPPers + (100 - p1.HPPers);
            PbP2HP.Value = p2.HPPers + (100 - p2.HPPers);
            PbP3HP.Value = p3.HPPers + (100 - p3.HPPers);
            PbP4HP.Value = p4.HPPers + (100 - p4.HPPers);
            PbP5HP.Value = p5.HPPers + (100 - p5.HPPers);

            PbGMP.Value = p1.MPPers + (100 - p1.MPPers);
            PbP2MP.Value = p2.MPPers + (100 - p2.MPPers);
            PbP3MP.Value = p3.MPPers + (100 - p3.MPPers);
            PbP4MP.Value = p4.MPPers + (100 - p4.MPPers);
            PbP5MP.Value = p5.MPPers + (100 - p5.MPPers);

            switch (p1.NomeClasse)
            {
                case 1:
                    PF1.Image = ImgListPers.Images[0];
                    PbRostoAtual.Image = ImgListRostos.Images[0];
                    break;

                case 2:
                    PF1.Image = ImgListPers.Images[1];
                    PbRostoAtual.Image = ImgListRostos.Images[1];
                    break;

                case 3:
                    PF1.Image = ImgListPers.Images[2];
                    PbRostoAtual.Image = ImgListRostos.Images[2];
                    break;

                case 4:
                    PF1.Image = ImgListPers.Images[3];
                    PbRostoAtual.Image = ImgListRostos.Images[3];
                    break;

                case 5:
                    PF1.Image = ImgListPers.Images[4];
                    PbRostoAtual.Image = ImgListRostos.Images[4];
                    break;
            }

            switch (p2.NomeClasse)
            {
                case 1:
                    PF2.Image = ImgListPers.Images[0];
                    PbRosto2.Image = ImgListRostos.Images[0];
                    break;

                case 2:
                    PF2.Image = ImgListPers.Images[1];
                    PbRosto2.Image = ImgListRostos.Images[1];
                    break;

                case 3:
                    PF2.Image = ImgListPers.Images[2];
                    PbRosto2.Image = ImgListRostos.Images[2];
                    break;

                case 4:
                    PF2.Image = ImgListPers.Images[3];
                    PbRosto2.Image = ImgListRostos.Images[3];
                    break;

                case 5:
                    PF2.Image = ImgListPers.Images[4];
                    PbRosto2.Image = ImgListRostos.Images[4];
                    break;
            }

            switch (p3.NomeClasse)
            {
                case 1:
                    PT1.Image = ImgListPers.Images[0];
                    PbRosto3.Image = ImgListRostos.Images[0];
                    break;

                case 2:
                    PT1.Image = ImgListPers.Images[1];
                    PbRosto3.Image = ImgListRostos.Images[1];
                    break;

                case 3:
                    PT1.Image = ImgListPers.Images[2];
                    PbRosto3.Image = ImgListRostos.Images[2];
                    break;

                case 4:
                    PT1.Image = ImgListPers.Images[3];
                    PbRosto3.Image = ImgListRostos.Images[3];
                    break;

                case 5:
                    PT1.Image = ImgListPers.Images[4];
                    PbRosto3.Image = ImgListRostos.Images[4];
                    break;
            }

            switch (p4.NomeClasse)
            {
                case 1:
                    PT2.Image = ImgListPers.Images[0];
                    PbRosto4.Image = ImgListRostos.Images[0];
                    break;

                case 2:
                    PT2.Image = ImgListPers.Images[1];
                    PbRosto4.Image = ImgListRostos.Images[1];
                    break;

                case 3:
                    PT2.Image = ImgListPers.Images[2];
                    PbRosto4.Image = ImgListRostos.Images[2];
                    break;

                case 4:
                    PT2.Image = ImgListPers.Images[3];
                    PbRosto4.Image = ImgListRostos.Images[3];
                    break;

                case 5:
                    PT2.Image = ImgListPers.Images[4];
                    PbRosto4.Image = ImgListRostos.Images[4];
                    break;
            }

            switch (p5.NomeClasse)
            {
                case 1:
                    PT3.Image = ImgListPers.Images[0];
                    PbRosto5.Image = ImgListRostos.Images[0];
                    break;

                case 2:
                    PT3.Image = ImgListPers.Images[1];
                    PbRosto5.Image = ImgListRostos.Images[1];
                    break;

                case 3:
                    PT3.Image = ImgListPers.Images[2];
                    PbRosto5.Image = ImgListRostos.Images[2];
                    break;

                case 4:
                    PT3.Image = ImgListPers.Images[3];
                    PbRosto5.Image = ImgListRostos.Images[3];
                    break;

                case 5:
                    PT3.Image = ImgListPers.Images[4];
                    PbRosto5.Image = ImgListRostos.Images[4];
                    break;
            }

            PbRostoAtual.Image = PbRostoAtual.Image;
            lblPersAtual.Text = lblPersAtual.Text;
            PbGHP.Value = PbGHP.Value;
            PbGMP.Value = PbGMP.Value;
            VidaAtual.Text = Convert.ToString(p1.HPPers);
            ManaAtual.Text = Convert.ToString(p1.MPPers);

            LblNomeBoss.Text = "NOME DO BOSS";
            LblNomeInim1.Text = "Esqueleto";
            LblNomeInim2.Text = "Esqueleto";
            LblNomeInim3.Text = "Esqueleto";
            LblNomeInim4.Text = "Esqueleto";

            PbHPBoss.Value = 100;
            PbHPInim1.Value = 100;
            PbHPInim2.Value = 100;
            PbHPInim3.Value = 100;
            PbHPInim4.Value = 100;
        }
        #endregion

        #region Trocar Jogadores

        #region Verificar Total de Jogadores
        public void VerificarTotalJogadores()
        {
            ccbd.IdPartida = int.Parse(idPartida);
            bd.PesquisarIdPartida(ccbd.IdPartida);
            objDados = bd.PesquisarIdPartida(ccbd.IdPartida);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Partida não existente!!!",
                    "*** PARTIDA INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                objDados.Read();
                TotalJogadores = objDados["TotalJogadores"].ToString();
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #endregion

        #region Botão Configurações
        private void Btn_Config_Click(object sender, EventArgs e)
        {
            Configuracoes C = new Configuracoes();
            C.ShowDialog();

            // Se as configurações forem só o som pode deixar este botao com o icone de Som Ativo ou Som com X Vermelho
        }
        #endregion

        #region Botão Sair
        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            //j.saida();

            if (MessageBox.Show("Deseja Sair? A batalha será perdida", "Sair?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // !!! Passa as informações dos personagens, do loot, e xp obtido pro Bd;
                Application.Exit();
            }
        }
        #endregion

        #region Ataque
        
        #region SelecionarPanelInimigo
        private void PanelInim2_MouseEnter(object sender, EventArgs e)
        {
            if (AtivarSeleçãoDosInimigos == 1)
            {
                PanelInim2.BackColor = Color.LightGray;
            }
        }

        private void PanelInim1_MouseEnter(object sender, EventArgs e)
        {
            if (AtivarSeleçãoDosInimigos == 1)
            {
                PanelInim1.BackColor = Color.LightGray;
            }
        }

        private void PanelBoss_MouseEnter(object sender, EventArgs e)
        {
            if (AtivarSeleçãoDosInimigos == 1)
            {
                PanelBoss.BackColor = Color.LightGray;
            }
        }

        private void PanelInim4_MouseEnter(object sender, EventArgs e)
        {
            if (AtivarSeleçãoDosInimigos == 1)
            {
                PanelInim4.BackColor = Color.LightGray;
            }
        }

        private void PanelInim3_MouseEnter(object sender, EventArgs e)
        {
            if (AtivarSeleçãoDosInimigos == 1)
            {
                PanelInim3.BackColor = Color.LightGray;
            }
        }
        #endregion

        #region Desselecionar Panel Inimigo
        private void PanelInim3_MouseLeave(object sender, EventArgs e)
        {
            PanelInim3.BackColor = SystemColors.Control;
        }

        private void PanelInim4_MouseLeave(object sender, EventArgs e)
        {
            PanelInim4.BackColor = SystemColors.Control;
        }

        private void PanelInim1_MouseLeave(object sender, EventArgs e)
        {
            PanelInim1.BackColor = SystemColors.Control;
        }

        private void PanelInim2_MouseLeave(object sender, EventArgs e)
        {
            PanelInim2.BackColor = SystemColors.Control;
        }

        private void PanelBoss_MouseLeave(object sender, EventArgs e)
        {
            PanelBoss.BackColor = SystemColors.Control;
        }
        #endregion

        #region Abrir
        private void BtnAtaque_Click(object sender, EventArgs e)
        {
            PanelAtaque.Parent = PanelJogadoresEmBatalha;
            PanelAtaque.Top = PanelOpcoesLuta.Top;
            PanelAtaque.Left = PanelOpcoesLuta.Left;
            PanelAtaque.Visible = true;
            PanelOpcoesLuta.Visible = false;
        }
        #endregion

        #region Voltar
        private void BtnVoltarAtaque_Click(object sender, EventArgs e)
        {
            PanelAtaque.Visible = false;
            PanelOpcoesLuta.Visible = true;
        }
        #endregion

        int AtaqueNormalAtivado;
        int AtaqueEspecialAtivado;

        #region Ataque Normal
        private void BtnAtkNormal_Click(object sender, EventArgs e)
        {
            AtaqueNormalAtivado = 1;
            AtivarSeleçãoDosInimigos = 1;
        }
        #endregion

        int dano;
        int VidaE1 = 15;
        int VidaE2 = 15;
        int VidaE3 = 15;
        int VidaE4 = 15;
        int VidaBoss = 50;

        #region Atacar Boss
        private void PanelBoss_MouseClick(object sender, MouseEventArgs e)
        {

            switch (TurnoJogador)
            {
                case 1:
                    dano = (p1.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 2:
                    dano = (p2.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 3:
                    dano = (p3.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 4:
                    dano = (p4.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 5:
                    dano = (p5.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
            }

            if (AtaqueNormalAtivado == 1)
            {
                if (VidaBoss >= dano)
                {
                    VidaBoss -= dano;
                    PbHPBoss.Value = Convert.ToInt32(Math.Round(VidaBoss * 1.66667));
                    AtivarSeleçãoDosInimigos = 0;
                    AtaqueNormalAtivado = 0;
                    AvançarPersonagem.Enabled = true;

                    TurnoJogador++;
                    PassarTurno();

                    if (PbHPBoss.Value < 1)
                    {
                        LblNomeBoss.Text = "morri...";
                    }
                }
            }
        }
        #endregion

        #region Atacar Inimigo 1
        private void PanelInim1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (TurnoJogador)
            {
                case 1:
                    dano = (p1.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 2:
                    dano = (p2.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 3:
                    dano = (p3.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 4:
                    dano = (p4.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 5:
                    dano = (p5.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
            }

            if (AtaqueNormalAtivado == 1)
            {
                if (VidaE1 >= dano)
                {
                    VidaE1 -= dano;
                    PbHPInim1.Value = Convert.ToInt32(VidaE1 * 5);
                    AtivarSeleçãoDosInimigos = 0;
                    AtaqueNormalAtivado = 0;

                    AvançarPersonagem.Enabled = true;

                    if (PbHPInim1.Value < 1)
                    {
                        LblNomeInim1.Text = "morri...";
                    }


                    TurnoJogador++;
                    PassarTurno();
                }
            }
        }
        #endregion

        #region Atacar Inimigo 2
        private void PanelInim2_MouseClick(object sender, MouseEventArgs e)
        {
            switch (TurnoJogador)
            {
                case 1:
                    dano = (p1.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 2:
                    dano = (p2.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 3:
                    dano = (p3.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 4:
                    dano = (p4.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 5:
                    dano = (p5.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
            }

            if (AtaqueNormalAtivado == 1)
            {
                if (VidaE2 >= dano)
                {
                    VidaE2 -= dano;
                    PbHPInim2.Value = Convert.ToInt32(VidaE2 * 5);
                    AtivarSeleçãoDosInimigos = 0;
                    AtaqueNormalAtivado = 0;

                    AvançarPersonagem.Enabled = true;

                    if (PbHPInim2.Value < 1)
                    {
                        LblNomeInim2.Text = "morri...";
                    }

                    TurnoJogador++;
                    PassarTurno();
                }
            }
        }
        #endregion

        #region Atacar Inimigo 3
        private void PanelInim3_MouseClick(object sender, MouseEventArgs e)
        {
            switch (TurnoJogador)
            {
                case 1:
                    dano = (p1.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 2:
                    dano = (p2.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 3:
                    dano = (p3.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 4:
                    dano = (p4.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 5:
                    dano = (p5.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
            }

            if (AtaqueNormalAtivado == 1)
            {
                if (VidaE3 >= dano)
                {
                    VidaE3 -= dano;
                    PbHPInim3.Value = Convert.ToInt32(VidaE3 * 5);
                    AtivarSeleçãoDosInimigos = 0;
                    AtaqueNormalAtivado = 0;

                    AvançarPersonagem.Enabled = true;

                    if (PbHPInim3.Value < 1)
                    {
                        LblNomeInim3.Text = "morri...";
                    }

                    TurnoJogador++;
                    PassarTurno();
                }
            }
        }
        #endregion

        #region Atacar Inimigo 4
        private void PanelInim4_MouseClick(object sender, MouseEventArgs e)
        {
            switch (TurnoJogador)
            {
                case 1:
                    dano = (p1.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 2:
                    dano = (p2.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 3:
                    dano = (p3.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 4:
                    dano = (p4.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
                case 5:
                    dano = (p5.DanoPers + rnd.Next(3) - rnd.Next(3) - rnd.Next(6));
                    break;
            }

            if (AtaqueNormalAtivado == 1)
            {
                if (VidaE4 >= dano)
                {
                    VidaE4 -= dano;
                    PbHPInim4.Value = Convert.ToInt32(VidaE4 * 5);
                    AtivarSeleçãoDosInimigos = 0;
                    AtaqueNormalAtivado = 0;
                    AvançarPersonagem.Enabled = true;

                    if (PbHPInim4.Value < 1)
                    {
                        LblNomeInim4.Text = "morri...";
                    }

                    TurnoJogador++;
                    PassarTurno();
                }
            }
        }
        #endregion

        #region Ataque Especial
        private void BtnAtkEspecial_Click(object sender, EventArgs e)
        {
            AtaqueEspecialAtivado = 1;
            AtivarSeleçãoDosInimigos = 1;
        }
        #endregion

        #endregion

        #region Inventario

        #region Abrir
        private void BtnInventario_Click(object sender, EventArgs e)
        {
            PanelInventario.Parent = PanelJogadoresEmBatalha;
            PanelInventario.Top = PanelOpcoesLuta.Top;
            PanelInventario.Left = PanelOpcoesLuta.Left;
            PanelInventario.Visible = true;
            PanelOpcoesLuta.Visible = false;
        }
        #endregion

        #region Voltar
        private void BtnVoltarInventario_Click(object sender, EventArgs e)
        {
            PanelInventario.Visible = false;
            PanelOpcoesLuta.Visible = true;
        }
        #endregion

        #endregion

        #region Passar Turno Personagens
        int TurnoJogador = 1;

        private void PassarTurno()
        {
            if (TurnoJogador == 1)
            {
                PbRostoAtual.Image = PbRostoAtual.Image;
                lblPersAtual.Text = lblPersAtual.Text;
                PbGHP.Value = PbGHP.Value;
                PbGMP.Value = PbGMP.Value;
                VidaAtual.Text = Convert.ToString(p1.HPPers);
                ManaAtual.Text = Convert.ToString(p1.MPPers);

                // PanelPeq1.Visible = false;

                if (Convert.ToInt32(TotalJogadores) == 1)
                {
                    //Passa pro Inimigo
                }

                if (Convert.ToInt32(TotalJogadores) == 2)
                {
                    // PanelPeq1.Location = new Point(10, 824);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 424);
                }

                if (Convert.ToInt32(TotalJogadores) == 3)
                {
                    // PanelPeq1.Location = new Point(10, 824);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 424);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 524);
                }

                if (Convert.ToInt32(TotalJogadores) == 4)
                {
                    // PanelPeq1.Location = new Point(10, 824);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 424);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 524);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 624);
                }

                if (Convert.ToInt32(TotalJogadores) == 5)
                {
                    // PanelPeq1.Location = new Point(10, 824);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 424);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 524);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 624);

                    PanelPeq5.Visible = true;
                    PanelPeq5.Location = new Point(10, 724);
                }
            }

            if (TurnoJogador == 2)
            {
                PbRostoAtual.Image = PbRosto2.Image;
                lblPersAtual.Text = lblPersonagem2.Text;
                PbGHP.Value = PbP2HP.Value;
                PbGMP.Value = PbP2MP.Value;
                PanelPeq2.Visible = false;
                VidaAtual.Text = Convert.ToString(p2.HPPers);
                ManaAtual.Text = Convert.ToString(p2.MPPers);

                if (Convert.ToInt32(TotalJogadores) == 2)
                {
                    PanelPeq2.Location = new Point(10, 824);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 424);
                }

                if (Convert.ToInt32(TotalJogadores) == 3)
                {
                    PanelPeq2.Location = new Point(10, 824);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 424);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 524);
                }

                if (Convert.ToInt32(TotalJogadores) == 4)
                {
                    PanelPeq2.Location = new Point(10, 824);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 424);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 524);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 624);
                }

                if (Convert.ToInt32(TotalJogadores) == 5)
                {
                    PanelPeq2.Location = new Point(10, 824);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 424);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 524);

                    PanelPeq5.Visible = true;
                    PanelPeq5.Location = new Point(10, 624);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 724);
                }
            }

            if (TurnoJogador == 3)
            {
                PbRostoAtual.Image = PbRosto3.Image;
                lblPersAtual.Text = lblPersonagem3.Text;
                PbGHP.Value = PbP3HP.Value;
                PbGMP.Value = PbP3MP.Value;
                PanelPeq3.Visible = false;
                VidaAtual.Text = Convert.ToString(p3.HPPers);
                ManaAtual.Text = Convert.ToString(p3.MPPers);

                if (Convert.ToInt32(TotalJogadores) == 3)
                {
                    PanelPeq3.Location = new Point(10, 824);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 424);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 524);
                }

                if (Convert.ToInt32(TotalJogadores) == 4)
                {
                    PanelPeq3.Location = new Point(10, 824);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 424);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 524);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 624);
                }

                if (Convert.ToInt32(TotalJogadores) == 5)
                {
                    PanelPeq3.Location = new Point(10, 824);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 424);

                    PanelPeq5.Visible = true;
                    PanelPeq5.Location = new Point(10, 524);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 624);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 724);
                }
            }

            if (TurnoJogador == 4)
            {
                PbRostoAtual.Image = PbRosto4.Image;
                lblPersAtual.Text = lblPersonagem4.Text;
                PbGHP.Value = PbP4HP.Value;
                PbGMP.Value = PbP4MP.Value;
                PanelPeq4.Visible = false;
                VidaAtual.Text = Convert.ToString(p4.HPPers);
                ManaAtual.Text = Convert.ToString(p4.MPPers);

                if (Convert.ToInt32(TotalJogadores) == 4)
                {
                    PanelPeq4.Location = new Point(10, 824);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 424);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 524);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 624);

                }

                if (Convert.ToInt32(TotalJogadores) == 5)
                {
                    PanelPeq4.Location = new Point(10, 824);

                    PanelPeq5.Visible = true;
                    PanelPeq5.Location = new Point(10, 424);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 524);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 624);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 724);

                }
            }

            if (TurnoJogador == 5)
            {
                PbRostoAtual.Image = PbRosto5.Image;
                lblPersAtual.Text = lblPersonagem5.Text;
                PbGHP.Value = PbP5HP.Value;
                PbGMP.Value = PbP5MP.Value;
                PanelPeq5.Visible = false;
                VidaAtual.Text = Convert.ToString(p5.HPPers);
                ManaAtual.Text = Convert.ToString(p5.MPPers);

                if (Convert.ToInt32(TotalJogadores) == 5)
                {
                    PanelPeq5.Location = new Point(10, 824);

                    // PanelPeq1.Visible = true;
                    // PanelPeq1.Location = new Point(10, 424);

                    PanelPeq2.Visible = true;
                    PanelPeq2.Location = new Point(10, 524);

                    PanelPeq3.Visible = true;
                    PanelPeq3.Location = new Point(10, 624);

                    PanelPeq4.Visible = true;
                    PanelPeq4.Location = new Point(10, 724);
                }
            }

            if (TurnoJogador > Convert.ToInt32(TotalJogadores))
            {
                TurnoJogador = 1;
                PassarTurno();
            }
        }
        #endregion

        #region Botão Teste
        private void BtnTeste_Click(object sender, EventArgs e)
        {
            TurnoJogador++;
            PassarTurno();
        }
        #endregion

        #region Avançar Personagem
        int Ticks = 0;
        private void AvançarPersonagem_Tick(object sender, EventArgs e)
        {
            int UltimoJogador = TurnoJogador - 1;
            Ticks++;
            if (Ticks <= 20)
            {
                if (UltimoJogador == 1)
                {
                    PF1.Top--;
                }
                if (UltimoJogador == 2)
                {
                    PF2.Top--;
                }
                if (UltimoJogador == 3)
                {
                    PT1.Top--;
                }
                if (UltimoJogador == 4)
                {
                    PT2.Top--;
                }
                if (UltimoJogador == 0)
                {
                    PT3.Top--;
                }
            }
            if (Ticks >= 20 && Ticks <= 40)
            {

                if (UltimoJogador == 1)
                {
                    PF1.Top++;
                }
                if (UltimoJogador == 2)
                {
                    PF2.Top++;
                }
                if (UltimoJogador == 3)
                {
                    PT1.Top++;
                }
                if (UltimoJogador == 4)
                {
                    PT2.Top++;
                }
                if (UltimoJogador == 0)
                {
                    PT3.Top++;
                }
            }

            if (Ticks > 40)
            {
                Ticks = 0;
                AvançarPersonagem.Enabled = false;
            }
        }
        #endregion
    }
}