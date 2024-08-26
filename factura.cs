private class Factura
{
    public List<Mesa> Mesas { get; private set; } = new List<Mesa>();

    public void AgregarMesa(Mesa mesa)
    {
        Mesas.Add(mesa);
    }

    public void ImprimirFactura()
    {
        Console.WriteLine("Factura:");
        float totalNeto = 0;

        foreach (var mesa in Mesas)
        {
            mesa.MostrarMesa();
            float totalMesa = mesa.ProductosActuales.CalcularTotal();
            Console.WriteLine($"Total para la mesa {mesa.Nmesa}: ${totalMesa}");
            totalNeto += totalMesa;
        }
        Console.WriteLine($"Total Neto: ${totalNeto}");
    }
}