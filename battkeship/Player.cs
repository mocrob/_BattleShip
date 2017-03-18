using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battkeship
{
    class Player : Cell
    {
        Ship[] myShips = new Ship[10];


        public Ship[] MyShips
        {
            get { return myShips; }
            set { myShips = value; }
        }

        //Поле игрока
        Field myField;
        public Field MyField
        {
            get { return myField; }
            set { myField = value; }
        }
        //Поле врага
        Field enemyField;
        public Field EnemyField
        {
            get { return enemyField; }
            set { enemyField = value; }
        }
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Число кораблей у игрока
        int numOfShips;
        public int NumOfShips
        {
            get { return numOfShips; }
            set { numOfShips = value; }
        }

        //Игрок или соперник(враг)
        bool isEnemy;
        public bool IsEnemy
        {
            get { return isEnemy; }
            set { isEnemy = value; }
        }

        //Ход игрока
        bool stroke;
        public bool Stroke
        {
            get { return stroke; }
            set { stroke = value; }
        }

        int hits;
        public int Hits
        {
            get { return hits; }
            set { hits = value; }
        }
        int numOfShipFour, numOfShipThree, numOfShipTwo, numOfShipOne;
        public int NumOfShipFour
        {
            get { return numOfShipFour; }
            set { numOfShipFour = value; }
        }
        public int NumOfShipThree
        {
            get { return numOfShipThree; }
            set { numOfShipThree = value; }
        }
        public int NumOfShipTwo
        {
            get { return numOfShipTwo; }
            set { numOfShipTwo = value; }
        }
        public int NumOfShipOne
        {
            get { return numOfShipOne; }
            set { numOfShipOne = value; }
        }




        public Player()
        {
            name = "Player";
            hits = 0;
            numOfShips = 10;
            numOfShipFour = 1;
            numOfShipThree = 2;
            numOfShipTwo = 3;
            numOfShipOne = 4;
        }
        public Player(string _name)
        {
            name = _name;
            hits = 0;
            numOfShips = 10;
            numOfShipFour = 1;
            numOfShipThree = 2;
            numOfShipTwo = 3;
            numOfShipOne = 4;
        }

        public void hit(Field _Field, int _x, int _y)
        {

            if (_Field._Field[_x, _y].Condition == 1 || _Field._Field[_x, _y].Condition == 5 || _Field._Field[_x, _y].Condition == 6 || _Field._Field[_x, _y].Condition == 7)
            {
                for (int i = 0; i < myShips.Length; i++)
                {
                    for (int j = 0; j < myShips[i].Type; j++)
                    {
                        if (myShips[i].X[j] == _x && myShips[i].Y[j] == _y)
                        {
                            myShips[i].hit(_Field, _x, _y);
                            if (myShips[i].IsLive == false) numOfShips -= 1;
                            hits++;
                            stroke = true;
                            return;
                        }
                    }
                }
            }
            else
                if (_Field._Field[_x, _y].Condition == 2 || _Field._Field[_x, _y].Condition == 0)
                {
                    _Field._Field[_x, _y].Condition = 4;
                    _Field._Field[_x, _y].onPaint();
                }
            stroke = false;
            hits++;
            return;
        }



    }
}
