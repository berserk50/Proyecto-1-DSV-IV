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

namespace Proyecto_1_Calculadora
{
    public partial class Form1 : Form
    {
        int idSuma, idResta, idMul, idDivi, idCua, idRaiz;
        bool nuevo = true;
        string connectionString = @"Server=.\sqlexpress;Database=Operaciones;TrustServerCertificate=true;Integrated Security=SSPI;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "4";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            txtEntrada2.Text = txtEntrada.Text;
            txtEntrada.Text = "";
            Operaciones operacion = new Operaciones();
            double resultado = operacion.cuadrado(txtEntrada2.Text);
            txtEntrada.Text = resultado.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text.Substring(0, txtEntrada.Text.Length - 1);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "0";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "3";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = txtEntrada.Text + "7";
        }

        private void btnRestar_Click(object sender, EventArgs e)
        {
            txtEntrada2.Text = txtEntrada.Text;
            txtEntrada.Text = "";
            txtSigno.Text = "-";

        }

        private void btnIgualar_Click(object sender, EventArgs e)
        {
            if (txtSigno.Text == "-")
            {
                Operaciones operacion = new Operaciones();
                double resultado = operacion.Restar(txtEntrada2.Text, txtEntrada.Text);
                txtEntrada.Text = resultado.ToString();
                txtEntrada2.Text = "";
                txtSigno.Text = "";


           
            }
           if (txtSigno.Text == "+")
           {
                Operaciones operacion = new Operaciones();
                double resultado = operacion.Sumar(txtEntrada2.Text, txtEntrada.Text);
                txtEntrada.Text = resultado.ToString();
                txtEntrada2.Text = "";
           }
            if (txtSigno.Text == "/")
            {
                Operaciones operacion = new Operaciones();
                double resultado = operacion.Dividir(txtEntrada2.Text, txtEntrada.Text);
                txtEntrada.Text = resultado.ToString();
                txtEntrada2.Text = "";
            }
            if (txtSigno.Text == "*")
            {
                Operaciones operacion = new Operaciones();
                double resultado = operacion.Multiplicar(txtEntrada2.Text, txtEntrada.Text);
                txtEntrada.Text = resultado.ToString();
                txtEntrada2.Text = "";
            }
            if (nuevo)
            {
                string sql = "INSERT INTO RESULTADO (RESULTADOFINAL)"
                + "VALUES ('" + txtEntrada.Text + "')";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Registro ingresado correctamente !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }

                finally
                {
                    con.Close();
                }

            }

        }

        private void btnSumar_Click(object sender, EventArgs e)
        {
            txtEntrada2.Text = txtEntrada.Text;
            txtEntrada.Text = "";
            txtSigno.Text = "+";

        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            txtEntrada2.Text = txtEntrada.Text;
            txtEntrada.Text = "";
            txtSigno.Text = "/";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string connectionString = @"Server=.\SQLEXPRESS;Database=Operaciones;TrustServerCertificate=true;Integrated Security=SSPI;";

            SqlConnection conexion = new SqlConnection(connectionString);
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

            string query = "SELECT ResultadoFinal FROM [dbo].[RESULTADO]";

            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataReader lector = comando.ExecuteReader();

            listBox1.Items.Clear();

            while (lector.Read())
            {
                listBox1.Items.Add(lector["ResultadoFinal"].ToString());
            }

            lector.Close();

            conexion.Close();
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            txtEntrada2.Text = txtEntrada.Text;
            txtEntrada.Text = "";
            txtSigno.Text = "*";
        }

        private void btn_negativo_Click(object sender, EventArgs e)
        {
            Operaciones operacion = new Operaciones();
            double resultado = operacion.NumeroNegativo(txtEntrada.Text);
            txtEntrada.Text = resultado.ToString();
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            Operaciones operacion = new Operaciones();
            double resultado = operacion.AgregarDecimal(txtEntrada.Text);
            txtEntrada.Text = resultado.ToString();
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            Operaciones operacion = new Operaciones();
            double resultado = operacion.RaizCuadrada(txtEntrada.Text);
            txtEntrada.Text = resultado.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEntrada.Text = "";
            txtEntrada2.Text = "";
            txtSigno.Text = "";
        }
    }
}
