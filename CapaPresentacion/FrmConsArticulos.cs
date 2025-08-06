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
    public partial class FrmConsArticulos : Form
    {
        ArticulosN articulosN = new ArticulosN();
        public FrmConsArticulos()
        {
            InitializeComponent();
        }

        private void FrmConsArticulos_Load(object sender, EventArgs e)
        {
            CargarColumasYFilas();//metodo para cargar las columnas y filas del DataGridView
            CargarDatosDGV();//metodo para cargar los datos del DataGridView
        }
        private void CargarColumasYFilas()
        { 
            // Método para cargar las columnas y filas del DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            ArticulosN articulosN = new ArticulosN();
            DgvConsulta.DataSource = null;
            DgvConsulta.Rows.Clear();
            DgvConsulta.Columns.Clear();

            //Definicion de la columna y celda ID
            DataGridViewColumn NuevaColumna = new DataGridViewColumn();
            DataGridViewCell NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "ID";
            NuevaColumna.Name = "ID";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            //definicion de la columna y celda Nombre
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Nombre";
            NuevaColumna.Name = "Nombre";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Tipo Articulo";
            NuevaColumna.Name = "Tipo Articulo";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            //definicion de la columna y celda Valor
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Valor";
            NuevaColumna.Name = "Valor";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            //definicion de la columna y celda Inventario
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Inventario";
            NuevaColumna.Name = "Inventario";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            //definicion de la columna y celda Activo
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Activo";
            NuevaColumna.Name = "Activo";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;
            // Agregar la columna al DataGridView
            DgvConsulta.Columns.Add(NuevaColumna);
        }
        //metodo para cargar los datos a DGV
        private void CargarDatosDGV()
        {
            // Método para cargar los datos del DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            Articulos[] arregloArticulos = articulosN.ObtenerArticulos();

            if (arregloArticulos != null && arregloArticulos.Count() > 0)
            {
                foreach (var arregloArticulo in arregloArticulos)
                {
                    if (arregloArticulos != null)
                    {
                        DataGridViewRow Row = (DataGridViewRow)DgvConsulta.Rows[0].Clone();
                        Row.CreateCells(DgvConsulta);
                        Row.Cells[0].Value = arregloArticulo.Id;
                        Row.Cells[1].Value = arregloArticulo.Nombre;
                        Row.Cells[2].Value = arregloArticulo.TiposArticulos.Nombre;
                        Row.Cells[3].Value = arregloArticulo.Valor;
                        Row.Cells[4].Value = arregloArticulo.Inventario;
                        Row.Cells[5].Value = arregloArticulo.Activo;

                        DgvConsulta.Rows.Add(Row);
                    }
                }
            }
        }

        // Botón para regresar al menú principal
        private void BttMenu_Click_1(object sender, EventArgs e)
        {
            MenuPrincipal Ventana = new MenuPrincipal();
            Ventana.Show();
            this.Hide();
        }
    }

    }


