
namespace hw_10_lv_1_ex_1
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
            this.txtbx_value_0 = new System.Windows.Forms.TextBox();
            this.txtbx_value_1 = new System.Windows.Forms.TextBox();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.lbl_answer_0 = new System.Windows.Forms.Label();
            this.operation_signature = new System.Windows.Forms.Label();
            this.equals_sign = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtbx_value_0
            // 
            this.txtbx_value_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtbx_value_0.Location = new System.Drawing.Point(48, 48);
            this.txtbx_value_0.Name = "txtbx_value_0";
            this.txtbx_value_0.Size = new System.Drawing.Size(100, 30);
            this.txtbx_value_0.TabIndex = 0;
            // 
            // txtbx_value_1
            // 
            this.txtbx_value_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtbx_value_1.Location = new System.Drawing.Point(230, 48);
            this.txtbx_value_1.Name = "txtbx_value_1";
            this.txtbx_value_1.Size = new System.Drawing.Size(100, 30);
            this.txtbx_value_1.TabIndex = 1;
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(65, 202);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(247, 96);
            this.btn_calculate.TabIndex = 2;
            this.btn_calculate.Text = "Calculate";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_answer_0
            // 
            this.lbl_answer_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_answer_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lbl_answer_0.Location = new System.Drawing.Point(65, 141);
            this.lbl_answer_0.Name = "lbl_answer_0";
            this.lbl_answer_0.Size = new System.Drawing.Size(247, 39);
            this.lbl_answer_0.TabIndex = 3;
            this.lbl_answer_0.Text = "Your result";
            this.lbl_answer_0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // operation_signature
            // 
            this.operation_signature.AutoSize = true;
            this.operation_signature.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.operation_signature.Location = new System.Drawing.Point(172, 48);
            this.operation_signature.Name = "operation_signature";
            this.operation_signature.Size = new System.Drawing.Size(37, 39);
            this.operation_signature.TabIndex = 4;
            this.operation_signature.Text = "+";
            // 
            // equals_sign
            // 
            this.equals_sign.AutoSize = true;
            this.equals_sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.equals_sign.Location = new System.Drawing.Point(172, 102);
            this.equals_sign.Name = "equals_sign";
            this.equals_sign.Size = new System.Drawing.Size(37, 39);
            this.equals_sign.TabIndex = 5;
            this.equals_sign.Text = "=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 343);
            this.Controls.Add(this.equals_sign);
            this.Controls.Add(this.operation_signature);
            this.Controls.Add(this.lbl_answer_0);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.txtbx_value_1);
            this.Controls.Add(this.txtbx_value_0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbx_value_0;
        private System.Windows.Forms.TextBox txtbx_value_1;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.Label lbl_answer_0;
        private System.Windows.Forms.Label operation_signature;
        private System.Windows.Forms.Label equals_sign;
    }
}

