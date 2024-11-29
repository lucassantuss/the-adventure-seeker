using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPG
{
    public partial class Mapa1 : Form
    {
        Configuracoes c = new Configuracoes();

        #region Carregar Página
        public Mapa1()
        {
            InitializeComponent();

            #region Música
            c.MusicaGeral.SoundLocation = "";
            c.MusicaGeral.PlayLooping();
            #endregion

            Personagem1.Parent = pbMapa1;
        }

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

        #region Timer
        private void TimerMovimento_Tick(object sender, EventArgs e)
        {
            label9.Text = Convert.ToString(Personagem1.Location.X);
            label11.Text = Convert.ToString(Personagem1.Location.Y);
        }
        #endregion

        #region Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Sair?", "Sair?",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        #region Dado
        int NumDado;
        private void btnDado_Click(object sender, EventArgs e)
        {
            #region Código do Dado

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

        public void MoverCima()
        {
            Movimento = 8;
            Personagem1.Top -= Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem1.Top += Velocidade;
                Colidiu = false;
            }
        }

        public void MoverBaixo()
        {
            Movimento = 2;
            Personagem1.Top += Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem1.Top -= Velocidade;
                Colidiu = false;
            }
        }

        public void MoverEsq()
        {
            Movimento = 4;
            Personagem1.Left -= Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem1.Left += Velocidade;
                Colidiu = false;
            }
        }

        public void MoverDir()
        {
            Movimento = 6;
            Personagem1.Left += Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem1.Left -= Velocidade;
                Colidiu = false;
            }
        }

        public void Parar()
        {

        }

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
                    if (ctrl != pbMapa1)
                    {
                        int pbX1 = ctrl.Location.X;
                        int pbX2 = ctrl.Width - 8;
                        int pbY1 = ctrl.Location.Y - 2;
                        int pbY2 = ctrl.Height - 8;

                        int PersonagemX1 = Personagem1.Location.X;
                        int PersonagemY1 = Personagem1.Location.Y;
                        int PersonagemX2 = Personagem1.Width;
                        int PersonagemY2 = Personagem1.Height;

                        Rectangle PbRetangulo = new Rectangle(pbX1, pbY1, pbX2, pbY2);
                        Rectangle PersRetangulo = new Rectangle(PersonagemX1, PersonagemY1, PersonagemX2, PersonagemY2);

                        if (PbRetangulo.IntersectsWith(PersRetangulo))
                        {
                            Colidiu = true;
                            label11.Text = "Colidiu";
                        }
                    }
                }
            }
        }
        #endregion
    }
}