using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace actividad5
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("server=DESKTOP-4UL2PG6 ; database=db_actividad5 ; integrated security = true");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

            if (string.IsNullOrEmpty(txt_nombre.Text) || string.IsNullOrEmpty(txt_apellido.Text) ||
                string.IsNullOrEmpty(txt_num.Text) || string.IsNullOrEmpty(txt_sexo.Text) ||
                string.IsNullOrEmpty(txt_pais.Text) || string.IsNullOrEmpty(txt_edad.Text) ||
                string.IsNullOrEmpty(txt_telefono.Text) || string.IsNullOrEmpty(txt_correo.Text) ||
                string.IsNullOrEmpty(txt_estudia.Text) || string.IsNullOrEmpty(txt_trabaja.Text)
                )
            {
                throw new Exception("Hay campos vacios, por favor completar");
            }
            else
            {
                
                try
                {
                    conexion.Open();



                    string cadena = "insert into tabla_actividad5([Nombre],[Apellido],[Numero_identificacion],[Sexo],[Pais_nacimiento],[Edad],[Telefono],[Correo_electronico],[Estudia],[Trabaja])" +
                        "values ('" + txt_nombre.Text + "','" + txt_apellido.Text + "','" + txt_num.Text + "','" + txt_sexo.SelectedItem.ToString() + "','" + txt_pais.Text + "','" + txt_edad.Text + "','" + txt_telefono.Text + "','" + txt_correo.Text + "','" + txt_estudia.SelectedItem.ToString() + "','" + txt_trabaja.SelectedItem.ToString() + "')";
                    SqlCommand comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Se ha guardado exitosamente");

                    SqlCommand comMostrar = new SqlCommand("select * from tabla_actividad5", conexion);

                    SqlDataReader mostrar = comMostrar.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(mostrar);

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = table;

                    conexion.Close();

                }
                catch (System.Data.SqlClient.SqlException sqq)
                {
                    MessageBox.Show("El numero de identificacion ya existe");
                }
                
                
            }
            


        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



    }
}
