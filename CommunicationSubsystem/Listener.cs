using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunicationSubsystem;

namespace CommunicationSubsystem
{
    public class Listener : BackgroundThread
    {
        // *** This is likely to change .. when we figure how to discover queues.
        private Conversations conversations;
        private MessageQ requests;
        private Communicator communicator;
        //public int port { get; set; }

        // The listener must have the following associations: (1) comm, (2) messageQ
        //// Since we don't know yet how to handle the queues, It will have its own for now.
        //public Listener()
        //{
        //    communicator = new Communicator();
        //    conversations = new Conversations();
        //    requests = new MessageQ("RQ");
        //}


        public Listener(ref Communicator comm, ref MessageQ _requests, ref Conversations _conversations)
        {
            communicator = comm;
            conversations = _conversations;
            requests = _requests;
        }


        private void fileMsg(Envelop _env)
        {
            // check conversation id and msgId
            if (_env.msg.ConversationId == _env.msg.MessageNr)
            {
                // if match place in requests
                requests.addMessage(_env);
                //conversations.
            }
            else if (conversations.hasMessageQ(_env.msg.ConversationId))
            {

                // else if a conversation exists with mathching key (conversationID) insert there
                conversations.addMessageInConversation(_env.msg.ConversationId, _env);
            }
            // else dismiss as erroneous ( do nothing )
        }




        private void work()
        {
            Envelop tempMsg = communicator.receive();
            if (tempMsg != null)
            {
                fileMsg(tempMsg);
            }
        }


        public override string ThreadName()
        {
            return "Listener";
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
