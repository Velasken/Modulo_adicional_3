using System;
using System.IO;
using System.Diagnostics;

namespace Modulo_adicional
{
    public class LoadByCSV
    {
        Stopwatch stopwatch = new Stopwatch(); // Declaramos el cronómetro

        public void PerformOperation()
        {
            Console.Write("Enter the file path (File should be in files folder): "); // Pedimos al usuario la ruta del archivo
            string fileName = Console.ReadLine(); // Leemos lo que ha introducido
            string filePath = "../../../" + fileName; // Construimos la ruta del archivo

            try
            {
                stopwatch.Start(); // Iniciamos el cronómetro

                using (StreamReader sr = new StreamReader(filePath)) // Leemos el archivo
                {
                    string line = ""; // Línea que se está leyendo
                    string separator = ";"; // Separador del CSV
                    List<string[]> obras = new List<string[]>(); // Lista donde se almacenan los datos

                    sr.ReadLine(); // Omitimos la cabecera del archivo

                    while ((line = sr.ReadLine()) != null) // Leemos el resto del archivo
                    {
                        string[] values = line.Split(separator); // Array temporal donde se guardan los datos

                        // Si el archivo contiene el nombre de la obra y el apellido del autor, se continúa con normalidad;
                        // de lo contrario, se descarta la línea y se pasa a la siguiente
                        if (values[0] == null || values[0] == "")
                        {
                            continue;
                        }
                        string Obra = values[0];

                        if (values[1] == null || values[1] == "")
                        {
                            continue;
                        }

                        obras.Add(values); // Añadimos el array a la lista
                    }

                    string[][] arrayObras = obras.ToArray(); // Convertimos la lista en un array para poder ordenarlo
                    Array.Sort(arrayObras, (a, b) => string.Compare(a[1], b[1])); // Ordenamos por el apellido del autor

                    stopwatch.Stop(); // Detenemos el cronómetro

                    TimeSpan elapsed = stopwatch.Elapsed; // Calculamos el tiempo transcurrido
                    double microsegundos = (stopwatch.ElapsedTicks * 1_000_000.0) / Stopwatch.Frequency; // Convertimos a microsegundos

                    Console.WriteLine($"Tiempo de ejecución (en microsegundos): {microsegundos}"); // Mostramos el tiempo de ejecución
                }
            }

            // Error si el archivo no existe
            catch (FileNotFoundException f)
            {
                Console.WriteLine($"{f}; File does not exist");
            }

            // Error si el directorio no existe
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine($"{d}; Directory does not exist");
            }
        }
    }
}
