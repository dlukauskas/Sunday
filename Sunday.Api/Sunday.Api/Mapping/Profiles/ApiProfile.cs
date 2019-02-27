using AutoMapper;
using Sunday.Data.Entities;
using Sunday.Models.Details;
using Sunday.Models.Listing.ListingItem;

namespace Sunday.Api.Mapping.Profiles
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<TaxPeriod, TaxPeriodListingItem>();
            CreateMap<TaxPeriod, TaxPeriodDetailsModel>();
            CreateMap<TaxPeriodDetailsModel, TaxPeriod>()
                .ForMember(x => x.Taxes, opt => opt.Ignore());

            CreateMap<Tax, TaxListingItem>();
            CreateMap<Tax, TaxDetailsModel>();
            CreateMap<TaxDetailsModel, Tax>()
                .ForMember(x => x.Municipality, opt => opt.Ignore())
                .ForMember(x => x.TaxPeriod, opt => opt.Ignore())
                .ForMember(x => x.CreatedAtUtc, opt => opt.Ignore())
                .ForMember(x => x.UpdatedAtUtc, opt => opt.Ignore())
                .ForMember(x => x.DeletedAtUtc, opt => opt.Ignore());

            CreateMap<Municipality, MunicipalityListingItem>();
            CreateMap<Municipality, MunicipalityDetailsModel>();
            CreateMap<MunicipalityDetailsModel, Municipality>()
                .ForMember(x => x.Taxes, opt => opt.Ignore());
        }
    }
}