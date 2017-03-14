using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battkeship
{
    class Player:Cell
    {
        Ship[] myShips = new Ship[10];


        public Ship[] MyShips
        {
            get { return myShips; }
            set { myShips = value; }
        }
      
        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
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
            name = "Player1";
            hits = 0;
            numOfShipFour = 1;
            numOfShipThree = 2;
            numOfShipTwo = 3;
            numOfShipOne = 4;
        }
        public Player(string _name)
        {
            name = _name;
            hits = 0;
            numOfShipFour = 1;
            numOfShipThree = 2;
            numOfShipTwo = 3;
            numOfShipOne = 4;
        }

        public void hit(Field _Field, int _x, int _y)
        {

            if (_Field._Field[_x, _y].Condition == 1 || _Field._Field[_x, _y].Condition == 5 || _Field._Field[_x, _y].Condition == 6 || _Field._Field[_x, _y].Condition == 7)
                {
                    for(int i=0;i<myShips.Length;i++)
                    {
                        for(int j=0;j<myShips[i].Type;j++)
                        {
                            if(myShips[i].X[j]==_x && myShips[i].Y[j]==_y)
                            {
                                myShips[i].hit(_Field,_x,_y);
                                return;
                            }
                        }
                    }
                }else
                if (_Field._Field[_x, _y].Condition == 2 || _Field._Field[_x, _y].Condition == 0)
                {
                    _Field._Field[_x, _y].Condition = 4;
                    _Field._Field[_x, _y].onPaint();
                }
            
                hits++;
        }

        
        
    }
}
