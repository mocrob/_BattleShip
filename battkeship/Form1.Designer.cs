namespace battkeship
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.FieldTwo = new System.Windows.Forms.Panel();
            this.FieldOne = new System.Windows.Forms.Panel();
            this.fourDeck = new System.Windows.Forms.PictureBox();
            this.threeDeck = new System.Windows.Forms.PictureBox();
            this.twoDeck = new System.Windows.Forms.PictureBox();
            this.oneDeck = new System.Windows.Forms.PictureBox();
            this.numOfFour = new System.Windows.Forms.Label();
            this.numOfThree = new System.Windows.Forms.Label();
            this.numOfTwo = new System.Windows.Forms.Label();
            this.numOfOne = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fourDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneDeck)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldTwo
            // 
            this.FieldTwo.Location = new System.Drawing.Point(588, 32);
            this.FieldTwo.Name = "FieldTwo";
            this.FieldTwo.Size = new System.Drawing.Size(350, 350);
            this.FieldTwo.TabIndex = 1;
            // 
            // FieldOne
            // 
            this.FieldOne.Location = new System.Drawing.Point(232, 32);
            this.FieldOne.Name = "FieldOne";
            this.FieldOne.Size = new System.Drawing.Size(350, 350);
            this.FieldOne.TabIndex = 0;
            // 
            // fourDeck
            // 
            this.fourDeck.Location = new System.Drawing.Point(12, 35);
            this.fourDeck.Name = "fourDeck";
            this.fourDeck.Size = new System.Drawing.Size(140, 35);
            this.fourDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourDeck.TabIndex = 2;
            this.fourDeck.TabStop = false;
            this.fourDeck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fourDeck_MouseClick);
            // 
            // threeDeck
            // 
            this.threeDeck.Location = new System.Drawing.Point(12, 76);
            this.threeDeck.Name = "threeDeck";
            this.threeDeck.Size = new System.Drawing.Size(105, 35);
            this.threeDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.threeDeck.TabIndex = 3;
            this.threeDeck.TabStop = false;
            this.threeDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.threeDeck_MouseDown);
            // 
            // twoDeck
            // 
            this.twoDeck.Location = new System.Drawing.Point(12, 117);
            this.twoDeck.Name = "twoDeck";
            this.twoDeck.Size = new System.Drawing.Size(70, 35);
            this.twoDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.twoDeck.TabIndex = 4;
            this.twoDeck.TabStop = false;
            this.twoDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.twoDeck_MouseDown);
            // 
            // oneDeck
            // 
            this.oneDeck.Location = new System.Drawing.Point(12, 158);
            this.oneDeck.Name = "oneDeck";
            this.oneDeck.Size = new System.Drawing.Size(35, 35);
            this.oneDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oneDeck.TabIndex = 5;
            this.oneDeck.TabStop = false;
            this.oneDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oneDeck_MouseDown);
            // 
            // numOfFour
            // 
            this.numOfFour.AutoSize = true;
            this.numOfFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfFour.Location = new System.Drawing.Point(175, 35);
            this.numOfFour.Name = "numOfFour";
            this.numOfFour.Size = new System.Drawing.Size(188, 39);
            this.numOfFour.TabIndex = 0;
            this.numOfFour.Text = "numOfFour";
            // 
            // numOfThree
            // 
            this.numOfThree.AutoSize = true;
            this.numOfThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfThree.Location = new System.Drawing.Point(175, 76);
            this.numOfThree.Name = "numOfThree";
            this.numOfThree.Size = new System.Drawing.Size(207, 39);
            this.numOfThree.TabIndex = 1;
            this.numOfThree.Text = "numOfThree";
            // 
            // numOfTwo
            // 
            this.numOfTwo.AutoSize = true;
            this.numOfTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfTwo.Location = new System.Drawing.Point(175, 117);
            this.numOfTwo.Name = "numOfTwo";
            this.numOfTwo.Size = new System.Drawing.Size(183, 39);
            this.numOfTwo.TabIndex = 2;
            this.numOfTwo.Text = "numOfTwo";
            // 
            // numOfOne
            // 
            this.numOfOne.AutoSize = true;
            this.numOfOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfOne.Location = new System.Drawing.Point(175, 158);
            this.numOfOne.Name = "numOfOne";
            this.numOfOne.Size = new System.Drawing.Size(182, 39);
            this.numOfOne.TabIndex = 3;
            this.numOfOne.Text = "numOfOne";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 359);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 399);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.oneDeck);
            this.Controls.Add(this.twoDeck);
            this.Controls.Add(this.threeDeck);
            this.Controls.Add(this.fourDeck);
            this.Controls.Add(this.FieldTwo);
            this.Controls.Add(this.FieldOne);
            this.Controls.Add(this.numOfOne);
            this.Controls.Add(this.numOfTwo);
            this.Controls.Add(this.numOfThree);
            this.Controls.Add(this.numOfFour);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.fourDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneDeck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FieldTwo;
        private System.Windows.Forms.Panel FieldOne;
        public System.Windows.Forms.PictureBox fourDeck;
        public System.Windows.Forms.PictureBox threeDeck;
        public System.Windows.Forms.PictureBox twoDeck;
        public System.Windows.Forms.PictureBox oneDeck;
        public System.Windows.Forms.Label numOfFour;
        public System.Windows.Forms.Label numOfThree;
        public System.Windows.Forms.Label numOfTwo;
        public System.Windows.Forms.Label numOfOne;
        private System.Windows.Forms.Button button2;

    }
}

