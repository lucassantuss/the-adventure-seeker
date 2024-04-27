using System;
using System.Media;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RPG
{
    public partial class Configuracoes : Form
    {
        #region Inicializar
        public Configuracoes()
        {
            InitializeComponent();

            #region Música
            MusicaGeral.Stop();
            FundoConfig.SoundLocation = "Configurações.wav";
            FundoConfig.PlayLooping();
            #endregion
        }
        #endregion

        #region habilita acesso ao controle de som do windows
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region Botão Voltar
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Get e Set - Som
        public SoundPlayer MusicaGeral = new SoundPlayer();
        public SoundPlayer FundoConfig = new SoundPlayer();

        public SoundPlayer VolumeGeral
        {
            get
            {
                return MusicaGeral;
            }

            set
            {
                MusicaGeral = value;
            }
        }
        #endregion

        #region Botão OnOff (Ativado/Desativado)
        private void BtnOn_Click(object sender, EventArgs e)
        {
            FundoConfig.PlayLooping();

            // Ativa o som do sistema 
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        private void BtnOff_Click(object sender, EventArgs e)
        {
            MusicaGeral.Stop();
            FundoConfig.Stop();

            // Deixa o som do sistema como Mudo 
            SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle,
                (IntPtr)APPCOMMAND_VOLUME_MUTE);
        }
        #endregion
    }
}