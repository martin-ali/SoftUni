using System.Linq;
using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // Import
            this.CreateMap<ImportUserDto, User>()
                .ReverseMap();

            this.CreateMap<ImportProductDto, Product>()
                .ReverseMap();

            this.CreateMap<ImportCategoryDto, Category>()
                .ReverseMap();

            this.CreateMap<ImportCategoryProductDto, CategoryProduct>()
                .ReverseMap();

            // Export
            this.CreateMap<Product, ExportProductDto>()
                .ForMember(ep => ep.Buyer, o => o.MapFrom(p => $"{p.Buyer.FirstName} {p.Buyer.LastName}"))
                .ReverseMap();

            this.CreateMap<User, ExportUserDto>()
                .ReverseMap();

            this.CreateMap<Category, ExportCategoryDto>()
                .ForMember(ec => ec.Count, o => o.MapFrom(p => p.CategoryProducts.Count))
                .ForMember(ec => ec.AveragePrice, o => o.MapFrom(p => p.CategoryProducts.Average(cp => cp.Product.Price)))
                .ForMember(ec => ec.TotalRevenue, o => o.MapFrom(p => p.CategoryProducts.Sum(cp => cp.Product.Price)));
        }
    }
}
