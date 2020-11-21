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

namespace AsynchronousDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataManagerSerivice.Instance.DataWarmUp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action action = new Action(this.QueryData);

            action.BeginInvoke(null, null);            
        }

        private void QueryData()
        {
            int ret = DataManagerSerivice.Instance.GetData();
            this.BeginInvoke(new Action(() => this.label1.Text = ret.ToString()), null);
        }
    }
}
