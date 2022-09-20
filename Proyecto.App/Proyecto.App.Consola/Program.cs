using System;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.Consola
{
    class Program
    {
        private static IRepositorioCliente _repositorioCliente = new RepositorioCliente(new Persistencia.ApplicationContext());
        
        static void Main(string[] args)
        {
            // Elegir una opción entre Cliente y Caso
            Console.WriteLine("1. Cliente");
            Console.WriteLine("2. Caso");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    OpcionesCliente();
                    break;
                case 2:
                    OpcionesCaso();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        public static void OpcionesCaso(){
            // Elegir una opción entre Agregar
            Console.WriteLine("1. Agregar");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        public static void OpcionesCliente(){
            // Menu para elegir opción de CRUD con la entidad cliente

            Console.WriteLine("1. Agregar cliente");
            Console.WriteLine("2. Eliminar cliente");
            Console.WriteLine("3. Modificar cliente");
            Console.WriteLine("4. Obtener cliente");
            Console.WriteLine("5. Obtener todos los clientes");

            Console.WriteLine("Escriba una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarCliente();
                    break;
                case "2":
                    EliminarCliente();
                    break;
                case "3":
                    ModificarCliente();
                    break;
                case "4":
                    ObtenerCliente();
                    break;
                case "5":
                    ObtenerTodosClientes();
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        public static void AgregarCliente(){
            Cliente cliente = new Cliente();

            Console.WriteLine("Escriba el nombre del cliente: ");
            cliente.nombre = Console.ReadLine();
            Console.WriteLine("Escriba el apellido del cliente: ");
            cliente.apellido = Console.ReadLine();
            Console.WriteLine("Escriba la edad del cliente: ");
            cliente.edad = int.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el genero del cliente (0 Masculino, 1 Femenino): ");
            cliente.genero = (Genero)Enum.Parse(typeof(Genero), Console.ReadLine());

            _repositorioCliente.Agregar(cliente);

        }

        public static void EliminarCliente(){
            // pedir un id de cliente a eliminar
            Console.WriteLine("Escriba el id del cliente a eliminar: ");
            var id = int.Parse(Console.ReadLine());
            _repositorioCliente.Eliminar(id);
        }

        public static void ModificarCliente(){
            // Pedir un id de cliente a modificar
            Console.WriteLine("Escriba el id del cliente a modificar: ");
            var id = int.Parse(Console.ReadLine());
            
            Cliente cliente = _repositorioCliente.ObtenerPorId(id);
            // Pedir los nuevos datos del cliente
            Console.WriteLine("Escriba el nuevo nombre: ");
            cliente.nombre = Console.ReadLine();
            Console.WriteLine("Escriba el nuevo apellido: ");
            cliente.apellido = Console.ReadLine();
            Console.WriteLine("Escriba el nuevo genero: ");
            cliente.genero = (Genero)Enum.Parse(typeof(Genero), Console.ReadLine());
            Console.WriteLine("Escriba la nueva edad: ");
            cliente.edad = int.Parse(Console.ReadLine());

            _repositorioCliente.Modificar(cliente);
        }

        public static void ObtenerCliente(){
            // Pedir un id de cliente a obtener
            Console.WriteLine("Escriba el id del cliente a obtener: ");
            var id = int.Parse(Console.ReadLine());
            
            Cliente cliente = _repositorioCliente.ObtenerPorId(id);
            Console.WriteLine($"{cliente.nombre} {cliente.apellido} {cliente.genero} {cliente.edad}");
        }

        public static void ObtenerTodosClientes(){
            var clientes = _repositorioCliente.ObtenerTodos();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.nombre} {cliente.apellido} {cliente.genero} {cliente.edad}");
            }
        }


        


    }
}