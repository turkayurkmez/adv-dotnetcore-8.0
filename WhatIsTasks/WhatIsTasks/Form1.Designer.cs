namespace WhatIsTasks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            labelThreadStart = new Label();
            buttonThreadStart = new Button();
            groupBox2 = new GroupBox();
            labelTask = new Label();
            buttonTask = new Button();
            progressBar1 = new ProgressBar();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelThreadStart);
            groupBox1.Controls.Add(buttonThreadStart);
            groupBox1.Location = new Point(39, 64);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(255, 159);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thread";
            // 
            // labelThreadStart
            // 
            labelThreadStart.AutoSize = true;
            labelThreadStart.Location = new Point(87, 113);
            labelThreadStart.Name = "labelThreadStart";
            labelThreadStart.Size = new Size(16, 15);
            labelThreadStart.TabIndex = 1;
            labelThreadStart.Text = "...";
            // 
            // buttonThreadStart
            // 
            buttonThreadStart.Location = new Point(84, 46);
            buttonThreadStart.Name = "buttonThreadStart";
            buttonThreadStart.Size = new Size(123, 23);
            buttonThreadStart.TabIndex = 0;
            buttonThreadStart.Text = "Thread'i Başlat";
            buttonThreadStart.UseVisualStyleBackColor = true;
            buttonThreadStart.Click += buttonThreadStart_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(progressBar1);
            groupBox2.Controls.Add(labelTask);
            groupBox2.Controls.Add(buttonTask);
            groupBox2.Location = new Point(327, 64);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(255, 159);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Task";
            // 
            // labelTask
            // 
            labelTask.AutoSize = true;
            labelTask.Location = new Point(87, 113);
            labelTask.Name = "labelTask";
            labelTask.Size = new Size(16, 15);
            labelTask.TabIndex = 1;
            labelTask.Text = "...";
            // 
            // buttonTask
            // 
            buttonTask.Location = new Point(84, 46);
            buttonTask.Name = "buttonTask";
            buttonTask.Size = new Size(123, 23);
            buttonTask.TabIndex = 0;
            buttonTask.Text = "Task'ı Başlat";
            buttonTask.UseVisualStyleBackColor = true;
            buttonTask.Click += buttonTask_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(49, 87);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(170, 23);
            progressBar1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label labelThreadStart;
        private Button buttonThreadStart;
        private GroupBox groupBox2;
        private Label labelTask;
        private Button buttonTask;
        private ProgressBar progressBar1;
    }
}
