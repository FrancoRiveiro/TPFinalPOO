namespace Trabajo_Final_p1
{
    partial class SistemaViajes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.viajesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.holaToolStripMenuItem,
            this.EmpresaToolStripMenuItem,
            this.LoginToolStripMenuItem,
            this.UsuariosToolStripMenuItem,
            this.viajesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(909, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 29);
            this.inicioToolStripMenuItem.Text = "inicio";
            this.inicioToolStripMenuItem.Click += new System.EventHandler(this.inicioToolStripMenuItem_Click);
            // 
            // holaToolStripMenuItem
            // 
            this.holaToolStripMenuItem.Name = "holaToolStripMenuItem";
            this.holaToolStripMenuItem.Size = new System.Drawing.Size(42, 29);
            this.holaToolStripMenuItem.Text = "hola";
            this.holaToolStripMenuItem.Click += new System.EventHandler(this.holaToolStripMenuItem_Click);
            // 
            // EmpresaToolStripMenuItem
            // 
            this.EmpresaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarEmpresaToolStripMenuItem});
            this.EmpresaToolStripMenuItem.Name = "EmpresaToolStripMenuItem";
            this.EmpresaToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.EmpresaToolStripMenuItem.Text = "Empresa";
            this.EmpresaToolStripMenuItem.Click += new System.EventHandler(this.EmpresaToolStripMenuItem_Click);
            // 
            // gestionarEmpresaToolStripMenuItem
            // 
            this.gestionarEmpresaToolStripMenuItem.Name = "gestionarEmpresaToolStripMenuItem";
            this.gestionarEmpresaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.gestionarEmpresaToolStripMenuItem.Text = "Gestionar ";
            // 
            // LoginToolStripMenuItem
            // 
            this.LoginToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LoginToolStripMenuItem.AutoSize = false;
            this.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem";
            this.LoginToolStripMenuItem.Size = new System.Drawing.Size(74, 29);
            this.LoginToolStripMenuItem.Text = "Login";
            this.LoginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItem_Click);
            // 
            // UsuariosToolStripMenuItem
            // 
            this.UsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarToolStripMenuItem});
            this.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem";
            this.UsuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.UsuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // gestionarToolStripMenuItem
            // 
            this.gestionarToolStripMenuItem.Name = "gestionarToolStripMenuItem";
            this.gestionarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.gestionarToolStripMenuItem.Text = "Gestionar";
            this.gestionarToolStripMenuItem.Click += new System.EventHandler(this.gestionarToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Location = new System.Drawing.Point(0, 31);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.Size = new System.Drawing.Size(909, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // viajesToolStripMenuItem
            // 
            this.viajesToolStripMenuItem.Name = "viajesToolStripMenuItem";
            this.viajesToolStripMenuItem.Size = new System.Drawing.Size(49, 29);
            this.viajesToolStripMenuItem.Text = "Viajes";
            this.viajesToolStripMenuItem.Click += new System.EventHandler(this.viajesToolStripMenuItem_Click);
            // 
            // SistemaViajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(909, 487);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SistemaViajes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Viajes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoginToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestionarEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viajesToolStripMenuItem;
    }
}

