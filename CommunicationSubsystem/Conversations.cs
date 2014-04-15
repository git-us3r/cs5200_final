using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using Messages;

namespace CommunicationSubsystem
{
    public class Conversations
    {
        // A dictionary with key: ConversationId.
        private System.Collections.Generic.Dictionary<MessageNumber, MessageQ> conversations;


        /// <summary>
        /// CTOR: instantiates the dictionary
        /// </summary>
        public Conversations()
        {
            conversations = new System.Collections.Generic.Dictionary<MessageNumber, MessageQ>();
        }



        /// <summary>
        /// Adds a conversation to the dictionary with key _msgNum
        /// </summary>
        /// <param name="_msgNum"></param>
        /// <param name="_q"></param>
        public void addConversation(MessageNumber _conversationID, MessageQ _q)
        {
            conversations.Add(_conversationID, _q);
        }



        public bool hasMessageQ(Common.MessageNumber _key)
        {
            return conversations.ContainsKey(_key);
        }


        /// <summary>
        /// Adds envelop to messageQ with _key id.
        /// </summary>
        /// <param name="_key"></param>
        /// <param name="_msg"></param>
        public void addMessageInConversation(MessageNumber _key, Envelop _msg)
        {
            conversations[_key].addMessage(_msg);
        }


        /// <summary>
        /// Asynchronously retrieves the next message in queue with key _key.
        /// </summary>
        /// <param name="_key"></param>
        /// <returns></returns>
        public Envelop getNextMessageInQ(MessageNumber _key)
        {
            return conversations[_key].getMessage();
        }

    }
}
