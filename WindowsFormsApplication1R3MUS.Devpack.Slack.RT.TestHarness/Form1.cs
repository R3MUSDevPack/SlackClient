using R3MUS.Devpack.Slack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1R3MUS.Devpack.Slack.RT.TestHarness
{
    public partial class Form1 : Form
    {
        Plugin plugin;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plugin = new Plugin(textBox1.Text);
            this.Text = plugin.Connected.ToString();
        }
    }
}
