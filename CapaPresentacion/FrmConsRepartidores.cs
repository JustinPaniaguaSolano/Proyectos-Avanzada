﻿using CapaEntidades;
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
    public partial class FrmConsRepartidores : Form
    {
        RepartidoresN repartidoresN = new RepartidoresN();

        public FrmConsRepartidores()
        {
            InitializeComponent();
        }

        private void FrmConsRepartidores_Load(object sender, EventArgs e)
        {
            CargarColumnasYFilasDGV(); // Cargar las columnas y filas del DataGridView
            CargarDatosAlDGV();// Cargar los datos al DataGridView
        }
        private void CargarColumnasYFilasDGV()
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

            // Definicion de la columna y celda Fecha Contratacion
            DgvConsulta.Columns.Add(NuevaColumna);
            NuevaColumna = new DataGridViewColumn();
            NuevaCelda = new DataGridViewTextBoxCell();

            NuevaColumna.CellTemplate = NuevaCelda;
            NuevaColumna.HeaderText = "Fecha Contratacion";
            NuevaColumna.Name = "Fecha Contratacion";
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

            DgvConsulta.Columns.Add(NuevaColumna);// Agregar la columna al DataGridView
        }
        //metodo para cargar los datos al DataGridView
        private void CargarDatosAlDGV()
        {
            // Método para cargar lo datos al  DataGridView
            //Idea sacada de la tutoria de Johan Acosta:
            //https://www.youtube.com/watch?v=2IWiBqwDgKM
            Repartidores[] arregloRepartidores = repartidoresN.ObtenerRepartidores();

            if (arregloRepartidores != null && arregloRepartidores.Count() > 0)
            {
                foreach (var arregloRepartidor in arregloRepartidores)
                {
                    if (arregloRepartidores != null)
                    {
                        DataGridViewRow Row = (DataGridViewRow)DgvConsulta.Rows[0].Clone();
                        Row.CreateCells(DgvConsulta);
                        Row.Cells[0].Value = arregloRepartidor.Identificacion;
                        Row.Cells[1].Value = arregloRepartidor.Nombre;
                        Row.Cells[2].Value = arregloRepartidor.PrimerApellido;
                        Row.Cells[3].Value = arregloRepartidor.SegundoApellido;
                        //Mostrar la fecha en formato corto
                        //idea sacada de :https://www.geeksforgeeks.org/c-sharp/datetime-toshortdatestring-method-in-c-sharp/
                        Row.Cells[4].Value = arregloRepartidor.FechaNacimiento.ToShortDateString();
                        Row.Cells[5].Value = arregloRepartidor.FechaContractacion.ToShortDateString();
                        Row.Cells[6].Value = arregloRepartidor.Activo;


                        DgvConsulta.Rows.Add(Row);


                    }
                }
            }
        }
        // Botón para regresar al menú principal
        private void BttMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipal ventana= new MenuPrincipal(); 
            ventana.Show();
            this.Hide();
        }
    }
}

