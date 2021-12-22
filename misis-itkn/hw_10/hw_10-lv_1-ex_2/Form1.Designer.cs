
namespace hw_10_lv_1_ex_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_integers_amount = new System.Windows.Forms.TextBox();
            this.lbl_nochange_integers_amount = new System.Windows.Forms.Label();
            this.lbl_nochange_result = new System.Windows.Forms.Label();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_integers_amount
            // 
            this.tb_integers_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tb_integers_amount.Location = new System.Drawing.Point(88, 62);
            this.tb_integers_amount.Name = "tb_integers_amount";
            this.tb_integers_amount.Size = new System.Drawing.Size(100, 30);
            this.tb_integers_amount.TabIndex = 0;
            // 
            // lbl_nochange_integers_amount
            // 
            this.lbl_nochange_integers_amount.AutoSize = true;
            this.lbl_nochange_integers_amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbl_nochange_integers_amount.Location = new System.Drawing.Point(12, 39);
            this.lbl_nochange_integers_amount.Name = "lbl_nochange_integers_amount";
            this.lbl_nochange_integers_amount.Size = new System.Drawing.Size(265, 20);
            this.lbl_nochange_integers_amount.TabIndex = 1;
            this.lbl_nochange_integers_amount.Text = "Amount of integers (count from one)";
            // 
            // lbl_nochange_result
            // 
            this.lbl_nochange_result.AutoSize = true;
            this.lbl_nochange_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbl_nochange_result.Location = new System.Drawing.Point(84, 131);
            this.lbl_nochange_result.Name = "lbl_nochange_result";
            this.lbl_nochange_result.Size = new System.Drawing.Size(51, 22);
            this.lbl_nochange_result.TabIndex = 2;
            this.lbl_nochange_result.Text = "Sum:";
            // 
            // btn_calculate
            // 
            this.btn_calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btn_calculate.Location = new System.Drawing.Point(63, 156);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(159, 60);
            this.btn_calculate.TabIndex = 3;
            this.btn_calculate.Text = "Calculate";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbl_result.Location = new System.Drawing.Point(141, 130);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(20, 22);
            this.lbl_result.TabIndex = 4;
            this.lbl_result.Text = "1";
            this.lbl_result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 248);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.lbl_nochange_result);
            this.Controls.Add(this.lbl_nochange_integers_amount);
            this.Controls.Add(this.tb_integers_amount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_integers_amount;
        private System.Windows.Forms.Label lbl_nochange_integers_amount;
        private System.Windows.Forms.Label lbl_nochange_result;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.Label lbl_result;
    }
}

