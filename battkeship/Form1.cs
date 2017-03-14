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
            this.button1.Text = "Test";
            this.button2.Text = "Start game";
            this.button3.Text = "Generate";
            this.numOfFour.Text = ""; this.numOfThree.Text = ""; this.numOfTwo.Text = ""; this.numOfOne.Text = "";
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            player = MyField._Player;
            shipDesk(oneDeck, twoDeck, threeDeck, fourDeck, numOfOne, numOfTwo, numOfThree, numOfFour);
        }
        Player player = new Player();
        Field MyField = new Field(false);
        Field EnemyField = new Field(true);
        
       
        
        int type;
        
       

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
            EnemyField.getMatrOfCondition(MyField.setMatrOfCondition());
            EnemyField.setPlayer(MyField);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyField.RandomGenerator();
            MyField.DrawRand();
        }

       

       



    }
}
