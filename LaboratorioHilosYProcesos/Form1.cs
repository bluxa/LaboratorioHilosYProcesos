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
            return value.ToString("yyyy/MM/dd HH:mm:ss.ffff");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //USO DE PROGRAMACIÓN LINEAL
                if (comboBox1.Text != "" && comboBox1.Text == "Modo Secuencial")
                {
                    txtResultado.Clear();
                    int n = 1;
                    while (n <= Convert.ToInt32(textBox1.Text))
                    {
                        txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " - " + "Atendiendo Modo Secuencial Factorial 1: " + r.factorial(Convert.ToInt32(n)) + "\r\n";
                        Thread.Sleep(20);
                        n++;
                    }
                    
                    int i = 1;
                    while (i <= Convert.ToInt32(textBox1.Text))
                    {
                        txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " - " + "Atendiendo Modo Secuencial Fibonacci 2: " + r.fibonacci(Convert.ToInt32(i)) + "\r\n";
                        Thread.Sleep(20); 
                        i++;
                    }
                }
                //USO DE HILOS 
                else if (comboBox1.Text != "" && comboBox1.Text == "Uso de Hilos")
                {
                    Thread HiloProcesoFactorial = new Thread(new ThreadStart(AtenderHiloFactorial));
                    Thread HiloProcesoFibonacci = new Thread(new ThreadStart(AtenderHiloFibonacci));
                    
                    HiloProcesoFactorial.Start();
                    HiloProcesoFibonacci.Start();
                }

                else
                    MessageBox.Show("Seleccionar operación");
            }
            else
                MessageBox.Show("Ingresar datos en el txt");

        }

        public void AtenderHiloFactorial()
        {
            for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
            {
                delegado MD = new delegado(ActualizarFactorial);
                this.Invoke(MD, new object[] { r.fibonacci(Convert.ToInt32(i)) });
                Thread.Sleep(20);
            }
        }

        public void AtenderHiloFibonacci()
        {
            for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
            {
                delegado MD = new delegado(ActualizarFibonacci);
                this.Invoke(MD, new object[] { r.factorial(Convert.ToInt32(i)) });
                Thread.Sleep(20);
            }
        }
        public void ActualizarFactorial(int valor)
        {
            txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " - " + "Atendiendo Uso De Hilos Factorial 1:   " + valor + "\r\n";
        }
        public void ActualizarFibonacci(int valor)
        {
            txtResultado.Text = txtResultado.Text + GetTimestamp(DateTime.Now) + " - " + "Atendiendo Uso De Hilos Fibonacci 2: " + valor + "\r\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            txtResultado.Clear();
        }
    }

    public class Recursividad
    {
        public double factorial(int num)
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
