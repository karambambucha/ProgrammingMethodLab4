
namespace ServerApp
{
    partial class ServerForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SendToClientButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ServerOffButton = new System.Windows.Forms.Button();
            this.ServerOnButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ServerTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "IP-адрес";
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.textBox1.Location = new System.Drawing.Point(82, 385);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "127.0.0.1";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // SendToClientButton
            // 
            this.SendToClientButton.Enabled = false;
            this.SendToClientButton.Location = new System.Drawing.Point(12, 487);
            this.SendToClientButton.Name = "SendToClientButton";
            this.SendToClientButton.Size = new System.Drawing.Size(270, 30);
            this.SendToClientButton.TabIndex = 22;
            this.SendToClientButton.Text = "Передать клиенту";
            this.SendToClientButton.UseVisualStyleBackColor = true;
            this.SendToClientButton.Click += new System.EventHandler(this.SendToClientButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 523);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(270, 30);
            this.ExitButton.TabIndex = 21;
            this.ExitButton.Text = "Выход";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ServerOffButton
            // 
            this.ServerOffButton.Enabled = false;
            this.ServerOffButton.Location = new System.Drawing.Point(12, 451);
            this.ServerOffButton.Name = "ServerOffButton";
            this.ServerOffButton.Size = new System.Drawing.Size(270, 30);
            this.ServerOffButton.TabIndex = 20;
            this.ServerOffButton.Text = "Отключить сервер";
            this.ServerOffButton.UseVisualStyleBackColor = true;
            // 
            // ServerOnButton
            // 
            this.ServerOnButton.Location = new System.Drawing.Point(12, 413);
            this.ServerOnButton.Name = "ServerOnButton";
            this.ServerOnButton.Size = new System.Drawing.Size(270, 30);
            this.ServerOnButton.TabIndex = 19;
            this.ServerOnButton.Text = "Включить сервер";
            this.ServerOnButton.UseVisualStyleBackColor = true;
            this.ServerOnButton.Click += new System.EventHandler(this.ServerOnButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Серверная сторона";
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(288, 34);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.ReadOnly = true;
            this.ServerTextBox.Size = new System.Drawing.Size(303, 519);
            this.ServerTextBox.TabIndex = 17;
            this.ServerTextBox.Text = "";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 566);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SendToClientButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ServerOffButton);
            this.Controls.Add(this.ServerOnButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerTextBox);
            this.Name = "ServerForm";
            this.Text = "Программа-сервер";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SendToClientButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ServerOffButton;
        private System.Windows.Forms.Button ServerOnButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ServerTextBox;
    }
}