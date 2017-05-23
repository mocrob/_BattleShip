using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace battkeship
{

    class Field
    {
        //для изменения режимов отрисовки
        //по-умолчанию = ""
        string mode = "";

        public string Mode
        {
            get { return mode; }
            set { mode = value;}
        }
       // Player player = new Player(mode);
        Player player;
        public Player _Player
        {
            get { return player; }
            set { player = value; }
        }

        //Тип корабля
        int type;
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        //Поворот корабля
        int rotation;

        //Количество кораблей на поле (изначально 0, максимум 10)
        int numOfShips;
        public int NumOfShips
        {
            get { return numOfShips; }
            set { numOfShips = value; }
        }
        //Варжеское поле или поле игрока
        bool isEnemyField;

        public bool IsEnemyField
        {
            get { return isEnemyField; }
            set { isEnemyField = value; }
        }
        //Выбран ли корабль
        bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        //Режим расстановки кораблей
        bool isCreateMode;
        public bool IsCreateMode
        {
            get { return isCreateMode; }
            set { isCreateMode = value; }
        }
        //переменные, отвечающие за столбцы 
        static int Col = 10, Row = 10;

        //размер клетки (size) и координаты клетки
        int x, y, size;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        //Матрица состояний поля
        int[,] matrOfCondition;

        public int[,] MatrOfCondition
        {
            get { return matrOfCondition; }
            set { matrOfCondition = value; }
        }
        //Матрица поля 
        Cell[,] _field;

        public Cell[,] _Field
        {
            get { return _field; }
            set { _field = value; }
        }

        // счетчики для кораблей
        int one, two, three;

       

        //Конструктор при создании
        public Field(bool isEnemy, string _mode)
        {
            Player player = new Player(_mode);
            mode = _mode;
            _field = CellMatrix(Col, Row);
            //FieldBorder(_Field);
            isEnemyField = isEnemy;
            isCreateMode = true;
            numOfShips = 0;
            type = 0;
            rotation = 3;
        }

        public Field(string _mode)
        {
            Player player = new Player(_mode);
            mode = _mode;
            _field = CellMatrix(Col, Row);
            //FieldBorder(_Field);
            numOfShips = 0;
        }

        //Создание двумерного массива клеток(cell)
        Cell[,] CellMatrix(int col, int row)
        {
            Cell[,] M = new Cell[col, row];
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    M[i, j] = new Cell(mode);
                }
            }
            return M;
        }
        //Определяем границы поля
        void FieldBorder(Cell[,] M)
        {
            int i;
            for (i = 0; i < Row; i++)
            {
                M[0, i].IsBorder = true;
                M[Col - 1, i].IsBorder = true;
            }
            for (i = 0; i < Col; i++)
            {
                M[i, 0].IsBorder = true;
                M[i, Row - 1].IsBorder = true;
            }
        }
        //Функция обработки вхождения в область видимости объекта
        void Enter(object sender, EventArgs e)
        {


            PictureBox picEnter = sender as PictureBox;
            x = (int)Char.GetNumericValue(picEnter.Name[0]);
            y = (int)Char.GetNumericValue(picEnter.Name[2]);
            if (isEnemyField == false && isCreateMode == true && _field[x, y].IsEmpty/*condition=0*/== true)
            {
                _Enter(x, y, type, rotation, _field);
            }
            else if (isEnemyField == true)
            {
                Image res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "SelectedWater");
                // Image res = global::battkeship.Properties.Resources.SelectedWater;
                //Image res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject("SelectedWater.png");
                //Image res = Image.FromFile("../");
                if (_field[x, y].Condition == 0 || _field[x, y].Condition == 1 || _field[x, y].Condition == 2)
                {
                    _field[x, y]._Cell.Image = res;
                    _field[x, y]._Cell.Update();
                }
            }
        }

        //Функция обработки выхода из области видимости объекта
        void Leave(object sender, EventArgs e)
        {

            PictureBox picEnter = sender as PictureBox;
            x = (int)Char.GetNumericValue(picEnter.Name[0]);
            y = (int)Char.GetNumericValue(picEnter.Name[2]);
            if (isEnemyField == false && isCreateMode == true && _field[x, y].IsEmpty/*condition=0*/== true)
            {
                _Leave(x, y, type, rotation, _field);



            }
            else if (isEnemyField == true)
            {
                Image res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                //Image res = global::battkeship.Properties.Resources.Water;
                if (_field[x, y].Condition == 0 || _field[x, y].Condition == 1 || _field[x, y].Condition == 2)
                {
                    _field[x, y]._Cell.Image = res;
                    _field[x, y]._Cell.Update();
                }
            }
        }
        //Функция обработки нажатия кнопки мыши
        void Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                if (isEnemyField == false && isCreateMode == true && isSelected == true)
                {

                    PictureBox picClick = sender as PictureBox;

                    x = (int)Char.GetNumericValue(picClick.Name[0]);
                    y = (int)Char.GetNumericValue(picClick.Name[2]);
                    if (Check(x, y, type, rotation, _field) == true)
                    {
                        AddShip(type, x, y, rotation);
                        updateLabeles(Program.menu.numOfOne, Program.menu.numOfTwo, Program.menu.numOfThree, Program.menu.numOfFour);

                        for (int i = 0; i < type; i++)
                        {
                            if (rotation == 0)
                            {
                                _field[x, y - i].Condition = 1;
                                _field[x, y - i].CanAdd = false;
                                _field[x, y - i].onPaint(mode);
                                _field[x, y - i]._Cell.Update();
                                continue;
                            }
                            if (rotation == 1)
                            {
                                _field[x, y + i].Condition = 1;
                                _field[x, y + i].CanAdd = false;
                                _field[x, y + i].onPaint(mode);
                                _field[x, y + i]._Cell.Update();
                                continue;
                            }
                            if (rotation == 2)
                            {
                                _field[x - i, y].Condition = 1;
                                _field[x - i, y].CanAdd = false;
                                _field[x - i, y].onPaint(mode);
                                _field[x - i, y]._Cell.Update();
                                continue;
                            }
                            if (rotation == 3)
                            {
                                _field[x + i, y].Condition = 1;
                                _field[x + i, y].CanAdd = false;
                                _field[x + i, y].onPaint(mode);
                                _field[x + i, y]._Cell.Update();
                                continue;
                            }
                        }
                        updatePBoxes(Program.menu.oneDeck, Program.menu.twoDeck, Program.menu.threeDeck, Program.menu.fourDeck);
                        ChangeZoneNearShip(_field, true/*при создании*/);
                    }
                }
                else if (isEnemyField == true)
                {

                    PictureBox picClick = sender as PictureBox;

                    x = (int)Char.GetNumericValue(picClick.Name[0]);
                    y = (int)Char.GetNumericValue(picClick.Name[2]);
                    if (this._field[x, y].Condition != 4 &&
                         this._field[x, y].Condition != 3 &&
                         this._field[x, y].Condition != 8 &&
                         this._field[x, y].Condition != -5 &&
                         this._field[x, y].Condition != -6 &&
                         this._field[x, y].Condition != -7
                        )
                    {
                        //**//
                        if (hit(this, x, y) == false)
                        {
                            Program.menu.DisablePan();
                            Program.menu.SendStroke("0");
                        }
                        else
                        {
                            Program.menu.EnablePan();
                            Program.menu.SendStroke("1");
                        }
                        /*if (player.Stroke == false)
                        {
                            Program.menu.botHit();
                        }*/
                        Program.menu.changeScoreLabel();
                        Program.menu.SenderForField(ConditionToString(false));
                    }

                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (isEnemyField == false && isCreateMode == true)
                {
                    PictureBox picClick = sender as PictureBox;
                    x = (int)Char.GetNumericValue(picClick.Name[0]);
                    y = (int)Char.GetNumericValue(picClick.Name[2]);
                    _Leave(x, y, type, rotation, _field);
                    if (rotation == 1) rotation = 3;
                    else
                    {
                        if (rotation == 3) rotation = 0;
                        else
                        {
                            if (rotation == 0) rotation = 2;
                            else { rotation = 1; }
                        }
                    }

                    _Enter(x, y, type, rotation, _field);

                }
            }
        }


        //Зона вокруг корабля при создании
        void ChangeZoneNearShip(Cell[,] _Field, bool isCreate)
        {
            if (isCreate == true)
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Row; j++)
                    {
                        if (_Field[i, j].Condition == 1)
                        {
                            // up left
                            if (i > 0 && j > 0 && _Field[i - 1, j - 1].Condition == 0)
                            {
                                _Field[i - 1, j - 1].Condition = 2;
                                _Field[i - 1, j - 1].CanAdd = false;
                            }
                            //up
                            if (i > 0 && _Field[i - 1, j].Condition == 0)
                            {
                                _Field[i - 1, j].Condition = 2;
                                _Field[i - 1, j].CanAdd = false;
                            }
                            //up right
                            if (i > 0 && j < Row - 1 && _Field[i - 1, j + 1].Condition == 0)
                            {
                                _Field[i - 1, j + 1].Condition = 2;
                                _Field[i - 1, j + 1].CanAdd = false;
                            }
                            //right
                            if (j < Row - 1 && _Field[i, j + 1].Condition == 0)
                            {
                                _Field[i, j + 1].Condition = 2;
                                _Field[i, j + 1].CanAdd = false;
                            }
                            //down right
                            if (i < Row - 1 && j < Row - 1 && _Field[i + 1, j + 1].Condition == 0)
                            {
                                _Field[i + 1, j + 1].Condition = 2;
                                _Field[i + 1, j + 1].CanAdd = false;
                            }
                            //down
                            if (i < Row - 1 && _Field[i + 1, j].Condition == 0)
                            {
                                _Field[i + 1, j].Condition = 2;
                                _Field[i + 1, j].CanAdd = false;
                            }
                            //down left
                            if (i < Row - 1 && j > 0 && _Field[i + 1, j - 1].Condition == 0)
                            {
                                _Field[i + 1, j - 1].Condition = 2;
                                _Field[i + 1, j - 1].CanAdd = false;
                            }
                            //left
                            if (j > 0 && _Field[i, j - 1].Condition == 0)
                            {
                                _Field[i, j - 1].Condition = 2;
                                _Field[i, j - 1].CanAdd = false;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Row; j++)
                    {
                        if (_Field[i, j].Condition == 2)
                        {
                            _Field[i, j].Condition = 0;
                            _Field[i, j].CanAdd = true;
                        }

                    }
                }
            }
        }

        //Функция обработки двойного щелчка кнопки мыши
        void DoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isEnemyField == false && isCreateMode == true)
                {
                    ChangeZoneNearShip(_field, false);
                    PictureBox picClick = sender as PictureBox;
                    int i = 0;
                    x = (int)Char.GetNumericValue(picClick.Name[0]);
                    y = (int)Char.GetNumericValue(picClick.Name[2]);
                    DeleteShip(x, y);
                    updateLabeles(Program.menu.numOfOne, Program.menu.numOfTwo, Program.menu.numOfThree, Program.menu.numOfFour);
                    updatePBoxes(Program.menu.oneDeck, Program.menu.twoDeck, Program.menu.threeDeck, Program.menu.fourDeck);
                    ChangeZoneNearShip(_field, true);
                }
            }
        }
        void _Enter(int x, int y, int type, int rotation, Cell[,] _Field)
        {
            Image res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
            // Image res = global::battkeship.Properties.Resources.Ship_Green;
            Border(rotation, _Field);
            //test();
            if (type != 1)
            {
                for (int i = 0; i < type; i++)
                {
                    if (rotation == 0)
                    {
                        if (y - i < 0) break;

                        if (y - type + 1 < 0)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                        //res = global::battkeship.Properties.Resources.Ship_Red;

                        else
                        {
                            if (_Field[x, y - i].CanAdd == false)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                                //res = global::battkeship.Properties.Resources.Ship_Red;
                                if (_Field[x, y - i].Condition == 1)
                                    res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                //res = global::battkeship.Properties.Resources.Ship_Green;
                            }
                            else if (_Field[x, y - i].Condition == 0)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                //res = global::battkeship.Properties.Resources.Ship_Green;
                            }
                        }
                        if (_Field[x, y - i].CanAdd == false && _Field[x, y - i].IsBorder == true)
                        {
                            _Field[x, y - i]._Cell.Image = res;
                            _Field[x, y - i]._Cell.Update();
                            break;
                        }
                        _Field[x, y - i]._Cell.Image = res;
                        _Field[x, y - i]._Cell.Update();

                        /**/
                        if (_Field[x, y - i].IsBorder == true && _Field[x, y - i].Condition != 2)
                        {
                            _Field[x, y - i].CanAdd = true;
                            break;
                        }
                        continue;
                    }
                    if (rotation == 1)
                    {
                        if (y + i > Row - 1) break;
                        if (y + type - 1 > Row - 1)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                        //res = global::battkeship.Properties.Resources.Ship_Red;
                        else
                            if (_Field[x, y + i].CanAdd == false)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                                //res = global::battkeship.Properties.Resources.Ship_Red;
                                if (_Field[x, y + i].Condition == 1)

                                    res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");                                    //  res = global::battkeship.Properties.Resources.Ship_Green;
                            }
                            else if (_Field[x, y + i].Condition == 0)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                //res = global::battkeship.Properties.Resources.Ship_Green;
                            }



                        if (_Field[x, y + i].CanAdd == false && _Field[x, y + i].IsBorder == true)
                        {
                            _Field[x, y + i]._Cell.Image = res;
                            _Field[x, y + i]._Cell.Update();
                            break;
                        }
                        _Field[x, y + i]._Cell.Image = res;
                        _Field[x, y + i]._Cell.Update();

                        if (_Field[x, y + i].IsBorder == true && _Field[x, y + i].Condition != 2) { _Field[x, y + i].CanAdd = true; break; }
                        continue;
                    }
                    if (rotation == 2)
                    {

                        if (x - i < 0) break;
                        if (x - type + 1 < 0)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                        //res = global::battkeship.Properties.Resources.Ship_Red;
                        else
                            if (_Field[x - i, y].CanAdd == false)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                                //res = global::battkeship.Properties.Resources.Ship_Red;
                                if (_Field[x - i, y].Condition == 1)
                                    res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                //res = global::battkeship.Properties.Resources.Ship_Green;
                            }
                            else if (_Field[x - i, y].Condition == 0)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                // res = global::battkeship.Properties.Resources.Ship_Green;
                            }


                        if (_Field[x - i, y].CanAdd == false && _Field[x - i, y].IsBorder == true)
                        {
                            _Field[x - i, y]._Cell.Image = res;
                            _Field[x - i, y]._Cell.Update();
                            break;
                        }
                        _Field[x - i, y]._Cell.Image = res;
                        _Field[x - i, y]._Cell.Update();

                        if (_Field[x - i, y].IsBorder == true && _Field[x - i, y].Condition != 2) { _Field[x - i, y].CanAdd = true; break; }
                        continue;
                    }
                    if (rotation == 3)
                    {
                        if (x + i > Row - 1) break;
                        if (x + type - 1 > Row - 1)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                        //res = global::battkeship.Properties.Resources.Ship_Red;
                        else
                            if (_Field[x + i, y].CanAdd == false)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                                //res = global::battkeship.Properties.Resources.Ship_Red;
                                if (_Field[x + i, y].Condition == 1)
                                    res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                //res = global::battkeship.Properties.Resources.Ship_Green;
                            }
                            else if (_Field[x + i, y].Condition == 0)
                            {
                                res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                                //res = global::battkeship.Properties.Resources.Ship_Green;
                            }

                        if (_Field[x + i, y].CanAdd == false && _Field[x + i, y].IsBorder == true)
                        {
                            _Field[x + i, y]._Cell.Image = res;
                            _Field[x + i, y]._Cell.Update();
                            break;
                        }
                        _Field[x + i, y]._Cell.Image = res;
                        _Field[x + i, y]._Cell.Update();

                        if (_Field[x + i, y].IsBorder == true && _Field[x + i, y].Condition != 2) { _Field[x + i, y].CanAdd = true; break; }
                        continue;
                    }

                }

            }
            else
            {
                UnBorder(_Field);
                if (_Field[x, y].CanAdd == false)
                {
                    res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Red");
                    //res = global::battkeship.Properties.Resources.Ship_Red;
                    if (_Field[x, y].Condition == 1)
                        res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                    //res = global::battkeship.Properties.Resources.Ship_Green;
                }
                if (_Field[x, y].CanAdd == false && _Field[x, y].IsBorder == true) return;
                _Field[x, y]._Cell.Image = res;
                _Field[x, y]._Cell.Update();
            }
        }
        void _Leave(int x, int y, int type, int rotation, Cell[,] _Field)
        {
            Image res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
            //Image res = global::battkeship.Properties.Resources.Water;
            if (type != 1)
            {
                for (int i = 0; i < type; i++)
                {

                    if (rotation == 0)
                    {
                        if (y - i < 0) break;
                        if (_Field[x, y - i].CanAdd == false && _Field[x, y - i].Condition == 1)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                        //res = global::battkeship.Properties.Resources.Ship_Green;
                        else
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                        // res = global::battkeship.Properties.Resources.Water;
                        if (_Field[x, y - i].CanAdd == false && _Field[x, y - i].Condition != 2)
                        {
                            _Field[x, y - i]._Cell.Image = res;
                            _Field[x, y - i]._Cell.Update();
                            continue;
                        }
                        _Field[x, y - i]._Cell.Image = res;
                        _Field[x, y - i]._Cell.Update();
                        if (_Field[x, y - i].IsBorder == true && _Field[x, y - i].Condition != 2)
                        {
                            _Field[x, y - i].CanAdd = true; break;
                        }
                        continue;
                    }
                    if (rotation == 1)
                    {
                        if (y + i > Row - 1) break;
                        if (_Field[x, y + i].CanAdd == false && _Field[x, y + i].Condition == 1)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                        // res = global::battkeship.Properties.Resources.Ship_Green;
                        else
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                        // res = global::battkeship.Properties.Resources.Water;
                        if (_Field[x, y + i].CanAdd == false && _Field[x, y + i].Condition != 2)
                        {
                            _Field[x, y + i]._Cell.Image = res;
                            _Field[x, y + i]._Cell.Update();
                            continue;
                        }
                        _Field[x, y + i]._Cell.Image = res;
                        _Field[x, y + i]._Cell.Update();
                        if (_Field[x, y + i].IsBorder == true && _Field[x, y + i].Condition != 2) { _Field[x, y + i].CanAdd = true; break; }
                        continue;
                    }
                    if (rotation == 2)
                    {
                        if (x - i < 0) break;
                        if (_Field[x - i, y].CanAdd == false && _Field[x - i, y].Condition == 1)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                        // res = global::battkeship.Properties.Resources.Ship_Green;
                        else
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                        // res = global::battkeship.Properties.Resources.Water;
                        if (_Field[x - i, y].CanAdd == false && _Field[x - i, y].Condition != 2)
                        {
                            _Field[x - i, y]._Cell.Image = res;
                            _Field[x - i, y]._Cell.Update();
                            continue;
                        }
                        _Field[x - i, y]._Cell.Image = res;
                        _Field[x - i, y]._Cell.Update();
                        if (_Field[x - i, y].IsBorder == true && _Field[x - i, y].Condition != 2) { _Field[x - i, y].CanAdd = true; break; }
                        continue;
                    }
                    if (rotation == 3)
                    {
                        if (x + i > Row - 1) break;
                        if (_Field[x + i, y].CanAdd == false && _Field[x + i, y].Condition == 1)
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                        // res = global::battkeship.Properties.Resources.Ship_Green;
                        else
                            res = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                        //res = global::battkeship.Properties.Resources.Water;
                        if (_Field[x + i, y].CanAdd == false && _Field[x + i, y].Condition != 2)
                        {
                            _Field[x + i, y]._Cell.Image = res;
                            _Field[x + i, y]._Cell.Update();
                            continue;
                        }
                        _Field[x + i, y]._Cell.Image = res;
                        _Field[x + i, y]._Cell.Update();
                        if (_Field[x + i, y].IsBorder == true && _Field[x + i, y].Condition != 2) { _Field[x + i, y].CanAdd = true; break; }
                        continue;
                    }

                }
                UnBorder(_Field);
            }
            if (type == 1)
            {

                if (_Field[x, y].CanAdd == false && _Field[x, y].Condition != 2) return;
                _Field[x, y]._Cell.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                //_Field[x, y]._Cell.Image = global::battkeship.Properties.Resources.Water;
                _Field[x, y]._Cell.Update();
            }

        }

        bool Check(int x, int y, int type, int rotation, Cell[,] _Field)
        {
            int tmp = 0;
            for (int i = 0; i < type; i++)
            {
                if (rotation == 0 && _Field[x, y - i].CanAdd == true)
                {
                    if (i < type - 1 && _Field[x, y - i].IsBorder == true) return false;
                    tmp += 1;
                    continue;
                }
                else
                {
                    if (rotation == 1 && _Field[x, y + i].CanAdd == true)
                    {
                        if (i < type - 1 && _Field[x, y + i].IsBorder == true) return false;
                        tmp += 1;
                        continue;
                    }
                    else
                    {
                        if (rotation == 2 && _Field[x - i, y].CanAdd == true)
                        {
                            if (i < type - 1 && _Field[x - i, y].IsBorder == true) return false;
                            tmp += 1;
                            continue;
                        }
                        else
                        {
                            if (rotation == 3 && _Field[x + i, y].CanAdd == true)
                            {
                                if (i < type - 1 && _Field[x + i, y].IsBorder == true) return false;
                                tmp += 1;
                                continue;
                            }
                            else return false;
                        }
                    }
                }

            }
            //Подумать, убрать или нет
            if (tmp == type)
                return true;
            else return false;
        }
        void Border(int rotation, Cell[,] M)
        {
            //up
            if (rotation == 0)
            {
                for (int i = 0; i < Row; i++)
                    M[i, 0].IsBorder = true;
            }
            else
                //down
                if (rotation == 1)
                {
                    for (int i = 0; i < Row; i++)
                        M[i, Row - 1].IsBorder = true;
                }
                else
                    //left
                    if (rotation == 3)
                    {
                        for (int i = 0; i < Row; i++)
                            M[Row - 1, i].IsBorder = true;
                    }
                    else
                    {
                        for (int i = 0; i < Row; i++)
                            M[0, i].IsBorder = true;
                    }
        }
        void UnBorder(Cell[,] M)
        {
            int i;
            for (i = 0; i < Row; i++)
            {
                M[0, i].IsBorder = false;
                M[Col - 1, i].IsBorder = false;
            }
            for (i = 0; i < Col; i++)
            {
                M[i, 0].IsBorder = false;
                M[i, Row - 1].IsBorder = false;
            }
        }

        //Добавление корабля
        void AddShip(int _type, int _x, int _y, int _rotation)
        {
            Ship ship = new Ship(_type, _x, _y, _rotation, this,mode);
            player.MyShips[numOfShips] = ship;
            if (_type == 4) player.NumOfShipFour -= 1;
            else
            {
                if (_type == 3) player.NumOfShipThree -= 1;
                else
                {
                    if (_type == 2) player.NumOfShipTwo -= 1;
                    else
                    {
                        player.NumOfShipOne -= 1;
                    }
                }
            }
            this.numOfShips += 1;
        }

        //Удаление корабля
        void DeleteShip(int _x, int _y)
        {
            int k = 0;
            for (int i = 0; i < numOfShips; i++)
            {
                for (int j = 0; j < player.MyShips[i].Type; j++)
                {
                    if (player.MyShips[i].X[j] == _x && player.MyShips[i].Y[j] == _y)
                    {

                        if (player.MyShips[i].Type == 4) player.NumOfShipFour += 1;
                        else
                        {
                            if (player.MyShips[i].Type == 3) player.NumOfShipThree += 1;
                            else
                            {
                                if (player.MyShips[i].Type == 2) player.NumOfShipTwo += 1;
                                else
                                {
                                    player.NumOfShipOne += 1;
                                }
                            }
                        }
                        player.MyShips[i].delete(_field);
                        player.MyShips[i] = null;

                        for (k = i; k < numOfShips - 1; k++)
                        {
                            player.MyShips[k] = player.MyShips[k + 1];
                            if (player.MyShips[k + 1] == null) { numOfShips -= 1; return; }
                        }
                        player.MyShips[k] = null;
                        numOfShips -= 1;
                        return;
                    }

                }
            }
        }
        //Функция отрисовки поля (без кораблей)
        public void CreateField(Panel panel)
        {
            //размер клетки, вычисляющийся исходя из размеров панели
            size = panel.Height / Row;

            for (y = 0; y < Row; y++)
            {
                for (x = 0; x < Col; x++)
                {
                    PictureBox cell = new PictureBox()
                    {
                        Image = _field[x, y]._Cell.Image,
                        Location = new System.Drawing.Point(x * size, y * size),
                        Name = x.ToString() + " " + y.ToString(),
                        Size = new System.Drawing.Size(size, size),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                    };
                    _field[x, y]._Cell = cell;
                    cell.MouseDown += Click;
                    cell.MouseEnter += Enter;
                    cell.MouseLeave += Leave;
                    cell.MouseDoubleClick += DoubleClick;
                    panel.Controls.Add(cell);
                }
            }


            updatePBoxes(Program.menu.oneDeck, Program.menu.twoDeck, Program.menu.threeDeck, Program.menu.fourDeck);

        }





        //Присваивание матрицы  состояний
        public int[,] setMatrOfCondition()
        {
            int[,] matrOfCondition = new int[Row, Row];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    matrOfCondition[i, j] = this._field[i, j].Condition;
                }
            }
            return matrOfCondition;
        }
        //Получения матрицы состояний
        public void getMatrOfCondition(int[,] tmp)
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    this._field[i, j].Condition = tmp[i, j];
                }
            }
        }
        /**/
        void updateLabeles(Label _one, Label _two, Label _three, Label _four)
        {
            _one.Text = player.NumOfShipOne.ToString();
            _two.Text = player.NumOfShipTwo.ToString();
            _three.Text = player.NumOfShipThree.ToString();
            _four.Text = player.NumOfShipFour.ToString();
        }
        void updatePBoxes(PictureBox one, PictureBox two, PictureBox three, PictureBox four)
        {

            if (type == 4 && player.NumOfShipFour == 0)
            {
                isSelected = false;
                four.Size = new System.Drawing.Size(4 * size, size);
                four.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                //four.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                four.Enabled = false;
                type = 0;
                return;
            }
            else
            {
                four.Enabled = true;
            }
            if (type == 3 && player.NumOfShipThree == 0)
            {
                isSelected = false;
                three.Size = new System.Drawing.Size(3 * size, size);
                three.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
               // three.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                three.Enabled = false;
                type = 0;
                return;
            }
            else
            {
                three.Enabled = true;
            }
            if (type == 2 && player.NumOfShipTwo == 0)
            {
                isSelected = false;
                two.Size = new System.Drawing.Size(2 * size, size);
                two.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                //two.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                two.Enabled = false;
                type = 0;
                return;
            }
            else
            {
                two.Enabled = true;
            }
            if (type == 1 && player.NumOfShipOne == 0)
            {
                isSelected = false;
                one.Size = new System.Drawing.Size(size, size);
                one.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
               // one.Image = global::battkeship.Properties.Resources.Ship_Grey;
                one.Enabled = false;
                type = 0;
                return;
            }
            else
            {
                one.Enabled = true;
            }


        }
        //
        public void ResetField() {
            // затирать все предыдущие расстановки
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    DeleteShip(i, j);
                    _Field[i, j].Condition = 0;
                    _Field[i, j].CanAdd = true;
                    _Field[i, j]._Cell.Image = (Image)global::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                    // _Field[i, j]._Cell.Image = global::battkeship.Properties.Resources.Water;
                    _Field[i, j]._Cell.Update();

                }
            }
        }
        // Случайная расстановка
        public void RandomGenerator()
        {

            // затирать все предыдущие расстановки
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    DeleteShip(i, j);
                    _Field[i, j].Condition = 0;
                    _Field[i, j].CanAdd = true;
                    _Field[i, j]._Cell.Image=(Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Water");
                   // _Field[i, j]._Cell.Image = global::battkeship.Properties.Resources.Water;
                    _Field[i, j]._Cell.Update();

                }
            }


            var random = new Random();
            int x = random.Next(10);
            int y = random.Next(10);
            // размещение 4-ех палубника

            RandFour(random, x, y);

            // размещение 3-ех палубников
            three = 0;
            while (three < 2)
            {

                RandThree(random, x, y);
            }


            // размещение 2-ух палубников
            two = 0;
            while (two < 3)
            {
                RandTwo(random, x, y);
            }

            // размещение однопалубников
            one = 0;
            while (one < 4)
            {
                RandOne(random, x, y);
            }

            updateLabeles(Program.menu.numOfOne, Program.menu.numOfTwo, Program.menu.numOfThree, Program.menu.numOfFour);
        }
        //генерация 4-палубного
        void RandFour(Random random, int x, int y)
        {

            if (x > 5)
            {
                y = random.Next(5);
                for (int i = 0; i < 4; i++)
                {
                    _Field[x, y + i].Condition = 1;
                    _Field[x, y + i].CanAdd = false;

                }
                AddShip(4, x, y, 1);
                ChangeZoneNearShip(_Field, true);
                return;
            }

            if (y > 5)
            {
                x = random.Next(5);
                for (int j = 0; j < 4; j++)
                {
                    _Field[x + j, y].Condition = 1;
                    _Field[x + j, y].CanAdd = false;

                }
                AddShip(4, x, y, 3);
                ChangeZoneNearShip(_Field, true);
                return;
            }

            int k = random.Next(2);
            if (k == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    _Field[x, y + i].Condition = 1;
                    _Field[x, y + i].CanAdd = false;

                }
                AddShip(4, x, y, 1);
                ChangeZoneNearShip(_Field, true);
            }
            else
            {
                for (int j = 0; j < 4; j++)
                {
                    _Field[x + j, y].Condition = 1;
                    _Field[x + j, y].CanAdd = false;

                }
                AddShip(4, x, y, 3);
                ChangeZoneNearShip(_Field, true);
            }



            ChangeZoneNearShip(_Field, true);
        }
        //генерация 3-палубного
        void RandThree(Random random, int x, int y)
        {
            x = random.Next(10);
            y = random.Next(10);
            if (_Field[x, y].Condition == 0)
            {
                if (y > 6)
                {
                    x = random.Next(7);
                    if (_Field[x + 1, y].Condition == 0 && _Field[x + 2, y].Condition == 0 && _Field[x, y].Condition == 0)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            _Field[x + j, y].Condition = 1;
                            _Field[x + j, y].CanAdd = false;
                        }
                        three++;
                        AddShip(3, x, y, 3);
                        ChangeZoneNearShip(_Field, true);
                        return;
                    }
                }
                if (x > 6)
                {
                    y = random.Next(7);
                    if (_Field[x, y + 1].Condition == 0 && _Field[x, y + 2].Condition == 0 && _Field[x, y].Condition == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            _Field[x, y + i].Condition = 1;
                            _Field[x, y + i].CanAdd = false;
                        }
                        three++;
                        AddShip(3, x, y, 1);
                        ChangeZoneNearShip(_Field, true);
                        return;
                    }
                }
                int k = random.Next(2);
                if (k == 0 && y <= 7 && _Field[x, y + 1].Condition == 0 && _Field[x, y + 2].Condition == 0 && _Field[x, y].Condition == 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        _Field[x, y + i].Condition = 1;
                        _Field[x, y + i].CanAdd = false;
                    }
                    three++;
                    AddShip(3, x, y, 1);
                    ChangeZoneNearShip(_Field, true);
                }
                else
                {
                    if (x <= 7 && _Field[x + 1, y].Condition == 0 && _Field[x + 2, y].Condition == 0 && _Field[x, y].Condition == 0)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            _Field[x + j, y].Condition = 1;
                            _Field[x + j, y].CanAdd = false;
                        }
                        three++;
                        AddShip(3, x, y, 3);
                        ChangeZoneNearShip(_Field, true);
                    }
                }
            }
        }
        //генерация 2-палубного
        void RandTwo(Random random, int x, int y)
        {
            x = random.Next(10);
            y = random.Next(10);
            if (y > 7)
            {
                x = random.Next(8);

                if (_Field[x, y].Condition == 0 && _Field[x + 1, y].Condition == 0)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        _Field[x + j, y].Condition = 1;
                        _Field[x + j, y].CanAdd = false;
                    }
                    two++;
                    AddShip(2, x, y, 3);
                    ChangeZoneNearShip(_Field, true);
                    return;
                }
            }
            if (x > 7)
            {
                y = random.Next(8);

                if (_Field[x, y].Condition == 0 && _Field[x, y + 1].Condition == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        _Field[x, y + i].Condition = 1;
                        _Field[x, y + i].CanAdd = false;
                    }
                    two++;
                    AddShip(2, x, y, 1);
                    ChangeZoneNearShip(_Field, true);
                    return;
                }
            }
            int k = random.Next(2);
            if (k == 0)
            {

                if (y <= 8 && _Field[x, y].Condition == 0 && _Field[x, y + 1].Condition == 0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        _Field[x, y + i].Condition = 1;
                        _Field[x, y + i].CanAdd = false;
                    }
                    two++;
                    AddShip(2, x, y, 1);
                    ChangeZoneNearShip(_Field, true);
                }
            }
            else
            {

                if (x <= 8 && _Field[x, y].Condition == 0 && _Field[x + 1, y].Condition == 0)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        _Field[x + j, y].Condition = 1;
                        _Field[x + j, y].CanAdd = false;
                    }
                    two++;
                    AddShip(2, x, y, 3);
                    ChangeZoneNearShip(_Field, true);
                }
            }

        }
        //генерация 1-палубного
        void RandOne(Random random, int x, int y)
        {
            x = random.Next(10);
            y = random.Next(10);
            if (_Field[x, y].Condition == 0)
            {
                _Field[x, y].Condition = 1;
                _Field[x, y].CanAdd = false;
                AddShip(1, x, y, 1);
                ChangeZoneNearShip(_Field, true);
                one++;

            }
        }
        // отрисовка кораблей после генерации
        public void DrawRand()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Row; j++)
                {
                    if (_Field[i, j].Condition == 1)
                    {
                        _Field[i, j]._Cell.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                      //  _Field[i, j]._Cell.Image = global::battkeship.Properties.Resources.Ship_Green;
                        _Field[i, j]._Cell.Update();
                    }
                }
            }

        }
        public bool hit(Field _Field, int _x, int _y)
        {

            if (_Field._Field[_x, _y].Condition == 1 || _Field._Field[_x, _y].Condition == 5 || _Field._Field[_x, _y].Condition == 6 || _Field._Field[_x, _y].Condition == 7)
            {
                for (int i = 0; i < player.MyShips.Length; i++)
                {
                    for (int j = 0; j < player.MyShips[i].Type; j++)
                    {
                        if (player.MyShips[i].X[j] == _x && player.MyShips[i].Y[j] == _y)
                        {
                            player.MyShips[i].hit(_Field, _x, _y);
                            if (player.MyShips[i].IsLive == false) numOfShips -= 1;

                            player.Hits++;
                            player.Stroke = true;

                            return true;
                        }
                    }
                }
            }
            else
                if (_Field._Field[_x, _y].Condition == 2 || _Field._Field[_x, _y].Condition == 0)
                {
                    _Field._Field[_x, _y].Condition = 4;
                    _Field._Field[_x, _y].onPaint(mode);

                }

            player.Stroke = false;

            player.Hits++;
            return false;

        }
        //Функция обработки бота
        static void botHit(ref Field _field)
        {

            Random random = new Random();
            //Бесконечный цикл
            while (true)
            {
                _field.x = random.Next(10);
                _field.y = random.Next(10);
                if (_field._Field[_field.x, _field.y].Condition == 1 ||
                    _field._Field[_field.x, _field.y].Condition == 0 ||
                    _field._Field[_field.x, _field.y].Condition == 2) break;
            }
            _field.hit(_field, _field.x, _field.y);
            return;

        }
        // Функция перевода кораблей в строку

        public String ShipsToString()
        {
            String Transmite = "S";
            //изначальное количество кораблей всегда 10
            for (int i = 0; i < 10; i++)
            {
                Transmite += Convert.ToString(this.player.MyShips[i].Type) + Convert.ToString(this.player.MyShips[i].X[0]) + Convert.ToString(this.player.MyShips[i].Y[0]) + Convert.ToString(this.player.MyShips[i].Rotation);
            }
            return Transmite;
        }

        //Функция перевода строки в корабли
        public void StringToShips(String Receive)
        {
            int k = 1;
            for (int i = 0; i < 10; i++)
            {
                this.AddShip((int)Char.GetNumericValue(Receive[k]), (int)Char.GetNumericValue(Receive[k + 1]), (int)Char.GetNumericValue(Receive[k + 2]), (int)Char.GetNumericValue(Receive[k + 3]));
                k += 4;
            }
        }
        public String ConditionToString(bool flags)
        {
            if (flags)
            {
                String Transmite = "T";
                for (int i = 0; i < Row; i++)
                    for (int j = 0; j < Row; j++)
                        Transmite += Convert.ToString(_Field[i, j].Condition);
                return Transmite;
            }
            else
            {
                return _Field[x, y]._Cell.Name;
            }
        }

        public void StringToCondition(String Receive)
        {
            int k = 1;
            for (int i = 0; i < Row; i++)
                for (int j = 0; j < Row; j++)
                {
                    _Field[i, j].Condition = (int)Char.GetNumericValue(Receive[k]);
                    k++;
                }
        }

        public void ReciveMsg(String Msg)
        {
            x = (int)Char.GetNumericValue(Msg[0]);
            y = (int)Char.GetNumericValue(Msg[2]);
            hit(this, x, y);
            /*if (hit(this, x, y) == false)
            {
                Program.menu.SendStroke("1");                    
            }
            else Program.menu.SendStroke("0");*/

            ////дальше строки только для проверки, изменить после приема сообщения
            //_Field[x, y].Condition = 3;
            //_Field[x, y]._Cell.Image = global::battkeship.Properties.Resources.Ship_Red;
        }
        public void Update()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    _field[x, y].onPaint(mode);
                }
            }
        }
    }

}
