using AutoMapper;
using AutoMapper.Configuration;
using Sunday.Api.Mapping.Profiles;

namespace Sunday.Api.Mapping
{
    public static class Initializer
    {
        public static void InitializeAutoMapper()
        {
            var cfg = new MapperConfigurationExpression();

            cfg.AddProfile(new ApiProfile());

            Mapper.Initialize(cfg);

            //TODO remove this on live
            Mapper.AssertConfigurationIsValid();
        }
    }
}