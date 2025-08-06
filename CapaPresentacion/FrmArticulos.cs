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
    public partial class FrmArticulos : Form
    {
        // Declaración de las instancias de las clases de la capa lógica de negocio
        private ArticulosN articulosN = new ArticulosN();
        private TiposArticulosN tiposArticulosN = new TiposArticulosN();

        public FrmArticulos()
        {
            InitializeComponent();
        }
#region Botones(menu ,guardar)
        //boton para regresar al menu principal
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal ventana = new MenuPrincipal();
            ventana.Show();
            this.Hide();
        }
        //boton para guardar el articulo
        private void BttGuardar_Click(object sender, EventArgs e)
        {
            // Validación de los campos de entrada
            Articulos Validacion =ValidacionCampos();
            if (Validacion == null)
            {
                return;
            }

            // Si la validación es exitosa, se procede a guardar el artículo
            bool Validar = articulosN.ValidarArticulo(Validacion);

            if (Validar)
            {
                MessageBox.Show("Tipo de artículo agregado correctamente");
                LimpiarCampos();//llamado de la funcion para limpiar los campos
            }
            // Si el artículo ya existe, se muestra un mensaje de error
            else
            {
                MessageBox.Show("Error:ID debe de ser Unico");
            }
        }
#endregion
#region Validaciones

        //Metodo para validar los campos ingresados por el usuario
        private Articulos ValidacionCampos()
        {
            try
            {
                // Validar ID
                //idea de validacion sacada de: https://stackoverflow.com/questions/1752499/c-sharp-testing-to-see-if-a-string-is-an-integer
                if (!int.TryParse(TxtID.Text.Trim(), out int id))
                    throw new Exception("ID Incorrecto (El ID del articulo debe de ser Numeral)...");

                // Validar nombre
                string nombre = TxtNombre.Text.Trim();
                if (string.IsNullOrWhiteSpace(nombre))
                    throw new Exception("Debe de digitar un nombre para el articulo...");

                // Validar valor
                if (!double.TryParse(TxtValor.Text.Trim(), out double valor))
                    throw new Exception("El valor del articulo debe de ser numeral...");

                // Validar inventario
                if (!int.TryParse(TxtInventario.Text.Trim(), out int inventario))
                    throw new Exception("El inventario del articulo debe de ser numeral...");

                // Validar tipo de artículo
                if (CmbTipoArticulo.SelectedItem == null)
                    throw new Exception("Debe seleccionar un tipo de artículo para registrar el articulo...");

                TiposArticulos tipo = (TiposArticulos)CmbTipoArticulo.SelectedItem;

                // Validar estado activo
                if (CmbActivo.SelectedItem == null)
                    throw new Exception("Debe seleccionar si el artículo está activo o no...");

                bool activo = CmbActivo.SelectedItem.ToString() == "Si";

                // Se retorna el nuevo objeto Articulos con los datos validados
                return new Articulos(id, nombre, tipo, valor, inventario, activo);
            }
            catch (Exception ex)
            {
                // Muestra el mensaje de error personalizado 
                //mensaje de error sacado de: https://stackoverflow.com/questions/2109441/how-to-show-a-custom-error-or-warning-message-box-in-net-winforms
                MessageBox.Show("Error: " + ex.Message, "Error Critico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
#endregion
        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            //cargar combobox 
            //idea sacada de la tutoria del tutor Johan Acosta :
            //https://www.youtube.com/watch?v=2IWiBqwDgKM

            TiposArticulos[] ArregloTiposArticulos = tiposArticulosN.ObtenerTiposArticulos();//se obtienen los TiposArticulos
            CmbTipoArticulo.Items.Clear();
            CmbTipoArticulo.DisplayMember = "Nombre";
            CmbTipoArticulo.ValueMember = "Id";

            //Se recorre el arreglo
            for (int i = 0;i< ArregloTiposArticulos.Length; i++)
            {
                if (ArregloTiposArticulos[i] != null)
                {
                    CmbTipoArticulo.Items.Add(ArregloTiposArticulos[i]);//se agregan los datos
                    
                }
            }
            //Se selecciona por defecto el Index 0
            if (CmbTipoArticulo.Items.Count > 0)
            {
                CmbTipoArticulo.SelectedIndex = 0; 
            }
           //combobox de activo
            CmbActivo.Items.Add("Si");
            CmbActivo.Items.Add("No");
            CmbActivo.SelectedIndex = 0;

        }
        //metodo para limpiar los campos
        private void LimpiarCampos()
        {
            TxtID.Clear();
            TxtNombre.Clear();
            TxtValor.Clear();
            TxtInventario.Clear();
            CmbTipoArticulo.SelectedIndex = 0;
            CmbActivo.SelectedIndex = 0;
        }
    }
}
