using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nimap_Infotech_Task.Models
{
    public class ProductMaster
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        //public int CategoryId { get; set; }

        [Required]  
        public string CategoryName { get; set; }    
    }

   
}