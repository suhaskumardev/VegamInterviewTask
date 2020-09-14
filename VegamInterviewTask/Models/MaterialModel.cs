using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VegamInterviewTask.Models
{
    public class MaterialModel
    {
        [Required]
        public string MaterialNo { get; set; }
        
        [StringLength(200)]
        public string MaterialDesc { get; set; }
        [Required]
        public int? ShelfLife { get; set; }
        [StringLength(10)]
        public string Duration { get; set; }
        [Required]
        public string Type { get; set; }
    }
}