using AutoMapper;
using Shopy.Common;

namespace Shopy.Application.Mappings
{
    public static class AutoMapperExtensions
    {
        public static TDestination MapTo<TDestination>(this object source) =>
            ServiceLocator
                .GetService<IMapper>()
                .Map<TDestination>(source);
    }
}
