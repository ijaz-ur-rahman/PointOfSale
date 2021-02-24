using PointOfSale.DataService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.IServices
{
    public interface ILookupService
    {
        Task<ServiceResponse<object>> RolesDrp(object SelectedValue);
        Task<ServiceResponse<object>> CategoriesDrp(object SelectedValue);
        Task<ServiceResponse<object>> UOMDrp(object SelectedValue);
        Task<ServiceResponse<object>> SaleOrderDrp(object SelectedValue);
        Task<ServiceResponse<object>> CustomerDrp(object SelectedValue);
        Task<ServiceResponse<object>> SupplierDrp(object SelectedValue);
        Task<ServiceResponse<object>> PurchaseOrderDrp(object SelectedValue);
        Task<ServiceResponse<object>> ItemsDrp(object SelectedValue);
    }
}
