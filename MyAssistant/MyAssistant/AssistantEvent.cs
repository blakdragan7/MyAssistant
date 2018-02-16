using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAssistant
{
    class AssistantEvent
    {
        public EventType eventType { get; set; }
        public string eventDescription {
            get { return DescriptionForEventType(eventType); }
        }

        private AssistantEvent()
        {
            eventType = EventType.UnkownEvent;
        }

        public AssistantEvent(EventType eventType)
        {
            this.eventType = eventType;
        }

        public void PushEventNow()
        {
            switch(eventType)
            {
                case EventType.CallEvent:
                    {

                    }
                    break;
                case EventType.NotificationEvent:
                    {

                    }
                    break;
                case EventType.UnkownEvent:
                default:
                    throw new InvalidOperationException("Can Not Push Event With Unkown Event Type !");
                
                
            }
        }

        private static string DescriptionForEventType(EventType type)
        {
            switch(type)
            {
                case EventType.CallEvent:
                    return "Event used for a reminder to call someone. Links to a contact to call";
                case EventType.NotificationEvent:
                    return "Event used purely for reminders, like a notification.";
                case EventType.UnkownEvent:
                default:
                    return "Unkown or Invalid Event.";
            }
        }

        public static AssistantEvent Parse(string parseString)
        {
            if(String.IsNullOrEmpty(parseString))
            {
                throw new ArgumentNullException("argument @parseString can not be null !");
            }

            EventType _eventType = EventType.UnkownEvent;

            if(parseString.Equals("CallEvent"))
            {
                _eventType = EventType.CallEvent;
            }
            else if (parseString.Equals("NotificationEvent"))
            {
                _eventType = EventType.NotificationEvent;
            }
            else
            {
                throw new ArgumentException(parseString + " is not a known event type !");
            }

            return new AssistantEvent(_eventType);
        }

        public override string ToString()
        {
            return eventType.ToString();
        }

        public enum EventType
        {
            CallEvent, // Event that calls someone automatically from your contacts
            NotificationEvent, // Event that only sends a notification to notify 
            UnkownEvent
        }
    }
}
