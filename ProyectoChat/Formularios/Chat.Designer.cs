namespace ProyectoChat
{
    partial class Chat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chat));
            this.metroSetPanel1 = new MetroSet_UI.Controls.MetroSetPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblfecha = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.metroSetButton1 = new MetroSet_UI.Controls.MetroSetButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.metroSetPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroSetPanel1
            // 
            this.metroSetPanel1.BackgroundColor = System.Drawing.Color.White;
            this.metroSetPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.metroSetPanel1.BorderThickness = 1;
            this.metroSetPanel1.Controls.Add(this.button4);
            this.metroSetPanel1.Controls.Add(this.button3);
            this.metroSetPanel1.Controls.Add(this.button2);
            this.metroSetPanel1.Controls.Add(this.button1);
            this.metroSetPanel1.IsDerivedStyle = true;
            this.metroSetPanel1.Location = new System.Drawing.Point(54, 187);
            this.metroSetPanel1.Name = "metroSetPanel1";
            this.metroSetPanel1.Size = new System.Drawing.Size(808, 341);
            this.metroSetPanel1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetPanel1.StyleManager = null;
            this.metroSetPanel1.TabIndex = 4;
            this.metroSetPanel1.ThemeAuthor = "Narwin";
            this.metroSetPanel1.ThemeName = "MetroLite";
            this.metroSetPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.metroSetPanel1_Paint);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Brown;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button4.ForeColor = System.Drawing.Color.Aqua;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(808, 81);
            this.button4.TabIndex = 10;
            this.button4.Text = "      Información Concesionario";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Brown;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button3.ForeColor = System.Drawing.Color.Aqua;
            this.button3.Image = global::ProyectoChat.Properties.Resources.chat_icon_icons_com_67748__1_;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(808, 81);
            this.button3.TabIndex = 9;
            this.button3.Text = "      Chat";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button2.ForeColor = System.Drawing.Color.Aqua;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(808, 80);
            this.button2.TabIndex = 8;
            this.button2.Text = "      Stock";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Aqua;
            this.button1.Image = global::ProyectoChat.Properties.Resources.cooperation_greeting_partnership_deal_agreement_handshake_icon_262591__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(808, 80);
            this.button1.TabIndex = 7;
            this.button1.Text = "      Interesados\r\n";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblfecha
            // 
            this.lblfecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblfecha.AutoSize = true;
            this.lblfecha.BackColor = System.Drawing.Color.Moccasin;
            this.lblfecha.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfecha.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblfecha.Location = new System.Drawing.Point(610, 41);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(161, 21);
            this.lblfecha.TabIndex = 7;
            this.lblfecha.Text = "8 de enero del 2024";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(685, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "11:23:00 p.m";
            // 
            // metroSetButton1
            // 
            this.metroSetButton1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.metroSetButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton1.IsDerivedStyle = true;
            this.metroSetButton1.Location = new System.Drawing.Point(837, 581);
            this.metroSetButton1.Name = "metroSetButton1";
            this.metroSetButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton1.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton1.Size = new System.Drawing.Size(109, 24);
            this.metroSetButton1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetButton1.StyleManager = null;
            this.metroSetButton1.TabIndex = 9;
            this.metroSetButton1.Text = "Cerrar Sesión";
            this.metroSetButton1.ThemeAuthor = "Narwin";
            this.metroSetButton1.ThemeName = "MetroLite";
            this.metroSetButton1.Click += new System.EventHandler(this.metroSetButton1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(420, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 81);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(54, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 89);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 617);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.metroSetButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblfecha);
            this.Controls.Add(this.metroSetPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Chat";
            this.Text = "Chat";
            this.metroSetPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroSet_UI.Controls.MetroSetPanel metroSetPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}