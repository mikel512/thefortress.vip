using System.Diagnostics.CodeAnalysis;
using vDomain.Entity;

namespace vApplication.Extensions;

public class EventConcertEqualityComparer : IEqualityComparer<EventConcert>
{
    public bool Equals(EventConcert? x, EventConcert? y)
    {
        if (x == null && x == null)
            return true;
        else if (x == null || y == null)
            return false;
        else if (x.EventName == y.EventName && x.EventDate == y.EventDate && x.VenueFk == y.VenueFk)
        {
            if (y.EventConcertId == 0)
            {
                y.EventConcertId = x.EventConcertId;
            }
            else
            {
                x.EventConcertId = y.EventConcertId;
            }
            return true;
        }
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
