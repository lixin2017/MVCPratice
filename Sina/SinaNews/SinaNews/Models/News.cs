using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SinaNews.Models
{
    public class News
    {
        [Key]
        public int NewsId { get; set; }
        public string PageUrl { get; set; }
        [Required]
        public DateTime time { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public string author { get; set; }
    }
}