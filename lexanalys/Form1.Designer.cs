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
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(28, 91);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(836, 547);
            this.CodeBox.TabIndex = 0;
            this.CodeBox.Text = "";
            // 
            // ReadCode
            // 
            this.ReadCode.Location = new System.Drawing.Point(51, 29);
            this.ReadCode.Name = "ReadCode";
            this.ReadCode.Size = new System.Drawing.Size(124, 44);
            this.ReadCode.TabIndex = 1;
            this.ReadCode.Text = "Считать код с файла";
            this.ReadCode.UseVisualStyleBackColor = true;
            // 
            // AnalysButton
            // 
            this.AnalysButton.Location = new System.Drawing.Point(206, 29);
            this.AnalysButton.Name = "AnalysButton";
            this.AnalysButton.Size = new System.Drawing.Size(128, 44);
            this.AnalysButton.TabIndex = 2;
            this.AnalysButton.Text = "Разобрать";
            this.AnalysButton.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(427, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 650);
            this.Controls.Add(this.button3);
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
        private System.Windows.Forms.Button button3;
    }
}

