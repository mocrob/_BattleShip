using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace battkeship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point(100, 100);
            this.button1.Text = "Test";
            this.button2.Text = "Start game";
            this.button3.Text = "Generate";
            this.numOfFour.Text = ""; this.numOfThree.Text = ""; this.numOfTwo.Text = ""; this.numOfOne.Text = "";
            
        }
        Player player = new Player("Игрок1");
        Player enemy = new Player("Игрок2");
        Field MyField = new Field(false);
        Field EnemyField = new Field(true);



        int type,
        WScreen,HScreen,
        WTmp ,HTmp ,
        Xone,Yone,
        XTwo, YTwo,
        Xthree, YThree,
        XFour, YFour;
        private void Form1_Load(object sender, EventArgs e)
        {
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            player = MyField._Player;
            enemy = EnemyField._Player;
            shipDesk(oneDeck, twoDeck, threeDeck, fourDeck, numOfOne, numOfTwo, numOfThree, numOfFour);
        }

        //Доска кораблей
        void shipDesk(PictureBox one, PictureBox two, PictureBox three, PictureBox four, Label _one, Label _two, Label _three, Label _four)
        {
            _one.Text = player.NumOfShipOne.ToString();
            _two.Text = player.NumOfShipTwo.ToString();
            _three.Text = player.NumOfShipThree.ToString();
            _four.Text = player.NumOfShipFour.ToString();

            int size = FieldOne.Width / 10;
            //Отрисовка кораблей 
            one.Size = new System.Drawing.Size(size, size);
            one.Image = global::battkeship.Properties.Resources.Ship_Grey;

            two.Size = new System.Drawing.Size(2*size, size);
            two.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

            three.Size = new System.Drawing.Size(3 * size, size);
            three.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

            four.Size = new System.Drawing.Size(4 * size, size);
            four.Image = global::battkeship.Properties.Resources.FourShip_Grey;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            MyField.IsCreateMode = false;
        }


        /*Реализовать замену картинок*/
        private void fourDeck_MouseClick(object sender, MouseEventArgs e)
        {
            if (type != 4 && player.NumOfShipFour!=0)
            {
                MyField.IsSelected = true;
                type = 4;
                /**/
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Green;
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                /**/
                fourDeck.Size = new System.Drawing.Size(4 * size + 2, size + 2);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void threeDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 3 && player.NumOfShipThree!=0)
            {
                MyField.IsSelected = true;
                type = 3;
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                /**/
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Green;
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                /**/
                threeDeck.Size = new System.Drawing.Size(3 * size + 2, size + 2);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void twoDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 2 && player.NumOfShipTwo != 0)
            {
                MyField.IsSelected = true;
                type = 2;
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                /**/
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Green;
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                /**/
                twoDeck.Size = new System.Drawing.Size(2 * size + 2, size + 2);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                MyField.IsSelected = false;
                type = 0;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void oneDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 1 && player.NumOfShipOne!=0)
            {
                MyField.IsSelected = true;
                type = 1;
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                /**/
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Green;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                /**/
                oneDeck.Size = new System.Drawing.Size(size + 2, size + 2);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyField.test();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyField.RandomGenerator();
            EnemyField.RandomGenerator();
            MyField.DrawRand();
        }
        //Small
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            /// 
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem3.Enabled = true;
            toolStripMenuItem4.Enabled = true;
            WScreen = Screen.PrimaryScreen.WorkingArea.Width;
            HScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new System.Drawing.Size(500, 250);
            this.Location = new System.Drawing.Point(100, HScreen / 50);
            FieldOne.Size = new System.Drawing.Size(150, 150);
            FieldTwo.Size = new System.Drawing.Size(150, 150);
            deckPanel.Size = new System.Drawing.Size(100, fourDeck.Size.Height * 5);
            FieldOne.Location = new System.Drawing.Point(deckPanel.Location.X + deckPanel.Size.Width + 10, 30);
            FieldTwo.Location = new System.Drawing.Point(deckPanel.Location.X + deckPanel.Size.Width + FieldOne.Size.Width + 30, 30);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);


            
            threeDeck.Location = new System.Drawing.Point(threeDeck.Location.X, fourDeck.Location.Y + fourDeck.Size.Height + threeDeck.Size.Height / 5);
            twoDeck.Location = new System.Drawing.Point(twoDeck.Location.X, threeDeck.Location.Y + threeDeck.Size.Height + twoDeck.Size.Height / 5);
            oneDeck.Location = new System.Drawing.Point(oneDeck.Location.X, twoDeck.Location.Y + twoDeck.Size.Height + oneDeck.Size.Height / 5);

            numOfOne.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, oneDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfTwo.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, twoDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfThree.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, threeDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfFour.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, 9 + oneDeck.Size.Height / 7);

            numOfOne.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        //Medium
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem3.Enabled = false;
            toolStripMenuItem4.Enabled = true;
            this.Size = new System.Drawing.Size(970, 440);
            this.Location = new System.Drawing.Point(100, 100);
            FieldOne.Size = new System.Drawing.Size(350, 350);
            FieldTwo.Size = new System.Drawing.Size(350, 350);
            FieldOne.Location = new System.Drawing.Point(230,30);
            FieldTwo.Location = new System.Drawing.Point(590, 30);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            deckPanel.Location = new System.Drawing.Point(12,30);
            deckPanel.Size = new System.Drawing.Size(218, 170);

            

            oneDeck.Location = new System.Drawing.Point(0, 135);
            twoDeck.Location = new System.Drawing.Point(0, 93);
            threeDeck.Location = new System.Drawing.Point(0, 51);
            fourDeck.Location = new System.Drawing.Point(0, 9);

            numOfOne.Location = new System.Drawing.Point(173, 135+oneDeck.Size.Height/7);
            numOfTwo.Location = new System.Drawing.Point(173, 93+oneDeck.Size.Height/7);
            numOfThree.Location = new System.Drawing.Point(173, 51+oneDeck.Size.Height/7);
            numOfFour.Location = new System.Drawing.Point(173, 9 + oneDeck.Size.Height /7);

            numOfOne.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));


        }
        //Large
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // 
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem3.Enabled = true;
            toolStripMenuItem4.Enabled = false;
            WScreen = Screen.PrimaryScreen.WorkingArea.Width;
            HScreen = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new System.Drawing.Size(1190, 550);
            this.Location = new System.Drawing.Point(100, HScreen / 50);
            FieldOne.Size = new System.Drawing.Size(460, 460);
            FieldTwo.Size = new System.Drawing.Size(460, 460);
            FieldOne.Location = new System.Drawing.Point(230, 30);
            FieldTwo.Location = new System.Drawing.Point(700, 30);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            

            deckPanel.Size = new System.Drawing.Size(218, fourDeck.Size.Height*5);
            threeDeck.Location = new System.Drawing.Point(threeDeck.Location.X, fourDeck.Location.Y + fourDeck.Size.Height + threeDeck.Size.Height / 5);
            twoDeck.Location = new System.Drawing.Point(twoDeck.Location.X, threeDeck.Location.Y + threeDeck.Size.Height + twoDeck.Size.Height / 5);
            oneDeck.Location = new System.Drawing.Point(oneDeck.Location.X, twoDeck.Location.Y + twoDeck.Size.Height + oneDeck.Size.Height / 5);

            numOfOne.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, oneDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfTwo.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, twoDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfThree.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, threeDeck.Location.Y + oneDeck.Size.Height /7);
            numOfFour.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, 9 + oneDeck.Size.Height / 7);

            numOfOne.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem3.Enabled = false;
            toolStripMenuItem4.Enabled = false;
            fullScreenToolStripMenuItem.Enabled = false;
            onWindowToolStripMenuItem.Enabled = true;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            WScreen = Screen.PrimaryScreen.WorkingArea.Width;
            HScreen = Screen.PrimaryScreen.WorkingArea.Height;
            FieldOne.Size = new System.Drawing.Size(HScreen - 250, HScreen - 250);
            FieldTwo.Size = new System.Drawing.Size(HScreen - 250, HScreen - 250);
            FieldOne.Location = new System.Drawing.Point(deckPanel.Location.X + deckPanel.Size.Width+50, 30);
            FieldTwo.Location = new System.Drawing.Point(deckPanel.Location.X + deckPanel.Size.Width + FieldOne.Size.Width + 50, 30);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            deckPanel.Size = new System.Drawing.Size(fourDeck.Size.Width+35, fourDeck.Size.Height * 5);

            threeDeck.Location = new System.Drawing.Point(threeDeck.Location.X, fourDeck.Location.Y + fourDeck.Size.Height + threeDeck.Size.Height / 5);
            twoDeck.Location = new System.Drawing.Point(twoDeck.Location.X, threeDeck.Location.Y + threeDeck.Size.Height + twoDeck.Size.Height / 5);
            oneDeck.Location = new System.Drawing.Point(oneDeck.Location.X, twoDeck.Location.Y + twoDeck.Size.Height + oneDeck.Size.Height / 5);


            numOfOne.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, oneDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfTwo.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, twoDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfThree.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, threeDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfFour.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, 9+ oneDeck.Size.Height /7);

            numOfOne.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }

        private void onWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem3.Enabled = false;
            toolStripMenuItem4.Enabled = true;
            fullScreenToolStripMenuItem.Enabled = true;
            onWindowToolStripMenuItem.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(970, 440);
            this.Location = new System.Drawing.Point(100, 100);
            FieldOne.Size = new System.Drawing.Size(350, 350);
            FieldTwo.Size = new System.Drawing.Size(350, 350);
            FieldOne.Location = new System.Drawing.Point(230, 30);
            FieldTwo.Location = new System.Drawing.Point(590, 30);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);

            deckPanel.Size = new System.Drawing.Size(218, 170);
            deckPanel.Location = new System.Drawing.Point(12, 30);

            oneDeck.Location = new System.Drawing.Point(0, 135);
            twoDeck.Location = new System.Drawing.Point(0, 93);
            threeDeck.Location = new System.Drawing.Point(0, 51);
            fourDeck.Location = new System.Drawing.Point(0, 9);

            numOfOne.Location = new System.Drawing.Point(173, 135+oneDeck.Size.Height/7);
            numOfTwo.Location = new System.Drawing.Point(173, 93 + oneDeck.Size.Height / 7);
            numOfThree.Location = new System.Drawing.Point(173, 51 + oneDeck.Size.Height /7);
            numOfFour.Location = new System.Drawing.Point(173, 9 + oneDeck.Size.Height / 7);

            numOfOne.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
           /* WScreen = Screen.PrimaryScreen.WorkingArea.Width;
            HScreen = Screen.PrimaryScreen.WorkingArea.Height;
            if (WScreen != WTmp || HScreen != HTmp)
            {
                WTmp = WScreen;
                HTmp = HScreen;
                FieldOne.Size = new System.Drawing.Size(HScreen - 180, HScreen - 180);
                FieldTwo.Size = new System.Drawing.Size(HScreen - 180, HScreen - 180);
                FieldOne.Controls.Clear();
                FieldTwo.Controls.Clear();
                MyField.CreateField(FieldOne);
                EnemyField.CreateField(FieldTwo);
                threeDeck.Location = new System.Drawing.Point(threeDeck.Location.X, fourDeck.Location.Y + fourDeck.Size.Height + threeDeck.Size.Height / 5);
                twoDeck.Location = new System.Drawing.Point(twoDeck.Location.X, threeDeck.Location.Y + threeDeck.Size.Height + twoDeck.Size.Height / 5);
                oneDeck.Location = new System.Drawing.Point(oneDeck.Location.X, twoDeck.Location.Y + twoDeck.Size.Height + oneDeck.Size.Height / 5);
            }
            else
            {
                WTmp = 0;
                HTmp = 0;
                toolStripMenuItem2.Enabled = true;
                toolStripMenuItem3.Enabled = true;
                toolStripMenuItem4.Enabled = true;
                this.Size = new System.Drawing.Size(970, 440);
                this.Location = new System.Drawing.Point(100, 100);
                FieldOne.Size = new System.Drawing.Size(350, 350);
                FieldTwo.Size = new System.Drawing.Size(350, 350);
                FieldOne.Location = new System.Drawing.Point(230, 30);
                FieldTwo.Location = new System.Drawing.Point(590, 30);
                FieldOne.Controls.Clear();
                FieldTwo.Controls.Clear();
                MyField.CreateField(FieldOne);
                EnemyField.CreateField(FieldTwo);
                oneDeck.Location = new System.Drawing.Point(12, 161);
                twoDeck.Location = new System.Drawing.Point(12, 119);
                threeDeck.Location = new System.Drawing.Point(12, 77);
                fourDeck.Location = new System.Drawing.Point(12, 35);
            }*/
        }

        

       

       

       



    }
}
