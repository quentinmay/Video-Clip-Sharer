
namespace Video_Clip_Sharer
{
    partial class AdvancedSettingsForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelOutputFileSize = new System.Windows.Forms.Label();
            this.labelVideoLength = new System.Windows.Forms.Label();
            this.labelAverageBitrate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max Bitrate kb/s";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Average Bitrate kb/s";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(180, 104);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Min Bitrate kb/s";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(180, 78);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            // 
            // labelOutputFileSize
            // 
            this.labelOutputFileSize.AutoSize = true;
            this.labelOutputFileSize.Location = new System.Drawing.Point(46, 173);
            this.labelOutputFileSize.Name = "labelOutputFileSize";
            this.labelOutputFileSize.Size = new System.Drawing.Size(132, 13);
            this.labelOutputFileSize.TabIndex = 6;
            this.labelOutputFileSize.Text = "Expected Output File Size:";
            // 
            // labelVideoLength
            // 
            this.labelVideoLength.AutoSize = true;
            this.labelVideoLength.Location = new System.Drawing.Point(70, 23);
            this.labelVideoLength.Name = "labelVideoLength";
            this.labelVideoLength.Size = new System.Drawing.Size(108, 13);
            this.labelVideoLength.TabIndex = 7;
            this.labelVideoLength.Text = "Output Video Length:";
            // 
            // labelAverageBitrate
            // 
            this.labelAverageBitrate.AutoSize = true;
            this.labelAverageBitrate.Location = new System.Drawing.Point(65, 49);
            this.labelAverageBitrate.Name = "labelAverageBitrate";
            this.labelAverageBitrate.Size = new System.Drawing.Size(113, 13);
            this.labelAverageBitrate.TabIndex = 8;
            this.labelAverageBitrate.Text = "Video Average Bitrate:";
            // 
            // AdvancedSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 276);
            this.Controls.Add(this.labelAverageBitrate);
            this.Controls.Add(this.labelVideoLength);
            this.Controls.Add(this.labelOutputFileSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "AdvancedSettingsForm";
            this.Text = "AdvancedSettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label labelOutputFileSize;
        private System.Windows.Forms.Label labelVideoLength;
        private System.Windows.Forms.Label labelAverageBitrate;
    }
}