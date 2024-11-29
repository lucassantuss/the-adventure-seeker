using System;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RPG
{
    class AtributosJogador
    {
        #region Variáveis
        ClassBanco bd = new ClassBanco();
        StringBuilder strQuery = new StringBuilder();
        ClassColunasBD ccbd = new ClassColunasBD();
        MySqlDataReader objDados;

        int ClasseJogo;
        DialogResult resposta;

        public string NomePersonagem { get; set; }
        public int NomeClasse { get; set; }
        public int HPPers { get; set; }
        public int MPPers { get; set; }
        public int SPPers { get; set; }
        public int DanoPers { get; set; }
        public int AgilPers { get; set; }
        public int DefPers { get; set; }
        public int DefMagPers { get; set; }

        #endregion

        #region Dados da Classe
        public void BuscarClasse(int idClasse)
        {
            ClasseJogo = idClasse;
            ccbd.IdClasse = idClasse;
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

                NomeClasse = Convert.ToInt32(objDados["idClasse"].ToString());
                HPPers = Convert.ToInt32(objDados["Vida"].ToString());
                MPPers = Convert.ToInt32(objDados["Mana"].ToString());
                DanoPers = Convert.ToInt32(objDados["Dano"].ToString());
                AgilPers = Convert.ToInt32(objDados["Agilidade"].ToString());
                DefPers = Convert.ToInt32(objDados["Defesa"].ToString());
                DefMagPers = Convert.ToInt32(objDados["DefesaMagica"].ToString());
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #region Dados dos Jogadores

        public void BuscarJogador(int Id)
        {
            ccbd.IdJogador = Id;
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
                NomePersonagem = objDados["NomeJogador"].ToString();
                int IdDaClasse = Convert.ToInt32(objDados["idClasse"].ToString());

                BuscarClasse(IdDaClasse);
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
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