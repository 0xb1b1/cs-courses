using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw_10_lv_1_ex_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value_0 = int.Parse(txtbx_value_0.Text);
            int value_1 = int.Parse(txtbx_value_1.Text);
            int result = value_0 + value_1;
            lbl_answer_0.Text = result.ToString();
        }
    }
}
