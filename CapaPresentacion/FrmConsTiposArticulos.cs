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
    public partial class FrmConsTiposArticulos : Form
    {
        TiposArticulosN tiposArticulosN = new TiposArticulosN();

        public FrmConsTiposArticulos()
        {
            InitializeComponent();
        }

        private void FrmConsTiposArticulos_Load(object sender, EventArgs e)
        {
           CargarColumnasYFilasDGV(); // Cargar las columnas y filas del DataGridView
           CargarDatosDGV(); // Cargar los datos al DataGridView



        }
        private void CargarColumnasYFilasDGV()
        {
            // Método para cargar las columnas y filas del DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            DgvConsulta.DataSource = null;
            DgvConsulta.Rows.Clear();
            DgvConsulta.Columns.Clear();

            // Definicion de la columna y celda ID
            DataGridViewColumn NuevaColumna = new DataGridViewColumn();
            DataGridViewCell NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "ID";
            NuevaColumna.Name = "ID";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            // Definicion de la columna y celda Nombre
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Nombre";
            NuevaColumna.Name = "Nombre";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            // Definicion de la columna y celda Descripcion
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Descripcion";
            NuevaColumna.Name = "Descripcion";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            DgvConsulta.Columns.Add(NuevaColumna);// Añadir la columna  al DataGridView
        }
        private void CargarDatosDGV()
        {
            // Método para cargar los datos del DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            TiposArticulos[] arregloTiposArticulos = tiposArticulosN.ObtenerTiposArticulos();

            if (arregloTiposArticulos != null && arregloTiposArticulos.Count() > 0)
            {
                foreach (var arregloTiposArticulo in arregloTiposArticulos)
                {
                    if (arregloTiposArticulo != null)
                    {
                        DataGridViewRow Row = (DataGridViewRow)DgvConsulta.Rows[0].Clone();
                        Row.CreateCells(DgvConsulta);
                        Row.Cells[0].Value = arregloTiposArticulo.Id;
                        Row.Cells[1].Value = arregloTiposArticulo.Nombre;
                        Row.Cells[2].Value = arregloTiposArticulo.Descripcion;

                        DgvConsulta.Rows.Add(Row);
                    }
                }
            }
        }
        //botón para regresar al menú principal
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal Ventana = new MenuPrincipal();    
            Ventana.Show();
            this.Hide();
        }
    }
}
