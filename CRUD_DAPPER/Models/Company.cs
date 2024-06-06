using System.ComponentModel.DataAnnotations;
namespace CRUD_DAPPER.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; }

        [Display(Name = "Company Address")]
        public string? CompanyAddress { get; set; }

        public string? Country { get; set; }

        [Display(Name = "Glassdoor Rating")]
        public int GlassdoorRating { get; set; }
    }
}
