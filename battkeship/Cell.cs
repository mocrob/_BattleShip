using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace battkeship
{
    class Cell
    {

        public Cell()
        {
            condition = 0;
            imgOnCell = global::battkeship.Properties.Resources.Water;
        }
        //состояние
        int condition;/*-1- граница поля
                       * 0-пустая клетка, 
                       * 1-корабль, 
                       * 2-рядом корабль,
                       * 3-попадание по кораблю, 
                       * 4-промах, 
                       * 5-одно попадание по 4-х палубному,
                       * 6-два попадание по 4-х палубному/одно попадание по 3-х палубному,
                       * 7-три попадания по 4-х палубному/два попадания по 3-х палубному/одно попадание по 2-х палубному,
                       * 8-четыре попадания по 4-х палубному/три попадания по 3-х палубному/два попадания по 2-х палубному/одно попадание по 1-палубному
                       */

        //изображение клетки поля
        Image imgOnCell;
        public int Condition
        {
            get { return condition; }
            set { condition = value; }
        }
        public Image ImgOnCell
        {
            get { return imgOnCell; }
            set { imgOnCell = value; }
        }

        //функция рисования клетки 
        public void onPaint()
        {
            if(this.condition==0)
            {
                imgOnCell = global::battkeship.Properties.Resources.Water;
                return;
            }
            if (this.condition == 1)
            {
                imgOnCell = global::battkeship.Properties.Resources.Ship_Green;
                return;
            }
            if (this.condition == 5)
            {
                imgOnCell = global::battkeship.Properties.Resources.Ship_Ligth_Yellow;
                return; 
            }
            if (this.condition == 6)
            {
                imgOnCell = global::battkeship.Properties.Resources.Ship_Yellow;
                return; 
            }
            if (this.condition == 7)
            {
                imgOnCell = global::battkeship.Properties.Resources.Ship_Orange;
                return;
            }
            if (this.condition == 8)
            {
                imgOnCell = global::battkeship.Properties.Resources.Ship_Red;
                return;
            }
        }
        

    }
}
