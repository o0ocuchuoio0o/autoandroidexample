namespace WindowSpy
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.moduleFileNameLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.handleLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.styleLabel = new System.Windows.Forms.Label();
            this.rectangleLabel = new System.Windows.Forms.Label();
            this.threadIDLabel = new System.Windows.Forms.Label();
            this.processIDLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.copyButton = new System.Windows.Forms.Button();
            this.getWindowHandleCodeTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.finderBox1 = new WindowSpy.FinderBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.getWindowRadioButton = new System.Windows.Forms.RadioButton();
            this.findWindowRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Window finder tool";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.81179F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.0068F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.95465F));
            this.tableLayoutPanel2.Controls.Add(this.finderBox1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(441, 38);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Finder Tool:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiến hành drag (nhấp chuột trái sau đó giữ và rê) Finder Tool vào một window để c" +
                "họn. Sau đó nhả chuột.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(13, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 183);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected object";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.08844F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.91156F));
            this.tableLayoutPanel1.Controls.Add(this.moduleFileNameLabel, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.handleLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.classLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.styleLabel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.rectangleLabel, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.threadIDLabel, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.processIDLabel, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(441, 164);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // moduleFileNameLabel
            // 
            this.moduleFileNameLabel.AutoSize = true;
            this.moduleFileNameLabel.Location = new System.Drawing.Point(96, 140);
            this.moduleFileNameLabel.Name = "moduleFileNameLabel";
            this.moduleFileNameLabel.Size = new System.Drawing.Size(37, 13);
            this.moduleFileNameLabel.TabIndex = 14;
            this.moduleFileNameLabel.Text = "          ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Process ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Handle:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Text:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Thread ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Class:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Style:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Rectangle:";
            // 
            // handleLabel
            // 
            this.handleLabel.AutoSize = true;
            this.handleLabel.Location = new System.Drawing.Point(96, 0);
            this.handleLabel.Name = "handleLabel";
            this.handleLabel.Size = new System.Drawing.Size(37, 13);
            this.handleLabel.TabIndex = 6;
            this.handleLabel.Text = "          ";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(96, 20);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(37, 13);
            this.textLabel.TabIndex = 7;
            this.textLabel.Text = "          ";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(96, 40);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(37, 13);
            this.classLabel.TabIndex = 8;
            this.classLabel.Text = "          ";
            // 
            // styleLabel
            // 
            this.styleLabel.AutoSize = true;
            this.styleLabel.Location = new System.Drawing.Point(96, 60);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(37, 13);
            this.styleLabel.TabIndex = 9;
            this.styleLabel.Text = "          ";
            // 
            // rectangleLabel
            // 
            this.rectangleLabel.AutoSize = true;
            this.rectangleLabel.Location = new System.Drawing.Point(96, 80);
            this.rectangleLabel.Name = "rectangleLabel";
            this.rectangleLabel.Size = new System.Drawing.Size(37, 13);
            this.rectangleLabel.TabIndex = 10;
            this.rectangleLabel.Text = "          ";
            // 
            // threadIDLabel
            // 
            this.threadIDLabel.AutoSize = true;
            this.threadIDLabel.Location = new System.Drawing.Point(96, 100);
            this.threadIDLabel.Name = "threadIDLabel";
            this.threadIDLabel.Size = new System.Drawing.Size(37, 13);
            this.threadIDLabel.TabIndex = 11;
            this.threadIDLabel.Text = "          ";
            // 
            // processIDLabel
            // 
            this.processIDLabel.AutoSize = true;
            this.processIDLabel.Location = new System.Drawing.Point(96, 120);
            this.processIDLabel.Name = "processIDLabel";
            this.processIDLabel.Size = new System.Drawing.Size(37, 13);
            this.processIDLabel.TabIndex = 12;
            this.processIDLabel.Text = "          ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Module filename:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(19, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(441, 149);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Code to get selected object handle";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.Controls.Add(this.getWindowHandleCodeTextBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(435, 130);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(3, 98);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 5;
            this.copyButton.Text = "&Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // findWindowCodeTextBox
            // 
            this.getWindowHandleCodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.getWindowHandleCodeTextBox.Location = new System.Drawing.Point(3, 3);
            this.getWindowHandleCodeTextBox.Multiline = true;
            this.getWindowHandleCodeTextBox.Name = "findWindowCodeTextBox";
            this.getWindowHandleCodeTextBox.ReadOnly = true;
            this.getWindowHandleCodeTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.getWindowHandleCodeTextBox.Size = new System.Drawing.Size(299, 124);
            this.getWindowHandleCodeTextBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "&Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(379, 420);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "&About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // finderBox1
            // 
            this.finderBox1.Location = new System.Drawing.Point(355, 3);
            this.finderBox1.Name = "finderBox1";
            this.finderBox1.Size = new System.Drawing.Size(37, 32);
            this.finderBox1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.copyButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(308, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(124, 124);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.findWindowRadioButton);
            this.groupBox4.Controls.Add(this.getWindowRadioButton);
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(118, 89);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Method options";
            // 
            // getWindowRadioButton
            // 
            this.getWindowRadioButton.AutoSize = true;
            this.getWindowRadioButton.Location = new System.Drawing.Point(7, 20);
            this.getWindowRadioButton.Name = "getWindowRadioButton";
            this.getWindowRadioButton.Size = new System.Drawing.Size(81, 17);
            this.getWindowRadioButton.TabIndex = 0;
            this.getWindowRadioButton.TabStop = true;
            this.getWindowRadioButton.Text = "GetWindow";
            this.getWindowRadioButton.UseVisualStyleBackColor = true;
            // 
            // findWindowRadioButton
            // 
            this.findWindowRadioButton.AutoSize = true;
            this.findWindowRadioButton.Location = new System.Drawing.Point(7, 43);
            this.findWindowRadioButton.Name = "findWindowRadioButton";
            this.findWindowRadioButton.Size = new System.Drawing.Size(84, 17);
            this.findWindowRadioButton.TabIndex = 1;
            this.findWindowRadioButton.TabStop = true;
            this.findWindowRadioButton.Text = "FindWindow";
            this.findWindowRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 452);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Window Spy";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox getWindowHandleCodeTextBox;
        private System.Windows.Forms.Button button1;
        private FinderBox finderBox1;
        private System.Windows.Forms.Label handleLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label styleLabel;
        private System.Windows.Forms.Label rectangleLabel;
        private System.Windows.Forms.Label threadIDLabel;
        private System.Windows.Forms.Label processIDLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label moduleFileNameLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton findWindowRadioButton;
        private System.Windows.Forms.RadioButton getWindowRadioButton;
    }
}

