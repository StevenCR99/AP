using System;
using System.Collections.Generic;

namespace AgendaPro
{
    class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

    public Persona(int id, string nombre, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"{Id} - {Nombre} - {Telefono}";
        }
    }

    class Cita
    {
        public int PersonaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Cita(int personaId, DateTime fecha, string descripcion)
        {
            PersonaId = personaId;
            Fecha = fecha;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return $"{PersonaId} | {Fecha:dd/MM/yyyy HH:mm} | {Descripcion}";
        }
    }

    class Program
    {
        static List<Persona> personas = new List<Persona>();
        static List<Cita> citas = new List<Cita>();

        static void Main(string[] args)
        {
            int opcion = 0;

            do
            {
                Console.WriteLine("\n--- Menú AgendaPro ---");
                Console.WriteLine("1. Registrar persona");
                Console.WriteLine("2. Listar personas");
                Console.WriteLine("3. Crear cita");
                Console.WriteLine("4. Listar citas por PersonaId");
                Console.WriteLine("5. Mostrar todas las citas");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                try
                {
                    opcion = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Debe ingresar un número válido.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarPersona();
                        break;
                    case 2:
                        ListarPersonas();
                        break;
                    case 3:
                        CrearCita();
                        break;
                    case 4:
                        ListarCitasPorPersona();
                        break;
                    case 5:
                        ListarTodasLasCitas();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 6);
        }

        static void RegistrarPersona()
        {
            try
            {
                Console.Write("Ingrese Id: ");
                int id = int.Parse(Console.ReadLine());

                if (personas.Exists(p => p.Id == id))
                {
                    Console.WriteLine("Ya existe una persona con ese Id.");
                    return;
                }

                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese teléfono: ");
                string telefono = Console.ReadLine();

                personas.Add(new Persona(id, nombre, telefono));
                Console.WriteLine("Persona registrada correctamente.");
            }
            catch
            {
                Console.WriteLine("Error al registrar persona. Revise los datos ingresados.");
            }
        }

        static void ListarPersonas()
        {
            Console.WriteLine("\n--- Lista de Personas ---");
            if (personas.Count == 0)
            {
                Console.WriteLine("No hay personas registradas.");
                return;
            }

            foreach (var p in personas)
            {
                Console.WriteLine(p);
            }
        }

        static void CrearCita()
        {
            try
            {
                Console.Write("Ingrese PersonaId: ");
                int personaId = int.Parse(Console.ReadLine());

                Persona persona = personas.Find(p => p.Id == personaId);
                if (persona == null)
                {
                    Console.WriteLine("No existe una persona con ese Id.");
                    return;
                }

                Console.Write("Ingrese fecha (dd/MM/yyyy HH:mm): ");
                DateTime fecha = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null);

                Console.Write("Ingrese descripción: ");
                string descripcion = Console.ReadLine();

                citas.Add(new Cita(personaId, fecha, descripcion));
                Console.WriteLine("Cita registrada correctamente.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de fecha o número incorrecto.");
            }
            catch
            {
                Console.WriteLine("Error al crear la cita.");
            }
        }

        static void ListarCitasPorPersona()
        {
            try
            {
                Console.Write("Ingrese PersonaId: ");
                int personaId = int.Parse(Console.ReadLine());

                var citasPersona = citas.FindAll(c => c.PersonaId == personaId);

                if (citasPersona.Count == 0)
                {
                    Console.WriteLine("No hay citas para esta persona.");
                    return;
                }

                Console.WriteLine("\n--- Citas de Persona ---");
                foreach (var c in citasPersona)
                {
                    Console.WriteLine(c);
                }
            }
            catch
            {
                Console.WriteLine("Error al listar citas.");
            }
        }

        static void ListarTodasLasCitas()
        {
            Console.WriteLine("\n--- Todas las Citas ---");
            if (citas.Count == 0)
            {
                Console.WriteLine("No hay citas registradas.");
                return;
            }

            foreach (var c in citas)
            {
                Console.WriteLine(c);
            }
        }
    }
}
