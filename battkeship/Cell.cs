using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace battkeship
{
    class Cell
    {

        public Cell()
        {
            cell = new PictureBox();
            isEmpty = true;
            condition = 0;
            cell.Image = global::battkeship.Properties.Resources.Water;
            isBorder = false;
            canAdd = true;
        }

        bool canAdd;
        public bool CanAdd
        {
            get { return canAdd; }
            set { canAdd = value; }
        }
        //
        PictureBox cell;

        public PictureBox _Cell
        {
            get { return cell; }
            set { cell = value; }
        }
        //граница
        bool isBorder;
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
        //Клетка пустая (condition =0)
        bool isEmpty;
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

        public bool IsEmpty
        {
            get { return isEmpty; }
            set { isEmpty = value; }
        }

        public bool IsBorder
        {
            get { return isBorder; }
            set { isBorder = value; }
        }
        //функция рисования клетки 
        public void onPaint()
        {
            
            if(this.condition==0)
            {
                cell.Image = global::battkeship.Properties.Resources.Water;
                return;
            }
            if (this.condition == 1)
            {
                cell.Image = global::battkeship.Properties.Resources.Ship_Green;
                return;
            }
            if (this.condition == 3)
            {
                cell.Image = global::battkeship.Properties.Resources.HitWater;
                return;
            }
            if (this.condition == 4)
            {
                cell.Image = global::battkeship.Properties.Resources.MissWater;
                return;
            }
            if (this.condition == 5)
            {
                cell.Image = global::battkeship.Properties.Resources.Ship_Ligth_Yellow;
                return; 
            }
            if (this.condition == 6)
            {
                cell.Image = global::battkeship.Properties.Resources.Ship_Yellow;
                return; 
            }
            if (this.condition == 7)
            {
                cell.Image = global::battkeship.Properties.Resources.Ship_Orange;
                return;
            }
            if (this.condition == 8)
            {
                cell.Image = global::battkeship.Properties.Resources.Ship_Red;
                return;
            }
        }
        

    }
}
