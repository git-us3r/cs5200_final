using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Common;
using Messages;
using CommunicationSubsystem;

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
        public WhiningSpinner()
        {
            // See protected members of Agent.

            communicator = new Communicator();
            requestQ = new MessageQ("RQ");
            conversationsQ = new Conversations();
            listener = new Listener(ref communicator, ref requestQ, ref conversationsQ);

            doer = new Doer();

            AgentInfo defaultInfo = new AgentInfo(uniqueId, AgentInfo.PossibleAgentType.WhiningSpinner);

            // Needs updating
            stateData = new StateData_BS(defaultInfo, 1, 1, 1);

            cee = new ConversationExecutionStrategy_TS(communicator.send);

            resourcePool = new AgentResourcePool();

            brain = new AgentBrain_TS();

            resourceManager = new ResourceManager_TS(ref resourcePool, ref stateData);

            listener.Start();
            doer.Start();
            brain.Start();

        }

    }
}
