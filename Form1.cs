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

namespace LightController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LEDController.MouseUp += new MouseEventHandler(LEDController_MouseUp);
            Shown += new EventHandler(Form_Shown);
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

        static HttpClient client = new HttpClient();
        private async Task<HttpResponseMessage> TriggerLights()
        {
            HttpResponseMessage res = await client.GetAsync("https://maker.ifttt.com/trigger/deskled/with/key/cJcWpIT5E0XV5GPWWn9nWl");

            return res;
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

    }
}
