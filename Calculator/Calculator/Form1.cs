using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformOperation("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            PerformOperation("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        private void PerformOperation(string operation)
        {
            try
            {
                double firstNumber = Convert.ToDouble(txtFirstNumber.Text);
                double secondNumber = Convert.ToDouble(txtSecondNumber.Text);
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

                lblResult.Text = "Result: " + result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.");
            }
        }
    }
}
