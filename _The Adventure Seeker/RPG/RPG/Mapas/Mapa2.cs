using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPG
{
    public partial class Mapa5 : Form
    {
        Configuracoes c = new Configuracoes();

        public Mapa5()
        {
            InitializeComponent();

            #region Música
            c.MusicaGeral.SoundLocation = "";
            c.MusicaGeral.PlayLooping();
            #endregion
        }

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
            Personagem.Top -= Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem.Top += Velocidade;
                Colidiu = false;
            }
        }

        public void MoverBaixo()
        {
            Movimento = 2;
            Personagem.Top += Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem.Top -= Velocidade;
                Colidiu = false;
            }
        }

        public void MoverEsq()
        {
            Movimento = 4;
            Personagem.Left -= Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem.Left += Velocidade;
                Colidiu = false;
            }
        }

        public void MoverDir()
        {
            Movimento = 6;
            Personagem.Left += Velocidade;
            Colidir(Mapa2.Controls);
            if (Colidiu == true)
            {
                Personagem.Left -= Velocidade;
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
                    if (ctrl != pbMapa)
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