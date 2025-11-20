using MySql.Data.MySqlClient;
using System.Data;

namespace Clases
{
    public static class DB
    {
        static MySqlCommand command;

        static DB()
        {
            command = new MySqlCommand();
            command.Connection = new MySqlConnection("Server=localhost; Database=garage; Uid=root; Pwd=;");
            command.CommandType = CommandType.Text;
        }

        public static bool Guardar(Auto auto)
        {
            bool exito = true;

            try
            {
                string qry = $"INSERT INTO idautos(marca, color, patente, modelo, precio) VALUES (@marca, @color, @patente, @modelo, @precio)";

                command.Connection.Open();
                command.CommandText = qry;

                command.Parameters.AddWithValue("@marca", auto.Marca);
                command.Parameters.AddWithValue("@color", auto.Color);
                command.Parameters.AddWithValue("@patente", auto.Patente);
                command.Parameters.AddWithValue("@modelo", auto.Modelo);
                command.Parameters.AddWithValue("@precio", auto.Precio);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar guardar en la db: {ex.Message}");

                exito = false;
            }
            finally
            {
                if (command.Connection is not null && command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();

                }
            }

            return exito;
        }

        public static List<Auto> LeerTodos()
        {
            List<Auto> autos = new List<Auto>();
            try
            {
                string qry = "SELECT * FROM idautos";

                command.Connection.Open();
                command.CommandText = qry;

                using (MySqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        int id = dataReader.GetInt32("id");
                        string marca = dataReader.GetString("marca");
                        string color = dataReader.GetString("color");
                        string patente = dataReader.GetString("patente");
                        int modelo = dataReader.GetInt32("modelo");
                        double precio = dataReader.GetDouble("precio");

                        Auto nuevo = new Auto(marca, color, patente, modelo, precio);

                        nuevo.Id = id;

                        autos.Add(nuevo);
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (command.Connection is not null && command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();

                }
            }

            return autos;
        }
        public static bool GuardarTodos(List<Auto> autos)
        {
            bool exito = true;

            try
            {
                command.Connection.Open();

                foreach (Auto auto in autos)
                {
                    string qry = $"INSERT INTO idautos(marca, color, patente, modelo, precio) VALUES (@marca, @color, @patente, @modelo, @precio)";
                    command.CommandText = qry;

                    command.Parameters.AddWithValue("@marca", auto.Marca);
                    command.Parameters.AddWithValue("@color", auto.Color);
                    command.Parameters.AddWithValue("@patente", auto.Patente);
                    command.Parameters.AddWithValue("@modelo", auto.Modelo);
                    command.Parameters.AddWithValue("@precio", auto.Precio);

                    command.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar guardar en la db: {ex.Message}");

                exito = false;
            }
            finally
            {
                if (command.Connection is not null && command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();

                }
            }

            return exito;
        }

        public static bool Editar(Auto modificado)
        {
            bool exito = true;
            try
            {
                string qry = "UPDATE idautos SET marca=@marca,color=@color,patente=@patente,modelo=@modelo,precio=@precio WHERE id=@id";

                command.Connection.Open();
                command.CommandText = qry;

                command.Parameters.AddWithValue("@id", modificado.Id);
                command.Parameters.AddWithValue("@marca", modificado.Marca);
                command.Parameters.AddWithValue("@color", modificado.Color);
                command.Parameters.AddWithValue("@patente", modificado.Patente);
                command.Parameters.AddWithValue("@modelo", modificado.Modelo);
                command.Parameters.AddWithValue("@precio", modificado.Precio);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar updatear en la base datos: {ex.Message}");
                exito = false;
                return exito;
            }
            finally
            {
                if (command.Connection is not null && command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();

                }
            }

            return exito;
            
        }

        public static bool Eliminar(Auto auto)
        {
            bool exito = true;
            try
            {
                string qry = "DELETE FROM idautos WHERE id=@id";

                command.Connection.Open();
                command.CommandText = qry;

                command.Parameters.AddWithValue("@id", auto.Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar eliminar en la base datos: {ex.Message}");
                exito = false;
                return exito;
            }
            finally
            {
                if (command.Connection is not null && command.Connection.State == ConnectionState.Open)
                {
                    command.Connection.Close();

                }
            }
            return exito;
        }


        public static string MetodoDePrueba(string msj)
        {
            return msj;
        }
    }
}
