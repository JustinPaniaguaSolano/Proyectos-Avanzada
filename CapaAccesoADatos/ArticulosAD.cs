using CapaEntidades;
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
namespace CapaAccesoADatos
{
    public static class ArticulosAD
    {
        private static Articulos[] ArregloArticulos = new Articulos[20];
        private static int contador = 0;

        public static bool AgregarArticulo(Articulos articulos)
        {

            ArregloArticulos[contador] = articulos;
            contador++;
            return true;
        }
        public static Articulos[] ObtenerArticulos()
        {
            Articulos[] ArregloArticulosA = new Articulos[contador];
            for (int i = 0; i < contador; i++)
            {
                ArregloArticulosA[i] = ArregloArticulos[i];
            }
            return ArregloArticulosA;
           
        }
    }
}
