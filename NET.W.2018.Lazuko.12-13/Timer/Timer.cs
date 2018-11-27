using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Timer
{
    /// <summary>
    /// class Timer;
    /// </summary>
    public class Timer
    {
        public EventHandler<TimerInfoEventArgs> TimerOuted;

        /// <summary>
        /// Starts the timer. Then raises event.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        private void StartTimer(int seconds)
        {
            Thread.Sleep(seconds / 10);

            OnTimerOuted(new TimerInfoEventArgs());
        }

        /// <summary>
        /// Raises the <see cref="E:TimerOuted" /> event.
        /// </summary>
        /// <param name="info">The <see cref="TimerInfoEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTimerOuted(TimerInfoEventArgs info)
        {
            TimerOuted?.Invoke(this, info);
        }
    }
}
