﻿namespace Trabajo_Final_p1.Forms
{
    partial class GestorEmpresa
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
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textDire = new System.Windows.Forms.TextBox();
            this.textCodPos = new System.Windows.Forms.TextBox();
            this.textNom = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 373);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 27);
            this.button2.TabIndex = 29;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "CodigoPostal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 145);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 252);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Direccion";
            // 
            // textDire
            // 
            this.textDire.Location = new System.Drawing.Point(150, 250);
            this.textDire.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDire.Name = "textDire";
            this.textDire.Size = new System.Drawing.Size(112, 20);
            this.textDire.TabIndex = 21;
            // 
            // textCodPos
            // 
            this.textCodPos.Location = new System.Drawing.Point(150, 190);
            this.textCodPos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textCodPos.Name = "textCodPos";
            this.textCodPos.Size = new System.Drawing.Size(112, 20);
            this.textCodPos.TabIndex = 20;
            // 
            // textNom
            // 
            this.textNom.Location = new System.Drawing.Point(150, 141);
            this.textNom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textNom.Name = "textNom";
            this.textNom.Size = new System.Drawing.Size(112, 20);
            this.textNom.TabIndex = 19;
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(150, 90);
            this.textId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(112, 20);
            this.textId.TabIndex = 18;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(87, 373);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(59, 27);
            this.btnAceptar.TabIndex = 32;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            
            this.btnAceptar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bntAceptar_MouseDown);
            // 
            // GestorEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 421);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textDire);
            this.Controls.Add(this.textCodPos);
            this.Controls.Add(this.textNom);
            this.Controls.Add(this.textId);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GestorEmpresa";
            this.Text = "GestorEmpresa";
            this.Load += new System.EventHandler(this.GestorEmpresa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textDire;
        private System.Windows.Forms.TextBox textCodPos;
        private System.Windows.Forms.TextBox textNom;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Button btnAceptar;
    }
}