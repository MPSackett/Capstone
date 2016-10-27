using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Collections;


namespace DP2_Lidar_2016
{
    class Hokuyo : SerialPort
    {

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            char[] newchararray = new char[2110]; //raw data without first 22 bytes
            char[] charArray; //raw char
                              // string data; // raw data
            char[] onlyrangedata = new char[2048];
            char[,] encodeddist = new char[682, 3];
            int[] rangeValues = new int[682];


            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();
            //Console.WriteLine("Data Received:");
            //Console.Write(data);
            charArray = data.ToCharArray(); //array of ASCII char

            //3RD LINE FEED TO END OF IT
            for (int i = 31; i < charArray.Length - 1; i++) //23 if only gd
            {
                newchararray[i - 31] = charArray[i];
            }

            //WE DO NOT WANT SUM OR LF
            for (int x = 0; x <= 31; x++)
            {
                for (int l = 0; l < 64; l++)
                {
                    onlyrangedata[64 * x + l] = newchararray[66 * x + l];
                }
            }
            //newchararray = newchararray.Where(val => val != value).ToArray(); // deletes LF but not sum... (We could use Matlab methods
            int stepNum = onlyrangedata.Length / 3;
            for (int k = 0; k < stepNum; k++)
            {
                encodeddist[k, 0] = (char)onlyrangedata.GetValue(k * 3);
                encodeddist[k, 1] = (char)onlyrangedata.GetValue(k * 3 + 1);
                encodeddist[k, 2] = (char)onlyrangedata.GetValue(k * 3 + 2);
            }
            int numRows = encodeddist.GetLength(0); //number of rows
            for (int k = 0; k < numRows; k++)
            {
                rangeValues[k] = decodeSCIP(encodeddist[k, 0], encodeddist[k, 1], encodeddist[k, 2]);
            }
            rangeValues.ToList().ForEach(i => Console.WriteLine(i.ToString()));
            // sensor1.WriteCommand("QT"); // TURN LASER OFF
            sp.Close();
            sw.Stop();
          //  return rangeValues;

        }

