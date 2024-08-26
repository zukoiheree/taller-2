private class Producto
{
    public List<Menu> productos { get; private set; } = new List<Menu>();

    public void MostrarProductos()
    {
        Console.WriteLine("Productos:");
        foreach (var producto in productos)
        {
            Console.WriteLine($"ID: {producto.id} - {producto.nombre} - ${producto.precio}");
        }
    }

    public void AgregarProducto(Menu producto)
    {
        productos.Add(producto);
    }

    public void EliminarProducto(int id)
    {
        var producto = productos.FirstOrDefault(p => p.id == id);
        if (producto != null)
        {
            productos.Remove(producto);
        }
        else
        {
            Console.WriteLine("Este producto no ha sido encontrado");
        }
    }
    public void EditarProducto(int id, string nuevoNombre, float nuevoPrecio)
    {
        var menu = productos.FirstOrDefault(m => m.id == id);
        if (menu != null)
        {
            menu.nombre = nuevoNombre;
            menu.precio = nuevoPrecio;
            Console.WriteLine("El producto se editó adecuadamente.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }
    public float CalcularTotal()
    {
        return productos.Sum(p => p.precio);
    }
}