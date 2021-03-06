﻿namespace FastFood.Web.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterEmployeeInputModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(15, 80)]
        public int Age { get; set; }

        [Required]
        public int PositionId { get; set; }

        [Required]
        public string PositionName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Address { get; set; }
    }
}
