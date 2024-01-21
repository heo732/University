using System.Collections.Generic;

namespace Airport.Entities
{
    public class PlaneType : BaseEntity
    {
        public List<Plane> Planes { get; set; } = new List<Plane>();
    }
}