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
    public class ArticulosN
    {
    //Metodo para validar si el Articulo ya esta registrado
        public bool ValidarArticulo(Articulos pEntidad)
        {
            bool resultado = false;
            Articulos[] arreglo = ArticulosAD.ObtenerArticulos();//arreglo que contiene los articulos registrados

            //recorrido del arreglo
            for (int i = 0; i < arreglo.Length; i++)
            {
                if (arreglo[i] != null && arreglo[i].Id == pEntidad.Id)
                {
                    resultado = true;//existe el articulo
                    break;
                }
            }
            //si el articulo ya esta registrado se retorna false    
            if (resultado)
            {
                return false;
            }
            //se guarda el articulo si no esta registrado
            else
            {
                return ArticulosAD.AgregarArticulo(pEntidad);
            }
        }
        //Metodo para obtener los articulos registrados
        public Articulos[] ObtenerArticulos()
        {
            return ArticulosAD.ObtenerArticulos();

        }
        //metodo para buscar un articulo por su id
        public Articulos BuscarTipoArticulo(int id)
        {
            var arreglo = ObtenerArticulos();//se obtiene el arreglo de articulos registrados
            if (arreglo == null) return null;//si el arreglo es nulo se retorna null
            //se recorre el arreglo para buscar el articulo por su id
            for (int i = 0; i < arreglo.Length; i++)
            {
                var art = arreglo[i];
                if (art != null && art.Id == id)
                    return art;
            }
            return null;
        }

        //Metodo para restar cantidad de un articulo
        public bool RestarCantidad(int id, int cantidad)
        {
            Articulos[] articulos=ArticulosAD.ObtenerArticulos();//obtenemos el arreglo de articulos registrados
            //recorremos el arreglo para buscar el articulo por su id
            for (int i = 0; i < articulos.Length; i++)
            {
                if (articulos[i] != null && articulos[i].Id == id)
                {
                    if (articulos[i].Inventario >= cantidad)
                    {
                        articulos[i].Inventario -= cantidad; // Restar la cantidad del inventario
                        return true; //Correcto
                    }
                    else
                    {
                        return false; // No hay suficiente inventario
                    }
                }
            }
            return false; // Artículo no encontrado
        }
    }
}
