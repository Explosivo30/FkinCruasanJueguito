using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;

public static class AsyncWait
{
    public static void Wait(Action action, float seconds)
    {
        int miliseconds =(int)(seconds * 1000f);
        Timer timer = new Timer(miliseconds);

        WaitClass waitClass = new WaitClass(action);

        timer.Elapsed += waitClass.OnTimerElapsed;
    }

    class WaitClass
    {
        readonly Action action;
        public WaitClass(Action action) 
        {
            this.action = action;
        }
        public void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            action();
        }
    }

    

    
}
