using Data_Access_Layer.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class ChapterModel
    {
        public Guid ChapterId { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public Guid? StoryId { get; set; }
    }
}
