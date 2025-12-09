using System;
using System.IO;
using System.Diagnostics;

namespace Modulo_adicional
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                LoadByCSV loader = new LoadByCSV(); // Creamos una nueva instancia de la clase LoadByCSV
                loader.PerformOperation(); // Ejecutamos la operación de carga del archivo y ordenación
            }
            catch(FormatException)
            {
                Console.WriteLine("Wrong type of input");
            }
            catch(OverflowException)
            {
                Console.WriteLine("This number is too large");
            }
        }
    }
}
