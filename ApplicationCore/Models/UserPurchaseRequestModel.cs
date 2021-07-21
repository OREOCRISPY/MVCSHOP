using System;
using System.ComponentModel.DataAnnotations;
namespace ApplicationCore.Models
{
    public class UserPurchaseRequestModel
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
