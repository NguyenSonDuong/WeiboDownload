namespace Weibo
{
    partial class Form1
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
            this.btnTai = new System.Windows.Forms.Button();
            this.tbUID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.lbPics = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCountOK = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbVideoOK = new System.Windows.Forms.Label();
            this.lbImageOK = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTai
            // 
            this.btnTai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTai.Location = new System.Drawing.Point(29, 296);
            this.btnTai.Name = "btnTai";
            this.btnTai.Size = new System.Drawing.Size(231, 33);
            this.btnTai.TabIndex = 0;
            this.btnTai.Text = "Tải ảnh";
            this.btnTai.UseVisualStyleBackColor = true;
            this.btnTai.Click += new System.EventHandler(this.btnTai_Click);
            // 
            // tbUID
            // 
            this.tbUID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUID.Location = new System.Drawing.Point(29, 224);
            this.tbUID.Name = "tbUID";
            this.tbUID.Size = new System.Drawing.Size(231, 20);
            this.tbUID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số bài đăng:";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.ForeColor = System.Drawing.Color.Green;
            this.lbCount.Location = new System.Drawing.Point(152, 19);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(13, 13);
            this.lbCount.TabIndex = 3;
            this.lbCount.Text = "0";
            // 
            // lbPics
            // 
            this.lbPics.AutoSize = true;
            this.lbPics.ForeColor = System.Drawing.Color.Green;
            this.lbPics.Location = new System.Drawing.Point(152, 67);
            this.lbPics.Name = "lbPics";
            this.lbPics.Size = new System.Drawing.Size(13, 13);
            this.lbPics.TabIndex = 5;
            this.lbPics.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số ảnh/video đã lấy:";
            // 
            // lbCountOK
            // 
            this.lbCountOK.AutoSize = true;
            this.lbCountOK.ForeColor = System.Drawing.Color.Green;
            this.lbCountOK.Location = new System.Drawing.Point(152, 43);
            this.lbCountOK.Name = "lbCountOK";
            this.lbCountOK.Size = new System.Drawing.Size(13, 13);
            this.lbCountOK.TabIndex = 7;
            this.lbCountOK.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Số bài đăng đã duyệt:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbCountOK);
            this.panel1.Controls.Add(this.lbCount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbPics);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(29, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 98);
            this.panel1.TabIndex = 8;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.Green;
            this.richTextBox1.Location = new System.Drawing.Point(303, 39);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(690, 535);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.tbUID);
            this.panel2.Controls.Add(this.btnTai);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 561);
            this.panel2.TabIndex = 11;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(29, 273);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(62, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Tải ảnh";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 250);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Lưu lick vào file .txt";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbVideoOK);
            this.panel3.Controls.Add(this.lbImageOK);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lbError);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(29, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 98);
            this.panel3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số ảnh đã tải:";
            // 
            // lbVideoOK
            // 
            this.lbVideoOK.AutoSize = true;
            this.lbVideoOK.ForeColor = System.Drawing.Color.Green;
            this.lbVideoOK.Location = new System.Drawing.Point(152, 43);
            this.lbVideoOK.Name = "lbVideoOK";
            this.lbVideoOK.Size = new System.Drawing.Size(13, 13);
            this.lbVideoOK.TabIndex = 7;
            this.lbVideoOK.Text = "0";
            // 
            // lbImageOK
            // 
            this.lbImageOK.AutoSize = true;
            this.lbImageOK.ForeColor = System.Drawing.Color.Green;
            this.lbImageOK.Location = new System.Drawing.Point(152, 19);
            this.lbImageOK.Name = "lbImageOK";
            this.lbImageOK.Size = new System.Drawing.Size(13, 13);
            this.lbImageOK.TabIndex = 3;
            this.lbImageOK.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Số video đã tải:";
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Maroon;
            this.lbError.Location = new System.Drawing.Point(152, 67);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(13, 13);
            this.lbError.TabIndex = 5;
            this.lbError.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(45, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Số ảnh/video tải lỗi:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbStatus.Location = new System.Drawing.Point(303, 13);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 20);
            this.lbStatus.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Dừng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 586);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Weibo";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTai;
        private System.Windows.Forms.TextBox tbUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Label lbPics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbCountOK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbVideoOK;
        private System.Windows.Forms.Label lbImageOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button button1;
    }
}

