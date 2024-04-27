using System;

namespace RPG
{
    class Acoes
    {
        public int Atacar(int PClasseDano, int AtkForce, int AtkType, int InimDef)
            //(PClasse.Dano, AtkForce, AtkType, InimDef, InimMagDef, )
        {
            double Dano = 0;
            int DanoFinal = 0;
            double BonusCrit = 1;
            double BonusAtkForce = 0;

            #region Código do Dado
            int NumDado;
            Random rndNumero = new Random();
            NumDado = rndNumero.Next(1, 21);

            // 2 de 20 - 10% de Chance de Critico 
            if (NumDado > 18)
            {
                //Critico();
                BonusCrit = 1.6; // Multiplica o dano 
            }
            #endregion

            if (AtkForce == 1)
            {
                BonusAtkForce = 0.4;
            }

            if (AtkForce == 2)
            {
                BonusAtkForce = 0.8;
            }

            if (AtkForce == 3)
            {
                BonusAtkForce = 1.2;
            }

            // Se o Atk ñ for Magia
            if (AtkType == 1)
            {
                Dano = ((PClasseDano * BonusAtkForce) * BonusCrit) - InimDef;
            }

            DanoFinal = Convert.ToInt32(Dano);

            return DanoFinal;
        }
    }
}