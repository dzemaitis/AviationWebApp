using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AviationEducation.Models
{
    public partial class Question
    {
        public long Id { get; set; }
        //Validacija. Nauodojam DataAnnotations namespace.
        [Display(Name = "Question Text")]
        [StringLength(500, MinimumLength =3)]
        [Required]
        public string Question_Text { get; set; }
        [Required]
        [StringLength(500)]
        public string Option1 { get; set; }
        [Required]
        [StringLength(500)]
        public string Option2 { get; set; }
        [Required]
        [StringLength(500)]
        public string Option3 { get; set; }
        [Required]
        [StringLength(500)]
        public string Answer { get; set; }
        [Required]
        public string Explanation { get; set; }
        [Required]
        public string Module { get; set; }
        [Required]
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
