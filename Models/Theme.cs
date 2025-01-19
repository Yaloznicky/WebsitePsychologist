using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebsitePsychologist.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? PathImage { get; set; }
        public string? ThemeName { get; set; }
        public string? Text { get; set; }
    }
}