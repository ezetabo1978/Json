namespace Clases
{
    public class Auto
    {
        int id;
        string marca;
        string color;
        string patente;
        int modelo;
        double precio;

        public Auto(string marca, string color, string patente, int modelo, double precio)
        {
            this.marca = marca;
            this.color = color;
            this.patente = patente;
            this.modelo = modelo;
            this.precio = precio;
        }

        public string Marca { get => marca; set => marca = value; }
        public string Color { get => color; set => color = value; }
        public string Patente { get => patente; set => patente = value; }
        public int Modelo { get => modelo; set => modelo = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Id { get => id; set => id = value; }

        public double PrecioConIva
        {
            get
            {
                return precio * 0.21;
            }
        }

        public override string ToString()
        {
            return $"Marca: {marca} - Color: {color} - Patente: {patente}- Modelo: {modelo} - Precio: {precio}";
        }

    }
}
