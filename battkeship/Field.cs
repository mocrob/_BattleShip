using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace battkeship
{
    class Field : Cell
    {
        //Количество кораблей на поле (изначально 0, максимум 10)
        int numOfShips;
        public int NumOfShips
        {
            get { return numOfShips; }
            set { numOfShips = value; }
        }
        //Варжеское поле или поле игрока
        bool isEnemyField;
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
        /*Сделать геттеры сеттеры для матриц*/
        //Матрица поля 
        public Cell[,] _Field;

        //Конструктор при создании
        public Field(bool isEnemy)
        {
            _Field = CellMatrix(Col, Row);
            FieldBorder(_Field);
            isEnemyField = isEnemy;
            isCreateMode = true;
            numOfShips = 0;
        }

        public Field()
        {
            _Field = CellMatrix(Col, Row);
            FieldBorder(_Field);
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
                    M[i, j] = new Cell();
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
                M[0, i].Condition = -1;
                M[Col - 1, i].Condition = -1;
            }
            for (i = 0; i < Col; i++)
            {
                M[0, i].Condition = -1;
                M[Row - 1, i].Condition = -1;
            }
        }

        //Функция обработки нажатия кнопки мыши
        void Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isEnemyField == false && isCreateMode == true)
                {
                    PictureBox picClick = sender as PictureBox;
                    x = (int)Char.GetNumericValue(picClick.Name[0]);
                    y = (int)Char.GetNumericValue(picClick.Name[2]);
                    //MessageBox.Show(picClick.Name);
                    _Field[x, y].Condition = 1;
                    _Field[x, y].onPaint();
                    picClick.Image = _Field[x, y].ImgOnCell;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (isEnemyField == false && isCreateMode == true)
                {
                    PictureBox picClick = sender as PictureBox;
                    x = (int)Char.GetNumericValue(picClick.Name[0]);
                    y = (int)Char.GetNumericValue(picClick.Name[2]);
                    //MessageBox.Show(picClick.Name);
                    _Field[x, y].Condition = 0;
                    _Field[x, y].onPaint();
                    picClick.Image = _Field[x, y].ImgOnCell;
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
                        Image = _Field[x, y].ImgOnCell,
                        Location = new System.Drawing.Point(x * size, y * size),
                        Name = x.ToString() + " " + y.ToString(),
                        Size = new System.Drawing.Size(size, size),
                        SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
                    };
                    cell.MouseDown += Click;
                    panel.Controls.Add(cell);

                }
            }

        }

        //Добавление корабля
        void AddShip(int _type, int _x, int _y, int _rotation)
        {
            Ship ship = new Ship(_type, _x, _y, _rotation, this);
            this.NumOfShips += 1;
        }





    }
}
