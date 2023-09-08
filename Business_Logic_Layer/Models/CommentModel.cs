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
    public class CommentModel
    {
        public Guid CommentId { get; set; }
        public string CommentText { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? StoryId { get; set; }
        public Guid? UserId { get; set; }
    }
}
