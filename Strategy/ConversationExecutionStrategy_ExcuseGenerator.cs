using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strategy
{
    class ConversationExecutionStrategy_ExcuseGenerator : ConversationExecutionStrategy
    {
        public override void process(object data) { }

        // Common methods for all agents
        public override void startNewGame(object data) { }
        public override void newGameRequest(object data) { }
        public override void dataRequest(object data) { }
        public override void changeRequest(object data) { }
        public override void statusRequest(object data) { }        // noun ... ehh?

        public override void joinGame(object data) { }
        public override void requestData(object data) { }        // verb
        public override void receiveTick(object data) { }
        public override void getEaten(object data) { }
        public override void getDestroyed(object data) { }
        public override void heal(object data) { }
        public override void sendData(object data) { }
        public override void phoneHome(object data) { }            // ask for help from any student

        // From IObservable
        public override IDisposable Subscribe(IObserver<object> observer)
        {
            return null;
        }
        public override void Unsubscribe(IObserver<object> observer) { }
    }
}
