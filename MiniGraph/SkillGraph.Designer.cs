namespace MiniGraph
{
    partial class SkillGraph
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
            this.SGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TopHeader = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // SGraph
            // 
            this.SGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SGraph.Location = new System.Drawing.Point(9, 27);
            this.SGraph.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SGraph.Name = "SGraph";
            this.SGraph.Size = new System.Drawing.Size(582, 304);
            this.SGraph.TabIndex = 1;
            this.SGraph.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "■";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(535, 333);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(56, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // TopHeader
            // 
            this.TopHeader.Location = new System.Drawing.Point(28, 10);
            this.TopHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TopHeader.Name = "TopHeader";
            this.TopHeader.Size = new System.Drawing.Size(562, 19);
            this.TopHeader.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(9, 333);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(521, 22);
            this.label2.TabIndex = 6;
            // 
            // SkillGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.ControlBox = false;
            this.Controls.Add(this.SGraph);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TopHeader);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SkillGraph";
            this.Text = "SkillGraph";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SkillGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart SGraph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label TopHeader;
        private System.Windows.Forms.Label label2;
    }
}