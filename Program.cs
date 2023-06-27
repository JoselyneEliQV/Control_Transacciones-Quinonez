using Taller_Metodos_CRUD_Quinonez.Models;
using ConsoleTables;




class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("-------Bienvenidos--------");
            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Consultar clientes");
            Console.WriteLine("3. Modificar cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("5. Salir");
            Console.Write("Ingrese una opci�n: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarCliente();
                    break;
                case "2":
                    ConsultarCliente();
                    break;
                case "3":
                    ModificarCliente();
                    break;
                case "4":
                    EliminarCliente();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opci�n inv�lida.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // Agregar cliente
    public static void AgregarCliente()
    {
        Console.WriteLine("++++ Agregar Cliente ++++");

        Cliente cliente = new Cliente();

        Console.Write("Nombre: ");
        cliente.Nombre = Console.ReadLine();

        Console.Write("Apellido: ");
        cliente.Apellido = Console.ReadLine();

        Console.Write("Direcci�n: ");
        cliente.Direccion = Console.ReadLine();

        Console.Write("Tel�fono: ");
        cliente.Telefono = Console.ReadLine();

        Console.Write("Fecha de Nacimiento (yyyy-mm-dd): ");
        cliente.FechaNacimiento = DateTime.Parse(Console.ReadLine());

        Console.Write("Estado: ");
        cliente.Estado = Console.ReadLine()[0];

        using (var context = new AplicationDbContext())
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();

            Console.WriteLine("El cliente ha sido agregado.");
        }
    }

    // Consultar cliente 
    public static void ConsultarCliente()
    {
        Console.WriteLine("++++ Consultar Cliente ++++");
        Console.Write("Ingrese el Id del cliente: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Cliente cliente = context.Clientes.Find(id);

            if (cliente != null)
            {
                var table = new ConsoleTable("Id", "Nombre", "Apellido", "Direcci�n", "Tel�fono", "Fecha de Nacimiento", "Estado");
                table.AddRow(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.Direccion, cliente.Telefono, cliente.FechaNacimiento.ToShortDateString(), cliente.Estado);
                Console.WriteLine();
                table.Write(Format.Alternative);
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }

    // Modificar cliente
    public static void ModificarCliente()
    {
        Console.WriteLine("++++ Modificar Cliente ++++");
        Console.Write("Ingrese el Id del cliente a modificar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Cliente cliente = context.Clientes.Find(id);

            if (cliente != null)
            {
                var table = new ConsoleTable("Id", "Nombre", "Apellido", "Direcci�n", "Tel�fono", "Fecha de Nacimiento", "Estado");
                table.AddRow(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.Direccion, cliente.Telefono, cliente.FechaNacimiento.ToShortDateString(), cliente.Estado);
                Console.WriteLine();
                table.Write(Format.Alternative);


                Console.Write("Nuevo nombre: ");
                string nuevoNombre = Console.ReadLine();
                cliente.Nombre = string.IsNullOrEmpty(nuevoNombre) ? cliente.Nombre : nuevoNombre;

                Console.Write("Nuevo apellido: ");
                string nuevoApellido = Console.ReadLine();
                cliente.Apellido = string.IsNullOrEmpty(nuevoApellido) ? cliente.Apellido : nuevoApellido;

                Console.Write("Nueva direcci�n: ");
                string nuevaDireccion = Console.ReadLine();
                cliente.Direccion = string.IsNullOrEmpty(nuevaDireccion) ? cliente.Direccion : nuevaDireccion;

                Console.Write("Nuevo tel�fono: ");
                string nuevoTelefono = Console.ReadLine();
                cliente.Telefono = string.IsNullOrEmpty(nuevoTelefono) ? cliente.Telefono : nuevoTelefono;

                Console.Write("Nueva fecha de nacimiento (yyyy-mm-dd): ");
                string nuevaFechaNacimientoStr = Console.ReadLine();
                DateTime nuevaFechaNacimiento;
                if (DateTime.TryParse(nuevaFechaNacimientoStr, out nuevaFechaNacimiento))
                {
                    cliente.FechaNacimiento = nuevaFechaNacimiento;
                }

                Console.Write("Nuevo estado: ");
                string nuevoEstado = Console.ReadLine();
                cliente.Estado = string.IsNullOrEmpty(nuevoEstado) ? cliente.Estado : nuevoEstado[0];

                context.SaveChanges();

                Console.WriteLine("Cliente modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }


    // Eliminar cliente
    public static void EliminarCliente()
    {
        Console.WriteLine("++++ Eliminar Cliente ++++");
        Console.Write("Ingrese el Id del cliente a eliminar: ");
        int id = int.Parse(Console.ReadLine());

        using (var context = new AplicationDbContext())
        {
            Cliente cliente = context.Clientes.Find(id);

            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();

                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }
    }
}