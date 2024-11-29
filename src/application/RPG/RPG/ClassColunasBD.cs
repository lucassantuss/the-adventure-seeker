namespace RPG
{
    class ClassColunasBD
    {
        #region Primary Keys
        int idclasse;
        int idpartida;
        int idhabilidade;
        int idinimigo;
        int idinventario;
        int iditem;
        int idjogador;
        int idloja;
        int idmapa;
        int idmissao;
        int idvillage;

        public int IdClasse
        {
            get { return idclasse; }
            set { idclasse = value; }
        }

        public int IdPartida
        {
            get { return idpartida; }
            set { idpartida = value; }
        }

        public int IdHabilidade
        {
            get { return idinimigo; }
            set { idinimigo = value; }
        }

        public int IdInimigo
        {
            get { return idhabilidade; }
            set { idhabilidade = value; }
        }

        public int IdInventario
        {
            get { return idinventario; }
            set { idinventario = value; }
        }

        public int IdItem
        {
            get { return iditem; }
            set { iditem = value; }
        }

        public int IdJogador
        {
            get { return idjogador; }
            set { idjogador = value; }
        }

        public int IdLoja
        {
            get { return idloja; }
            set { idloja = value; }
        }

        public int IdMapa
        {
            get { return idmapa; }
            set { idmapa = value; }
        }

        public int IdMissao
        {
            get { return idmissao; }
            set { idmissao = value; }
        }

        public int IdVillage
        {
            get { return idvillage; }
            set { idvillage = value; }
        }
        #endregion

        #region Jogador
        // idJogador
        string nomejogador;
        int nivel;
        int experiencia;
        // idInventario
        // idClasse
        // idPartida

        public string NomeJogador
        {
            get { return nomejogador; }
            set { nomejogador = value; }
        }

        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public int Experiencia
        {
            get { return experiencia; }
            set { experiencia = value; }
        }
        #endregion

        #region Classe
        // idClasse
        int vida;
        int mana;
        int dano;
        string nomeclasse;
        int defesa;
        int defesamagica;
        int agilidade;
        string descclasse;

        public int Vida
        {
            get { return vida; }
            set { vida = value; }
        }

        public int Mana
        {
            get { return mana; }
            set { mana = value; }
        }

        public int Dano
        {
            get { return dano; }
            set { dano = value; }
        }

        public string NomeClasse
        {
            get { return nomeclasse; }
            set { nomeclasse = value; }
        }

        public int Defesa
        {
            get { return defesa; }
            set { defesa = value; }
        }

        public int DefesaMagica
        {
            get { return defesamagica; }
            set { defesamagica = value; }
        }

        public int Agilidade
        {
            get { return agilidade; }
            set { agilidade = value; }
        }

        public string DescClasse
        {
            get { return descclasse; }
            set { descclasse = value; }
        }
        #endregion

        #region DadosPartida
        int totaljogadores;

        public int TotalJogadores
        {
            get { return totaljogadores; }
            set { totaljogadores = value; }
        }
        #endregion
    }
}