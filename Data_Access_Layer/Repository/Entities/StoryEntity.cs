using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    [Table("Story")]
    public class StoryEntity
    {
        [Key]
        public Guid StoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string StoryName { get; set; }
        public double StoryRating { get; set; }
        public Guid? CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public CategoryEntity Category { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
        public virtual ICollection<ChapterEntity> Chapters { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }


    }
}
