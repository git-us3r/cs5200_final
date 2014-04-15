using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class ConversationStrategyFactory
    {
        // enums are static by default (.. a  type .. ?)
        public enum agentType { BrilliantStudent, ExcuseGenerator, TwineSpinner };

        public ConversationStrategyFactory() { }

        public ConversationExecutionStrategy getStrategy(agentType _agent)
        {
            switch (_agent)
            {
                case agentType.BrilliantStudent:
                    return new ConversationExecutionStrategy_BrilliantStudent() as ConversationExecutionStrategy;

                case agentType.ExcuseGenerator:
                    return new ConversationExecutionStrategy_ExcuseGenerator() as ConversationExecutionStrategy;
                    
                case agentType.TwineSpinner:
                    return new ConversationExecutionStrategy_TwineSpinner() as ConversationExecutionStrategy;
                default:
                    return null;
            }
        }

    }
}
