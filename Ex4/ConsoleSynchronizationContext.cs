using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    public class ConsoleSynchronizationContext : SynchronizationContext
    {
        public override void Send(SendOrPostCallback d, object? state)
        {
            Thread thread = new Thread(p=>
            {
                d.Invoke(state);
            });
            thread.Name = "My Thread";
            thread.Start();
            Console.WriteLine("Message from context");
        }

        public override void Post(SendOrPostCallback d, object? state)
        {
            try
            {
                d.Invoke(state);
            }
            catch(Exception ex)  
            {
                //Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
            }
            
        }
    }
}
