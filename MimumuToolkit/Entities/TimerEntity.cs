using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimumuToolkit.Entities
{
    public class TimerEntity
    {
        public int IntervalSeconds { get; set; }
        public Action? ElapsedAction { get; set; }
        public DateTime LastElapsedTime { get; set; } = DateTime.MinValue;

        public TimerEntity(int intervalseconds, Action action)
        {
            IntervalSeconds = intervalseconds;
            ElapsedAction = action;
        }
    }
}
