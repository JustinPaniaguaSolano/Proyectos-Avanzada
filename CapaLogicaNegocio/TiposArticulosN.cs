using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoADatos;
namespace CapaLogicaNegocio
/*
   UNED SEGUNDO CUATRIMESTRE 2025
   PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
   Estudiante:Justin Paniagua Solano
   Cedula:305530632
   Fecha :15/6/2025
   */
{
    public class TiposArticulosN
    {
        // Metodo para validar si el Tipo de Articulo ya esta registrado
        public bool ValidarTipoArticulo(TiposArticulos pEntidad)
        {
            bool resultado = false;
            TiposArticulos[] arreglo = TiposArticulosAD.ObtenerTiposArticulos();

            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] != null && arreglo[i].Id == pEntidad.Id)
                {
                    resultado = true;
                    break;
                }
            }
            if (resultado)
            {
                return false;
            }
            else
            {
                return TiposArticulosAD.AgregarTipoArticulo(pEntidad);
            }
        }
        // Metodo para obtener los tipos de articulos registrados
        public TiposArticulos[] ObtenerTiposArticulos()
        {
            return TiposArticulosAD.ObtenerTiposArticulos();
        }
    }
}
