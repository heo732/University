namespace Lab_2
{
    partial class Form_Recognition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Recognition));
            this.button_Wrong = new System.Windows.Forms.Button();
            this.button_Right = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Wrong
            // 
            this.button_Wrong.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Wrong.Location = new System.Drawing.Point(144, 384);
            this.button_Wrong.Name = "button_Wrong";
            this.button_Wrong.Size = new System.Drawing.Size(92, 35);
            this.button_Wrong.TabIndex = 4;
            this.button_Wrong.Text = "Невірно";
            this.button_Wrong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Wrong.UseVisualStyleBackColor = true;
            this.button_Wrong.Click += new System.EventHandler(this.button_Wrong_Click);
            // 
            // button_Right
            // 
            this.button_Right.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Right.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Right.Location = new System.Drawing.Point(36, 384);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(92, 35);
            this.button_Right.TabIndex = 3;
            this.button_Right.Text = "Вірно";
            this.button_Right.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Right.UseVisualStyleBackColor = true;
            this.button_Right.Click += new System.EventHandler(this.button_Right_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Lab_2.Properties.Resources.wrong;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(202, 390);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.button_Wrong_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Lab_2.Properties.Resources.right;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(92, 390);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 25);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.button_Right_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(36, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 300);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(33, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Результат:";
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Result.ForeColor = System.Drawing.Color.Green;
            this.label_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_Result.Location = new System.Drawing.Point(132, 325);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(34, 20);
            this.label_Result.TabIndex = 8;
            this.label_Result.Text = ". . .";
            this.label_Result.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form_Recognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 431);
            this.Controls.Add(this.label_Result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button_Wrong);
            this.Controls.Add(this.button_Right);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Recognition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Розпізнавання";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Recognition_FormClosed);
            this.Load += new System.EventHandler(this.Form_Recognition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button button_Right;
        public System.Windows.Forms.Button button_Wrong;
        public System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label_Result;
    }
}