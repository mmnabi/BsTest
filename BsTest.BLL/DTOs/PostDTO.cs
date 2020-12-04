using System;
using System.Collections.Generic;

namespace BsTest.BLL.DTOs
{
    public class PostDTO
    {
        public PostDTO()
        {
            Comments = new List<CommentDTO>();
        }

        public int PostId { get; set; }
        public string UserName { get; set; }
        public string PostContent { get; set; }
        public DateTime? CreatedAtLocal { get; set; }
        public int CommentCount { get; set; }
        public virtual IEnumerable<CommentDTO> Comments { get; set; }
    }
}
