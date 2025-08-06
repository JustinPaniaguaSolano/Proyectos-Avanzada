using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocio;
namespace CapaPresentacion
/*
       UNED SEGUNDO CUATRIMESTRE 2025
   PROYECTO 1:Aplicacion de escritorio para la gestion de articulos de la empresa Entregas S.A
Estudiante:Justin Paniagua Solano
Cedula:305530632
Fecha :15/6/2025
*/
{
    public partial class FrmTiposArticulos : Form
    {
        private TiposArticulosN tiposArticulosN = new TiposArticulosN();

        public FrmTiposArticulos()
        {
            InitializeComponent();
        }
        //boton guardar
        private void BttGuardar_Click(object sender, EventArgs e)
        {
            // Llama al método ValidarCampos para validar los campos del formulario
            TiposArticulos tiposArticulos = ValidarCampos();
            if (tiposArticulos == null)
              {
                return; 
              }
            //validar el id del tipo de articulo
            bool Validar = tiposArticulosN.ValidarTipoArticulo(tiposArticulos);

            if (Validar)
            {
                MessageBox.Show("Tipo de artículo agregado correctamente");
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error:ID debe de ser Unico");
            }
        }
        // Método para validar los campos ingresados por el usuario
        private TiposArticulos ValidarCampos()
        {
            try
            {
                // Validar ID
                if (!int.TryParse(TxtID.Text.Trim(), out int id))
                {
                    throw new Exception("El ID del tipos articulo debe de ser numeral");
                }

                // Validar Nombre
                string nombre = TxtNombre.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    throw new Exception("El Nombre del tipo de articulo es obligatorio");
                }

                // Validar Descripción
                string descripcion = TxtDescripcion.Text.Trim();
                if (string.IsNullOrEmpty(descripcion))
                {
                    throw new Exception("La Descripción  del tipo de articulo es obligatoria");
                }
                // Crea una nueva instancia de TiposArticulos con los valores validados
                return new TiposArticulos(id, nombre, descripcion);
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
            TxtID.Clear();
            TxtNombre.Clear();
            TxtDescripcion.Clear();
        }
        //boton menu
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal ventana=new MenuPrincipal();
            ventana.Show();
            this.Hide();
        }
    }
}
