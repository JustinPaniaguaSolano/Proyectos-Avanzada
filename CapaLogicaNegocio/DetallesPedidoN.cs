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
    public class DetallesPedidoN
    {
        private ArticulosN articulosN=new ArticulosN();
        // Metodo para agregar detalles del pedido
        public bool AgregarDetalles(int numeroPedido, Articulos articulo, int cantidad)
        {
            //validar que inventario sea suficiente
            if (articulo.Inventario<cantidad)
            {
                return false; // No hay suficiente inventario
            }
            //se actualiza el inventario del articulo
            bool Actulizar =articulosN.RestarCantidad(articulo.Id, cantidad);//se resta la cantidad del inventario del articulo
            if(!Actulizar)
            {
                return false; // No se pudo actualizar el inventario
            }


            double monto = articulo.Valor * cantidad;//se calcula el monto del pedido
            DetallesPedido detalle = new DetallesPedido(numeroPedido, articulo, cantidad);
            detalle.Monto = monto;
            return DetallesAD.AgregarDetalles(detalle);
        }
        // Metodo para validar si el detalle del pedido ya esta registrado
        public DetallesPedido[] ObtenerDetallesPedidos()
        {
        
              return DetallesAD.ObtenerDetallesPedidos();
        }
       
    }
}


