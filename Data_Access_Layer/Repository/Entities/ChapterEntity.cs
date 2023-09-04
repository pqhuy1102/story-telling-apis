using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Entities
{
    [Table("Chapter")]
    public class ChapterEntity
    {
        [Key]
        public Guid ChapterId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ChapterName { get; set; }
        [Required]
        public string Content { get; set; }
        public Guid? StoryId { get; set; }
        [ForeignKey(nameof(StoryId))]
        public StoryEntity Story { get; set; }

    }
}
