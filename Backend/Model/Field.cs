namespace Backend.Model
{
    public class Field
    {
        public Guid FieldId { get; set; }
        public string Type { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }
        public Guid RecipientId {  get; set; }
        public Recipient Recipient { get; set; }
        public Guid DocumentId {  get; set; }
        public Document Document { get; set; }
    }
}
