using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSG.DAL.Entities.Reference;
namespace WSG.DAL.Interfaces
{
    public interface IAirportRepository: IDisposable
    {
        IEnumerable<Airport> GetAirports();
        Airport GetAirport(Guid id);
        void CreateAirport(Airport airport);
        void UpdateAirport(Airport);
        void DeleteAirport(Guid id);
        void Save();
    }
}
