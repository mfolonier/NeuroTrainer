using System;


namespace NeuroTrainer.Helper
{
    public class RandomNum
    {
        public static Random rnd;
        public static int number;
        public static int RandomGenerate(int numero)
        {


            rnd = new Random();
            number = rnd.Next(numero);

            return number;

        }

        public static int RandomGenerateWithoutZero(int numero)
        {


            rnd = new Random();
            number = rnd.Next(1, numero);

            return number;

        }

    }
}
