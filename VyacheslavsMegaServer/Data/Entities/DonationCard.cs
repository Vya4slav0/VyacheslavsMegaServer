﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Org.BouncyCastle.Asn1.X509;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using VyacheslavsMegaServer.Data.Entities.Base;

namespace VyacheslavsMegaServer.Data.Entities
{
    public class DonationCard : EntityBase
    {
        [Display(Name = "Название карты")]
        public string CardName { get; set; }

        [Display(Name = "Название банка")]
        public string BankName { get; set; }

        [Display(Name = "Номер карты")]
        [RegularExpression("^(?:\\d{4}[- ]?){3}\\d{4}|\\d{16,19}$")]
        public string CardNumber { get; set; }

        [NotMapped]
        [ValidateNever]
        public string CardNumderWhitespaces => Regex.Replace(Regex.Replace(CardNumber, @"\D", ""), @"(\d{4})(?=\d)", "$1 ");

        [NotMapped]
        [ValidateNever]
        public string CardNumderNormalized => CardNumber.Replace(" ", string.Empty);

        [Display(Name = "Имя владельца карты")]
        public string CardHolder { get; set; }

        [Display(Name = "Цвет правого верхнего угла")]
        public string ColorUpRight { get; set; }

        [Display(Name = "Цвет левого нижнего угла")]
        public string ColorDownLeft { get; set; }
    }
}
