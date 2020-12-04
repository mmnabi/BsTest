using System;

namespace BsTest.BLL.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }
        public int? PostId { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedAtLocal { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
    }
}
