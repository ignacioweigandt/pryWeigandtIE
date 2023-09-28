namespace pryWeigandtIE
{
    partial class FrmRegProv
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegProv));
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.txtEntidad = new System.Windows.Forms.TextBox();
            this.txtApertura = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNumExp = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.cmbLiquidador = new System.Windows.Forms.ComboBox();
            this.cmbJuzg = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbJurisd = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProveedores
            // 
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(44, 463);
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.RowHeadersWidth = 62;
            this.dgvProveedores.RowTemplate.Height = 33;
            this.dgvProveedores.Size = new System.Drawing.Size(633, 398);
            this.dgvProveedores.TabIndex = 74;
            this.dgvProveedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedores_CellContentClick);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.BackColor = System.Drawing.Color.Silver;
            this.cmdCancelar.Location = new System.Drawing.Point(554, 267);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(111, 38);
            this.cmdCancelar.TabIndex = 73;
            this.cmdCancelar.Text = "Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = false;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.BackColor = System.Drawing.Color.Silver;
            this.cmdEliminar.Location = new System.Drawing.Point(554, 203);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(111, 35);
            this.cmdEliminar.TabIndex = 72;
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = false;
            // 
            // cmdModificar
            // 
            this.cmdModificar.BackColor = System.Drawing.Color.Silver;
            this.cmdModificar.Location = new System.Drawing.Point(554, 137);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(111, 45);
            this.cmdModificar.TabIndex = 71;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = false;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.BackColor = System.Drawing.Color.Silver;
            this.cmdAgregar.Location = new System.Drawing.Point(554, 65);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(111, 38);
            this.cmdAgregar.TabIndex = 70;
            this.cmdAgregar.Text = "Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = false;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // txtEntidad
            // 
            this.txtEntidad.BackColor = System.Drawing.Color.Silver;
            this.txtEntidad.Location = new System.Drawing.Point(261, 112);
            this.txtEntidad.Name = "txtEntidad";
            this.txtEntidad.Size = new System.Drawing.Size(183, 31);
            this.txtEntidad.TabIndex = 69;
            // 
            // txtApertura
            // 
            this.txtApertura.BackColor = System.Drawing.Color.Silver;
            this.txtApertura.Location = new System.Drawing.Point(261, 157);
            this.txtApertura.Name = "txtApertura";
            this.txtApertura.Size = new System.Drawing.Size(183, 31);
            this.txtApertura.TabIndex = 68;
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.Silver;
            this.txtDireccion.Location = new System.Drawing.Point(264, 334);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(178, 31);
            this.txtDireccion.TabIndex = 67;
            // 
            // txtNumExp
            // 
            this.txtNumExp.BackColor = System.Drawing.Color.Silver;
            this.txtNumExp.Location = new System.Drawing.Point(264, 200);
            this.txtNumExp.Name = "txtNumExp";
            this.txtNumExp.Size = new System.Drawing.Size(178, 31);
            this.txtNumExp.TabIndex = 66;
            // 
            // txtNum
            // 
            this.txtNum.BackColor = System.Drawing.Color.Silver;
            this.txtNum.Location = new System.Drawing.Point(261, 65);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(183, 31);
            this.txtNum.TabIndex = 65;
            // 
            // cmbLiquidador
            // 
            this.cmbLiquidador.BackColor = System.Drawing.Color.Silver;
            this.cmbLiquidador.FormattingEnabled = true;
            this.cmbLiquidador.Location = new System.Drawing.Point(261, 376);
            this.cmbLiquidador.Name = "cmbLiquidador";
            this.cmbLiquidador.Size = new System.Drawing.Size(183, 33);
            this.cmbLiquidador.TabIndex = 64;
            // 
            // cmbJuzg
            // 
            this.cmbJuzg.BackColor = System.Drawing.Color.Silver;
            this.cmbJuzg.FormattingEnabled = true;
            this.cmbJuzg.Location = new System.Drawing.Point(261, 250);
            this.cmbJuzg.Name = "cmbJuzg";
            this.cmbJuzg.Size = new System.Drawing.Size(183, 33);
            this.cmbJuzg.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(44, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 21);
            this.label7.TabIndex = 62;
            this.label7.Text = "LIQUIDADOR RESPONSABLE";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 338);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 25);
            this.label6.TabIndex = 61;
            this.label6.Text = "DIRECCION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 25);
            this.label5.TabIndex = 60;
            this.label5.Text = "JUZG.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 59;
            this.label4.Text = "Nº EXPTE.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 25);
            this.label3.TabIndex = 58;
            this.label3.Text = "APERTURA\t";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 57;
            this.label2.Text = "Entidad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 25);
            this.label1.TabIndex = 56;
            this.label1.Text = "Nº\t";
            // 
            // cmbJurisd
            // 
            this.cmbJurisd.BackColor = System.Drawing.Color.Silver;
            this.cmbJurisd.FormattingEnabled = true;
            this.cmbJurisd.Location = new System.Drawing.Point(261, 295);
            this.cmbJurisd.Name = "cmbJurisd";
            this.cmbJurisd.Size = new System.Drawing.Size(183, 33);
            this.cmbJurisd.TabIndex = 76;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 25);
            this.label8.TabIndex = 75;
            this.label8.Text = "JURISD";
            // 
            // FrmRegProv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.cmdCancelar;
            this.ClientSize = new System.Drawing.Size(729, 993);
            this.Controls.Add(this.cmbJurisd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvProveedores);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.txtEntidad);
            this.Controls.Add(this.txtApertura);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtNumExp);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.cmbLiquidador);
            this.Controls.Add(this.cmbJuzg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRegProv";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Proveedores";
            this.Load += new System.EventHandler(this.FrmRegProv_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvProveedores;
        private Button cmdCancelar;
        private Button cmdEliminar;
        private Button cmdModificar;
        private Button cmdAgregar;
        private TextBox txtEntidad;
        private TextBox txtApertura;
        private TextBox txtDireccion;
        private TextBox txtNumExp;
        private TextBox txtNum;
        private ComboBox cmbLiquidador;
        private ComboBox cmbJuzg;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cmbJurisd;
        private Label label8;
    }
}