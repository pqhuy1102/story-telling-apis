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
    public class StoryModel
    {
        public Guid StoryId { get; set; }
        public string StoryName { get; set; }
        public double StoryRating { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? UserId { get; set; }
        public virtual ICollection<ChapterModel>? Chapters { get; set; }
        public virtual ICollection<CommentModel>? Comments { get; set; }
    }
}
