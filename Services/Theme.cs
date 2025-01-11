namespace WebsitePsychologist.Services
{
    public class Theme
    {
        public string pathImage { get; set; } = "img/service.jpg";
        public string? text { get; set; }
        public string? theme { get; set; }

        public Theme(string theme, string text)
        {
            this.theme = theme;
            this.text = text;
        }

    }
}