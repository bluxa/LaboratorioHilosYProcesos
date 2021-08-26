using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (comboBox1.Text != "")
                {
                    if (comboBox2.Text != "" && comboBox2.Text == "Factorial")
                    {
                        FactorialRecursivo r = new FactorialRecursivo();
                        int n = 1;
                        while (n <= Convert.ToInt32(textBox1.Text))
                        {
                            txtResultado.Text = txtResultado.Text + r.factorial(Convert.ToInt32(n)) + "\r\n";
                            n++;
                        }
                        
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

    }

    public class FactorialRecursivo
    {
        //public static double factorial(int num)
        public double factorial(int num)
        {
            if (num == 0 || num == 1)
                return 1;
            return num * factorial(num - 1);

        }
    }
}
