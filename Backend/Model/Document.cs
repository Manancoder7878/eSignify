namespace Backend.Model
{
    public class Document
    {
        public Guid DocumentId {  get; set; }
        public string Title { get; set; }
        public byte[] Documents { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime SignedDate { get; set; }    
        public string Status {  get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public List<Recipient> Recipients { get; set; }
        public List<Field> Fields { get; set; }
    }
}
