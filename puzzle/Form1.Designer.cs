namespace puzzle
{
    partial class FM_config
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.GB_dificuldade = new System.Windows.Forms.GroupBox();
            this.RB_dificil = new System.Windows.Forms.RadioButton();
            this.RB_medio = new System.Windows.Forms.RadioButton();
            this.RB_facil = new System.Windows.Forms.RadioButton();
            this.GB_imagem = new System.Windows.Forms.GroupBox();
            this.BT_galeria = new System.Windows.Forms.Button();
            this.BT_selecionar = new System.Windows.Forms.Button();
            this.LB_imgSelecionada = new System.Windows.Forms.Label();
            this.GB_adicional = new System.Windows.Forms.GroupBox();
            this.CB_imgAJuda = new System.Windows.Forms.CheckBox();
            this.CB_imgSave = new System.Windows.Forms.CheckBox();
            this.BT_pronto = new System.Windows.Forms.Button();
            this.GB_dificuldade.SuspendLayout();
            this.GB_imagem.SuspendLayout();
            this.GB_adicional.SuspendLayout();
            this.SuspendLayout();
            // 
            // GB_dificuldade
            // 
            this.GB_dificuldade.BackColor = System.Drawing.SystemColors.Control;
            this.GB_dificuldade.Controls.Add(this.RB_dificil);
            this.GB_dificuldade.Controls.Add(this.RB_medio);
            this.GB_dificuldade.Controls.Add(this.RB_facil);
            this.GB_dificuldade.Location = new System.Drawing.Point(11, 33);
            this.GB_dificuldade.Margin = new System.Windows.Forms.Padding(2);
            this.GB_dificuldade.Name = "GB_dificuldade";
            this.GB_dificuldade.Padding = new System.Windows.Forms.Padding(2);
            this.GB_dificuldade.Size = new System.Drawing.Size(205, 81);
            this.GB_dificuldade.TabIndex = 0;
            this.GB_dificuldade.TabStop = false;
            this.GB_dificuldade.Text = "Dificuldade";
            // 
            // RB_dificil
            // 
            this.RB_dificil.AutoSize = true;
            this.RB_dificil.Checked = true;
            this.RB_dificil.Location = new System.Drawing.Point(12, 60);
            this.RB_dificil.Margin = new System.Windows.Forms.Padding(2);
            this.RB_dificil.Name = "RB_dificil";
            this.RB_dificil.Size = new System.Drawing.Size(50, 17);
            this.RB_dificil.TabIndex = 2;
            this.RB_dificil.TabStop = true;
            this.RB_dificil.Text = "Dificil";
            this.RB_dificil.UseVisualStyleBackColor = true;
            // 
            // RB_medio
            // 
            this.RB_medio.AutoSize = true;
            this.RB_medio.Location = new System.Drawing.Point(12, 39);
            this.RB_medio.Margin = new System.Windows.Forms.Padding(2);
            this.RB_medio.Name = "RB_medio";
            this.RB_medio.Size = new System.Drawing.Size(54, 17);
            this.RB_medio.TabIndex = 1;
            this.RB_medio.Text = "Medio";
            this.RB_medio.UseVisualStyleBackColor = true;
            // 
            // RB_facil
            // 
            this.RB_facil.AutoSize = true;
            this.RB_facil.Location = new System.Drawing.Point(12, 17);
            this.RB_facil.Margin = new System.Windows.Forms.Padding(2);
            this.RB_facil.Name = "RB_facil";
            this.RB_facil.Size = new System.Drawing.Size(47, 17);
            this.RB_facil.TabIndex = 0;
            this.RB_facil.Text = "Facil";
            this.RB_facil.UseVisualStyleBackColor = true;
            // 
            // GB_imagem
            // 
            this.GB_imagem.Controls.Add(this.BT_galeria);
            this.GB_imagem.Controls.Add(this.BT_selecionar);
            this.GB_imagem.Controls.Add(this.LB_imgSelecionada);
            this.GB_imagem.Location = new System.Drawing.Point(11, 133);
            this.GB_imagem.Margin = new System.Windows.Forms.Padding(2);
            this.GB_imagem.Name = "GB_imagem";
            this.GB_imagem.Padding = new System.Windows.Forms.Padding(2);
            this.GB_imagem.Size = new System.Drawing.Size(205, 109);
            this.GB_imagem.TabIndex = 1;
            this.GB_imagem.TabStop = false;
            this.GB_imagem.Text = "Imagem";
            // 
            // BT_galeria
            // 
            this.BT_galeria.Location = new System.Drawing.Point(7, 72);
            this.BT_galeria.Margin = new System.Windows.Forms.Padding(2);
            this.BT_galeria.Name = "BT_galeria";
            this.BT_galeria.Size = new System.Drawing.Size(56, 19);
            this.BT_galeria.TabIndex = 2;
            this.BT_galeria.Text = "Galeria";
            this.BT_galeria.UseVisualStyleBackColor = true;
            this.BT_galeria.Click += new System.EventHandler(this.BT_galeria_Click);
            // 
            // BT_selecionar
            // 
            this.BT_selecionar.Location = new System.Drawing.Point(7, 39);
            this.BT_selecionar.Margin = new System.Windows.Forms.Padding(2);
            this.BT_selecionar.Name = "BT_selecionar";
            this.BT_selecionar.Size = new System.Drawing.Size(100, 20);
            this.BT_selecionar.TabIndex = 1;
            this.BT_selecionar.Text = "Selecionar imagem";
            this.BT_selecionar.UseVisualStyleBackColor = true;
            this.BT_selecionar.Click += new System.EventHandler(this.BT_selecionar_Click);
            // 
            // LB_imgSelecionada
            // 
            this.LB_imgSelecionada.AutoSize = true;
            this.LB_imgSelecionada.Location = new System.Drawing.Point(4, 15);
            this.LB_imgSelecionada.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LB_imgSelecionada.Name = "LB_imgSelecionada";
            this.LB_imgSelecionada.Size = new System.Drawing.Size(156, 13);
            this.LB_imgSelecionada.TabIndex = 0;
            this.LB_imgSelecionada.Text = "Imagem selecionada: Nenhuma";
            // 
            // GB_adicional
            // 
            this.GB_adicional.Controls.Add(this.CB_imgAJuda);
            this.GB_adicional.Controls.Add(this.CB_imgSave);
            this.GB_adicional.Location = new System.Drawing.Point(11, 255);
            this.GB_adicional.Margin = new System.Windows.Forms.Padding(2);
            this.GB_adicional.Name = "GB_adicional";
            this.GB_adicional.Padding = new System.Windows.Forms.Padding(2);
            this.GB_adicional.Size = new System.Drawing.Size(205, 81);
            this.GB_adicional.TabIndex = 2;
            this.GB_adicional.TabStop = false;
            this.GB_adicional.Text = "Configuração adicional";
            // 
            // CB_imgAJuda
            // 
            this.CB_imgAJuda.AutoSize = true;
            this.CB_imgAJuda.Checked = true;
            this.CB_imgAJuda.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_imgAJuda.Location = new System.Drawing.Point(7, 17);
            this.CB_imgAJuda.Margin = new System.Windows.Forms.Padding(2);
            this.CB_imgAJuda.Name = "CB_imgAJuda";
            this.CB_imgAJuda.Size = new System.Drawing.Size(107, 17);
            this.CB_imgAJuda.TabIndex = 3;
            this.CB_imgAJuda.Text = "Imagem de ajuda";
            this.CB_imgAJuda.UseVisualStyleBackColor = true;
            // 
            // CB_imgSave
            // 
            this.CB_imgSave.AutoSize = true;
            this.CB_imgSave.Location = new System.Drawing.Point(7, 38);
            this.CB_imgSave.Margin = new System.Windows.Forms.Padding(2);
            this.CB_imgSave.Name = "CB_imgSave";
            this.CB_imgSave.Size = new System.Drawing.Size(105, 17);
            this.CB_imgSave.TabIndex = 4;
            this.CB_imgSave.Text = "Salvar na galeria";
            this.CB_imgSave.UseVisualStyleBackColor = true;
            // 
            // BT_pronto
            // 
            this.BT_pronto.Location = new System.Drawing.Point(11, 346);
            this.BT_pronto.Margin = new System.Windows.Forms.Padding(2);
            this.BT_pronto.Name = "BT_pronto";
            this.BT_pronto.Size = new System.Drawing.Size(205, 37);
            this.BT_pronto.TabIndex = 3;
            this.BT_pronto.Text = "Pronto";
            this.BT_pronto.UseVisualStyleBackColor = true;
            this.BT_pronto.Click += new System.EventHandler(this.BT_pronto_Click);
            // 
            // FM_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 441);
            this.Controls.Add(this.BT_pronto);
            this.Controls.Add(this.GB_adicional);
            this.Controls.Add(this.GB_imagem);
            this.Controls.Add(this.GB_dificuldade);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FM_config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GB_dificuldade.ResumeLayout(false);
            this.GB_dificuldade.PerformLayout();
            this.GB_imagem.ResumeLayout(false);
            this.GB_imagem.PerformLayout();
            this.GB_adicional.ResumeLayout(false);
            this.GB_adicional.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_dificuldade;
        private System.Windows.Forms.RadioButton RB_dificil;
        private System.Windows.Forms.RadioButton RB_medio;
        private System.Windows.Forms.RadioButton RB_facil;
        private System.Windows.Forms.GroupBox GB_imagem;
        private System.Windows.Forms.Button BT_selecionar;
        private System.Windows.Forms.Label LB_imgSelecionada;
        private System.Windows.Forms.Button BT_galeria;
        private System.Windows.Forms.GroupBox GB_adicional;
        private System.Windows.Forms.CheckBox CB_imgAJuda;
        private System.Windows.Forms.CheckBox CB_imgSave;
        private System.Windows.Forms.Button BT_pronto;
    }
}

