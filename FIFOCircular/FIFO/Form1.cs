﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFO
{
    public partial class Form1 : Form
    {
        Processor proc;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            proc = new Processor();
            proc.process();
            labelEmpty.Text += proc.getEmptyCicles().ToString();
            labelUnTask.Text += proc.getUncompletedTasks().ToString();
            labelCoTask.Text += proc.getCompletedTasks().ToString();
        }
    }
}
