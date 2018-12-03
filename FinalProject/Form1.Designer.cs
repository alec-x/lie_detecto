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
            this.faceResultText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heartResultText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(388, 171);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(225, 40);
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
            this.trainHeart.Location = new System.Drawing.Point(388, 299);
            this.trainHeart.Name = "trainHeart";
            this.trainHeart.Size = new System.Drawing.Size(225, 40);
            this.trainHeart.TabIndex = 2;
            this.trainHeart.Text = "train heart";
            this.trainHeart.UseVisualStyleBackColor = true;
            this.trainHeart.Click += new System.EventHandler(this.trainHeart_Click);
            // 
            // statusTrainText
            // 
            this.statusTrainText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTrainText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.statusTrainText.Location = new System.Drawing.Point(388, 217);
            this.statusTrainText.Name = "statusTrainText";
            this.statusTrainText.Size = new System.Drawing.Size(225, 30);
            this.statusTrainText.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(388, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "train face";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // faceResultText
            // 
            this.faceResultText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.faceResultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.faceResultText.Location = new System.Drawing.Point(13, 34);
            this.faceResultText.Name = "faceResultText";
            this.faceResultText.Size = new System.Drawing.Size(164, 30);
            this.faceResultText.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Face Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 12.8F);
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Heart Result";
            // 
            // heartResultText
            // 
            this.heartResultText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.heartResultText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.heartResultText.Location = new System.Drawing.Point(16, 94);
            this.heartResultText.Name = "heartResultText";
            this.heartResultText.Size = new System.Drawing.Size(164, 30);
            this.heartResultText.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(625, 351);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.heartResultText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.faceResultText);
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
        private System.Windows.Forms.TextBox faceResultText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox heartResultText;
    }
}

