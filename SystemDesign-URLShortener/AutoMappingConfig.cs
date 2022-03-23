using AutoMapper;
using URLShortener.Core.Commands;
using URLShortener.Core.Entities;
using URLShortener.Core.Results;

namespace SystemDesign_URLShortener
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<ShortenerCommand, URL>();

            CreateMap<URL, ShortenerResult>();
        }
    }
}
