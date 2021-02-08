﻿using PointOfSale.DataService.Helpers;
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
    }
}
