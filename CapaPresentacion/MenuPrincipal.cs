using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
           UNED SEGUNDO CUATRIMESTRE 2025
       PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
    Estudiante:Justin Paniagua Solano
   Cedula:305530632
   Fecha :15/6/2025
   */
namespace CapaPresentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        //boton para ingregsar a registrar tipos de articulo
        private void BttRegistrarTiposArticulos_Click(object sender, EventArgs e)
        {
            FrmTiposArticulos Ventana = new FrmTiposArticulos();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingregsar a registrar articulos
        private void BttRegistrarArticulos_Click(object sender, EventArgs e)
        {
            FrmArticulos Ventana = new FrmArticulos();
            Ventana.Show();
            this.Hide();
        }

        //Boton para ingregar a registrar clientes
        private void BttRegistrarCliente_Click(object sender, EventArgs e)
        {
            FrmClientes Ventana = new FrmClientes();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingregar a registrar repartidores
        private void BttRegistrarRepartidores_Click(object sender, EventArgs e)
        {
            FrmRepartidor Ventana = new FrmRepartidor();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingregar a registrar pedidos   
        private void BttRegistrarPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos Ventana = new FrmPedidos();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingrear a consultar tipos de articulo
        private void BttConsultarTiposArticulos_Click(object sender, EventArgs e)
        {
            FrmConsTiposArticulos Ventana = new FrmConsTiposArticulos();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingregar a consultar articulos
        private void BttConsultarArticulos_Click(object sender, EventArgs e)
        {
            FrmConsArticulos Ventana = new FrmConsArticulos();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingregar a consultar clientes
        private void BttConsultarClientes_Click(object sender, EventArgs e)
        {
            FrmConsClientes Ventana = new FrmConsClientes();
            Ventana.Show();
            this.Hide();
        }

        //boton para ingregar a consultar repartidores
        private void BttConsultarRepartidores_Click(object sender, EventArgs e)
        {
            FrmConsRepartidores ventana = new FrmConsRepartidores();
            ventana.Show();
            this.Hide();
        }

        //boton para ingregar a consultar pedidos
        private void BttConsultarPedidos_Click(object sender, EventArgs e)
        {
            FrmConsPedidosYDetalles ventana = new FrmConsPedidosYDetalles();
            ventana.Show();
            this.Hide();

        }
    }
}
