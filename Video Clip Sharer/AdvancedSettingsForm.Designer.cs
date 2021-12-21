
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
            this.textBoxMaxBitrate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAvgBitrate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMinBitrate = new System.Windows.Forms.TextBox();
            this.labelOutputFileSize = new System.Windows.Forms.Label();
            this.labelVideoLength = new System.Windows.Forms.Label();
            this.labelAverageBitrate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.checkBoxTwoPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxMaxBitrate
            // 
            this.textBoxMaxBitrate.Location = new System.Drawing.Point(174, 183);
            this.textBoxMaxBitrate.Name = "textBoxMaxBitrate";
            this.textBoxMaxBitrate.Size = new System.Drawing.Size(70, 20);
            this.textBoxMaxBitrate.TabIndex = 0;
            this.textBoxMaxBitrate.TextChanged += new System.EventHandler(this.textBoxMaxBitrate_TextChanged);
            this.textBoxMaxBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxBitrate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Video Max Bitrate kb/s";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Video Average Bitrate kb/s";
            // 
            // textBoxAvgBitrate
            // 
            this.textBoxAvgBitrate.Location = new System.Drawing.Point(174, 157);
            this.textBoxAvgBitrate.Name = "textBoxAvgBitrate";
            this.textBoxAvgBitrate.Size = new System.Drawing.Size(70, 20);
            this.textBoxAvgBitrate.TabIndex = 2;
            this.textBoxAvgBitrate.TextChanged += new System.EventHandler(this.textBoxAvgBitrate_TextChanged);
            this.textBoxAvgBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAvgBitrate_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Video Min Bitrate kb/s";
            // 
            // textBoxMinBitrate
            // 
            this.textBoxMinBitrate.Location = new System.Drawing.Point(174, 131);
            this.textBoxMinBitrate.Name = "textBoxMinBitrate";
            this.textBoxMinBitrate.Size = new System.Drawing.Size(70, 20);
            this.textBoxMinBitrate.TabIndex = 4;
            this.textBoxMinBitrate.TextChanged += new System.EventHandler(this.textBoxMinBitrate_TextChanged);
            this.textBoxMinBitrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMinBitrate_KeyPress);
            // 
            // labelOutputFileSize
            // 
            this.labelOutputFileSize.AutoSize = true;
            this.labelOutputFileSize.Location = new System.Drawing.Point(40, 226);
            this.labelOutputFileSize.Name = "labelOutputFileSize";
            this.labelOutputFileSize.Size = new System.Drawing.Size(132, 13);
            this.labelOutputFileSize.TabIndex = 6;
            this.labelOutputFileSize.Text = "Expected Output File Size:";
            // 
            // labelVideoLength
            // 
            this.labelVideoLength.AutoSize = true;
            this.labelVideoLength.Location = new System.Drawing.Point(64, 44);
            this.labelVideoLength.Name = "labelVideoLength";
            this.labelVideoLength.Size = new System.Drawing.Size(108, 13);
            this.labelVideoLength.TabIndex = 7;
            this.labelVideoLength.Text = "Output Video Length:";
            // 
            // labelAverageBitrate
            // 
            this.labelAverageBitrate.AutoSize = true;
            this.labelAverageBitrate.Location = new System.Drawing.Point(59, 70);
            this.labelAverageBitrate.Name = "labelAverageBitrate";
            this.labelAverageBitrate.Size = new System.Drawing.Size(113, 13);
            this.labelAverageBitrate.TabIndex = 8;
            this.labelAverageBitrate.Text = "Video Average Bitrate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "These changes will overwrite any given \"Quality\" options given";
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(59, 95);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(113, 13);
            this.labelAudioBitrate.TabIndex = 10;
            this.labelAudioBitrate.Text = "Audio Average Bitrate:";
            // 
            // checkBoxTwoPass
            // 
            this.checkBoxTwoPass.AutoSize = true;
            this.checkBoxTwoPass.Location = new System.Drawing.Point(67, 247);
            this.checkBoxTwoPass.Name = "checkBoxTwoPass";
            this.checkBoxTwoPass.Size = new System.Drawing.Size(143, 17);
            this.checkBoxTwoPass.TabIndex = 11;
            this.checkBoxTwoPass.Text = "Use Two-Pass Encoding";
            this.checkBoxTwoPass.UseVisualStyleBackColor = true;
            this.checkBoxTwoPass.CheckedChanged += new System.EventHandler(this.checkBoxTwoPass_CheckedChanged);
            // 
            // AdvancedSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 276);
            this.Controls.Add(this.checkBoxTwoPass);
            this.Controls.Add(this.labelAudioBitrate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAverageBitrate);
            this.Controls.Add(this.labelVideoLength);
            this.Controls.Add(this.labelOutputFileSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMinBitrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxAvgBitrate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMaxBitrate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSettingsForm";
            this.ShowIcon = false;
            this.Text = "Advanced Settings";
            this.Load += new System.EventHandler(this.AdvancedSettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMaxBitrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAvgBitrate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMinBitrate;
        private System.Windows.Forms.Label labelOutputFileSize;
        private System.Windows.Forms.Label labelVideoLength;
        private System.Windows.Forms.Label labelAverageBitrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.CheckBox checkBoxTwoPass;
    }
}