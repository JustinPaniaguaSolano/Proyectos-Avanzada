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
    public class PedidosAD
    {
        private static Pedidos[] ArregloPedidos = new Pedidos[40];
        private static int contador = 0;

        public static bool AgregarPedidos(Pedidos pedidos)
        {
            ArregloPedidos[contador] = pedidos;
            contador++;
            return true;
        }
        public static Pedidos[] ObtenerPedidos()
        {
            Pedidos[] ArregloPedidosA = new Pedidos[contador];
            for (int i = 0; i < contador; i++)
            {
                ArregloPedidosA[i] = ArregloPedidos[i];
            }
            return ArregloPedidosA;
        }
    }
    }


