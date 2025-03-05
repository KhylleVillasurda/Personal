using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace netFrameWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hello! This is your text popping up.");
        }

        private void label2_Click_2(object sender, EventArgs e)
        {
       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int choice = int.Parse(textBox1.Text);

            switch (choice) {
                case 1:
                    System.Windows.Forms.MessageBox.Show("Maintain Silence and proper decorum");
                    break;
                case 2:
                    System.Windows.Forms.MessageBox.Show("Games are not allowed inside the class");
                    break;
                case 3:
                    System.Windows.Forms.MessageBox.Show("Surfing is allowed only with permission of the instructor");
                    break;
                case 4:
                    System.Windows.Forms.MessageBox.Show("Getting access to other websites not related to the course is strictly prohibited");
                    break;
                case 5:
                    System.Windows.Forms.MessageBox.Show("Deleting computer files and changing the set-up of the computer is a major offense");
                    break;
                case 6:
                    System.Windows.Forms.MessageBox.Show("Observe computer time usage usage carefully");
                    break;
                case 7:
                    System.Windows.Forms.MessageBox.Show("Chewing gum, eating, drinking, smoking and other forms of vandalism are prohibited inside the lab.");
                    break;
                case 8:
                    System.Windows.Forms.MessageBox.Show("Do not get inside the lab unless the instructor is present");
                    break;
                case 9:
                    System.Windows.Forms.MessageBox.Show("All bags, knapsacks,and the likes must be deposited at the counter");
                    break;
                case 10:
                    System.Windows.Forms.MessageBox.Show("Follow the seating arrangment of the instructor");
                    break;
                case 11:
                    System.Windows.Forms.MessageBox.Show("At the end of the class, all software must be closed");
                    break;
                case 12:
                    System.Windows.Forms.MessageBox.Show("Return all the chairs at their proper places after using");
                    break;
                default:
                    System.Windows.Forms.MessageBox.Show("Please input a valid number");
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("My message here");

        }
    }
}
