using Api.Models;
using System.Diagnostics.CodeAnalysis;

namespace Api.Extensions
{
    public class EventConcertEqualityComparer : IEqualityComparer<EventConcert>
    {
        public bool Equals(EventConcert? x, EventConcert? y)
        {
            if (x == null && x == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.EventName == y.EventName && x.EventDate == y.EventDate  && x.VenueFk == y.VenueFk)
                return true;
            else
                return false;
        }

        public int GetHashCode([DisallowNull] EventConcert obj)
        {
            string tempHash = obj.EventName + obj.EventDate.ToString() + obj.VenueFk;
            var hc = tempHash.GetHashCode();
            return hc;
        }
    }
}
