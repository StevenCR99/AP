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