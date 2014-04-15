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

    public abstract class ConversationExecutionStrategy : IObservable<NotificationObject>
    {
        //public Communicator communicator;          // circular dependencies .... ehh delegates.
        public delegate void SendMethod(Message _msg, IPEndPoint _remoteEndPoint);
        public SendMethod Send; 

        public IObserver<NotificationObject> observer;          // For extensibility, add an observer container.
        


        // Default Ctor just sets the communicator member.
        public ConversationExecutionStrategy(SendMethod _send)
        {
            Send = _send;
        }


        // Excecute methods based on param msg.
        public virtual void process(Message msg, IPEndPoint ep)
        {
            // switch on msg to determine the strategy.
            switch (msg.MessageTypeId())
            {
                // Messages containing resources (DistributableResource) or state change objects
                // are processed via notification.
                // See: Agent.
                /////
                case Message.MESSAGE_CLASS_IDS.ResourceReply:
                case Message.MESSAGE_CLASS_IDS.TickDelivery:
                case Message.MESSAGE_CLASS_IDS.StatusReply:
                case Message.MESSAGE_CLASS_IDS.PlayingFieldReply:
                case Message.MESSAGE_CLASS_IDS.ConfigurationReply:
                case Message.MESSAGE_CLASS_IDS.AgentListReply:
                    NotificationObject recNotObj = new NotificationObject(msg.MessageTypeId(), (msg as ResourceReply).Resource);
                    observer.OnNext(recNotObj);
                    break;


                case Message.MESSAGE_CLASS_IDS.ChangeStrength:
                    NotificationObject reqNotObj = new NotificationObject(Message.MESSAGE_CLASS_IDS.ChangeStrength, (msg as ChangeStrength));
                    break;

                case Message.MESSAGE_CLASS_IDS.GameAnnouncement:
                    // get  public Int16 GameId { get; set; }
                    // get  public EndPoint GameSeverEP { get; set; }
                    // do something ... by the Gods, do something.
                    break;

                case Message.MESSAGE_CLASS_IDS.GetResource:
                    // reply with resource
                    // public Int16 GameId { get; set; }
                    // public PossibleResourceType GetResourceType { get; set; }
                    // public Tick EnablingTick { get; set; }
                    break;
                    
                case Message.MESSAGE_CLASS_IDS.GetStatus:
                    // reply with status
                    break;

                case Message.MESSAGE_CLASS_IDS.AckNak:
                    NotificationObject ackNotObj = new NotificationObject(msg.MessageTypeId(), (msg as AckNak).ObjResult);
                    break;

                default:
                    // Reply with Error.
                    break;                  
            }

        }



        #region From IObservable

        public IDisposable Subscribe(IObserver<NotificationObject> _observer) 
        {
            
            // Push observer into container.
            observer = _observer;


            // What to send back?
            return null;
        }



        public void Unsubscribe(IObserver<object> _observer) 
        {
            observer = null;
        }


    #endregion
    }


    // TODD: remove. It has been implemented as part of the Agent behavior. Pending tests....

    //#region ABSTRACT CLASS GAME_EXECUTION_STRATEGY
    ///// <summary>
    ///// Implements Common.BackgroundThread and IObserver
    ///// It observes the Agent
    ///// </summary>
    //public abstract class GameExecutionStrategy : BackgroundThread, IObserver<StateData>
    //{
    //    public delegate void SendMethod(Message _msg, IPEndPoint _remoteEndPoint);
    //    public SendMethod Send;

    //    private IDisposable unsubscriber;
    //    private string instName;




    //    // Default Ctor just sets the communicator member.
    //    public GameExecutionStrategy(SendMethod _send)
    //    {
    //        Send = _send;
    //    }



    //    #region Active Strategies
    //    // TODO: Implement.
    //    public virtual void JoinGame(object data) { }
    //    public virtual void GetEaten(object data) { }
    //    public virtual void GetDestroyed(object data) { }
    //    public virtual void Heal(object data) { }
    //    public virtual void RequestResource(object data) { }
    //    public virtual void RequestStatus(object data) { }

    //    #endregion



    //    #region BackgroundThread

    //    private void work()
    //    {
    //        // TODO: Student (uses GameData.StateData via notifications from Agent).
    //        // join game
    //        // while in game
    //        //  while alive
    //        //      while not takingDamage()
    //        //          if(bombSupply is empty)
    //        //              BuildBomb()
    //        //          else (if there are bombs available)
    //        //              target = FindAnyProf()
    //        //              ThrowBomb(target)
    //        //              GoAnyWhere()
    //        //      if taking damage?
    //        //          GoAnyWhere()
    //        //  if dead
    //        //      GetDestroyed
    //    }

    //    public override string ThreadName()
    //    {
    //        return "GameExecutionStrategy";
    //    }



    //    /// <summary>
    //    /// Main process method for background thread
    //    /// 
    //    /// This method should stop whatever it is doing and terminate whenever keepGoing becomes false. 
    //    /// Also, it should not actually do any process anything but stay alive, if suspend becomes true.
    //    /// </summary>
    //    protected override void Process()
    //    {
    //        // Try to empty the input queue
    //        while (keepGoing)
    //        {
    //            work();
    //        }
    //    }

    //    #endregion



    //    #region IObserver

    //    public virtual void Subscribe(IObservable<StateData> provider)
    //    {
    //        if (provider != null)
    //        {
    //            // provider.Subscibe returns an IDisposable object to quit ahead of time (if need be).
    //            unsubscriber = provider.Subscribe(this);
    //        }
    //    }



    //    public virtual void Unsubscribe()
    //    {
    //        unsubscriber.Dispose();
    //    }




    //    // implement IObserver
    //    public virtual void OnCompleted()
    //    {
    //        // Action
    //        // unsubscribe
    //        this.Unsubscribe();
    //    }



    //    public virtual void OnError(Exception e)
    //    {
    //        // NOTHING ... for now
    //    }




    //    public virtual void OnNext(StateData _stateChange)
    //    {
    //        // TODO:
    //        // update a flag so that the new state can be processed.
    //    }

    //    #endregion

    //}

    //#endregion

   
}
