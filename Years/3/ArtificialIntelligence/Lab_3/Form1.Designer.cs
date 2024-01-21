namespace Lab_2
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.опціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розмірСтеркиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маленькаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.середняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.великаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розмірОлівцяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вийтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вийтиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.вийтиToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button_Recognition = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button_Pencil = new System.Windows.Forms.Button();
            this.button_Eraser = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.опціїToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(412, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // опціїToolStripMenuItem
            // 
            this.опціїToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.розмірСтеркиToolStripMenuItem,
            this.розмірОлівцяToolStripMenuItem,
            this.зберегтиToolStripMenuItem,
            this.вийтиToolStripMenuItem,
            this.вийтиToolStripMenuItem1,
            this.вийтиToolStripMenuItem2});
            this.опціїToolStripMenuItem.Name = "опціїToolStripMenuItem";
            this.опціїToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.опціїToolStripMenuItem.Text = "Опції";
            // 
            // розмірСтеркиToolStripMenuItem
            // 
            this.розмірСтеркиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.маленькаToolStripMenuItem,
            this.середняToolStripMenuItem,
            this.великаToolStripMenuItem});
            this.розмірСтеркиToolStripMenuItem.Name = "розмірСтеркиToolStripMenuItem";
            this.розмірСтеркиToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.розмірСтеркиToolStripMenuItem.Text = "Розмір стерки";
            // 
            // маленькаToolStripMenuItem
            // 
            this.маленькаToolStripMenuItem.Name = "маленькаToolStripMenuItem";
            this.маленькаToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.маленькаToolStripMenuItem.Text = "Маленька";
            this.маленькаToolStripMenuItem.Click += new System.EventHandler(this.маленькаToolStripMenuItem_Click);
            // 
            // середняToolStripMenuItem
            // 
            this.середняToolStripMenuItem.Name = "середняToolStripMenuItem";
            this.середняToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.середняToolStripMenuItem.Text = "Середня";
            this.середняToolStripMenuItem.Click += new System.EventHandler(this.середняToolStripMenuItem_Click);
            // 
            // великаToolStripMenuItem
            // 
            this.великаToolStripMenuItem.Name = "великаToolStripMenuItem";
            this.великаToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.великаToolStripMenuItem.Text = "Велика";
            this.великаToolStripMenuItem.Click += new System.EventHandler(this.великаToolStripMenuItem_Click);
            // 
            // розмірОлівцяToolStripMenuItem
            // 
            this.розмірОлівцяToolStripMenuItem.Name = "розмірОлівцяToolStripMenuItem";
            this.розмірОлівцяToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.розмірОлівцяToolStripMenuItem.Text = "Товщина олівця";
            this.розмірОлівцяToolStripMenuItem.Click += new System.EventHandler(this.розмірОлівцяToolStripMenuItem_Click);
            // 
            // зберегтиToolStripMenuItem
            // 
            this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
            this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.зберегтиToolStripMenuItem.Text = "Колір олівця";
            this.зберегтиToolStripMenuItem.Click += new System.EventHandler(this.зберегтиToolStripMenuItem_Click);
            // 
            // вийтиToolStripMenuItem
            // 
            this.вийтиToolStripMenuItem.Name = "вийтиToolStripMenuItem";
            this.вийтиToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.вийтиToolStripMenuItem.Text = "Коефіцієнт швидкості навчання";
            this.вийтиToolStripMenuItem.Click += new System.EventHandler(this.вийтиToolStripMenuItem_Click);
            // 
            // вийтиToolStripMenuItem1
            // 
            this.вийтиToolStripMenuItem1.Name = "вийтиToolStripMenuItem1";
            this.вийтиToolStripMenuItem1.Size = new System.Drawing.Size(249, 22);
            this.вийтиToolStripMenuItem1.Text = "Зберегти";
            this.вийтиToolStripMenuItem1.Click += new System.EventHandler(this.вийтиToolStripMenuItem1_Click);
            // 
            // вийтиToolStripMenuItem2
            // 
            this.вийтиToolStripMenuItem2.Name = "вийтиToolStripMenuItem2";
            this.вийтиToolStripMenuItem2.Size = new System.Drawing.Size(249, 22);
            this.вийтиToolStripMenuItem2.Text = "Вийти";
            this.вийтиToolStripMenuItem2.Click += new System.EventHandler(this.вийтиToolStripMenuItem2_Click);
            // 
            // button_Recognition
            // 
            this.button_Recognition.Location = new System.Drawing.Point(100, 372);
            this.button_Recognition.Name = "button_Recognition";
            this.button_Recognition.Size = new System.Drawing.Size(200, 50);
            this.button_Recognition.TabIndex = 2;
            this.button_Recognition.Text = "Розпізнати";
            this.button_Recognition.UseVisualStyleBackColor = true;
            this.button_Recognition.Click += new System.EventHandler(this.button_Recognition_Click);
            // 
            // button_Pencil
            // 
            this.button_Pencil.BackgroundImage = global::Lab_2.Properties.Resources.pencil;
            this.button_Pencil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Pencil.Location = new System.Drawing.Point(306, 178);
            this.button_Pencil.Name = "button_Pencil";
            this.button_Pencil.Size = new System.Drawing.Size(50, 50);
            this.button_Pencil.TabIndex = 5;
            this.button_Pencil.UseVisualStyleBackColor = true;
            this.button_Pencil.Click += new System.EventHandler(this.button_Pencil_Click);
            // 
            // button_Eraser
            // 
            this.button_Eraser.BackgroundImage = global::Lab_2.Properties.Resources.eraser;
            this.button_Eraser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Eraser.Location = new System.Drawing.Point(306, 122);
            this.button_Eraser.Name = "button_Eraser";
            this.button_Eraser.Size = new System.Drawing.Size(50, 50);
            this.button_Eraser.TabIndex = 4;
            this.button_Eraser.UseVisualStyleBackColor = true;
            this.button_Eraser.Click += new System.EventHandler(this.button_Eraser_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.BackgroundImage = global::Lab_2.Properties.Resources.clear;
            this.button_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Clear.Location = new System.Drawing.Point(306, 66);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(50, 50);
            this.button_Clear.TabIndex = 3;
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(100, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 300);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form_Main
            // 
            this.AcceptButton = this.button_Pencil;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 461);
            this.Controls.Add(this.button_Pencil);
            this.Controls.Add(this.button_Eraser);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Recognition);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Розпізнавання літер латинського алфавіту";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Main_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem опціїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розмірСтеркиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розмірОлівцяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Recognition;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Eraser;
        private System.Windows.Forms.Button button_Pencil;
        private System.Windows.Forms.ToolStripMenuItem маленькаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem середняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem великаToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem2;
    }
}

