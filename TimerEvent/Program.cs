/*
 *Atur
 *
 * demostration of event on timer.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;

namespace TimerEvent
{
    public class Program
    {
        
        Timer tEvent = null;
        Stopwatch clock = null;
        int counter;

        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.StartTimer();

            // see this is gets printed at first
            Console.WriteLine("\nProcess Completed. Press a key to Exit.");

            //Readline here is necessary to actually let the timer functions run
            //or else the program will close prematurely
            Console.ReadLine();
        }

        /// <summary>
        /// Starts the timer functionality
        /// </summary>
        protected void StartTimer()
        {
            counter = 0;
            clock = new Stopwatch();
            clock.Start();

            tEvent =  new Timer();

            ClockTick(counter, clock.Elapsed, clock.ElapsedMilliseconds, clock.ElapsedTicks);
            StartProcesses();
           
        }

        /// <summary>
        /// Clocks the tick.
        /// </summary>
        /// <param name="count">count.</param>
        /// <param name="timeSpan">time span.</param>
        /// <param name="elapsedMilliSec">elapsed milli sec.</param>
        /// <param name="elapsedTicks"> elapsed ticks.</param>
        protected void ClockTick(int count, TimeSpan timeSpan, long elapsedMilliSec, long elapsedTicks)
        {
            string message = "{0} run at timespan => {1}, total elapsed milliseconds => {2} with elapsed ticks count at => {3} ";
            Console.WriteLine(string.Format(message,count,timeSpan, elapsedMilliSec, elapsedTicks)) ;
            Console.WriteLine("\n");
        }

        /// <summary>
        /// Starts the timer processes.
        /// </summary>
        protected void StartProcesses()
        {
            if (counter >= 10)
            {
                tEvent.Elapsed -= new ElapsedEventHandler(Timer_Elasped);
                Console.WriteLine("\nProcess is really Completed. Press a key to Exit.");
                return;
            }
            else
            {
                counter++;
                tEvent.Interval = 2 * 1000;
                tEvent.Elapsed -= new ElapsedEventHandler(Timer_Elasped);
                tEvent.Elapsed += new ElapsedEventHandler(Timer_Elasped);
                tEvent.Start();
            }
        }

        /// <summary>
        /// Handles the Elasped event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        protected void Timer_Elasped(object sender, ElapsedEventArgs e)
        {
            ClockTick(counter, clock.Elapsed, clock.ElapsedMilliseconds, clock.ElapsedTicks);
            StartProcesses();
        }
    }
}
