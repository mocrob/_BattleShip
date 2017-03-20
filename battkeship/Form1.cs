using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace battkeship
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button2.Text = "Start game";
            this.numOfFour.Text = ""; this.numOfThree.Text = ""; this.numOfTwo.Text = ""; this.numOfOne.Text = "";
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            player = MyField._Player;
            shipDesk(oneDeck, twoDeck, threeDeck, fourDeck, numOfOne, numOfTwo, numOfThree, numOfFour);
            new Thread(new ThreadStart(Receiver)).Start();
        }
        Player player = new Player();
        Field MyField = new Field(false);
        Field EnemyField = new Field(true);
        String RecMsg = "";

        public void SenderForField(object Message)
        {
            Sender(Message);
        }
        delegate void SendMsg(String Text, RichTextBox Rtb);

        SendMsg AcceptDelegate = (String Text, RichTextBox Rtb) =>
        {
            Rtb.Text += Text + "\n";
        };

        protected void Receiver()
        {
            
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(7000);
            //Начинаем прослушку
            Listen.Start();
            //и заведем заранее сокет
            Socket ReceiveSocket;
            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[256];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        do
                        {//Собственно читаем
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //и записываем в поток
                            MessageR.Write(Receive, 0, ReceivedBytes);
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceiveSocket.Available > 0);
                        //Добавляем изменения в ChatBox
                        //ChatBox.BeginInvoke(AcceptDelegate, new object[] { "Received " + Encoding.Default.GetString(MessageR.ToArray()), ChatBox });
                        RecMsg = Encoding.Default.GetString(MessageR.ToArray());
                        if(RecMsg[0]==84)
                        {
                            EnemyField.StringToCondition(RecMsg);
                        }
                       else
                        {
                            MyField.ReciveMsg(RecMsg);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        protected void Sender(object Message)
        {
            try
            {
                //Проверяем входной объект на соответствие строке
                String MessageText = "";
                if (Message is String)
                    MessageText = Message as String;
                else
                    throw new Exception("На вход необходимо подавать строку");
                //Создаем сокет, коннектимся
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP.Text), 7000);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                //Отправляем сообщение
                Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                Connector.Send(SendBytes);
                Connector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int type;
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //Доска кораблей
        void shipDesk(PictureBox one, PictureBox two, PictureBox three, PictureBox four, Label _one, Label _two, Label _three, Label _four)
        {
            _one.Text = player.NumOfShipOne.ToString();
            _two.Text = player.NumOfShipTwo.ToString();
            _three.Text = player.NumOfShipThree.ToString();
            _four.Text = player.NumOfShipFour.ToString();

            int size = FieldOne.Width / 10;
            //Отрисовка кораблей 
            one.Size = new System.Drawing.Size(size, size);
            one.Image = global::battkeship.Properties.Resources.Ship_Grey;

            two.Size = new System.Drawing.Size(2*size, size);
            two.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

            three.Size = new System.Drawing.Size(3 * size, size);
            three.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

            four.Size = new System.Drawing.Size(4 * size, size);
            four.Image = global::battkeship.Properties.Resources.FourShip_Grey;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            MyField.IsCreateMode = false;
            Sender(MyField.ConditionToString(true));

        }


        /*Реализовать замену картинок*/
        private void fourDeck_MouseClick(object sender, MouseEventArgs e)
        {
            if (type != 4 && player.NumOfShipFour!=0)
            {
                MyField.IsSelected = true;
                type = 4;
                /**/
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Green;
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                /**/
                fourDeck.Size = new System.Drawing.Size(4 * size + 2, size + 2);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void threeDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 3 && player.NumOfShipThree!=0)
            {
                MyField.IsSelected = true;
                type = 3;
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                /**/
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Green;
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                /**/
                threeDeck.Size = new System.Drawing.Size(3 * size + 2, size + 2);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void twoDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 2 && player.NumOfShipTwo != 0)
            {
                MyField.IsSelected = true;
                type = 2;
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                /**/
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Green;
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                /**/
                twoDeck.Size = new System.Drawing.Size(2 * size + 2, size + 2);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                MyField.IsSelected = false;
                type = 0;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void oneDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 1 && player.NumOfShipOne!=0)
            {
                MyField.IsSelected = true;
                type = 1;
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                /**/
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Green;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                /**/
                oneDeck.Size = new System.Drawing.Size(size + 2, size + 2);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                oneDeck.Size = new System.Drawing.Size(size, size);
                oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyField.RandomGenerator();
            MyField.DrawRand();
        }

        private void conn_Click(object sender, EventArgs e)
        {
            IP.Enabled = false;
        }

        private void close_con_Click(object sender, EventArgs e)
        {
            IP.Enabled = true;
        }
    }
}
