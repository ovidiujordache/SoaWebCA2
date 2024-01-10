using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiCA2.Repository.Models;





/*** Hspandrestaurant . Hospitality Service Provider (Aka Waiter, Delivery, Driver and Workplace  Restaurant A , Restaurant B.
    One waiter can work in many restaurants 
One restaurant can have many stuff /Service Providers/ Waiters etc.
 ***/



[Table("Restaurant")]
public partial class Restaurant
{
    [Key]
    public int RestaurantId { get; set; }

    [StringLength(50)]
    public string RestaurantName { get; set; } = null!;

    [StringLength(50)]
    public string? RestaurantAddress { get; set; }

    [InverseProperty("Restaurant")]
    
    public virtual ICollection<HspandRestaurant> HspandRestaurants { get; set; } = new List<HspandRestaurant>();
}
public partial  class RestaurantDto
{
    public string RestaurantName { get; set; }
    public string RestaurantAddress { get; set; }
    /*        public List<HospitalityServiceProvider> HospitalityServiceProviders { get; } = new();*/

}