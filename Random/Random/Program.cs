using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RandomNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw;
            string path = Directory.GetCurrentDirectory();
            Random random = new Random();
            int number;
            List<int> numbers = new List<int>();

            try
            {
                sw = new StreamWriter(@"Random.txt", true, Encoding.ASCII);

                while (numbers.Count() <= 100000)
                {
                    number = random.Next();
                    if (!numbers.Contains(number))
                    {
                        numbers.Add(number);
                        Console.WriteLine(number);
                        sw.WriteLine(number);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                Console.WriteLine("Fichero creado en " + path + ". Pulse cualquier tecla para salir.");
                Console.ReadLine();
            }



        }
    }
}
