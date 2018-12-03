namespace FinalProject
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
            this.startButton = new System.Windows.Forms.Button();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.trainHeart = new System.Windows.Forms.Button();
            this.statusTrainText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(170, 171);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(100, 40);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "startSession";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // trainHeart
            // 
            this.trainHeart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trainHeart.Location = new System.Drawing.Point(170, 299);
            this.trainHeart.Name = "trainHeart";
            this.trainHeart.Size = new System.Drawing.Size(100, 40);
            this.trainHeart.TabIndex = 2;
            this.trainHeart.Text = "train heart";
            this.trainHeart.UseVisualStyleBackColor = true;
            this.trainHeart.Click += new System.EventHandler(this.trainHeart_Click);
            // 
            // statusTrainText
            // 
            this.statusTrainText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTrainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.statusTrainText.Location = new System.Drawing.Point(170, 217);
            this.statusTrainText.Name = "statusTrainText";
            this.statusTrainText.Size = new System.Drawing.Size(100, 30);
            this.statusTrainText.TabIndex = 3;
            this.statusTrainText.TextChanged += new System.EventHandler(this.statusTrainText_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(170, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "train face";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(282, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusTrainText);
            this.Controls.Add(this.trainHeart);
            this.Controls.Add(this.startButton);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Lie Detection Interface";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button trainHeart;
        private System.Windows.Forms.TextBox statusTrainText;
        private System.Windows.Forms.Button button1;
    }
}

