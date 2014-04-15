using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using Messages;

namespace Strategy
{

    public abstract class ConversationExecutionStrategy : IObservable<object>
    {
        // Default CTOR
        protected ConversationExecutionStrategy()
        {
            // Concrete strategies will join game as part as
            // the ctor's behavior.
        }




        public virtual void process(Message msg, IPEndPoint ep)
        {
            // switch on env to determine the strategy.

        }



        // Common methods for all agents ... TODO 
        public virtual void joinGame()
        {
            // construct a new message
        }



        public abstract void startNewGame(object data);
        public abstract void newGameRequest(object data);
        public abstract void dataRequest(object data);
        public abstract void changeRequest(object data);
        public abstract void statusRequest(object data);        // noun ... ehh?

        public abstract void requestData(object data);        // verb
        public abstract void receiveTick(object data);
        public abstract void getEaten(object data);
        public abstract void getDestroyed(object data);
        public abstract void heal(object data);
        public abstract void sendData(object data);
        public abstract void phoneHome(object data);            // ask for help from any student

        // From IObservable
        public abstract IDisposable Subscribe(IObserver<object> observer);
        public abstract void Unsubscribe(IObserver<object> observer);

    }


   
   }
