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
[Table("HospitalityServiceProvider")]
public partial class HospitalityServiceProvider
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    public int? Password { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<FinancialTransaction> FinancialTransactions { get; set; } = new List<FinancialTransaction>();

    [InverseProperty("User")]
    public virtual ICollection<HspandRestaurant> HspandRestaurants { get; set; } = new List<HspandRestaurant>();


}
public class HospitalityServiceProviderDto
{
    //DTO for this enitty
    public string FirstName { get; set; }
    public string LastName { get; set; }

    /*    public List<Restaurant> Restaurants { get; } = new();*/

    /*    public List<HSPAndRestaurant> HspAndRestaurants { get; } = new();*/
}
