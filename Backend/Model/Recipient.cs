namespace Backend.Model
{
    public class Recipient
    {
        public Guid RecipientId { get; set; }
        public string Email {  get; set; }
        public Guid DocumentId {  get; set; }
        public Document Document { get; set; }
        public List<Field> Fields  { get; set; } = new List<Field>();

    }
}
