
using System;

namespace Sunday.Models.Listing.ListingItem
{
    public class TaxListingItem : ListingItemBase
    {
        public int MunicipalityId { get; set; }
        public int TaxPeriodId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public float Rate { get; set; }
    }
}
