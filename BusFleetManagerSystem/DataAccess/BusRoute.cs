//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusFleetManagerSystem.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class BusRoute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BusRoute()
        {
            this.Buses = new HashSet<Bus>();
            this.Drivers = new HashSet<Driver>();
        }
    
        public int BusRouteId { get; set; }
        public int RouteNumber { get; set; }
        public string StartpointName { get; set; }
        public string EndpointName { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public System.TimeSpan EndTime { get; set; }
        public int MovementInterval { get; set; }
        public int RouteLength { get; set; }
        public int PointOfDeparture_DeparturePointId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bus> Buses { get; set; }
        public virtual DeparturePoint DeparturePoint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}
