using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessinalLesson15
{
    public class ConsoleSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object? state)
        {
            Thread thread = new Thread(p =>
            {
                d.Invoke(state);
            });
            thread.Name = "ThreadFromContext";
            thread.Start();
        }
    }
}
