using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace battkeship
{
    class Ship : Cell
    {
        //Тип корабля
        int type;
        /*1-однопалубный
         * 2-двупалубный
         * 3-трехпалубный
         * 4-четырехпалубный
         */
        //Очки здоровья корабля
        int hp;
        //Жив или мертв
        bool isLive;
        //Масиивы координат корабля
        int[] x, y;
        //Переменая для определения положения коробля на поле
        int rotation;
        /*
         * 0-up
         * 1-down
         * 2-left
         * 3-right
         */

        //Нужно ли?!
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public Ship(int _type, int _x, int _y, int _rotation, Field curField)
        {
            rotation = _rotation;
            type = _type;
            x = new int[_type]; y = new int[_type];
            if (type == 1)
            {
                hp = 1;

            }
            else
                if (type == 2)
                {
                    hp = 2;

                }
                else
                    if (type == 3)
                    {
                        hp = 3;

                    }
                    else
                    {
                        hp = 4;

                    }
            fillMatrix(curField, type, _x, _y, rotation);
            isLive = true;
        }

        //Функция заполнения матрицы координат
        void fillMatrix(Field curField, int _type, int _x, int _y, int _rotation)
        {

            if (_type == 1)
            {
                curField._Field[_x, _y].Condition = 1;
                x[0] = _x; y[0] = _y;
                return;
            }

            //up
            if (_rotation == 0)
            {
                for (int i = 0; i < type; i++)
                {
                    curField._Field[_x, _y - i].Condition = 1;
                    x[i] = _x; y[i] = _y - i;
                }
            }
            else
            {
                //down
                if (_rotation == 1)
                {
                    for (int i = 0; i < type; i++)
                    {
                        curField._Field[_x, _y + i].Condition = 1;
                        x[i] = _x; y[i] = _y + i;
                    }
                }
                else
                {
                    //left
                    if (_rotation == 2)
                    {
                        for (int i = 0; i < type; i++)
                        {
                            curField._Field[_x - i, _y].Condition = 1;
                            x[i] = _x - i; y[i] = _y;
                        }
                    }
                    //right
                    else
                    {
                        for (int i = 0; i < type; i++)
                        {
                            curField._Field[_x + i, _y].Condition = 1;
                            x[i] = _x + i; y[i] = _y;
                        }
                    }
                }
            }
            return;
        }
        //Попадание
        void hit(Field curField, int _x, int _y)
        {
            this.hp -= 1;
            //четыре попадания по 4-х палубному/три попадания по 3-х палубному/два попадания по 2-х палубному/одно попадание по 1-палубному
            if (this.hp == 0)
            {
                isLive = false;
                for (int i = 0; i < this.type; i++)
                {
                    curField._Field[x[i], y[i]].Condition = 8;
                }
                return;
            }
            //одно попадание по 4-х палубному
            if (this.hp == 3)
            {
                for (int i = 0; i < this.type; i++)
                {
                    curField._Field[x[i], y[i]].Condition = 5;
                }
            }
            else
            {
                //два попадание по 4-х палубному/одно попадание по 3-х палубному
                if (this.hp == 2)
                {
                    for (int i = 0; i < this.type; i++)
                    {
                        curField._Field[x[i], y[i]].Condition = 6;
                    }
                }
                else
                {
                    //три попадания по 4-х палубному/два попадания по 3-х палубному/одно попадание по 2-х палубному
                    if (this.hp == 1)
                    {
                        for (int i = 0; i < this.type; i++)
                        {
                            curField._Field[x[i], y[i]].Condition = 7;
                        }
                    }
                }
            }
            curField._Field[_x, _y].Condition = 3;

        }



    }
}
