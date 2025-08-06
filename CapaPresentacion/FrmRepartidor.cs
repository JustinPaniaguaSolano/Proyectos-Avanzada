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
    public partial class FrmRepartidor : Form
    {
        private RepartidoresN repartidoresN = new RepartidoresN();
        public FrmRepartidor()
        {
            InitializeComponent();
        }

        //Boton menu 
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal ventana = new MenuPrincipal();
            ventana.Show();
            this.Hide();
        }
        //boton guardar
        private void BttGuardar_Click(object sender, EventArgs e)
        {
            // Llama al método ValidarCampos para validar los campos del formulario
            Repartidores repartidores = ValidarCampos();
            // Si la validación falla, repartidores será null
            if (repartidores == null)
            {
                return; // Si la validación falla, se sale del método
            }

            // Llama al método ValidarIdRepartidor para verificar si el repartidor ya está registrado   
            bool Validar = repartidoresN.ValidarIdRepartidor(repartidores);
            //Si se guarda correctamente, Validar será true
            if (Validar)
            {
                MessageBox.Show("Repartidor Guardado correctamente");
                LimpiarCampos();
            }
            //En caso contrario, se muestra un mensaje de error
            else
            {
                MessageBox.Show("Error:ID debe de ser Unico");
            }
        }
        // Método para validar los campos ingresados por el usuario
        private Repartidores ValidarCampos()
        {
            try
            {
                // Validar número de identificación
                if (!int.TryParse(TxtIdentificacion.Text.Trim(), out int id))
                {
                    throw new Exception("El numero de identificacion debe de ser numeral");
                }
                
                //validar nombre repartidor
                string nombre = TxtNombre.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                    {
                    throw new Exception("El nombre del repartidor no puede estar vacio...");
                }

                //validar primer apellido
                string PriApellido = TxtPriApelli.Text.Trim();
                if (string.IsNullOrEmpty(PriApellido))
                {
                    throw new Exception("El primer apellido del repartidor no puede estar vacio...");
                }

                //validar segundo apellido
                string SegApellido = TxtSegApellido.Text.Trim();
                if (string.IsNullOrEmpty(SegApellido))
                {
                    throw new Exception("El segundo apellido del repartidor no puede estar vacio....");
                }
                //validar que sea mayor de edad
                DateTime fechaNaci = DtpFechNaci.Value;
                if (!repartidoresN.ValidarEdad(fechaNaci))
                {
                    throw new Exception("El repartidor debe de ser mayor de edad");
                }
                //validar fecha de contratacion no sea futura
                DateTime fechaContr = DtpFecCont.Value;
                if (!repartidoresN.ValidarFechaContratacion(fechaContr))
                {
                    throw new Exception("La fecha de contratacion no puede ser futura");
                }

                bool activo = CmbActivo.SelectedItem.ToString() == "Si";

                // Crear un nuevo objeto Repartidores con los datos validados
                return new Repartidores(id, nombre, PriApellido, SegApellido, fechaNaci,fechaContr,activo);
            }

            catch (Exception ex)
            {
                // Muestra el mensaje de error personalizado 
                //mensaje de error sacado de: https://stackoverflow.com/questions/2109441/how-to-show-a-custom-error-or-warning-message-box-in-net-winforms
                MessageBox.Show("Error: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            TxtIdentificacion.Clear();
            TxtNombre.Clear();
            TxtPriApelli.Clear();
            TxtSegApellido.Clear();
            DtpFechNaci.Value = DateTime.Now;
            DtpFecCont.Value = DateTime.Now;
            CmbActivo.SelectedIndex = 0;
        }

        private void FrmRepartidor_Load(object sender, EventArgs e)
        {
            // Inicializa el ComboBox CmbActivo con las opciones "Si" y "No"
            CmbActivo.Items.Add("Si");
            CmbActivo.Items.Add("No");
            CmbActivo.SelectedIndex = 0;
        }
    }
}
