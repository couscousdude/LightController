using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;

namespace LightController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LEDController.MouseUp += new MouseEventHandler(LEDController_MouseUp);
            Shown += new EventHandler(Form_Shown);
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
        }

        private void Form_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                LEDController.Visible = true;
            }
        }

        private string apiUrl = System.Environment.GetEnvironmentVariable("ApiUrl");
        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.SetEnvironmentVariable("ApiUrl", textBox2.Text, EnvironmentVariableTarget.User);
            apiUrl = System.Environment.GetEnvironmentVariable("ApiUrl", EnvironmentVariableTarget.User);
            textBox3.Text = apiUrl;
        }

        static HttpClient client = new HttpClient();
        private async Task<HttpResponseMessage> TriggerLights()
        {
            HttpResponseMessage res = await client.GetAsync(apiUrl);

            return res;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TriggerLights();
        }
        private void LEDController_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TriggerLights();
            }
            if (e.Button == MouseButtons.Right)
            {
                WindowState = FormWindowState.Maximized;
                Show();
                LEDController.Visible = false;
            }
        }
        private void textBox2_TextChanged(object send, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object send, EventArgs e)
        {

        }
    }
}
