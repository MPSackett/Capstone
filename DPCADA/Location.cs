using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;



namespace DPCADA
{
    class Location
    {
        int[] samples3; //first sensor samples (field of class Program) for common access storage
        int[] samples4; //second sensor samples (field of class Program) for common access storage
        int[] samples5; //third sensor samples (field of class Program) for common access storage
        int sensor1 = 7; //changes depending on com port each is plugged into
        int sensor2 = 9; //changes depending on com port each is plugged into
        int sensor3 = 12; //changes depending on com port each is plugged into

        //For converting values to binary
        public static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }

        //For making data from sensor usable
        static public int decodeSCIP(char rangeENC0, char rangeENC1, char rangeENC2)
        {
            int value1; // integer values from ASCII text
            int value2;
            int value3;
            string value4; // binary string values from integers
            string value5;
            string value6;
            string binaryString; //concatenated binary string from all three columns after decoding
            int rangeValue; // returned range from converted binaryString
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
                //concatenate binary, then convert to decimal for range
                binaryString = value4 + value5;
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

        public Tuple<int[], int[], int[]> testfunction2()
        {
            //http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
            Program program = new Program(); // initialize class program
            Thread testThread3 = new Thread(delegate () { program.getRange2(sensor1); }); // thread each sensor with a delegate in order to thread a function with an input
            Thread testThread4 = new Thread(delegate () { program.getRange2(sensor2); });
            Thread testThread5 = new Thread(delegate () { program.getRange2(sensor3); });

            //start each thread to acquire data
            testThread3.Start();
            testThread4.Start();
            testThread5.Start();
            //stopwatch for time to acquire
            Stopwatch mytest = new Stopwatch();
            mytest.Start();
            bool myFlag = false; //while loop flag
            int[] myint1 = new int[682]; //temporary values for this function to set equal to Program fields (samples3,samples4, samples5)
            int[] myint2 = new int[682];
            int[] myint3 = new int[682];
            int scanCount = 0; //this was used for testing purposes (if we ever got in an infinite while loop of nonacquired data)
            while (!myFlag) //while not all sensors have been acquired
            {
                if (program.samples3 == null || program.samples4 == null || program.samples5 == null) //not all sensors have been acquired
                {
                    Thread.Sleep(20); //sleep
                    scanCount++; //increment to see how many loops before all data is acquired
                    /*
                    Console.WriteLine(scanCount.ToString());
                    Console.WriteLine("{0}", scanCount);
                    
                    if (scanCount >= 10)
                    {
                        scanCount = 0;
                        int[] errorVal = new int[1];
                        errorVal[0] = -1;
                        return (Tuple.Create(errorVal, errorVal, errorVal));
                    }
                    */
                } //all sensors have been acquired (might be a better way to check this)
                else if (program.samples3.Length == 682 && program.samples4.Length == 682 && program.samples5.Length == 682)
                {
                    mytest.Stop(); //stop stopwatch for sampling time -> sampling frequency
                    myint1 = program.samples3; //program field which are global (necessary for threading here) so that we can return values
                    myint2 = program.samples4;
                    myint3 = program.samples5;
                    myFlag = true;
                }
                else
                {
                    Console.WriteLine("SENSORS NOT ACQUIRED");
                    break;
                }
            }

            return Tuple.Create(myint1, myint2, myint3);
        }

    }
}
