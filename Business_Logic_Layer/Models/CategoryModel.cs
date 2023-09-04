using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
