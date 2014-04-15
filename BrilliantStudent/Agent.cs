using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunicationSubsystem;
using Common;
using Messages;

namespace Agents
{
    
    public abstract class Agent
    {

        public static Int16 uniqueId = 2345;

        // TODO
        private IDisposable unsubscriber;
        
        private string instName;

        // Agent common qualities...

        // Midware
        protected Communicator communicator;
        protected Listener listener;
        protected MessageQ requestQ;
        protected Conversations conversationsQ;
        protected Doer doer;
        protected StateData stateData;
        protected ConversationExecutionStrategy cee;
        protected AgentResourcePool resourcePool;
        protected AgentBrain brain;
        protected ResourceManager resourceManager;


        public Agent() 
        {
            // for now, just increment the unique id.
            uniqueId++;
   
            // Instantiate comm subsys elements
            // Instantiate  data and resources entities
            //  StateData is initialized with a mostly empty AgentInfo object.
            // Recall ResourceManager -> Observes -> ConversationExecutionStrategy
            //  TODO: instantiate manager and strat call subscribe on manager with a reference
            //          to the strat.

            // ...
            //
            // Fire up the Brain

        }

        

        // The agent will no longer be the observer ... the resource manager will be.
        // The agent is an active thread (active behaviors)
        // The manager is a passive object, only being invoked by the notify method.
        //////
        //#region IObserver
        //public virtual void Subscribe(IObservable<NotificationObject> provider)
        //{
        //    if (provider != null)
        //    {
        //        // provider.Subscibe returns an IDisposable object to quit ahead of time (if need be).
        //        unsubscriber = provider.Subscribe(this);
        //    }
        //}


        
        //public virtual void Unsubscribe()
        //{
        //    unsubscriber.Dispose();
        //}




        //// implement IObserver
        //public virtual void OnCompleted() 
        //{ 
        //    // Action

        //    // unsubscribe
        //    this.Unsubscribe();
        //}



        //public virtual void OnError(Exception e)
        //{
        //    // NOTHING ... for now
        //}




        //public virtual void OnNext(NotificationObject _notification)
        //{
        //    // call active strategy with _notification.
        //    // Notification can be (1) resource or (2) state change.
        //    /////

        //    switch (_notification.notificationType)
        //    {
        //        case Message.MESSAGE_CLASS_IDS.ResourceReply:
        //            ProcessResource(_notification.data as DistributableObject);
        //            break;

        //        case Message.MESSAGE_CLASS_IDS.TickDelivery:
        //            ProcessTick(_notification.data as Tick);
        //            break;

        //        case Message.MESSAGE_CLASS_IDS.StatusReply:
        //            ProcessStatus(_notification.data as AgentInfo);
        //            break;

        //        case Message.MESSAGE_CLASS_IDS.PlayingFieldReply:
        //            ProcessPlayingField(_notification.data as PlayingFieldLayout);
        //            break;

        //        case Message.MESSAGE_CLASS_IDS.ConfigurationReply:
        //            ProcessConfiguration(_notification.data as GameConfiguration);
        //            break;

        //        case Message.MESSAGE_CLASS_IDS.AgentListReply:
        //            ProcessAgentList(_notification.data as AgentList);
        //            break;

        //        case Message.MESSAGE_CLASS_IDS.ChangeStrength:
        //            ProcessStateChange(_notification.data as StateChange);
        //            break;
        //    }


        //}
        //#endregion





        


    }
}

