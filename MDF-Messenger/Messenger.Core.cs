using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDF_Messenger
{
    public class MessengerCore
    {
        public ICommunicator Communicator;

        public MessengerCore(ICommunicator communicator)
        {
            this.Communicator = communicator;
        }

        public void Send(ICommunicator communicator)
        {
            //Kontakt holen (public Key des Empfaengers)
            //Message zu Xml serialisieren
            //Xml verschluesseln
            //Verschluesseltes Xml verschicken

            throw new NotImplementedException();
        }

        public void Recieve(ICommunicator communicator)
        {
            //Nach neuen Nachrichten suchen
            //Nachrichten herunterladen
            //Nachrichten entschluesseln
            //Nachrichten zurückliefern

            throw new NotImplementedException();
        }
    }
}