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
    public static class DetallesAD
    {
        private static DetallesPedido[] ArregloDetallesPedido = new DetallesPedido[20];
        private static int contador = 0;

        public static bool AgregarDetalles(DetallesPedido detallesPedido)
        {
            ArregloDetallesPedido[contador] = detallesPedido;
            contador++;
            return true;
        }
        public static DetallesPedido[] ObtenerDetallesPedidos()
        {
            DetallesPedido[] ArregloDetallesPedidoA = new DetallesPedido[contador];
            for (int i = 0; i < contador; i++)
            {
                ArregloDetallesPedidoA[i] = ArregloDetallesPedido[i];
            }
            return ArregloDetallesPedidoA;
        }
    }
}
