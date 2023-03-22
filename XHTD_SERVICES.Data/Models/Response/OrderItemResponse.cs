using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XHTD_SERVICES.Data.Models.Response
{
    public class OrderItemResponse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public Guid DistributorId { get; set; } = Guid.Empty;
        public string DistributorName { get; set; } = string.Empty;
        public string DistributorAccount { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public string ItemUnitName { get; set; } = string.Empty;
        public double? ItemPrice { get; set; }
        public double NumberOrder { get; set; }
        public double? NumberRelease { get; set; }
        public string VehicleId { get; set; } = string.Empty;
        public double VehicleEmptyWeight { get; set; }
        public double VehicleFullWeight { get; set; }
        public Guid? DriverId { get; set; }
        public string DriverAccount { get; set; } = string.Empty;
        public string DriverName { get; set; } = string.Empty;
        public DateTime? DriverAcceptDate { get; set; }
        public int Step { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string Note { get; set; } = string.Empty;
        public bool? IsFinished { get; set; }
        public bool? IsCanceled { get; set; }
        public bool? IsCanceledBySystem { get; set; }
        public int? Type { get; set; }
    }
}
