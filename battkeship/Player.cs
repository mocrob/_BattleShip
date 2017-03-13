using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace battkeship
{
    class Player
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
            numOfShipFour = 1;
            numOfShipThree = 2;
            numOfShipTwo = 3;
            numOfShipOne = 4;
        }
        public Player(string _name)
        {
            name = _name;
            numOfShipFour = 1;
            numOfShipThree = 2;
            numOfShipTwo = 3;
            numOfShipOne = 4;
        }

        void hit(int _x, int _y)
        {

        }
        
    }
}
