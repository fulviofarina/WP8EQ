﻿using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;
using System;
using System.Diagnostics;
using System.Windows;

namespace Agent
{
    public class ScheduledAgent : ScheduledTaskAgent
    {


/*
        // This is shared amongst all the pages
        // It is the contents of the log itself, as a large string
        public string LogText = "";



        const string logFileName = "logfile.txt";

        // Get a reference to the Mutex. 
        private static Mutex mut = new Mutex(false, "LocationLogMutex");

        public bool SaveLogToIsolatedStorageFile()
        {
            mut.WaitOne(); // Wait until it is safe to enter

            try
            {
                // Obtain the virtual store for the application.
                IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

                // Specify the file path and options.
                using (var isoFileStream = new IsolatedStorageFileStream(logFileName, FileMode.Create, myStore))
                {
                    //Write the data
                    using (var isoFileWriter = new StreamWriter(isoFileStream))
                    {
                        isoFileWriter.WriteLine(LogText);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                mut.ReleaseMutex(); // Release the Mutex. 
            }
        }


        public bool LoadLogFromIsolatedStorageFile()
        {
            mut.WaitOne(); // Wait until it is safe to enter

            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

            try
            {
                // Specify the file path and options.
                using (var isoFileStream = new IsolatedStorageFileStream(logFileName, FileMode.Open, myStore))
                {
                    // Read the data.
                    using (var isoFileReader = new StreamReader(isoFileStream))
                    {
                        LogText = isoFileReader.ReadToEnd();
                    }
                }
                return true;
            }
            catch
            {
                LogText = "";
                return false;
            }
            finally
            {
                mut.ReleaseMutex(); // Release the Mutex. 
            }
        }

        */
        public object Tag;
        /// <remarks>
        /// ScheduledAgent constructor, initializes the UnhandledException handler
        /// </remarks>
        static ScheduledAgent()
        {
            // Subscribe to the managed exception handler
            Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                Application.Current.UnhandledException += UnhandledException;
            });



        }

        /// Code to execute on Unhandled Exceptions
        private static void UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                Debugger.Break();
            }
        }

        /// <summary>
        /// Agent that runs a scheduled task
        /// </summary>
        /// <param name="task">
        /// The invoked task
        /// </param>
        /// <remarks>
        /// This method is called when a periodic or resource intensive task is invoked
        /// </remarks>
        protected override void OnInvoke(ScheduledTask task)
        {

             EQ.Main.Start(task, doSomething);
           
          //  Task p =  as Task;
           // ScheduledActionService.LaunchForTest(task.Name, TimeSpan.FromSeconds(10));
            
        }

        private void doSomething(IAsyncResult rs)
        {
            string message = "Esto es una prueba";

            //  if (LoadLogFromIsolatedStorageFile())
            {
                //  message = "Loaded";
            }
            //   else
            {
                // message = "Initialised";
            }

            DateTime timeStamp = DateTime.Now;
            string timeStampString = timeStamp.ToShortDateString() + " " + timeStamp.ToShortTimeString() + " ";

            //   GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            //   watcher.Start();

            //   string positionString = watcher.Position.Location.ToString() + System.Environment.NewLine;

            if (Microsoft.Phone.Info.DeviceStatus.DeviceName == "XDeviceEmulator")
            {
                // GeoCoordinateWatcher.Position doesn't contian meaningful data in the emulator, so fake it
                //       positionString = "In the emulator" + System.Environment.NewLine;
            }



            //    LogText = LogText + timeStampString + positionString;

            //    SaveLogToIsolatedStorageFile();


            ///QUITAR DE AQUI

       

            ShellToast toast = new ShellToast();
            toast.Title = "EQ Alert:";
            toast.Content = message;
            toast.Show();

            NotifyComplete();

         //   EQ.Main.NotifyAll();


         

        }
    }
}