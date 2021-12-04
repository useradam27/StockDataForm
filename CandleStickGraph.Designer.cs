
namespace Project3
{
    partial class CandleStickGraph
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.patternBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.patterns_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 45);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1089, 533);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // patternBox
            // 
            this.patternBox.FormattingEnabled = true;
            this.patternBox.Items.AddRange(new object[] {
            "Neutral",
            "Long-Legged",
            "Gravestone",
            "Dragonfly",
            "Bullish Marubozus",
            "Bearish Marubozus"});
            this.patternBox.Location = new System.Drawing.Point(750, 13);
            this.patternBox.Name = "patternBox";
            this.patternBox.Size = new System.Drawing.Size(121, 21);
            this.patternBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(676, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patterns:";
            // 
            // patterns_button
            // 
            this.patterns_button.Location = new System.Drawing.Point(917, 13);
            this.patterns_button.Name = "patterns_button";
            this.patterns_button.Size = new System.Drawing.Size(137, 23);
            this.patterns_button.TabIndex = 4;
            this.patterns_button.Text = "Graph Pattern";
            this.patterns_button.UseVisualStyleBackColor = true;
            this.patterns_button.Click += new System.EventHandler(this.patterns_button_Click);
            // 
            // CandleStickGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 590);
            this.Controls.Add(this.patterns_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.patternBox);
            this.Controls.Add(this.chart1);
            this.Name = "CandleStickGraph";
            this.Text = "CandleStickGraph";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox patternBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button patterns_button;
    }
}