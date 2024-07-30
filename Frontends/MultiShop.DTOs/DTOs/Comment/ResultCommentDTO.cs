using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOs.DTOs.Comment
{
    public class ResultCommentDTO
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string CommentDetail { get; set; }
        public int Rating { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }
        public string ProductId { get; set; }
    }
}
