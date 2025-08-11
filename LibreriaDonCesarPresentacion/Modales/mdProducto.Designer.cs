namespace LibreriaDonCesarPresentacion.Modales
{
    partial class mdProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtescrituraFiltro = new System.Windows.Forms.TextBox();
            this.cmbbusquedaFiltro = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFiltrar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarFiltros = new FontAwesome.Sharp.IconButton();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_SubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtescrituraFiltro
            // 
            this.txtescrituraFiltro.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtescrituraFiltro.Location = new System.Drawing.Point(220, 32);
            this.txtescrituraFiltro.Name = "txtescrituraFiltro";
            this.txtescrituraFiltro.Size = new System.Drawing.Size(128, 20);
            this.txtescrituraFiltro.TabIndex = 51;
            // 
            // cmbbusquedaFiltro
            // 
            this.cmbbusquedaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbusquedaFiltro.FormattingEnabled = true;
            this.cmbbusquedaFiltro.Location = new System.Drawing.Point(100, 31);
            this.cmbbusquedaFiltro.Name = "cmbbusquedaFiltro";
            this.cmbbusquedaFiltro.Size = new System.Drawing.Size(114, 21);
            this.cmbbusquedaFiltro.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(12, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 36);
            this.label7.TabIndex = 49;
            this.label7.Text = "Filtrar por:\r\n ";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Id_Articulo,
            this.Articulo,
            this.Id_Marca,
            this.Marca,
            this.Id_SubCat,
            this.SubCat,
            this.Id_Presentacion,
            this.Presentacion,
            this.Stock});
            this.dgvData.Location = new System.Drawing.Point(-2, 77);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(478, 259);
            this.dgvData.TabIndex = 48;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(-2, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(478, 77);
            this.label6.TabIndex = 47;
            this.label6.Text = "Listado de Productos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnFiltrar.IconColor = System.Drawing.Color.Snow;
            this.btnFiltrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFiltrar.IconSize = 24;
            this.btnFiltrar.Location = new System.Drawing.Point(354, 32);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(47, 23);
            this.btnFiltrar.TabIndex = 53;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatAppearance.BorderSize = 0;
            this.btnLimpiarFiltros.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiarFiltros.IconColor = System.Drawing.Color.Snow;
            this.btnLimpiarFiltros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarFiltros.IconSize = 24;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(416, 32);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(47, 23);
            this.btnLimpiarFiltros.TabIndex = 52;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Id_Articulo
            // 
            this.Id_Articulo.HeaderText = "Id_Articulo";
            this.Id_Articulo.Name = "Id_Articulo";
            this.Id_Articulo.ReadOnly = true;
            this.Id_Articulo.Visible = false;
            this.Id_Articulo.Width = 200;
            // 
            // Articulo
            // 
            this.Articulo.HeaderText = "Nombre";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 90;
            // 
            // Id_Marca
            // 
            this.Id_Marca.HeaderText = "Id_Marca";
            this.Id_Marca.Name = "Id_Marca";
            this.Id_Marca.ReadOnly = true;
            this.Id_Marca.Visible = false;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            // 
            // Id_SubCat
            // 
            this.Id_SubCat.HeaderText = "Id_SubCat";
            this.Id_SubCat.Name = "Id_SubCat";
            this.Id_SubCat.ReadOnly = true;
            this.Id_SubCat.Visible = false;
            // 
            // SubCat
            // 
            this.SubCat.HeaderText = "SubCategoria";
            this.SubCat.Name = "SubCat";
            this.SubCat.ReadOnly = true;
            this.SubCat.Width = 90;
            // 
            // Id_Presentacion
            // 
            this.Id_Presentacion.HeaderText = "Id_Presentacion";
            this.Id_Presentacion.Name = "Id_Presentacion";
            this.Id_Presentacion.ReadOnly = true;
            this.Id_Presentacion.Visible = false;
            // 
            // Presentacion
            // 
            this.Presentacion.HeaderText = "Presentacion";
            this.Presentacion.Name = "Presentacion";
            this.Presentacion.ReadOnly = true;
            this.Presentacion.Width = 90;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // mdProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 373);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.txtescrituraFiltro);
            this.Controls.Add(this.cmbbusquedaFiltro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label6);
            this.Name = "mdProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdProducto";
            this.Load += new System.EventHandler(this.mdProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnFiltrar;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltros;
        private System.Windows.Forms.TextBox txtescrituraFiltro;
        private System.Windows.Forms.ComboBox cmbbusquedaFiltro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_SubCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
    }
}