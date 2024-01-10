using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiCA2.Repository.Models;

[Table("HSPAndRestaurant")]
public partial class HspandRestaurant
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RestaurantId { get; set; }

    [ForeignKey("RestaurantId")]
    [InverseProperty("HspandRestaurants")]
    public virtual Restaurant Restaurant { get; set; } = new Restaurant();

    [ForeignKey("UserId")]
    [InverseProperty("HspandRestaurants")]
    public virtual HospitalityServiceProvider User { get; set; } = new HospitalityServiceProvider();

}


/*** Hspandrestaurant . Hospitality Service Provider (Aka Waiter, Delivery, Driver and Workplace  Restaurant A , Restaurant B.
    One waiter can work in many restaurants 
One restaurant can have many stuff /Service Providers/ Waiters etc.
 ***/
public partial class HspandRestaurantDto
{
    public virtual Restaurant Restaurant { get; set; } 

    public virtual HospitalityServiceProvider User { get; set; }



}
