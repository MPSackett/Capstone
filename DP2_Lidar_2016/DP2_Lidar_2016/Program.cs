/*
Dp2_Lidar_2016:

This is the main program for the project, it interfaces with the LIDAR, calculates position, and runs the controller. 
Prior to using this the tank should be configured correctly and the navaidLocation program run to determine   the position of the aids.
The positions of the aids must be manually typed in to this program. Also initial and desired position can be manually input. 
Before testing you should insure the platform is in the specified initial position or else it will not work. The test should
run for the pre selected number of samples and then stop and display the time at the end, however if there is an error the platform
may keep sending thruster commands, to stop the thruster commands the program should be closed, and then the allstop program needs to
be run. 

*/

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //used to Thread (parallel process) sensors
using System.IO.Ports; //used for setting up SerialPort class
using System.IO; //used for setting up SerialPort class
using System.Collections;
using System.Reflection; // assembly directory
using Accord.Math; //libray for matrix math



namespace DP2_Lidar_2016
{
    class Program
    {
        int[] samples3; //first sensor samples (field of class Program) for common access storage
        int[] samples4; //second sensor samples (field of class Program) for common access storage
        int[] samples5; //third sensor samples (field of class Program) for common access storage
        int sensor1 = 7; //changes depending on com port each is plugged into
        int sensor2 = 9; //changes depending on com port each is plugged into
        int sensor3 = 12; //changes depending on com port each is plugged into
        int ard = 11; //changes depending on com port each is plugged into

        /*  This funcion is necessary for converting an integer value of some length into a binary string. 
            This is used for the SCIP 2.0 Protocol
            //FUNCTION THAT CONVERTS INTEGER TO BINARY STRING -- http://stackoverflow.com/questions/1838963/easy-and-fast-way-to-convert-an-int-to-binary
        */
        public static string ToBin(int value, int len)
        {
            return (len > 1 ? ToBin(value >> 1, len - 1) : null) + "01"[value & 1];
        }
        /*  FUNCTION THAT DECODES ENCODED DISTANCE DATA ONLY
            It takes each of the three columns (ASCII text) and is used to decode them into a string of binary bits
            The binary bits are then concatenated and returned as an integer for a range.
            There is 2-character and 3-character encoding specified in the SCIP2.0 Protocol. This function takes three columns
            of one row at a time.

            Parameters: Three columns of ASCII text (encoded)
            Output: range for one row of three columns
        */
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

        /*  Threaded, but blocking until all are acquired function to obtain LIDAR data
            This funcion can thread as many sensors as you desire, but we only use 3.
            It starts a thread for each sensor of the getRange2 function (which acquires data from one sensor)
            This function is no longer a test function and was implemented.

            Parameters: none (although it is modifiable)
            Output: Tuple (data collection) of three arrays of LIDAR ranges, one set of ranges from each sensor
        */
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
            
            //DISPLAY PURPOSES to compare
            /*
            for (int i = 0; i < program.samples3.Length - 1; i++)
            {
                int j = program.samples3[i];
                int k = program.samples4[i];
                int l = program.samples5[i];
                Console.WriteLine("sensor1: {0}\tsensor2: {1}\tsensor3: {2}", j, k, l);
            }
            */
            return Tuple.Create(myint1, myint2, myint3);
        }

