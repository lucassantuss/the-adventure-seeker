using System;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RPG
{
    public partial class RPG : Form
    {
        #region Variáveis
        Configuracoes c = new Configuracoes();
        Jogador j1 = new Jogador();
        Jogadores j = new Jogadores();
        ClassBanco bd = new ClassBanco();
        StringBuilder strQuery = new StringBuilder();
        ClassColunasBD ccbd = new ClassColunasBD();
        MySqlDataReader objDados;
        private object resposta;
        private object resposta1;
        int Local = 1;

        #region Declarando as var das Imagens dos Personagens
        Image Cima1;
        Image Cima2;

        Image Baixo1;
        Image Baixo2;

        Image Direita1;
        Image Direita2;

        Image Esquerda1;
        Image Esquerda2;
        #endregion

        string idPartida;
        string TotalJogadores;
        int ClasseJogo;
        int player = 1;
        #endregion

        #region Inicializar
        public RPG()
        {
            InitializeComponent();

            #region Música
            c.MusicaGeral.SoundLocation = "";
            c.MusicaGeral.PlayLooping();
            #endregion

            Personagem.Parent = pbMapa;

            #region Add Font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"A Goblin Appears!.ttf");
            pfc.AddFontFile(@"Ancient Modern Tales.ttf");

            foreach (Control c in this.Controls)
            {
                lblPersonagem.Font = new Font(pfc.Families[0], 11, FontStyle.Regular);
                lblClasse.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
                btnConfig.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
                btnSair.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
            }
            #endregion

            #region Image List

            #region ImageList Arqueiro
            Baixo1 = ILArqueiro.Images[0];
            Baixo2 = ILArqueiro.Images[1];

            Cima1 = ILArqueiro.Images[2];
            Cima2 = ILArqueiro.Images[3];

            Direita1 = ILArqueiro.Images[4];
            Direita2 = ILArqueiro.Images[5];

            Esquerda1 = ILArqueiro.Images[6];
            Esquerda2 = ILArqueiro.Images[7];
            #endregion

            #region ImageList Cavaleiro
            //Baixo1 = ILCavaleiro.Images[0];
            //Baixo2 = ILCavaleiro.Images[1];

            //Cima1 = ILCavaleiro.Images[2];
            //Cima2 = ILCavaleiro.Images[3];

            //Direita1 = ILCavaleiro.Images[4];
            //Direita2 = ILCavaleiro.Images[5];

            //Esquerda1 = ILCavaleiro.Images[6];
            //Esquerda2 = ILCavaleiro.Images[7];
            #endregion

            #region ImageList Clérigo
            Baixo1 = ILClérigo.Images[0];
            Baixo2 = ILClérigo.Images[1];

            Cima1 = ILClérigo.Images[2];
            Cima2 = ILClérigo.Images[3];

            Direita1 = ILClérigo.Images[4];
            Direita2 = ILClérigo.Images[5];

            Esquerda1 = ILClérigo.Images[6];
            Esquerda2 = ILClérigo.Images[7];
            #endregion

            #region ImageList Mago
            //Baixo1 = ILMago.Images[0];
            //Baixo2 = ILMago.Images[1];

            //Cima1 = ILMago.Images[2];
            //Cima2 = ILMago.Images[3];

            //Direita1 = ILMago.Images[4];
            //Direita2 = ILMago.Images[5];

            //Esquerda1 = ILMago.Images[6];
            //Esquerda2 = ILMago.Images[7];
            #endregion

            #region ImageList Paladino
            //Baixo1 = ILPaladino.Images[0];
            //Baixo2 = ILPaladino.Images[1];

            //Cima1 = ILPaladino.Images[2];
            //Cima2 = ILPaladino.Images[3];

            //Direita1 = ILPaladino.Images[4];
            //Direita2 = ILPaladino.Images[5];

            //Esquerda1 = ILPaladino.Images[6];
            //Esquerda2 = ILPaladino.Images[7];
            #endregion

            #endregion

            #region Pesquisar Classes
            Arqueiro();
            Cavaleiro();
            Clérigo();
            Mago();
            Paladino();
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
                lblPersonagem.Text = objDados["NomeJogador"].ToString();
                idPartida = objDados["idPartida"].ToString();

                switch (objDados["idClasse"])
                {
                    case 1:
                        Arqueiro();
                        break;

                    case 2:
                        Cavaleiro();
                        break;

                    case 3:
                        Clérigo();
                        break;

                    case 4:
                        Mago();
                        break;

                    case 5:
                        Paladino();
                        break;
                }
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
            #endregion

            VerificarTotalJogadores();

            MoverCima();
        }
        #endregion

        #region Carregar a Página
        private void RPG_Load(object sender, EventArgs e)
        {
            SetFeatureToAllControls(this.Controls);
        }

        private void SetFeatureToAllControls(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Control control in cc)
                {
                    control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
                    SetFeatureToAllControls(control.Controls);
                }
            }
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }
        #endregion

        #region Dados das Classes

        #region Arqueiro
        public void Arqueiro()
        {
            ClasseJogo = 1;
            ccbd.IdClasse = 1;
            bd.PesquisarClasse(ccbd.IdClasse);
            objDados = bd.PesquisarClasse(ccbd.IdClasse);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Classe não existente!!!",
                    "*** CLASSE INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                objDados.Read();

                lblClasse.Text = objDados["NomeClasse"].ToString();
                lblVida.Text = "Vida: " + objDados["Vida"].ToString();
                lblMana.Text = "Mana: " + objDados["Mana"].ToString();
                ProgressBMana.Value = 0;
                lblDano.Text = objDados["Dano"].ToString();
                lblAgilidade.Text = objDados["Agilidade"].ToString();
                lblDefesa.Text = objDados["Defesa"].ToString();
                lblDefesaMagica.Text = objDados["DefesaMagica"].ToString();
                pbRosto.Image = ILRosto.Images[0];
                Baixo1 = ILArqueiro.Images[0];
                Baixo2 = ILArqueiro.Images[1];
                Cima1 = ILArqueiro.Images[2];
                Cima2 = ILArqueiro.Images[3];
                Direita1 = ILArqueiro.Images[4];
                Direita2 = ILArqueiro.Images[5];
                Esquerda1 = ILArqueiro.Images[6];
                Esquerda2 = ILArqueiro.Images[7];
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Cavaleiro
        public void Cavaleiro()
        {
            ClasseJogo = 2;
            ccbd.IdClasse = 2;
            bd.PesquisarClasse(ccbd.IdClasse);
            objDados = bd.PesquisarClasse(ccbd.IdClasse);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Classe não existente!!!",
                    "*** CLASSE INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                objDados.Read();

                lblClasse.Text = objDados["NomeClasse"].ToString();
                lblVida.Text = "Vida: " + objDados["Vida"].ToString();
                lblMana.Text = "Mana: " + objDados["Mana"].ToString();
                ProgressBMana.Value = 0;
                lblDano.Text = objDados["Dano"].ToString();
                lblAgilidade.Text = objDados["Agilidade"].ToString();
                lblDefesa.Text = objDados["Defesa"].ToString();
                lblDefesaMagica.Text = objDados["DefesaMagica"].ToString();
                pbRosto.Image = ILRosto.Images[1];
                //Baixo1 = ILCavaleiro.Images[0];
                //Baixo2 = ILCavaleiro.Images[1];
                //Cima1 = ILCavaleiro.Images[2];
                //Cima2 = ILCavaleiro.Images[3];
                //Direita1 = ILCavaleiro.Images[4];
                //Direita2 = ILCavaleiro.Images[5];
                //Esquerda1 = ILCavaleiro.Images[6];
                //Esquerda2 = ILCavaleiro.Images[7];
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Clérigo
        public void Clérigo()
        {
            ClasseJogo = 3;
            ccbd.IdClasse = 3;
            bd.PesquisarClasse(ccbd.IdClasse);
            objDados = bd.PesquisarClasse(ccbd.IdClasse);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Classe não existente!!!",
                    "*** CLASSE INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                objDados.Read();

                lblClasse.Text = objDados["NomeClasse"].ToString();
                lblVida.Text = "Vida: " + objDados["Vida"].ToString();
                lblMana.Text = "Mana: " + objDados["Mana"].ToString();
                ProgressBMana.Value = 100;
                lblDano.Text = objDados["Dano"].ToString();
                lblAgilidade.Text = objDados["Agilidade"].ToString();
                lblDefesa.Text = objDados["Defesa"].ToString();
                lblDefesaMagica.Text = objDados["DefesaMagica"].ToString();
                pbRosto.Image = ILRosto.Images[2];
                Baixo1 = ILClérigo.Images[0];
                Baixo2 = ILClérigo.Images[1];
                Cima1 = ILClérigo.Images[2];
                Cima2 = ILClérigo.Images[3];
                Direita1 = ILClérigo.Images[4];
                Direita2 = ILClérigo.Images[5];
                Esquerda1 = ILClérigo.Images[6];
                Esquerda2 = ILClérigo.Images[7];
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Mago
        public void Mago()
        {
            ClasseJogo = 4;
            ccbd.IdClasse = 4;
            bd.PesquisarClasse(ccbd.IdClasse);
            objDados = bd.PesquisarClasse(ccbd.IdClasse);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Classe não existente!!!",
                    "*** CLASSE INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                objDados.Read();

                lblClasse.Text = objDados["NomeClasse"].ToString();
                lblVida.Text = "Vida: " + objDados["Vida"].ToString();
                lblMana.Text = "Mana: " + objDados["Mana"].ToString();
                ProgressBMana.Value = 100;
                lblDano.Text = objDados["Dano"].ToString();
                lblAgilidade.Text = objDados["Agilidade"].ToString();
                lblDefesa.Text = objDados["Defesa"].ToString();
                lblDefesaMagica.Text = objDados["DefesaMagica"].ToString();
                pbRosto.Image = ILRosto.Images[3];
                Baixo1 = ILMago.Images[0];
                Baixo2 = ILMago.Images[1];
                Cima1 = ILMago.Images[2];
                Cima2 = ILMago.Images[3];
                Direita1 = ILMago.Images[4];
                Direita2 = ILMago.Images[5];
                Esquerda1 = ILMago.Images[6];
                Esquerda2 = ILMago.Images[7];
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Paladino
        public void Paladino()
        {
            ClasseJogo = 5;
            ccbd.IdClasse = 5;
            bd.PesquisarClasse(ccbd.IdClasse);
            objDados = bd.PesquisarClasse(ccbd.IdClasse);

            if (!objDados.HasRows)
            {
                MessageBox.Show("Classe não existente!!!",
                    "*** CLASSE INEXISTENTE ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            else
            {
                objDados.Read();

                lblClasse.Text = objDados["NomeClasse"].ToString();
                lblVida.Text = "Vida: " + objDados["Vida"].ToString();
                lblMana.Text = "Mana: " + objDados["Mana"].ToString();
                ProgressBMana.Value = 100;
                lblDano.Text = objDados["Dano"].ToString();
                lblAgilidade.Text = objDados["Agilidade"].ToString();
                lblDefesa.Text = objDados["Defesa"].ToString();
                lblDefesaMagica.Text = objDados["DefesaMagica"].ToString();
                pbRosto.Image = ILRosto.Images[4];
                Baixo1 = ILPaladino.Images[0];
                Baixo2 = ILPaladino.Images[1];
                Cima1 = ILPaladino.Images[2];
                Cima2 = ILPaladino.Images[3];
                Direita1 = ILPaladino.Images[4];
                Direita2 = ILPaladino.Images[5];
                Esquerda1 = ILPaladino.Images[6];
                Esquerda2 = ILPaladino.Images[7];
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #endregion

        #region Dados dos Jogadores

        #region Jogador 1
        public void Jogador1()
        {
            ccbd.IdJogador = 1;
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
                lblPersonagem.Text = objDados["NomeJogador"].ToString();

                switch (objDados["idClasse"])
                {
                    case 1:
                        Arqueiro();
                        break;

                    case 2:
                        Cavaleiro();
                        break;

                    case 3:
                        Clérigo();
                        break;

                    case 4:
                        Mago();
                        break;

                    case 5:
                        Paladino();
                        break;
                }
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Jogador 2
        public void Jogador2()
        {
            ccbd.IdJogador = 2;
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
                lblPersonagem.Text = objDados["NomeJogador"].ToString();

                switch (objDados["idClasse"])
                {
                    case 1:
                        Arqueiro();
                        break;

                    case 2:
                        Cavaleiro();
                        break;

                    case 3:
                        Clérigo();
                        break;

                    case 4:
                        Mago();
                        break;

                    case 5:
                        Paladino();
                        break;
                }
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Jogador 3
        public void Jogador3()
        {
            ccbd.IdJogador = 3;
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
                lblPersonagem.Text = objDados["NomeJogador"].ToString();

                switch (objDados["idClasse"])
                {
                    case 1:
                        Arqueiro();
                        break;

                    case 2:
                        Cavaleiro();
                        break;

                    case 3:
                        Clérigo();
                        break;

                    case 4:
                        Mago();
                        break;

                    case 5:
                        Paladino();
                        break;
                }
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Jogador 4
        public void Jogador4()
        {
            ccbd.IdJogador = 4;
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
                lblPersonagem.Text = objDados["NomeJogador"].ToString();

                switch (objDados["idClasse"])
                {
                    case 1:
                        Arqueiro();
                        break;

                    case 2:
                        Cavaleiro();
                        break;

                    case 3:
                        Clérigo();
                        break;

                    case 4:
                        Mago();
                        break;

                    case 5:
                        Paladino();
                        break;
                }
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Jogador 5
        public void Jogador5()
        {
            ccbd.IdJogador = 5;
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
                lblPersonagem.Text = objDados["NomeJogador"].ToString();

                switch (objDados["idClasse"])
                {
                    case 1:
                        Arqueiro();
                        break;

                    case 2:
                        Cavaleiro();
                        break;

                    case 3:
                        Clérigo();
                        break;

                    case 4:
                        Mago();
                        break;

                    case 5:
                        Paladino();
                        break;
                }
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

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

        #region Botão Troca Direita
        private void BtnTrocaDireita_Click(object sender, EventArgs e)
        {
            if (player > 0 && player + 1 <= int.Parse(TotalJogadores))
            {
                player++;
                AlternarPbPersonagem();
            }
        }
        #endregion

        #region Botão Troca Esquerda
        private void BtnTrocaEsquerda_Click(object sender, EventArgs e)
        {
            if (player - 1 > 0 && player <= int.Parse(TotalJogadores))
            {
                player--;
                AlternarPbPersonagem();
            }
        }
        #endregion

        #region Alternar Personagem
        public void AlternarPbPersonagem()
        {
            switch (player)
            {
                case 1:
                    Jogador1();
                    break;

                case 2:
                    Jogador2();
                    break;

                case 3:
                    Jogador3();
                    break;

                case 4:
                    Jogador4();
                    break;

                case 5:
                    Jogador5();
                    break;
            }
        }
        #endregion

        #endregion

        #region Timer

        int Passo = 0;

        #region Timer Movimento
        private void TimerMovimento_Tick(object sender, EventArgs e)
        {
            PosX.Text = Convert.ToString(Personagem.Location.X);
            PosY.Text = Convert.ToString(Personagem.Location.Y);

            #region Personagem andar MUDAR IMAGEM

            #region Cima
            if (Movimento == 8)
            {
                if (Passo % 2 == 0)
                {
                    Personagem.Image = Cima1;
                }

                if (Passo % 2 == 1)
                {
                    Personagem.Image = Cima2;
                }
            }
            #endregion

            #region Baixo
            if (Movimento == 2)
            {
                if (Passo % 2 == 0)
                {
                    Personagem.Image = Baixo1;
                }

                if (Passo % 2 == 1)
                {
                    Personagem.Image = Baixo2;
                }
            }
            #endregion

            #region Direita
            if (Movimento == 6)
            {
                if (Passo % 2 == 0)
                {
                    Personagem.Image = Direita1;
                }

                if (Passo % 2 == 1)
                {
                    Personagem.Image = Direita2;
                }
            }
            #endregion

            #region Esquerda
            if (Movimento == 4)
            {
                if (Passo % 2 == 0)
                {
                    Personagem.Image = Esquerda1;
                }

                if (Passo % 2 == 1)
                {
                    Personagem.Image = Esquerda2;
                }
            }
            #endregion

            #endregion
        }
        #endregion

        #region Timer Passo
        private void TimerPasso_Tick(object sender, EventArgs e)
        {
            Passo++;
            Parar();
        }
        #endregion

        #endregion

        #region Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            j1.saida();
        }
        #endregion

        #region Dado
        int NumDado;
        private void btnDado_Click(object sender, EventArgs e)
        {
            #region Codigo do Dado

            // Cria uma variavel NumDado e armazena um numero inteiro aleatorio entre 1 e 6
            Random rndNumero = new Random();

            NumDado = rndNumero.Next(1, 7);

            //Coloca a Imagem do Dado correspondente
            /*
            if (NumDado == 1)
            {
                pbDado.Load("Dado1.png");
            }

            if (NumDado == 2)
            {
                pbDado.Load("Dado2.png");
            }

            if (NumDado == 3)
            {
                pbDado.Load("Dado3.png");
            }

            if (NumDado == 4)
            {
                pbDado.Load("Dado4.png");
            }

            if (NumDado == 5)
            {
                pbDado.Load("Dado5.png");
            }

            if (NumDado == 6)
            {
                pbDado.Load("Dado6.png");
            }
            
            */
            #endregion
        }
        #endregion

        #region Movimento

        int Velocidade = 3;
        Boolean Colidiu = false;
        int Movimento;
        // 2 Baixo
        // 4 Esquerda
        // 6 Direita
        // 8 Cima

        #region Mover Cima
        public void MoverCima()
        {
            Movimento = 8;
            Personagem.Top -= Velocidade;

            if (Local == 1)
            {
                Colidir(Mapa.Controls);
            }
            else
            {
                if (Local == 2)
                {
                    Colidir(Mapa2.Controls);
                }
            }

            if (Colidiu == true)
            {
                Personagem.Top += Velocidade;
                Colidiu = false;
            }
        }
        #endregion

        #region Mover Baixo
        public void MoverBaixo()
        {
            Movimento = 2;
            Personagem.Top += Velocidade;

            if (Local == 1)
            {
                Colidir(Mapa.Controls);
            }
            else
            {
                if (Local == 2)
                {
                    Colidir(Mapa2.Controls);
                }
            }

            if (Colidiu == true)
            {
                Personagem.Top -= Velocidade;
                Colidiu = false;
            }
        }
        #endregion

        #region Mover Esquerda
        public void MoverEsq()
        {
            Movimento = 4;
            Personagem.Left -= Velocidade;

            if (Local == 1)
            {
                Colidir(Mapa.Controls);
            }
            else
            {
                if (Local == 2)
                {
                    Colidir(Mapa2.Controls);
                }
            }

            if (Colidiu == true)
            {
                Personagem.Left += Velocidade;
                Colidiu = false;
            }
        }
        #endregion

        #region Mover Direita
        public void MoverDir()
        {
            Movimento = 6;
            Personagem.Left += Velocidade;

            if (Local == 1)
            {
                Colidir(Mapa.Controls);
            }
            else
            {
                if (Local == 2)
                {
                    Colidir(Mapa2.Controls);
                }
            }

            if (Colidiu == true)
            {
                Personagem.Left -= Velocidade;
                Colidiu = false;
            }
        }
        #endregion

        #region Parar
        public void Parar()
        {
            Movimento = 0;
        }
        #endregion

        #endregion

        #region Teclado
        public void RPG_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoverCima();
                    break;

                case Keys.Down:
                    MoverBaixo();
                    break;

                case Keys.Right:
                    MoverDir();
                    break;

                case Keys.Left:
                    MoverEsq();
                    break;

                default:
                    Parar();
                    break;
            }
        }
        #endregion

        #region Colisão
        private void Colidir(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is PictureBox)
                {
                    if (ctrl != pbMapa && ctrl != pbMapa1)
                    {
                        int pbX1 = ctrl.Location.X;
                        int pbX2 = ctrl.Width - 8;
                        int pbY1 = ctrl.Location.Y - 2;
                        int pbY2 = ctrl.Height - 8;

                        int PersonagemX1 = Personagem.Location.X;
                        int PersonagemY1 = Personagem.Location.Y;
                        int PersonagemX2 = Personagem.Width;
                        int PersonagemY2 = Personagem.Height;

                        Rectangle PbRetangulo = new Rectangle(pbX1, pbY1, pbX2, pbY2);
                        Rectangle PersRetangulo = new Rectangle(PersonagemX1, PersonagemY1, PersonagemX2, PersonagemY2);

                        if (PbRetangulo.IntersectsWith(PersRetangulo))
                        {
                            #region Ver se é uma porta
                            string NomeDaPB = ctrl.Name;
                            Colidiu = true;

                            #region Casa Aberta
                            if (NomeDaPB == "CasaAberta")
                            {
                                this.resposta = MessageBox.Show("Deseja entrar na casa?",
                                    "**** CASA ABERTA ****",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2);

                                if (this.resposta.Equals(DialogResult.Yes))
                                {
                                    //Mapa.Visible = false;
                                    //Mapa3.Visible = true;

                                    //Personagem.Parent = pbMapa1;
                                    //Local = 3;
                                    //this.Hide();

                                    //this.Enabled = false;
                                    //TelaBatalha battle = new TelaBatalha();
                                    //battle.Closed += (s, args) => this.Close();
                                    //battle.Show();
                                    //battle.Enabled = true;
                                    //Mapa.Visible = false;
                                    //panel1.Visible = true;
                                    //Personagem.Parent = panel1;     
                                }
                            }
                            #endregion

                            #region Batalha
                            if (NomeDaPB == "Batalha")
                            {
                                this.resposta = MessageBox.Show("Deseja enfrentar os monstros?",
                                        "**** BATALHA ****",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button2);

                                if (this.resposta.Equals(DialogResult.Yes))
                                {
                                    this.Hide();
                                    this.Enabled = false;
                                    TelaBatalha battle = new TelaBatalha();
                                    battle.Closed += (s, args) => this.Close();
                                    battle.Show();
                                }
                            }
                            #endregion

                            #region Conversa NPC
                            if (NomeDaPB == "NPC")
                            {
                                this.resposta = MessageBox.Show("Olá " + lblPersonagem.Text + ", você está bem?",
                                        "**** CONVERSA COM O ALDEÃO ****",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.None,
                                        MessageBoxDefaultButton.Button2);

                                MessageBox.Show("Esta cidade não é mais segura, recentemente alguém ou alguma coisa anda ressucitando monstros por aí!",
                                    "*** CONVERSA COM O ALDEÃO ***",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.None);

                                this.resposta1 = MessageBox.Show("Eu ouvi alguns rumores e aparentemente você é um " + lblClasse.Text + ". \n \nGostaria de me ajudar vencendo esses monstros? Eu sei de onde eles surgem, porém não posso enfrentá-los sozinho, se aceitar, podemos ir até eles!",
                                        "**** CONVERSA COM O ALDEÃO ****",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.None,
                                        MessageBoxDefaultButton.Button2);

                                #region Sim
                                if (this.resposta1.Equals(DialogResult.Yes))
                                {
                                    MessageBox.Show("Muito bem! Siga-me que te levarei...",
                                        "*** CONVERSA COM O ALDEÃO ***",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.None);

                                    Mapa.Visible = false;
                                    Mapa2.Visible = true;

                                    Personagem.Parent = pbMapa1;
                                    Local = 2;

                                    Personagem.Location = new Point(856, 86);
                                }
                                #endregion

                                #region Não
                                if (this.resposta1.Equals(DialogResult.No))
                                {
                                    MessageBox.Show("OK! Estarei esperando caso mude de idéia.",
                                        "*** CONVERSA COM O ALDEÃO ***",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.None);
                                }
                                #endregion


                            }
                            #endregion

                            #region Casa Fechada
                            if (NomeDaPB == "CasaFechada")
                            {
                                MessageBox.Show("O dono da casa trancou a porta, portanto você não pode entrar!",
                                    "*** CASA FECHADA ***",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                            #endregion

                            #region Casa Vazia
                            if (NomeDaPB == "CasaVazia")
                            {
                                MessageBox.Show("Não tem ninguém em casa...",
                                    "*** CASA VAZIA ***",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }

                            if (NomeDaPB == "CasaVazia1")
                            {
                                MessageBox.Show("Não tem ninguém em casa...",
                                    "*** CASA VAZIA ***",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }

                            if (NomeDaPB == "CasaVazia2")
                            {
                                MessageBox.Show("Não tem ninguém em casa...",
                                    "*** CASA VAZIA ***",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }

                            if (NomeDaPB == "CasaVazia3")
                            {
                                MessageBox.Show("Não tem ninguém em casa...",
                                    "*** CASA VAZIA ***",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                            #endregion

                            #endregion
                        }
                    }
                }
            }
        }

        private void Teste_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            TelaBatalha battle = new TelaBatalha();
            battle.Closed += (s, args) => this.Close();
            battle.Show();
        }

        private void btnMissoes_Click(object sender, EventArgs e)
        {

        }

        private void Teste_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            this.Enabled = false;
            TelaBatalha battle = new TelaBatalha();
            battle.Closed += (s, args) => this.Close();
            battle.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
    }
}