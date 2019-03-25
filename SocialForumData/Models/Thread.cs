using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialForumData.Models
{
    public class Thread
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int LikeCount { get; set; }
        [Required]
        public virtual User Creator { get; set; }

        public virtual IEnumerable<Comment> Comments{ get; set; }
    }
}
