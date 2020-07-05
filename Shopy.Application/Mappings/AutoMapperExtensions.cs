using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Shopy.Common;

namespace Shopy.Application.Mappings
{
    public static class AutoMapperExtensions
    {
        public static TDestination MapTo<TDestination>(this object source) =>
            ServiceLocator
                .Provider
                .GetService<IMapper>()
                .Map<TDestination>(source);
    }
}
