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
            this.button2.Text = "Start game";
            this.button1.Text = "Create";
            this.numOfFour.Text = ""; this.numOfThree.Text = ""; this.numOfTwo.Text = ""; this.numOfOne.Text = "";
            shipDesk(oneDeck, twoDeck, threeDeck, fourDeck, numOfOne, numOfTwo, numOfThree, numOfFour);
            
        }
        Field MyField = new Field(false);
        Field EnemyField = new Field(true);
        private void button1_Click(object sender, EventArgs e)
        {
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
        }

        //Доска кораблей
        void shipDesk(PictureBox one, PictureBox two, PictureBox three, PictureBox four, Label _one, Label _two, Label _three, Label _four)
        {

            int size = FieldOne.Width / 10;
            //Отрисовка кораблей 
            one.Size = new System.Drawing.Size(size, size);
            one.Image = global::battkeship.Properties.Resources.Ship_Green;

            two.Size = new System.Drawing.Size(2*size, size);
            two.Image = global::battkeship.Properties.Resources.TwoShip_Green;

            three.Size = new System.Drawing.Size(3 * size, size);
            three.Image = global::battkeship.Properties.Resources.ThreeShip_Green;

            four.Size = new System.Drawing.Size(4 * size, size);
            four.Image = global::battkeship.Properties.Resources.FourShip_Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyField.IsCreateMode = false;
        }


    }
}
