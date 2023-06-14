using AracSatis.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace AracSatis.Models.ViewModels.Posts
{
    public class UpdatePostVM
    {
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "İlanınıza bir başlık verin.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Başlık en az 10, en fazla 30 karakter içermeli")]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "İlanınızın açıklamasını girin.")]
        [StringLength(5000, MinimumLength = 30, ErrorMessage = "Açıklama en az 30, en fazla 200 karakter içermeli")]
        public string Description { get; set; }

        [Range(10000, 999999999, ErrorMessage = "Fiyat bilgisi istenilen aralıkta değil")]
        public decimal Price { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Aracınızın markasını giriniz.")]
        public string Make { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Aracınızın modelini giriniz.")]
        public string Model { get; set; }

        [Range(1950, 2023, ErrorMessage = "Yıl bilgisi geçerli aralıkta değil")]
        public int Year { get; set; }

        [Range(0, 1000000, ErrorMessage = "Kilometre istenilen aralıkta değil")]
        public int Kilometer { get; set; }

        [Range(10, 1000, ErrorMessage = "Beygir istenilen aralıkta değil")]
        public int HorsePower { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Aracınızın bulunduğu ülkeyi giriniz.")]
        public string LocationCountry { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Aracınızın bulunduğu şehri giriniz.")]
        public string LocationCity { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Bir kategori seçin.")]
        public int CategoryId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Yakıt türünü seçin.")]
        public int FuelTypeId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Vites türünü seçin.")]
        public int TransmissionTypeId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
        public List<FuelType> FuelTypes { get; set; } = new List<FuelType>();
        public List<TransmissionType> TransmissionTypes { get; set; } = new List<TransmissionType>();

    }
}
