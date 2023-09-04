using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    [Table("Comment")]
    public class CommentEntity
    {
        [Key]
        public Guid CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public Guid? StoryId { get; set; }
        [ForeignKey(nameof(StoryId))]
        public StoryEntity Story { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
    }
}
