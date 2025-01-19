using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WebsitePsychologist.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Login { get; set; }
        public char? Gender { get; set; }
        public string? Password { get; set; }
        public string? AvatarImage { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = [];
    }
}
