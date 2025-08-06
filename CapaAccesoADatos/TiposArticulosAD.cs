using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
namespace CapaAccesoADatos
/*
       UNED SEGUNDO CUATRIMESTRE 2025
   PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
Estudiante:Justin Paniagua Solano
Cedula:305530632
Fecha :15/6/2025
*/
{
    public static class TiposArticulosAD
    {
        private static TiposArticulos[] ArregloTiposArticulos= new TiposArticulos[10];
        private static int contador = 0;
          
        public static bool AgregarTipoArticulo(TiposArticulos tipoArticulo)
        {
                ArregloTiposArticulos[contador] = tipoArticulo;
                contador++;
                  return true;
        }
        public static TiposArticulos[] ObtenerTiposArticulos()
        {

            TiposArticulos[] ArregloTiposArticulosA = new TiposArticulos[contador];
            for (int i = 0; i < contador; i++)
            {
                ArregloTiposArticulosA[i] = ArregloTiposArticulos[i];
            }
            return ArregloTiposArticulosA;
        }
    }
}
