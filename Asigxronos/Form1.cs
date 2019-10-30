using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asigxronos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text = BigData();
        }


        public static string BigData()
        {
            Thread.Sleep(5000);

            return "Para polla dedomena";
        }
    }
}
