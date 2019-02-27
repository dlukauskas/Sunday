using Sunday.Models.Listing.ListingItem;
using System.Collections.Generic;

namespace Sunday.Models.Listing
{
    public abstract class ListingModelBase<TListingItem>
        where TListingItem : ListingItemBase
    {
        public List<TListingItem> Items { get; set; } = new List<TListingItem>();
    }
}
