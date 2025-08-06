using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
            UNED SEGUNDO CUATRIMESTRE 2025
        PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
     Estudiante:Justin Paniagua Solano
    Cedula:305530632
    Fecha :15/6/2025
    */
namespace CapaEntidades
{
    //clase con los atributos de los tipos de articulos
    public class TiposArticulos:DatosArticulosHerencia
    {
        public string Descripcion { get; set; }

        public TiposArticulos() { }
        public TiposArticulos(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
