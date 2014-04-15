using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    /// <summary>
    /// A Whining Spinner listens for time ticks from the Clock Tower and one each tick 
    /// makes progress towards building some whining twine.  It also keeps a queue of completed whining 
    /// twine and responds to requests for whining twine from Brilliant Students on a first‐coming, first‐serve 
    /// basis. 
    /// </summary>
    public class WhiningSpinner : Agent
    {

        // implement IObserver
        public override void OnCompleted() { }
        public override void OnError(Exception e) { }
        public override void OnNext(object data) { }

        // strength points
        // twine creation rate

        // ask game for config params
        // twine acceleration rate
        // get eaten
        // get destroyed
        // listen .. 
        // respond to student
        // send status

    }
}
