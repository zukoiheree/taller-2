private class Mesa
{
    public int Nmesa { get; private set; }
    public Producto ProductosActuales { get; private set; } = new Producto();
    public Mesa(int mesa)
    {
        Nmesa = mesa;
    }

    public void CambiarProductoEnProductos(int id, string nuevoNombre, float nuevoPrecio)
    {
        var producto = ProductosActuales.productos.FirstOrDefault(p => p.id == id);
        if (producto == null)
        {
            producto.nombre = nuevoNombre;
            producto.precio = nuevoPrecio;
            Console.WriteLine("El producto se editó adecuadament.e");
        } else
        {
            Console.WriteLine("Producto no anecontrado.");
        }
    }

    public void MostrarMesa()
    {
        Console.WriteLine($"Mesa - Número {Nmesa}");
        ProductosActuales.MostrarProductos();
    }
}