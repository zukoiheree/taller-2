private class Restaurante
{
    static void Main()
    {
        Menu.ListaProductos();
        Menu.Admin admin = new Menu.Admin();
        Producto producto = new Producto();
        
        Factura factura = new Factura();

        while (true)
        {
            Console.WriteLine("1. Ver Menu");
            Console.WriteLine("2. Reservar Mesa");
            Console.WriteLine("3. Reservas");
            Console.WriteLine("4. Editar Reserva");
            Console.WriteLine("5. Generar Factura");
            Console.WriteLine("6. Editar Producto");
            Console.WriteLine("0. Salir");
            Console.Write("Elección: ");

            int elección;
            if (!int.TryParse(Console.ReadLine(), out elección))
            {
                Console.WriteLine("Elección inválida.");
                continue;
            }

            switch (elección)
            {
                case 1:
                    Menu.VerListaProductos();
                    break;
                case 2:
                    Console.Write("Ingrese la mesa a reservar:");
                    int nmesa = int.Parse(Console.ReadLine());
                    Mesa nuevaMesa = new Mesa(nmesa);

                    while (true)
                    {
                        Menu.VerListaProductos();
                        Console.WriteLine("Ingrese el ID del producto (nada para agregar o 0 para terminar): ");
                        int productoId = int.Parse(Console.ReadLine());

                        if (productoId == 0) break;

                        var producto1 = admin.BuscarProductoPorId(productoId);
                        if (producto1 != null)
                        {
                            nuevaMesa.ProductosActuales.AgregarProducto(producto1);
                            Console.WriteLine($"Producto '{producto1.nombre}' añadido.");
                        }
                        else
                        {
                            Console.WriteLine("No se encuentra el producto.");
                        }
                    }

                    factura.AgregarMesa(nuevaMesa);
                    Console.WriteLine("Fué creada adecuadamente");
                    break;
                case 3:
                    if (factura.Mesas.Count == 0)
                    {
                        Console.WriteLine("Reservas no encontradas.");
                    }
                    else
                    {
                        foreach (var mesa in factura.Mesas)
                        {
                            mesa.MostrarMesa();
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Escriba la mesa de reserva para editar: ");
                    int editarMesa = int.Parse(Console.ReadLine());
                    var editarReserva = factura.Mesas.FirstOrDefault(r => r.Nmesa == editarMesa);

                    if (editarReserva != null)
                    {
                        Console.WriteLine("Productos en la reserva actual");
                        editarReserva.MostrarMesa();

                        Console.WriteLine("Escriba el id del producto para eliminar o editar (o 0 para cancelar): ");
                        int editarProductoId = int.Parse(Console.ReadLine());

                        if (editarProductoId != 0)
                        {
                            Console.WriteLine("1. Cambiar nombre y precio del producto");
                            Console.WriteLine("2. Eliminar el producto");
                            Console.Write("Realice su elección: ");
                            int elecciónEdición = int.Parse(Console.ReadLine());    

                            if (elecciónEdición == 1)
                            {
                                Console.WriteLine("Escriba un nuevo nombre para el producto");
                                string nuevoNombre = Console.ReadLine();
                                Console.WriteLine("Escriba un nuevo precio para el prodco");
                                float nuevoPrecio = float.Parse(Console.ReadLine());
                                editarReserva.CambiarProductoEnProductos(editarProductoId, nuevoNombre, nuevoPrecio);
                            }
                            else
                            {
                                if(elecciónEdición == 2)
                                {
                                    editarReserva.ProductosActuales.EliminarProducto(editarProductoId);
                                    Console.WriteLine("El producto fue eliminado");
                                }
                                else
                                {
                                    Console.WriteLine("opción inválida");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encuentra esta Reserva.");
                        }
                    }
                    break;
                case 5:
                    factura.ImprimirFactura();
                    break;
                case 6:
                    Console.Write("Escriba el ID del producto a editar: ");
                    int productoEditarId = int.Parse(Console.ReadLine());
                    Console.Write("Escriba un nuevo nombre para el producto: ");
                    string nuevoNombreProducto = Console.ReadLine();
                    Console.Write("Escriba un nuevo precio para el producto: ");
                    float nuevoPrecioProducto = float.Parse(Console.ReadLine());
                    producto.EditarProducto(productoEditarId, nuevoNombreProducto, nuevoPrecioProducto);
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}