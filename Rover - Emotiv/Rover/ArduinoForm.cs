using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmotivApI
{
    public partial class ArduinoForm : Form
    {

        public static SerialPort serial;
        public ArduinoForm()
        {
            InitializeComponent();
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // serial.DataReceived += new SerialDataReceivedEventHandler(onReceivedData);
            serial = new SerialPort(textBox1.Text, 9600, Parity.None);
            serial.Open();
            Thread th = new Thread(new ParameterizedThreadStart(read_async));
            th.Start(serial);
        }

        private void read_async(Object portobj)
        {
            SerialPort port = (SerialPort)portobj;
            try
            {
                while (port.IsOpen)
                {
                    string line = port.ReadLine();
                    onReceivedData(line);
                      
                 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        delegate void OnRecieveDelegate(string data);
        public void onReceivedData(string data)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new OnRecieveDelegate(onReceivedData), new object[] { data});
            }
            else
            { //string str = System.Text.Encoding.UTF8.Getstring(data);
                textBox2.AppendText(data+ "\n");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnOpen(object sender, EventArgs e)
        {
            serial.Write(new byte[] { (byte)'L' },0,1);
            
        }

        private void ArduinoForm_Load(object sender, EventArgs e)
        {

        }

        private void OnClose(object sender, EventArgs e)
        {
            serial.Write(new byte[] { (byte)'N' },0,1);
        }
    }
}
