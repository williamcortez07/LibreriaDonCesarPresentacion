namespace LibreriaDonCesarPresentacion
{
    partial class frmReportesCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtfechainicio = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtfechafin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFiltrar = new FontAwesome.Sharp.IconButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApeProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Catidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomSubCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbproveedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnbuscarfiltros = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.txtescrituraFiltro = new System.Windows.Forms.TextBox();
            this.cmbfiltrar = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDescargar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dtfechainicio
            // 
            this.dtfechainicio.CustomFormat = "dd/mm/yyyy";
            this.dtfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfechainicio.Location = new System.Drawing.Point(36, 73);
            this.dtfechainicio.Name = "dtfechainicio";
            this.dtfechainicio.Size = new System.Drawing.Size(102, 20);
            this.dtfechainicio.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(907, 100);
            this.label6.TabIndex = 34;
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 33);
            this.label2.TabIndex = 35;
            this.label2.Text = "Reportes Compras";
            // 
            // dtfechafin
            // 
            this.dtfechafin.CustomFormat = "dd/mm/yyyy";
            this.dtfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfechafin.Location = new System.Drawing.Point(202, 73);
            this.dtfechafin.Name = "dtfechafin";
            this.dtfechafin.Size = new System.Drawing.Size(102, 20);
            this.dtfechafin.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 37;
            this.label1.Text = "Fecha Inicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(199, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Fecha Fin";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFiltrar.FlatAppearance.BorderSize = 2;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnFiltrar.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnFiltrar.IconColor = System.Drawing.Color.Snow;
            this.btnFiltrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFiltrar.IconSize = 20;
            this.btnFiltrar.Location = new System.Drawing.Point(567, 64);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 30);
            this.btnFiltrar.TabIndex = 48;
            this.btnFiltrar.Text = "Buscar";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecharegistro,
            this.NumCompra,
            this.Total,
            this.Usuario,
            this.NomProveedor,
            this.ApeProveedor,
            this.NomProducto,
            this.PrecioC,
            this.PrecioV,
            this.Catidad,
            this.SubTotal,
            this.nomSubCategoria,
            this.nomColor,
            this.nomMarca});
            this.dgvData.Location = new System.Drawing.Point(25, 175);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(845, 332);
            this.dgvData.TabIndex = 51;
            // 
            // fecharegistro
            // 
            this.fecharegistro.HeaderText = "fecharegistro";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            // 
            // NumCompra
            // 
            this.NumCompra.HeaderText = "NumCompra";
            this.NumCompra.Name = "NumCompra";
            this.NumCompra.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // NomProveedor
            // 
            this.NomProveedor.HeaderText = "NomProveedor";
            this.NomProveedor.Name = "NomProveedor";
            this.NomProveedor.ReadOnly = true;
            // 
            // ApeProveedor
            // 
            this.ApeProveedor.HeaderText = "Apellido Proveedor";
            this.ApeProveedor.Name = "ApeProveedor";
            this.ApeProveedor.ReadOnly = true;
            // 
            // NomProducto
            // 
            this.NomProducto.HeaderText = "Nombre Producto";
            this.NomProducto.Name = "NomProducto";
            this.NomProducto.ReadOnly = true;
            // 
            // PrecioC
            // 
            this.PrecioC.HeaderText = "Precio Compra";
            this.PrecioC.Name = "PrecioC";
            this.PrecioC.ReadOnly = true;
            // 
            // PrecioV
            // 
            this.PrecioV.HeaderText = "Precio Venta";
            this.PrecioV.Name = "PrecioV";
            this.PrecioV.ReadOnly = true;
            // 
            // Catidad
            // 
            this.Catidad.HeaderText = "Cantidad";
            this.Catidad.Name = "Catidad";
            this.Catidad.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // nomSubCategoria
            // 
            this.nomSubCategoria.HeaderText = "SubCategoria";
            this.nomSubCategoria.Name = "nomSubCategoria";
            this.nomSubCategoria.ReadOnly = true;
            // 
            // nomColor
            // 
            this.nomColor.HeaderText = "Color";
            this.nomColor.Name = "nomColor";
            this.nomColor.ReadOnly = true;
            // 
            // nomMarca
            // 
            this.nomMarca.HeaderText = "Marca";
            this.nomMarca.Name = "nomMarca";
            this.nomMarca.ReadOnly = true;
            // 
            // cmbproveedor
            // 
            this.cmbproveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproveedor.FormattingEnabled = true;
            this.cmbproveedor.Location = new System.Drawing.Point(375, 76);
            this.cmbproveedor.Name = "cmbproveedor";
            this.cmbproveedor.Size = new System.Drawing.Size(168, 21);
            this.cmbproveedor.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(372, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "Proveedor";
            // 
            // btnbuscarfiltros
            // 
            this.btnbuscarfiltros.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnbuscarfiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarfiltros.FlatAppearance.BorderSize = 0;
            this.btnbuscarfiltros.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.btnbuscarfiltros.IconColor = System.Drawing.Color.Snow;
            this.btnbuscarfiltros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarfiltros.IconSize = 24;
            this.btnbuscarfiltros.Location = new System.Drawing.Point(747, 133);
            this.btnbuscarfiltros.Name = "btnbuscarfiltros";
            this.btnbuscarfiltros.Size = new System.Drawing.Size(47, 23);
            this.btnbuscarfiltros.TabIndex = 58;
            this.btnbuscarfiltros.UseVisualStyleBackColor = false;
            this.btnbuscarfiltros.Click += new System.EventHandler(this.btnbuscarfiltros_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderSize = 0;
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.Snow;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 24;
            this.btnlimpiar.Location = new System.Drawing.Point(819, 133);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(47, 23);
            this.btnlimpiar.TabIndex = 57;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // txtescrituraFiltro
            // 
            this.txtescrituraFiltro.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtescrituraFiltro.Location = new System.Drawing.Point(527, 134);
            this.txtescrituraFiltro.Name = "txtescrituraFiltro";
            this.txtescrituraFiltro.Size = new System.Drawing.Size(178, 20);
            this.txtescrituraFiltro.TabIndex = 56;
            // 
            // cmbfiltrar
            // 
            this.cmbfiltrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfiltrar.FormattingEnabled = true;
            this.cmbfiltrar.Location = new System.Drawing.Point(369, 135);
            this.cmbfiltrar.Name = "cmbfiltrar";
            this.cmbfiltrar.Size = new System.Drawing.Size(114, 21);
            this.cmbfiltrar.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(268, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 36);
            this.label7.TabIndex = 54;
            this.label7.Text = "Filtrar por:\r\n ";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(12, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(907, 398);
            this.label5.TabIndex = 59;
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDescargar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnDescargar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnDescargar.IconColor = System.Drawing.Color.DarkGreen;
            this.btnDescargar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDescargar.IconSize = 25;
            this.btnDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargar.Location = new System.Drawing.Point(27, 138);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(111, 31);
            this.btnDescargar.TabIndex = 61;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // frmReportesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 527);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.btnbuscarfiltros);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.txtescrituraFiltro);
            this.Controls.Add(this.cmbfiltrar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbproveedor);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtfechafin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtfechainicio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "frmReportesCompras";
            this.Text = "frmReportesCompras";
            this.Load += new System.EventHandler(this.frmReportesCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtfechainicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtfechafin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnFiltrar;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ComboBox cmbproveedor;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnbuscarfiltros;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private System.Windows.Forms.TextBox txtescrituraFiltro;
        private System.Windows.Forms.ComboBox cmbfiltrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnDescargar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApeProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Catidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomSubCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomMarca;
    }
}