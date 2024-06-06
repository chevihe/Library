namespace Library.Api.PostModel
{
    public class BookPostModel
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool Status { get; set; }
        public int BranchId { get; set; }
        public int PartnerId { get; set; }
    }
}
