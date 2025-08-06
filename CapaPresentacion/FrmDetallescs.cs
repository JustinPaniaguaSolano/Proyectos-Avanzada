using CapaAccesoADatos;
using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
/*
           UNED SEGUNDO CUATRIMESTRE 2025
       PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
    Estudiante:Justin Paniagua Solano
   Cedula:305530632
   Fecha :15/6/2025
   */
namespace CapaPresentacion
{
    public partial class FrmDetallescs : Form
    {
        private int numeroPedido;//instancia del numero de pedido ,pasado en registro de pedidos
        private ArticulosN articuloN = new ArticulosN();//instancia de ArticulosN para obtener los articulos

        private DetallesPedidoN detallesPedidosN = new DetallesPedidoN();
        public FrmDetallescs(int numeroPedido)
        {
            InitializeComponent();
            this.numeroPedido = numeroPedido;
        }
        //boton guardar
        private void BttGuardar_Click(object sender, EventArgs e)
        {
            //verificar la cantidad ingresada
            if (!int.TryParse(TxtCantidad.Text, out int cantidad))
            {
                MessageBox.Show("Error:Digite la cantidad....");
                return;
            }

            Articulos articuloSeleccionado = (Articulos)CmbArticulo.SelectedItem;//obtengo el articulo seleccionado del combobox

        //agregar los datos
            bool agregar = detallesPedidosN.AgregarDetalles(numeroPedido, articuloSeleccionado, cantidad);
            if (agregar)
            {
                MessageBox.Show("Detalles del pedido agregados correctamente");
                LimpiarCampos();
                //se habre el menu principal
                MenuPrincipal ventana = new MenuPrincipal();
                ventana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error al agregar los detalles del pedido. Verifique los datos ingresados.");
            }
        }
        //metodo para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            CmbArticulo.SelectedIndex = 0; // Resetea el combobox al primer elemento
            TxtCantidad.Clear(); // Limpia el campo de cantidad
        }

        private void FrmDetallescs_Load(object sender, EventArgs e)
        {
            LbNumeroPedido.Text = $"Detalles del Pedido N° {numeroPedido}";//mostrar el numero de pedido en el label
            CmbArticulo.Items.Clear();

            var arregloArticulos = articuloN.ObtenerArticulos();
            //recorrer el arreglo de articulos y agregar los articulos al combobox
            for (int i = 0; i < arregloArticulos.Length; i++)
            {
                var art = arregloArticulos[i];       
                if (art != null && art.TiposArticulos != null)
                {
                    CmbArticulo.Items.Add(art);
                }
            }

            CmbArticulo.DisplayMember = "Nombre";
            if (CmbArticulo.Items.Count > 0)
            {
                CmbArticulo.SelectedIndex = 0;
            }
        }
    }
}
