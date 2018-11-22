using Newtonsoft.Json.Linq;
using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using WebSocket4Net;



namespace EmotivApI
{
    public partial class Main : Form
    {
        const string Url = "wss://127.0.0.1:54321";
        private WebSocket websock; 
        public Main()
        {
            InitializeComponent();
    
            websock = new WebSocket(Url);
            websock.Security.AllowUnstrustedCertificate = true;
            websock.Security.AllowNameMismatchCertificate = true;
            websock.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(WebSocketClient_Error);
            websock.Opened += new EventHandler(WebSocketClient_Opened);
            websock.Closed += new EventHandler(WebSocketClient_Closed);
            websock.MessageReceived += new EventHandler<MessageReceivedEventArgs>(WebSocketClient_MessageReceived);
            websock.Open();

        }


        private void WebSocketClient_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            JObject response = JObject.Parse(e.Message);
            if (response["warning"] != null)
            {
                JObject warning = (JObject)response["warning"];
                string messageWarning = "";
                int code = -1;
                if (warning["message"].Type == JTokenType.String)
                {
                    messageWarning = warning["message"].ToString();
                }
                else if (warning["message"].Type == JTokenType.Object)
                {
                    Console.WriteLine("Received Warning Object");
                }
                if (warning["code"] != null)
                    code = (int)warning["code"];

                Console.WriteLine("Received: " + messageWarning);

          
            }
            if (response["sid"] != null)
            {
                string sid = (string)response["sid"];
                
                if (response["com"] != null)
                {
                    Console.WriteLine("metal command jsons:"+e.Message  );
                    MentalCommand(response);
                }
               else
                {
                    Console.WriteLine("Can not detect stream type");
                }

            }
            else if (response["error"] != null)
            {
                JObject error = (JObject)response["error"];
                int code = (int)error["code"];
                string messageError = (string)error["message"];
                //Console.WriteLine("Received: " + messageError);
                //Send Error message event
             
            }
            else if (response["id"] != null)
            {
                int id = (int)response["id"];
                //Console.WriteLine("Received: " + e.Message);

                if (id == 12)
                {
                    SetAuthToken(response);
                }
            }

        }

        private  void MentalCommand(JObject jObject)
        {
            string str = jObject["com"][0].ToString();
            double val =  Convert.ToDouble( jObject["com"][1].ToString());
            if (str == "neutral")
            {
                ParseNeutral();
                //Console.WriteLine(str);
            }
            else if(str == "left")
            {
                ParseLeft(val);
                //Console.WriteLine("left"+str);
            }
            else if(str == "right")
            {
                ParseRight(val);
                //Console.WriteLine("right" + str);
            }
        }

        bool IsLeft = false;
        bool IsRight = false;
        int restCnt = 0;
        public void ParseLeft(double val)
        {
            restCnt = 0;
            if (val > 0.4)
                if (!IsLeft)
                {
                    IsLeft = true;
                    if (serial != null && serial.IsOpen)
                        try
                        {
                            serial.Write(new byte[] { (byte)'L' }, 0, 1);
                        }
                        catch(Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                    Console.WriteLine("Left Sent.");
                    IsLeft = false;
                }
        }
        public void ParseRight(double val)
        {
            restCnt = 0;
            if (val > 0.4)
                if (!IsRight)
                {
                    IsRight = true;
                    if(serial!=null && serial.IsOpen)
                        try
                        {
                            serial.Write(new byte[] { (byte)'R' }, 0, 1);
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                    Console.WriteLine("Right Sent.");
                    IsRight = false;
                }
        }

        public void ParseNeutral()
        {
            restCnt++;
            if (restCnt > 2)
                if (IsLeft || IsRight)
                {
                    IsLeft = false;
                    IsRight = false;
                    if(serial!=null && serial.IsOpen)
                        try
                        {
                            serial.Write(new byte[] { (byte)'N' }, 0, 1);
                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                    Console.WriteLine("Rest Sent.");
            }
        }

        private void WebSocketClient_Closed(object sender, EventArgs e)
        {
            Console.WriteLine("CLOSED");
        }

        private void WebSocketClient_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("OPENED");
        }

        private void WebSocketClient_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.GetType() + ":" + e.Exception.Message + Environment.NewLine + e.Exception.StackTrace);

            if (e.Exception.InnerException != null)
            {
                Console.WriteLine(e.Exception.InnerException.GetType());
            }
        }

        private void OnAuth(object sender, EventArgs e)
        {
                websock.Send("   {    \"jsonrpc\": \"2.0\",    \"method\": \"authorize\",    \"params\": { },    \"id\": 12  }");
        }
        delegate void deleteAuthorizationToken(JObject response);
        
        private void SetAuthToken(JObject response)
        {
            if(InvokeRequired)
            {
                Invoke(new deleteAuthorizationToken(SetAuthToken), new object[] { response });
            }
            else
            {
                textBox3.Text = response["result"]["_auth"].ToString();

            }
             
        }

        private void OnSessionRequest(object sender, EventArgs e)
        {
            /*
             *   {
    "jsonrpc": "2.0",
    "method": "createSession",
    "params": {
      "_auth": "...",
      "status": "open"
    },
    "id": 1
  }*/


            JObject request = new JObject(
              new JProperty("jsonrpc", "2.0"),
              new JProperty("id", 13),
              new JProperty("method", "createSession"));

            JObject para = new JObject(new JProperty("_auth", textBox3.Text), new JProperty("status", "open"));
         
            request.Add("params", para);
            websock.Send(request.ToString());


        }

        private void OnSubscribeRequest(object sender, EventArgs e)
        {
            JObject request = new JObject(
                                   new JProperty("jsonrpc", "2.0"),
                                   new JProperty("id", 15),
                                   new JProperty("method", "subscribe"));

            JObject para = new JObject(new JProperty("_auth", textBox3.Text), new JProperty("streams", new object[] {"com"}));

            request.Add("params", para);
            string req = request.ToString();
            websock.Send(req);        
        }
    public static SerialPort serial;

        private void OpenConnection(object sender, EventArgs e)
        {
            serial = new SerialPort(textBox1.Text, 9600, Parity.None);
            serial.Open();
            Thread th = new Thread(new ParameterizedThreadStart(read_async));
            th.Start(serial);
        }

        private void read_async(object portobj)
        {
            SerialPort port = (SerialPort)portobj;
            try
            {
                while (port.IsOpen)
                {
                    string line = port.ReadLine();
                    OnReceivedData(line);


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        delegate void OnRecieveDelegate(string data);
        public void OnReceivedData(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new OnRecieveDelegate(OnReceivedData), new object[] { data });
            }
            else
            { //string str = System.Text.Encoding.UTF8.Getstring(data);
                textBox2.AppendText(data + "\n");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
