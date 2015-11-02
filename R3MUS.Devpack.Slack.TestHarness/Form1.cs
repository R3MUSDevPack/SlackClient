﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R3MUS.Devpack.Slack.TestHarness
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var response = Plugin.SendUserInvite(txtbxGroup.Text, txtbxToken.Text, txtbxUserEmail.Text);
            listBox1.Items.Insert(0, string.Format("SendUserInvite returned {0}", response.ToString()));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var things = Plugin.GetUsers(txtbxGroup.Text, txtbxToken.Text);

            listBox1.Items.Insert(0, string.Format("GetUsers returned {0} results", things.Count()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var response = Plugin.DeactivateUser(txtbxGroup.Text, txtbxToken.Text, txtbxUserEmail.Text);
            listBox1.Items.Insert(0, string.Format("DeactivateUser returned {0}", response.ToString()));
        }
    }
}