using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunicationSubsystem;
using Messages;
using Strategy;
using GameData;

namespace Agents
{
    
    public abstract class Agent : IObserver<object>
    {
        // Agent common qualities...

        // Midware
        protected Communicator communicator;
        protected Listener listener;
        protected MessageQ requestQ;
        protected Conversations conversationsQ;
        protected Doer doer;
        protected StateData stateData;



        // TODO
        private IDisposable unsubscriber;
        private string instName;



        public virtual void Subscribe(IObservable<object> provider)
        {
            if (provider != null)
            {
                // provider.Subscibe returns an IDisposable object to quit ahead of time (if need be).
                unsubscriber = provider.Subscribe(this);
            }
        }


        
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }




        // implement IObserver
        public virtual void OnCompleted() 
        { 
            // Action

            // unsubscribe
            this.Unsubscribe();
        }



        public virtual void OnError(Exception e)
        {
            // NOTHING ... for now
        }




        public virtual void OnNext(object data)
        {
            // notify the game strategy (different from the conversation strategy)
        }
    }
}

