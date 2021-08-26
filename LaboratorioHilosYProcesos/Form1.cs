using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorioHilosYProcesos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Recursividad r = new Recursividad();
        delegate void delegado(int valor);

        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy/MM/dd HHmmssffff");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    //USO DE PROGRAMACIÓN LINEAL
                    if (comboBox2.Text != "" && comboBox1.Text == "Modo Secuencial" && comboBox2.Text == "Factorial")
                    {
                        txtResultado.Clear();
                        int n = 1;
                        while (n <= Convert.ToInt32(textBox1.Text))
                        {
                            txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + r.factorial(Convert.ToInt32(n)) + "\r\n";
                            n++;
                        }
                    }
                    else if (comboBox2.Text != "" && comboBox1.Text == "Modo Secuencial" && comboBox2.Text == "Fibonacci")
                    {
                        txtResultado.Clear();
                        int n = 1;
                        while (n <= Convert.ToInt32(textBox1.Text))
                        {
                            txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + r.fibonacci(Convert.ToInt32(n)) + "\r\n";
                            n++;
                        }
                    }
                    //USO DE HILOS 
                    else if (comboBox2.Text != "" && comboBox1.Text == "Uso de Hilos" && comboBox2.Text == "Factorial")
                    {
                        //Thread HiloProcesoFactorial = new Thread(new ThreadStart(AtenderHiloFactorial));
                        Thread HiloProcesoFactorial = new Thread(new ThreadStart(AtenderHiloFactorial));
                        HiloProcesoFactorial.Start();

                        
                    }
                    else
                        MessageBox.Show("Seleccionar operación");
                }
                else
                    MessageBox.Show("Seleccionar modo de ejecución");
            }
            else
                MessageBox.Show("Ingresar datos en el txt");

        }

        //public double factorialHilo(int num)
        //{
        //    delegado MD = new delegado(Actualizar1);
        //    if (num == 0 || num == 1)
        //    {
        //        this.Invoke(MD, new object[] { num });
        //        return 1;
        //    }
        //    return num * factorialHilo(num - 1);
        //    this.Invoke(MD, new object[] { num * factorialHilo(num - 1) });

        //}
        public void AtenderHiloFactorial()
        {
            for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
            {
                delegado MD = new delegado(Actualizar1);
                this.Invoke(MD, new object[] { r.factorial(i) });
                //this.Invoke(MD, new object[] { i });
                //Thread.Sleep(10);
            }
        }
        public void Actualizar1(int valor)
        {
            //txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " - " + "Atendiendo Proceso 1 No: " + valor + "\r\n";
            //txtResultado.Clear();
            //int n = 1;
            //while (n <= Convert.ToInt32(textBox1.Text))
            //{
            //    txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " -  " + r.factorial(Convert.ToInt32(n)) + "\r\n";
            //    n++;
            //}
            //txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " -  " + r.factorial(valor) + "\r\n";
            txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " -  " + valor + "\r\n";
        }

    }

    public class Recursividad
    {
        //public static double factorial(int num)
        public int factorial(int num)
        {
            if (num == 0 || num == 1)
                return 1;
            return num * factorial(num - 1);

        }

        public double fibonacci(int num)
        {
            if (num < 2)
                return num;
            else
                return (fibonacci(num - 1) + fibonacci(num - 2));
        }
    }
}
