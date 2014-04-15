using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Common;
using Messages;


namespace Agents
{
    public class ConversationStrategy_Factory
    {
        // enums are static by default (.. a  type .. ?)
        public enum agentType { BrilliantStudent, ExcuseGenerator, TwineSpinner };


        public ConversationStrategy_Factory() { }

        public ConversationExecutionStrategy Create(agentType _agent, ConversationExecutionStrategy.SendMethod _send)
        {
            switch (_agent)
            {
                case agentType.BrilliantStudent:
                    return new ConversationExecutionStrategy_BS(_send) as ConversationExecutionStrategy;

                case agentType.ExcuseGenerator:
                    return new ConversationExecutionStrategy_EG(_send) as ConversationExecutionStrategy;
                    
                case agentType.TwineSpinner:
                    return new ConversationExecutionStrategy_TS(_send) as ConversationExecutionStrategy;
                default:
                    return null;
            }
        }

    }
}
