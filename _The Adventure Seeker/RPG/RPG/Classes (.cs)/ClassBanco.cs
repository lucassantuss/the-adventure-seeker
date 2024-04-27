using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace RPG
{
    class ClassBanco
    {
        #region String de Conexao
        // Para criar string de Conexão, vai em "Project", depois em "Properties";
        // Type -- Connection string; Scope -- application; Value -- server = 127.0.0.1; user id = root; password=etec; database=BDRPG

        // string con = Properties.Settings.Default.ConexaoMySql;
        // string con = "server = 127.0.0.1; user id = root; password=etec; database=BDRPG";
        string con = "server = localhost; user id = root; password = admin; database = BDRPG";

        #endregion

        #region AbreBanco
        private MySqlConnection AbreBanco()
        {
            MySqlConnection ocon = new MySqlConnection(); //Variável de Conexão
            ocon.ConnectionString = this.con;
            ocon.Open(); //Abre a conexão
            return ocon;
        }
        #endregion

        #region FechaBanco
        private void FechaBanco(MySqlConnection ocon)
        {
            if (ocon.State == ConnectionState.Open) //Se a conexão tiver aberta
            {
                ocon.Close(); //Fecha a Conexão
            }
        }
        #endregion

        #region RetornaDataReader
        public MySqlDataReader RetornaDataReader(string strQuery)
        {
            MySqlConnection ocon = new MySqlConnection();
            MySqlCommand cmdComando = new MySqlCommand(); //Comando a ser executado

            try
            {
                ocon = AbreBanco(); //Conexão Aberta
                cmdComando.CommandText = strQuery; //Seleciona a operação que for mandada para o strQuery
                cmdComando.CommandType = CommandType.Text; //String de Comando
                cmdComando.Connection = ocon; //Mostra qual a conexão em questão
                return cmdComando.ExecuteReader(); //Executa o comando
            }

            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ExecutaComandoParam
        public void ExecutaComandoParam(string strSql, List<MySqlParameter> colParam)
        {
            try
            {
                MySqlConnection ocon = new MySqlConnection(); //Variável de Conexão
                MySqlCommand cmdComando = new MySqlCommand(); //Comando a ser executado

                ocon = AbreBanco();
                cmdComando.CommandText = strSql;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = ocon;
                cmdComando.Parameters.AddRange(colParam.ToArray());
                cmdComando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ExecutaComando
        public void ExecutaComando(string strSql)
        {
            try
            {
                MySqlConnection ocon = new MySqlConnection(); //Variável de Conexão
                MySqlCommand cmdComando = new MySqlCommand(); //Comando a ser executado

                ocon = AbreBanco();
                cmdComando.CommandText = strSql;
                cmdComando.CommandType = CommandType.Text;
                cmdComando.Connection = ocon;
                cmdComando.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region PesquisarJogador
        public MySqlDataReader PesquisarJogador(int CodigoJogador)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select * from Jogador where idJogador = " + CodigoJogador);
            return RetornaDataReader(strQuery.ToString());
        }
        #endregion

        #region PesquisarInimigoPartido
        public MySqlDataReader PesquisarInimigo(int IdPartida, int IdInimigo)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select * from DadosPartidaInimigo where idPartida = " + IdPartida + " and idInimigo = " + IdInimigo);
            return RetornaDataReader(strQuery.ToString());
        }
        #endregion

        #region PesquisarInimigo
        public MySqlDataReader PesquisarDadosInimigo(int IdInimigo)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select * from Inimigo where idInimigo = " + IdInimigo);
            return RetornaDataReader(strQuery.ToString());
        }
        #endregion

        #region PesquisarIdPartida
        public MySqlDataReader PesquisarIdPartida(int idPartida)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select * from DadosPartida where idPartida = " + idPartida);
            return RetornaDataReader(strQuery.ToString());
        }
        #endregion

        #region PesquisarClasse
        public MySqlDataReader PesquisarClasse(int idClasse)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select * from Classe where idClasse = " + idClasse);
            return RetornaDataReader(strQuery.ToString());
        }
        #endregion

        #region PesquisarHabilidade
        public MySqlDataReader PesquisarHabilidade(int idHabilidade)
        {
            StringBuilder strQuery = new StringBuilder();
            strQuery.Append("select * from Habilidade where idClasse = " + idHabilidade);
            return RetornaDataReader(strQuery.ToString());
        }
        #endregion
    }
}