        /*  Obtains range data for one sensor. It is used in a thread and outputs data to global fields of class Program
            The output is not used in our threads, but we were curious of sampling times for testing purposes

            Parameters: sensor number (COM #)
            Output: how long it took to acquire (is not used as we output values to Program fields (samples3,samples4,samples5)

        */
        public TimeSpan getRange2(int whichSensor)
        {
            bool gdflag = false; //whether we have data flag
            bool testFlag = false; //testing flag
            char[] newchararray = new char[2110]; //raw data without first 22 bytes of ASCII
            char[] charArray; //raw char array
            string data; // raw data string
            char[] onlyrangedata = new char[2048]; //After we cut out extraneous data specified in SCIP 2.0 
            char[,] encodeddist = new char[682, 3]; // we take onlyrangedata and put it into three columns
            int[] rangeValues = new int[682]; //encodeddist is encoded therefore we must decode each row of three columns into 682 rows of ranges
            Stopwatch sw = new Stopwatch(); //for timing
            sw.Start(); //start
            SerialPort sp2 = new SerialPort("COM" + whichSensor.ToString(), 57600, 0, 8); //SerialPort for designated sensor. Be careful modifying BaudRate
            sp2.Open(); //open serialport first always
            sp2.WriteLine("BM"); //turns laser on. only need to run at start SCIP 2.0 Protocol
            sp2.WriteLine("GD0044072500"); //command to acquire data (Specified in SCIP 2.0 Protocol)
            while (!gdflag) //while we have not obtained data, continue until we do
            {
                if (sp2.BytesToRead > 100) //we got some data
                {
                    while (!testFlag) // so that we read everything
                    {
                        data = sp2.ReadExisting(); //reade xisting data on serialport
                        sp2.Close(); //VERY IMPORTANT TO CLOSE IMMEDIATELY TO AVOID OPENING OPEN PORTS!!!  
                        charArray = data.ToCharArray(); //array of ASCII characters

                        //3RD LINE FEED TO END OF IT (designated in SCIP)
                        int z = charArray.Length - 2111;
                        for (int i = z; i < charArray.Length - 1; i++)
                        {
                            newchararray[i - z] = charArray[i];
                        }

                        //WE DO NOT WANT SUM OR LF characters
                        for (int x = 0; x <= 31; x++)
                        {
                            for (int l = 0; l < 64; l++)
                            {
                                onlyrangedata[64 * x + l] = newchararray[66 * x + l];
                            }
                        }

                        //Take the data for only ranges and put it into three columns of 682 rows
                        int stepNum = onlyrangedata.Length / 3;
                        for (int k = 0; k < stepNum; k++)
                        {
                            encodeddist[k, 0] = (char)onlyrangedata.GetValue(k * 3);
                            encodeddist[k, 1] = (char)onlyrangedata.GetValue(k * 3 + 1);
                            encodeddist[k, 2] = (char)onlyrangedata.GetValue(k * 3 + 2);
                        }

                        // for each row decode the three columns to get a range
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
            sw.Stop();
            if (sp2.PortName == "COM"+sensor1.ToString())
            {
                samples3 = rangeValues; //assign it to Program field
            }
            else if (sp2.PortName == "COM"+sensor2.ToString())
            {
                samples4 = rangeValues;
            }
            else if (sp2.PortName == "COM"+sensor3.ToString())
            {
                samples5 = rangeValues;
            }

            return sw.Elapsed;
        }

        //calculates ranges and bearings for one sensor (used in positionHeading function)
        public Tuple<SortedList<char , double>, Queue<double>> AbsoluteRangesAndAngles(int[] sensor, Tuple<double, double, double> initialPosition , int sensorNum)
        {
            //control variable used to determine how many nav aids are seen. 
            int sensorState = 0;
            //navaid ranges, each nav aid is seen in multiple steps of the scan, (ranges are in mm)
            Queue<int> s1Aid1 = new Queue<int>();
            Queue<int> s1Aid2 = new Queue<int>();
            Queue<int> s1Aid3 = new Queue<int>();
            Queue<int> s1Aid4 = new Queue<int>();
            Queue<int> s1Aid5 = new Queue<int>();
            Queue<int> s1Aid6 = new Queue<int>();
            Queue<int> s1Aid7 = new Queue<int>();
            Queue<int> s1Aid8 = new Queue<int>();
            //navaid angle
            Queue<int> s1Aid1Angle = new Queue<int>(); 
            Queue<int> s1Aid2Angle = new Queue<int>();
            Queue<int> s1Aid3Angle = new Queue<int>();
            Queue<int> s1Aid4Angle = new Queue<int>();
            Queue<int> s1Aid5Angle = new Queue<int>();
            Queue<int> s1Aid6Angle = new Queue<int>();
            Queue<int> s1Aid7Angle = new Queue<int>();
            Queue<int> s1Aid8Angle = new Queue<int>();
            //inialize range variables
            int range1 = 0;
            int range2 = 0;
            int range3 = 0;
            int range4 = 0;
            int range5 = 0;
            int range6 = 0;
            int range7 = 0;
            int range8 = 0;
            //initialize angle variables (180 is easier for troubleshooting than 0)
            double angle1 = 180;
            double angle2 = 180;
            double angle3 = 180;
            double angle4 = 180;
            double angle5 = 180;
            double angle6 = 180;
            double angle7 = 180;
            double angle8 = 180;
            // initialize corners of the tank. (these are used for the dynamic mask)
            double corner1 = 0;
            double corner2 = 0;
            double corner3 = 0;
            double corner4 = 0;
            //queue of ranges and angles when relative ranges and angles are computed
            Queue<int> relativeRangeQueue = new Queue<int>();
            Queue<double> relativeAngleQueue = new Queue<double>();
            // initialize heading and headingShift, heading is the actual heading of the sensor, headingShift is the correction to
            // shift measured headings from sensor3 and sensor2 to the heading of sensor1 which is the heading of the platform.  
            double heading = 0;
            double headingShift = 0;
            
            // For sensor1 the heading is the same as the platforms heading and the shift is 0
            if (sensorNum == 1)
            {
                heading = initialPosition.Item3;
                headingShift = 0;
            }
            // for sensor2 the heading is +120 degrees from the platforms heading, and the shift is +120
            else if (sensorNum == 2)
            {
                heading = initialPosition.Item3 + 120;
                headingShift = 120;
            }
            // sensor3 is -120 and -120
            else if (sensorNum ==3)
            {
                heading = initialPosition.Item3 - 120;
                headingShift = -120;

            }

            //DYNAMIC MASK, this part is kinda messy but I couldn't think of a better way. 
            // First you have to determine the angle to each of the corners from the platform. I convert everything to degrees
            // even though C# does everything in radians.
            corner1 = Math.Atan((2300 - initialPosition.Item1) / (1350 - initialPosition.Item2)) * 180 / Math.PI - heading;
            corner2 = Math.Atan((1350 + initialPosition.Item2) / (2300 - initialPosition.Item1)) * 180 / Math.PI + 90 - heading;
            corner3 = Math.Atan((2300 + initialPosition.Item1) / (1350 + initialPosition.Item2)) * 180 / Math.PI + 180 - heading;
            corner4 = Math.Atan((1350 - initialPosition.Item2) / (2300 + initialPosition.Item1)) * 180 / Math.PI + 270 - heading;
            
            // if angle is greater than 240 degrees correct it by subtracting 360 degrees, this that the magnitude of the angles
            // can be compared to determine which is seen first.
            while (corner1 > 240)
            {
                corner1 = corner1 - 360;
            }
            while (corner2 > 240)
            {
                corner2 = corner2 - 360;
            }
            while (corner3 > 240)
            {
                corner3 = corner3 - 360;
            }
            while (corner4 > 240)
            {
                corner4 = corner4 - 360;
            }


            // convert angles to steps in scans, if negative then  the corner is seen, if positive the corner is not seen
            int stepCorner1 = Convert.ToInt16((corner1 - 120) / .3524229) ;
            int stepCorner2 = Convert.ToInt16((corner2 - 120) / .3524229) ;
            int stepCorner3 = Convert.ToInt16((corner3 - 120) / .3524229) ;
            int stepCorner4 = Convert.ToInt16((corner4 - 120) / .3524229) ;

            // maskList: key equals the step at which the corner occurs, value is the specfic corner,
            // only seen corners are stored in list. Since it is a sorted list the list is organized by key values, so the first seen 
            // corners are on the top of the list and the last seen are at the bottom.
            SortedList<int, int> maskList = new SortedList<int, int>() ;
            
            // negative steps(seen) are entered into the mask list
            if (stepCorner1 < 0 && stepCorner1 > -682)
            {
                maskList.Add(stepCorner1, 1);
            }
            if (stepCorner2 < 0 && stepCorner2 > -682)
            {
                maskList.Add(stepCorner2, 2);
            }
            if (stepCorner3 < 0 && stepCorner3 > -682)
            {
                maskList.Add(stepCorner3, 3);
            }
            if (stepCorner4 < 0 && stepCorner4 > -682)
            {
                maskList.Add(stepCorner4, 4);
            }

            // control entry for last portion of mask 
            maskList.Add(0, 5);

            // intialize control variables
            int lastCornerStep = 999;
            int lastCorner = 0 ;
            int count = 1;
            int length = maskList.Count;
            int initial = 0 ;
            int final = 0 ;
            double maxRange = 9999;
           
            // go through the masklist to determine the initial and final step of the scan. (counterclockwise)
            // Start at the 681 step and go to 0. All scans are processed this way 681->0 to make scans counterclockwise.
            foreach (var corner in maskList)
            {
                // for first entery it goes from the initial step to the first corner seen.
                if (count == 1)
                {
                    initial = 681;
                    // negative because steps are positive. they were converted to negative to organize sortedList.
                    final = -corner.Key;
                    lastCornerStep = final;
                }
                // intermediate steps, between two seen corners
                else if (count > 1 && count != length)
                {
                    // start with the last corner seens step value
                    initial = lastCornerStep ;
                    final = -corner.Key;
                    lastCornerStep = final;
                }
                // Once all corners are seen the last leg is from the last seen corner to 0
                else if (count > 1 && count == length)
                {
                    initial = lastCornerStep;
                    final = 0;
                }
                // Once inital and final values are calculated begin masking the data, first the maxRange is calculated, then
                // the maxRange is compared to the scanned range to determine whether or not to zero out the value.
                for (int i = initial; i-- > final;)
                {
                    // Determine max range based on polar plots for each corner value the corresponding polar equation is the 
                    // line that occurs to before the corner.
                    if (corner.Value == 1)
                    {
                        // maxRange for the specfic leg of the scan.
                        maxRange = (1350 - initialPosition.Item2) / Math.Cos((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        lastCorner = 1;
                    }
                    else if (corner.Value == 2)
                    {
                        maxRange = (2300 - initialPosition.Item1) / Math.Sin((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        lastCorner = 2;
                    }
                    else if (corner.Value == 3)
                    {
                        maxRange = (-1350 - initialPosition.Item2) / Math.Cos((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        lastCorner = 3;
                    }
                    else if (corner.Value == 4)
                    {
                        maxRange = (-2300 - initialPosition.Item1) / Math.Sin((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        lastCorner = 4;
                    }
                    // special case, this account for the leg seen after the last corner, new equations occur after the last seen corner
                    else if (corner.Value == 5)
                    {
                        if (lastCorner == 1)
                        {
                            maxRange = (2300 - initialPosition.Item1) / Math.Sin((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        }
                        else if ( lastCorner == 2)
                        {
                            maxRange = (-1350 - initialPosition.Item2) / Math.Cos((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        }
                        else if (lastCorner == 3)
                        {
                            maxRange = (-2300 - initialPosition.Item1) / Math.Sin((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        }
                        else if (lastCorner ==4)
                        {
                            maxRange = (1350 - initialPosition.Item2) / Math.Cos((i * -.3524229 + 120 + heading) * Math.PI / 180);
                        }
                    }
                    // set value to 0 if it is greater than max range, also remove values under 400 mm, all values that are not
                    // ranges to nav aids should be zeroed out in this section
                    if (sensor[i] > maxRange || sensor[i] < 400)
                    {
                        sensor[i] = 0;
                    }
                    // DYNAMIC MASK IS COMPLETE, NOW WE PROCESS THE RANGE DATA
                    // as long as the range=0 nothing has been seen.
                    if (sensor[i] == 0 && sensorState == 0) //RANGE IS 0 AND hasn't seen navaid
                    {

                    }
                    // once a non zero value is seen it is time to begine storing the range data.
                    else if (sensor[i] != 0 && sensorState == 0) //range is nonzero and currently sees (first entry, first step)
                    {
                        s1Aid1.Enqueue(sensor[i]); //store range of step
                        s1Aid1Angle.Enqueue(i); //store step (for angle use)
                        sensorState = 1; //update state
                    }
                    else if (sensor[i] != 0 && sensorState == 1) //range is nonzero and stores the rest of the entries
                    {
                        s1Aid1.Enqueue(sensor[i]); // enqueue the rest of the values and steps
                        s1Aid1Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 1) //range is zero and finished first navaid
                    {
                        int[] aid1 = new int[s1Aid1.Count]; // initialize array to enter into queue
                        s1Aid1.CopyTo(aid1, 0); //put queue into array
                        range1 = aid1.Min() + 70; //minimum of queue  is the final range, add 70mm (radius of nav aids)  
                        int index1 = Array.IndexOf(aid1, range1-70); // This is the index of the miniumum value of our range
                        int[] aid1A = new int[s1Aid1Angle.Count]; //WE WANT TO FIND THE INDEX OF THE MIN VALUE OF THE AID QUEUE
                        s1Aid1Angle.CopyTo(aid1A, 0);
                        angle1 = aid1A[index1]; //step value
                        angle1 = -angle1 * 0.3524229 + 120; //convert to an angle
                        sensorState = 2;
                    }
                    // repeat process for other nav aids until complete with scan
                    else if (sensor[i] == 0 && sensorState == 2)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 2)
                    {
                        s1Aid2.Enqueue(sensor[i]);
                        s1Aid2Angle.Enqueue(i);
                        sensorState = 3;
                    }
                    else if (sensor[i] != 0 && sensorState == 3)
                    {
                        s1Aid2.Enqueue(sensor[i]);
                        s1Aid2Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 3)
                    {
                        int[] aid2 = new int[s1Aid2.Count];
                        s1Aid2.CopyTo(aid2, 0);
                        range2 = aid2.Min() + 70;
                        int index2 = Array.IndexOf(aid2, range2-70);
                        int[] aid2A = new int[s1Aid2Angle.Count];
                        s1Aid2Angle.CopyTo(aid2A, 0);
                        angle2 = aid2A[index2];
                        angle2 = -angle2 * 0.3524229 + 120;
                        sensorState = 4;
                    }
                    else if (sensor[i] == 0 && sensorState == 4)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 4)
                    {
                        s1Aid3.Enqueue(sensor[i]);
                        s1Aid3Angle.Enqueue(i);
                        sensorState = 5;
                    }
                    else if (sensor[i] != 0 && sensorState == 5)
                    {
                        s1Aid3.Enqueue(sensor[i]);
                        s1Aid3Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 5)
                    {
                        int[] aid3 = new int[s1Aid3.Count];
                        s1Aid3.CopyTo(aid3, 0);
                        range3 = aid3.Min() + 70;
                        int index3 = Array.IndexOf(aid3, range3-70);
                        int[] aid3A = new int[s1Aid3Angle.Count];
                        s1Aid3Angle.CopyTo(aid3A, 0);
                        angle3 = aid3A[index3];
                        angle3 = -angle3 * 0.3524229 + 120;
                        sensorState = 6;

                    }
                    else if (sensor[i] == 0 && sensorState == 6)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 6)
                    {
                        s1Aid4.Enqueue(sensor[i]);
                        s1Aid4Angle.Enqueue(i);
                        sensorState = 7;
                    }
                    else if (sensor[i] != 0 && sensorState == 7)
                    {
                        s1Aid4.Enqueue(sensor[i]);
                        s1Aid4Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 7)
                    {
                        int[] aid4 = new int[s1Aid4.Count];
                        s1Aid4.CopyTo(aid4, 0);
                        range4 = aid4.Min() + 70;
                        int index4 = Array.IndexOf(aid4, range4-70);
                        int[] aid4A = new int[s1Aid4Angle.Count];
                        s1Aid4Angle.CopyTo(aid4A, 0);
                        angle4 = aid4A[index4];
                        angle4 = -angle4 * 0.3524229 + 120;
                        sensorState = 8;
                    }
                    else if (sensor[i] == 0 && sensorState == 8)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 8)
                    {
                        s1Aid5.Enqueue(sensor[i]);
                        s1Aid5Angle.Enqueue(i);
                        sensorState = 9;
                    }
                    else if (sensor[i] != 0 && sensorState == 9)
                    {
                        s1Aid5.Enqueue(sensor[i]);
                        s1Aid5Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 9)
                    {
                        int[] aid5 = new int[s1Aid5.Count];
                        s1Aid5.CopyTo(aid5, 0);
                        range5 = aid5.Min() + 70;
                        int index5 = Array.IndexOf(aid5, range5-70);
                        int[] aid5A = new int[s1Aid5Angle.Count];
                        s1Aid5Angle.CopyTo(aid5A, 0);
                        angle5 = aid5A[index5];
                        angle5 = -angle5 * 0.3524229 + 120;
                        sensorState = 10;
                    }
                    else if (sensor[i] == 0 && sensorState == 10)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 10)
                    {
                        s1Aid6.Enqueue(sensor[i]);
                        s1Aid6Angle.Enqueue(i);
                        sensorState = 11;
                    }
                    else if (sensor[i] != 0 && sensorState == 11)
                    {
                        s1Aid6.Enqueue(sensor[i]);
                        s1Aid6Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 11)
                    {
                        int[] aid6 = new int[s1Aid6.Count];
                        s1Aid6.CopyTo(aid6, 0);
                        range6 = aid6.Min() + 70;
                        int index6 = Array.IndexOf(aid6, range6-70);
                        int[] aid6A = new int[s1Aid6Angle.Count];
                        s1Aid6Angle.CopyTo(aid6A, 0);
                        angle6 = aid6A[index6];
                        angle6 = -angle6 * 0.3524229 + 120;
                        sensorState = 12;
                    }
                    else if (sensor[i] == 0 && sensorState == 12)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 12)
                    {
                        s1Aid7.Enqueue(sensor[i]);
                        s1Aid7Angle.Enqueue(i);
                        sensorState = 13;
                    }
                    else if (sensor[i] != 0 && sensorState == 13)
                    {
                        s1Aid7.Enqueue(sensor[i]);
                        s1Aid7Angle.Enqueue(i);
                    }
                    else if (sensor[i] == 0 && sensorState == 13)
                    {
                        int[] aid7 = new int[s1Aid7.Count];
                        s1Aid7.CopyTo(aid7, 0);
                        range7 = aid7.Min() + 70;
                        int index7 = Array.IndexOf(aid7, range7-70);
                        int[] aid7A = new int[s1Aid7Angle.Count];
                        s1Aid7Angle.CopyTo(aid7A, 0);
                        angle7 = aid7A[index7];
                        angle7 = -angle7 * 0.3524229 + 120;
                        sensorState = 14;
                    }
                    else if (sensor[i] == 0 && sensorState == 14)
                    {

                    }
                    else if (sensor[i] != 0 && sensorState == 14)
                    {
                        s1Aid8.Enqueue(sensor[i]);
                        s1Aid8Angle.Enqueue(i);
                        sensorState = 15;
                    }
                    else if (sensor[i] != 0 && sensorState == 15)
                    {
                        s1Aid8.Enqueue(sensor[i]);
                        s1Aid8Angle.Enqueue(i);
                    }
                    else
                    {
                        int[] aid8 = new int[s1Aid8.Count];
                        s1Aid8Angle.CopyTo(aid8, 0);
                        range8 = aid8.Min() + 70;
                        int index8 = Array.IndexOf(aid8, range8-70);
                        int[] aid8A = new int[s1Aid8Angle.Count];
                        s1Aid8.CopyTo(aid8A, 0);
                        angle8 = aid8A[index8];
                        angle8 = -angle8 * 0.3524229 + 120;
                    }
                    //WE NOW HAVE UP TO 8 RANGES AND 8 ANGLES FROM A SINGLE SCAN
                
                }
                count++;
            }
            // store non zero ranges for output
            if (range1 != 0)
            {
                relativeRangeQueue.Enqueue(range1);
                relativeAngleQueue.Enqueue(angle1);
            }
            if (range2 != 0)
            {
                relativeRangeQueue.Enqueue(range2);
                relativeAngleQueue.Enqueue(angle2);
            }
            if (range3 != 0)
            {
                relativeRangeQueue.Enqueue(range3);
                relativeAngleQueue.Enqueue(angle3);
            }
            if (range4 != 0)
            {
                relativeRangeQueue.Enqueue(range4);
                relativeAngleQueue.Enqueue(angle4);
            }
            if (range5 != 0)
            {
                relativeRangeQueue.Enqueue(range5);
                relativeAngleQueue.Enqueue(angle5);
            }
            if (range6 != 0)
            {
                relativeRangeQueue.Enqueue(range6);
                relativeAngleQueue.Enqueue(angle6);
            }
            if (range7 != 0)
            {
                relativeRangeQueue.Enqueue(range7);
                relativeAngleQueue.Enqueue(angle7);
            }
            if (range8 != 0)
            {
                relativeRangeQueue.Enqueue(range8);
                relativeAngleQueue.Enqueue(angle8);
            }

            // control variable
            bool testingFlag = false;

            //initialize variables 
            int r1 = 0;
            int r2 = 0;
            double a1 = 0;
            double a2 = 0;
            double spacing = 0;
            SortedList<char, double> returnSortedList = new SortedList<char, double>(); //this will return the absolute navaids with the range
            int shiftCount = 0;
            //char[] aids = {'F', 'G','H','A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'A', 'X', 'Z' , 'Z', 'Y' };
            //int lastStore = 14;
            int clear = 0; 
            Queue<double> absoluteHeading = new Queue<double>();

            while (!testingFlag)
            {
                // if we have not shifter more than once and the count is greater than once, determine the spacing between the next 
                // two items in the scan. 
                if (relativeRangeQueue.Count() > 1 && shiftCount < 2)
                {
                    // determine the distance betweent the next two navaids, peek is used so we can shift the queue if the spacing is 
                    // not a nav aid spacing. 
                    r1 = relativeRangeQueue.Dequeue();
                    r2 = relativeRangeQueue.Peek();
                    a1 = relativeAngleQueue.Dequeue();
                    a2 = relativeAngleQueue.Peek();
                    spacing = Math.Sqrt(Math.Pow(r1 * Math.Cos(a1*Math.PI/180) - r2 * Math.Cos(a2*Math.PI/180), 2) + Math.Pow(r1 * Math.Sin(a1*Math.PI/180) - r2 * Math.Sin(a2*Math.PI/180), 2)); //calculates spacing between nav-aids

                    if (spacing < 660 && spacing > 500) //NAVAID-AB
                    {
                        // try catch for debugging, shouldn't slow it down much though, this shouldn't error anymore though 
                        try
                        {
                            returnSortedList.Add('A', r1);
                            returnSortedList.Add('B', r2);
                        }
                        catch
                        {
                            // unique clear value for debugging
                            clear = 1;
                        }
                        r2 = relativeRangeQueue.Dequeue();
                        a2 = relativeAngleQueue.Dequeue();
                        //lastStore = 4;
                        // Two cases of calculating headings for each nav aid pair. 
                        if (r1 > r2)
                        {
                            double h = -a1 + Math.Asin(r2 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift; // 500 is the distance between A and B
                            absoluteHeading.Enqueue(h);
                        }
                        else
                        {
                            double h = 180 - a2 - Math.Asin(r1 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift;
                            absoluteHeading.Enqueue(h);
                        }
                    }
                    else if (spacing < 940 && spacing > 790) //NAVAID-EF
                    {
                        try
                        {
                            returnSortedList.Add('E', r1);
                            returnSortedList.Add('F', r2);
                        }
                        catch
                        {
                            clear = 2;
                        }
                        r2 = relativeRangeQueue.Dequeue();
                        a2 = relativeAngleQueue.Dequeue();
                        //lastStore = 8;
                        if (r1 > r2)
                        {
                            double h = -180 - a1 + Math.Asin(r2 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift; // 500 is the distance between A and B
                            absoluteHeading.Enqueue(h);
                        }
                        else
                        {
                            double h = -a2 - Math.Asin(r1 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift;
                            absoluteHeading.Enqueue(h);
                        }

                    }
                    else if (spacing < 1270 && spacing > 1010) //NAVAID-CD
                    {
                        try
                        {
                            returnSortedList.Add('C', r1);
                            returnSortedList.Add('D', r2);
                        }
                        catch
                        {
                            clear = 3;
                        }
                        r2 = relativeRangeQueue.Dequeue();
                        a2 = relativeAngleQueue.Dequeue();
                        //lastStore = 6;
                        if (r1 > r2)
                        {
                            double h = 90 - a1 + Math.Asin(r2 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift; // 1100 is the distance between A and B
                            absoluteHeading.Enqueue(h);
                        }
                        else
                        {
                            double h = -90 - a2 - Math.Asin(r1 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift;
                            absoluteHeading.Enqueue(h);
                        }

                    }
                    else if (spacing < 1460 && spacing > 1300) //NAVAID-GH
                    {
                        try
                        {
                            returnSortedList.Add('G', r1);
                            returnSortedList.Add('H', r2);
                        }
                        catch
                        {
                            clear = 4;
                        }
                        r2 = relativeRangeQueue.Dequeue();
                        a2 = relativeAngleQueue.Dequeue();
                        //lastStore = 10;
                        if (r1 > r2)
                        {
                            double h = -90 - a1 + Math.Asin(r2 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift; // 1100 is the distance between A and B
                            absoluteHeading.Enqueue(h);
                        }
                        else
                        {
                            double h = 90 - a2 - Math.Asin(r1 * Math.Sin((a2 - a1) * Math.PI / 180) / spacing) * 180 / Math.PI - headingShift;
                            absoluteHeading.Enqueue(h);
                        }
                    }
                    else // first two not nav aid pair so we shift the queue and check again
                    {
                        relativeRangeQueue.Enqueue(r1);
                        relativeAngleQueue.Enqueue(a1);
                        shiftCount++;
                    }
                }
                // this reduced the consistancy of our measurments so we took it out
                /*else if (relativeRangeQueue.Count == 1) // Odd cases
                {
                    if (shiftCount == 0) //found a pair or more, but trailing single navaid
                    {
                        try
                        {
                            returnSortedList.Add(aids[lastStore + 1], relativeRangeQueue.Dequeue());
                        }
                        catch
                        {
                            clear = 5; 
                        }
                            testingFlag = true;
                    }
                    
                    else if (shiftCount == 1) //leading single naviaid then pairs (but we still shifted leading navaid to trail)
                    {
                        try
                        {
                            returnSortedList.Add(aids[lastStore - returnSortedList.Count()], relativeRangeQueue.Dequeue());
                        }
                         catch
                        {
                            clear = 6;
                        }
                            testingFlag = true;
                    }
                }*/
                // if we shift twice were done
                else if (shiftCount == 2) 
                {
                    
                /*
                    try
                    {
                        returnSortedList.Add(aids[lastStore + 1], relativeRangeQueue.Dequeue());
                        returnSortedList.Add(aids[lastStore - returnSortedList.Count + 1], relativeRangeQueue.Dequeue());
                    }
                    catch
                    {
                        clear = 7;
                    }*/ 
                    testingFlag = true; // to exit loop
                }
                // if count is zero no nav aids left so exit loop
                else if (relativeRangeQueue.Count == 0)
                {
                    testingFlag = true;
                }
                else
                {
                    returnSortedList.Add('Z', 9999);
                    testingFlag = true;
                }
            }
            if (clear != 0)
            {
                returnSortedList.Clear();
                absoluteHeading.Clear(); 
            }
            return Tuple.Create(returnSortedList,absoluteHeading);

        }
        
        public Tuple<double, double, double> PositionHeading(Tuple<int[],int[],int[]> myScans, Tuple<double, double, double> initialPosition)
        {
            //Gets the ranges and angles for each sensor, if you couldn't tell...
            //POSSIBLE BETTER IMPLEMENTATION WOULD TO PUT IN THREAD FOR EACH SENSOR PROCESS??? -- will be decided later

            // send initial position and data and get back queues with the ranges and angles 
            Tuple<SortedList<char, double>,Queue<double>> sensor1RangesAndAngles = AbsoluteRangesAndAngles(myScans.Item1, initialPosition, 1);
            Tuple<SortedList<char, double>, Queue<double>> sensor2RangesAndAngles = AbsoluteRangesAndAngles(myScans.Item2, initialPosition, 2);
            Tuple<SortedList<char, double>, Queue<double>> sensor3RangesAndAngles = AbsoluteRangesAndAngles(myScans.Item3, initialPosition, 3);

            int size = sensor1RangesAndAngles.Item1.Count + sensor2RangesAndAngles.Item1.Count+ sensor3RangesAndAngles.Item1.Count;
            // intialize matrix for calculations
            double[,] H = new double[size, 2];
            double[,] deltaRange = new double[size, 1];
            // row of matrix to write too
            int currentRow = 0;
            // assumed x and y coordinate 
            double x = 0;
            double y = 0;
            double h = 0;
            // nav aid positions, update this with information from navaidLocation function!
            double aX = 1854.6; double aY = 219;
            double bX = 1881.5; double bY = -354.2;
            double cX = 466.4; double cY = -1265.1;
            double dX = -603.3; double dY = -1213.1;
            double eX = -2031.9; double eY = -496.7;
            double fX = -2040.9; double fY = 389.2;
            double gX = -860.2; double gY = 1152.3;
            double hX = 525.2; double hY = 1072.9;
            
            // overdetermined least squares matrix solution, 7 iterations enough for convergance!
            for (int i = 0; i < 7; i++)
            {
                // remove nav aid ranges from sensor1 and begin generating H matrix and deltaRange matrix
                foreach (var sensor in sensor1RangesAndAngles.Item1)
                {
                    if (sensor.Key == 'A')
                    {
                        // Generate componenets of H matrix
                        H[currentRow, 0] = (x - aX) / sensor.Value;
                        H[currentRow, 1] = (y - aY) / sensor.Value;
                        // generate deltaRange matrix by subtracting asumed range from measured range (aka distance calculation from asumed position to nav aid minus sensor range)
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - aX, 2) + Math.Pow(y - aY, 2)) - sensor.Value;
                        // update row of matrix
                        currentRow++;
                    }
                    // repeat process for other nav aids
                    else if (sensor.Key == 'B')
                    {
                        H[currentRow, 0] = (x - bX) / sensor.Value;
                        H[currentRow, 1] = (y - bY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - bX, 2) + Math.Pow(y - bY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'C')
                    {
                        H[currentRow, 0] = (x - cX) / sensor.Value;
                        H[currentRow, 1] = (y - cY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - cX, 2) + Math.Pow(y - cY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'D')
                    {
                        H[currentRow, 0] = (x - dX) / sensor.Value;
                        H[currentRow, 1] = (y - dY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - dX, 2) + Math.Pow(y - dY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'E')
                    {
                        H[currentRow, 0] = (x - eX) / sensor.Value;
                        H[currentRow, 1] = (y - eY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - eX, 2) + Math.Pow(y - eY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'F')
                    {
                        H[currentRow, 0] = (x - fX) / sensor.Value;
                        H[currentRow, 1] = (y - fY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - fX, 2) + Math.Pow(y - fY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'G')
                    {
                        H[currentRow, 0] = (x - gX) / sensor.Value;
                        H[currentRow, 1] = (y - gY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - gX, 2) + Math.Pow(y - gY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'H')
                    {
                        H[currentRow, 0] = (x - hX) / sensor.Value;
                        H[currentRow, 1] = (y - hY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - hX, 2) + Math.Pow(y - hY, 2)) - sensor.Value;
                        currentRow++;
                    }
                }
                // repeat for each sensor
                foreach (var sensor in sensor2RangesAndAngles.Item1)
                {
                    if (sensor.Key == 'A')
                    {
                        // Generate componenets of H matrix
                        H[currentRow, 0] = (x - aX) / sensor.Value;
                        H[currentRow, 1] = (y - aY) / sensor.Value;
                        // generate deltaRange matrix by subtracting asumed range from measured range (aka distance calculation from asumed position to nav aid minus sensor range)
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - aX, 2) + Math.Pow(y - aY, 2)) - sensor.Value;
                        // update row of matrix
                        currentRow++;
                    }
                    else if (sensor.Key == 'B')
                    {
                        H[currentRow, 0] = (x - bX) / sensor.Value;
                        H[currentRow, 1] = (y - bY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - bX, 2) + Math.Pow(y - bY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'C')
                    {
                        H[currentRow, 0] = (x - cX) / sensor.Value;
                        H[currentRow, 1] = (y - cY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - cX, 2) + Math.Pow(y - cY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'D')
                    {
                        H[currentRow, 0] = (x - dX) / sensor.Value;
                        H[currentRow, 1] = (y - dY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - dX, 2) + Math.Pow(y - dY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'E')
                    {
                        H[currentRow, 0] = (x - eX) / sensor.Value;
                        H[currentRow, 1] = (y - eY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - eX, 2) + Math.Pow(y - eY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'F')
                    {
                        H[currentRow, 0] = (x - fX) / sensor.Value;
                        H[currentRow, 1] = (y - fY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - fX, 2) + Math.Pow(y - fY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'G')
                    {
                        H[currentRow, 0] = (x - gX) / sensor.Value;
                        H[currentRow, 1] = (y - gY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - gX, 2) + Math.Pow(y - gY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'H')
                    {
                        H[currentRow, 0] = (x - hX) / sensor.Value;
                        H[currentRow, 1] = (y - hY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - hX, 2) + Math.Pow(y - hY, 2)) - sensor.Value;
                        currentRow++;
                    }
                }
                foreach (var sensor in sensor3RangesAndAngles.Item1)
                {
                    if (sensor.Key == 'A')
                    {
                        // Generate componenets of H matrix
                        H[currentRow, 0] = (x - aX) / sensor.Value;
                        H[currentRow, 1] = (y - aY) / sensor.Value;
                        // generate deltaRange matrix by subtracting asumed range from measured range (aka distance calculation from asumed position to nav aid minus sensor range)
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - aX, 2) + Math.Pow(y - aY, 2)) - sensor.Value;
                        // update row of matrix
                        currentRow++;
                    }
                    else if (sensor.Key == 'B')
                    {
                        H[currentRow, 0] = (x - bX) / sensor.Value;
                        H[currentRow, 1] = (y - bY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - bX, 2) + Math.Pow(y - bY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'C')
                    {
                        H[currentRow, 0] = (x - cX) / sensor.Value;
                        H[currentRow, 1] = (y - cY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - cX, 2) + Math.Pow(y - cY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'D')
                    {
                        H[currentRow, 0] = (x - dX) / sensor.Value;
                        H[currentRow, 1] = (y - dY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - dX, 2) + Math.Pow(y - dY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'E')
                    {
                        H[currentRow, 0] = (x - eX) / sensor.Value;
                        H[currentRow, 1] = (y - eY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - eX, 2) + Math.Pow(y - eY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'F')
                    {
                        H[currentRow, 0] = (x - fX) / sensor.Value;
                        H[currentRow, 1] = (y - fY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - fX, 2) + Math.Pow(y - fY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'G')
                    {
                        H[currentRow, 0] = (x - gX) / sensor.Value;
                        H[currentRow, 1] = (y - gY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - gX, 2) + Math.Pow(y - gY, 2)) - sensor.Value;
                        currentRow++;
                    }
                    else if (sensor.Key == 'H')
                    {
                        H[currentRow, 0] = (x - hX) / sensor.Value;
                        H[currentRow, 1] = (y - hY) / sensor.Value;
                        deltaRange[currentRow, 0] = Math.Sqrt(Math.Pow(x - hX, 2) + Math.Pow(y - hY, 2)) - sensor.Value;
                        currentRow++;
                    }
                }
                 
                try
                {
                    var deltaPosition = Matrix.Solve(H, deltaRange, leastSquares: false);
                    x = x - deltaPosition[0, 0];
                    y = y - deltaPosition[1, 0];
                    currentRow = 0; 
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    x= initialPosition.Item1;
                    y= initialPosition.Item2;
                    break;

                }
                
            }
            // calculate heading by putting all measured angles into a single queue
            Queue<double> finalAngle = new Queue<double>() ;
            // store all headings from sensor 1 into queue
            foreach(var angle in sensor1RangesAndAngles.Item2)
            {
                if (angle <0)
                {
                    finalAngle.Enqueue(360 + angle);
                }
                else if (angle >360)
                {
                    finalAngle.Enqueue(angle - 360);
                }
                else
                {
                    finalAngle.Enqueue(angle);
                }
            }
            //repeat for sensors 2 and 3
            foreach (var angle in sensor2RangesAndAngles.Item2)
            {
                if (angle < 0)
                {
                    finalAngle.Enqueue(360 + angle);
                }
                else if (angle > 360)
                {
                    finalAngle.Enqueue(angle - 360);
                }
                else
                {
                    finalAngle.Enqueue(angle);
                }
            }
            foreach (var angle in sensor3RangesAndAngles.Item2)
            {
                if (angle < 0)
                {
                    finalAngle.Enqueue(360 + angle);
                }
                else if (angle > 360)
                {
                    finalAngle.Enqueue(angle - 360);
                }
                else
                {
                    finalAngle.Enqueue(angle);
                }
            }
              
            // final heading is average of all measured headings
            try
            {
                h = finalAngle.Average();
            }
            catch
            {
                h = initialPosition.Item3;
            }

            // error correction, if the position/heading shows a significant jump in a single scan, asssume faulty measurments and
            // then set position equal to last position. 
            if (Math.Abs(x - initialPosition.Item1)>300)
            {
                x = initialPosition.Item1;
            }
            else if (Math.Abs(y- initialPosition.Item2)>300)
            {
                y = initialPosition.Item2;
            }
            else if (Math.Abs(h-initialPosition.Item3)>20)
            {
              h = initialPosition.Item3;
            }

            Tuple<double, double, double> xyh = new Tuple<double,double,double>(x, y, h);
            return xyh;


        }
        public static Tuple<double,double,double,double,double,double> ClosedLoopControl(Tuple<double, double, double> current, Tuple<double,double,double> desired, Tuple<double, double, double> summationIntegral, Tuple<double,double,double> lastPosition, double dt)
        {
            //initialize current and desired Pos/Head
            double currentX = current.Item1; double currentY = current.Item2;double currentH = current.Item3;
            double desiredX = desired.Item1;double desiredY = desired.Item2;double desiredH = desired.Item3;

            //initalize summation of error over time
            double xIntegral = summationIntegral.Item1;double yIntegral = summationIntegral.Item2;double hIntegral = summationIntegral.Item3;

            //initialize last position
            double lastX = lastPosition.Item1; double lastY = lastPosition.Item2; double lastH = lastPosition.Item3;

            //find error between desired and current
            double errorX = (desiredX - currentX)/1000; double errorY = (desiredY - currentY)/1000; 
            double errorH = (desiredH - currentH)/1000; //Divided by 1000 unintentionally, but heading controller is currently tuned for this error
            dt = dt / 1000; //milliseconds to seconds

            // allows to correct heading around 0 degrees and 360 degrees
            if (errorH>180)
            {
                errorH = ((desiredH + 360) - currentH)/1000;
            }
            /* 2015 DP margin implementation with their calculated values
            //Find diff between last and current
           // double diffX = lastX - currentX; double diffY = lastY - currentY; double diffH = lastH - currentH;
            
            //x and y margins
            double margin1 = 50; double margin2 = 150; double margin3 = 300; // double max = 1000;

            //heading margins
            double Hmargin1 = 2; double Hmargin2 = 10; double Hmargin3 = 25;
            
            double Kpx = 1.2511;
            double Kix = 2.0537;

            double Kpy = 1.2511;
            double Kiy = 2.0537;

            double Kph = 1.2511;
            double Kih = 2.0537;
            */
            // Coefficients
            double Kpx = 2*4.4904/75;
            double Kix = 2.2966/75;
            
            double Kpy = 2*3.3089 /75;
            double Kiy = 1.9084/75;

            double Kph = 3.5*3.3089/100;
            double Kih = 1.9084/100;
            double Kdh = .0153 / dt;

            //PI translational
            double Px = Kpx * errorX;
            double Ix = 0; //initialize
            double ThrustX = 0;
            double Py = Kpy * errorY;
            double Iy = 0; //initialize
            double ThrustY = 0;

            //PID rotational      
            double Ph = Kph * errorH;
            double lastErrorH = (desiredH - lastH) / 1000;
            if (lastErrorH > 180)
            {
                lastErrorH = ((desiredH + 360) - lastH) / 1000;
            }
            double diffH = lastErrorH - errorH;
            double Dh = Kdh * diffH;
            double Ih = 0; //initialize
            double ThrustH = 0;
 
            
            #region Old bad controller 2015 in C#
            /*
            //if else for margin x
            if (Math.Abs(errorX)  >=margin3) //P if outside of 3
            {
          //      ThrustX = 2 * Px; //net force to produce (unitless)
                Ix = Kix * xIntegral * dt;
                ThrustX = 2 * (Px + Ix);
                xIntegral = 0;
            }
            else if(Math.Abs(errorX) >= margin2 && Math.Abs(errorX) <= margin3) //PI if between 2 and 3
            {
                xIntegral = xIntegral + errorX;
                Ix = Kix * xIntegral * dt;
                //ThrustX = 2 * Ix;
                         ThrustX = 2*(Px + Ix);
           //     ThrustX = 2 * Px ;

            }
            else if(Math.Abs(errorX) >= margin1 && Math.Abs(errorX) <= margin2) //PID if between 2 and 1
            {
                xIntegral = xIntegral + errorX;
                Ix = Kix * xIntegral * dt;
                //     ThrustX = 2 * (Px + Ix-Dx);
                //ThrustX = -2 * Dx;
         //       ThrustX = 2 * Px * .4;
                ThrustX = 2 * (Px + Ix);
            }
            else
            {
                //xIntegral = 0;
                ThrustX = 0;
            }

            //if else for margin y
            if (Math.Abs(errorY) >= margin3) //P if outside of 3
            {
          //      ThrustY = 2 * Py; //net force to produce (unitless)
                Iy = Kiy * yIntegral * dt;
                ThrustY = 2 * (Py + Iy);
                yIntegral = 0;
            }
            else if (Math.Abs(errorY) >= margin2 && Math.Abs(errorY) <= margin3) //PI if between 2 and 3
            {
                yIntegral = yIntegral + errorY;
                Iy = Kiy * yIntegral * dt;
                //  ThrustY = 2 * (Py + Iy);
                //ThrustY = 2 * Iy;
            //    ThrustY = 2 * Py*.6; //net force to produce (unitless)
                ThrustY = 2 * (Py + Iy);

            }
            else if (Math.Abs(errorY) >= margin1 && Math.Abs(errorY) <= margin2) //PID if between 2 and 1
            {
                yIntegral = yIntegral + errorY;
                Iy = Kiy * yIntegral * dt;
                //   ThrustY = 2 * (Py + Iy - Dy);
                //ThrustY = -2 * Dy;
           //     ThrustY = 2 * Py*.4; //net force to produce (unitless)
                ThrustY = 2 * (Py + Iy);
            }
            else
            {
                yIntegral = 0;
                ThrustY = 0;
            }

            //control Heading
            if (Math.Abs(errorH) >= Hmargin3) //P if outside of 3
            {
                Ih = Kih * hIntegral * dt;
                ThrustH = 2 * (Ph + Ih);
          //      ThrustH = 2 * Ph; //net force to produce (unitless)
                hIntegral = 0;
            }
            else if (Math.Abs(errorH) >= Hmargin2 && Math.Abs(errorH) <= Hmargin3) //PI if between 2 and 3
            {
                hIntegral = hIntegral + errorH;
                Ih = Kih * hIntegral * dt;
                //  ThrustY = 2 * (Py + Iy);
                //ThrustH = 2 * Ih;
            //    ThrustH = 2 * Ph * .6;
                ThrustH = 2 * (Ph + Ih);

            }
            else if (Math.Abs(errorH) >= Hmargin1 && Math.Abs(errorH) <= Hmargin2) //PID if between 2 and 1
            {
                hIntegral = hIntegral + errorH;
                Ih = Kih * hIntegral * dt;
                //   ThrustY = 2 * (Py + Iy - Dy);
               // ThrustY = -2 * Dh + 2 * Ph * 1.5;
           //     ThrustH = 2 * Ph * .4;
                ThrustH = 2 * (Ph + Ih);
            }
            else
            {
                hIntegral = 0;
                ThrustH = 0;
            }
            */
            #endregion

            //Implemented controller
            yIntegral = yIntegral + errorY*dt; 
            //Y portion using margins to designate output from controller
            if (errorY<50)
            {
                yIntegral = 0;
            }
            Iy = Kiy * yIntegral ;
            if (Iy > .4*Py)
            {
                Iy = .4 * Py;
            }
            ThrustY =  (Py + Iy);

            //X Portion for output of controller
            xIntegral = xIntegral + errorX*dt;
            if (errorX < 50)
            {
                xIntegral = 0;
            }
            Ix = Kix * xIntegral ;
            if (Ix > .4 * Px)
            {
                Ix = .4 * Px;
            }
            ThrustX =  (Px + Ix);

            //Heading Portion
            hIntegral = hIntegral + errorH*dt;
            if (errorH < 3)
            {
                hIntegral = 0;
            }
            Ih = Kih * hIntegral ;
            if (Ih > .4 * Ph)
            {
                Ih = .4 * Ph;
            }
            ThrustH =   (Ph + Ih - Dh);

            return Tuple.Create(xIntegral, yIntegral, hIntegral, ThrustX, ThrustY, ThrustH) ;

        }

        /*  This function takes the output of the ClosedLoopControl Thrust values and converts them into thruster commands
            This function distributes forces evenly between translational complementary thrusters
            Only one rotational thruster, thruster 6, is used because it gave a more stable heading response
            Six commands are returned in the forms of 5 character strings

            Parameters: outputs of thrust X, Y, H, and what our current heading is
            Output: 6 strings of thruster commands to be sent via serial interface to Arduino

        */
        public static string[] thrusterCommands(double thrustX, double thrustY, double thrustH, double heading)
        {
            double thrust1 = 0; double thrust2 = 0; double thrust3 = 0; double thrust4 = 0; double thrust5 = 0; double thrust6 = 0;
            double dir1 = 0; double dir2 = 0; double dir3 = 0; double dir4 = 0; double dir5 = 0; double dir6 = 0;
            //thrust x and  y Prime represent the thrust of motors based on heading (mathematically rotating cartesian plane)
            //Projection of forces onto our own relative heading axis
            double thrustXPrime = thrustX * Math.Cos(-heading * Math.PI / 180) + thrustY * Math.Sin(-heading * Math.PI / 180);
            double thrustYPrime = -thrustX * Math.Sin(-heading * Math.PI / 180) + thrustY * Math.Cos(-heading * Math.PI / 180);

            //Y thrust amount
            if (thrustYPrime < 0)
            {
                thrust1 = -thrustYPrime / 2; //evenly distribute between Y thrusters
                thrust4 = -thrustYPrime / 2;
                dir1 = 1; //same direction
                dir4 = 0;
            }
            else if (thrustYPrime > 0)
            {
                thrust1 = thrustYPrime / 2;
                thrust4 = thrustYPrime / 2;
                dir1 = 0;
                dir4 = 1;
            }
            else if (thrustYPrime == 0) //no output force desired, therefore none sent to thrusters
            {
                thrust1 = 0; 
                thrust4 = 0;
                dir1 = 0;
                dir4 = 0;
            }
            // Same Process for X
            if (thrustXPrime < 0)
            {
                thrust2 = -thrustXPrime / 2;
                thrust5 = -thrustXPrime / 2;
                dir2 = 1;
                dir5 = 0;
            }
            else if (thrustXPrime > 0)
            {
                thrust2 = thrustXPrime / 2;
                thrust5 = thrustXPrime / 2;
                dir2 = 0;
                dir5 = 1;
            }
            else if (thrustXPrime == 0)
            {
                thrust2 = 0;
                thrust5 = 0;
                dir2 = 0;
                dir5 = 0;
            }
            //Heading uses only thruster 6 because more stable response with one thruster
            if (thrustH > 0)
            {
           //   thrust3 = thrustH / 2*.6;
                thrust6 = thrustH *.6; //scaled to .6 because they are more powerful than translational thrusters
                dir3 = 1;
                dir6 = 1;
            }
            else if (thrustH < 0)
            {
         //     thrust3 = -thrustH / 2;
                thrust6 = -thrustH*.6;
                dir3 = 0;
                dir6 = 0;
            }
            else if(thrustH == 0)
            {
                thrust3 = 0;
                thrust6 = 0;
                dir3 = 0;
                dir6 = 0;
            }

            //convert thrusts and directions to strings that are workable commands to be sent (Arduino uses PWM values from 0-255)
            //NORMALIZES THEM 
            double[] thrustArray = { thrust1, thrust2, thrust3, thrust4, thrust5, thrust6 };
            double[] dirArray = { dir1, dir2, dir3, dir4, dir5, dir6 };
            int indexThruster = 0;
            string[] commands = new string[6];
         
            for(int i = 0 ;i < 6; i++)
            {
                if (thrustArray[i] > 1)
                {
                    thrustArray[i] = 1;
                }
                else if(thrustArray[i]<0)
                {
                    Console.WriteLine("ERROR, THRUST ARRAY GIVEN NEGATIVE COMMAND");
                    thrustArray[i] = 0;
                }
                thrustArray[i] = Math.Ceiling( thrustArray[i] * 50); //PWM values from 5-55 out of 0-255
                thrustArray[i] = thrustArray[i] + 5; //DC gain
                indexThruster++; 

                //commands for each (i) thruster... ex: 10255 (thruster 1, backwards direction(0), 255 PWM)
                //one command for each thruster will be given of this specified 5 character string length 
                commands[i] =indexThruster.ToString() + dirArray[i].ToString() + thrustArray[i].ToString("000");
            }

            indexThruster = 0;
            return commands; //thruster commands returned that are sent via Pseudo-serial interface with Arduino
        }

        static void Main(string[] args)
        {
            
            #region Closed Loop Test
            Program program = new Program(); //initialize class program for field access
            double[] PRETEND = new double[3];
            Stopwatch sw = new Stopwatch(); //per sample time
            Stopwatch myStop = new Stopwatch(); //used for total time

            //INITIAL VALUES FOR PLACING IN TANK --> need for position calculation
            double initialX = -300 ;
            double initialY = -100 ;
            double initialH = 90 ;

            //initialize arduino according to the COM port in the Program field
            SerialPort myArduino = new SerialPort("COM"+ program.ard.ToString(),57600); //com can change and note baudrate
            myArduino.Open();

            //Desired values
            double desiredX = 300;
            double desiredY = 100;
            double desiredH = 180;
            double X_Integral = 0;
            double Y_Integral = 0;
            double H_Integral = 0;
            string[] commArd = new string[6];
            Tuple<double, double, double> desiredPosition = new Tuple<double, double, double>(desiredX,desiredY,desiredH); //where we want to be
            Tuple<double, double, double> lastPosition = new Tuple<double, double, double>(initialX, initialY, initialH); //where we last were
            Tuple<double, double, double> finalPosition; //where we are now
            Tuple<double, double, double> integral = new Tuple<double, double, double>(X_Integral, Y_Integral, H_Integral); 
            Tuple<double, double, double, double, double, double> inputThrusters;
            Queue<string> commArdFile = new Queue<string>(); //used for output of desired data to process in Matlab afterwards
            string commArdSum ="" ;
            int testCount = 0;
            myStop.Start(); 
            while(testCount < 300) //300 samples of data --> 72-77 seconds
            {             
                sw.Start();
                var myanswers = program.testfunction2(); //threaded acquire data
                finalPosition= program.PositionHeading(myanswers, lastPosition) ; //get our position
                sw.Stop(); //how long it took us to acquire data for 3 sensors (1 sample)
                inputThrusters = ClosedLoopControl(finalPosition, desiredPosition, integral, lastPosition, Convert.ToDouble(sw.Elapsed.TotalMilliseconds)); //current,desired,integral, and then last position and time elapse
               commArd = thrusterCommands(inputThrusters.Item4, inputThrusters.Item5, inputThrusters.Item6, finalPosition.Item3);
                for (int i = 0;i<6; i++)
                {
                   myArduino.Write(commArd[i]);
                   commArdSum= commArdSum + "\t" + commArd[i];
                }
               
                commArdFile.Enqueue(commArdSum + "\t" + finalPosition.Item1 + "\t" + finalPosition.Item2 + "\t" + finalPosition.Item3 + "\t" + sw.Elapsed.Milliseconds.ToString());
                commArdSum = "";
                lastPosition = finalPosition;
                integral = Tuple.Create(inputThrusters.Item1, inputThrusters.Item2, inputThrusters.Item3) ; 
               // Console.WriteLine("x= {0}\ty= {1}\th= {2}\tt= {3}", finalPosition.Item1, finalPosition.Item2, finalPosition.Item3, sw.Elapsed.Milliseconds.ToString());
                sw.Reset();
                testCount++;
            }
            #endregion
            //Here we do File Output to Analyze in Matlab
            myStop.Stop();
            Console.WriteLine(myStop.Elapsed.TotalSeconds.ToString());
            
            using (StreamWriter file = new StreamWriter(@"C:\finaltesting\new2sens3thrust2.txt", true))
            {
                foreach (string line in commArdFile)
                {
                    file.WriteLine("{0}", line);

                }
               // file.Write("{0}\t{1}\t{2}\t{3}", finalPosition.Item1, finalPosition.Item2, finalPosition.Item3, sw.Elapsed.Milliseconds.ToString());
                file.WriteLine();
            }
            
            myArduino.Write("10000");
            myArduino.Write("20000");
            myArduino.Write("30000");
            myArduino.Write("40000");
            myArduino.Write("50000");
            myArduino.Write("60000");
            Console.WriteLine("Adam cannot spell");
            Console.ReadKey();
        }

    }
}

//sensor1.WriteCommand("QT"); // TURN LASER OFF