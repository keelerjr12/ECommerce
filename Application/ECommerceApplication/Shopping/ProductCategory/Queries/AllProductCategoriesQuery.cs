using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ECommerceData;
using MediatR;

namespace ECommerceApplication.Shopping.ProductCategory.Queries
{
    public class AllProductCategoriesQuery
    {
        public class Request : IRequest<Result>
        {

        }

        public class Handler : IRequestHandler<Request, Result>
        {
            public Handler(ECommerceContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
            {
                var categoryDTOs = _db.ProductCategories;

                var categories = new List<ProductCategoryDTO>();
                foreach (var categoryDTO in categoryDTOs)
                {
                    var category = new ProductCategoryDTO(categoryDTO.Id, categoryDTO.Name);
                    categories.Add(category);
                }

                var result = new Result(categories);

                return result;
            }

            private readonly ECommerceContext _db;
        }

        public class Result
        {
            public List<ProductCategoryDTO> ProductCategories { get; }

            public Result(List<ProductCategoryDTO> categories)
            {
                ProductCategories = categories;
            }
        }
    }
}
