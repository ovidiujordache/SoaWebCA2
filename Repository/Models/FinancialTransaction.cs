using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiCA2.Repository.Models;

[Table("FinancialTransaction")]
public partial class FinancialTransaction
{
    [Key]
    public int FinancialTransactionId { get; set; }

    public double FinancialTransactionAmount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FinancialTransactionDate { get; set; }

    public int UserId { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("FinancialTransactions")]
    public virtual HospitalityServiceProvider User { get; set; } = null!;
}
public partial class FinancialTransactionDto
{
    public double FinancialTransactionAmount { get; set; }

   
    public DateTime FinancialTransactionDate { get; set; }

}