using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BazaZaginionych.Models
{
    public class ZaginieniModel
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string Imie { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Nazwisko { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Opis { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Nazwa Zdjecia")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Dodaj Zdjecie")]
        public IFormFile imageFile { get; set; }
    }
}
