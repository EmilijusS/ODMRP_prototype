namespace ODMRPprototype
{
    partial class MainWindow
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
            this.NextStepButton = new System.Windows.Forms.Button();
            this.AddNodeButton = new System.Windows.Forms.Button();
            this.DataSentBox = new System.Windows.Forms.TextBox();
            this.DataReceivedBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NextStepButton
            // 
            this.NextStepButton.Location = new System.Drawing.Point(137, 181);
            this.NextStepButton.Name = "NextStepButton";
            this.NextStepButton.Size = new System.Drawing.Size(75, 23);
            this.NextStepButton.TabIndex = 0;
            this.NextStepButton.Text = "Next step";
            this.NextStepButton.UseVisualStyleBackColor = true;
            this.NextStepButton.Click += new System.EventHandler(this.NextStepButton_Click);
            // 
            // AddNodeButton
            // 
            this.AddNodeButton.Location = new System.Drawing.Point(278, 181);
            this.AddNodeButton.Name = "AddNodeButton";
            this.AddNodeButton.Size = new System.Drawing.Size(75, 23);
            this.AddNodeButton.TabIndex = 1;
            this.AddNodeButton.Text = "Add node";
            this.AddNodeButton.UseVisualStyleBackColor = true;
            this.AddNodeButton.Click += new System.EventHandler(this.AddNodeButton_Click);
            // 
            // DataSentBox
            // 
            this.DataSentBox.Location = new System.Drawing.Point(91, 12);
            this.DataSentBox.Multiline = true;
            this.DataSentBox.Name = "DataSentBox";
            this.DataSentBox.Size = new System.Drawing.Size(262, 76);
            this.DataSentBox.TabIndex = 2;
            // 
            // DataReceivedBox
            // 
            this.DataReceivedBox.Location = new System.Drawing.Point(91, 94);
            this.DataReceivedBox.Multiline = true;
            this.DataReceivedBox.Name = "DataReceivedBox";
            this.DataReceivedBox.Size = new System.Drawing.Size(262, 81);
            this.DataReceivedBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data sent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data received";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 219);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataReceivedBox);
            this.Controls.Add(this.DataSentBox);
            this.Controls.Add(this.AddNodeButton);
            this.Controls.Add(this.NextStepButton);
            this.Name = "MainWindow";
            this.Text = "ODMRP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NextStepButton;
        private System.Windows.Forms.Button AddNodeButton;
        private System.Windows.Forms.TextBox DataSentBox;
        private System.Windows.Forms.TextBox DataReceivedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

