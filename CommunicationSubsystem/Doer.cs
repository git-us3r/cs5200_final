using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    

namespace CommunicationSubsystem
{
    public class Doer : BackgroundThread
    {
        private ConversationExecutionStrategy eStrat;
        private MessageQ requests;
        private Conversations conversations;

        public Doer(ref ConversationExecutionStrategy _eStrat, ref MessageQ _requests, ref Conversations _conversations)
        {
            eStrat = _eStrat;
            requests = _requests;
            conversations = _conversations;
        }

        private void work()
        {
            Envelop temp = requests.getMessage();
            if (temp != null)
            {
                eStrat.process(temp);       // TODO
            }

        }


        public override string ThreadName()
        {
            return "Main Doer";
        }


        /// <summary>
        /// Main process method for background thread
        /// 
        /// This method should stop whatever it is doing and terminate whenever keepGoing becomes false. 
        /// Also, it should not actually do any process anything but stay alive, if suspend becomes true.
        /// </summary>
        protected override void Process()
        {
            // Try to empty the input queue
            while (keepGoing)
            {
                work();
            }
        }
    }
}
