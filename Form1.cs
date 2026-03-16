using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Examen_Bryan_Mejia
{
    public partial class Form1 : Form
    {
        List<Doctores> doctores = new List<Doctores>();
        List<Pacientes> pacientes = new List<Pacientes>();
        List<Citas> citas = new List<Citas>();
        string docSeleccionado = "";
        string pacienteSeleccionado = "";


        public Form1()
        {
            InitializeComponent();
            CargarDoctoresDesdeArchivo("doctores.txt");
            CargarPacientesArchivo("pacientes.txt");
        }






        private void MostrarDoctores()
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = doctores;
        }

        private void CargarDoctoresDesdeArchivo(string fileName)
        {
            if (File.Exists(fileName))
            {

                doctores.Clear();


                string[] lineas = File.ReadAllLines(fileName);

                foreach (string linea in lineas)
                {

                    string[] datos = linea.Split(',');

                    if (datos.Length == 3)
                    {
                        Doctores doctorCargado = new Doctores();
                        doctorCargado.Nombre = datos[0];
                        doctorCargado.Especialidad = datos[1];
                        doctorCargado.Id = datos[2];

                        doctores.Add(doctorCargado);
                    }
                }


                MostrarDoctores();
            }
        }



        private void Mostrarpaci()
        {

            dataGridView4.DataSource = null;
            dataGridView4.DataSource = pacientes;
        }

        private void CargarPacientesArchivo(string fileName)
        {
            if (File.Exists(fileName))
            {

                pacientes.Clear();


                string[] lineas = File.ReadAllLines(fileName);

                foreach (string linea in lineas)
                {

                    string[] datos = linea.Split(',');

                    if (datos.Length == 3)
                    {
                        Pacientes pacientescargado = new Pacientes();
                        pacientescargado.Dpi = datos[0];
                        pacientescargado.Nombre = datos[1];
                        pacientescargado.Telefono = datos[2];

                        pacientes.Add(pacientescargado);
                    }
                }


                Mostrarpaci();
            }
        }





        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                
                Doctores doctores = (Doctores)dataGridView1.CurrentRow.DataBoundItem;
                docSeleccionado = doctores.Nombre;

               
                labeldoc.Text = "Doctor Seleccionado: " + docSeleccionado;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow != null)
            {

                Pacientes pacientes = (Pacientes)dataGridView4.CurrentRow.DataBoundItem;
                pacienteSeleccionado = pacientes.Nombre;


                Paci.Text = "Paciente Seleccionado: " + pacienteSeleccionado;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(pacienteSeleccionado) && !string.IsNullOrEmpty(docSeleccionado))
            {
                Citas nuevacita = new Citas();
                nuevacita.Idpaciente = pacienteSeleccionado;
                nuevacita.Iddoc = docSeleccionado;
                nuevacita.Fecha = dateTimePicker1.Value;

                citas.Add(nuevacita);

                
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = citas;

                MessageBox.Show("¡Cita realizada con éxito!");

               
                pacienteSeleccionado = "";
                docSeleccionado = "";
                labeldoc.Text = "Doctor seleccionado:";
                Paci.Text = "Paciente Seleccionado:";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona primero un Doctor y un Paciente.");
            }
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            if (citas == null || citas.Count == 0)
            {
                MessageBox.Show("No hay citas para ordenar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
            citas = citas.OrderByDescending(c => c.Fecha).ToList();

            
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = citas;
        }
    }
    
}
