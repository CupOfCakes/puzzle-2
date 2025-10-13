using System.Drawing;

namespace puzzle
{
    partial class Galeria
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
            this.FLP_Galeria = new System.Windows.Forms.FlowLayoutPanel();
            this.LB_Galeria = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FLP_Galeria
            // 
            this.FLP_Galeria.AutoScroll = true;
            this.FLP_Galeria.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FLP_Galeria.Location = new System.Drawing.Point(0, 19);
            this.FLP_Galeria.Name = "FLP_Galeria";
            this.FLP_Galeria.Size = new System.Drawing.Size(800, 431);
            this.FLP_Galeria.TabIndex = 1;
            this.FLP_Galeria.Paint += new System.Windows.Forms.PaintEventHandler(this.FLP_Galeria_Paint);
            // 
            // LB_Galeria
            // 
            this.LB_Galeria.AutoSize = true;
            this.LB_Galeria.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Galeria.Font = new System.Drawing.Font("Arial", 10F);
            this.LB_Galeria.Location = new System.Drawing.Point(0, 0);
            this.LB_Galeria.Name = "LB_Galeria";
            this.LB_Galeria.Size = new System.Drawing.Size(140, 16);
            this.LB_Galeria.TabIndex = 0;
            this.LB_Galeria.Text = "Imagem selecionada:";
            this.LB_Galeria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LB_Galeria.Click += new System.EventHandler(this.label1_Click);
            // 
            // Galeria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LB_Galeria);
            this.Controls.Add(this.FLP_Galeria);
            this.Name = "Galeria";
            this.Text = "Galeria";
            this.Load += new System.EventHandler(this.Galeria_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel FLP_Galeria;
        private System.Windows.Forms.Label LB_Galeria;
    }
}