using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CalculatorApplication.Form1.CalculatorClass;

namespace CalculatorApplication
{
    public partial class Form1 : Form
    {


        CalculatorClass cal;


        double num1;
        double num2;

        
        public Form1()
        {
            InitializeComponent();
            cal = new CalculatorClass();
        }


        public delegate T Formula<T>(T arg1, T arg2);
        public Formula<double> DoubleType;

        public class CalculatorClass
        {
          

            public double GetSum(double arg1, double arg2)
            {
                return arg1 + arg2;
            }
            public double GetDifference(double arg1, double arg2)
            {
                return arg1 - arg2;
            }
            public double GetProduct(double arg1, double arg2)
            {
                return arg1 * arg2;
            }
            public double GetQuotient(double arg1, double arg2)
            {
                if (arg2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                return arg1 / arg2;


            }


            public delegate double CalculatorDelegate(double arg1, double arg2);

            private CalculatorDelegate calculateEvent;

            public event CalculatorDelegate CalculateEvent
            {
                add
                {
                    calculateEvent += value;
                    Console.WriteLine("Added the Delegate");
                }
                remove
                {
                    calculateEvent -= value;
                    Console.WriteLine("Removed the Delegate");
                }
            }





        }


       





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(txtBoxInput1.Text);
            num2 = Convert.ToDouble(txtBoxInput2.Text);

            string op = cbOperator.SelectedItem.ToString();
            double result = 0;

            if (op == "+")
            {
                cal.CalculateEvent += new CalculatorDelegate(cal.GetSum);
                result = cal.GetSum(num1,num2);
                cal.CalculateEvent -= new CalculatorDelegate(cal.GetSum);
                lblDisplayTotal.Text = result.ToString();
            }
            else if (op == "-")
            {
                cal.CalculateEvent += new CalculatorDelegate(cal.GetDifference);
                result = cal.GetDifference(num1, num2);
                cal.CalculateEvent -= new CalculatorDelegate(cal.GetDifference);
                lblDisplayTotal.Text = result.ToString();
            }
            else if (op == "*")
            {
                cal.CalculateEvent += new CalculatorDelegate(cal.GetProduct);
                result = cal.GetProduct(num1, num2);
                cal.CalculateEvent -= new CalculatorDelegate(cal.GetProduct);
                lblDisplayTotal.Text = result.ToString();
            }
            else if (op == "/")
            {
                cal.CalculateEvent += new CalculatorDelegate(cal.GetQuotient);
                try
                {
                    result = cal.GetQuotient(num1, num2);
                    lblDisplayTotal.Text = result.ToString();
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message);
                    return; 
                }
                finally
                {
                    cal.CalculateEvent -= new CalculatorDelegate(cal.GetQuotient);
                }
            }

     
            
        }

    }
}
