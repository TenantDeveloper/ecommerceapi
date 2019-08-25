using AutoMapper;
using ecommerce_DAL;
using ecommerceServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecommerceServices.Helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Sp_GetProducts_Result, ProductDto>();

            CreateMap<ProductVm, Product>().ForMember(p => p.Category, opt => opt.Ignore())
                .ForMember(p =>p.Product_Images,opts => opts.Ignore());
            CreateMap<Product, ProductDto>();
           
           
        }
    }
}