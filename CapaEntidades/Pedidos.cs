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
    //Clase con los atributos de los pedidos
    public class Pedidos
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public Clientes clientes { get; set; }
        public Repartidores repartidores { get; set; }
        public string Direccion { get; set; }

        //Constructor de la clase Pedidos
        public Pedidos() { }
        public Pedidos(int numeroPedido, DateTime fechaPedido, Clientes clientes, Repartidores repartidores, string direccion)
        {
            NumeroPedido = numeroPedido;
            FechaPedido = fechaPedido;
            this.clientes = clientes;
            this.repartidores = repartidores;
            Direccion = direccion;
        }
        public override string ToString()
        {
            return $"Pedido #{NumeroPedido} - Cliente: {clientes.Nombre} {clientes.PrimerApellido} - Repartidor: {repartidores.Nombre} {repartidores.PrimerApellido} - Fecha: {FechaPedido.ToShortDateString()} - Dirección: {Direccion}";
        }
    }
}
