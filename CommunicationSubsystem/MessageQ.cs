using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

using Common;
using Messages;

namespace CommunicationSubsystem 
{
    // Discoverable ... ? How ?
    public class MessageQ
    {
        //-----------//
        // Members
        //-----------//
        public ConcurrentQueue<Envelop> q { get; private set; }
        public string name { get; set; }


        //----------------------------------------------------------


        //-----------//
        // Methods
        //-----------//


        /// <summary>
        /// Ctor: instantiates new Concurrent queue and sets the name of the queue.
        /// </summary>
        /// <param name="_name"></param>
        public MessageQ(string _name)
        {
            q = new ConcurrentQueue<Envelop>();
            name = _name;
        }
        

        /// <summary>
        /// Enqueues an Envelop into the queue. (q)
        /// </summary>
        /// <param name="msg"></param>
        public void addMessage(Envelop msg) 
        {
            // This is too hard!
            q.Enqueue(msg);
        }



        /// <summary>
        /// Returns the next message in q.
        /// </summary>
        /// <returns></returns>
        public Envelop getMessage()
        {
            Envelop e;
            if (q.TryDequeue(out e))
            {
                return e;
            }
            else {
                return null;
            }
            
        }
        
    }

}












