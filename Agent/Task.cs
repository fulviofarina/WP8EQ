using Microsoft.Phone.Scheduler;
using System;
using System.Windows;


namespace Agent
{

/*
    public class PerTask :  
    {
        public PerTask()
            : base()
        {

        }
            public object Tag = null;


    }
    */
    public class Task 
    {

       
        public object Tag;

        private string description=string.Empty;
        private int seconds = 60;
        private PeriodicTask periodicTask = null;
         
        private string periodicTaskName = "BackgroundTask";

        public Task(string Description, int Seconds)
        {
            description = Description;
            seconds = Seconds;
           
           
            periodicTask = ScheduledActionService.Find(periodicTaskName) as PeriodicTask;

            if (periodicTask == null)
            {
                // If the task already exists and the IsEnabled property is false, background
                // agents have been disabled by the user
                if (periodicTask != null && !periodicTask.IsEnabled)
                {
                    MessageBox.Show("Background agents for this application have been disabled by the user.");
                    return;
                }

                // If the task already exists and background agents are enabled for the
                // application, you must remove the task and then add it again to update 
                // the schedule
                if (periodicTask != null && periodicTask.IsEnabled)
                {
                    RemoveAgent(periodicTaskName);
                }

             
                // If debugging is enabled, use LaunchForTest to launch the agent in one minute.

                //   trackingControlButton.Content = "Stop Tracking";
            }
            else
            {
              
                ScheduledActionService.Remove(periodicTaskName);

            }
            periodicTask = new PeriodicTask(periodicTaskName);
            // The description is required for periodic agents. This is the string that the user
            // will see in the background services Settings page on the device.
            periodicTask.Description = description;

            ScheduledActionService.Add(periodicTask);
    
       
         //   ScheduledActionService.LaunchForTest(periodicTaskName, TimeSpan.FromSeconds(seconds));
         
           
        }

     
        private void RemoveAgent(string name)
        {
            try
            {
                ScheduledActionService.Remove(name);
            }
            catch (Exception)
            {
            }
        }

    

     

      

       

    }





}
