using CapaAccesoADatos;
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
namespace CapaLogicaNegocio
{
    public class PedidosN
    {
        // Metodo para validar si el Pedido ya esta registrado
        public bool ValidarIDPedido(Pedidos pEntidad)
        {
            bool resultado = false;
            Pedidos[] arreglo = PedidosAD.ObtenerPedidos();// arreglo que contiene los pedidos registrados

            // recorrido del arreglo
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] != null && arreglo[i].NumeroPedido == pEntidad.NumeroPedido)// se verifica si el pedido ya existe
                {
                    resultado = true;// si existe se cambia el valor de resultado a true
                    break;
                }
            }
            // si el pedido ya esta registrado se retorna false
            if (resultado)
            {
                return false;
            }
            // se guarda el pedido si no esta registrado
            else
            {
                return PedidosAD.AgregarPedidos(pEntidad);
            }
        }
        // Metodo para obtener los pedidos registrados
        public Pedidos[] ObtenerPedidos()
        {
            return PedidosAD.ObtenerPedidos();
        }
        // Metodo para validar la fecha de entrega del pedido
        public bool ValidarFechaPedido(DateTime fechaEntrega)
        {
            DateTime hoy = DateTime.Now;
            return fechaEntrega > hoy;
        }
    }
}
