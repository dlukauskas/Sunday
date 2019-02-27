
using System;

namespace Sunday.Models.Details
{
    public class TaxDetailsModel : DetailsModelBase
    {
        public int MunicipalityId { get; set; }
        public int TaxPeriodId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public float Rate { get; set; }
    }
}
