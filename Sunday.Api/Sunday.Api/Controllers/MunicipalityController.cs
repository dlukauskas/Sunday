using Sunday.Api.Controllers.Base.Listing;
using Sunday.Data.Entities;
using Sunday.Data.Repositories;
using Sunday.Models.Details;
using Sunday.Models.Listing;
using Sunday.Models.Listing.ListingItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sunday.Api.Controllers
{
    public class MunicipalityController : ListingApiControllerBase<MunicipalityListingItem, MunicipalityListingModel, MunicipalityDetailsModel, Municipality, MunicipalityRepository>
    {
        public MunicipalityController() : base()
        {
        }
    }
}
