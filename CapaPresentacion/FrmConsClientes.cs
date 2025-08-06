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
    public partial class FrmConsClientes : Form
    {
        ClientesN clientesN = new ClientesN();//Instacion de la clase

        public FrmConsClientes()
        {
            InitializeComponent();
        }

        private void FrmConsClientes_Load(object sender, EventArgs e)
        {
             CargarColumasYFilas();//metodo para cargar las columnas y filas del DataGridView
            CargarDatosDGV();//metodo para cargar los datos del DataGridView
        }

        // Método para cargar las columnas y filas del DataGridView
        private void CargarColumasYFilas()
        {
            // Método para cargar las columnas y filas del DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM

            DgvConsulta.DataSource = null;
            DgvConsulta.Rows.Clear();
            DgvConsulta.Columns.Clear();

            // Definicion de la columna y celda Identificacion
            DataGridViewColumn NuevaColumna = new DataGridViewColumn();
            DataGridViewCell NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Identificacion";
            NuevaColumna.Name = "Identificacion";
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

            // Definicion de la columna y celda Primer Apellido
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Primer Apellido";
            NuevaColumna.Name = "Primer Apellido";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            // Definicion de la columna y celda Segundo Apellido
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Segundo Apellido";
            NuevaColumna.Name = "Segundo Apellido";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            // Definicion de la columna y celda Fecha Nacimiento
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Fecha Nacimiento";
            NuevaColumna.Name = "Fecha Nacimiento";
            NuevaColumna.Visible = true;
            NuevaColumna.Width = 100;

            // Definicion de la columna y celda Activo
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
        // Método para cargar los datos del DataGridView
        private void CargarDatosDGV()
        {
            // Método para cargar los datos del DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            Clientes[] arregloClientes = clientesN.ObtenerClientes();
            if (arregloClientes != null && arregloClientes.Count() > 0)
            {
                foreach (var arreglo in arregloClientes)
                {
                    if (arregloClientes != null)
                    {
                        DataGridViewRow Row = (DataGridViewRow)DgvConsulta.Rows[0].Clone();
                        Row.CreateCells(DgvConsulta);
                        Row.Cells[0].Value = arreglo.Identificacion;
                        Row.Cells[1].Value = arreglo.Nombre;
                        Row.Cells[2].Value = arreglo.PrimerApellido;
                        Row.Cells[3].Value = arreglo.SegundoApellido;
                        //Mostrar la fecha en formato corto
                        //idea sacada de :https://www.geeksforgeeks.org/c-sharp/datetime-toshortdatestring-method-in-c-sharp/
                        Row.Cells[4].Value = arreglo.FechaNacimiento.ToShortDateString();
                        Row.Cells[5].Value = arreglo.Activo;
                        DgvConsulta.Rows.Add(Row);
                    }
                }
            }
        }
        // Botón para regresar al menú principal
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal Ventana = new MenuPrincipal();
            Ventana.Show();
            this.Hide();
        }
    }

}



