﻿using System.ComponentModel.DataAnnotations;

namespace SistemUpravljanjaOdsustvaZaposlenih.Web.Models.TipOdsustva
{
    public class TipOdsustvaCreateVM
    {
        //Validation
        [Required]
        [Length(4,150, ErrorMessage = "You have violated the length requirements.")]
        public string Ime { get; set; }

        [Required]
        [Range(1,90, ErrorMessage = "Broj mora biti izmedju 1 i 90.")]
        [Display(Name="Maximum allocation of days")]
        public int BrojDana { get; set; }
    }
}