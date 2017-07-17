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
using System.IO;
using System.Diagnostics;

namespace ModbusTCP_Master
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Gateway
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications", "<om2m:application xmlns:om2m='http://uri.etsi.org/m2m' appId='G_Internet'><om2m:searchStrings><om2m:searchString> Type/MonitorRecord </om2m:searchString><om2m:searchString> Category/ITS </om2m:searchString></om2m:searchStrings></om2m:application>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications", "<om2m:application xmlns:om2m='http://uri.etsi.org/m2m' appId='G_Intranet'><om2m:searchStrings><om2m:searchString> Type/MonitorRecord </om2m:searchString><om2m:searchString> Category/ITS </om2m:searchString></om2m:searchStrings></om2m:application>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications", "<om2m:application xmlns:om2m='http://uri.etsi.org/m2m' appId='G_Local'><om2m:searchStrings><om2m:searchString> Type/MonitorRecord </om2m:searchString><om2m:searchString> Category/ITS </om2m:searchString></om2m:searchStrings></om2m:application>");
            //Local Sensor
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Local/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='JSP214'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Local/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='JSH100'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Local/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='JVT250'></om2m:container>");
            //Intranet Sensor
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Intranet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='SMZ2T200'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Intranet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='C2Z2320_1'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Intranet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='C2Z2320_2'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Intranet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='Camera_1'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Intranet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='Camera_2'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Intranet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='LXT_401_1'></om2m:container>");
            //Internet Sensor
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_1'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_2'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_3'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_4'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_5'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_6'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='THZ100_7'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='LXT401_1'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='LXT401_2'></om2m:container>");
            _HTTP_Post("http://127.0.0.1:8080/om2m/nscl/applications/G_Internet/containers", "<om2m:container xmlns:om2m='http://uri.etsi.org/m2m' om2m:id='Camera'></om2m:container>");
        }

        private void _HTTP_Post(String url,String parame)
        {
            string authInfo = "admin:admin";
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            string targetUrl = url;
            HttpWebRequest request = HttpWebRequest.Create(targetUrl) as HttpWebRequest;

            System.Diagnostics.Stopwatch timer = new Stopwatch();
            timer.Start();

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers["Authorization"] = "Basic " + authInfo;

            byte[] postData = Encoding.UTF8.GetBytes(parame);
            request.ContentLength = postData.Length;

            // 寫入 Post Body Message 資料流
            using (Stream st = request.GetRequestStream())
            {
                st.Write(postData, 0, postData.Length);
            }

            // 取得回應資料
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    label3.Text = sr.ReadToEnd();
                }
                response.Close();
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            label2.Text = "總消耗時間："+timeTaken.ToString();
        }
    }
}