namespace MultiShop.Comment.Entitys
{
    public class Comment
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
