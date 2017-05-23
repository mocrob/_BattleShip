using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

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
        public bool IsLive
        {
            get { return isLive; }
            set { isLive = value; }
        }
        //Масиивы координат корабля
        int[] x, y;

        public int[] X
        {
            get { return x; }
            set { x = value; }
        }
        public int[] Y
        {
            get { return y; }
            set { y = value; }
        }
        //Переменая для определения положения коробля на поле
        int rotation;
        /*
         * 0-up
         * 1-down
         * 2-left
         * 3-right
         */
        public int Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }
        //Нужно ли?!
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
       static string mode = "";


       public Ship(string _mode)
           : base(_mode)
        {
            mode = _mode;
        }
        public Ship(int _type, int _x, int _y, int _rotation, Field curField, string _mode):base(_mode)
        {
            mode = _mode;
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
        public void hit(Field curField, int _x, int _y)
        {
            if (curField.IsEnemyField == false)
            {
                Image res = global::battkeship.Properties.Resources.Water;
                this.hp -= 1;
                //четыре попадания по 4-х палубному/три попадания по 3-х палубному/два попадания по 2-х палубному/одно попадание по 1-палубному
                if (this.hp == 0)
                {
                    
                    isLive = false;
                    for (int i = 0; i < this.type; i++)
                    {
                        
                        //res = global::battkeship.Properties.Resources.Water;
                        curField._Field[x[i], y[i]].Condition = 8;
                        curField._Field[x[i], y[i]].onPaint(mode);
                        //curField._Field[_x, _y]._Cell.Image = res;
                    }
                    this.SpaceAroundTheShip(curField._Field);
                    return;
                }
                //одно попадание по 4-х палубному
                if (this.hp == 3)
                {
                    for (int i = 0; i < this.type; i++)
                    {
                        curField._Field[x[i], y[i]].Condition = 5;
                        curField._Field[x[i], y[i]].onPaint(mode);
                    }
                    curField._Field[_x, _y].Condition = -5;
                    curField._Field[_x, _y].onPaint(mode);
                }
                else
                {
                    //два попадание по 4-х палубному/одно попадание по 3-х палубному
                    if (this.hp == 2)
                    {
                        for (int i = 0; i < this.type; i++)
                        {
                            if (curField._Field[x[i], y[i]].Condition == -5)
                            {
                                curField._Field[x[i], y[i]].Condition = -6;
                            }
                            else
                            {
                                curField._Field[x[i], y[i]].Condition = 6;
                            }
                            curField._Field[x[i], y[i]].onPaint(mode);
                        }
                        
                        curField._Field[_x, _y].Condition = -6;
                        curField._Field[_x, _y].onPaint(mode);
                    }
                    else
                    {
                        //три попадания по 4-х палубному/два попадания по 3-х палубному/одно попадание по 2-х палубному
                        if (this.hp == 1)
                        {
                            for (int i = 0; i < this.type; i++)
                            {
                                if (curField._Field[x[i], y[i]].Condition == -6)
                                {
                                    curField._Field[x[i], y[i]].Condition = -7;
                                }
                                else
                                {
                                    curField._Field[x[i], y[i]].Condition = 7;
                                }
                                curField._Field[x[i], y[i]].onPaint(mode);
                            }
                            curField._Field[_x, _y].Condition = -7;
                            curField._Field[_x, _y].onPaint(mode);
                        }
                    }
                }
            }
            else
            {
                this.hp -= 1;
                curField._Field[_x, _y].Condition = 3;
                if (this.hp == 0)
                {
                    isLive = false;
                    for (int i = 0; i < this.type; i++)
                    {
                        //корабль убит
                        curField._Field[x[i], y[i]].Condition = 8;
                        curField._Field[x[i], y[i]].onPaint(mode);
                        curField._Field[x[i], y[i]]._Cell.Update();
                    }
                    //Отрисовать точками
                    this.SpaceAroundTheShip(curField._Field);
                }
                curField._Field[_x, _y].onPaint(mode);
                curField._Field[_x, _y]._Cell.Update();
            }


        }

        //Пространство вокруг корабля
        void SpaceAroundTheShip(Cell[,] _Field)
        {
            int Row = _Field.GetLength(1);
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (_Field[i, j].Condition == 8)
                    {
                        // up left
                        if (i > 0 && j > 0 && _Field[i - 1, j - 1].Condition == 2)
                        {
                            _Field[i - 1, j - 1].Condition = 4;
                            _Field[i - 1, j - 1].onPaint(mode);
                        }
                        //up
                        if (i > 0 && _Field[i - 1, j].Condition == 2)
                        {
                            _Field[i - 1, j].Condition = 4;
                            _Field[i - 1, j].onPaint(mode);
                            
                        }
                        //up right
                        if (i > 0 && j < Row - 1 && _Field[i - 1, j + 1].Condition == 2)
                        {
                            _Field[i - 1, j + 1].Condition = 4;
                            _Field[i - 1, j + 1].onPaint(mode);
                           
                        }
                        //right
                        if (j < Row - 1 && _Field[i, j + 1].Condition == 2)
                        {
                            _Field[i, j + 1].Condition = 4;
                            _Field[i, j + 1].onPaint(mode);
                          
                        }
                        //down right
                        if (i < Row - 1 && j < Row - 1 && _Field[i + 1, j + 1].Condition == 2)
                        {
                            _Field[i + 1, j + 1].Condition = 4;
                            _Field[i + 1, j + 1].onPaint(mode);
                            
                        }
                        //down
                        if (i < Row - 1 && _Field[i + 1, j].Condition == 2)
                        {
                            _Field[i + 1, j].Condition = 4;
                            _Field[i + 1, j].onPaint(mode);
                           
                        }
                        //down left
                        if (i < Row - 1 && j > 0 && _Field[i + 1, j - 1].Condition == 2)
                        {
                            _Field[i + 1, j - 1].Condition = 4;
                            _Field[i + 1, j - 1].onPaint(mode);
                         
                        }
                        //left
                        if (j > 0 && _Field[i, j - 1].Condition == 2)
                        {
                            _Field[i, j - 1].Condition = 4;
                            _Field[i, j - 1].onPaint(mode);
                        }
                    }
                }
            }
        }
        public Ship delete(Cell[,] _Field)
        {
            for (int i = 0; i < this.type; i++)
            {
                _Field[this.X[i], this.y[i]].Condition = 0;
                _Field[this.X[i], this.y[i]].onPaint(mode);
                _Field[this.X[i], this.y[i]].CanAdd = true;
                GC.Collect();
            }
            return null;
        }
    }
}
