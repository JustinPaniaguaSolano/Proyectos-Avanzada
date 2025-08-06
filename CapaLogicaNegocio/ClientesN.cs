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
    public class ClientesN
    {
        // Metodo para validar si el Cliente ya esta registrado
        public bool ValidarIdCliente(Clientes pEntidad)
        {
            bool resultado = false;
            Clientes[] arreglo = ClientesAD.ObtenerClientes();// arreglo que contiene los clientes registrados
            // recorrido del arreglo
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] != null && arreglo[i].Identificacion == pEntidad.Identificacion)
                {
                    resultado = true;
                    break;
                }
            }
            // si el cliente ya esta registrado se retorna false
            if (resultado)
            {
                return false;
            }
            // se guarda el cliente si no esta registrado
            else
            {
                return ClientesAD.AgregarClientes(pEntidad);
            }
        }
        //metodo para obtener los clientes registrados
        public Clientes[] ObtenerClientes()
        {
            return ClientesAD.ObtenerClientes();
        }
       
    }
}
