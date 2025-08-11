namespace LibreriaDonCesarPresentacion
{
    partial class frmProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIndice = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarFiltros = new FontAwesome.Sharp.IconButton();
            this.txtescrituraFiltro = new System.Windows.Forms.TextBox();
            this.cmbbusquedaFiltro = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_SubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbArticulo = new System.Windows.Forms.ComboBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.cmbSubCat = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.btnDescargar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Snow;
            this.label9.Location = new System.Drawing.Point(219, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 14);
            this.label9.TabIndex = 49;
            this.label9.Text = "ID";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Snow;
            this.label8.Location = new System.Drawing.Point(219, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 14);
            this.label8.TabIndex = 48;
            this.label8.Text = "Index";
            this.label8.Visible = false;
            // 
            // txtIndice
            // 
            this.txtIndice.Location = new System.Drawing.Point(257, 10);
            this.txtIndice.Name = "txtIndice";
            this.txtIndice.Size = new System.Drawing.Size(27, 20);
            this.txtIndice.TabIndex = 47;
            this.txtIndice.Text = "-1";
            this.txtIndice.Visible = false;
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
            this.btnFiltrar.Location = new System.Drawing.Point(766, 52);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(47, 23);
            this.btnFiltrar.TabIndex = 46;
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
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(836, 52);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(47, 23);
            this.btnLimpiarFiltros.TabIndex = 45;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // txtescrituraFiltro
            // 
            this.txtescrituraFiltro.Font = new System.Drawing.Font("Modern No. 20", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtescrituraFiltro.Location = new System.Drawing.Point(546, 52);
            this.txtescrituraFiltro.Name = "txtescrituraFiltro";
            this.txtescrituraFiltro.Size = new System.Drawing.Size(178, 20);
            this.txtescrituraFiltro.TabIndex = 44;
            // 
            // cmbbusquedaFiltro
            // 
            this.cmbbusquedaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbusquedaFiltro.FormattingEnabled = true;
            this.cmbbusquedaFiltro.Location = new System.Drawing.Point(417, 53);
            this.cmbbusquedaFiltro.Name = "cmbbusquedaFiltro";
            this.cmbbusquedaFiltro.Size = new System.Drawing.Size(114, 21);
            this.cmbbusquedaFiltro.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(316, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 36);
            this.label7.TabIndex = 42;
            this.label7.Text = "Filtrar por:\r\n ";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(257, 36);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(27, 20);
            this.txtId.TabIndex = 41;
            this.txtId.Text = "0";
            this.txtId.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.Blue;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Blue;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 24;
            this.btnLimpiar.Location = new System.Drawing.Point(22, 453);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(251, 35);
            this.btnLimpiar.TabIndex = 39;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.Snow;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btnEliminar.IconColor = System.Drawing.Color.Snow;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 24;
            this.btnEliminar.Location = new System.Drawing.Point(21, 494);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(252, 35);
            this.btnEliminar.TabIndex = 38;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Snow;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnGuardar.IconColor = System.Drawing.Color.AliceBlue;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 24;
            this.btnGuardar.Location = new System.Drawing.Point(22, 412);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(251, 35);
            this.btnGuardar.TabIndex = 37;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnSeleccionar,
            this.Id,
            this.Id_Articulo,
            this.Articulo,
            this.Id_Marca,
            this.Marca,
            this.Id_Color,
            this.Color,
            this.Id_SubCat,
            this.SubCat,
            this.Id_Presentacion,
            this.Presentacion,
            this.Descripcion});
            this.dgvData.Location = new System.Drawing.Point(301, 130);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvData.RowTemplate.Height = 28;
            this.dgvData.Size = new System.Drawing.Size(635, 391);
            this.dgvData.TabIndex = 36;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick);
            this.dgvData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvData_CellPainting);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.HeaderText = "";
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.ReadOnly = true;
            this.btnSeleccionar.Width = 50;
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
            this.Articulo.HeaderText = "Articulo";
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
            this.Marca.Width = 90;
            // 
            // Id_Color
            // 
            this.Id_Color.HeaderText = "Id_Color";
            this.Id_Color.Name = "Id_Color";
            this.Id_Color.ReadOnly = true;
            this.Id_Color.Visible = false;
            // 
            // Color
            // 
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Width = 80;
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
            this.Presentacion.Width = 80;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 110;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Snow;
            this.label6.Location = new System.Drawing.Point(301, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(635, 124);
            this.label6.TabIndex = 33;
            this.label6.Text = "Listado de Productos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(18, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 24);
            this.label5.TabIndex = 32;
            this.label5.Text = "SubCategoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Snow;
            this.label4.Location = new System.Drawing.Point(18, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 24);
            this.label4.TabIndex = 31;
            this.label4.Text = "Artículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(22, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 33);
            this.label2.TabIndex = 29;
            this.label2.Text = "Agregar Productos";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 533);
            this.label1.TabIndex = 28;
            // 
            // cmbArticulo
            // 
            this.cmbArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArticulo.FormattingEnabled = true;
            this.cmbArticulo.Location = new System.Drawing.Point(18, 93);
            this.cmbArticulo.Name = "cmbArticulo";
            this.cmbArticulo.Size = new System.Drawing.Size(256, 21);
            this.cmbArticulo.TabIndex = 50;
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(20, 204);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(253, 21);
            this.cmbColor.TabIndex = 51;
            // 
            // cmbPresentacion
            // 
            this.cmbPresentacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Location = new System.Drawing.Point(18, 310);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(256, 21);
            this.cmbPresentacion.TabIndex = 52;
            // 
            // cmbSubCat
            // 
            this.cmbSubCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubCat.FormattingEnabled = true;
            this.cmbSubCat.Location = new System.Drawing.Point(20, 259);
            this.cmbSubCat.Name = "cmbSubCat";
            this.cmbSubCat.Size = new System.Drawing.Size(254, 21);
            this.cmbSubCat.TabIndex = 53;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(18, 367);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(256, 25);
            this.txtDescripcion.TabIndex = 54;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Snow;
            this.label10.Location = new System.Drawing.Point(18, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 24);
            this.label10.TabIndex = 55;
            this.label10.Text = "Color";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Snow;
            this.label11.Location = new System.Drawing.Point(18, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 24);
            this.label11.TabIndex = 56;
            this.label11.Text = "Presentación";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label12.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Snow;
            this.label12.Location = new System.Drawing.Point(18, 340);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 24);
            this.label12.TabIndex = 57;
            this.label12.Text = "Descripción";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Snow;
            this.label13.Location = new System.Drawing.Point(18, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 24);
            this.label13.TabIndex = 59;
            this.label13.Text = "Marca";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(18, 150);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(256, 21);
            this.cmbMarca.TabIndex = 58;
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
            this.btnDescargar.Location = new System.Drawing.Point(319, 93);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(111, 31);
            this.btnDescargar.TabIndex = 60;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // frmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 533);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.cmbSubCat);
            this.Controls.Add(this.cmbPresentacion);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.cmbArticulo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIndice);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.txtescrituraFiltro);
            this.Controls.Add(this.cmbbusquedaFiltro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmProductos";
            this.Text = "frmProductos";
            this.Load += new System.EventHandler(this.frmProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIndice;
        private FontAwesome.Sharp.IconButton btnFiltrar;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltros;
        private System.Windows.Forms.TextBox txtescrituraFiltro;
        private System.Windows.Forms.ComboBox cmbbusquedaFiltro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbArticulo;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbPresentacion;
        private System.Windows.Forms.ComboBox cmbSubCat;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewButtonColumn btnSeleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_SubCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbMarca;
        private FontAwesome.Sharp.IconButton btnDescargar;
    }
}