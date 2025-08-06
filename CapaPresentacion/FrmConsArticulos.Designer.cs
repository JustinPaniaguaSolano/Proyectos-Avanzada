namespace CapaPresentacion
{
    partial class FrmConsArticulos
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
            DgvConsulta = new DataGridView();
            BttMenu = new Button();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)DgvConsulta).BeginInit();
            SuspendLayout();
            // 
            // DgvConsulta
            // 
            DgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvConsulta.Location = new Point(52, 132);
            DgvConsulta.Name = "DgvConsulta";
            DgvConsulta.Size = new Size(696, 239);
            DgvConsulta.TabIndex = 39;
            // 
            // BttMenu
            // 
            BttMenu.BackColor = Color.OrangeRed;
            BttMenu.Font = new Font("Segoe UI", 15F);
            BttMenu.ForeColor = SystemColors.ButtonHighlight;
            BttMenu.Location = new Point(345, 397);
            BttMenu.Name = "BttMenu";
            BttMenu.Size = new Size(115, 38);
            BttMenu.TabIndex = 38;
            BttMenu.Text = "Menu";
            BttMenu.UseVisualStyleBackColor = false;
            BttMenu.Click += BttMenu_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.InactiveCaptionText;
            label1.Location = new Point(257, 89);
            label1.Name = "label1";
            label1.Size = new Size(224, 28);
            label1.TabIndex = 37;
            label1.Text = "Consulta De  Articulos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.DarkGray;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Verdana", 35.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Tomato;
            label2.Location = new Point(193, 20);
            label2.Name = "label2";
            label2.Size = new Size(361, 59);
            label2.TabIndex = 40;
            label2.Text = "Entregas S.A";
            // 
            // FrmConsArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(DgvConsulta);
            Controls.Add(BttMenu);
            Controls.Add(label1);
            Name = "FrmConsArticulos";
            Text = "Consulta De Articulos Entregas S.A";
            Load += FrmConsArticulos_Load;
            ((System.ComponentModel.ISupportInitialize)DgvConsulta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DgvConsulta;
        private Button BttMenu;
        private Label label1;
        private Label label2;
    }
}