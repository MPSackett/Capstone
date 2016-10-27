using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //used for setting up SerialPort class
using System.IO; //used for setting up SerialPort class

namespace DPCADA
{
    public partial class Form1 : Form
    {
        static int ard = 5; //changes depending on com port each is plugged into
                             //initialize arduino according to the COM port in the Program field
        SerialPort myArduino = new SerialPort("COM" + ard.ToString(), 57600); //com can change and note baudrate        

        public Form1()
        {
            InitializeComponent();
            myArduino.Open();

        }

        private void checkBoxposMotor1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxposMotor1.Checked == true)
            {
                myArduino.Write("11005");
                checkBoxnegMotor1.Checked = false;
            }
            else
            {
                myArduino.Write("10000");
            }
        }

        private void checkBoxnegMotor1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxnegMotor1.Checked == true)
            {
                checkBoxposMotor1.Checked = false;
                myArduino.Write("10005");
            }
            else
            {
                myArduino.Write("10000");
                checkBoxposMotor1.Enabled = true;
            }
        }

        private void checkBoxposMotor2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxposMotor2.Checked == true)
            {
                myArduino.Write("21005");
                checkBoxnegMotor2.Checked = false;
            }
            else
            {
                myArduino.Write("20000");
            }
        }

        private void checkBoxnegMotor2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxnegMotor2.Checked == true)
            {
                myArduino.Write("20005");
                checkBoxposMotor2.Checked = false;
            }
            else
            {
                myArduino.Write("20000");
            }
        }

        private void checkBoxposMotor3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxposMotor3.Checked == true)
            {
                myArduino.Write("31005");
                checkBoxnegMotor3.Checked = false;
            }
            else
            {
                myArduino.Write("30000");
            }
        }

        private void checkBoxnegMotor3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxnegMotor3.Checked == true)
            {
                checkBoxposMotor3.Checked = false;
                myArduino.Write("30005");
            }
            else
            {
                myArduino.Write("30000");
            }
        }

        private void checkBoxposMotor4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxposMotor4.Checked == true)
            {
                checkBoxnegMotor4.Checked = false;
                myArduino.Write("41005");
                
            }
            else
            {
                myArduino.Write("40000");
            }
        }

        private void checkBoxnegMotor4_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxnegMotor4.Checked == true)
            {
                checkBoxposMotor4.Checked = false;
                myArduino.Write("40005");
            }
            else
            {
                myArduino.Write("40000");
            }          
        }

        private void checkBoxposMotor5_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxposMotor5.Checked == true)
            {
                checkBoxnegMotor5.Checked = false;
                myArduino.Write("51005");
            }
            else
            {
                myArduino.Write("50000");
            }
        }

        private void checkBoxnegMotor5_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxnegMotor5.Checked == true)
            {
                checkBoxposMotor5.Checked = false;
                myArduino.Write("50005");
            }
            else
            {
                myArduino.Write("50000");
            }

        }

        private void checkBoxposMotor6_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxposMotor6.Checked == true)
            {
                checkBoxnegMotor6.Checked = false;
                myArduino.Write("61005");
            }
            else
            {
                myArduino.Write("60000");
            }
        }

        private void checkBoxnegMotor6_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxnegMotor6.Checked == true)
            {
                checkBoxposMotor6.Checked = false;
                myArduino.Write("60005");
            }
            else
            {
                myArduino.Write("60000");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonManual_Click(object sender, EventArgs e)
        {

        }

        private void buttonAutomatic_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

