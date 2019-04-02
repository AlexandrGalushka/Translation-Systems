namespace lexanalys
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CodeBox = new System.Windows.Forms.RichTextBox();
            this.ReadCode = new System.Windows.Forms.Button();
            this.AnalysButton = new System.Windows.Forms.Button();
            this.numericCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CodeBox
            // 
            this.CodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeBox.Location = new System.Drawing.Point(89, 91);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(796, 547);
            this.CodeBox.TabIndex = 0;
            this.CodeBox.Text = "";
            // 
            // ReadCode
            // 
            this.ReadCode.Location = new System.Drawing.Point(89, 29);
            this.ReadCode.Name = "ReadCode";
            this.ReadCode.Size = new System.Drawing.Size(124, 44);
            this.ReadCode.TabIndex = 1;
            this.ReadCode.Text = "Считать код с файла";
            this.ReadCode.UseVisualStyleBackColor = true;
            // 
            // AnalysButton
            // 
            this.AnalysButton.Location = new System.Drawing.Point(219, 29);
            this.AnalysButton.Name = "AnalysButton";
            this.AnalysButton.Size = new System.Drawing.Size(128, 44);
            this.AnalysButton.TabIndex = 2;
            this.AnalysButton.Text = "Разобрать";
            this.AnalysButton.UseVisualStyleBackColor = true;
            // 
            // numericCode
            // 
            this.numericCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.numericCode.Location = new System.Drawing.Point(12, 91);
            this.numericCode.Name = "numericCode";
            this.numericCode.Size = new System.Drawing.Size(71, 547);
            this.numericCode.TabIndex = 4;
            this.numericCode.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 650);
            this.Controls.Add(this.numericCode);
            this.Controls.Add(this.AnalysButton);
            this.Controls.Add(this.ReadCode);
            this.Controls.Add(this.CodeBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CodeBox;
        private System.Windows.Forms.Button ReadCode;
        private System.Windows.Forms.Button AnalysButton;
        private System.Windows.Forms.RichTextBox numericCode;
    }
}

