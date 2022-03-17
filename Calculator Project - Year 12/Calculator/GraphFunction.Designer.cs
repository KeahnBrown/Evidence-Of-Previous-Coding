namespace Calculator
{
    partial class GraphFunction
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
            this.chtGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chtGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // chtGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.chtGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtGraph.Legends.Add(legend1);
            this.chtGraph.Location = new System.Drawing.Point(71, 31);
            this.chtGraph.Name = "chtGraph";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtGraph.Series.Add(series1);
            this.chtGraph.Size = new System.Drawing.Size(652, 382);
            this.chtGraph.TabIndex = 0;
            this.chtGraph.Text = "chart1";
            // 
            // GraphFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chtGraph);
            this.Name = "GraphFunction";
            this.Text = "GraphFunction";
            ((System.ComponentModel.ISupportInitialize)(this.chtGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chtGraph;
    }
}