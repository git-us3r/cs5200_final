using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using Agents;


namespace GameData
{


    ////////////////////////////////////////////////
    // 
    // StateData: Following, there are the factory, abstract, and concrete classes
    // needed to maintain the game state data
    //////
    public abstract class StateData
    {
        protected StateData() { }

        // COMMON  PROPERTIES
        // Strength Points
        // game parameters
        // playing field
        // game layout
        // contacts
        // resources

        public int strengthPoints { get; set; }
        public GameInfo gameInfo { get; set; }
        public GameConfiguration gameConfig { get; set; }
        public PlayingFieldLayout fieldLayout { get; set; }
        public HashSet<Agent> contacts { get; set; }
        public HashSet<DistributableObject> resources { get; set; }


    }// END abstract class



    /////
    //
    // Concrete StateData  implementations for each agent.
    /////
    public class StateData_BrilliantStudent : StateData
    {
        public int sidewalkSpeedFactor { get; set; }
        public int grassSpeedFactor { get; set; }

        public StateData_BrilliantStudent(int _strengthPoints, int _sidewalkSpeedFactor, int _grassSpeedFactor) 
        {
            strengthPoints = _strengthPoints;
            sidewalkSpeedFactor = _sidewalkSpeedFactor;
            grassSpeedFactor = _grassSpeedFactor;
        }
    }


    public class StateData_ExcuseGenerator : StateData
    {
        public int creationRate { get; set; }
        public int excuseAccelerationRate { get; set; }

        public StateData_ExcuseGenerator(int _strengthPoints, int _creationRate, int _excuseAccelerationRate) 
        {
            strengthPoints = _strengthPoints;
            creationRate = _creationRate;
            excuseAccelerationRate = _excuseAccelerationRate;
        }
    }


    public class StateData_TwineSpinner : StateData
    {
        public int creationRate { get; set; }
        public int twineAccelerationRate { get; set; }

        public StateData_TwineSpinner(int _strengthPoints, int _creationRate, int _twineAccelerationRate) 
        {
            strengthPoints = _strengthPoints;
            creationRate = _creationRate;
            twineAccelerationRate = _twineAccelerationRate;
        }
    }

    // END CONCRETE StateData implementations


    /// <summary>
    /// Used to generate an appropriate StateData object, depending on the agent.
    /// </summary>
    public class StateDataFactory
    {
        // enums are static by default (.. a  type .. ?)
        public enum agentType { BrilliantStudent, ExcuseGenerator, TwineSpinner };

        public StateDataFactory() { }

        public StateData getDataForm(agentType _agent, int agentParam1, int agentParam2, int agentParam3)
        {
            switch (_agent)
            {
                case agentType.BrilliantStudent:
                    return new StateData_BrilliantStudent(agentParam1, agentParam2, agentParam3) as StateData;

                case agentType.ExcuseGenerator:
                    return new StateData_ExcuseGenerator(agentParam1, agentParam2, agentParam3) as StateData;
                    
                case agentType.TwineSpinner:
                    return new StateData_TwineSpinner(agentParam1, agentParam2, agentParam3) as StateData;
                default:
                    return null;
            }
        }
    }
}
