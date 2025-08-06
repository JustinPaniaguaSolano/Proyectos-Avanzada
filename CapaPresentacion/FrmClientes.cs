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
/*
           UNED SEGUNDO CUATRIMESTRE 2025
       PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
    Estudiante:Justin Paniagua Solano
   Cedula:305530632
   Fecha :15/6/2025
   */
namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        private ClientesN ClientesN = new ClientesN();
        public FrmClientes()
        {
            InitializeComponent();
        }
        //boton menu principal
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal Ventana = new MenuPrincipal();
            Ventana.Show();
            this.Hide();
        }
        //boton guardar
        private void BttGuardar_Click(object sender, EventArgs e)
        {
            //Llamado de la función de validación de campos
            Clientes clientes = ValidacionCampos();
            if (clientes == null)
                return; // Si la validación falla, se sale del método

            //llamado de la función para validar si el cliente ya existe
            bool Validar = ClientesN.ValidarIdCliente(clientes);
            if (Validar){
                MessageBox.Show("Cliente Guardado correctamente");
                LimpiarCampos();

            } else{
                MessageBox.Show("Error:ID debe de ser Unico");
            }
        }
        //Metodo para validar los campos ingresados por el usuario
        private Clientes ValidacionCampos()
        {
            try
            {
                // Validar identificación
                if (!int.TryParse(TxtIdentificacion.Text.Trim(), out int identificacion))
                    throw new Exception("La identificación del cliente debe de ser numeral...");

                // Validar nombre
                string Nombre = TxtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(Nombre))
                throw new Exception("Debe digitar el nombre...");

                //validar primer apellido
                string PrimerApellido = TxtPrimerApellido.Text.Trim();
                if (string.IsNullOrWhiteSpace(PrimerApellido))
                    throw new Exception("Debe digitar el primer Apellido...");

                // Validar segundo apellido
                string SegundoApellido =TxtSegundoApellido.Text.Trim();
                if (string.IsNullOrWhiteSpace(SegundoApellido))
                    throw new Exception("Debe digitar el Segundo Apellido...");


                DateTime fechaNacimiento = DtpFechaNacimiento.Value;

                // Validar combo activo
                if (CmbActivo.SelectedItem == null)
                    throw new Exception("Debe seleccionar si el cliente está activo o no.");

                bool activo = CmbActivo.SelectedItem.ToString() == "Si";

                // retornar un nuevo objeto Clientes con los datos validados
                return new Clientes(identificacion, Nombre, PrimerApellido, SegundoApellido, fechaNacimiento, activo);
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error personalizado 
                //mensaje de error sacado de: https://stackoverflow.com/questions/2109441/how-to-show-a-custom-error-or-warning-message-box-in-net-winforms
                MessageBox.Show("Error: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //funcion para limpiar los campos
        private void LimpiarCampos()
        {
            TxtIdentificacion.Clear();
            TxtNombre.Clear();
            TxtPrimerApellido.Clear();
            TxtSegundoApellido.Clear();
            DtpFechaNacimiento.Value = DateTime.Now;
            CmbActivo.SelectedIndex =0;
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            // Cargar el CmbActivo con los datos 
            CmbActivo.Items.Add("Si");
            CmbActivo.Items.Add("No");
            CmbActivo.SelectedIndex = 0;
        }
    }
}
