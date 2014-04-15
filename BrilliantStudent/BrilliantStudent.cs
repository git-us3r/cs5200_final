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
    public class BrilliantStudent : Agent
    {
        public BrilliantStudent()
        {
            // See protected members of Agent.

            communicator = new Communicator();
            requestQ = new MessageQ("RQ");
            conversationsQ = new Conversations();
            listener = new Listener(ref communicator, ref requestQ, ref conversationsQ);

            doer = new Doer();

            AgentInfo defaultInfo = new AgentInfo(uniqueId, AgentInfo.PossibleAgentType.BrilliantStudent);

            // Needs updating
            stateData = new StateData_BS(defaultInfo, 1, 1, 1);

            cee = new ConversationExecutionStrategy_BS(communicator.send);

            resourcePool = new AgentResourcePool();

            brain = new AgentBrain_BS(ref stateData, communicator.send);

            resourceManager = new ResourceManager_BS(ref resourcePool, ref stateData);

            listener.Start();
            doer.Start();
            brain.Start();

        }


    }
}
