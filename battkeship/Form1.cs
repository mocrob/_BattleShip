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
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.IO;


namespace battkeship
{
    public partial class Battleship : Form
    {

        public Battleship()
        {
            InitializeComponent();
            this.Location = new System.Drawing.Point(100, 100);
            //this.button1.Text = "Test";
            this.StartBut.Text = "Start game";
            this.button3.Text = "Generate";
            this.ScoreLabel.Text = "";
            //this.button4.Text = "Connect";
            // this.button5.Text = "Close connect";
            this.IP.Text = "127.0.0.1";
            this.stroke.Text = "";
            this.numOfFour.Text = ""; this.numOfThree.Text = ""; this.numOfTwo.Text = ""; this.numOfOne.Text = "";
            //this.Title.Text = "Enter your name:";
            //this.IpLable.Text = "Enter the ip address:";
            /*this.button6.Text = "Start game";
            this.button6.Enabled = false;*/

            /*player.MyField = new Field(false);
            player.EnemyField = new Field(true);*/



            

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //MyField.CreateField(FieldOne);
            //EnemyField.CreateField(FieldTwo);
           
            DisplayResolutions();
            GetConfig();
            ApplicationSettings(one);
            MyField._Player = player;
            EnemyField._Player = enemy;
            player.IsEnemy = false;
            enemy.IsEnemy = true;
            //запускаем поток прослушкиD:\Desktop\Учеба\4 семестр\Техн. прог\_BattleShip-ver.-0.92c\battkeship\Form1.cs
            newThread = new Thread(new ThreadStart(Receiver));
            //newThread.Start();

        }
        //public string IP;
        Config one = new Config();
        bool isFullscreen;
        int W, H, standartW, standartH;
        public Thread newThread;
        Player player = new Player("");
        Player enemy = new Player("");
        String RecMsg = "";//принятое сообщение
        string mode = "";
        Field MyField= new Field(false, "");
        Field EnemyField = new Field(true, "");
       
            

        string _ip, _name;
        String myIp, enemyIp;
        public delegate void AddMessageDelegate(string message);
        public delegate void HidePanel();
        public delegate void UnEnabledPanel(bool message);
        public delegate DialogResult ShowDialog(string message);
        public delegate void _ShowDialog(string message);
        public void LogAdd(string message)
        {
            IP.Text = message;
        }
        public void NameAdd(string message)
        {
            enemy.Name = message;
            enemyName.Text += message;
        }
        public void MyNameAdd(string message)
        {
            player.Name = message;
            playerName.Text += message;
        }
        //Функция отображает диалог состояния подключения
        public void _ShowD(string message)
        {
            MessageBox.Show(this, message);
        }
        //Функция отображает диалог для подключения
        public DialogResult ShowD(string name)
        {
            return MessageBox.Show(this, "Игрок " + name + " пытается подключиться к вам! \n Вы готовы принять подключение?", "Подключение", MessageBoxButtons.YesNo);
        }
        //Функция отображения того, кто ходит
        public void Stroke(string message)
        {
            this.stroke.Text = "Ходит " + message;
        }
        public void HidePan()
        {
            this.NetPanel.Visible = false;
            this.Main_Menu.Visible = false;
            this.NetPanel.SendToBack();
            this.Main_Menu.SendToBack();
        }
        public void UnEnabledPan(bool message)
        {
            this.FieldTwo.Enabled = message;
        }

        public void SenderForField(object Message)
        {
            Sender(Message);
        }
        public void SendStroke(object Message)
        {
            Sender(Message);
        }
        delegate void SendMsg(String Text);

