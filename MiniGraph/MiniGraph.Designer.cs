namespace MiniGraph
{
    partial class MiniGraph
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
            this.InstanceInfo = new System.Windows.Forms.Label();
            this.OpacitySlider = new System.Windows.Forms.TrackBar();
            this.BottomInfo = new System.Windows.Forms.Label();
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuShowHide = new System.Windows.Forms.ToolStripMenuItem();
            this.borderYesNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ChangeBasicFull = new System.Windows.Forms.Button();
            this.PauseResume = new System.Windows.Forms.Button();
            this.LoadAnother = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // InstanceInfo
            // 
            this.InstanceInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstanceInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InstanceInfo.Location = new System.Drawing.Point(11, 3);
            this.InstanceInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.InstanceInfo.Name = "InstanceInfo";
            this.InstanceInfo.Size = new System.Drawing.Size(510, 18);
            this.InstanceInfo.TabIndex = 1;
            this.InstanceInfo.Text = "                                         ";
            // 
            // OpacitySlider
            // 
            this.OpacitySlider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpacitySlider.BackColor = System.Drawing.SystemColors.Control;
            this.OpacitySlider.Location = new System.Drawing.Point(523, 3);
            this.OpacitySlider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpacitySlider.Minimum = 1;
            this.OpacitySlider.Name = "OpacitySlider";
            this.OpacitySlider.Size = new System.Drawing.Size(78, 45);
            this.OpacitySlider.TabIndex = 2;
            this.OpacitySlider.Value = 10;
            this.OpacitySlider.Scroll += new System.EventHandler(this.Opacity_Scroll);
            // 
            // BottomInfo
            // 
            this.BottomInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BottomInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BottomInfo.Location = new System.Drawing.Point(9, 388);
            this.BottomInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BottomInfo.Name = "BottomInfo";
            this.BottomInfo.Size = new System.Drawing.Size(592, 19);
            this.BottomInfo.TabIndex = 3;
            this.BottomInfo.Text = "                                          ";
            this.BottomInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Graph
            // 
            this.Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Graph.Location = new System.Drawing.Point(9, 20);
            this.Graph.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(592, 366);
            this.Graph.SuppressExceptions = true;
            this.Graph.TabIndex = 4;
            this.Graph.Text = "chart1";
            this.Graph.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseDoubleClick);
            this.Graph.MouseLeave += new System.EventHandler(this.Graph_MouseLeave);
            this.Graph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseMove);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = global::MiniGraph.Properties.Resources.Zonde;
            this.notifyIcon1.Text = "MiniGraph";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuShowHide,
            this.borderYesNoToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.menuExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            this.contextMenuStrip1.Text = "MiniGraph";
            // 
            // menuShowHide
            // 
            this.menuShowHide.Name = "menuShowHide";
            this.menuShowHide.Size = new System.Drawing.Size(180, 22);
            this.menuShowHide.Text = "Show / Hide";
            this.menuShowHide.Click += new System.EventHandler(this.MenuShowHide_Click);
            // 
            // borderYesNoToolStripMenuItem
            // 
            this.borderYesNoToolStripMenuItem.Name = "borderYesNoToolStripMenuItem";
            this.borderYesNoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.borderYesNoToolStripMenuItem.Text = "Border Yes / No";
            this.borderYesNoToolStripMenuItem.Click += new System.EventHandler(this.BorderYesNoToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(180, 22);
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "■";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseUp);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(2, 388);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 19);
            this.button1.TabIndex = 6;
            this.button1.Text = "Border On";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ChangeBasicFull
            // 
            this.ChangeBasicFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeBasicFull.BackColor = System.Drawing.SystemColors.Control;
            this.ChangeBasicFull.Location = new System.Drawing.Point(470, 0);
            this.ChangeBasicFull.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ChangeBasicFull.Name = "ChangeBasicFull";
            this.ChangeBasicFull.Size = new System.Drawing.Size(51, 20);
            this.ChangeBasicFull.TabIndex = 7;
            this.ChangeBasicFull.Text = "Basic";
            this.ChangeBasicFull.UseVisualStyleBackColor = false;
            this.ChangeBasicFull.Click += new System.EventHandler(this.ChangeBasicFull_Click);
            // 
            // PauseResume
            // 
            this.PauseResume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PauseResume.BackColor = System.Drawing.SystemColors.Control;
            this.PauseResume.Location = new System.Drawing.Point(69, 388);
            this.PauseResume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PauseResume.Name = "PauseResume";
            this.PauseResume.Size = new System.Drawing.Size(62, 19);
            this.PauseResume.TabIndex = 8;
            this.PauseResume.Text = "Pause";
            this.PauseResume.UseVisualStyleBackColor = false;
            this.PauseResume.Click += new System.EventHandler(this.PauseResume_Click);
            // 
            // LoadAnother
            // 
            this.LoadAnother.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LoadAnother.BackColor = System.Drawing.SystemColors.Control;
            this.LoadAnother.Location = new System.Drawing.Point(136, 388);
            this.LoadAnother.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadAnother.Name = "LoadAnother";
            this.LoadAnother.Size = new System.Drawing.Size(74, 19);
            this.LoadAnother.TabIndex = 9;
            this.LoadAnother.Text = "Load Prev.";
            this.LoadAnother.UseVisualStyleBackColor = false;
            this.LoadAnother.Click += new System.EventHandler(this.LoadAnother_Click);
            // 
            // MiniGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(610, 410);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.ChangeBasicFull);
            this.Controls.Add(this.LoadAnother);
            this.Controls.Add(this.PauseResume);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OpacitySlider);
            this.Controls.Add(this.InstanceInfo);
            this.Controls.Add(this.BottomInfo);
            this.Icon = global::MiniGraph.Properties.Resources.Zonde;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MiniGraph";
            this.Text = "MiniGraph";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MiniGraph_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MiniGraph_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.OpacitySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label InstanceInfo;
        private System.Windows.Forms.TrackBar OpacitySlider;
        private System.Windows.Forms.Label BottomInfo;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuShowHide;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem borderYesNoToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ChangeBasicFull;
        private System.Windows.Forms.Button PauseResume;
        private System.Windows.Forms.Button LoadAnother;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

