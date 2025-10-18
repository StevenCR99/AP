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
        static void Main(string[] args
            {

        }

    }