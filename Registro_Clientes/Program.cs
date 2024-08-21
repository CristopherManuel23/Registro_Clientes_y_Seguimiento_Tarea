using System;
using System.Collections.Generic;

namespace Segunda_Practica
{
    class PROGRAM
    {
        static void Main(string[] args)
        {
            // Variable para controlar el bucle principal
            // Esta variable se utiliza para determinar si el programa debe continuar ejecutándose o no
            bool continuar = true;

            do
            {
                // Mostrar menú principal
                // Este menú muestra las opciones disponibles para el usuario
                Console.WriteLine("\n MENU PRINCIPAL: \n");
                Console.WriteLine("\n(1) Sistema de Registro de Clientes " +
                                  "\n(2) Sistema de Seguimiento de Tareas  " +
                                  "\n(3) Cerrar el programa\n");

                // Leer selección del usuario
                // El usuario selecciona una opción del menú principal
                int seleccion = int.Parse(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:
                        // Llamar al sistema de registro de clientes
                        // Esta función permite al usuario registrar clientes
                        SistemaRegistroClientes();
                        break;
                    case 2:
                        // Llamar al sistema de seguimiento de tareas
                        // Esta función permite al usuario registrar y seguir tareas
                        SistemaSeguimientoTareas();
                        break;
                    case 3:
                        // Salir del programa
                        // Si el usuario selecciona esta opción, el programa se cierra
                        continuar = false;
                        Console.WriteLine("Programa cerrado.");
                        break;
                    default:
                        // Mostrar mensaje de error si la selección no es válida
                        // Si el usuario selecciona una opción no válida, se muestra un mensaje de error
                        Console.WriteLine("Selección no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            while (continuar);
        }

        static void SistemaRegistroClientes()
        {
            // Crear lista de clientes
            // Esta lista se utiliza para almacenar los clientes registrados
            List<Cliente> listaClientes = new List<Cliente>();
            bool continuarClientes = true;

            while (continuarClientes)
            {
                // Mostrar menú de registro de clientes
                // Este menú muestra las opciones disponibles para el usuario en el sistema de registro de clientes
                Console.WriteLine("\nSistema de Registro de Clientes:");
                Console.WriteLine("\n(1) Agregar Cliente " +
                                  "\n(2) Mostrar Clientes " +
                                  "\n(3) Volver al menú principal\n");

                // Leer selección del usuario
                // El usuario selecciona una opción del menú de registro de clientes
                int opcionClientes = int.Parse(Console.ReadLine());

                switch (opcionClientes)
                {
                    // Agregar cliente
                    // El usuario ingresa la información del cliente y se agrega a la lista de clientes
                    case 1:
                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la edad del cliente: ");
                        int edad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el correo del cliente: ");
                        string correo = Console.ReadLine();

                        Console.Write("¿El cliente es corporativo? (s/n): ");
                        string esCorporativo = Console.ReadLine().ToLower();

                        if (esCorporativo == "s")
                        {
                            Console.Write("Ingrese el nombre de la empresa: ");
                            string nombreEmpresa = Console.ReadLine();
                            Cliente cliente = new ClienteCorporativo(nombre, edad, correo, nombreEmpresa);
                            listaClientes.Add(cliente);
                        }
                        else
                        {
                            Cliente cliente = new Cliente(nombre, edad, correo);
                            listaClientes.Add(cliente);
                        }

                        Console.WriteLine("Cliente agregado con éxito.");
                        break;

                    // Mostrar lista de clientes
                    // Se muestra la lista de clientes registrados
                    case 2:
                        Console.WriteLine("\nLista de Clientes:");
                        foreach (Cliente cliente in listaClientes)
                        {
                            cliente.MostrarInformacion();
                            Console.WriteLine();
                        }
                        break;

                    // Volver al menú principal
                    // Si el usuario selecciona esta opción, se vuelve al menú principal
                    case 3:
                        continuarClientes = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
        }

        static void SistemaSeguimientoTareas()
        {
            List<Tarea> listaTareas = new List<Tarea>();
            bool continuarTareas = true;

            do
            {
                Console.WriteLine("\nSistema de Seguimiento de Tareas:");
                Console.WriteLine("\n(1) Agregar Tarea " +
                                  "\n(2) Mostrar Tareas " +
                                  "\n(3) Volver al menú principal\n");

                int opcionTareas = int.Parse(Console.ReadLine());

                switch (opcionTareas)
                {
                    case 1:
                        Console.Write("Ingrese el título de la tarea: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Ingrese la fecha límite (dd-mm-aaaa): ");
                        DateTime fechaLimite = DateTime.Parse(Console.ReadLine());

                        Console.Write("¿La tarea es urgente? (s/n): ");
                        string esUrgente = Console.ReadLine().ToLower();

                        if (esUrgente == "s")
                        {
                            Console.Write("Ingrese el nivel de urgencia: ");
                            string nivelUrgencia = Console.ReadLine();
                            Tarea tarea = new TareaUrgente(titulo, descripcion, fechaLimite, nivelUrgencia);
                            listaTareas.Add(tarea);
                        }
                        else
                        {
                            Tarea tarea = new Tarea(titulo, descripcion, fechaLimite);
                            listaTareas.Add(tarea);
                        }

                        Console.WriteLine("Tarea agregada con éxito.");
                        break;
                    case 2:
                        Console.WriteLine("\nLista de Tareas:");
                        foreach (Tarea tarea in listaTareas)
                        {
                            tarea.MostrarDetalles();
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        continuarTareas = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            while (continuarTareas);
        }
    }

    // Clase para representar un cliente
    class Cliente
    {
        private string nombre;
        private int edad;
        private string correo;

        // Constructor de la clase Cliente
        public Cliente(string nombre, int edad, string correo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.correo = correo;
        }

        // Métodos para establecer y obtener el nombre
        public void SetNombre(string nombre) { this.nombre = nombre; }
        public string GetNombre() { return nombre; }

        // Métodos para establecer y obtener la edad
        public void SetEdad(int edad) { this.edad = edad; }
        public int GetEdad() { return edad; }

        // Métodos para establecer y obtener el correo
        public void SetCorreo(string correo) { this.correo = correo; }
        public string GetCorreo() { return correo; }

        // Método virtual para mostrar la información del cliente

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad}, Correo: {correo}");
        }
    }

    // Clase derivada para representar un cliente corporativo
    class ClienteCorporativo : Cliente
    {
        private string nombreEmpresa;

        // Constructor de la clase ClienteCorporativo
        public ClienteCorporativo(string nombre, int edad, string correo, string nombreEmpresa)
            : base(nombre, edad, correo)// Llamada al constructor de la clase base
        {
            this.nombreEmpresa = nombreEmpresa;
        }

        // Métodos para establecer y obtener el nombre de la empresa
        public void SetNombreEmpresa(string nombreEmpresa) { this.nombreEmpresa = nombreEmpresa; }
        public string GetNombreEmpresa() { return nombreEmpresa; }

        // Método sobreescrito para mostrar la información del cliente corporativo
        public override void MostrarInformacion()
        {
            base.MostrarInformacion();// Llamada al método MostrarInformacion de la clase base
            Console.WriteLine($"Nombre de la Empresa: {nombreEmpresa}");
        }
    }

    class Tarea
    {
        private string titulo;
        private string descripcion;
        private DateTime fechaLimite;

        public Tarea(string titulo, string descripcion, DateTime fechaLimite)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fechaLimite = fechaLimite;
        }

        public void SetTitulo(string titulo) { this.titulo = titulo; }
        public string GetTitulo() { return titulo; }

        public void SetDescripcion(string descripcion) { this.descripcion = descripcion; }
        public string GetDescripcion() { return descripcion; }

        public void SetFechaLimite(DateTime fechaLimite) { this.fechaLimite = fechaLimite; }
        public DateTime GetFechaLimite() { return fechaLimite; }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"Título: {titulo}, Descripción: {descripcion}, Fecha Límite: {fechaLimite.ToShortDateString()}");
        }
    }

    class TareaUrgente : Tarea
    {
        private string nivelUrgencia;

        public TareaUrgente(string titulo, string descripcion, DateTime fechaLimite, string nivelUrgencia)
            : base(titulo, descripcion, fechaLimite)
        {
            this.nivelUrgencia = nivelUrgencia;
        }

        public void SetNivelUrgencia(string nivelUrgencia) { this.nivelUrgencia = nivelUrgencia; }
        public string GetNivelUrgencia() { return nivelUrgencia; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Nivel de Urgencia: {nivelUrgencia}");
        }
    }
}