        public void DisablePan()
        {
            Invoke(new UnEnabledPanel(UnEnabledPan), new object[] { false });
        }
        public void EnablePan()
        {
            Invoke(new UnEnabledPanel(UnEnabledPan), new object[] { true });
        }
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
                        //Получаем все состояния клеток поля
                        if (RecMsg[0] == 84)
                        {
                            EnemyField.StringToCondition(RecMsg);
                        }
                        //Получаем все корабли
                        else if (RecMsg[0] == 83)
                        {
                            EnemyField.StringToShips(RecMsg);
                        }
                        else if (RecMsg[0] == 80)
                        {
                            if (this.player.Name != "")
                            {
                                if (this.ShowIpAndName(RecMsg, out _ip, out _name) == true)
                                {
                                    Invoke(new AddMessageDelegate(LogAdd), new object[] { _ip });
                                    Invoke(new AddMessageDelegate(NameAdd), new object[] { _name });
                                    Invoke(new AddMessageDelegate(MyNameAdd), new object[] { player.Name });
                                    Invoke(new HidePanel(HidePan));
                                    Sender("}" + player.Name, _ip);
                                    // MessageBox.Show("Подключение установленно!");
                                }
                                else
                                    Invoke(new _ShowDialog(_ShowD), new object[] { "Подключение не установленно!" });
                                //MessageBox.Show(this, "Подключение не установленно!");
                            }
                            else
                            {
                                this.ShowIp(RecMsg, out _ip);
                                Sender("{", _ip);
                                Invoke(new _ShowDialog(_ShowD), new object[] { "Подключение не установленно! \n Введите имя!" });
                                //MessageBox.Show(this, "Подключение не установленно! \n Введите имя!");
                            }
                        }
                        else if (RecMsg[0] == 125)
                        {
                            Invoke(new AddMessageDelegate(NameAdd), new object[] { RecMsg.Substring(1, RecMsg.Length - 1) });
                            Invoke(new HidePanel(HidePan));
                            Invoke(new _ShowDialog(_ShowD), new object[] { "Подключение установленно!" });
                            //MessageBox.Show(this, "Подключение установленно!");
                        }
                        else if (RecMsg[0] == 123)
                        {
                            Invoke(new _ShowDialog(_ShowD), new object[] { "Подключение не установленно! \n Противник забыл ввести имя!" });
                            //MessageBox.Show(this, "Подключение не установленно! \n Противник забыл ввести имя!");
                        }
                        else if (RecMsg[0] == 126)
                        {
                            endGame(RecMsg);
                        }
                        else if (RecMsg[0] == 47)
                        {
                            player.Stroke = false;

                            //Invoke(new AddMessageDelegate(NameAdd), new object[] { enemy.Name });
                            Invoke(new UnEnabledPanel(UnEnabledPan), new object[] { false });
                            //DisablePan();
                            Invoke(new AddMessageDelegate(Stroke), new object[] { enemy.Name });


                        }
                        else
                        {
                            if (RecMsg.Length == 1 && RecMsg[0] == 48)
                            {
                                player.Stroke = true;
                                enemy.Stroke = false;
                                Invoke(new AddMessageDelegate(Stroke), new object[] { player.Name });
                                EnablePan();
                            }
                            else
                                if (RecMsg.Length == 1 && RecMsg[0] == 49)
                                {
                                    player.Stroke = false;
                                    enemy.Stroke = true;
                                    Invoke(new AddMessageDelegate(Stroke), new object[] { enemy.Name });
                                    DisablePan();
                                }
                                else
                                {

                                    //передача хода

                                    MyField.ReciveMsg(RecMsg);

                                }


                        }
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        protected bool Sender(object Message, string ip)
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
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(ip), 7000);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                //Connector.LingerState = new LingerOption(true, 1);
                // Connector.Ttl = 2;
                //Connector.ReceiveTimeout = 150;
                //Connector.SendBufferSize = 8;
                //Connector.ReceiveBufferSize = 8;
                Connector.Connect(EndPoint);
                //Отправляем сообщение
                Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                Connector.Send(SendBytes);
                Connector.Close();
                return true;
            }
            /*catch (System.Net.Sockets.SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }*/
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }
        protected bool Sender(object Message)
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
                //Connector.LingerState = new LingerOption(true, 1);
                // Connector.Ttl = 2;
                //Connector.ReceiveTimeout = 150;
                //Connector.SendBufferSize = 8;
                //Connector.ReceiveBufferSize = 8;
                Connector.Connect(EndPoint);
                //Отправляем сообщение
                Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                Connector.Send(SendBytes);
                Connector.Close();
                return true;
            }
            /*catch (System.Net.Sockets.SocketException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }*/
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                return false;
            }
        }
        String GetIp()
        {
            //Получение ip адреса машины в локальной сети
            // доступно ли сетевое подключение
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return null;
            // запросить у DNS-сервера IP-адрес, связанный с именем узла
            var host = Dns.GetHostEntry(Dns.GetHostName());
            // Пройдем по списку IP-адресов, связанных с узлом
            foreach (var ip in host.AddressList)
            {
                string tmpIp = ip.ToString();
                // если текущий IP-адрес версии IPv4, то выведем его 
                if (ip.AddressFamily == AddressFamily.InterNetwork && tmpIp != "192.168.56.1")
                {
                    //возвращаем ip машины
                    return "P" + ip.ToString();
                }
            }
            return null;
        }

        //Вывод своего ip 
        void ShowIp(String Receive, out string ip)
        {
            int i = 1;
            while (Receive[i] != 125) i++;
            ip = Receive.Substring(1, i - 1);
        }
        bool ShowIpAndName(String Receive, out string ip, out string name)
        {
            int i = 1, j = 0, tmp;
            while (Receive[i] != 125) i++;
            ip = Receive.Substring(1, i - 1);
            tmp = i + 1;
            while (i != Receive.Length - 1)
            {
                i++;
                j++;
            }
            name = Receive.Substring(tmp, j);
            //MessageBox.Show(ip);
            DialogResult result;
            result = (DialogResult)Invoke(new ShowDialog(ShowD), new object[] { name });
            // result = MessageBox.Show(this,"Игрок " + name + " пытается подключиться к вам! \n Вы готовы принять подключение?", "Подключение",MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                return true;

            }
            else
                return false;
        }

        /*Завершение партии*/
        void endGame(String Receive)
        {
            string name;
            name = Receive.Substring(1, Receive.Length - 2);
            DialogResult end;
            end = MessageBox.Show("Игрок " + name + " победил!\nНачать партию заново?", "Конец игры", MessageBoxButtons.YesNo);
            if (end == System.Windows.Forms.DialogResult.Yes)
            {
                MyField.ResetField();
                EnemyField.ResetField();
                //Очистка полей и статистики
                //this.Close();
            }
            else
            {
                Main_Menu.Visible = true;
                MyField.ResetField();
                EnemyField.ResetField();
            }
        }
        //Выстрел бота
        public void botHit()
        {
            while (false)//true
            {
                Random random = new Random();
                //Бесконечный цикл
                while (true)
                {
                    MyField.X = random.Next(10);
                    MyField.Y = random.Next(10);
                    if (MyField._Field[MyField.X, MyField.Y].Condition == 0 ||
                        MyField._Field[MyField.X, MyField.Y].Condition == 1 ||
                        MyField._Field[MyField.X, MyField.Y].Condition == 2 ||
                        MyField._Field[MyField.X, MyField.Y].Condition == 5 ||
                        MyField._Field[MyField.X, MyField.Y].Condition == 6 ||
                        MyField._Field[MyField.X, MyField.Y].Condition == 7 || player.NumOfShips == 0) break;
                }
                MyField.hit(MyField, MyField.X, MyField.Y);
                if (MyField._Player.Stroke == false)
                    break;

            }
            return;
        }
        int type,
        WScreen, HScreen,
        WTmp, HTmp,
        Xone, Yone,
        XTwo, YTwo,
        Xthree, YThree,
        XFour, YFour;


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
            one.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
            //one.Image = global::battkeship.Properties.Resources.Ship_Grey;

            two.Size = new System.Drawing.Size(2 * size, size);
            two.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
            //two.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

            three.Size = new System.Drawing.Size(3 * size, size);
            three.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
            //three.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

            four.Size = new System.Drawing.Size(4 * size, size);
            four.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
            //four.Image = global::battkeship.Properties.Resources.FourShip_Grey;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyField.IsCreateMode = false;
            player.Stroke = true;
            enemy.Stroke = false;
            //stroke.Text = "Ходит " + player.Name;
            //Sender("/");
            Sender(MyField.ConditionToString(true));
            Sender(MyField.ShipsToString());
            /*Random r = new Random();
            int _r = r.Next(2);
            if (_r == 0)
            {
                player.Stroke = true;
                enemy.Stroke = false;
                stroke.Text = "Ходит " + player.Name;
            }else
            {
                player.Stroke = false;
                enemy.Stroke = true;
                stroke.Text = "Ходит " + enemy.Name;
            }*/

        }

        /*Реализовать замену картинок*/
        private void fourDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 4 && player.NumOfShipFour != 0)
            {
                MyField.IsSelected = true;
                type = 4;
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Green");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Green;
                // threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                // twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                // oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Height / 10;

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
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                oneDeck.Size = new System.Drawing.Size(size, size);
                // oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                // twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                //threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void threeDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 3 && player.NumOfShipThree != 0)
            {
                MyField.IsSelected = true;
                type = 3;
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Green");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                // threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Green;
                // twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;
                // oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);

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
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                oneDeck.Size = new System.Drawing.Size(size, size);
                //oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                // twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                // threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                //fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void twoDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 2 && player.NumOfShipTwo != 0)
            {
                MyField.IsSelected = true;
                type = 2;
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Green");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                // threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                // twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Green;
                // oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);

                twoDeck.Size = new System.Drawing.Size(2 * size + 2, size + 2);
                oneDeck.Size = new System.Drawing.Size(size, size);
            }
            else
            {
                MyField.IsSelected = false;
                type = 0;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                oneDeck.Size = new System.Drawing.Size(size, size);
                //oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                // twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                // threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }

        private void oneDeck_MouseDown(object sender, MouseEventArgs e)
        {
            if (type != 1 && player.NumOfShipOne != 0)
            {
                MyField.IsSelected = true;
                type = 1;
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Green");
                // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
                //threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;
                //twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                // oneDeck.Image = global::battkeship.Properties.Resources.Ship_Green;

                int size = FieldOne.Width / 10;
                fourDeck.Size = new System.Drawing.Size(4 * size, size);
                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                twoDeck.Size = new System.Drawing.Size(2 * size, size);

                oneDeck.Size = new System.Drawing.Size(size + 2, size + 2);
            }
            else
            {
                type = 0;
                MyField.IsSelected = false;
                int size = FieldOne.Width / 10;
                //Отрисовка кораблей 
                fourDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "FourShip_Grey");
                threeDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "ThreeShip_Grey");
                twoDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "TwoShip_Grey");
                oneDeck.Image = (Image)global ::battkeship.Properties.Resources.ResourceManager.GetObject(mode + "Ship_Grey");
                oneDeck.Size = new System.Drawing.Size(size, size);
               // oneDeck.Image = global::battkeship.Properties.Resources.Ship_Grey;

                twoDeck.Size = new System.Drawing.Size(2 * size, size);
                //twoDeck.Image = global::battkeship.Properties.Resources.TwoShip_Grey;

                threeDeck.Size = new System.Drawing.Size(3 * size, size);
                //threeDeck.Image = global::battkeship.Properties.Resources.ThreeShip_Grey;

                fourDeck.Size = new System.Drawing.Size(4 * size, size);
               // fourDeck.Image = global::battkeship.Properties.Resources.FourShip_Grey;
            }
            MyField.Type = type;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            MyField.RandomGenerator();
            //EnemyField.RandomGenerator();
            MyField.DrawRand();
        }
       
        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }


        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && ch != 8 && ch != 46) //Если символ, введенный с клавы -  цифра (IsDigit),
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }
        private void ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46) //Если символ, введенный с клавы -  цифра (IsDigit),
            {
                e.Handled = true;// то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CResolution ChangeRes = new CResolution(standartW, standartH);
            this.newThread.Abort();
            System.Environment.Exit(1);

        }
        private void ButSingle_Click(object sender, EventArgs e)
        {
            Main_Menu.Visible = false;
        }
        private void ButConfig_Click(object sender, EventArgs e)
        {
            ConfigPanel.Visible = true;
            ConfigPanel.BringToFront();
        }
        private void backConfig_Click(object sender, EventArgs e)
        {
            ConfigPanel.Visible = false;
            ConfigPanel.SendToBack();
            Main_Menu.BringToFront();
        }
        private void ButExit_Click(object sender, EventArgs e)
        {
            CResolution ChangeRes = new CResolution(standartW, standartH);
            this.newThread.Abort();
            System.Environment.Exit(1);


        }

        private void ButNet_Click(object sender, EventArgs e)
        {
            newThread.Start();
            NetPanel.Visible = true;
            NetPanel.BringToFront();
        }



        private void netBack_Click(object sender, EventArgs e)
        {
            /*Main_Menu.Visible = true;
            Main_Menu.Enabled = true;*/
            NetPanel.Visible = false;
            Main_Menu.BringToFront();
        }
        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            player.Name = nameTBox.Text;
        }

        private void netJoin_Click(object sender, EventArgs e)
        {
            try
            {
                playerName.Text = "Player:";
                if (nameTBox.Text != "")
                {
                    this.player.Name = nameTBox.Text;
                    playerName.Text += player.Name;
                }
                else throw new Exception("Введите имя");
                if (GetIp() != null)
                {
                    string IpAndname = GetIp() + "}" + player.Name;
                    bool flag = Sender(IpAndname);
                    if (_ip != null)
                        myIp = GetIp();
                    // IP.Text = _ip;
                    player.Stroke = true;
                    this.stroke.Text = "Ходит " + player.Name;
                    Sender("/");
                    //Маркер того, что хост ходит первый
                    //код 47
                    //Sender("/");
                    //IP.Enabled = false;
                    //if (flag == true) this.button6.Enabled = true;
                }
                else throw new Exception("Отсутствует подключение");

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
        //Возврат в меню
        private void button1_Click(object sender, EventArgs e)
        {
            this.Main_Menu.Visible = true;
            this.Main_Menu.BringToFront();
        }

        //Получаем все доступные разрешения экрана
        void DisplayResolutions()
        {
            standartH = Screen.PrimaryScreen.Bounds.Height;
            standartW = Screen.PrimaryScreen.Bounds.Width;
            var vDevMode = new WinApiHelper.DEVMODE();
            int i = 0;
            var resolutions = new List<string>();
            while (WinApiHelper.EnumDisplaySettings(null, i, ref vDevMode))
            {
                if (Convert.ToInt32(vDevMode.dmPelsWidth) >= 800)
                    resolutions.Add(string.Format("{0}x{1}", vDevMode.dmPelsWidth, vDevMode.dmPelsHeight));
                i++;
            }
            screenResolutionCb.Items.AddRange(resolutions.Select(x => x).Distinct().ToArray());
        }
        //Задаем значение полей настроек
        void SetConfig()
        {
            one.resolution = screenResolutionCb.SelectedItem.ToString();
            one.mode = ModeCb.SelectedItem.ToString();
            one.style = StyleOfDesignCb.SelectedItem.ToString();
            string serialized = JsonConvert.SerializeObject(one);
            FileInfo f = new FileInfo("config.txt");
            StreamWriter w = f.CreateText();
            w.WriteLine(serialized);
            w.Close();
            ScreenCalculating(one.resolution);
        }
        //Считывание
        void GetConfig()
        {

            string tmp = "";
            StreamReader s = File.OpenText("config.txt");
            string read = null;
            while ((read = s.ReadLine()) != null)
            {
                tmp = read;
            }
            s.Close();
            one = JsonConvert.DeserializeObject<Config>(tmp);
            screenResolutionCb.SelectedItem = one.resolution;
            ModeCb.SelectedItem = one.mode;
            StyleOfDesignCb.SelectedItem = one.style;
            ScreenCalculating(one.resolution);

        }
        //Рассчет высоты и ширины
        void ScreenCalculating(string resolution)
        {
            int i, lastIndx;
            i = 0;
            lastIndx = resolution.Length - 1;
            while (resolution[i] != 'x')
            {
                lastIndx--;
                i++;
            }
            W = Convert.ToInt32(one.resolution.Substring(0, i));
            H = Convert.ToInt32(one.resolution.Substring(i + 1, lastIndx));
        }
        void ApplicationSettings(Config config)
        {
            
            if (config.style == "Классический")
            {
                // MyField.Mode = "";
                //EnemyField.Mode = "";
                mode = "";
                MyField.Mode = mode;
                EnemyField.Mode = mode;
                MyField.Update();
                EnemyField.Update();
                MyField.CreateField(FieldOne);
                EnemyField.CreateField(FieldTwo);
            }
            else
            {
                //MyField.Mode = "p";
                // EnemyField.Mode = "p";
                mode = "p";
                MyField.Mode = mode;
                EnemyField.Mode = mode;
                MyField.Update();
                EnemyField.Update();
                MyField.CreateField(FieldOne);
                EnemyField.CreateField(FieldTwo);
            }
            if (config.mode == "Полноэкранный")
            {
                isFullscreen = true;
                FullScreen(W, H);
                setResolution(W, H);
            }
            else
            {
                isFullscreen = false;
                Windowed();
            }
            shipDesk(oneDeck, twoDeck, threeDeck, fourDeck, numOfOne, numOfTwo, numOfThree, numOfFour);
            

        }
       
        void FullScreen(int w, int h)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;


            FieldOne.Size = new System.Drawing.Size(w / 3 + h / 25, w / 3 + h / 25);
            FieldTwo.Size = new System.Drawing.Size(w / 3 + h / 25, w / 3 + h / 25);
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            updatePBoxes(FieldOne.Height / 10);
            deckPanel.Size = new System.Drawing.Size(fourDeck.Size.Width + fourDeck.Size.Height, fourDeck.Size.Height * 5);
            FieldOne.Location = new System.Drawing.Point(deckPanel.Location.X + deckPanel.Size.Width + 50, 50);
            FieldTwo.Location = new System.Drawing.Point(deckPanel.Location.X + deckPanel.Size.Width + FieldOne.Size.Width + fourDeck.Size.Height * 2, 50);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);


            threeDeck.Location = new System.Drawing.Point(threeDeck.Location.X, fourDeck.Location.Y + fourDeck.Size.Height + threeDeck.Size.Height / 5);
            twoDeck.Location = new System.Drawing.Point(twoDeck.Location.X, threeDeck.Location.Y + threeDeck.Size.Height + twoDeck.Size.Height / 5);
            oneDeck.Location = new System.Drawing.Point(oneDeck.Location.X, twoDeck.Location.Y + twoDeck.Size.Height + oneDeck.Size.Height / 5);


            numOfOne.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, oneDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfTwo.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, twoDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfThree.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, threeDeck.Location.Y + oneDeck.Size.Height / 7);
            numOfFour.Location = new System.Drawing.Point(fourDeck.Size.Width + 5, 9 + oneDeck.Size.Height / 7);

            numOfOne.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        }
        void Windowed()
        {
            CResolution ChangeRes = new CResolution(standartW, standartH);
            this.TopMost = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(970, 440);
            this.Location = new System.Drawing.Point(100, 100);
            FieldOne.Size = new System.Drawing.Size(350, 350);
            FieldTwo.Size = new System.Drawing.Size(350, 350);
            updatePBoxes(FieldOne.Height / 10);
            FieldOne.Location = new System.Drawing.Point(230, 30);
            FieldTwo.Location = new System.Drawing.Point(590, 30);
            FieldOne.Controls.Clear();
            FieldTwo.Controls.Clear();
            MyField.CreateField(FieldOne);
            EnemyField.CreateField(FieldTwo);
            deckPanel.Location = new System.Drawing.Point(12, 30);
            deckPanel.Size = new System.Drawing.Size(218, 170);



            oneDeck.Location = new System.Drawing.Point(0, 135);
            twoDeck.Location = new System.Drawing.Point(0, 93);
            threeDeck.Location = new System.Drawing.Point(0, 51);
            fourDeck.Location = new System.Drawing.Point(0, 9);

            numOfOne.Location = new System.Drawing.Point(173, 135 + oneDeck.Size.Height / 7);
            numOfTwo.Location = new System.Drawing.Point(173, 93 + oneDeck.Size.Height / 7);
            numOfThree.Location = new System.Drawing.Point(173, 51 + oneDeck.Size.Height / 7);
            numOfFour.Location = new System.Drawing.Point(173, 9 + oneDeck.Size.Height / 7);

            numOfOne.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfTwo.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfThree.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            numOfFour.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

        }
        void setResolution(int w, int h)
        {
            CResolution ChangeRes = new CResolution(w, h);
        }
        private void applyConfig_Click(object sender, EventArgs e)
        {
            SetConfig();
            ApplicationSettings(one);
        }
        void updatePBoxes(int size)
        {
            oneDeck.Size = new System.Drawing.Size(size, size);
            twoDeck.Size = new System.Drawing.Size(2 * size, size);
            threeDeck.Size = new System.Drawing.Size(3 * size, size);
            fourDeck.Size = new System.Drawing.Size(4 * size, size);
        }
        /*Завершение партии*/
        public void changeScoreLabel()
        {

            enemy.DefeatShips();
            ScoreLabel.Text = "Уничтожено: " + enemy.NumOfDefeatShips.ToString() + " кораблей";
            if (enemy.NumOfDefeatShips == 10)
            {
                Sender("~" + player.Name);
                DialogResult end;
                end = MessageBox.Show(this, "Поздравляю! Вы победили!\nНачать партию заново?", "Конец игры", MessageBoxButtons.YesNo);
                if (end == System.Windows.Forms.DialogResult.Yes)
                {
                    MyField.ResetField();
                    EnemyField.ResetField();
                    //Очистка полей и статистики
                    //this.Close();
                }
                else
                {
                    Main_Menu.Visible = true;
                    MyField.ResetField();
                    EnemyField.ResetField();
                }

            }


        }
        private void Main_Menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ConfigPanel_Paint(object sender, PaintEventArgs e)
        {

        }





















    }
}
