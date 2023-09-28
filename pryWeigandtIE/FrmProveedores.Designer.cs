namespace pryWeigandtIE
{
    partial class frmProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores));
            this.listViewProveedores = new System.Windows.Forms.ListView();
            this.tvProveedores = new System.Windows.Forms.TreeView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewProveedores
            // 
            this.listViewProveedores.BackColor = System.Drawing.Color.Silver;
            this.listViewProveedores.Location = new System.Drawing.Point(401, 12);
            this.listViewProveedores.Name = "listViewProveedores";
            this.listViewProveedores.Size = new System.Drawing.Size(474, 441);
            this.listViewProveedores.TabIndex = 0;
            this.listViewProveedores.UseCompatibleStateImageBehavior = false;
            // 
            // tvProveedores
            // 
            this.tvProveedores.BackColor = System.Drawing.Color.Silver;
            this.tvProveedores.Location = new System.Drawing.Point(12, 12);
            this.tvProveedores.Name = "tvProveedores";
            this.tvProveedores.Size = new System.Drawing.Size(332, 441);
            this.tvProveedores.TabIndex = 1;
            this.tvProveedores.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProveedores_AfterSelect);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Silver;
            this.btnCancelar.Location = new System.Drawing.Point(12, 461);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(191, 34);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(896, 507);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tvProveedores);
            this.Controls.Add(this.listViewProveedores);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.FrmProveedores_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listViewProveedores;
        private TreeView tvProveedores;
        private Button btnCancelar;
    }
}