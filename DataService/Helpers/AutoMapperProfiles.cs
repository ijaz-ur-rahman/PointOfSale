using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PointOfSale.DatabaseService;
using PointOfSale.DataService.ViewModels;

namespace PointOfSale.DataService.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //category
            CreateMap<Categories, CategoryForCreateVM>().ReverseMap();
            CreateMap<Categories, CategoryForUpdateVM>().ReverseMap();
            CreateMap<Categories, CategoryForListVM>().ReverseMap();
            CreateMap<Categories, CategoryForDetailsVM>().ReverseMap();
            //Item
            CreateMap<Items, ItemForCreateVM>().ReverseMap();
            CreateMap<Items, ItemForListVM>().ReverseMap();
            CreateMap<Items, ItemForUpdateVM>().ReverseMap();
            CreateMap<Items, ItemForDetailsVM>().ReverseMap();
            //Customer
            CreateMap<Customers, CustomerForCreateVM>().ReverseMap();
            CreateMap<Customers, CustomerForListVM>().ReverseMap();
            CreateMap<Customers, CustomerForUpdateVM>().ReverseMap();
            CreateMap<Customers, CustomerForDetailsVM>().ReverseMap();
            //Supplier
            CreateMap<Suppliers, SupplierForCreateVM>().ReverseMap();
            CreateMap<Suppliers, SupplierForListVM>().ReverseMap();
            CreateMap<Suppliers, SupplierForUpdateVM>().ReverseMap();
            CreateMap<Suppliers, SupplierForDetailsVM>().ReverseMap();
            //UOM
            CreateMap<UnitOfMeasurement, UOMForCreateVM>().ReverseMap();
            CreateMap<UnitOfMeasurement, UOMForListVM>().ReverseMap();
            CreateMap<UnitOfMeasurement, UOMForUpdateVM>().ReverseMap();
            CreateMap<UnitOfMeasurement, UOMForDetailVM>().ReverseMap();
            //Sale Order
            CreateMap<SaleOrders, SaleOrderForCreateVM>().ReverseMap();
            CreateMap<SaleOrders, SaleOrderForListVM>().ReverseMap();
            CreateMap<SaleOrders, SaleOrderForUpdateVM>().ReverseMap();
            //Sale Order Detail
            CreateMap<SaleOrderDetails, SaleOrderDetailForCreateVM>().ReverseMap();
            CreateMap<SaleOrderDetails, SaleOrderDetailForListVM>().ReverseMap();
            CreateMap<SaleOrderDetails, SaleOrderDetailForUpdateVM>().ReverseMap();
        }
    }
}
