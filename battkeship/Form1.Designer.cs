namespace battkeship
{
    partial class Battleship
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
            this.StartBut = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.deckPanel = new System.Windows.Forms.Panel();
            this.numOfOne = new System.Windows.Forms.Label();
            this.numOfTwo = new System.Windows.Forms.Label();
            this.numOfThree = new System.Windows.Forms.Label();
            this.numOfFour = new System.Windows.Forms.Label();
            this.fourDeck = new System.Windows.Forms.PictureBox();
            this.threeDeck = new System.Windows.Forms.PictureBox();
            this.twoDeck = new System.Windows.Forms.PictureBox();
            this.oneDeck = new System.Windows.Forms.PictureBox();
            this.Main_Menu = new System.Windows.Forms.Panel();
            this.ConfigPanel = new System.Windows.Forms.Panel();
            this.StyleOfDesignLb = new System.Windows.Forms.Label();
            this.StyleOfDesignCb = new System.Windows.Forms.ComboBox();
            this.ModeLb = new System.Windows.Forms.Label();
            this.ModeCb = new System.Windows.Forms.ComboBox();
            this.screenResolutionLb = new System.Windows.Forms.Label();
            this.screenResolutionCb = new System.Windows.Forms.ComboBox();
            this.applyConfig = new System.Windows.Forms.Button();
            this.backConfig = new System.Windows.Forms.Button();
            this.NetPanel = new System.Windows.Forms.Panel();
            this.nameLbl = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.netJoin = new System.Windows.Forms.Button();
            this.netBack = new System.Windows.Forms.Button();
            this.nameTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButExit = new System.Windows.Forms.Button();
            this.ButConfig = new System.Windows.Forms.Button();
            this.ButNet = new System.Windows.Forms.Button();
            this.ButSingle = new System.Windows.Forms.Button();
            this.stroke = new System.Windows.Forms.Label();
            this.playerName = new System.Windows.Forms.Label();
            this.enemyName = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.deckPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fourDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneDeck)).BeginInit();
            this.Main_Menu.SuspendLayout();
            this.ConfigPanel.SuspendLayout();
            this.NetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FieldTwo
            // 
            this.FieldTwo.Location = new System.Drawing.Point(590, 50);
            this.FieldTwo.Name = "FieldTwo";
            this.FieldTwo.Size = new System.Drawing.Size(350, 350);
            this.FieldTwo.TabIndex = 1;
            // 
            // FieldOne
            // 
            this.FieldOne.Location = new System.Drawing.Point(230, 50);
            this.FieldOne.Name = "FieldOne";
            this.FieldOne.Size = new System.Drawing.Size(350, 350);
            this.FieldOne.TabIndex = 0;
            // 
            // StartBut
            // 
            this.StartBut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StartBut.Location = new System.Drawing.Point(12, 370);
            this.StartBut.Name = "StartBut";
            this.StartBut.Size = new System.Drawing.Size(75, 23);
            this.StartBut.TabIndex = 6;
            this.StartBut.Text = "button2";
            this.StartBut.UseVisualStyleBackColor = true;
            this.StartBut.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(12, 341);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // deckPanel
            // 
            this.deckPanel.Controls.Add(this.numOfOne);
            this.deckPanel.Controls.Add(this.numOfTwo);
            this.deckPanel.Controls.Add(this.numOfThree);
            this.deckPanel.Controls.Add(this.numOfFour);
            this.deckPanel.Controls.Add(this.fourDeck);
            this.deckPanel.Controls.Add(this.threeDeck);
            this.deckPanel.Controls.Add(this.twoDeck);
            this.deckPanel.Controls.Add(this.oneDeck);
            this.deckPanel.Location = new System.Drawing.Point(12, 50);
            this.deckPanel.Name = "deckPanel";
            this.deckPanel.Size = new System.Drawing.Size(218, 170);
            this.deckPanel.TabIndex = 10;
            // 
            // numOfOne
            // 
            this.numOfOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfOne.AutoSize = true;
            this.numOfOne.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfOne.Location = new System.Drawing.Point(173, 135);
            this.numOfOne.Name = "numOfOne";
            this.numOfOne.Size = new System.Drawing.Size(146, 32);
            this.numOfOne.TabIndex = 9;
            this.numOfOne.Text = "numOfOne";
            // 
            // numOfTwo
            // 
            this.numOfTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfTwo.AutoSize = true;
            this.numOfTwo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfTwo.Location = new System.Drawing.Point(173, 93);
            this.numOfTwo.Name = "numOfTwo";
            this.numOfTwo.Size = new System.Drawing.Size(144, 32);
            this.numOfTwo.TabIndex = 8;
            this.numOfTwo.Text = "numOfTwo";
            // 
            // numOfThree
            // 
            this.numOfThree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfThree.AutoSize = true;
            this.numOfThree.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfThree.Location = new System.Drawing.Point(173, 51);
            this.numOfThree.Name = "numOfThree";
            this.numOfThree.Size = new System.Drawing.Size(165, 32);
            this.numOfThree.TabIndex = 7;
            this.numOfThree.Text = "numOfThree";
            // 
            // numOfFour
            // 
            this.numOfFour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numOfFour.AutoSize = true;
            this.numOfFour.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfFour.Location = new System.Drawing.Point(173, 9);
            this.numOfFour.Name = "numOfFour";
            this.numOfFour.Size = new System.Drawing.Size(151, 32);
            this.numOfFour.TabIndex = 6;
            this.numOfFour.Text = "numOfFour";
            // 
            // fourDeck
            // 
            this.fourDeck.Location = new System.Drawing.Point(0, 9);
            this.fourDeck.Name = "fourDeck";
            this.fourDeck.Size = new System.Drawing.Size(140, 35);
            this.fourDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fourDeck.TabIndex = 2;
            this.fourDeck.TabStop = false;
            this.fourDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.fourDeck_MouseDown);
            // 
            // threeDeck
            // 
            this.threeDeck.Location = new System.Drawing.Point(0, 51);
            this.threeDeck.Name = "threeDeck";
            this.threeDeck.Size = new System.Drawing.Size(105, 35);
            this.threeDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.threeDeck.TabIndex = 3;
            this.threeDeck.TabStop = false;
            this.threeDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.threeDeck_MouseDown);
            // 
            // twoDeck
            // 
            this.twoDeck.Location = new System.Drawing.Point(0, 93);
            this.twoDeck.Name = "twoDeck";
            this.twoDeck.Size = new System.Drawing.Size(70, 35);
            this.twoDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.twoDeck.TabIndex = 4;
            this.twoDeck.TabStop = false;
            this.twoDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.twoDeck_MouseDown);
            // 
            // oneDeck
            // 
            this.oneDeck.Location = new System.Drawing.Point(0, 135);
            this.oneDeck.Name = "oneDeck";
            this.oneDeck.Size = new System.Drawing.Size(35, 35);
            this.oneDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oneDeck.TabIndex = 5;
            this.oneDeck.TabStop = false;
            this.oneDeck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.oneDeck_MouseDown);
            // 
            // Main_Menu
            // 
            this.Main_Menu.Controls.Add(this.ConfigPanel);
            this.Main_Menu.Controls.Add(this.NetPanel);
            this.Main_Menu.Controls.Add(this.ButExit);
            this.Main_Menu.Controls.Add(this.ButConfig);
            this.Main_Menu.Controls.Add(this.ButNet);
            this.Main_Menu.Controls.Add(this.ButSingle);
            this.Main_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Menu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Main_Menu.Location = new System.Drawing.Point(0, 0);
            this.Main_Menu.Name = "Main_Menu";
            this.Main_Menu.Size = new System.Drawing.Size(954, 422);
            this.Main_Menu.TabIndex = 14;
            this.Main_Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Menu_Paint);
            // 
            // ConfigPanel
            // 
            this.ConfigPanel.Controls.Add(this.StyleOfDesignLb);
            this.ConfigPanel.Controls.Add(this.StyleOfDesignCb);
            this.ConfigPanel.Controls.Add(this.ModeLb);
            this.ConfigPanel.Controls.Add(this.ModeCb);
            this.ConfigPanel.Controls.Add(this.screenResolutionLb);
            this.ConfigPanel.Controls.Add(this.screenResolutionCb);
            this.ConfigPanel.Controls.Add(this.applyConfig);
            this.ConfigPanel.Controls.Add(this.backConfig);
            this.ConfigPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigPanel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfigPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigPanel.Name = "ConfigPanel";
            this.ConfigPanel.Size = new System.Drawing.Size(954, 422);
            this.ConfigPanel.TabIndex = 5;
            this.ConfigPanel.Visible = false;
            this.ConfigPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfigPanel_Paint);
            // 
            // StyleOfDesignLb
            // 
            this.StyleOfDesignLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StyleOfDesignLb.AutoSize = true;
            this.StyleOfDesignLb.Location = new System.Drawing.Point(304, 199);
            this.StyleOfDesignLb.Name = "StyleOfDesignLb";
            this.StyleOfDesignLb.Size = new System.Drawing.Size(149, 18);
            this.StyleOfDesignLb.TabIndex = 15;
            this.StyleOfDesignLb.Text = "Стиль оформления";
            // 
            // StyleOfDesignCb
            // 
            this.StyleOfDesignCb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StyleOfDesignCb.FormattingEnabled = true;
            this.StyleOfDesignCb.Items.AddRange(new object[] {
            "Классический",
            "Реалистичный"});
            this.StyleOfDesignCb.Location = new System.Drawing.Point(307, 220);
            this.StyleOfDesignCb.Name = "StyleOfDesignCb";
            this.StyleOfDesignCb.Size = new System.Drawing.Size(305, 26);
            this.StyleOfDesignCb.TabIndex = 14;
            // 
            // ModeLb
            // 
            this.ModeLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ModeLb.AutoSize = true;
            this.ModeLb.Location = new System.Drawing.Point(304, 145);
            this.ModeLb.Name = "ModeLb";
            this.ModeLb.Size = new System.Drawing.Size(56, 18);
            this.ModeLb.TabIndex = 13;
            this.ModeLb.Text = "Режим";
            // 
            // ModeCb
            // 
            this.ModeCb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ModeCb.FormattingEnabled = true;
            this.ModeCb.Items.AddRange(new object[] {
            "Оконный",
            "Полноэкранный"});
            this.ModeCb.Location = new System.Drawing.Point(307, 168);
            this.ModeCb.Name = "ModeCb";
            this.ModeCb.Size = new System.Drawing.Size(305, 26);
            this.ModeCb.TabIndex = 12;
            // 
            // screenResolutionLb
            // 
            this.screenResolutionLb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.screenResolutionLb.AutoSize = true;
            this.screenResolutionLb.Location = new System.Drawing.Point(304, 95);
            this.screenResolutionLb.Name = "screenResolutionLb";
            this.screenResolutionLb.Size = new System.Drawing.Size(151, 18);
            this.screenResolutionLb.TabIndex = 11;
            this.screenResolutionLb.Text = "Разрешение экрана";
            this.screenResolutionLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // screenResolutionCb
            // 
            this.screenResolutionCb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.screenResolutionCb.FormattingEnabled = true;
            this.screenResolutionCb.Location = new System.Drawing.Point(307, 116);
            this.screenResolutionCb.Name = "screenResolutionCb";
            this.screenResolutionCb.Size = new System.Drawing.Size(305, 26);
            this.screenResolutionCb.TabIndex = 10;
            // 
            // applyConfig
            // 
            this.applyConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.applyConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.applyConfig.Location = new System.Drawing.Point(421, 254);
            this.applyConfig.Name = "applyConfig";
            this.applyConfig.Size = new System.Drawing.Size(108, 23);
            this.applyConfig.TabIndex = 9;
            this.applyConfig.Text = "Применить";
            this.applyConfig.UseVisualStyleBackColor = true;
            this.applyConfig.Click += new System.EventHandler(this.applyConfig_Click);
            // 
            // backConfig
            // 
            this.backConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backConfig.Location = new System.Drawing.Point(307, 254);
            this.backConfig.Name = "backConfig";
            this.backConfig.Size = new System.Drawing.Size(108, 23);
            this.backConfig.TabIndex = 8;
            this.backConfig.Text = "Назад";
            this.backConfig.UseVisualStyleBackColor = true;
            this.backConfig.Click += new System.EventHandler(this.backConfig_Click);
            // 
            // NetPanel
            // 
            this.NetPanel.Controls.Add(this.nameLbl);
            this.NetPanel.Controls.Add(this.IP);
            this.NetPanel.Controls.Add(this.netJoin);
            this.NetPanel.Controls.Add(this.netBack);
            this.NetPanel.Controls.Add(this.nameTBox);
            this.NetPanel.Controls.Add(this.label1);
            this.NetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetPanel.Location = new System.Drawing.Point(0, 0);
            this.NetPanel.Name = "NetPanel";
            this.NetPanel.Size = new System.Drawing.Size(954, 422);
            this.NetPanel.TabIndex = 4;
            this.NetPanel.Visible = false;
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLbl.Location = new System.Drawing.Point(10, 25);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(150, 25);
            this.nameLbl.TabIndex = 6;
            this.nameLbl.Text = "Введите имя:";
            // 
            // IP
            // 
            this.IP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IP.Location = new System.Drawing.Point(12, 111);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(925, 21);
            this.IP.TabIndex = 5;
            // 
            // netJoin
            // 
            this.netJoin.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.netJoin.Location = new System.Drawing.Point(126, 148);
            this.netJoin.Name = "netJoin";
            this.netJoin.Size = new System.Drawing.Size(101, 23);
            this.netJoin.TabIndex = 4;
            this.netJoin.Text = "Подключиться";
            this.netJoin.UseVisualStyleBackColor = true;
            this.netJoin.Click += new System.EventHandler(this.netJoin_Click);
            // 
            // netBack
            // 
            this.netBack.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.netBack.Location = new System.Drawing.Point(13, 148);
            this.netBack.Name = "netBack";
            this.netBack.Size = new System.Drawing.Size(101, 23);
            this.netBack.TabIndex = 2;
            this.netBack.Text = "Назад";
            this.netBack.UseVisualStyleBackColor = true;
            this.netBack.Click += new System.EventHandler(this.netBack_Click);
            // 
            // nameTBox
            // 
            this.nameTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.nameTBox.Location = new System.Drawing.Point(12, 53);
            this.nameTBox.Name = "nameTBox";
            this.nameTBox.Size = new System.Drawing.Size(925, 21);
            this.nameTBox.TabIndex = 0;
            this.nameTBox.TextChanged += new System.EventHandler(this.nameTBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введите ip адрес:";
            // 
            // ButExit
            // 
            this.ButExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButExit.Location = new System.Drawing.Point(307, 238);
            this.ButExit.Name = "ButExit";
            this.ButExit.Size = new System.Drawing.Size(305, 39);
            this.ButExit.TabIndex = 3;
            this.ButExit.Text = "ВЫХОД";
            this.ButExit.UseVisualStyleBackColor = true;
            this.ButExit.Click += new System.EventHandler(this.ButExit_Click);
            // 
            // ButConfig
            // 
            this.ButConfig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButConfig.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButConfig.Location = new System.Drawing.Point(307, 193);
            this.ButConfig.Name = "ButConfig";
            this.ButConfig.Size = new System.Drawing.Size(305, 39);
            this.ButConfig.TabIndex = 2;
            this.ButConfig.Text = "НАСТРОЙКИ";
            this.ButConfig.UseVisualStyleBackColor = true;
            this.ButConfig.Click += new System.EventHandler(this.ButConfig_Click);
            // 
            // ButNet
            // 
            this.ButNet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButNet.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButNet.Location = new System.Drawing.Point(307, 148);
            this.ButNet.Name = "ButNet";
            this.ButNet.Size = new System.Drawing.Size(305, 39);
            this.ButNet.TabIndex = 1;
            this.ButNet.Text = "СЕТЕВАЯ";
            this.ButNet.UseVisualStyleBackColor = true;
            this.ButNet.Click += new System.EventHandler(this.ButNet_Click);
            // 
            // ButSingle
            // 
            this.ButSingle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButSingle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButSingle.Location = new System.Drawing.Point(307, 103);
            this.ButSingle.Name = "ButSingle";
            this.ButSingle.Size = new System.Drawing.Size(305, 39);
            this.ButSingle.TabIndex = 0;
            this.ButSingle.Text = "ОДИНОЧНАЯ";
            this.ButSingle.UseVisualStyleBackColor = true;
            this.ButSingle.Click += new System.EventHandler(this.ButSingle_Click);
            // 
            // stroke
            // 
            this.stroke.AutoSize = true;
            this.stroke.Location = new System.Drawing.Point(13, 301);
            this.stroke.Name = "stroke";
            this.stroke.Size = new System.Drawing.Size(35, 13);
            this.stroke.TabIndex = 11;
            this.stroke.Text = "label1";
            // 
            // playerName
            // 
            this.playerName.AutoSize = true;
            this.playerName.Location = new System.Drawing.Point(13, 246);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(39, 13);
            this.playerName.TabIndex = 12;
            this.playerName.Text = "Player:";
            // 
            // enemyName
            // 
            this.enemyName.AutoSize = true;
            this.enemyName.Location = new System.Drawing.Point(12, 276);
            this.enemyName.Name = "enemyName";
            this.enemyName.Size = new System.Drawing.Size(42, 13);
            this.enemyName.TabIndex = 13;
            this.enemyName.Text = "Enemy:";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(12, 23);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.ScoreLabel.TabIndex = 14;
            this.ScoreLabel.Text = "Score";
            // 
            // Battleship
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(954, 422);
            this.Controls.Add(this.Main_Menu);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.stroke);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.StartBut);
            this.Controls.Add(this.FieldTwo);
            this.Controls.Add(this.FieldOne);
            this.Controls.Add(this.deckPanel);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.enemyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Battleship";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Battleship";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.deckPanel.ResumeLayout(false);
            this.deckPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fourDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threeDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twoDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneDeck)).EndInit();
            this.Main_Menu.ResumeLayout(false);
            this.ConfigPanel.ResumeLayout(false);
            this.ConfigPanel.PerformLayout();
            this.NetPanel.ResumeLayout(false);
            this.NetPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel FieldTwo;
        public System.Windows.Forms.Panel FieldOne;
        public System.Windows.Forms.PictureBox fourDeck;
        public System.Windows.Forms.PictureBox threeDeck;
        public System.Windows.Forms.PictureBox twoDeck;
        public System.Windows.Forms.PictureBox oneDeck;
        private System.Windows.Forms.Button StartBut;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel deckPanel;
        public System.Windows.Forms.Label numOfOne;
        public System.Windows.Forms.Label numOfTwo;
        public System.Windows.Forms.Label numOfThree;
        public System.Windows.Forms.Label numOfFour;
        private System.Windows.Forms.Label stroke;
        private System.Windows.Forms.Label playerName;
        private System.Windows.Forms.Label enemyName;
        private System.Windows.Forms.Panel Main_Menu;
        private System.Windows.Forms.Button ButExit;
        private System.Windows.Forms.Button ButConfig;
        private System.Windows.Forms.Button ButNet;
        private System.Windows.Forms.Button ButSingle;
        private System.Windows.Forms.Panel NetPanel;
        private System.Windows.Forms.TextBox nameTBox;
        private System.Windows.Forms.Button netJoin;
        private System.Windows.Forms.Button netBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.Panel ConfigPanel;
        private System.Windows.Forms.Button applyConfig;
        private System.Windows.Forms.Button backConfig;
        private System.Windows.Forms.Label StyleOfDesignLb;
        private System.Windows.Forms.ComboBox StyleOfDesignCb;
        private System.Windows.Forms.Label ModeLb;
        private System.Windows.Forms.ComboBox ModeCb;
        private System.Windows.Forms.Label screenResolutionLb;
        private System.Windows.Forms.ComboBox screenResolutionCb;
        private System.Windows.Forms.Label ScoreLabel;
    }
}

