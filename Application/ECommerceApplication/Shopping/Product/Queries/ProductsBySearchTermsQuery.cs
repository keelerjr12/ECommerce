﻿using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ECommerceData;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApplication.Shopping.Product.Queries
{
    public class ProductsBySearchTermsQuery
    {
        public class Request : IRequest<Result>
        {
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var productsToReturn = new List<ProductDTO>();

                if (!string.IsNullOrEmpty(request.Name))
                {
                    var normalizedName = Normalize(request.Name);
                    var nameSplitByToken = normalizedName.Split();
                    var productDB = _db.Products.Where(p => nameSplitByToken.Intersect(Normalize(p.Name).Split()).Any());

                    foreach (var dto in productDB)
                    {
                        var product = new ProductDTO(dto.SKU, dto.Name, dto.Description, dto.Price, dto.ImageFileName, dto.Status);
                        productsToReturn.Add(product);
                    }
                }

                if (!string.IsNullOrEmpty(request.Category))
                {
                    var normalizedCategory = Normalize(request.Category);
                    var categorySplitByToken = normalizedCategory.Split();
                    var productDB = _db.Products.Include(p => p.ProductCategory).Where(p => categorySplitByToken.Intersect(Normalize(p.ProductCategory.Name).Split()).Any());

                    foreach (var dto in productDB)
                    {
                        var product = new ProductDTO(dto.SKU, dto.Name, dto.Description, dto.Price, dto.ImageFileName, dto.Status);
                        productsToReturn.Add(product);
                    }
                }

                if (!string.IsNullOrEmpty(request.Description))
                {
                    var normalizedDescription = Normalize(request.Description);
                    var descriptionSplitByToken = normalizedDescription.Split();
                    var productDB = _db.Products.Where(p => descriptionSplitByToken.Intersect(Normalize(p.Description).Split()).Any());

                    foreach (var dto in productDB)
                    {
                        var product = new ProductDTO(dto.SKU, dto.Name, dto.Description, dto.Price, dto.ImageFileName, dto.Status);
                        productsToReturn.Add(product);
                    }
                }

                var result = new Result
                {
                    Products = productsToReturn
                };

                return result;
            }

            private string Normalize(string input)
            {
                return new string(input.ToLowerInvariant().Where(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)).Select(c => c).ToArray());
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public List<ProductDTO> Products { get; set; }
        }
    }
}
