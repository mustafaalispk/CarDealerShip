using CarDealerShip.Data;
using CarDealerShip.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

                Clear();
            }

        }

        private static void DisplayRegistry()
        {
            // Här vi hämtar alla car från databasen.

            List<Car> carList = context.Car.ToList();

            Write("Reg.nr".PadRight(10, ' '));
            Write("Märke".PadRight(10, ' '));
            Write("Model".PadRight(10, ' '));
            Write("Tillv.år".PadRight(10, ' '));
            WriteLine("Pris");

            foreach (Car car in carList)
            {
                Write(car.RegistrationNumber.PadRight(10, ' '));
                Write(car.Brand.PadRight(10, ' '));
                Write(car.Model.PadRight(10, ' '));
                Write(car.MakeYear.PadRight(10, ' '));
                WriteLine(car.Price);
            }
            ReadKey(true);
        }

        private static void RegisterCar()
        {
            bool isCorrect = false;            

            do
            {
                Clear();

                Write("Registrationnummer: ");

                string registrationNumber = ReadLine();

                Write("Märke: ");

                string brand = ReadLine();

                Write("Model: ");

                string model = ReadLine();

                Write("Tillverkningsår: ");

                string makeYear = ReadLine();

                Write("Pris: ");

                decimal price = decimal.Parse(ReadLine());

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

                    WriteLine("Bil registrerad");

                    Thread.Sleep(2000);

                    isCorrect = true;
                }
            } while (!isCorrect);
        }

        private static void SaveCar(Car car)
        {
            context.Car.Add(car);

            context.SaveChanges();           

        }
      
    }
}
