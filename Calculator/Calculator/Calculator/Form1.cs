using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private double firstNumber;
        private string operation;
        private bool isOperationPerformed;
        public Form1()
        {
            InitializeComponent();
        }

        private void PerformOperation(string op)
        {
            if (double.TryParse(txtDisplay.Text, out firstNumber))
            {
                operation = op;
                txtDisplay.Clear(); // Clear the display for the next number
                isOperationPerformed = true; // Set the flag to indicate an operation is performed
            }
        }

        private void button1_Click(object sender, EventArgs e) { txtDisplay.Text += "1"; }
        private void button2_Click(object sender, EventArgs e) { txtDisplay.Text += "2"; }
        private void button3_Click(object sender, EventArgs e) { txtDisplay.Text += "3"; }
        private void button4_Click(object sender, EventArgs e) { txtDisplay.Text += "4"; }
        private void button5_Click(object sender, EventArgs e) { txtDisplay.Text += "5"; }
        private void button6_Click(object sender, EventArgs e) { txtDisplay.Text += "6"; }
        private void button7_Click(object sender, EventArgs e) { txtDisplay.Text += "7"; }
        private void button8_Click(object sender, EventArgs e) { txtDisplay.Text += "8"; }
        private void button9_Click(object sender, EventArgs e) { txtDisplay.Text += "9"; }
        private void button11_Click(object sender, EventArgs e) { txtDisplay.Text += "0"; }
        private void button10_Click(object sender, EventArgs e) { txtDisplay.Text += "."; }
        private void button12_Click(object sender, EventArgs e) { PerformOperation("+"); }
        private void button13_Click(object sender, EventArgs e) { PerformOperation("-"); }
        private void button14_Click(object sender, EventArgs e) { PerformOperation("*"); }
        private void button15_Click(object sender, EventArgs e) { PerformOperation("/"); }
        private void button16_Click(object sender, EventArgs e) { /* Equals logic */ }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "6";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "5";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "1";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += ".";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "3";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtDisplay.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
 
            PerformOperation("+");
        }

        private void button13_Click(object sender, EventArgs e)
        {
 
            PerformOperation("-");

        }

        private void button14_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            double secondNumber;
            if (double.TryParse(txtDisplay.Text, out secondNumber))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber != 0)
                        {
                            result = firstNumber / secondNumber;
                        }
                        else
                        {
                            MessageBox.Show("Cannot divide by zero.");
                            return;
                        }
                        break;
                }

                txtDisplay.Text = result.ToString(); 
                isOperationPerformed = false; 
            }
        }
    }
}
