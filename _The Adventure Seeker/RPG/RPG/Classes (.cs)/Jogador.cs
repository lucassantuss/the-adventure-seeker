using System.Windows.Forms;

namespace RPG
{
    class Jogador
    {
        #region Get e Set
        private object resposta;
        private string p1;
        private string p2;
        private string p3;
        private string p4;
        private string p5;

        public string P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        public string P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public string P3
        {
            get { return p3; }
            set { p3 = value; }
        }

        public string P4
        {
            get { return p4; }
            set { p4 = value; }
        }

        public string P5
        {
            get { return p5; }
            set { p5 = value; }
        }
        #endregion

        #region Método Sair
        public void saida()
        {
            this.resposta = MessageBox.Show("Deseja sair do jogo?",
                "**** FINALIZANDO ****",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (this.resposta.Equals(DialogResult.Yes))
            {
                Application.Exit();
            }
        }
        #endregion
    }
}