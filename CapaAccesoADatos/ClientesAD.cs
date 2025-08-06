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
    public static class ClientesAD
    {
        private static Clientes[] ArregloClientes = new Clientes[20];
        private static int contador = 0;

        public static bool AgregarClientes(Clientes clientes)
        {
            ArregloClientes[contador] = clientes;
            contador++;
            return true;
        }
        public static Clientes[] ObtenerClientes()
        {
            Clientes[] ArregloClientesA = new Clientes[contador];
            for (int i = 0; i < contador; i++)
            {
                ArregloClientesA[i] = ArregloClientes[i];
            }
            return ArregloClientesA;
        }
    }
}
