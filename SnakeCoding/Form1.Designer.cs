namespace SnakeCoding
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
            this.components = new System.ComponentModel.Container();
            this.pbSnake = new System.Windows.Forms.PictureBox();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSnake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSnake
            // 
            this.pbSnake.BackColor = System.Drawing.Color.Green;
            this.pbSnake.Location = new System.Drawing.Point(727, 227);
            this.pbSnake.Name = "pbSnake";
            this.pbSnake.Size = new System.Drawing.Size(25, 25);
            this.pbSnake.TabIndex = 0;
            this.pbSnake.TabStop = false;
            // 
            // pbMap
            // 
            this.pbMap.BackColor = System.Drawing.Color.LavenderBlush;
            this.pbMap.Location = new System.Drawing.Point(672, 146);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(80, 1);
            this.pbMap.TabIndex = 1;
            this.pbMap.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pbSnake);
            this.Controls.Add(this.pbMap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbSnake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSnake;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.Timer gameTimer;
    }
}

