using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        public string Gender { get; set; }
        public string Pincode { get; set; }
        [Required(ErrorMessage ="Please Fill Correct Format of Email")]
        [EmailAddress]
        public string Email { get; set; }
        public bool IsActived { get; set; }
    }
}
