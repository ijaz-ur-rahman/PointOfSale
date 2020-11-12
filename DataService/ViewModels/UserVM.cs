using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.ViewModels
{
    public class UserVM
    {
    }
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserForCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }        
        public int? RoleId { get; set; }
    }
  
    public class UserForUpdateVM
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public int? RoleId { get; set; }
    }
    public class UserForListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
