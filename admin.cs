public class Admin
{
    private List<Menu> todosLosProductos = new List<Menu>();
    public Menu BuscarProductoPorId(int id)
    {
        return productos.FirstOrDefault(m => m.id == id);
    }
}