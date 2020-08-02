using MediatR;
using Shopy.Application.Models;
using Shopy.Common.Interfaces;
using System;

namespace Shopy.Application.Products.List
{
    public class ListProductsQuery : IRequest<IPagedList<ProductResponse>>
    {
        public string[] Sizes { get; set; }

        public string[] Brands { get; set; }

        public Guid? CategoryExternalId { get; set; }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public decimal? MaxPrice { get; set; }

        public decimal? MinPrice { get; set; }
    }
}