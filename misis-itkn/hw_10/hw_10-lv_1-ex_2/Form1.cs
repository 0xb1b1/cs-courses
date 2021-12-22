using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw_10_lv_1_ex_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            int integers_counter = int.Parse(tb_integers_amount.Text);
            int sum = 0;
            for (int i = 0; i <= integers_counter; i++)
            {
                sum += i;
            }
            lbl_result.Text = sum.ToString();
        }
    }
}
