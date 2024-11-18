using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tittel er påkrevd")]
        [StringLength(100, ErrorMessage = "Tittelen kan ikke være lengre enn 100 tegn")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Forfatter er påkrevd.")]
        public string Author { get; set; }

        [Range(1910, 2024, ErrorMessage = "Året må være mellom 1910 og 2024")]
        public int Year { get; set; }
    }
}