using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//step1. reference nmodbuspc.dll, and using the namespaces.
using Modbus.Device;      //for modbus master
using System.Net;         //for tcp client
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace ModbusTCP_Master
{
    public partial class Form1 : Form
    {
        [DllImport("WININET", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);
        enum InternetConnectionState : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }
        TcpClient tcpClient;
        ModbusIpMaster master;
        string ipAddress;
        int tcpPort = 502;
        DateTime dtDisconnect = new DateTime();
        DateTime dtNow = new DateTime();
        //int iError = 0;
        List<TextBox> listAI = new List<TextBox>();
 
        bool NetworkIsOk = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listAI.Add(AI0);//CO2
            listAI.Add(AI1);//環境溫度
            listAI.Add(AI2);//環境濕度
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照
            listAI.Add(AI3);//光照

            listAI.Add(AI4);//土壤濕度 
            listAI.Add(AI5);//土壤溫度 
            listAI.Add(AI6);//保留(忽略)
            listAI.Add(AI7);//環境溫度
            listAI.Add(AI8);//環境濕度
            listAI.Add(AI9);//電池電壓

            dtDisconnect = DateTime.Now;    
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            // connect to Modbus TCP Server
            NetworkIsOk = Connect();
            timer1.Enabled = true;
            btStart.Enabled = false;
            btStop.Enabled = true;
            timer1.Interval = 1000; //1800000 30分鐘更新一次
            
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (master != null)
                master.Dispose();
            if (tcpClient != null)
                tcpClient.Close();
            btStart.Enabled = true;
            btStop.Enabled = false;
        }
        private bool Connect()
        {
            ipAddress = txtIP.Text;
            if (master != null)
                master.Dispose();
            if (tcpClient != null)
                tcpClient.Close();

            if (CheckInternet())
            {
                try
                {
                    tcpClient = new TcpClient();
                    IAsyncResult asyncResult = tcpClient.BeginConnect(ipAddress, tcpPort, null, null);
                    asyncResult.AsyncWaitHandle.WaitOne(3000, true); //wait for 3 sec
                    if (!asyncResult.IsCompleted)
                    {
                        tcpClient.Close();
                        Console.WriteLine(DateTime.Now.ToString() + ":Cannot connect to server.");
                        return false;
                    }
                    //tcpClient = new TcpClient(ipAddress, tcpPort);

                    // create Modbus TCP Master by the tcp client
                    //document->Modbus.Device.Namespace->ModbusIpMaster Class->Create Method
                    master = ModbusIpMaster.CreateIp(tcpClient);
                    master.Transport.Retries = 0;   //don't have to do retries
                    master.Transport.ReadTimeout = 1500;
                    this.Text = "On line " + DateTime.Now.ToString();
                    Console.WriteLine(DateTime.Now.ToString() + ":Connect to server.");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DateTime.Now.ToString() + ":Connect process " + ex.StackTrace + "==>" + ex.Message);
                    return false;
                }
            }
            return false;

        }

        private bool CheckInternet()
        {
            //http://msdn.microsoft.com/en-us/library/windows/desktop/aa384702(v=vs.85).aspx
            InternetConnectionState flag = InternetConnectionState.INTERNET_CONNECTION_LAN;
            return InternetGetConnectedState(ref flag, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (NetworkIsOk)
                {
                    #region Master to Slave
                    //read AI(3xxxx), start address=0, points=18
                    ushort[] register = master.ReadInputRegisters(1, 0, 18);
                    int tmp = 0;
                    for (int index = 0; index < 18; index++)
                    {
                        //listAI[index].Text = register[index].ToString();
                        /*
                         * 不儲存等於0的數
                         * 
                        if (register[index] != 0)
                        { 
                            double value = (double)register[index]/100;
                            listAI[tmp].Text = value.ToString("0.00");
                            tmp++;
                        }
                        */    
                        double value = (double)register[index] / 100;
                        listAI[tmp].Text = value.ToString("0.00");
                        tmp++;
                        //Convert ushort array to Float 
                    }
                    _MySql();
                    //_CoAP();
                    #endregion
                }
                else
                {
                    dtNow = DateTime.Now;
                    if ((dtNow - dtDisconnect) > TimeSpan.FromSeconds(10))
                    {
                        Console.WriteLine(DateTime.Now.ToString() + ":Start connecting");
                        NetworkIsOk = Connect();
                        if (!NetworkIsOk)
                        {
                            Console.WriteLine(DateTime.Now.ToString() + ":Connecting fail. Wait for retry");
                            dtDisconnect = DateTime.Now;
                        }
                    }
                    else
                    {
                        Console.WriteLine(DateTime.Now.ToString() + ":Wait for retry connecting");
                    }
                }
            }
            catch (Exception exception)
            {
                //Connection exception
                //No response from server.
                //The server maybe close the connection, or response timeout.
                if (exception.Source.Equals("System"))
                {
                    NetworkIsOk = false;
                    Console.WriteLine(exception.Message);
                    this.Text = "Off line " + DateTime.Now.ToString();
                    dtDisconnect = DateTime.Now;
                }
                //The server return error code.
                //You can get the function code and exception code.
                if (exception.Source.Equals("nModbusPC"))
                {
                    string str = exception.Message;
                    int FunctionCode;
                    string ExceptionCode;

                    str = str.Remove(0, str.IndexOf("\r\n") + 17);
                    FunctionCode = Convert.ToInt16(str.Remove(str.IndexOf("\r\n")));
                    Console.WriteLine("Function Code: " + FunctionCode.ToString("X"));

                    str = str.Remove(0, str.IndexOf("\r\n") + 17);
                    ExceptionCode = str.Remove(str.IndexOf("-"));
                    switch (ExceptionCode.Trim())
                    {
                        case "1":
                            Console.WriteLine("Exception Code: " + ExceptionCode.Trim() + "----> Illegal function!");
                            break;
                        case "2":
                            Console.WriteLine("Exception Code: " + ExceptionCode.Trim() + "----> Illegal data address!");
                            break;
                        case "3":
                            Console.WriteLine("Exception Code: " + ExceptionCode.Trim() + "----> Illegal data value!");
                            break;
                        case "4":
                            Console.WriteLine("Exception Code: " + ExceptionCode.Trim() + "----> Slave device failure!");
                            break;
                    }
                    /*
                       //Modbus exception codes definition
                            
                       * Code   * Name                                      * Meaning
                         01       ILLEGAL FUNCTION                            The function code received in the query is not an allowable action for the server.
                         
                         02       ILLEGAL DATA ADDRESS                        The data addrdss received in the query is not an allowable address for the server.
                         
                         03       ILLEGAL DATA VALUE                          A value contained in the query data field is not an allowable value for the server.
                           
                         04       SLAVE DEVICE FAILURE                        An unrecoverable error occurred while the server attempting to perform the requested action.
                             
                         05       ACKNOWLEDGE                                 This response is returned to prevent a timeout error from occurring in the client (or master)
                                                                              when the server (or slave) needs a long duration of time to process accepted request.
                          
                         06       SLAVE DEVICE BUSY                           The server (or slave) is engaged in processing a long–duration program command , and the 
                                                                              client (or master) should retransmit the message later when the server (or slave) is free.
                             
                         08       MEMORY PARITY ERROR                         The server (or slave) attempted to read record file, but detected a parity error in the memory.
                             
                         0A       GATEWAY PATH UNAVAILABLE                    The gateway is misconfigured or overloaded.
                             
                         0B       GATEWAY TARGET DEVICE FAILED TO RESPOND     No response was obtained from the target device. Usually means that the device is not present on the network.

                     */
                }
            }
        }

        private void _MySql()
        {
            string dbHost = "140.127.22.61";//資料庫位址
            string dbUser = "sam";//資料庫使用者帳號
            string dbPass = "123456";//資料庫使用者密碼
            string dbName = "greenhouse";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand command = conn.CreateCommand();

            // 連線到資料庫 
            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        label16.Text = "無法連線到資料庫.";
                        break;
                    case 1045:
                        label16.Text = "使用者帳號或密碼錯誤,請再試一次.";
                        break;
                }
            }
            command.CommandText = "Insert into npust_1sec(modbus1_1_co2,modbus1_1_temp,modbus1_1_humi,modbus1_1_light,modbus1_2_soilhumi," +
                                    "modbus1_2_soiltemp,modbus1_2_temp,modbus1_2_humi,modbus1_2_battery,date) values("+
                                    "'" + double.Parse(listAI[0].Text)*100 +"','" + listAI[1].Text + "','" + listAI[2].Text + "','" + listAI[3].Text + "'" +
                                    ",'" + listAI[4].Text + "','" + listAI[5].Text + "','" + listAI[7].Text + "','" + listAI[8].Text + "','" + listAI[9].Text + "'"+
                                    ",'" + DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss") + "')";
            command.ExecuteNonQuery();
            Console.ReadLine();
            conn.Close();
            label16.Text = DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss")+" Succes!";
        }

        private void _CoAP()
        {
            double sum = 0;

            //CO2+溫濕度 C2Z2320_1
            String uri_post = "coap://140.127.22.61/om2m/nscl/applications/G_Intranet/containers/C2Z2320_1/contentInstances?authorization=admin:admin";
            CoAP.Request request = CoAP.Request.NewPost();
            request.URI = new Uri(uri_post);
            request.SetPayload("<obj> <str name='appId' val='G_Intranet'/> <int name='CO2' val='" + double.Parse(listAI[0].Text) * 100 + "'/> <int name='temp' val='" + listAI[1].Text + "'/> <int name='humi' val='" + listAI[2].Text + "'/> <str name='date' val='" + DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss") + "'/> </obj>", CoAP.MediaType.TextPlain);
            request.Send();
            CoAP.Response response = request.WaitForResponse();
            if (response == null)
            {
                Console.WriteLine("Request timeout!");
            }
            else
            {
                sum += response.RTT;
            }

            //照度計 LXT_401_1
            uri_post = "coap://140.127.22.61/om2m/nscl/applications/G_Intranet/containers/LXT_401_1/contentInstances?authorization=admin:admin";
            request = CoAP.Request.NewPost();
            request.URI = new Uri(uri_post);
            request.SetPayload("<obj> <str name='appId' val='G_Intranet'/> <int name='light' val='" + listAI[3].Text + "'/> <str name='date' val='" + DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss") + "'/> </obj>", CoAP.MediaType.TextPlain);
            request.Send();
            response = request.WaitForResponse();
            if (response == null)
            {
                Console.WriteLine("Request timeout!");
            }
            else
            {
                sum += response.RTT;
            }

            //土壤溫濕度 SMZ2T200
            uri_post = "coap://140.127.22.61/om2m/nscl/applications/G_Intranet/containers/SMZ2T200/contentInstances?authorization=admin:admin";
            request = CoAP.Request.NewPost();
            request.URI = new Uri(uri_post);
            request.SetPayload("<obj> <str name='appId' val='G_Intranet'/> <int name='modbus1_2_soilhumi' val='" + listAI[4].Text + "'/> <int name='modbus1_2_soiltemp' val='" + listAI[5].Text + "'/><int name='modbus1_2_temp' val='" + listAI[7].Text + "'/><int name='modbus1_2_humi' val='" + listAI[8].Text + "'/><int name='modbus1_2_battery' val='" + listAI[9].Text + "'/> <str name='date' val='" + DateTime.Now.ToString("yyyy/MM/dd, HH:mm:ss") + "'/> </obj>", CoAP.MediaType.TextPlain);
            request.Send();
            response = request.WaitForResponse();
            if (response == null)
            {
                Console.WriteLine("Request timeout!");
            }
            else
            {
                sum += response.RTT;
            }

            label3.Text = "Create Time (ms): " + response.RTT;
        }
    }
}