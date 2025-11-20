using Clases;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Json
{
    internal class Program
    {

        public static void EscribirAutoJson(string path, Auto auto)
        {
            string objetoString = JsonSerializer.Serialize(auto);
            File.WriteAllText(path, objetoString);
        }

        public static void EscribirAutosJson(string path, List<Auto> autos)
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            opciones.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);


            string objetoString = JsonSerializer.Serialize(autos,opciones);
            File.WriteAllText(path, objetoString);
        }


        public static Auto LeerAutoJson(string path)
        {
            string lectura = File.ReadAllText(path);
            Auto auto = JsonSerializer.Deserialize<Auto>(lectura);
            return auto;
        }

        public static List<Auto> LeerAutosJson(string path)
        {
            string lectura = File.ReadAllText(path);            
            List<Auto> auto = JsonSerializer.Deserialize<List<Auto>>(lectura);
            return auto;
        }


        static void Main(string[] args)
        {
            string ubicacion = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string rutaCompleta = Path.Combine(ubicacion, "Autos.json");

            Auto auto1 = new Auto("Fíat", "Rojo", "AB 123 CD", 2025, 10000);
            Auto auto2 = new Auto("Ford", "Rojo", "AB 123 CD", 2025, 10000);
            Auto auto3 = new Auto("Chevrolet", "Rojo", "AB 123 CD", 2025, 10000);
            Auto auto4 = new Auto("Renault", "Rojo", "AB 123 CD", 2025, 10000);
            Auto auto5 = new Auto("Mercedes Benz", "Rojo", "AB 123 CD", 2025, 10000);

            List<Auto> list = new List<Auto>()
            {
                auto1, auto2, auto3, auto4, auto5
            };


            //if (DB.Guardar(auto1))
            //{
            //    Console.WriteLine("Exito al guardar");
            //}
            //else
            //{
            //    Console.WriteLine("Se produjo un error al intentar acceder a la DB");
            //}

            List<Auto> autosDB = DB.LeerTodos();


            foreach (Auto auto in autosDB) 
            {
                Console.WriteLine($"ID:{auto.Id} - {auto}");
            }




        }
    }
}
