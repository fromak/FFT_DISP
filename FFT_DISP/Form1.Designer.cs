namespace FFT_DISP
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.crtADC = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtFFT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbGoerzelParam = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbStopGoer = new System.Windows.Forms.MaskedTextBox();
            this.tbStartGoer = new System.Windows.Forms.MaskedTextBox();
            this.btMicroBack = new System.Windows.Forms.Button();
            this.btMicroStep = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbGoerzel = new System.Windows.Forms.RadioButton();
            this.rbFFTSharp = new System.Windows.Forms.RadioButton();
            this.rbGoerzelMod = new System.Windows.Forms.RadioButton();
            this.rbFFT = new System.Windows.Forms.RadioButton();
            this.lbFreq = new System.Windows.Forms.Label();
            this.cbAverage = new System.Windows.Forms.CheckBox();
            this.cbBlackman = new System.Windows.Forms.CheckBox();
            this.cbHamming = new System.Windows.Forms.CheckBox();
            this.tbStartPoint = new System.Windows.Forms.MaskedTextBox();
            this.cbLeadZero = new System.Windows.Forms.CheckBox();
            this.btFFT = new System.Windows.Forms.Button();
            this.btStepForward = new System.Windows.Forms.Button();
            this.btStepBack = new System.Windows.Forms.Button();
            this.lbEndPoint = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numFFT = new System.Windows.Forms.NumericUpDown();
            this.tbSampleRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTotalPoints = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numAdcAcc = new System.Windows.Forms.NumericUpDown();
            this.tbADCVolt = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBinLength = new System.Windows.Forms.ComboBox();
            this.lbLength = new System.Windows.Forms.Label();
            this.rbInt = new System.Windows.Forms.RadioButton();
            this.rbFloat = new System.Windows.Forms.RadioButton();
            this.rbBinary = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btFileOpen = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cbDecrNoise = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNoiseDepth = new System.Windows.Forms.TextBox();
            this.btRemNoise = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSearchLen = new System.Windows.Forms.MaskedTextBox();
            this.btSearch = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crtADC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtFFT)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbGoerzelParam.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFFT)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdcAcc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.91453F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.08547F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(811, 586);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.crtADC);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crtFFT);
            this.splitContainer1.Size = new System.Drawing.Size(642, 580);
            this.splitContainer1.SplitterDistance = 302;
            this.splitContainer1.TabIndex = 0;
            // 
            // crtADC
            // 
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.Name = "ChartArea1";
            this.crtADC.ChartAreas.Add(chartArea1);
            this.crtADC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtADC.Location = new System.Drawing.Point(0, 0);
            this.crtADC.Name = "crtADC";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Name = "Series1";
            this.crtADC.Series.Add(series1);
            this.crtADC.Size = new System.Drawing.Size(642, 302);
            this.crtADC.TabIndex = 0;
            this.crtADC.Text = "chart1";
            // 
            // crtFFT
            // 
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.LineColor = System.Drawing.Color.DarkRed;
            chartArea2.Name = "ChartArea1";
            this.crtFFT.ChartAreas.Add(chartArea2);
            this.crtFFT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crtFFT.Location = new System.Drawing.Point(0, 0);
            this.crtFFT.Name = "crtFFT";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Name = "Series1";
            this.crtFFT.Series.Add(series2);
            this.crtFFT.Size = new System.Drawing.Size(642, 274);
            this.crtFFT.TabIndex = 0;
            this.crtFFT.Text = "chart1";
            this.crtFFT.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.crtFFT_CursorPositionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(651, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(157, 580);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(149, 554);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "FFT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gbGoerzelParam);
            this.groupBox3.Controls.Add(this.btMicroBack);
            this.groupBox3.Controls.Add(this.btMicroStep);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.lbFreq);
            this.groupBox3.Controls.Add(this.cbAverage);
            this.groupBox3.Controls.Add(this.cbBlackman);
            this.groupBox3.Controls.Add(this.cbHamming);
            this.groupBox3.Controls.Add(this.tbStartPoint);
            this.groupBox3.Controls.Add(this.cbLeadZero);
            this.groupBox3.Controls.Add(this.btFFT);
            this.groupBox3.Controls.Add(this.btStepForward);
            this.groupBox3.Controls.Add(this.btStepBack);
            this.groupBox3.Controls.Add(this.lbEndPoint);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numFFT);
            this.groupBox3.Controls.Add(this.tbSampleRate);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lbTotalPoints);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(143, 548);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FFT Parameters";
            // 
            // gbGoerzelParam
            // 
            this.gbGoerzelParam.Controls.Add(this.label7);
            this.gbGoerzelParam.Controls.Add(this.label6);
            this.gbGoerzelParam.Controls.Add(this.tbStopGoer);
            this.gbGoerzelParam.Controls.Add(this.tbStartGoer);
            this.gbGoerzelParam.Location = new System.Drawing.Point(9, 455);
            this.gbGoerzelParam.Name = "gbGoerzelParam";
            this.gbGoerzelParam.Size = new System.Drawing.Size(128, 87);
            this.gbGoerzelParam.TabIndex = 22;
            this.gbGoerzelParam.TabStop = false;
            this.gbGoerzelParam.Text = "GoerzelParam";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Stop";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Start";
            // 
            // tbStopGoer
            // 
            this.tbStopGoer.Location = new System.Drawing.Point(7, 61);
            this.tbStopGoer.Mask = "0000.0000";
            this.tbStopGoer.Name = "tbStopGoer";
            this.tbStopGoer.Size = new System.Drawing.Size(100, 20);
            this.tbStopGoer.TabIndex = 1;
            // 
            // tbStartGoer
            // 
            this.tbStartGoer.Location = new System.Drawing.Point(7, 25);
            this.tbStartGoer.Mask = "0000.0000";
            this.tbStartGoer.Name = "tbStartGoer";
            this.tbStartGoer.Size = new System.Drawing.Size(100, 20);
            this.tbStartGoer.TabIndex = 0;
            // 
            // btMicroBack
            // 
            this.btMicroBack.Location = new System.Drawing.Point(3, 189);
            this.btMicroBack.Name = "btMicroBack";
            this.btMicroBack.Size = new System.Drawing.Size(18, 23);
            this.btMicroBack.TabIndex = 21;
            this.btMicroBack.Text = "<";
            this.btMicroBack.UseVisualStyleBackColor = true;
            this.btMicroBack.Click += new System.EventHandler(this.btMicroBack_Click);
            // 
            // btMicroStep
            // 
            this.btMicroStep.Location = new System.Drawing.Point(120, 189);
            this.btMicroStep.Name = "btMicroStep";
            this.btMicroStep.Size = new System.Drawing.Size(18, 23);
            this.btMicroStep.TabIndex = 20;
            this.btMicroStep.Text = ">";
            this.btMicroStep.UseVisualStyleBackColor = true;
            this.btMicroStep.Click += new System.EventHandler(this.btMicroStep_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rbGoerzel);
            this.groupBox5.Controls.Add(this.rbFFTSharp);
            this.groupBox5.Controls.Add(this.rbGoerzelMod);
            this.groupBox5.Controls.Add(this.rbFFT);
            this.groupBox5.Location = new System.Drawing.Point(9, 343);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(100, 112);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Conversion";
            // 
            // rbGoerzel
            // 
            this.rbGoerzel.AutoSize = true;
            this.rbGoerzel.Location = new System.Drawing.Point(6, 89);
            this.rbGoerzel.Name = "rbGoerzel";
            this.rbGoerzel.Size = new System.Drawing.Size(61, 17);
            this.rbGoerzel.TabIndex = 3;
            this.rbGoerzel.TabStop = true;
            this.rbGoerzel.Text = "Goerzel";
            this.rbGoerzel.UseVisualStyleBackColor = true;
            // 
            // rbFFTSharp
            // 
            this.rbFFTSharp.AutoSize = true;
            this.rbFFTSharp.Checked = true;
            this.rbFFTSharp.Location = new System.Drawing.Point(6, 43);
            this.rbFFTSharp.Name = "rbFFTSharp";
            this.rbFFTSharp.Size = new System.Drawing.Size(72, 17);
            this.rbFFTSharp.TabIndex = 2;
            this.rbFFTSharp.TabStop = true;
            this.rbFFTSharp.Text = "FFTSharp";
            this.rbFFTSharp.UseVisualStyleBackColor = true;
            // 
            // rbGoerzelMod
            // 
            this.rbGoerzelMod.AutoSize = true;
            this.rbGoerzelMod.Location = new System.Drawing.Point(7, 66);
            this.rbGoerzelMod.Name = "rbGoerzelMod";
            this.rbGoerzelMod.Size = new System.Drawing.Size(85, 17);
            this.rbGoerzelMod.TabIndex = 1;
            this.rbGoerzelMod.Text = "Goerzel Mod";
            this.rbGoerzelMod.UseVisualStyleBackColor = true;
            // 
            // rbFFT
            // 
            this.rbFFT.AutoSize = true;
            this.rbFFT.Location = new System.Drawing.Point(7, 20);
            this.rbFFT.Name = "rbFFT";
            this.rbFFT.Size = new System.Drawing.Size(44, 17);
            this.rbFFT.TabIndex = 0;
            this.rbFFT.Text = "FFT";
            this.rbFFT.UseVisualStyleBackColor = true;
            // 
            // lbFreq
            // 
            this.lbFreq.AutoSize = true;
            this.lbFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbFreq.Location = new System.Drawing.Point(6, 307);
            this.lbFreq.Name = "lbFreq";
            this.lbFreq.Size = new System.Drawing.Size(37, 17);
            this.lbFreq.TabIndex = 16;
            this.lbFreq.Text = "freq";
            // 
            // cbAverage
            // 
            this.cbAverage.AutoSize = true;
            this.cbAverage.Location = new System.Drawing.Point(6, 287);
            this.cbAverage.Name = "cbAverage";
            this.cbAverage.Size = new System.Drawing.Size(66, 17);
            this.cbAverage.TabIndex = 15;
            this.cbAverage.Text = "Average";
            this.cbAverage.UseVisualStyleBackColor = true;
            this.cbAverage.CheckedChanged += new System.EventHandler(this.cbAverage_CheckedChanged);
            // 
            // cbBlackman
            // 
            this.cbBlackman.AutoSize = true;
            this.cbBlackman.Location = new System.Drawing.Point(6, 264);
            this.cbBlackman.Name = "cbBlackman";
            this.cbBlackman.Size = new System.Drawing.Size(73, 17);
            this.cbBlackman.TabIndex = 14;
            this.cbBlackman.Text = "Blackman";
            this.cbBlackman.UseVisualStyleBackColor = true;
            this.cbBlackman.CheckedChanged += new System.EventHandler(this.cbBlackman_CheckedChanged);
            // 
            // cbHamming
            // 
            this.cbHamming.AutoSize = true;
            this.cbHamming.Location = new System.Drawing.Point(6, 241);
            this.cbHamming.Name = "cbHamming";
            this.cbHamming.Size = new System.Drawing.Size(70, 17);
            this.cbHamming.TabIndex = 13;
            this.cbHamming.Text = "Hamming";
            this.cbHamming.UseVisualStyleBackColor = true;
            this.cbHamming.CheckedChanged += new System.EventHandler(this.cbHamming_CheckedChanged);
            // 
            // tbStartPoint
            // 
            this.tbStartPoint.HidePromptOnLeave = true;
            this.tbStartPoint.Location = new System.Drawing.Point(6, 142);
            this.tbStartPoint.Mask = "0000000000";
            this.tbStartPoint.Name = "tbStartPoint";
            this.tbStartPoint.Size = new System.Drawing.Size(100, 20);
            this.tbStartPoint.TabIndex = 12;
            this.tbStartPoint.Text = "0";
            this.tbStartPoint.TextChanged += new System.EventHandler(this.tbStartPoint_TextChanged);
            // 
            // cbLeadZero
            // 
            this.cbLeadZero.AutoSize = true;
            this.cbLeadZero.Location = new System.Drawing.Point(6, 218);
            this.cbLeadZero.Name = "cbLeadZero";
            this.cbLeadZero.Size = new System.Drawing.Size(81, 17);
            this.cbLeadZero.TabIndex = 11;
            this.cbLeadZero.Text = "Lead Zero?";
            this.cbLeadZero.UseVisualStyleBackColor = true;
            // 
            // btFFT
            // 
            this.btFFT.Location = new System.Drawing.Point(52, 189);
            this.btFFT.Name = "btFFT";
            this.btFFT.Size = new System.Drawing.Size(41, 23);
            this.btFFT.TabIndex = 10;
            this.btFFT.Text = "Conv";
            this.btFFT.UseVisualStyleBackColor = true;
            this.btFFT.Click += new System.EventHandler(this.btFFT_Click);
            // 
            // btStepForward
            // 
            this.btStepForward.Location = new System.Drawing.Point(93, 189);
            this.btStepForward.Name = "btStepForward";
            this.btStepForward.Size = new System.Drawing.Size(27, 23);
            this.btStepForward.TabIndex = 9;
            this.btStepForward.Text = ">>";
            this.btStepForward.UseVisualStyleBackColor = true;
            this.btStepForward.Click += new System.EventHandler(this.btStepForward_Click);
            // 
            // btStepBack
            // 
            this.btStepBack.Location = new System.Drawing.Point(21, 189);
            this.btStepBack.Name = "btStepBack";
            this.btStepBack.Size = new System.Drawing.Size(31, 23);
            this.btStepBack.TabIndex = 8;
            this.btStepBack.Text = "<<";
            this.btStepBack.UseVisualStyleBackColor = true;
            this.btStepBack.Click += new System.EventHandler(this.btStepBack_Click);
            // 
            // lbEndPoint
            // 
            this.lbEndPoint.AutoSize = true;
            this.lbEndPoint.Location = new System.Drawing.Point(6, 172);
            this.lbEndPoint.Name = "lbEndPoint";
            this.lbEndPoint.Size = new System.Drawing.Size(59, 13);
            this.lbEndPoint.TabIndex = 7;
            this.lbEndPoint.Text = "Stop Point:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Start Point:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "FFT Points:";
            // 
            // numFFT
            // 
            this.numFFT.Location = new System.Drawing.Point(6, 94);
            this.numFFT.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.numFFT.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numFFT.Name = "numFFT";
            this.numFFT.Size = new System.Drawing.Size(100, 20);
            this.numFFT.TabIndex = 3;
            this.numFFT.ThousandsSeparator = true;
            this.numFFT.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numFFT.ValueChanged += new System.EventHandler(this.numFFT_ValueChanged);
            // 
            // tbSampleRate
            // 
            this.tbSampleRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSampleRate.Location = new System.Drawing.Point(6, 54);
            this.tbSampleRate.Name = "tbSampleRate";
            this.tbSampleRate.Size = new System.Drawing.Size(100, 20);
            this.tbSampleRate.TabIndex = 2;
            this.tbSampleRate.Text = "8000";
            this.tbSampleRate.TextChanged += new System.EventHandler(this.tbSampleRate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sample Rate:";
            // 
            // lbTotalPoints
            // 
            this.lbTotalPoints.AutoSize = true;
            this.lbTotalPoints.Location = new System.Drawing.Point(6, 16);
            this.lbTotalPoints.Name = "lbTotalPoints";
            this.lbTotalPoints.Size = new System.Drawing.Size(39, 13);
            this.lbTotalPoints.TabIndex = 0;
            this.lbTotalPoints.Text = "Points:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(149, 554);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(143, 548);
            this.splitContainer2.SplitterDistance = 479;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.cbBinLength);
            this.groupBox2.Controls.Add(this.lbLength);
            this.groupBox2.Controls.Add(this.rbInt);
            this.groupBox2.Controls.Add(this.rbFloat);
            this.groupBox2.Controls.Add(this.rbBinary);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(143, 479);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File Parameters";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.numAdcAcc);
            this.groupBox4.Controls.Add(this.tbADCVolt);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 218);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(110, 100);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ADC Parameters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "ADC Accuracy(bit):";
            // 
            // numAdcAcc
            // 
            this.numAdcAcc.Location = new System.Drawing.Point(7, 74);
            this.numAdcAcc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAdcAcc.Name = "numAdcAcc";
            this.numAdcAcc.Size = new System.Drawing.Size(93, 20);
            this.numAdcAcc.TabIndex = 2;
            this.numAdcAcc.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // tbADCVolt
            // 
            this.tbADCVolt.HidePromptOnLeave = true;
            this.tbADCVolt.Location = new System.Drawing.Point(9, 32);
            this.tbADCVolt.Mask = "0.00";
            this.tbADCVolt.Name = "tbADCVolt";
            this.tbADCVolt.Size = new System.Drawing.Size(91, 20);
            this.tbADCVolt.TabIndex = 1;
            this.tbADCVolt.Text = "33";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADC Voltage:";
            // 
            // cbBinLength
            // 
            this.cbBinLength.FormattingEnabled = true;
            this.cbBinLength.Items.AddRange(new object[] {
            "8",
            "16",
            "32",
            "64"});
            this.cbBinLength.Location = new System.Drawing.Point(6, 163);
            this.cbBinLength.Name = "cbBinLength";
            this.cbBinLength.Size = new System.Drawing.Size(97, 21);
            this.cbBinLength.TabIndex = 4;
            this.cbBinLength.Visible = false;
            // 
            // lbLength
            // 
            this.lbLength.AutoSize = true;
            this.lbLength.Location = new System.Drawing.Point(6, 136);
            this.lbLength.Name = "lbLength";
            this.lbLength.Size = new System.Drawing.Size(73, 13);
            this.lbLength.TabIndex = 3;
            this.lbLength.Text = "Length in bits:";
            this.lbLength.Visible = false;
            // 
            // rbInt
            // 
            this.rbInt.AutoSize = true;
            this.rbInt.Location = new System.Drawing.Point(6, 97);
            this.rbInt.Name = "rbInt";
            this.rbInt.Size = new System.Drawing.Size(58, 17);
            this.rbInt.TabIndex = 2;
            this.rbInt.TabStop = true;
            this.rbInt.Text = "Integer";
            this.rbInt.UseVisualStyleBackColor = true;
            this.rbInt.CheckedChanged += new System.EventHandler(this.rbBinary_CheckedChanged);
            // 
            // rbFloat
            // 
            this.rbFloat.AutoSize = true;
            this.rbFloat.Location = new System.Drawing.Point(6, 58);
            this.rbFloat.Name = "rbFloat";
            this.rbFloat.Size = new System.Drawing.Size(48, 17);
            this.rbFloat.TabIndex = 1;
            this.rbFloat.TabStop = true;
            this.rbFloat.Text = "Float";
            this.rbFloat.UseVisualStyleBackColor = true;
            this.rbFloat.CheckedChanged += new System.EventHandler(this.rbBinary_CheckedChanged);
            // 
            // rbBinary
            // 
            this.rbBinary.AutoSize = true;
            this.rbBinary.Location = new System.Drawing.Point(6, 19);
            this.rbBinary.Name = "rbBinary";
            this.rbBinary.Size = new System.Drawing.Size(54, 17);
            this.rbBinary.TabIndex = 0;
            this.rbBinary.TabStop = true;
            this.rbBinary.Text = "Binary";
            this.rbBinary.UseVisualStyleBackColor = true;
            this.rbBinary.CheckedChanged += new System.EventHandler(this.rbBinary_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btFileOpen);
            this.groupBox1.Controls.Add(this.tbFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(143, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File";
            // 
            // btFileOpen
            // 
            this.btFileOpen.Location = new System.Drawing.Point(84, 14);
            this.btFileOpen.Name = "btFileOpen";
            this.btFileOpen.Size = new System.Drawing.Size(32, 20);
            this.btFileOpen.TabIndex = 1;
            this.btFileOpen.Text = "...";
            this.btFileOpen.UseVisualStyleBackColor = true;
            this.btFileOpen.Click += new System.EventHandler(this.btFileOpen_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(6, 14);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(78, 20);
            this.tbFile.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gbSearch);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(149, 554);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Search";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbSearch
            // 
            this.gbSearch.AutoSize = true;
            this.gbSearch.Controls.Add(this.cbDecrNoise);
            this.gbSearch.Controls.Add(this.label9);
            this.gbSearch.Controls.Add(this.tbNoiseDepth);
            this.gbSearch.Controls.Add(this.btRemNoise);
            this.gbSearch.Controls.Add(this.label8);
            this.gbSearch.Controls.Add(this.tbSearchLen);
            this.gbSearch.Controls.Add(this.btSearch);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSearch.Location = new System.Drawing.Point(3, 3);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(143, 548);
            this.gbSearch.TabIndex = 0;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // cbDecrNoise
            // 
            this.cbDecrNoise.AutoSize = true;
            this.cbDecrNoise.Location = new System.Drawing.Point(6, 157);
            this.cbDecrNoise.Name = "cbDecrNoise";
            this.cbDecrNoise.Size = new System.Drawing.Size(114, 17);
            this.cbDecrNoise.TabIndex = 6;
            this.cbDecrNoise.Text = "Decrement Noise?";
            this.cbDecrNoise.UseVisualStyleBackColor = true;
            this.cbDecrNoise.CheckedChanged += new System.EventHandler(this.cbDecrNoise_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Noise Depth";
            // 
            // tbNoiseDepth
            // 
            this.tbNoiseDepth.Location = new System.Drawing.Point(6, 131);
            this.tbNoiseDepth.Name = "tbNoiseDepth";
            this.tbNoiseDepth.Size = new System.Drawing.Size(100, 20);
            this.tbNoiseDepth.TabIndex = 4;
            this.tbNoiseDepth.Text = "0";
            // 
            // btRemNoise
            // 
            this.btRemNoise.Location = new System.Drawing.Point(6, 84);
            this.btRemNoise.Name = "btRemNoise";
            this.btRemNoise.Size = new System.Drawing.Size(100, 23);
            this.btRemNoise.TabIndex = 3;
            this.btRemNoise.Text = "Rememb Noise";
            this.btRemNoise.UseVisualStyleBackColor = true;
            this.btRemNoise.Click += new System.EventHandler(this.btRemNoise_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Search Length";
            // 
            // tbSearchLen
            // 
            this.tbSearchLen.HidePromptOnLeave = true;
            this.tbSearchLen.Location = new System.Drawing.Point(6, 58);
            this.tbSearchLen.Mask = "0000000000";
            this.tbSearchLen.Name = "tbSearchLen";
            this.tbSearchLen.Size = new System.Drawing.Size(100, 20);
            this.tbSearchLen.TabIndex = 1;
            this.tbSearchLen.Text = "131072";
            // 
            // btSearch
            // 
            this.btSearch.Location = new System.Drawing.Point(6, 19);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 0;
            this.btSearch.Text = "Search";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 586);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "FFTViewer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crtADC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtFFT)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbGoerzelParam.ResumeLayout(false);
            this.gbGoerzelParam.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFFT)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdcAcc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtADC;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtFFT;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbBinLength;
        private System.Windows.Forms.Label lbLength;
        private System.Windows.Forms.RadioButton rbInt;
        private System.Windows.Forms.RadioButton rbFloat;
        private System.Windows.Forms.RadioButton rbBinary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btFileOpen;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btStepForward;
        private System.Windows.Forms.Button btStepBack;
        private System.Windows.Forms.Label lbEndPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numFFT;
        private System.Windows.Forms.TextBox tbSampleRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbTotalPoints;
        private System.Windows.Forms.CheckBox cbLeadZero;
        private System.Windows.Forms.Button btFFT;
        private System.Windows.Forms.MaskedTextBox tbStartPoint;
        private System.Windows.Forms.CheckBox cbHamming;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAdcAcc;
        private System.Windows.Forms.MaskedTextBox tbADCVolt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbBlackman;
        private System.Windows.Forms.CheckBox cbAverage;
        private System.Windows.Forms.Label lbFreq;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton rbGoerzelMod;
        private System.Windows.Forms.RadioButton rbFFT;
        private System.Windows.Forms.RadioButton rbFFTSharp;
        private System.Windows.Forms.Button btMicroStep;
        private System.Windows.Forms.Button btMicroBack;
        private System.Windows.Forms.RadioButton rbGoerzel;
        private System.Windows.Forms.GroupBox gbGoerzelParam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox tbStopGoer;
        private System.Windows.Forms.MaskedTextBox tbStartGoer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox tbSearchLen;
        private System.Windows.Forms.Button btSearch;
        private System.Windows.Forms.CheckBox cbDecrNoise;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNoiseDepth;
        private System.Windows.Forms.Button btRemNoise;
    }
}

