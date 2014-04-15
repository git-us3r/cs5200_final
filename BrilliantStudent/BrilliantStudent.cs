using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agents
{
    public class BrilliantStudent : Agent
    {

        // implement IObserver
        public override void OnCompleted() { }
        public override void OnError(Exception e) { }
        public override void OnNext(object data) { }

        // A Brilliant Student agent acts on its own to a) move around the playing field, 
        // b) gather excuses, c) gather whining twine, d) build bombs, and e) destroy zombies. 


        // properties
        // Strength Points
        // Sidewalk Speed Factor
        // Grass speed factor
        // brain
        // GameExecutionStrategy


        // functions : this are the functions that need to be implemented
        // in the corresponding execution strategy

        // ask game for parameters
        // ask game for playing field
        // ask game for layout
        // ask game for zombie data
        // ask game for other agent's data
        // gather excuse
        // gather twine
        // make bomb
        // throw bomb   (talk to playing field)
        // move (talk to game)
        // talk to student (exchange data)
        // get eaten
        // get destroyed
        // heal
        // send data

    }
}
