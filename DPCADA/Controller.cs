using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCADA
{
    class Controller
    {
        public static Tuple<double, double, double, double, double, double> ClosedLoopControl(Tuple<double, double, double> current, Tuple<double, double, double> desired, Tuple<double, double, double> summationIntegral, Tuple<double, double, double> lastPosition, double dt)
        {
            //initialize current and desired Pos/Head
            double currentX = current.Item1; double currentY = current.Item2; double currentH = current.Item3;
            double desiredX = desired.Item1; double desiredY = desired.Item2; double desiredH = desired.Item3;

            //initalize summation of error over time
            double xIntegral = summationIntegral.Item1; double yIntegral = summationIntegral.Item2; double hIntegral = summationIntegral.Item3;

            //initialize last position
            double lastX = lastPosition.Item1; double lastY = lastPosition.Item2; double lastH = lastPosition.Item3;

            //find error between desired and current
            double errorX = (desiredX - currentX) / 1000; double errorY = (desiredY - currentY) / 1000;
            double errorH = (desiredH - currentH) / 1000; //Divided by 1000 unintentionally, but heading controller is currently tuned for this error
            dt = dt / 1000; //milliseconds to seconds

            // allows to correct heading around 0 degrees and 360 degrees
            if (errorH > 180)
            {
                errorH = ((desiredH + 360) - currentH) / 1000;
            }
            /*



                }
                public static Tuple<double, double, double, double, double, double> ClosedLoopControl(Tuple<double, double, double> current, Tuple<double, double, double> desired, Tuple<double, double, double> summationIntegral, Tuple<double, double, double> lastPosition, double dt)
                {
                    //initialize current and desired Pos/Head
                    double currentX = current.Item1; double currentY = current.Item2; double currentH = current.Item3;
                    double desiredX = desired.Item1; double desiredY = desired.Item2; double desiredH = desired.Item3;

                    //initalize summation of error over time
                    double xIntegral = summationIntegral.Item1; double yIntegral = summationIntegral.Item2; double hIntegral = summationIntegral.Item3;

                    //initialize last position
                    double lastX = lastPosition.Item1; double lastY = lastPosition.Item2; double lastH = lastPosition.Item3;

                    //find error between desired and current
                    double errorX = (desiredX - currentX) / 1000; double errorY = (desiredY - currentY) / 1000;
                    double errorH = (desiredH - currentH) / 1000; //Divided by 1000 unintentionally, but heading controller is currently tuned for this error
                    dt = dt / 1000; //milliseconds to seconds

                    // allows to correct heading around 0 degrees and 360 degrees
                    if (errorH > 180)
                    {
                        errorH = ((desiredH + 360) - currentH) / 1000;
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
            double Kpx = 2 * 4.4904 / 75;
                double Kix = 2.2966 / 75;

                double Kpy = 2 * 3.3089 / 75;
                double Kiy = 1.9084 / 75;

                double Kph = 3.5 * 3.3089 / 100;
                double Kih = 1.9084 / 100;
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
                yIntegral = yIntegral + errorY * dt;
                //Y portion using margins to designate output from controller
                if (errorY < 50)
                {
                    yIntegral = 0;
                }
                Iy = Kiy * yIntegral;
                if (Iy > .4 * Py)
                {
                    Iy = .4 * Py;
                }
                ThrustY = (Py + Iy);

                //X Portion for output of controller
                xIntegral = xIntegral + errorX * dt;
                if (errorX < 50)
                {
                    xIntegral = 0;
                }
                Ix = Kix * xIntegral;
                if (Ix > .4 * Px)
                {
                    Ix = .4 * Px;
                }
                ThrustX = (Px + Ix);

                //Heading Portion
                hIntegral = hIntegral + errorH * dt;
                if (errorH < 3)
                {
                    hIntegral = 0;
                }
                Ih = Kih * hIntegral;
                if (Ih > .4 * Ph)
                {
                    Ih = .4 * Ph;
                }
                ThrustH = (Ph + Ih - Dh);

                return Tuple.Create(xIntegral, yIntegral, hIntegral, ThrustX, ThrustY, ThrustH);

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
                    thrust6 = thrustH * .6; //scaled to .6 because they are more powerful than translational thrusters
                    dir3 = 1;
                    dir6 = 1;
                }
                else if (thrustH < 0)
                {
                    //     thrust3 = -thrustH / 2;
                    thrust6 = -thrustH * .6;
                    dir3 = 0;
                    dir6 = 0;
                }
                else if (thrustH == 0)
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

                for (int i = 0; i < 6; i++)
                {
                    if (thrustArray[i] > 1)
                    {
                        thrustArray[i] = 1;
                    }
                    else if (thrustArray[i] < 0)
                    {
                        Console.WriteLine("ERROR, THRUST ARRAY GIVEN NEGATIVE COMMAND");
                        thrustArray[i] = 0;
                    }
                    thrustArray[i] = Math.Ceiling(thrustArray[i] * 50); //PWM values from 5-55 out of 0-255
                    thrustArray[i] = thrustArray[i] + 5; //DC gain
                    indexThruster++;

                    //commands for each (i) thruster... ex: 10255 (thruster 1, backwards direction(0), 255 PWM)
                    //one command for each thruster will be given of this specified 5 character string length 
                    commands[i] = indexThruster.ToString() + dirArray[i].ToString() + thrustArray[i].ToString("000");
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
                double initialX = -300;
                double initialY = -100;
                double initialH = 90;

                //initialize arduino according to the COM port in the Program field
                SerialPort myArduino = new SerialPort("COM" + program.ard.ToString(), 57600); //com can change and note baudrate
                myArduino.Open();

                //Desired values
                double desiredX = 300;
                double desiredY = 100;
                double desiredH = 180;
                double X_Integral = 0;
                double Y_Integral = 0;
                double H_Integral = 0;
                string[] commArd = new string[6];
                Tuple<double, double, double> desiredPosition = new Tuple<double, double, double>(desiredX, desiredY, desiredH); //where we want to be
                Tuple<double, double, double> lastPosition = new Tuple<double, double, double>(initialX, initialY, initialH); //where we last were
                Tuple<double, double, double> finalPosition; //where we are now
                Tuple<double, double, double> integral = new Tuple<double, double, double>(X_Integral, Y_Integral, H_Integral);
                Tuple<double, double, double, double, double, double> inputThrusters;
                Queue<string> commArdFile = new Queue<string>(); //used for output of desired data to process in Matlab afterwards
                string commArdSum = "";
                int testCount = 0;
                myStop.Start();
                while (testCount < 300) //300 samples of data --> 72-77 seconds
                {
                    sw.Start();
                    var myanswers = program.testfunction2(); //threaded acquire data
                    finalPosition = program.PositionHeading(myanswers, lastPosition); //get our position
                    sw.Stop(); //how long it took us to acquire data for 3 sensors (1 sample)
                    inputThrusters = ClosedLoopControl(finalPosition, desiredPosition, integral, lastPosition, Convert.ToDouble(sw.Elapsed.TotalMilliseconds)); //current,desired,integral, and then last position and time elapse
                    commArd = thrusterCommands(inputThrusters.Item4, inputThrusters.Item5, inputThrusters.Item6, finalPosition.Item3);
                    for (int i = 0; i < 6; i++)
                    {
                        myArduino.Write(commArd[i]);
                        commArdSum = commArdSum + "\t" + commArd[i];
                    }

                    commArdFile.Enqueue(commArdSum + "\t" + finalPosition.Item1 + "\t" + finalPosition.Item2 + "\t" + finalPosition.Item3 + "\t" + sw.Elapsed.Milliseconds.ToString());
                    commArdSum = "";
                    lastPosition = finalPosition;
                    integral = Tuple.Create(inputThrusters.Item1, inputThrusters.Item2, inputThrusters.Item3);
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
}
}
