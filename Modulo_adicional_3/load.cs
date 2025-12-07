using System;
using System.IO;
using System.Diagnostics;

namespace Modulo_adicional
{
    public class LoadByCSV
    {
        public void PerformOperation()
        {
            Console.Write("Enter the file path (File should be in files folder): ");
            string fileName = Console.ReadLine();

            string filePath = "../../../" + fileName;

            // Search for errors with the path
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = "";
                    string separator = ";";

                    sr.ReadLine(); //Quito la cabecera

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(separator);

                        if (values[0] == null || values[0] == "")
                        {
                            continue;
                        }
                        string Obra = values[0];

                        if (values[1] == null || values[1] == "")
                        {
                            continue;
                        }
                        string Apellautor = values[1];
                        string Nomautor = values[2];
                        string Tonalidad = values[3];
                        string Opus = values[4];
                        string Duracion = values[5];
                    }
                }
            }

            // Error if the path doesn't exist
            catch (FileNotFoundException f)
            {
                Console.WriteLine($"{f}; File does not exist");
            }

            // Error if the directory is not found
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine($"{d}; Directory does not exist");
            }
        }
    }
}
