using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap_Infotech_Task.Models
{
    public class CategoryMaster
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Product { get; set; }

        public int ProductId { get; set; }


    }
    public class Category
    {
        [Required]
        public string CategoryName { get; set; }
    }
}