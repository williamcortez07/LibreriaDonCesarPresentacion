namespace LibreriaDonCesarPresentacion
{
    partial class inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuprincipal = new System.Windows.Forms.MenuStrip();
            this.menuInventario = new FontAwesome.Sharp.IconMenuItem();
            this.artículosToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuProduto = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuStock = new FontAwesome.Sharp.IconMenuItem();
            this.submenubaja = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuatributos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClasificacion = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuSubCategoria = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuPresentacion = new FontAwesome.Sharp.IconMenuItem();
            this.menuOperaciones = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuRegistraCompras = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuDetalleCompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenuventas = new System.Windows.Forms.ToolStripMenuItem();
            this.submenuproveedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.submenureportesCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.submenureportesVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdministracion = new FontAwesome.Sharp.IconMenuItem();
            this.submenuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.submenunegocio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDocumentacion = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.panelmostrarTodo = new System.Windows.Forms.Panel();
            this.submenuregistrarventas = new System.Windows.Forms.ToolStripMenuItem();
            this.submenudetallesventas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuprincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuprincipal
            // 
            this.menuprincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.menuprincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuprincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInventario,
            this.menuClasificacion,
            this.menuOperaciones,
            this.menuReportes,
            this.menuAdministracion,
            this.menuDocumentacion});
            this.menuprincipal.Location = new System.Drawing.Point(0, 96);
            this.menuprincipal.Name = "menuprincipal";
            this.menuprincipal.Size = new System.Drawing.Size(128, 533);
            this.menuprincipal.TabIndex = 0;
            this.menuprincipal.Text = "menuStrip1";
            // 
            // menuInventario
            // 
            this.menuInventario.AutoSize = false;
            this.menuInventario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.menuInventario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artículosToolStripMenuItem,
            this.subMenuProduto,
            this.subMenuStock,
            this.submenubaja,
            this.submenuatributos});
            this.menuInventario.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuInventario.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuInventario.IconChar = FontAwesome.Sharp.IconChar.BoxesPacking;
            this.menuInventario.IconColor = System.Drawing.Color.Silver;
            this.menuInventario.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.menuInventario.IconSize = 70;
            this.menuInventario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.menuInventario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuInventario.MergeIndex = 0;
            this.menuInventario.Name = "menuInventario";
            this.menuInventario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuInventario.Size = new System.Drawing.Size(122, 85);
            this.menuInventario.Text = "Inventario";
            this.menuInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuInventario.Click += new System.EventHandler(this.menuInventario_Click);
            // 
            // artículosToolStripMenuItem
            // 
            this.artículosToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.artículosToolStripMenuItem.IconColor = System.Drawing.Color.Black;
            this.artículosToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.artículosToolStripMenuItem.Name = "artículosToolStripMenuItem";
            this.artículosToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.artículosToolStripMenuItem.Text = "Artículos";
            this.artículosToolStripMenuItem.Click += new System.EventHandler(this.artículosToolStripMenuItem_Click);
            // 
            // subMenuProduto
            // 
            this.subMenuProduto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuProduto.IconColor = System.Drawing.Color.Black;
            this.subMenuProduto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuProduto.Name = "subMenuProduto";
            this.subMenuProduto.Size = new System.Drawing.Size(226, 26);
            this.subMenuProduto.Text = "Productos";
            this.subMenuProduto.Click += new System.EventHandler(this.subMenuProduto_Click);
            // 
            // subMenuStock
            // 
            this.subMenuStock.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuStock.IconColor = System.Drawing.Color.Black;
            this.subMenuStock.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuStock.Name = "subMenuStock";
            this.subMenuStock.Size = new System.Drawing.Size(226, 26);
            this.subMenuStock.Text = "Stock";
            this.subMenuStock.Click += new System.EventHandler(this.subMenuStock_Click);
            // 
            // submenubaja
            // 
            this.submenubaja.Name = "submenubaja";
            this.submenubaja.Size = new System.Drawing.Size(226, 26);
            this.submenubaja.Text = "Baja de Inventario";
            this.submenubaja.Click += new System.EventHandler(this.submenubaja_Click);
            // 
            // submenuatributos
            // 
            this.submenuatributos.Name = "submenuatributos";
            this.submenuatributos.Size = new System.Drawing.Size(226, 26);
            this.submenuatributos.Text = "Atributos";
            this.submenuatributos.Click += new System.EventHandler(this.submenuatributos_Click);
            // 
            // menuClasificacion
            // 
            this.menuClasificacion.AutoSize = false;
            this.menuClasificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.menuClasificacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuCategoria,
            this.subMenuSubCategoria,
            this.SubMenuPresentacion});
            this.menuClasificacion.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuClasificacion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuClasificacion.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuClasificacion.IconColor = System.Drawing.Color.Silver;
            this.menuClasificacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuClasificacion.IconSize = 70;
            this.menuClasificacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuClasificacion.Name = "menuClasificacion";
            this.menuClasificacion.Size = new System.Drawing.Size(122, 85);
            this.menuClasificacion.Text = "Clasificaciones";
            this.menuClasificacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuClasificacion.Click += new System.EventHandler(this.iconMenuItem6_Click);
            // 
            // subMenuCategoria
            // 
            this.subMenuCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuCategoria.IconColor = System.Drawing.Color.Black;
            this.subMenuCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuCategoria.Name = "subMenuCategoria";
            this.subMenuCategoria.Size = new System.Drawing.Size(192, 26);
            this.subMenuCategoria.Text = "Categoria";
            this.subMenuCategoria.Click += new System.EventHandler(this.iconMenuItem7_Click);
            // 
            // subMenuSubCategoria
            // 
            this.subMenuSubCategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuSubCategoria.IconColor = System.Drawing.Color.Black;
            this.subMenuSubCategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuSubCategoria.Name = "subMenuSubCategoria";
            this.subMenuSubCategoria.Size = new System.Drawing.Size(192, 26);
            this.subMenuSubCategoria.Text = "SubCategoria";
            this.subMenuSubCategoria.Click += new System.EventHandler(this.subMenuSubCategoria_Click);
            // 
            // SubMenuPresentacion
            // 
            this.SubMenuPresentacion.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuPresentacion.IconColor = System.Drawing.Color.Black;
            this.SubMenuPresentacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuPresentacion.Name = "SubMenuPresentacion";
            this.SubMenuPresentacion.Size = new System.Drawing.Size(192, 26);
            this.SubMenuPresentacion.Text = "presentaciones";
            this.SubMenuPresentacion.Click += new System.EventHandler(this.SubMenuPresentacion_Click);
            // 
            // menuOperaciones
            // 
            this.menuOperaciones.AutoSize = false;
            this.menuOperaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.menuOperaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuCompras,
            this.submenuventas,
            this.submenuproveedores});
            this.menuOperaciones.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuOperaciones.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuOperaciones.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menuOperaciones.IconColor = System.Drawing.Color.Silver;
            this.menuOperaciones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuOperaciones.IconSize = 70;
            this.menuOperaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuOperaciones.Name = "menuOperaciones";
            this.menuOperaciones.Size = new System.Drawing.Size(122, 85);
            this.menuOperaciones.Text = "Operaciones";
            this.menuOperaciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // subMenuCompras
            // 
            this.subMenuCompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuRegistraCompras,
            this.subMenuDetalleCompras});
            this.subMenuCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuCompras.IconColor = System.Drawing.Color.Black;
            this.subMenuCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuCompras.Name = "subMenuCompras";
            this.subMenuCompras.Size = new System.Drawing.Size(180, 26);
            this.subMenuCompras.Text = "Compras";
            // 
            // submenuRegistraCompras
            // 
            this.submenuRegistraCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuRegistraCompras.IconColor = System.Drawing.Color.Black;
            this.submenuRegistraCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuRegistraCompras.Name = "submenuRegistraCompras";
            this.submenuRegistraCompras.Size = new System.Drawing.Size(240, 26);
            this.submenuRegistraCompras.Text = "Registrar Compras";
            this.submenuRegistraCompras.Click += new System.EventHandler(this.submenuRegistraCompras_Click);
            // 
            // subMenuDetalleCompras
            // 
            this.subMenuDetalleCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.subMenuDetalleCompras.IconColor = System.Drawing.Color.Black;
            this.subMenuDetalleCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuDetalleCompras.Name = "subMenuDetalleCompras";
            this.subMenuDetalleCompras.Size = new System.Drawing.Size(221, 26);
            this.subMenuDetalleCompras.Text = "Ver detalles ";
            this.subMenuDetalleCompras.Click += new System.EventHandler(this.subMenuDetalleCompras_Click);
            // 
            // submenuventas
            // 
            this.submenuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarventas,
            this.submenudetallesventas});
            this.submenuventas.Name = "submenuventas";
            this.submenuventas.Size = new System.Drawing.Size(180, 26);
            this.submenuventas.Text = "Ventas";
            // 
            // submenuproveedores
            // 
            this.submenuproveedores.Name = "submenuproveedores";
            this.submenuproveedores.Size = new System.Drawing.Size(180, 26);
            this.submenuproveedores.Text = "Proveedores";
            this.submenuproveedores.Click += new System.EventHandler(this.submenuproveedores_Click_1);
            // 
            // menuReportes
            // 
            this.menuReportes.AutoSize = false;
            this.menuReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.menuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenureportesCompras,
            this.submenureportesVentas});
            this.menuReportes.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuReportes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuReportes.IconChar = FontAwesome.Sharp.IconChar.ArrowTrendUp;
            this.menuReportes.IconColor = System.Drawing.Color.Silver;
            this.menuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuReportes.IconSize = 70;
            this.menuReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuReportes.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.menuReportes.Name = "menuReportes";
            this.menuReportes.Size = new System.Drawing.Size(122, 85);
            this.menuReportes.Text = "Reportes";
            this.menuReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenureportesCompras
            // 
            this.submenureportesCompras.Name = "submenureportesCompras";
            this.submenureportesCompras.Size = new System.Drawing.Size(217, 26);
            this.submenureportesCompras.Text = "Reportes Compras";
            this.submenureportesCompras.Click += new System.EventHandler(this.submenureportesCompras_Click);
            // 
            // submenureportesVentas
            // 
            this.submenureportesVentas.Name = "submenureportesVentas";
            this.submenureportesVentas.Size = new System.Drawing.Size(217, 26);
            this.submenureportesVentas.Text = "Reportes Ventas";
            this.submenureportesVentas.Click += new System.EventHandler(this.submenureportesVentas_Click);
            // 
            // menuAdministracion
            // 
            this.menuAdministracion.AutoSize = false;
            this.menuAdministracion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.menuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuUsuarios,
            this.submenunegocio});
            this.menuAdministracion.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuAdministracion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuAdministracion.IconChar = FontAwesome.Sharp.IconChar.Folder;
            this.menuAdministracion.IconColor = System.Drawing.Color.Silver;
            this.menuAdministracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuAdministracion.IconSize = 70;
            this.menuAdministracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuAdministracion.Name = "menuAdministracion";
            this.menuAdministracion.Size = new System.Drawing.Size(122, 85);
            this.menuAdministracion.Text = "Administración";
            this.menuAdministracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuUsuarios
            // 
            this.submenuUsuarios.Name = "submenuUsuarios";
            this.submenuUsuarios.Size = new System.Drawing.Size(180, 26);
            this.submenuUsuarios.Text = "Usuarios";
            this.submenuUsuarios.Click += new System.EventHandler(this.submenuUsuarios_Click_1);
            // 
            // submenunegocio
            // 
            this.submenunegocio.Name = "submenunegocio";
            this.submenunegocio.Size = new System.Drawing.Size(180, 26);
            this.submenunegocio.Text = "Negocio";
            this.submenunegocio.Click += new System.EventHandler(this.submenunegocio_Click);
            // 
            // menuDocumentacion
            // 
            this.menuDocumentacion.AutoSize = false;
            this.menuDocumentacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.menuDocumentacion.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuDocumentacion.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.menuDocumentacion.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.menuDocumentacion.IconColor = System.Drawing.Color.Silver;
            this.menuDocumentacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuDocumentacion.IconSize = 70;
            this.menuDocumentacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuDocumentacion.Name = "menuDocumentacion";
            this.menuDocumentacion.Size = new System.Drawing.Size(122, 85);
            this.menuDocumentacion.Text = "Read";
            this.menuDocumentacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuDocumentacion.Click += new System.EventHandler(this.iconMenuItem1_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.AutoSize = false;
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1112, 96);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Libreria Don César";
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Mongolian Baiti", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(40)))));
            this.lblNombreUsuario.Location = new System.Drawing.Point(942, 38);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(153, 21);
            this.lblNombreUsuario.TabIndex = 4;
            this.lblNombreUsuario.Text = "NombreUsuario";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.User;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ButtonFace;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(907, 32);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 5;
            this.iconPictureBox1.TabStop = false;
            // 
            // panelmostrarTodo
            // 
            this.panelmostrarTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelmostrarTodo.Location = new System.Drawing.Point(128, 96);
            this.panelmostrarTodo.Name = "panelmostrarTodo";
            this.panelmostrarTodo.Size = new System.Drawing.Size(984, 533);
            this.panelmostrarTodo.TabIndex = 6;
            // 
            // submenuregistrarventas
            // 
            this.submenuregistrarventas.Name = "submenuregistrarventas";
            this.submenuregistrarventas.Size = new System.Drawing.Size(197, 26);
            this.submenuregistrarventas.Text = "Registrar venta";
            this.submenuregistrarventas.Click += new System.EventHandler(this.submenuregistrarventas_Click);
            // 
            // submenudetallesventas
            // 
            this.submenudetallesventas.Name = "submenudetallesventas";
            this.submenudetallesventas.Size = new System.Drawing.Size(197, 26);
            this.submenudetallesventas.Text = "Ver detalles";
            this.submenudetallesventas.Click += new System.EventHandler(this.submenudetallesventas_Click);
            // 
            // inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 629);
            this.Controls.Add(this.panelmostrarTodo);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuprincipal);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuprincipal;
            this.Name = "inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.inicio_Load);
            this.menuprincipal.ResumeLayout(false);
            this.menuprincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuprincipal;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private FontAwesome.Sharp.IconMenuItem menuInventario;
        private FontAwesome.Sharp.IconMenuItem subMenuProduto;
        private FontAwesome.Sharp.IconMenuItem subMenuStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombreUsuario;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconMenuItem menuClasificacion;
        private FontAwesome.Sharp.IconMenuItem subMenuCategoria;
        private FontAwesome.Sharp.IconMenuItem subMenuSubCategoria;
        private FontAwesome.Sharp.IconMenuItem SubMenuPresentacion;
        private FontAwesome.Sharp.IconMenuItem menuOperaciones;
        private FontAwesome.Sharp.IconMenuItem artículosToolStripMenuItem;
        private System.Windows.Forms.Panel panelmostrarTodo;
        private FontAwesome.Sharp.IconMenuItem menuReportes;
        private FontAwesome.Sharp.IconMenuItem menuDocumentacion;
        private FontAwesome.Sharp.IconMenuItem subMenuCompras;
        private FontAwesome.Sharp.IconMenuItem submenuRegistraCompras;
        private FontAwesome.Sharp.IconMenuItem subMenuDetalleCompras;
        private System.Windows.Forms.ToolStripMenuItem submenureportesCompras;
        private System.Windows.Forms.ToolStripMenuItem submenureportesVentas;
        private System.Windows.Forms.ToolStripMenuItem submenubaja;
        private System.Windows.Forms.ToolStripMenuItem submenuatributos;
        private System.Windows.Forms.ToolStripMenuItem submenuventas;
        private System.Windows.Forms.ToolStripMenuItem submenuproveedores;
        private FontAwesome.Sharp.IconMenuItem menuAdministracion;
        private System.Windows.Forms.ToolStripMenuItem submenuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem submenunegocio;
        private System.Windows.Forms.ToolStripMenuItem submenuregistrarventas;
        private System.Windows.Forms.ToolStripMenuItem submenudetallesventas;
    }
}

