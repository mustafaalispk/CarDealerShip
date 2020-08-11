using CarDealerShip.Data;
using CarDealerShip.Domain.Model;
using System;
using static System.Console;

namespace CarDealerShip
{
    class Program
    {
        static string connectionString = "Server=.;Database=CarDealerShip;Trusted_Connection=True";

        static CarDealerShipContext context = new CarDealerShipContext(connectionString);
        static void Main(string[] args)
        {
            bool isShouldNotExit = true;                    

            while (isShouldNotExit)
            {
                WriteLine("1. Registrera bil");
                WriteLine("2. Visa bilregister");
                WriteLine("3. Avsluta");

                ConsoleKeyInfo keyPressd = ReadKey(true);

                Clear();

                switch (keyPressd.Key)
                {
                    case ConsoleKey.D1:

                        RegisterCar();

                        break;

                    case ConsoleKey.D2:

                        DisplayRegistry();

                        break;

                    case ConsoleKey.D3:

                        isShouldNotExit = false;

                        break;


                }
            }

        }

        private static void DisplayRegistry()
        {
            throw new NotImplementedException();
        }

        private static void RegisterCar()
        {
            bool isCorrect = false;            

            do
            {
                Clear();

                WriteLine("Registrationnummer: ");

                string registrationNumber = ReadLine();

                Write("Märke: ");

                string brand = ReadLine();

                Write("Model: ");

                string model = ReadLine();

                Write("Tillverkningsår: ");

                string makeYear = ReadLine();

                Write("Pris: ");

                string price = ReadLine();

                WriteLine();

                WriteLine("Är det korrekt? J(a) eller N(ej)");

                ConsoleKeyInfo keyPressed;

                bool isVAlidKey = false;

                do
                {
                    keyPressed = ReadKey(true);

                    isVAlidKey = keyPressed.Key == ConsoleKey.J ||
                                 keyPressed.Key == ConsoleKey.N;
                } while (!isVAlidKey);

                if (keyPressed.Key == ConsoleKey.J)
                {
                   Car car = new Car(registrationNumber, brand, model, makeYear, price);

                    SaveCar(car);

                    isCorrect = true;
                }
            } while (!isCorrect);
        }

        private static void SaveCar(Car car)
        {
           
        }
    }
}
