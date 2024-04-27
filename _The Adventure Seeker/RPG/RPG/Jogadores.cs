using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RPG
{
    public partial class Jogadores : Form
    {
        #region Variáveis
        Configuracoes c = new Configuracoes();
        Jogador j = new Jogador();
        ClassBanco bd = new ClassBanco();
        StringBuilder strQuery = new StringBuilder();
        ClassColunasBD ccbd = new ClassColunasBD();
        MySqlDataReader objDados;
        string strInclui;
        string strExcluir;

        List<MySqlParameter> colParam = new List<MySqlParameter>();

        MySqlParameter pidJogador = new MySqlParameter("@idJogador", MySqlDbType.Int16);
        MySqlParameter pNomeJogador = new MySqlParameter("@Nome", MySqlDbType.VarChar);
        MySqlParameter pIdInventario = new MySqlParameter("@IdInventario", MySqlDbType.Int16);
        MySqlParameter pIdClasse = new MySqlParameter("@IdClasse", MySqlDbType.Int16);
        MySqlParameter pIdPartida = new MySqlParameter("@IdPartida", MySqlDbType.Int16);
        MySqlParameter pTotalJogadores = new MySqlParameter("@TotalJogadores", MySqlDbType.Int16);

        int JogadoresSelecionados = 0;
        int Click = 0;
        int id1 = 1;
        int id2 = 1;
        int id3 = 1;
        int id4 = 1;
        int id5 = 1;

        string DescArqueiro;
        string DescCavaleiro;
        string DescClérigo;
        string DescMago;
        string DescPaladino;

        Random rnd = new Random();
        #endregion

        #region Inicializar
        public Jogadores()
        {
            InitializeComponent();

            #region IdPartida
            // Gerando um número aleátório entre 0 e 100
            lblIdPartida.Text = rnd.Next(10000).ToString();
            #endregion

            #region Add Font
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile(@"A Goblin Appears!.ttf");
            pfc.AddFontFile(@"Ancient Modern Tales.ttf");

            foreach (Control c in this.Controls)
            {
                btnIniciar.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
                idPersonagem1.Font = new Font(pfc.Families[0], 6, FontStyle.Regular);
                idPersonagem2.Font = new Font(pfc.Families[0], 6, FontStyle.Regular);
                idPersonagem3.Font = new Font(pfc.Families[0], 6, FontStyle.Regular);
                idPersonagem4.Font = new Font(pfc.Families[0], 6, FontStyle.Regular);
                idPersonagem5.Font = new Font(pfc.Families[0], 6, FontStyle.Regular);
                lblStatus1.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
                lblStatus2.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
                lblStatus3.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
                lblStatus4.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
                lblStatus5.Font = new Font(pfc.Families[0], 7, FontStyle.Regular);
            }
            #endregion

            #region Música
            c.MusicaGeral.SoundLocation = "EscolherPersonagem.wav";
            c.MusicaGeral.PlayLooping();
            #endregion

            #region Pesquisar Classes
            Arqueiro();
            Cavaleiro();
            Clérigo();
            Mago();
            Paladino();
            #endregion

            #region Imagens Ativado/Desativado
            OnOff1.ImageLocation = "Ativado.png";
            OnOff2.ImageLocation = "Desativado.png";
            OnOff3.ImageLocation = "Desativado.png";
            OnOff4.ImageLocation = "Desativado.png";
            OnOff5.ImageLocation = "Desativado.png";
            #endregion

            #region Selecionar Jogador
            idPersonagem2.Text = "Selecionar Jogador";
            idPersonagem3.Text = "Selecionar Jogador";
            idPersonagem4.Text = "Selecionar Jogador";
            idPersonagem5.Text = "Selecionar Jogador";
            #endregion
        }
        #endregion

        #region Dados das Classes

        #region Arqueiro
        public void Arqueiro()
        {
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
                DescArqueiro = objDados["NomeClasse"].ToString() + "\n \n" +
                    objDados["DescClasse"].ToString() + "\n \n \n \n \n" +
                    "Vida: " + objDados["Vida"].ToString() + "\n" +
                    "Mana: " + objDados["Mana"].ToString() + "\n" +
                    "Dano: " + objDados["Dano"].ToString() + "\n" +
                    "Defesa: " + objDados["Defesa"].ToString() + "\n" +
                    "Defesa Mágica: " + objDados["DefesaMagica"].ToString() + "\n" +
                    "Agilidade:" + objDados["Agilidade"].ToString();
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
                DescCavaleiro = objDados["NomeClasse"].ToString() + "\n \n" +
                    objDados["DescClasse"].ToString() + "\n \n \n \n \n \n" +
                    "Vida: " + objDados["Vida"].ToString() + "\n" +
                    "Mana: " + objDados["Mana"].ToString() + "\n" +
                    "Dano: " + objDados["Dano"].ToString() + "\n" +
                    "Defesa: " + objDados["Defesa"].ToString() + "\n" +
                    "Defesa Mágica: " + objDados["DefesaMagica"].ToString() + "\n" +
                    "Agilidade:" + objDados["Agilidade"].ToString();
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
                DescClérigo = objDados["NomeClasse"].ToString() + "\n \n" +
                    objDados["DescClasse"].ToString() + "\n \n" +
                    "Vida: " + objDados["Vida"].ToString() + "\n" +
                    "Mana: " + objDados["Mana"].ToString() + "\n" +
                    "Dano: " + objDados["Dano"].ToString() + "\n" +
                    "Defesa: " + objDados["Defesa"].ToString() + "\n" +
                    "Defesa Mágica: " + objDados["DefesaMagica"].ToString() + "\n" +
                    "Agilidade:" + objDados["Agilidade"].ToString();
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
                DescMago = objDados["NomeClasse"].ToString() + "\n \n" +
                    objDados["DescClasse"].ToString() + "\n \n \n \n" +
                    "Vida: " + objDados["Vida"].ToString() + "\n" +
                    "Mana: " + objDados["Mana"].ToString() + "\n" +
                    "Dano: " + objDados["Dano"].ToString() + "\n" +
                    "Defesa: " + objDados["Defesa"].ToString() + "\n" +
                    "Defesa Mágica: " + objDados["DefesaMagica"].ToString() + "\n" +
                    "Agilidade:" + objDados["Agilidade"].ToString();
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
                DescPaladino = objDados["NomeClasse"].ToString() + "\n \n" +
                    objDados["DescClasse"].ToString() + "\n \n \n \n" +
                    "Vida: " + objDados["Vida"].ToString() + "\n" +
                    "Mana: " + objDados["Mana"].ToString() + "\n" +
                    "Dano: " + objDados["Dano"].ToString() + "\n" +
                    "Defesa: " + objDados["Defesa"].ToString() + "\n" +
                    "Defesa Mágica: " + objDados["DefesaMagica"].ToString() + "\n" +
                    "Agilidade:" + objDados["Agilidade"].ToString();
            }

            if (!objDados.IsClosed)
            {
                objDados.Close();
                strQuery.Remove(0, strQuery.Length);
            }
        }
        #endregion

        #endregion

        #region Botão Iniciar
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            #region Verificar se nenhum jogador foi selecionado
            if (OnOff1.ImageLocation == "Desativado.png" && OnOff2.ImageLocation == "Desativado.png" && OnOff3.ImageLocation == "Desativado.png" &&
                OnOff4.ImageLocation == "Desativado.png" && OnOff5.ImageLocation == "Desativado.png")
            {
                MessageBox.Show("Por favor, selecione pelo menos um jogador!!!",
                    "*** NENHUM PLAYER SELECIONADO ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Click = 0;
            }
            else
            {
                Click = 1;
            }
            #endregion

            #region Caso algum jogador for selecionado
            switch (Click)
            {
                case 0:
                    break;

                case 1:

                    #region Verificar IdPartida
                    ccbd.IdPartida = int.Parse(lblIdPartida.Text);
                    ccbd.TotalJogadores = JogadoresSelecionados;

                    objDados = bd.PesquisarIdPartida(ccbd.IdPartida);

                    if (objDados.HasRows)
                    {
                        strExcluir = "Delete from DadosPartida where idPartida = " + ccbd.IdPartida;

                        bd.ExecutaComando(strExcluir);
                    }

                    if (!objDados.IsClosed)
                    {
                        objDados.Close();
                    }

                    strInclui = "insert into DadosPartida(idPartida,TotalJogadores)" +
                        "values(@IdPartida, @TotalJogadores)";

                    pIdPartida.Value = ccbd.IdPartida;
                    pTotalJogadores.Value = ccbd.TotalJogadores;

                    colParam.Add(pIdPartida);
                    colParam.Add(pTotalJogadores);

                    bd.ExecutaComandoParam(strInclui, colParam);
                    #endregion

                    #region Enviar os dados dos jogadores selecionados
                    switch (OnOff1.ImageLocation)
                    {
                        case "Ativado.png":

                            #region Jogador 1
                            JogadoresSelecionados = 1;
                            ccbd.IdJogador = 1;
                            ccbd.NomeJogador = tbJogador1.Text;
                            ccbd.IdInventario = 1;
                            ccbd.IdPartida = int.Parse(lblIdPartida.Text);

                            objDados = bd.PesquisarJogador(ccbd.IdJogador);

                            if (objDados.HasRows)
                            {
                                strExcluir = "Delete from Jogador where idJogador = " + ccbd.IdJogador;

                                bd.ExecutaComando(strExcluir);
                            }

                            if (!objDados.IsClosed)
                            {
                                objDados.Close();
                            }

                            strInclui = "insert into Jogador(idJogador,NomeJogador,idInventario,idClasse,idPartida)" +
                                "values(@idJogador, @Nome, @IdInventario, @IdClasse, @IdPartida)";

                            pidJogador.Value = ccbd.IdJogador;
                            pNomeJogador.Value = ccbd.NomeJogador;
                            pIdInventario.Value = ccbd.IdInventario;
                            pIdClasse.Value = id1;
                            pIdPartida.Value = ccbd.IdPartida;

                            colParam.Add(pidJogador);
                            colParam.Add(pNomeJogador);
                            colParam.Add(pIdInventario);
                            colParam.Add(pIdClasse);

                            bd.ExecutaComandoParam(strInclui, colParam);

                            MessageBox.Show("Jogador cadastrado com Sucesso!!!",
                                "*** JOGADOR CADASTRADO ***",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            #endregion

                            switch (OnOff2.ImageLocation)
                            {
                                case "Ativado.png":

                                    #region Jogador 2
                                    JogadoresSelecionados = 2;
                                    ccbd.IdJogador = 2;
                                    ccbd.NomeJogador = tbJogador2.Text;
                                    ccbd.IdInventario = 2;
                                    ccbd.IdPartida = int.Parse(lblIdPartida.Text);

                                    objDados = bd.PesquisarJogador(ccbd.IdJogador);

                                    if (objDados.HasRows)
                                    {
                                        strExcluir = "Delete from Jogador where idJogador = " + ccbd.IdJogador;

                                        bd.ExecutaComando(strExcluir);
                                    }

                                    if (!objDados.IsClosed)
                                    {
                                        objDados.Close();
                                    }

                                    strInclui = "insert into Jogador(idJogador,NomeJogador,idInventario,idClasse,idPartida)" +
                                        "values(@idJogador, @Nome, @IdInventario, @IdClasse, @IdPartida)";

                                    pidJogador.Value = ccbd.IdJogador;
                                    pNomeJogador.Value = ccbd.NomeJogador;
                                    pIdInventario.Value = ccbd.IdInventario;
                                    pIdClasse.Value = id2;
                                    pIdPartida.Value = ccbd.IdPartida;

                                    bd.ExecutaComandoParam(strInclui, colParam);

                                    MessageBox.Show("Jogador cadastrado com Sucesso!!!",
                                        "*** JOGADOR CADASTRADO ***",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    #endregion

                                    switch (OnOff3.ImageLocation)
                                    {
                                        case "Ativado.png":

                                            #region Jogador 3
                                            JogadoresSelecionados = 3;
                                            ccbd.IdJogador = 3;
                                            ccbd.NomeJogador = tbJogador3.Text;
                                            ccbd.IdInventario = 3;
                                            ccbd.IdPartida = int.Parse(lblIdPartida.Text);

                                            objDados = bd.PesquisarJogador(ccbd.IdJogador);

                                            if (objDados.HasRows)
                                            {
                                                strExcluir = "Delete from Jogador where idJogador = " + ccbd.IdJogador;

                                                bd.ExecutaComando(strExcluir);
                                            }

                                            if (!objDados.IsClosed)
                                            {
                                                objDados.Close();
                                            }

                                            strInclui = "insert into Jogador(idJogador,NomeJogador,idInventario,idClasse,idPartida)" +
                                                "values(@idJogador, @Nome, @IdInventario, @IdClasse, @IdPartida)";

                                            pidJogador.Value = ccbd.IdJogador;
                                            pNomeJogador.Value = ccbd.NomeJogador;
                                            pIdInventario.Value = ccbd.IdInventario;
                                            pIdClasse.Value = id3;
                                            pIdPartida.Value = ccbd.IdPartida;

                                            bd.ExecutaComandoParam(strInclui, colParam);

                                            MessageBox.Show("Jogador cadastrado com Sucesso!!!",
                                                "*** JOGADOR CADASTRADO ***",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                            #endregion

                                            switch (OnOff4.ImageLocation)
                                            {
                                                case "Ativado.png":

                                                    #region Jogador 4
                                                    JogadoresSelecionados = 4;
                                                    ccbd.IdJogador = 4;
                                                    ccbd.NomeJogador = tbJogador4.Text;
                                                    ccbd.IdInventario = 4;
                                                    ccbd.IdPartida = int.Parse(lblIdPartida.Text);

                                                    objDados = bd.PesquisarJogador(ccbd.IdJogador);

                                                    if (objDados.HasRows)
                                                    {
                                                        strExcluir = "Delete from Jogador where idJogador = " + ccbd.IdJogador;

                                                        bd.ExecutaComando(strExcluir);
                                                    }

                                                    if (!objDados.IsClosed)
                                                    {
                                                        objDados.Close();
                                                    }

                                                    strInclui = "insert into Jogador(idJogador,NomeJogador,idInventario,idClasse,idPartida)" +
                                                        "values(@idJogador, @Nome, @IdInventario, @IdClasse, @IdPartida)";

                                                    pidJogador.Value = ccbd.IdJogador;
                                                    pNomeJogador.Value = ccbd.NomeJogador;
                                                    pIdInventario.Value = ccbd.IdInventario;
                                                    pIdClasse.Value = id4;
                                                    pIdPartida.Value = ccbd.IdPartida;

                                                    bd.ExecutaComandoParam(strInclui, colParam);

                                                    MessageBox.Show("Jogador cadastrado com Sucesso!!!",
                                                        "*** JOGADOR CADASTRADO ***",
                                                        MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information);
                                                    #endregion

                                                    switch (OnOff5.ImageLocation)
                                                    {
                                                        case "Ativado.png":

                                                            #region Jogador 5
                                                            JogadoresSelecionados = 5;
                                                            ccbd.IdJogador = 5;
                                                            ccbd.NomeJogador = tbJogador5.Text;
                                                            ccbd.IdInventario = 5;
                                                            ccbd.IdPartida = int.Parse(lblIdPartida.Text);

                                                            objDados = bd.PesquisarJogador(ccbd.IdJogador);

                                                            if (objDados.HasRows)
                                                            {
                                                                strExcluir = "Delete from Jogador where idJogador = " + ccbd.IdJogador;

                                                                bd.ExecutaComando(strExcluir);
                                                            }

                                                            if (!objDados.IsClosed)
                                                            {
                                                                objDados.Close();
                                                            }

                                                            strInclui = "insert into Jogador(idJogador,NomeJogador,idInventario,idClasse,idPartida)" +
                                                                "values(@idJogador, @Nome, @IdInventario, @IdClasse, @IdPartida)";

                                                            pidJogador.Value = ccbd.IdJogador;
                                                            pNomeJogador.Value = ccbd.NomeJogador;
                                                            pIdInventario.Value = ccbd.IdInventario;
                                                            pIdClasse.Value = id5;
                                                            pIdPartida.Value = ccbd.IdPartida;

                                                            bd.ExecutaComandoParam(strInclui, colParam);

                                                            MessageBox.Show("Jogador cadastrado com Sucesso!!!",
                                                                "*** JOGADOR CADASTRADO ***",
                                                                MessageBoxButtons.OK,
                                                                MessageBoxIcon.Information);
                                                            #endregion
                                                            break;

                                                        case "Desativado.png":
                                                            break;
                                                    }
                                                    break;

                                                case "Desativado.png":
                                                    break;
                                            }
                                            break;

                                        case "Desativado.png":
                                            break;
                                    }
                                    break;

                                case "Desativado.png":
                                    break;
                            }
                            break;
                    }
                    #endregion

                    #region Alterar os dados da Partida
                    ccbd.IdPartida = int.Parse(lblIdPartida.Text);
                    ccbd.TotalJogadores = JogadoresSelecionados;

                    objDados = bd.PesquisarIdPartida(ccbd.IdPartida);

                    if (!objDados.IsClosed)
                    {
                        objDados.Close();
                    }

                    strInclui = "update DadosPartida set TotalJogadores = @TotalJogadores where idPartida = @IdPartida";

                    pIdPartida.Value = ccbd.IdPartida;
                    pTotalJogadores.Value = ccbd.TotalJogadores;

                    bd.ExecutaComandoParam(strInclui, colParam);
                    #endregion

                    this.Hide();
                    RPG r = new RPG();
                    r.Closed += (s, args) => this.Close();
                    r.Show();
                    break;
            }
            #endregion
        }
        #endregion

        #region Botões Mudar Personagens

        #region Botões Direitos

        // Arqueiro
        // Cavaleiro
        // Clérigo
        // Mago
        // Paladino

        #region Botão Direito 1
        private void btnDireita1_Click(object sender, EventArgs e)
        {
            switch (idPersonagem1.Text)
            {
                #region case "Arqueiro":
                case "Arqueiro":
                    if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                        || idPersonagem5.Text == "Cavaleiro")
                    {
                        if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                            || idPersonagem5.Text == "Clérigo")
                        {
                            if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                || idPersonagem5.Text == "Mago")
                            {
                                if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 5;
                                    idPersonagem1.Text = "Paladino";
                                    pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus1.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 4;
                                idPersonagem1.Text = "Mago";
                                pbJogador1.ImageLocation = "Mago_Arrumado.png";
                                lblStatus1.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 3;
                            idPersonagem1.Text = "Clérigo";
                            pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus1.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 2;
                        idPersonagem1.Text = "Cavaleiro";
                        pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus1.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":
                    if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                            || idPersonagem5.Text == "Clérigo")
                    {
                        if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                || idPersonagem5.Text == "Mago")
                        {
                            if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                            {
                                if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 1;
                                    idPersonagem1.Text = "Arqueiro";
                                    pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus1.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 5;
                                idPersonagem1.Text = "Paladino";
                                pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus1.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 4;
                            idPersonagem1.Text = "Mago";
                            pbJogador1.ImageLocation = "Mago_Arrumado.png";
                            lblStatus1.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 3;
                        idPersonagem1.Text = "Clérigo";
                        pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus1.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                || idPersonagem5.Text == "Mago")
                    {
                        if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                        {
                            if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                            {
                                if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                    || idPersonagem5.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 2;
                                    idPersonagem1.Text = "Cavaleiro";
                                    pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus1.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 1;
                                idPersonagem1.Text = "Arqueiro";
                                pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus1.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 5;
                            idPersonagem1.Text = "Paladino";
                            pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus1.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 4;
                        idPersonagem1.Text = "Mago";
                        pbJogador1.ImageLocation = "Mago_Arrumado.png";
                        lblStatus1.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                    {
                        if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                        {
                            if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                    || idPersonagem5.Text == "Cavaleiro")
                            {
                                if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                    || idPersonagem5.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 3;
                                    idPersonagem1.Text = "Clérigo";
                                    pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus1.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 2;
                                idPersonagem1.Text = "Cavaleiro";
                                pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus1.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 1;
                            idPersonagem1.Text = "Arqueiro";
                            pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus1.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 5;
                        idPersonagem1.Text = "Paladino";
                        pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus1.Text = DescPaladino;
                        break;
                    }
                #endregion

                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                    {
                        if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                    || idPersonagem5.Text == "Cavaleiro")
                        {
                            if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                    || idPersonagem5.Text == "Clérigo")
                            {
                                if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                    || idPersonagem5.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 4;
                                    idPersonagem1.Text = "Mago";
                                    pbJogador1.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus1.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 3;
                                idPersonagem1.Text = "Clérigo";
                                pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus1.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 2;
                            idPersonagem1.Text = "Cavaleiro";
                            pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus1.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 1;
                        idPersonagem1.Text = "Arqueiro";
                        pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus1.Text = DescArqueiro;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Direito 2
        private void btnDireita2_Click(object sender, EventArgs e)
        {
            switch (idPersonagem2.Text)
            {
                #region case "Arqueiro":
                case "Arqueiro":
                    if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                        || idPersonagem1.Text == "Cavaleiro")
                    {
                        if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                            || idPersonagem1.Text == "Clérigo")
                        {
                            if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                || idPersonagem1.Text == "Mago")
                            {
                                if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 5;
                                    idPersonagem2.Text = "Paladino";
                                    pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus2.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 4;
                                idPersonagem2.Text = "Mago";
                                pbJogador2.ImageLocation = "Mago_Arrumado.png";
                                lblStatus2.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 3;
                            idPersonagem2.Text = "Clérigo";
                            pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus2.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 2;
                        idPersonagem2.Text = "Cavaleiro";
                        pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus2.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":
                    if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                            || idPersonagem1.Text == "Clérigo")
                    {
                        if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                || idPersonagem1.Text == "Mago")
                        {
                            if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                            {
                                if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 1;
                                    idPersonagem2.Text = "Arqueiro";
                                    pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus2.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 5;
                                idPersonagem2.Text = "Paladino";
                                pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus2.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 4;
                            idPersonagem2.Text = "Mago";
                            pbJogador2.ImageLocation = "Mago_Arrumado.png";
                            lblStatus2.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 3;
                        idPersonagem2.Text = "Clérigo";
                        pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus2.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                || idPersonagem1.Text == "Mago")
                    {
                        if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                        {
                            if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                            {
                                if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                    || idPersonagem1.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 2;
                                    idPersonagem2.Text = "Cavaleiro";
                                    pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus2.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 1;
                                idPersonagem2.Text = "Arqueiro";
                                pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus2.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 5;
                            idPersonagem2.Text = "Paladino";
                            pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus2.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 4;
                        idPersonagem2.Text = "Mago";
                        pbJogador2.ImageLocation = "Mago_Arrumado.png";
                        lblStatus2.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                    {
                        if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                        {
                            if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                    || idPersonagem1.Text == "Cavaleiro")
                            {
                                if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                    || idPersonagem1.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 3;
                                    idPersonagem2.Text = "Clérigo";
                                    pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus2.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 2;
                                idPersonagem2.Text = "Cavaleiro";
                                pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus2.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 1;
                            idPersonagem2.Text = "Arqueiro";
                            pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus2.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 5;
                        idPersonagem2.Text = "Paladino";
                        pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus2.Text = DescPaladino;
                        break;
                    }
                #endregion

                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                    {
                        if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                    || idPersonagem1.Text == "Cavaleiro")
                        {
                            if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                    || idPersonagem1.Text == "Clérigo")
                            {
                                if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                    || idPersonagem1.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 4;
                                    idPersonagem2.Text = "Mago";
                                    pbJogador2.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus2.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 3;
                                idPersonagem2.Text = "Clérigo";
                                pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus2.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 2;
                            idPersonagem2.Text = "Cavaleiro";
                            pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus2.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 1;
                        idPersonagem2.Text = "Arqueiro";
                        pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus2.Text = DescArqueiro;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Direito 3
        private void btnDireita3_Click(object sender, EventArgs e)
        {
            switch (idPersonagem3.Text)
            {
                #region case "Arqueiro":
                case "Arqueiro":
                    if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                        || idPersonagem2.Text == "Cavaleiro")
                    {
                        if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                            || idPersonagem2.Text == "Clérigo")
                        {
                            if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                || idPersonagem2.Text == "Mago")
                            {
                                if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 5;
                                    idPersonagem3.Text = "Paladino";
                                    pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus3.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 4;
                                idPersonagem3.Text = "Mago";
                                pbJogador3.ImageLocation = "Mago_Arrumado.png";
                                lblStatus3.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 3;
                            idPersonagem3.Text = "Clérigo";
                            pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus3.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 2;
                        idPersonagem3.Text = "Cavaleiro";
                        pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus3.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":
                    if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                            || idPersonagem2.Text == "Clérigo")
                    {
                        if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                || idPersonagem2.Text == "Mago")
                        {
                            if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                            {
                                if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 1;
                                    idPersonagem3.Text = "Arqueiro";
                                    pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus3.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 5;
                                idPersonagem3.Text = "Paladino";
                                pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus3.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 4;
                            idPersonagem3.Text = "Mago";
                            pbJogador3.ImageLocation = "Mago_Arrumado.png";
                            lblStatus3.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 3;
                        idPersonagem3.Text = "Clérigo";
                        pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus3.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                || idPersonagem2.Text == "Mago")
                    {
                        if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                        {
                            if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                            {
                                if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                    || idPersonagem2.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 2;
                                    idPersonagem3.Text = "Cavaleiro";
                                    pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus3.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 1;
                                idPersonagem3.Text = "Arqueiro";
                                pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus3.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 5;
                            idPersonagem3.Text = "Paladino";
                            pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus3.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 4;
                        idPersonagem3.Text = "Mago";
                        pbJogador3.ImageLocation = "Mago_Arrumado.png";
                        lblStatus3.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                    {
                        if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                        {
                            if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                    || idPersonagem2.Text == "Cavaleiro")
                            {
                                if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                    || idPersonagem2.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 3;
                                    idPersonagem3.Text = "Clérigo";
                                    pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus3.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 2;
                                idPersonagem3.Text = "Cavaleiro";
                                pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus3.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 1;
                            idPersonagem3.Text = "Arqueiro";
                            pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus3.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 5;
                        idPersonagem3.Text = "Paladino";
                        pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus3.Text = DescPaladino;
                        break;
                    }
                #endregion

                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                    {
                        if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                    || idPersonagem2.Text == "Cavaleiro")
                        {
                            if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                    || idPersonagem2.Text == "Clérigo")
                            {
                                if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                    || idPersonagem2.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 4;
                                    idPersonagem3.Text = "Mago";
                                    pbJogador3.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus3.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 3;
                                idPersonagem3.Text = "Clérigo";
                                pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus3.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 2;
                            idPersonagem3.Text = "Cavaleiro";
                            pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus3.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 1;
                        idPersonagem3.Text = "Arqueiro";
                        pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus3.Text = DescArqueiro;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Direito 4
        private void btnDireita4_Click(object sender, EventArgs e)
        {
            switch (idPersonagem4.Text)
            {
                #region case "Arqueiro":
                case "Arqueiro":
                    if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                        || idPersonagem3.Text == "Cavaleiro")
                    {
                        if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                            || idPersonagem3.Text == "Clérigo")
                        {
                            if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                || idPersonagem3.Text == "Mago")
                            {
                                if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 5;
                                    idPersonagem4.Text = "Paladino";
                                    pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus4.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 4;
                                idPersonagem4.Text = "Mago";
                                pbJogador4.ImageLocation = "Mago_Arrumado.png";
                                lblStatus4.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 3;
                            idPersonagem4.Text = "Clérigo";
                            pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus4.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 2;
                        idPersonagem4.Text = "Cavaleiro";
                        pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus4.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":
                    if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                            || idPersonagem3.Text == "Clérigo")
                    {
                        if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                || idPersonagem3.Text == "Mago")
                        {
                            if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                            {
                                if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 1;
                                    idPersonagem4.Text = "Arqueiro";
                                    pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus4.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 5;
                                idPersonagem4.Text = "Paladino";
                                pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus4.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 4;
                            idPersonagem4.Text = "Mago";
                            pbJogador4.ImageLocation = "Mago_Arrumado.png";
                            lblStatus4.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 3;
                        idPersonagem4.Text = "Clérigo";
                        pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus4.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                || idPersonagem3.Text == "Mago")
                    {
                        if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                        {
                            if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                            {
                                if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                    || idPersonagem3.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 2;
                                    idPersonagem4.Text = "Cavaleiro";
                                    pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus4.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 1;
                                idPersonagem4.Text = "Arqueiro";
                                pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus4.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 5;
                            idPersonagem4.Text = "Paladino";
                            pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus4.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 4;
                        idPersonagem4.Text = "Mago";
                        pbJogador4.ImageLocation = "Mago_Arrumado.png";
                        lblStatus4.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                    {
                        if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                        {
                            if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                    || idPersonagem3.Text == "Cavaleiro")
                            {
                                if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                    || idPersonagem3.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 3;
                                    idPersonagem4.Text = "Clérigo";
                                    pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus4.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 2;
                                idPersonagem4.Text = "Cavaleiro";
                                pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus4.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 1;
                            idPersonagem4.Text = "Arqueiro";
                            pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus4.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 5;
                        idPersonagem4.Text = "Paladino";
                        pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus4.Text = DescPaladino;
                        break;
                    }
                #endregion

                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                    {
                        if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                    || idPersonagem3.Text == "Cavaleiro")
                        {
                            if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                    || idPersonagem3.Text == "Clérigo")
                            {
                                if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                    || idPersonagem3.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 4;
                                    idPersonagem4.Text = "Mago";
                                    pbJogador4.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus4.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 3;
                                idPersonagem4.Text = "Clérigo";
                                pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus4.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 2;
                            idPersonagem4.Text = "Cavaleiro";
                            pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus4.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 1;
                        idPersonagem4.Text = "Arqueiro";
                        pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus4.Text = DescArqueiro;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Direito 5
        private void btnDireita5_Click(object sender, EventArgs e)
        {
            switch (idPersonagem5.Text)
            {
                #region case "Arqueiro":
                case "Arqueiro":
                    if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                        || idPersonagem4.Text == "Cavaleiro")
                    {
                        if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                            || idPersonagem4.Text == "Clérigo")
                        {
                            if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                || idPersonagem4.Text == "Mago")
                            {
                                if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 5;
                                    idPersonagem5.Text = "Paladino";
                                    pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus5.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 4;
                                idPersonagem5.Text = "Mago";
                                pbJogador5.ImageLocation = "Mago_Arrumado.png";
                                lblStatus5.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 3;
                            idPersonagem5.Text = "Clérigo";
                            pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus5.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 2;
                        idPersonagem5.Text = "Cavaleiro";
                        pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus5.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":
                    if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                            || idPersonagem4.Text == "Clérigo")
                    {
                        if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                || idPersonagem4.Text == "Mago")
                        {
                            if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                            {
                                if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 1;
                                    idPersonagem5.Text = "Arqueiro";
                                    pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus5.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 5;
                                idPersonagem5.Text = "Paladino";
                                pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus5.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 4;
                            idPersonagem5.Text = "Mago";
                            pbJogador5.ImageLocation = "Mago_Arrumado.png";
                            lblStatus5.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 3;
                        idPersonagem5.Text = "Clérigo";
                        pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus5.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                || idPersonagem4.Text == "Mago")
                    {
                        if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                        {
                            if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                            {
                                if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                    || idPersonagem4.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 2;
                                    idPersonagem5.Text = "Cavaleiro";
                                    pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus5.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 1;
                                idPersonagem5.Text = "Arqueiro";
                                pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus5.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 5;
                            idPersonagem5.Text = "Paladino";
                            pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus5.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 4;
                        idPersonagem5.Text = "Mago";
                        pbJogador5.ImageLocation = "Mago_Arrumado.png";
                        lblStatus5.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                    {
                        if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                        {
                            if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                    || idPersonagem4.Text == "Cavaleiro")
                            {
                                if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                    || idPersonagem4.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 3;
                                    idPersonagem5.Text = "Clérigo";
                                    pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus5.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 2;
                                idPersonagem5.Text = "Cavaleiro";
                                pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus5.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 1;
                            idPersonagem5.Text = "Arqueiro";
                            pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus5.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 5;
                        idPersonagem5.Text = "Paladino";
                        pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus5.Text = DescPaladino;
                        break;
                    }
                #endregion

                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                    {
                        if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                    || idPersonagem4.Text == "Cavaleiro")
                        {
                            if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                    || idPersonagem4.Text == "Clérigo")
                            {
                                if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                    || idPersonagem4.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 4;
                                    idPersonagem5.Text = "Mago";
                                    pbJogador5.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus5.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 3;
                                idPersonagem5.Text = "Clérigo";
                                pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus5.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 2;
                            idPersonagem5.Text = "Cavaleiro";
                            pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus5.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 1;
                        idPersonagem5.Text = "Arqueiro";
                        pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus5.Text = DescArqueiro;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #endregion

        #region Botões Esquerdos

        // Paladino
        // Mago
        // Clérigo
        // Cavaleiro
        // Arqueiro

        #region Botão Esquerdo 1
        private void btnEsquerda1_Click(object sender, EventArgs e)
        {
            switch (idPersonagem1.Text)
            {
                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                || idPersonagem5.Text == "Mago")
                    {
                        if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                || idPersonagem5.Text == "Clérigo")
                        {
                            if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                || idPersonagem5.Text == "Cavaleiro")
                            {
                                if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 1;
                                    idPersonagem1.Text = "Arqueiro";
                                    pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus1.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 2;
                                idPersonagem1.Text = "Cavaleiro";
                                pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus1.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 3;
                            idPersonagem1.Text = "Clérigo";
                            pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus1.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 4;
                        idPersonagem1.Text = "Mago";
                        pbJogador1.ImageLocation = "Mago_Arrumado.png";
                        lblStatus1.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                || idPersonagem5.Text == "Clérigo")
                    {
                        if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                || idPersonagem5.Text == "Cavaleiro")
                        {
                            if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                            {
                                if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 5;
                                    idPersonagem1.Text = "Paladino";
                                    pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus1.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 1;
                                idPersonagem1.Text = "Arqueiro";
                                pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus1.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 2;
                            idPersonagem1.Text = "Cavaleiro";
                            pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus1.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 3;
                        idPersonagem1.Text = "Clérigo";
                        pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus1.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                || idPersonagem5.Text == "Cavaleiro")
                    {
                        if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                        {
                            if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                            {
                                if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                    || idPersonagem5.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 4;
                                    idPersonagem1.Text = "Mago";
                                    pbJogador1.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus1.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 5;
                                idPersonagem1.Text = "Paladino";
                                pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus1.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 1;
                            idPersonagem1.Text = "Arqueiro";
                            pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus1.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 2;
                        idPersonagem1.Text = "Cavaleiro";
                        pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus1.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":

                    if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                    || idPersonagem5.Text == "Arqueiro")
                    {
                        if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                        {
                            if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                    || idPersonagem5.Text == "Mago")
                            {
                                if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                || idPersonagem5.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 3;
                                    idPersonagem1.Text = "Clérigo";
                                    pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus1.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 4;
                                idPersonagem1.Text = "Mago";
                                pbJogador1.ImageLocation = "Mago_Arrumado.png";
                                lblStatus1.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 5;
                            idPersonagem1.Text = "Paladino";
                            pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus1.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 1;
                        idPersonagem1.Text = "Arqueiro";
                        pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus1.Text = DescArqueiro;
                        break;
                    }
                #endregion

                #region case "Arqueiro":
                case "Arqueiro":

                    if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                    || idPersonagem5.Text == "Paladino")
                    {
                        if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                    || idPersonagem5.Text == "Mago")
                        {
                            if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                || idPersonagem5.Text == "Clérigo")
                            {
                                if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                || idPersonagem5.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id1 = 2;
                                    idPersonagem1.Text = "Cavaleiro";
                                    pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus1.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 3;
                                idPersonagem1.Text = "Clérigo";
                                pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus1.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id1 = 4;
                            idPersonagem1.Text = "Mago";
                            pbJogador1.ImageLocation = "Mago_Arrumado.png";
                            lblStatus1.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id1 = 5;
                        idPersonagem1.Text = "Paladino";
                        pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus1.Text = DescPaladino;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Esquerdo 2
        private void btnEsquerda2_Click(object sender, EventArgs e)
        {
            switch (idPersonagem2.Text)
            {
                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                || idPersonagem1.Text == "Mago")
                    {
                        if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                || idPersonagem1.Text == "Clérigo")
                        {
                            if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                || idPersonagem1.Text == "Cavaleiro")
                            {
                                if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 1;
                                    idPersonagem2.Text = "Arqueiro";
                                    pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus2.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 2;
                                idPersonagem2.Text = "Cavaleiro";
                                pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus2.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 3;
                            idPersonagem2.Text = "Clérigo";
                            pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus2.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 4;
                        idPersonagem2.Text = "Mago";
                        pbJogador2.ImageLocation = "Mago_Arrumado.png";
                        lblStatus2.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                || idPersonagem1.Text == "Clérigo")
                    {
                        if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                || idPersonagem1.Text == "Cavaleiro")
                        {
                            if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                            {
                                if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 5;
                                    idPersonagem2.Text = "Paladino";
                                    pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus2.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 1;
                                idPersonagem2.Text = "Arqueiro";
                                pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus2.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 2;
                            idPersonagem2.Text = "Cavaleiro";
                            pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus2.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 3;
                        idPersonagem2.Text = "Clérigo";
                        pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus2.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                || idPersonagem1.Text == "Cavaleiro")
                    {
                        if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                        {
                            if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                            {
                                if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                    || idPersonagem1.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 4;
                                    idPersonagem2.Text = "Mago";
                                    pbJogador2.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus2.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 5;
                                idPersonagem2.Text = "Paladino";
                                pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus2.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 1;
                            idPersonagem2.Text = "Arqueiro";
                            pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus2.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 2;
                        idPersonagem2.Text = "Cavaleiro";
                        pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus2.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":

                    if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                    || idPersonagem1.Text == "Arqueiro")
                    {
                        if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                        {
                            if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                    || idPersonagem1.Text == "Mago")
                            {
                                if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                || idPersonagem1.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 3;
                                    idPersonagem2.Text = "Clérigo";
                                    pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus2.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 4;
                                idPersonagem2.Text = "Mago";
                                pbJogador2.ImageLocation = "Mago_Arrumado.png";
                                lblStatus2.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 5;
                            idPersonagem2.Text = "Paladino";
                            pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus2.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 1;
                        idPersonagem2.Text = "Arqueiro";
                        pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus2.Text = DescArqueiro;
                        break;
                    }
                #endregion

                #region case "Arqueiro":
                case "Arqueiro":

                    if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                    || idPersonagem1.Text == "Paladino")
                    {
                        if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                    || idPersonagem1.Text == "Mago")
                        {
                            if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                || idPersonagem1.Text == "Clérigo")
                            {
                                if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                || idPersonagem1.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id2 = 2;
                                    idPersonagem2.Text = "Cavaleiro";
                                    pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus2.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id2 = 3;
                                idPersonagem2.Text = "Clérigo";
                                pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus2.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id2 = 4;
                            idPersonagem2.Text = "Mago";
                            pbJogador2.ImageLocation = "Mago_Arrumado.png";
                            lblStatus2.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id2 = 5;
                        idPersonagem2.Text = "Paladino";
                        pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus2.Text = DescPaladino;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Esquerdo 3
        private void btnEsquerda3_Click(object sender, EventArgs e)
        {
            switch (idPersonagem3.Text)
            {
                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                || idPersonagem2.Text == "Mago")
                    {
                        if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                || idPersonagem2.Text == "Clérigo")
                        {
                            if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                || idPersonagem2.Text == "Cavaleiro")
                            {
                                if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 1;
                                    idPersonagem3.Text = "Arqueiro";
                                    pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus3.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 2;
                                idPersonagem3.Text = "Cavaleiro";
                                pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus3.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 3;
                            idPersonagem3.Text = "Clérigo";
                            pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus3.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 4;
                        idPersonagem3.Text = "Mago";
                        pbJogador3.ImageLocation = "Mago_Arrumado.png";
                        lblStatus3.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                || idPersonagem2.Text == "Clérigo")
                    {
                        if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                || idPersonagem2.Text == "Cavaleiro")
                        {
                            if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                            {
                                if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 5;
                                    idPersonagem3.Text = "Paladino";
                                    pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus3.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 1;
                                idPersonagem3.Text = "Arqueiro";
                                pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus3.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 2;
                            idPersonagem3.Text = "Cavaleiro";
                            pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus3.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 3;
                        idPersonagem3.Text = "Clérigo";
                        pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus3.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                || idPersonagem2.Text == "Cavaleiro")
                    {
                        if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                        {
                            if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                            {
                                if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                    || idPersonagem2.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 4;
                                    idPersonagem3.Text = "Mago";
                                    pbJogador3.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus3.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 5;
                                idPersonagem3.Text = "Paladino";
                                pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus3.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 1;
                            idPersonagem3.Text = "Arqueiro";
                            pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus3.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 2;
                        idPersonagem3.Text = "Cavaleiro";
                        pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus3.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":

                    if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                    || idPersonagem2.Text == "Arqueiro")
                    {
                        if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                        {
                            if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                    || idPersonagem2.Text == "Mago")
                            {
                                if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                || idPersonagem2.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 3;
                                    idPersonagem3.Text = "Clérigo";
                                    pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus3.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 4;
                                idPersonagem3.Text = "Mago";
                                pbJogador3.ImageLocation = "Mago_Arrumado.png";
                                lblStatus3.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 5;
                            idPersonagem3.Text = "Paladino";
                            pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus3.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 1;
                        idPersonagem3.Text = "Arqueiro";
                        pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus3.Text = DescArqueiro;
                        break;
                    }
                #endregion

                #region case "Arqueiro":
                case "Arqueiro":

                    if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                    || idPersonagem2.Text == "Paladino")
                    {
                        if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                    || idPersonagem2.Text == "Mago")
                        {
                            if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                || idPersonagem2.Text == "Clérigo")
                            {
                                if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                || idPersonagem2.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id3 = 2;
                                    idPersonagem3.Text = "Cavaleiro";
                                    pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus3.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id3 = 3;
                                idPersonagem3.Text = "Clérigo";
                                pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus3.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id3 = 4;
                            idPersonagem3.Text = "Mago";
                            pbJogador3.ImageLocation = "Mago_Arrumado.png";
                            lblStatus3.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id3 = 5;
                        idPersonagem3.Text = "Paladino";
                        pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus3.Text = DescPaladino;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Esquerdo 4
        private void btnEsquerda4_Click(object sender, EventArgs e)
        {
            switch (idPersonagem4.Text)
            {
                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                || idPersonagem3.Text == "Mago")
                    {
                        if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                || idPersonagem3.Text == "Clérigo")
                        {
                            if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                || idPersonagem3.Text == "Cavaleiro")
                            {
                                if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 1;
                                    idPersonagem4.Text = "Arqueiro";
                                    pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus4.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 2;
                                idPersonagem4.Text = "Cavaleiro";
                                pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus4.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 3;
                            idPersonagem4.Text = "Clérigo";
                            pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus4.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 4;
                        idPersonagem4.Text = "Mago";
                        pbJogador4.ImageLocation = "Mago_Arrumado.png";
                        lblStatus4.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                || idPersonagem3.Text == "Clérigo")
                    {
                        if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                || idPersonagem3.Text == "Cavaleiro")
                        {
                            if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                            {
                                if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 5;
                                    idPersonagem4.Text = "Paladino";
                                    pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus4.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 1;
                                idPersonagem4.Text = "Arqueiro";
                                pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus4.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 2;
                            idPersonagem4.Text = "Cavaleiro";
                            pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus4.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 3;
                        idPersonagem4.Text = "Clérigo";
                        pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus4.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                || idPersonagem3.Text == "Cavaleiro")
                    {
                        if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                        {
                            if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                            {
                                if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                    || idPersonagem3.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 4;
                                    idPersonagem4.Text = "Mago";
                                    pbJogador4.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus4.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 5;
                                idPersonagem4.Text = "Paladino";
                                pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus4.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 1;
                            idPersonagem4.Text = "Arqueiro";
                            pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus4.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 2;
                        idPersonagem4.Text = "Cavaleiro";
                        pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus4.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":

                    if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                    || idPersonagem3.Text == "Arqueiro")
                    {
                        if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                        {
                            if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                    || idPersonagem3.Text == "Mago")
                            {
                                if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                || idPersonagem3.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 3;
                                    idPersonagem4.Text = "Clérigo";
                                    pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus4.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 4;
                                idPersonagem4.Text = "Mago";
                                pbJogador4.ImageLocation = "Mago_Arrumado.png";
                                lblStatus4.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 5;
                            idPersonagem4.Text = "Paladino";
                            pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus4.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 1;
                        idPersonagem4.Text = "Arqueiro";
                        pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus4.Text = DescArqueiro;
                        break;
                    }
                #endregion

                #region case "Arqueiro":
                case "Arqueiro":

                    if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                    || idPersonagem3.Text == "Paladino")
                    {
                        if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                    || idPersonagem3.Text == "Mago")
                        {
                            if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                || idPersonagem3.Text == "Clérigo")
                            {
                                if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                || idPersonagem3.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id4 = 2;
                                    idPersonagem4.Text = "Cavaleiro";
                                    pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus4.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id4 = 3;
                                idPersonagem4.Text = "Clérigo";
                                pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus4.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id4 = 4;
                            idPersonagem4.Text = "Mago";
                            pbJogador4.ImageLocation = "Mago_Arrumado.png";
                            lblStatus4.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id4 = 5;
                        idPersonagem4.Text = "Paladino";
                        pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus4.Text = DescPaladino;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #region Botão Esquerdo 5
        private void btnEsquerda5_Click(object sender, EventArgs e)
        {
            switch (idPersonagem5.Text)
            {
                #region case "Paladino":
                case "Paladino":

                    if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                || idPersonagem4.Text == "Mago")
                    {
                        if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                || idPersonagem4.Text == "Clérigo")
                        {
                            if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                || idPersonagem4.Text == "Cavaleiro")
                            {
                                if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 1;
                                    idPersonagem5.Text = "Arqueiro";
                                    pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                                    lblStatus5.Text = DescArqueiro;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 2;
                                idPersonagem5.Text = "Cavaleiro";
                                pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                                lblStatus5.Text = DescCavaleiro;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 3;
                            idPersonagem5.Text = "Clérigo";
                            pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                            lblStatus5.Text = DescClérigo;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 4;
                        idPersonagem5.Text = "Mago";
                        pbJogador5.ImageLocation = "Mago_Arrumado.png";
                        lblStatus5.Text = DescMago;
                        break;
                    }
                #endregion

                #region case "Mago":
                case "Mago":

                    if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                || idPersonagem4.Text == "Clérigo")
                    {
                        if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                || idPersonagem4.Text == "Cavaleiro")
                        {
                            if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                            {
                                if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 5;
                                    idPersonagem5.Text = "Paladino";
                                    pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                                    lblStatus5.Text = DescPaladino;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 1;
                                idPersonagem5.Text = "Arqueiro";
                                pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus5.Text = DescArqueiro;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 2;
                            idPersonagem5.Text = "Cavaleiro";
                            pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                            lblStatus5.Text = DescCavaleiro;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 3;
                        idPersonagem5.Text = "Clérigo";
                        pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                        lblStatus5.Text = DescClérigo;
                        break;
                    }
                #endregion

                #region case "Clérigo":
                case "Clérigo":

                    if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                || idPersonagem4.Text == "Cavaleiro")
                    {
                        if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                        {
                            if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                            {
                                if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                    || idPersonagem4.Text == "Mago")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 4;
                                    idPersonagem5.Text = "Mago";
                                    pbJogador5.ImageLocation = "Mago_Arrumado.png";
                                    lblStatus5.Text = DescMago;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 5;
                                idPersonagem5.Text = "Paladino";
                                pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                                lblStatus5.Text = DescPaladino;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 1;
                            idPersonagem5.Text = "Arqueiro";
                            pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                            lblStatus5.Text = DescArqueiro;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 2;
                        idPersonagem5.Text = "Cavaleiro";
                        pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                        lblStatus5.Text = DescCavaleiro;
                        break;
                    }
                #endregion

                #region case "Cavaleiro":
                case "Cavaleiro":

                    if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                    || idPersonagem4.Text == "Arqueiro")
                    {
                        if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                        {
                            if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                    || idPersonagem4.Text == "Mago")
                            {
                                if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                || idPersonagem4.Text == "Clérigo")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 3;
                                    idPersonagem5.Text = "Clérigo";
                                    pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                                    lblStatus5.Text = DescClérigo;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 4;
                                idPersonagem5.Text = "Mago";
                                pbJogador5.ImageLocation = "Mago_Arrumado.png";
                                lblStatus5.Text = DescMago;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 5;
                            idPersonagem5.Text = "Paladino";
                            pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                            lblStatus5.Text = DescPaladino;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 1;
                        idPersonagem5.Text = "Arqueiro";
                        pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                        lblStatus5.Text = DescArqueiro;
                        break;
                    }
                #endregion

                #region case "Arqueiro":
                case "Arqueiro":

                    if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                    || idPersonagem4.Text == "Paladino")
                    {
                        if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                    || idPersonagem4.Text == "Mago")
                        {
                            if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                || idPersonagem4.Text == "Clérigo")
                            {
                                if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                || idPersonagem4.Text == "Cavaleiro")
                                {
                                    break;
                                }

                                else
                                {
                                    id5 = 2;
                                    idPersonagem5.Text = "Cavaleiro";
                                    pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus5.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 3;
                                idPersonagem5.Text = "Clérigo";
                                pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                                lblStatus5.Text = DescClérigo;
                                break;
                            }
                        }

                        else
                        {
                            id5 = 4;
                            idPersonagem5.Text = "Mago";
                            pbJogador5.ImageLocation = "Mago_Arrumado.png";
                            lblStatus5.Text = DescMago;
                            break;
                        }
                    }

                    else
                    {
                        id5 = 5;
                        idPersonagem5.Text = "Paladino";
                        pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                        lblStatus5.Text = DescPaladino;
                        break;
                    }
                    #endregion
            }
        }
        #endregion

        #endregion

        #endregion

        #region Ativar / Desativar Personagens

        #region OnOff 1
        private void OnOff1_Click(object sender, EventArgs e)
        {
            #region Verificar se o jogador posterior está desativado
            switch (OnOff2.ImageLocation)
            {
                case "Desativado.png":

                    switch (OnOff1.ImageLocation)
                    {
                        #region Ativado
                        case "Ativado.png":
                            idPersonagem1.Text = "Selecionar Jogador";
                            lblStatus1.Text = "Características do personagem";
                            pbJogador1.ImageLocation = "interrogação.png";
                            pbJogador1.Enabled = false;
                            btnDireita1.Enabled = false;
                            btnEsquerda1.Enabled = false;
                            tbJogador1.Enabled = false;
                            lblStatus1.TextAlign = ContentAlignment.TopCenter;
                            OnOff1.ImageLocation = "Desativado.png";
                            break;
                        #endregion

                        #region Desativado
                        case "Desativado.png":
                            pbJogador1.Enabled = true;
                            btnDireita1.Enabled = true;
                            btnEsquerda1.Enabled = true;
                            tbJogador1.Enabled = true;
                            lblStatus1.TextAlign = ContentAlignment.TopLeft;
                            OnOff1.ImageLocation = "Ativado.png";

                            if (idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro"
                                            || idPersonagem5.Text == "Arqueiro")
                            {
                                if (idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro"
                                            || idPersonagem5.Text == "Cavaleiro")
                                {
                                    if (idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo"
                                            || idPersonagem5.Text == "Clérigo")
                                    {
                                        if (idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago"
                                            || idPersonagem5.Text == "Mago")
                                        {
                                            if (idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino"
                                            || idPersonagem5.Text == "Paladino")
                                            {
                                                break;
                                            }

                                            else
                                            {
                                                id1 = 5;
                                                idPersonagem1.Text = "Paladino";
                                                pbJogador1.ImageLocation = "Paladino_ArrumadoDourado.png";
                                                lblStatus1.Text = DescPaladino;
                                                break;
                                            }
                                        }

                                        else
                                        {
                                            id1 = 4;
                                            idPersonagem1.Text = "Mago";
                                            pbJogador1.ImageLocation = "Mago_Arrumado.png";
                                            lblStatus1.Text = DescMago;
                                            break;
                                        }
                                    }

                                    else
                                    {
                                        id1 = 3;
                                        idPersonagem1.Text = "Clérigo";
                                        pbJogador1.ImageLocation = "Clerigo_Arrumado.png";
                                        lblStatus1.Text = DescClérigo;
                                        break;
                                    }
                                }

                                else
                                {
                                    id1 = 2;
                                    idPersonagem1.Text = "Cavaleiro";
                                    pbJogador1.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus1.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id1 = 1;
                                idPersonagem1.Text = "Arqueiro";
                                pbJogador1.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus1.Text = DescArqueiro;
                                break;
                            }
                            #endregion
                    }
                    break;

                case "Ativado.png":

                    MessageBox.Show("Para não selecionar este jogador, desmarque o jogador posterior!!!",
                    "*** JOGADOR POSTERIOR SELECIONADO ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;
            }
            #endregion
        }
        #endregion

        #region OnOff 2
        private void OnOff2_Click(object sender, EventArgs e)
        {
            #region Verificar se o jogador anterior está ativado
            switch (OnOff1.ImageLocation)
            {
                case "Ativado.png":

                    #region Verificar se o jogador posterior está desativado
                    switch (OnOff3.ImageLocation)
                    {
                        case "Desativado.png":

                            switch (OnOff2.ImageLocation)
                            {
                                #region Ativado
                                case "Ativado.png":
                                    idPersonagem2.Text = "Selecionar Jogador";
                                    lblStatus2.Text = "Características do personagem";
                                    pbJogador2.ImageLocation = "interrogação.png";
                                    pbJogador2.Enabled = false;
                                    btnDireita2.Enabled = false;
                                    btnEsquerda2.Enabled = false;
                                    tbJogador2.Enabled = false;
                                    lblStatus2.TextAlign = ContentAlignment.TopCenter;
                                    OnOff2.ImageLocation = "Desativado.png";
                                    break;
                                #endregion

                                #region Desativado
                                case "Desativado.png":
                                    pbJogador2.Enabled = true;
                                    btnDireita2.Enabled = true;
                                    btnEsquerda2.Enabled = true;
                                    tbJogador2.Enabled = true;
                                    lblStatus2.TextAlign = ContentAlignment.TopLeft;
                                    OnOff2.ImageLocation = "Ativado.png";

                                    if (idPersonagem3.Text == "Arqueiro" || idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro"
                                                    || idPersonagem1.Text == "Arqueiro")
                                    {
                                        if (idPersonagem3.Text == "Cavaleiro" || idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro"
                                                    || idPersonagem1.Text == "Cavaleiro")
                                        {
                                            if (idPersonagem3.Text == "Clérigo" || idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo"
                                                    || idPersonagem1.Text == "Clérigo")
                                            {
                                                if (idPersonagem3.Text == "Mago" || idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago"
                                                    || idPersonagem1.Text == "Mago")
                                                {
                                                    if (idPersonagem3.Text == "Paladino" || idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino"
                                                    || idPersonagem1.Text == "Paladino")
                                                    {
                                                        break;
                                                    }

                                                    else
                                                    {
                                                        id2 = 5;
                                                        idPersonagem2.Text = "Paladino";
                                                        pbJogador2.ImageLocation = "Paladino_ArrumadoDourado.png";
                                                        lblStatus2.Text = DescPaladino;
                                                        break;
                                                    }
                                                }

                                                else
                                                {
                                                    id2 = 4;
                                                    idPersonagem2.Text = "Mago";
                                                    pbJogador2.ImageLocation = "Mago_Arrumado.png";
                                                    lblStatus2.Text = DescMago;
                                                    break;
                                                }
                                            }

                                            else
                                            {
                                                id2 = 3;
                                                idPersonagem2.Text = "Clérigo";
                                                pbJogador2.ImageLocation = "Clerigo_Arrumado.png";
                                                lblStatus2.Text = DescClérigo;
                                                break;
                                            }
                                        }

                                        else
                                        {
                                            id2 = 2;
                                            idPersonagem2.Text = "Cavaleiro";
                                            pbJogador2.ImageLocation = "Cavaleiro_Arrumado.png";
                                            lblStatus2.Text = DescCavaleiro;
                                            break;
                                        }
                                    }

                                    else
                                    {
                                        id2 = 1;
                                        idPersonagem2.Text = "Arqueiro";
                                        pbJogador2.ImageLocation = "Arqueiro_Arrumado.png";
                                        lblStatus2.Text = DescArqueiro;
                                        break;
                                    }
                                    #endregion
                            }
                            break;

                        case "Ativado.png":

                            MessageBox.Show("Para não selecionar este jogador, desmarque o jogador posterior!!!",
                            "*** JOGADOR POSTERIOR SELECIONADO ***",
                                    MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            break;
                    }
                    break;
                #endregion

                case "Desativado.png":

                    MessageBox.Show("Para selecionar este jogador, é necessário que o jogador anterior também esteja selecionado!!!",
                    "*** JOGADOR ANTERIOR NÃO SELECIONADO ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;
            }
            #endregion
        }
        #endregion

        #region OnOff 3
        private void OnOff3_Click(object sender, EventArgs e)
        {
            #region Verificar se o jogador anterior está ativado
            switch (OnOff2.ImageLocation)
            {
                case "Ativado.png":

                    #region Verificar se o jogador posterior está desativado
                    switch (OnOff4.ImageLocation)
                    {
                        case "Desativado.png":

                            switch (OnOff3.ImageLocation)
                            {
                                #region Ativado
                                case "Ativado.png":
                                    idPersonagem3.Text = "Selecionar Jogador";
                                    lblStatus3.Text = "Características do personagem";
                                    pbJogador3.ImageLocation = "interrogação.png";
                                    pbJogador3.Enabled = false;
                                    btnDireita3.Enabled = false;
                                    btnEsquerda3.Enabled = false;
                                    tbJogador3.Enabled = false;
                                    lblStatus3.TextAlign = ContentAlignment.TopCenter;
                                    OnOff3.ImageLocation = "Desativado.png";
                                    break;
                                #endregion

                                #region Desativado
                                case "Desativado.png":
                                    pbJogador3.Enabled = true;
                                    btnDireita3.Enabled = true;
                                    btnEsquerda3.Enabled = true;
                                    tbJogador3.Enabled = true;
                                    lblStatus3.TextAlign = ContentAlignment.TopLeft;
                                    OnOff3.ImageLocation = "Ativado.png";

                                    if (idPersonagem4.Text == "Arqueiro" || idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro"
                                                    || idPersonagem2.Text == "Arqueiro")
                                    {
                                        if (idPersonagem4.Text == "Cavaleiro" || idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro"
                                                    || idPersonagem2.Text == "Cavaleiro")
                                        {
                                            if (idPersonagem4.Text == "Clérigo" || idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo"
                                                    || idPersonagem2.Text == "Clérigo")
                                            {
                                                if (idPersonagem4.Text == "Mago" || idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago"
                                                    || idPersonagem2.Text == "Mago")
                                                {
                                                    if (idPersonagem4.Text == "Paladino" || idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino"
                                                    || idPersonagem2.Text == "Paladino")
                                                    {
                                                        break;
                                                    }

                                                    else
                                                    {
                                                        id3 = 5;
                                                        idPersonagem3.Text = "Paladino";
                                                        pbJogador3.ImageLocation = "Paladino_ArrumadoDourado.png";
                                                        lblStatus3.Text = DescPaladino;
                                                        break;
                                                    }
                                                }

                                                else
                                                {
                                                    id3 = 4;
                                                    idPersonagem3.Text = "Mago";
                                                    pbJogador3.ImageLocation = "Mago_Arrumado.png";
                                                    lblStatus3.Text = DescMago;
                                                    break;
                                                }
                                            }

                                            else
                                            {
                                                id3 = 3;
                                                idPersonagem3.Text = "Clérigo";
                                                pbJogador3.ImageLocation = "Clerigo_Arrumado.png";
                                                lblStatus3.Text = DescClérigo;
                                                break;
                                            }
                                        }

                                        else
                                        {
                                            id3 = 2;
                                            idPersonagem3.Text = "Cavaleiro";
                                            pbJogador3.ImageLocation = "Cavaleiro_Arrumado.png";
                                            lblStatus3.Text = DescCavaleiro;
                                            break;
                                        }
                                    }

                                    else
                                    {
                                        id3 = 1;
                                        idPersonagem3.Text = "Arqueiro";
                                        pbJogador3.ImageLocation = "Arqueiro_Arrumado.png";
                                        lblStatus3.Text = DescArqueiro;
                                        break;
                                    }
                                    #endregion
                            }
                            break;

                        case "Ativado.png":

                            MessageBox.Show("Para não selecionar este jogador, desmarque o jogador posterior!!!",
                            "*** JOGADOR POSTERIOR SELECIONADO ***",
                                    MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            break;
                    }
                    break;
                #endregion

                case "Desativado.png":

                    MessageBox.Show("Para selecionar este jogador, é necessário que o jogador anterior também esteja selecionado!!!",
                    "*** JOGADOR ANTERIOR NÃO SELECIONADO ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;
            }
            #endregion
        }
        #endregion

        #region OnOff 4
        private void OnOff4_Click(object sender, EventArgs e)
        {
            #region Verificar se o jogador anterior está ativado
            switch (OnOff3.ImageLocation)
            {
                case "Ativado.png":

                    #region Verificar se o jogador posterior está desativado
                    switch (OnOff5.ImageLocation)
                    {
                        case "Desativado.png":

                            switch (OnOff4.ImageLocation)
                            {
                                #region Ativado
                                case "Ativado.png":
                                    idPersonagem4.Text = "Selecionar Jogador";
                                    lblStatus4.Text = "Características do personagem";
                                    pbJogador4.ImageLocation = "interrogação.png";
                                    pbJogador4.Enabled = false;
                                    btnDireita4.Enabled = false;
                                    btnEsquerda4.Enabled = false;
                                    tbJogador4.Enabled = false;
                                    lblStatus4.TextAlign = ContentAlignment.TopCenter;
                                    OnOff4.ImageLocation = "Desativado.png";
                                    break;
                                #endregion

                                #region Desativado
                                case "Desativado.png":
                                    pbJogador4.Enabled = true;
                                    btnDireita4.Enabled = true;
                                    btnEsquerda4.Enabled = true;
                                    tbJogador4.Enabled = true;
                                    lblStatus4.TextAlign = ContentAlignment.TopLeft;
                                    OnOff4.ImageLocation = "Ativado.png";

                                    if (idPersonagem5.Text == "Arqueiro" || idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro"
                                                    || idPersonagem3.Text == "Arqueiro")
                                    {
                                        if (idPersonagem5.Text == "Cavaleiro" || idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro"
                                                    || idPersonagem3.Text == "Cavaleiro")
                                        {
                                            if (idPersonagem5.Text == "Clérigo" || idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo"
                                                    || idPersonagem3.Text == "Clérigo")
                                            {
                                                if (idPersonagem5.Text == "Mago" || idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago"
                                                    || idPersonagem3.Text == "Mago")
                                                {
                                                    if (idPersonagem5.Text == "Paladino" || idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino"
                                                    || idPersonagem3.Text == "Paladino")
                                                    {
                                                        break;
                                                    }

                                                    else
                                                    {
                                                        id4 = 5;
                                                        idPersonagem4.Text = "Paladino";
                                                        pbJogador4.ImageLocation = "Paladino_ArrumadoDourado.png";
                                                        lblStatus4.Text = DescPaladino;
                                                        break;
                                                    }
                                                }

                                                else
                                                {
                                                    id4 = 4;
                                                    idPersonagem4.Text = "Mago";
                                                    pbJogador4.ImageLocation = "Mago_Arrumado.png";
                                                    lblStatus4.Text = DescMago;
                                                    break;
                                                }
                                            }

                                            else
                                            {
                                                id4 = 3;
                                                idPersonagem4.Text = "Clérigo";
                                                pbJogador4.ImageLocation = "Clerigo_Arrumado.png";
                                                lblStatus4.Text = DescClérigo;
                                                break;
                                            }
                                        }

                                        else
                                        {
                                            id4 = 2;
                                            idPersonagem4.Text = "Cavaleiro";
                                            pbJogador4.ImageLocation = "Cavaleiro_Arrumado.png";
                                            lblStatus4.Text = DescCavaleiro;
                                            break;
                                        }
                                    }

                                    else
                                    {
                                        id4 = 1;
                                        idPersonagem4.Text = "Arqueiro";
                                        pbJogador4.ImageLocation = "Arqueiro_Arrumado.png";
                                        lblStatus4.Text = DescArqueiro;
                                        break;
                                    }
                                    #endregion
                            }
                            break;

                        case "Ativado.png":

                            MessageBox.Show("Para não selecionar este jogador, desmarque o jogador posterior!!!",
                            "*** JOGADOR POSTERIOR SELECIONADO ***",
                                    MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                            break;
                    }
                    break;
                #endregion

                case "Desativado.png":

                    MessageBox.Show("Para selecionar este jogador, é necessário que o jogador anterior também esteja selecionado!!!",
                    "*** JOGADOR ANTERIOR NÃO SELECIONADO ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;
            }
            #endregion
        }
        #endregion

        #region OnOff 5
        private void OnOff5_Click(object sender, EventArgs e)
        {
            #region Verificar se o jogador anterior está ativado
            switch (OnOff4.ImageLocation)
            {
                case "Ativado.png":

                    switch (OnOff5.ImageLocation)
                    {
                        #region Ativado
                        case "Ativado.png":
                            idPersonagem5.Text = "Selecionar Jogador";
                            lblStatus5.Text = "Características do personagem";
                            pbJogador5.ImageLocation = "interrogação.png";
                            pbJogador5.Enabled = false;
                            btnDireita5.Enabled = false;
                            btnEsquerda5.Enabled = false;
                            tbJogador5.Enabled = false;
                            lblStatus5.TextAlign = ContentAlignment.TopCenter;
                            OnOff5.ImageLocation = "Desativado.png";
                            break;
                        #endregion

                        #region Desativado
                        case "Desativado.png":
                            pbJogador5.Enabled = true;
                            btnDireita5.Enabled = true;
                            btnEsquerda5.Enabled = true;
                            tbJogador5.Enabled = true;
                            lblStatus5.TextAlign = ContentAlignment.TopLeft;
                            OnOff5.ImageLocation = "Ativado.png";

                            if (idPersonagem1.Text == "Arqueiro" || idPersonagem2.Text == "Arqueiro" || idPersonagem3.Text == "Arqueiro"
                                            || idPersonagem4.Text == "Arqueiro")
                            {
                                if (idPersonagem1.Text == "Cavaleiro" || idPersonagem2.Text == "Cavaleiro" || idPersonagem3.Text == "Cavaleiro"
                                            || idPersonagem4.Text == "Cavaleiro")
                                {
                                    if (idPersonagem1.Text == "Clérigo" || idPersonagem2.Text == "Clérigo" || idPersonagem3.Text == "Clérigo"
                                            || idPersonagem4.Text == "Clérigo")
                                    {
                                        if (idPersonagem1.Text == "Mago" || idPersonagem2.Text == "Mago" || idPersonagem3.Text == "Mago"
                                            || idPersonagem4.Text == "Mago")
                                        {
                                            if (idPersonagem1.Text == "Paladino" || idPersonagem2.Text == "Paladino" || idPersonagem3.Text == "Paladino"
                                            || idPersonagem4.Text == "Paladino")
                                            {
                                                break;
                                            }

                                            else
                                            {
                                                id5 = 5;
                                                idPersonagem5.Text = "Paladino";
                                                pbJogador5.ImageLocation = "Paladino_ArrumadoDourado.png";
                                                lblStatus5.Text = DescPaladino;
                                                break;
                                            }
                                        }

                                        else
                                        {
                                            id5 = 4;
                                            idPersonagem5.Text = "Mago";
                                            pbJogador5.ImageLocation = "Mago_Arrumado.png";
                                            lblStatus5.Text = DescMago;
                                            break;
                                        }
                                    }

                                    else
                                    {
                                        id5 = 3;
                                        idPersonagem5.Text = "Clérigo";
                                        pbJogador5.ImageLocation = "Clerigo_Arrumado.png";
                                        lblStatus5.Text = DescClérigo;
                                        break;
                                    }
                                }

                                else
                                {
                                    id5 = 2;
                                    idPersonagem5.Text = "Cavaleiro";
                                    pbJogador5.ImageLocation = "Cavaleiro_Arrumado.png";
                                    lblStatus5.Text = DescCavaleiro;
                                    break;
                                }
                            }

                            else
                            {
                                id5 = 1;
                                idPersonagem5.Text = "Arqueiro";
                                pbJogador5.ImageLocation = "Arqueiro_Arrumado.png";
                                lblStatus5.Text = DescArqueiro;
                                break;
                            }
                            #endregion
                    }
                    break;

                case "Desativado.png":

                    MessageBox.Show("Para selecionar este jogador, é necessário que o jogador anterior também esteja selecionado!!!",
                    "*** JOGADOR ANTERIOR NÃO SELECIONADO ***",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;
            }
            #endregion
        }
        #endregion

        #endregion
    }
}