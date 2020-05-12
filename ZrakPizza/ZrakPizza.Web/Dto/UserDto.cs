using System.ComponentModel.DataAnnotations;

namespace ZrakPizza.Web.Dto
{
    public class UserDto
    {
        [Required]
        [StringLength(255, MinimumLength = 4)]
        public string UserName { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
