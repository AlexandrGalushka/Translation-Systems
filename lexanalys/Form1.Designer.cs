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
            this.ErrorsBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CodeBox
            // 
            this.CodeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeBox.Location = new System.Drawing.Point(78, 91);
            this.CodeBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(807, 415);
            this.CodeBox.TabIndex = 0;
            this.CodeBox.Text = "";
            // 
            // ReadCode
            // 
            this.ReadCode.Location = new System.Drawing.Point(78, 30);
            this.ReadCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReadCode.Name = "ReadCode";
            this.ReadCode.Size = new System.Drawing.Size(124, 44);
            this.ReadCode.TabIndex = 1;
            this.ReadCode.Text = "Считать код с файла";
            this.ReadCode.UseVisualStyleBackColor = true;
            // 
            // AnalysButton
            // 
            this.AnalysButton.Location = new System.Drawing.Point(208, 30);
            this.AnalysButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.numericCode.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericCode.Location = new System.Drawing.Point(12, 91);
            this.numericCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericCode.Name = "numericCode";
            this.numericCode.Size = new System.Drawing.Size(67, 415);
            this.numericCode.TabIndex = 4;
            this.numericCode.Text = "";
            // 
            // ErrorsBox
            // 
            this.ErrorsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ErrorsBox.Location = new System.Drawing.Point(12, 513);
            this.ErrorsBox.Margin = new System.Windows.Forms.Padding(4);
            this.ErrorsBox.Name = "ErrorsBox";
            this.ErrorsBox.Size = new System.Drawing.Size(868, 124);
            this.ErrorsBox.TabIndex = 5;
            this.ErrorsBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 650);
            this.Controls.Add(this.ErrorsBox);
            this.Controls.Add(this.numericCode);
            this.Controls.Add(this.AnalysButton);
            this.Controls.Add(this.ReadCode);
            this.Controls.Add(this.CodeBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox CodeBox;
        private System.Windows.Forms.Button ReadCode;
        private System.Windows.Forms.Button AnalysButton;
        private System.Windows.Forms.RichTextBox numericCode;
        private System.Windows.Forms.RichTextBox ErrorsBox;
    }
}

