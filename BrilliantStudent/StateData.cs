using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace Agents
{

    #region StateData Abstract
    public class StateData
    {
        public enum DamageStatus {TAKING_DAMAGE, SAFE}

        private object thisLock = new object();
        
        public DamageStatus myDamageStatus
        {
            get
            {
                lock (thisLock)
                {
                    return myDamageStatus;
                }
            }
            set
            {
                lock (thisLock)
                {
                    myDamageStatus = value;
                }
            }
        }



        public AgentInfo myInfo
        {
            get
            {
                lock (thisLock)
                {
                    return myInfo;
                }
            }
            set
            {
                lock (thisLock)
                {
                    myInfo = value;
                }
            }
        }


        public StateData()
        {
            // EMPTY
        }


        public StateData(AgentInfo _agentInfo)
        {
            // Initialize common data members
            myInfo = _agentInfo;
            myDamageStatus = DamageStatus.SAFE;

        }// END abstract class
    }
    #endregion

}
