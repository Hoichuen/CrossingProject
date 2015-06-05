namespace ProCP
{
    partial class HelpGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpGUI));
            this.rTBHelp = new System.Windows.Forms.RichTextBox();
            this.cBoxHelpItems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rTBHelp
            // 
            this.rTBHelp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTBHelp.Location = new System.Drawing.Point(14, 42);
            this.rTBHelp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rTBHelp.Name = "rTBHelp";
            this.rTBHelp.Size = new System.Drawing.Size(303, 285);
            this.rTBHelp.TabIndex = 0;
            this.rTBHelp.Text = "";
            // 
            // cBoxHelpItems
            // 
            this.cBoxHelpItems.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cBoxHelpItems.DropDownHeight = 70;
            this.cBoxHelpItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxHelpItems.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxHelpItems.FormattingEnabled = true;
            this.cBoxHelpItems.IntegralHeight = false;
            this.cBoxHelpItems.Items.AddRange(new object[] {
            "How to?",
            "Crossing types",
            "Crossing settings",
            "Add Crossing",
            "Remove Crossing",
            "Lock Crossing",
            "Lock grid",
            "Toggle light",
            "Play Simulation",
            "Stop Simulation"});
            this.cBoxHelpItems.Location = new System.Drawing.Point(54, 9);
            this.cBoxHelpItems.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cBoxHelpItems.Name = "cBoxHelpItems";
            this.cBoxHelpItems.Size = new System.Drawing.Size(265, 25);
            this.cBoxHelpItems.TabIndex = 1;
            this.cBoxHelpItems.SelectedIndexChanged += new System.EventHandler(this.HelpGUI_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Help:";
            // 
            // HelpGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(331, 343);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBoxHelpItems);
            this.Controls.Add(this.rTBHelp);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HelpGUI";
            this.Text = "Help";
            this.Load += new System.EventHandler(this.HelpGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTBHelp;
        private System.Windows.Forms.ComboBox cBoxHelpItems;
        private System.Windows.Forms.Label label1;
    }
}