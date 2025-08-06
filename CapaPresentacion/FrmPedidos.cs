using CapaAccesoADatos;
using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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
    public partial class FrmPedidos : Form
    {
        private PedidosN PedidosN = new PedidosN();
        private ClientesN ClientesN = new ClientesN();
        private RepartidoresN RepartidoresN = new RepartidoresN();
        private int NumeroPedido = 0;
        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal ventana = new MenuPrincipal();
            ventana.Show();
            this.Hide();
        }

        private void BttGuardar_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = ValidarCampos();
            if (pedidos == null)
            {
                return; // Si la validación falla, se sale del método
            }


            bool ValidarID = PedidosN.ValidarIDPedido(pedidos);

            if (ValidarID)
            {
                MessageBox.Show("Pedido Guardado correctamente");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error: El numero de pedido debe de ser Unico");
                return;
            }

            FrmDetallescs ventana = new FrmDetallescs(NumeroPedido);
            ventana.Show();
            this.Hide();
        }
        //odo para validar los campos ingresados por el usuario
        private Pedidos ValidarCampos()
        {
            try
            {
                //validar nuemero de pedido
                if (!int.TryParse(TxtNumeroPedido.Text.Trim(), out int id))
                {
                    throw new Exception("El numero de pedido debe de ser numeral");
                }
                //validar direccion
                if (string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
                {
                    throw new Exception("Debe digitar la dirección del pedido");
                }

                //validar cliente
                if (CmbCliente.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un cliente");
                }
                //validar repartidor
                if (CmbRepartidor.SelectedItem == null)
                {
                    throw new Exception("Debe seleccionar un repartidor");
                }

                //validar fecha del pedido
                DateTime fechaPedido = DtpFechaPedido.Value;

                bool ValidarFecha = PedidosN.ValidarFechaPedido(fechaPedido);
                if (!ValidarFecha)
                {
                    throw new Exception("La fecha del pedido no puede ser anterior a la fecha actual");

                }
                // Crear un nuevo objeto Pedidos con los datos validados
                NumeroPedido = id;
                return new Pedidos(id, fechaPedido, (Clientes)CmbCliente.SelectedItem, (Repartidores)CmbRepartidor.SelectedItem, TxtDireccion.Text.Trim());
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error personalizado 
                //mensaje de error sacado de: https://stackoverflow.com/questions/2109441/how-to-show-a-custom-error-or-warning-message-box-in-net-winforms
                MessageBox.Show("Error: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        //metodo para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            TxtNumeroPedido.Clear();
            CmbCliente.SelectedIndex = -1;
            CmbRepartidor.SelectedIndex = -1;
            TxtDireccion.Clear();
            DtpFechaPedido.Value = DateTime.Now;

        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            //cargar combobox 
            //idea sacada de la tutoria del tutor Johan Acosta :
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            Clientes[] ArregloClientes = ClientesN.ObtenerClientes();
            CmbCliente.Items.Clear();
            CmbCliente.DisplayMember = "Nombre";
            CmbCliente.ValueMember = "Id";
            //recorrer el arreglo de clientes y agregar al combobox
            for (int i = 0; i < ArregloClientes.Length; i++)
            {
                if (ArregloClientes[i] != null)
                {
                    CmbCliente.Items.Add(ArregloClientes[i]);
                }
            }
            // Si hay elementos en el combobox, seleccionar el primero
            if (CmbCliente.Items.Count > 0)
            {
                CmbCliente.SelectedIndex = 0;
            }

            //llenar combobox Repartidores
            Repartidores[] ArregloRepartidores = RepartidoresN.ObtenerRepartidores();
            CmbRepartidor.Items.Clear();
            CmbRepartidor.DisplayMember = "Nombre";
            CmbRepartidor.ValueMember = "Id";
            //recorrer el arreglo de repartidores y agregar al combobox
            for (int i = 0; i < ArregloRepartidores.Length; i++)
            {
                if (ArregloRepartidores[i] != null)
                {
                    CmbRepartidor.Items.Add(ArregloRepartidores[i]);
                }
            }
            // Si hay elementos en el combobox, seleccionar el primero
            if (CmbRepartidor.Items.Count > 0)
            {
                CmbRepartidor.SelectedIndex = 0;
            }
        }
    }
}


