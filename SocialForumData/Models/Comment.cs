using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialForumData.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public virtual User Author{ get; set; }

        public virtual Thread Thread { get; set; }

    }
}
