using System;
using System.Timers;

namespace Hedenrag
{
    namespace FnH
    {
        public static class AsyncWait
        {
            public static void Wait(Action action, float seconds)
            {
                int miliseconds = (int)(seconds * 1000f);
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
    }
}