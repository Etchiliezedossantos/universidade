namespace PROJECO_P2_2
{
    partial class F_datas
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
            this.LB_dataA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LB_dataA
            // 
            this.LB_dataA.AutoSize = true;
            this.LB_dataA.BackColor = System.Drawing.Color.Transparent;
            this.LB_dataA.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_dataA.ForeColor = System.Drawing.Color.Black;
            this.LB_dataA.Location = new System.Drawing.Point(354, 9);
            this.LB_dataA.Name = "LB_dataA";
            this.LB_dataA.Size = new System.Drawing.Size(253, 24);
            this.LB_dataA.TabIndex = 0;
            this.LB_dataA.Text = "Data dos Exames de acesso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(637, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Os exames de acesso começam do dia 02 de Agosto até o  dia 30 de setembro";
            // 
            // F_datas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PROJECO_P2_2.Properties.Resources._4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.LB_dataA);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "F_datas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATAS";
            this.Load += new System.EventHandler(this.F_datas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LB_dataA;
        private System.Windows.Forms.Label label1;
    }
}