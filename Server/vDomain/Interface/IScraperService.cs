using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vDomain.Entity;

namespace vDomain.Interface;

public interface IScraperService
{
    Task SaveScraperResults(List<EventConcert> events);
}