        #region Functions from Main Code so that I can reference from Matlab
        //FUNCTION THAT CONVERTS INTEGER TO BINARY STRING -- http://stackoverflow.com/questions/1838963/easy-and-fast-way-to-convert-an-int-to-binary
        public static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }

        //FUNCTION THAT DECODES ENCODED DISTANCE DATA ONLY
        static public int decodeSCIP(char rangeENC0, char rangeENC1, char rangeENC2)
        {
            int value1;
            int value2;
            int value3;
            string value4;
            string value5;
            string value6;
            string binaryString;
            int rangeValue;
            if (rangeENC0 == '0' && rangeENC1 == '0' && rangeENC2 == '0') //range of 0
            {
                return 0;
            }
            if (rangeENC0 == '0') // 2 character encoding
            {
                //POSSIBLY NEED TO CHANGE FROM INT16 TO INT32
                value1 = Convert.ToInt16(rangeENC1) - 48;
                value2 = Convert.ToInt16(rangeENC2) - 48;
                //integer to binary string
                value4 = ToBin(value1, 6);
                value5 = ToBin(value2, 6);
                //inefficient methods built in
                /*
                value3 = Convert.ToString(value1,2);
                value4 = Convert.ToString(value2, 2);
                */
                //concatenate binary, then convert to decimal for range
                binaryString = value4 + value5;
                // var result = int.Parse(binaryString);
                // rangeValue = Convert.ToInt16(result);
                rangeValue = Convert.ToInt32(binaryString, 2);

                return rangeValue;
            }
            else // 3 character encoding
            {
                //char to integers
                value1 = Convert.ToInt16(rangeENC0) - 48;
                value2 = Convert.ToInt16(rangeENC1) - 48;
                value3 = Convert.ToInt16(rangeENC2) - 48;
                //integers to binary strings
                value4 = ToBin(value1, 6);
                value5 = ToBin(value2, 6);
                value6 = ToBin(value3, 6);
                //concatenate binary strings
                binaryString = value4 + value5 + value6;
                //convert to integer
                rangeValue = Convert.ToInt32(binaryString, 2);
                return rangeValue;
            }
        }
        public Tuple<int[], TimeSpan> getRange(string myPortName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool gdflag = false;
            bool testFlag = false;
            char[] newchararray = new char[2110]; //raw data without first 22 bytes
            char[] charArray; //raw char
            string data; // raw data
            char[] onlyrangedata = new char[2048];
            char[,] encodeddist = new char[682, 3];
            int[] rangeValues = new int[682];
            Hokuyo sensor1 = new Hokuyo(myPortName);
            sensor1.HokuyoOpen();
            sensor1.WriteCommand("BM"); // turn laser on
            sensor1.read();
            //sensor1.ReadCommand();
            // sensor1.WriteCommand("SS750000"); // this makes sure the bit rate of the sensor is same
            //sensor1.read();
            //sensor1.WriteCommand("TM");
            //sensor1.read();

            //sensor1.ReadCommand();
            sensor1.WriteCommand("GD0044072500"); // latest measurement data to host
            //testdata = sensor1.read();
            while (!gdflag)
            {
                if (sensor1.bytesToRead() > 100)
                {
                    //Console.WriteLine("how many bytes to read: {0}", sensor1.bytesToRead());
                    while (!testFlag)
                    {
                        data = sensor1.read(); //readexisting
                        charArray = data.ToCharArray(); //array of ASCII char

                        //3RD LINE FEED TO END OF IT
                        for (int i = 31; i < charArray.Length - 1; i++)
                        {
                            newchararray[i - 31] = charArray[i];
                        }

                        //WE DO NOT WANT SUM OR LF
                        for (int x = 0; x <= 31; x++)
                        {
                            for (int l = 0; l < 64; l++)
                            {
                                onlyrangedata[64 * x + l] = newchararray[66 * x + l];
                            }
                        }
                        //newchararray = newchararray.Where(val => val != value).ToArray(); // deletes LF but not sum... (We could use Matlab methods
                        int stepNum = onlyrangedata.Length / 3;
                        for (int k = 0; k < stepNum; k++)
                        {
                            encodeddist[k, 0] = (char)onlyrangedata.GetValue(k * 3);
                            encodeddist[k, 1] = (char)onlyrangedata.GetValue(k * 3 + 1);
                            encodeddist[k, 2] = (char)onlyrangedata.GetValue(k * 3 + 2);
                        }
                        int numRows = encodeddist.GetLength(0); //number of rows
                        for (int k = 0; k < numRows; k++)
                        {
                            rangeValues[k] = decodeSCIP(encodeddist[k, 0], encodeddist[k, 1], encodeddist[k, 2]);
                        }
                        testFlag = true;
                    }
                    gdflag = true;
                }
            }
           // rangeValues.ToList().ForEach(i => Console.WriteLine(i.ToString()));
            // sensor1.WriteCommand("QT"); // TURN LASER OFF
            sensor1.HokuyoClose();
            sw.Stop();
            return Tuple.Create(rangeValues, sw.Elapsed);
        }

        #endregion
        private SerialPort hokuyo = new SerialPort();


        #region basic functionality
        public Hokuyo(string portname)
        {
            SetBaudRate(750000);
            SetDataBits(8);
            SetPortName("COM"+portname);
           // Timeouts(1000, 500);
        }
        public void HokuyoOpen() // opens
        {
            hokuyo.Open();
        }
        public void SetPortName(string portName)
        {
            hokuyo.PortName = portName;
        }
        public void SetBaudRate(int baudRate)
        {
            hokuyo.BaudRate = baudRate;
        }
        public void SetDataBits(int dataBits)
        {
            hokuyo.DataBits = 8;
        }
        public void Timeouts(int readTimeout, int writeTimeout)
        {
            hokuyo.ReadTimeout = 1000;
            hokuyo.WriteTimeout = 1000;
        }
        public void HokuyoClose()
        {
            hokuyo.Close();
        }
        public void WriteCommand(string writeCommand)
        {
            hokuyo.WriteLine(writeCommand);
        }
       
        public void ReadCommand() // BAD BLOCKING CODE, NEED TO USE EVENT HANDLING
        {
            bool gdflag = false;

            while (!gdflag)
            {
                try
                {
                    Console.WriteLine(hokuyo.ReadLine());
                }
                catch
                {
                    gdflag = true;
                }
            }
        }
        public int bytesToRead()
        {
            int ifBytes = hokuyo.BytesToRead;
            return ifBytes;
        }

        public string read()
        {
            string thisisit = hokuyo.ReadExisting();
            return thisisit;
        }
        #endregion


    }
}
