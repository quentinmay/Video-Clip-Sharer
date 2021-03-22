
using System;

namespace Video_Clip_Sharer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.linkLabelVideoPath = new System.Windows.Forms.LinkLabel();
            this.buttonTestPlayVideo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.checkBoxStayInBoundary = new System.Windows.Forms.CheckBox();
            this.checkBoxShowCrop = new System.Windows.Forms.CheckBox();
            this.trackBarFPS = new System.Windows.Forms.TrackBar();
            this.labelFPS = new System.Windows.Forms.Label();
            this.textBoxOutputName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBarQuality = new System.Windows.Forms.TrackBar();
            this.labelQuality = new System.Windows.Forms.Label();
            this.redRangeStart = new System.Windows.Forms.PictureBox();
            this.greenRange = new System.Windows.Forms.PictureBox();
            this.redRangeEnd = new System.Windows.Forms.PictureBox();
            this.buttonSetStart = new System.Windows.Forms.Button();
            this.buttonSetEnd = new System.Windows.Forms.Button();
            this.listViewVideos = new System.Windows.Forms.ListView();
            this.fileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBoxLeftCrop = new System.Windows.Forms.PictureBox();
            this.pictureBoxRightCrop = new System.Windows.Forms.PictureBox();
            this.pictureBoxBottomCrop = new System.Windows.Forms.PictureBox();
            this.pictureBoxTopCrop = new System.Windows.Forms.PictureBox();
            this.buttonClearCrop = new System.Windows.Forms.Button();
            this.buttonClip = new System.Windows.Forms.Button();
            this.progressBarRender = new System.Windows.Forms.ProgressBar();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.labelRenderTimeToComplete = new System.Windows.Forms.Label();
            this.labelRenderTimeElapsed = new System.Windows.Forms.Label();
            this.labelFFmpegConsole = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.timerVLCTimeStamp = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.labelVolume = new System.Windows.Forms.Label();
            this.trackBarAudioTrack = new System.Windows.Forms.TrackBar();
            this.checkBoxSaveAudioTrack = new System.Windows.Forms.CheckBox();
            this.labelCurrentAudioTrack = new System.Windows.Forms.Label();
            this.labelPercentComplete = new System.Windows.Forms.Label();
            this.textBoxVideoListPath = new System.Windows.Forms.TextBox();
            this.linkLabelOutputPath = new System.Windows.Forms.LinkLabel();
            this.labelDirectoryLoadTime = new System.Windows.Forms.Label();
            this.textBoxFFmpegBinaries = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSearchListView = new System.Windows.Forms.TextBox();
            this.comboBoxOutputFormat = new System.Windows.Forms.ComboBox();
            this.textBoxScaleX = new System.Windows.Forms.TextBox();
            this.textBoxScaleY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonDev = new System.Windows.Forms.Button();
            this.buttonAdvancedSettings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQuality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redRangeStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redRangeEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopCrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelVideoPath
            // 
            this.linkLabelVideoPath.AutoSize = true;
            this.linkLabelVideoPath.Location = new System.Drawing.Point(10, 11);
            this.linkLabelVideoPath.Name = "linkLabelVideoPath";
            this.linkLabelVideoPath.Size = new System.Drawing.Size(98, 13);
            this.linkLabelVideoPath.TabIndex = 1;
            this.linkLabelVideoPath.TabStop = true;
            this.linkLabelVideoPath.Text = "linkLabelVideoPath";
            this.linkLabelVideoPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelVideoPath_LinkClicked);
            // 
            // buttonTestPlayVideo
            // 
            this.buttonTestPlayVideo.Location = new System.Drawing.Point(607, 408);
            this.buttonTestPlayVideo.Name = "buttonTestPlayVideo";
            this.buttonTestPlayVideo.Size = new System.Drawing.Size(99, 52);
            this.buttonTestPlayVideo.TabIndex = 2;
            this.buttonTestPlayVideo.Text = "Generate FFMPEG command";
            this.buttonTestPlayVideo.UseVisualStyleBackColor = true;
            this.buttonTestPlayVideo.Visible = false;
            this.buttonTestPlayVideo.Click += new System.EventHandler(this.buttonTestPlayVideo_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(335, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(188, 124);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(12, 27);
            this.axVLCPlugin21.MaximumSize = new System.Drawing.Size(640, 360);
            this.axVLCPlugin21.MinimumSize = new System.Drawing.Size(640, 360);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(640, 360);
            this.axVLCPlugin21.TabIndex = 7;
            this.axVLCPlugin21.MediaPlayerTimeChanged += new AxAXVLC.DVLCEvents_MediaPlayerTimeChangedEventHandler(this.axVLCPlugin21_MediaPlayerTimeChanged);
            this.axVLCPlugin21.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axVLCPlugin21_PreviewKeyDown);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(439, 393);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(162, 131);
            this.textBoxLog.TabIndex = 8;
            this.textBoxLog.Visible = false;
            // 
            // checkBoxStayInBoundary
            // 
            this.checkBoxStayInBoundary.AutoSize = true;
            this.checkBoxStayInBoundary.Location = new System.Drawing.Point(13, 404);
            this.checkBoxStayInBoundary.Name = "checkBoxStayInBoundary";
            this.checkBoxStayInBoundary.Size = new System.Drawing.Size(107, 17);
            this.checkBoxStayInBoundary.TabIndex = 9;
            this.checkBoxStayInBoundary.Text = "Stay In Boundary";
            this.checkBoxStayInBoundary.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowCrop
            // 
            this.checkBoxShowCrop.AutoSize = true;
            this.checkBoxShowCrop.Checked = true;
            this.checkBoxShowCrop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowCrop.Location = new System.Drawing.Point(126, 404);
            this.checkBoxShowCrop.Name = "checkBoxShowCrop";
            this.checkBoxShowCrop.Size = new System.Drawing.Size(78, 17);
            this.checkBoxShowCrop.TabIndex = 10;
            this.checkBoxShowCrop.Text = "Show Crop";
            this.checkBoxShowCrop.UseVisualStyleBackColor = true;
            this.checkBoxShowCrop.CheckedChanged += new System.EventHandler(this.checkBoxShowCrop_CheckedChanged);
            // 
            // trackBarFPS
            // 
            this.trackBarFPS.Location = new System.Drawing.Point(227, 477);
            this.trackBarFPS.Maximum = 60;
            this.trackBarFPS.Minimum = 1;
            this.trackBarFPS.Name = "trackBarFPS";
            this.trackBarFPS.Size = new System.Drawing.Size(212, 45);
            this.trackBarFPS.TabIndex = 11;
            this.trackBarFPS.Value = 1;
            this.trackBarFPS.ValueChanged += new System.EventHandler(this.trackBarFPS_ValueChanged);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(219, 484);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(13, 13);
            this.labelFPS.TabIndex = 12;
            this.labelFPS.Text = "0";
            // 
            // textBoxOutputName
            // 
            this.textBoxOutputName.Location = new System.Drawing.Point(861, 389);
            this.textBoxOutputName.Name = "textBoxOutputName";
            this.textBoxOutputName.Size = new System.Drawing.Size(165, 20);
            this.textBoxOutputName.TabIndex = 13;
            this.textBoxOutputName.TextChanged += new System.EventHandler(this.textBoxOutputName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(858, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Output Name:";
            // 
            // trackBarQuality
            // 
            this.trackBarQuality.Location = new System.Drawing.Point(227, 421);
            this.trackBarQuality.Maximum = 51;
            this.trackBarQuality.Name = "trackBarQuality";
            this.trackBarQuality.Size = new System.Drawing.Size(212, 45);
            this.trackBarQuality.TabIndex = 15;
            this.trackBarQuality.ValueChanged += new System.EventHandler(this.trackBarQuality_ValueChanged);
            // 
            // labelQuality
            // 
            this.labelQuality.AutoSize = true;
            this.labelQuality.Location = new System.Drawing.Point(219, 428);
            this.labelQuality.Name = "labelQuality";
            this.labelQuality.Size = new System.Drawing.Size(13, 13);
            this.labelQuality.TabIndex = 16;
            this.labelQuality.Text = "0";
            // 
            // redRangeStart
            // 
            this.redRangeStart.BackColor = System.Drawing.Color.Red;
            this.redRangeStart.Location = new System.Drawing.Point(46, 374);
            this.redRangeStart.MaximumSize = new System.Drawing.Size(437, 10);
            this.redRangeStart.Name = "redRangeStart";
            this.redRangeStart.Size = new System.Drawing.Size(0, 10);
            this.redRangeStart.TabIndex = 17;
            this.redRangeStart.TabStop = false;
            // 
            // greenRange
            // 
            this.greenRange.BackColor = System.Drawing.Color.Lime;
            this.greenRange.Location = new System.Drawing.Point(46, 374);
            this.greenRange.MaximumSize = new System.Drawing.Size(437, 10);
            this.greenRange.MinimumSize = new System.Drawing.Size(0, 10);
            this.greenRange.Name = "greenRange";
            this.greenRange.Size = new System.Drawing.Size(437, 10);
            this.greenRange.TabIndex = 18;
            this.greenRange.TabStop = false;
            // 
            // redRangeEnd
            // 
            this.redRangeEnd.BackColor = System.Drawing.Color.Red;
            this.redRangeEnd.Location = new System.Drawing.Point(483, 374);
            this.redRangeEnd.MaximumSize = new System.Drawing.Size(437, 10);
            this.redRangeEnd.Name = "redRangeEnd";
            this.redRangeEnd.Size = new System.Drawing.Size(0, 10);
            this.redRangeEnd.TabIndex = 19;
            this.redRangeEnd.TabStop = false;
            // 
            // buttonSetStart
            // 
            this.buttonSetStart.Location = new System.Drawing.Point(12, 425);
            this.buttonSetStart.Name = "buttonSetStart";
            this.buttonSetStart.Size = new System.Drawing.Size(75, 23);
            this.buttonSetStart.TabIndex = 20;
            this.buttonSetStart.Text = "Set Start";
            this.buttonSetStart.UseVisualStyleBackColor = true;
            this.buttonSetStart.Click += new System.EventHandler(this.buttonSetStart_Click);
            // 
            // buttonSetEnd
            // 
            this.buttonSetEnd.Location = new System.Drawing.Point(93, 425);
            this.buttonSetEnd.Name = "buttonSetEnd";
            this.buttonSetEnd.Size = new System.Drawing.Size(75, 23);
            this.buttonSetEnd.TabIndex = 21;
            this.buttonSetEnd.Text = "Set End";
            this.buttonSetEnd.UseVisualStyleBackColor = true;
            this.buttonSetEnd.Click += new System.EventHandler(this.buttonSetEnd_Click);
            // 
            // listViewVideos
            // 
            this.listViewVideos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileName,
            this.date,
            this.fileSize});
            this.listViewVideos.HideSelection = false;
            this.listViewVideos.Location = new System.Drawing.Point(710, 127);
            this.listViewVideos.Name = "listViewVideos";
            this.listViewVideos.Size = new System.Drawing.Size(316, 247);
            this.listViewVideos.TabIndex = 22;
            this.listViewVideos.UseCompatibleStateImageBehavior = false;
            this.listViewVideos.View = System.Windows.Forms.View.Details;
            this.listViewVideos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewVideos_ColumnClick);
            this.listViewVideos.ItemActivate += new System.EventHandler(this.listViewVideos_ItemActivate);
            // 
            // fileName
            // 
            this.fileName.Text = "Name";
            this.fileName.Width = 178;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 69;
            // 
            // fileSize
            // 
            this.fileSize.Text = "File Size";
            this.fileSize.Width = 62;
            // 
            // pictureBoxLeftCrop
            // 
            this.pictureBoxLeftCrop.BackColor = System.Drawing.Color.Teal;
            this.pictureBoxLeftCrop.Location = new System.Drawing.Point(12, 27);
            this.pictureBoxLeftCrop.Name = "pictureBoxLeftCrop";
            this.pictureBoxLeftCrop.Size = new System.Drawing.Size(0, 360);
            this.pictureBoxLeftCrop.TabIndex = 23;
            this.pictureBoxLeftCrop.TabStop = false;
            // 
            // pictureBoxRightCrop
            // 
            this.pictureBoxRightCrop.BackColor = System.Drawing.Color.Teal;
            this.pictureBoxRightCrop.Location = new System.Drawing.Point(652, 27);
            this.pictureBoxRightCrop.MaximumSize = new System.Drawing.Size(640, 360);
            this.pictureBoxRightCrop.MinimumSize = new System.Drawing.Size(0, 360);
            this.pictureBoxRightCrop.Name = "pictureBoxRightCrop";
            this.pictureBoxRightCrop.Size = new System.Drawing.Size(0, 360);
            this.pictureBoxRightCrop.TabIndex = 24;
            this.pictureBoxRightCrop.TabStop = false;
            // 
            // pictureBoxBottomCrop
            // 
            this.pictureBoxBottomCrop.BackColor = System.Drawing.Color.Teal;
            this.pictureBoxBottomCrop.Location = new System.Drawing.Point(12, 387);
            this.pictureBoxBottomCrop.MaximumSize = new System.Drawing.Size(640, 360);
            this.pictureBoxBottomCrop.MinimumSize = new System.Drawing.Size(640, 0);
            this.pictureBoxBottomCrop.Name = "pictureBoxBottomCrop";
            this.pictureBoxBottomCrop.Size = new System.Drawing.Size(640, 0);
            this.pictureBoxBottomCrop.TabIndex = 25;
            this.pictureBoxBottomCrop.TabStop = false;
            // 
            // pictureBoxTopCrop
            // 
            this.pictureBoxTopCrop.BackColor = System.Drawing.Color.Teal;
            this.pictureBoxTopCrop.Location = new System.Drawing.Point(12, 27);
            this.pictureBoxTopCrop.MaximumSize = new System.Drawing.Size(640, 360);
            this.pictureBoxTopCrop.MinimumSize = new System.Drawing.Size(640, 0);
            this.pictureBoxTopCrop.Name = "pictureBoxTopCrop";
            this.pictureBoxTopCrop.Size = new System.Drawing.Size(640, 0);
            this.pictureBoxTopCrop.TabIndex = 26;
            this.pictureBoxTopCrop.TabStop = false;
            // 
            // buttonClearCrop
            // 
            this.buttonClearCrop.Location = new System.Drawing.Point(12, 450);
            this.buttonClearCrop.Name = "buttonClearCrop";
            this.buttonClearCrop.Size = new System.Drawing.Size(75, 23);
            this.buttonClearCrop.TabIndex = 27;
            this.buttonClearCrop.Text = "Clear Crop";
            this.buttonClearCrop.UseVisualStyleBackColor = true;
            this.buttonClearCrop.Click += new System.EventHandler(this.buttonClearCrop_Click);
            // 
            // buttonClip
            // 
            this.buttonClip.Location = new System.Drawing.Point(861, 416);
            this.buttonClip.Name = "buttonClip";
            this.buttonClip.Size = new System.Drawing.Size(165, 108);
            this.buttonClip.TabIndex = 28;
            this.buttonClip.Text = "Clip";
            this.buttonClip.UseVisualStyleBackColor = true;
            this.buttonClip.Click += new System.EventHandler(this.buttonClip_Click);
            // 
            // progressBarRender
            // 
            this.progressBarRender.Location = new System.Drawing.Point(710, 498);
            this.progressBarRender.Name = "progressBarRender";
            this.progressBarRender.Size = new System.Drawing.Size(145, 26);
            this.progressBarRender.TabIndex = 29;
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(707, 454);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(52, 13);
            this.labelFileSize.TabIndex = 30;
            this.labelFileSize.Text = "File Size: ";
            // 
            // labelRenderTimeToComplete
            // 
            this.labelRenderTimeToComplete.AutoSize = true;
            this.labelRenderTimeToComplete.Location = new System.Drawing.Point(707, 482);
            this.labelRenderTimeToComplete.Name = "labelRenderTimeToComplete";
            this.labelRenderTimeToComplete.Size = new System.Drawing.Size(96, 13);
            this.labelRenderTimeToComplete.TabIndex = 31;
            this.labelRenderTimeToComplete.Text = "Time To Complete:";
            // 
            // labelRenderTimeElapsed
            // 
            this.labelRenderTimeElapsed.AutoSize = true;
            this.labelRenderTimeElapsed.Location = new System.Drawing.Point(707, 468);
            this.labelRenderTimeElapsed.Name = "labelRenderTimeElapsed";
            this.labelRenderTimeElapsed.Size = new System.Drawing.Size(74, 13);
            this.labelRenderTimeElapsed.TabIndex = 32;
            this.labelRenderTimeElapsed.Text = "Time Elapsed:";
            // 
            // labelFFmpegConsole
            // 
            this.labelFFmpegConsole.AutoSize = true;
            this.labelFFmpegConsole.Location = new System.Drawing.Point(10, 523);
            this.labelFFmpegConsole.Name = "labelFFmpegConsole";
            this.labelFFmpegConsole.Size = new System.Drawing.Size(89, 13);
            this.labelFFmpegConsole.TabIndex = 33;
            this.labelFFmpegConsole.Text = "FFmpeg Console ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Quality 0 - 51 (Lossless - Worst Quality)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "FPS:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(710, 416);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(145, 26);
            this.buttonCancel.TabIndex = 36;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Location = new System.Drawing.Point(835, 33);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(191, 45);
            this.trackBarVolume.TabIndex = 37;
            this.trackBarVolume.Value = 100;
            this.trackBarVolume.ValueChanged += new System.EventHandler(this.trackBarVolume_ValueChanged);
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.Location = new System.Drawing.Point(43, 389);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(34, 13);
            this.labelTimestamp.TabIndex = 38;
            this.labelTimestamp.Text = "00:00";
            // 
            // timerVLCTimeStamp
            // 
            this.timerVLCTimeStamp.Enabled = true;
            this.timerVLCTimeStamp.Tick += new System.EventHandler(this.timerVLCTimeStamp_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(832, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Volume 0 -100:";
            // 
            // labelVolume
            // 
            this.labelVolume.AutoSize = true;
            this.labelVolume.Location = new System.Drawing.Point(819, 39);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(25, 13);
            this.labelVolume.TabIndex = 39;
            this.labelVolume.Text = "100";
            // 
            // trackBarAudioTrack
            // 
            this.trackBarAudioTrack.Location = new System.Drawing.Point(703, 31);
            this.trackBarAudioTrack.Maximum = 1;
            this.trackBarAudioTrack.Minimum = 1;
            this.trackBarAudioTrack.Name = "trackBarAudioTrack";
            this.trackBarAudioTrack.Size = new System.Drawing.Size(104, 45);
            this.trackBarAudioTrack.TabIndex = 41;
            this.trackBarAudioTrack.Value = 1;
            this.trackBarAudioTrack.ValueChanged += new System.EventHandler(this.trackBarAudioTrack_ValueChanged);
            // 
            // checkBoxSaveAudioTrack
            // 
            this.checkBoxSaveAudioTrack.AutoSize = true;
            this.checkBoxSaveAudioTrack.Checked = true;
            this.checkBoxSaveAudioTrack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSaveAudioTrack.Location = new System.Drawing.Point(822, 0);
            this.checkBoxSaveAudioTrack.Name = "checkBoxSaveAudioTrack";
            this.checkBoxSaveAudioTrack.Size = new System.Drawing.Size(105, 17);
            this.checkBoxSaveAudioTrack.TabIndex = 42;
            this.checkBoxSaveAudioTrack.Text = "Save This Track";
            this.checkBoxSaveAudioTrack.UseVisualStyleBackColor = true;
            this.checkBoxSaveAudioTrack.CheckedChanged += new System.EventHandler(this.checkBoxSaveAudioTrack_CheckedChanged);
            // 
            // labelCurrentAudioTrack
            // 
            this.labelCurrentAudioTrack.AutoSize = true;
            this.labelCurrentAudioTrack.Location = new System.Drawing.Point(698, 18);
            this.labelCurrentAudioTrack.Name = "labelCurrentAudioTrack";
            this.labelCurrentAudioTrack.Size = new System.Drawing.Size(114, 13);
            this.labelCurrentAudioTrack.TabIndex = 44;
            this.labelCurrentAudioTrack.Text = "Current Audio Track: 1";
            // 
            // labelPercentComplete
            // 
            this.labelPercentComplete.AutoSize = true;
            this.labelPercentComplete.BackColor = System.Drawing.Color.Transparent;
            this.labelPercentComplete.Location = new System.Drawing.Point(684, 505);
            this.labelPercentComplete.Name = "labelPercentComplete";
            this.labelPercentComplete.Size = new System.Drawing.Size(21, 13);
            this.labelPercentComplete.TabIndex = 45;
            this.labelPercentComplete.Text = "0%";
            // 
            // textBoxVideoListPath
            // 
            this.textBoxVideoListPath.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxVideoListPath.Location = new System.Drawing.Point(710, 95);
            this.textBoxVideoListPath.Name = "textBoxVideoListPath";
            this.textBoxVideoListPath.ReadOnly = true;
            this.textBoxVideoListPath.Size = new System.Drawing.Size(316, 20);
            this.textBoxVideoListPath.TabIndex = 46;
            this.textBoxVideoListPath.Click += new System.EventHandler(this.textBoxVideoListPath_Click);
            // 
            // linkLabelOutputPath
            // 
            this.linkLabelOutputPath.AutoSize = true;
            this.linkLabelOutputPath.Location = new System.Drawing.Point(708, 441);
            this.linkLabelOutputPath.Name = "linkLabelOutputPath";
            this.linkLabelOutputPath.Size = new System.Drawing.Size(103, 13);
            this.linkLabelOutputPath.TabIndex = 47;
            this.linkLabelOutputPath.TabStop = true;
            this.linkLabelOutputPath.Text = "linkLabelOutputPath";
            this.linkLabelOutputPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOutputPath_LinkClicked);
            // 
            // labelDirectoryLoadTime
            // 
            this.labelDirectoryLoadTime.AutoSize = true;
            this.labelDirectoryLoadTime.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelDirectoryLoadTime.Location = new System.Drawing.Point(707, 114);
            this.labelDirectoryLoadTime.Name = "labelDirectoryLoadTime";
            this.labelDirectoryLoadTime.Size = new System.Drawing.Size(105, 13);
            this.labelDirectoryLoadTime.TabIndex = 48;
            this.labelDirectoryLoadTime.Text = "Directory Load Time:";
            // 
            // textBoxFFmpegBinaries
            // 
            this.textBoxFFmpegBinaries.BackColor = System.Drawing.Color.Red;
            this.textBoxFFmpegBinaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFFmpegBinaries.ForeColor = System.Drawing.Color.Transparent;
            this.textBoxFFmpegBinaries.Location = new System.Drawing.Point(445, 6);
            this.textBoxFFmpegBinaries.Name = "textBoxFFmpegBinaries";
            this.textBoxFFmpegBinaries.ReadOnly = true;
            this.textBoxFFmpegBinaries.Size = new System.Drawing.Size(207, 20);
            this.textBoxFFmpegBinaries.TabIndex = 49;
            this.textBoxFFmpegBinaries.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(332, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "FFmpeg Binaries Path:";
            this.label5.Visible = false;
            // 
            // textBoxSearchListView
            // 
            this.textBoxSearchListView.Location = new System.Drawing.Point(710, 69);
            this.textBoxSearchListView.Name = "textBoxSearchListView";
            this.textBoxSearchListView.Size = new System.Drawing.Size(316, 20);
            this.textBoxSearchListView.TabIndex = 51;
            this.textBoxSearchListView.Visible = false;
            this.textBoxSearchListView.TextChanged += new System.EventHandler(this.textBoxSearchListView_TextChanged);
            // 
            // comboBoxOutputFormat
            // 
            this.comboBoxOutputFormat.FormattingEnabled = true;
            this.comboBoxOutputFormat.Items.AddRange(new object[] {
            "Same As Source (usually h264)",
            "h264_nvenc",
            "libvpx-vp9",
            "gif"});
            this.comboBoxOutputFormat.Location = new System.Drawing.Point(710, 387);
            this.comboBoxOutputFormat.Name = "comboBoxOutputFormat";
            this.comboBoxOutputFormat.Size = new System.Drawing.Size(145, 21);
            this.comboBoxOutputFormat.TabIndex = 54;
            this.comboBoxOutputFormat.Text = "Output Format";
            this.comboBoxOutputFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxOutputFormat_SelectedIndexChanged);
            // 
            // textBoxScaleX
            // 
            this.textBoxScaleX.Location = new System.Drawing.Point(90, 476);
            this.textBoxScaleX.Name = "textBoxScaleX";
            this.textBoxScaleX.Size = new System.Drawing.Size(56, 20);
            this.textBoxScaleX.TabIndex = 55;
            this.textBoxScaleX.TextChanged += new System.EventHandler(this.textBoxScaleX_TextChanged);
            this.textBoxScaleX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxScaleX_KeyPress);
            // 
            // textBoxScaleY
            // 
            this.textBoxScaleY.Location = new System.Drawing.Point(154, 476);
            this.textBoxScaleY.Name = "textBoxScaleY";
            this.textBoxScaleY.ReadOnly = true;
            this.textBoxScaleY.Size = new System.Drawing.Size(56, 20);
            this.textBoxScaleY.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(145, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "x";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 461);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Width";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 461);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Height";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(10, 471);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 52);
            this.label9.TabIndex = 60;
            this.label9.Text = "Hotkeys:\r\nSet Start \"[\"\r\nSet End \"]\"\r\nSet Crop Point \"C\"\r\n";
            // 
            // buttonDev
            // 
            this.buttonDev.Location = new System.Drawing.Point(654, 513);
            this.buttonDev.Name = "buttonDev";
            this.buttonDev.Size = new System.Drawing.Size(24, 23);
            this.buttonDev.TabIndex = 61;
            this.buttonDev.UseVisualStyleBackColor = true;
            this.buttonDev.Click += new System.EventHandler(this.buttonDev_Click);
            // 
            // buttonAdvancedSettings
            // 
            this.buttonAdvancedSettings.Location = new System.Drawing.Point(607, 463);
            this.buttonAdvancedSettings.Name = "buttonAdvancedSettings";
            this.buttonAdvancedSettings.Size = new System.Drawing.Size(99, 39);
            this.buttonAdvancedSettings.TabIndex = 62;
            this.buttonAdvancedSettings.Text = "Advanced Settings";
            this.buttonAdvancedSettings.UseVisualStyleBackColor = true;
            this.buttonAdvancedSettings.Click += new System.EventHandler(this.buttonAdvancedSettings_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 536);
            this.Controls.Add(this.buttonAdvancedSettings);
            this.Controls.Add(this.buttonDev);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxScaleY);
            this.Controls.Add(this.textBoxScaleX);
            this.Controls.Add(this.comboBoxOutputFormat);
            this.Controls.Add(this.textBoxSearchListView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxFFmpegBinaries);
            this.Controls.Add(this.textBoxVideoListPath);
            this.Controls.Add(this.labelDirectoryLoadTime);
            this.Controls.Add(this.linkLabelOutputPath);
            this.Controls.Add(this.labelCurrentAudioTrack);
            this.Controls.Add(this.checkBoxSaveAudioTrack);
            this.Controls.Add(this.trackBarAudioTrack);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.labelTimestamp);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFFmpegConsole);
            this.Controls.Add(this.labelRenderTimeElapsed);
            this.Controls.Add(this.labelRenderTimeToComplete);
            this.Controls.Add(this.labelFileSize);
            this.Controls.Add(this.progressBarRender);
            this.Controls.Add(this.buttonClip);
            this.Controls.Add(this.buttonClearCrop);
            this.Controls.Add(this.pictureBoxTopCrop);
            this.Controls.Add(this.pictureBoxBottomCrop);
            this.Controls.Add(this.pictureBoxRightCrop);
            this.Controls.Add(this.pictureBoxLeftCrop);
            this.Controls.Add(this.listViewVideos);
            this.Controls.Add(this.buttonSetEnd);
            this.Controls.Add(this.buttonSetStart);
            this.Controls.Add(this.redRangeEnd);
            this.Controls.Add(this.redRangeStart);
            this.Controls.Add(this.greenRange);
            this.Controls.Add(this.labelQuality);
            this.Controls.Add(this.trackBarQuality);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutputName);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.trackBarFPS);
            this.Controls.Add(this.checkBoxShowCrop);
            this.Controls.Add(this.checkBoxStayInBoundary);
            this.Controls.Add(this.axVLCPlugin21);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonTestPlayVideo);
            this.Controls.Add(this.linkLabelVideoPath);
            this.Controls.Add(this.labelPercentComplete);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Simple Video Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop_1);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter_1);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQuality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redRangeStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redRangeEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeftCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRightCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBottomCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTopCrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.LinkLabel linkLabelVideoPath;
        private System.Windows.Forms.Button buttonTestPlayVideo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBox1;
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.CheckBox checkBoxStayInBoundary;
        private System.Windows.Forms.CheckBox checkBoxShowCrop;
        private System.Windows.Forms.TrackBar trackBarFPS;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.TextBox textBoxOutputName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBarQuality;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.PictureBox redRangeStart;
        private System.Windows.Forms.PictureBox greenRange;
        private System.Windows.Forms.PictureBox redRangeEnd;
        private System.Windows.Forms.Button buttonSetStart;
        private System.Windows.Forms.Button buttonSetEnd;
        private System.Windows.Forms.ListView listViewVideos;
        private System.Windows.Forms.ColumnHeader fileName;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader fileSize;
        private System.Windows.Forms.PictureBox pictureBoxLeftCrop;
        private System.Windows.Forms.PictureBox pictureBoxRightCrop;
        private System.Windows.Forms.PictureBox pictureBoxBottomCrop;
        private System.Windows.Forms.PictureBox pictureBoxTopCrop;
        private System.Windows.Forms.Button buttonClearCrop;
        private System.Windows.Forms.Button buttonClip;
        private System.Windows.Forms.ProgressBar progressBarRender;
        private System.Windows.Forms.Label labelFileSize;
        private System.Windows.Forms.Label labelRenderTimeToComplete;
        private System.Windows.Forms.Label labelRenderTimeElapsed;
        private System.Windows.Forms.Label labelFFmpegConsole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.Timer timerVLCTimeStamp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.TrackBar trackBarAudioTrack;
        private System.Windows.Forms.CheckBox checkBoxSaveAudioTrack;
        private System.Windows.Forms.Label labelCurrentAudioTrack;
        private System.Windows.Forms.Label labelPercentComplete;
        private System.Windows.Forms.TextBox textBoxVideoListPath;
        private System.Windows.Forms.LinkLabel linkLabelOutputPath;
        private System.Windows.Forms.Label labelDirectoryLoadTime;
        private System.Windows.Forms.TextBox textBoxFFmpegBinaries;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSearchListView;
        private System.Windows.Forms.ComboBox comboBoxOutputFormat;
        private System.Windows.Forms.TextBox textBoxScaleX;
        private System.Windows.Forms.TextBox textBoxScaleY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonDev;
        private System.Windows.Forms.Button buttonAdvancedSettings;
    }
}

