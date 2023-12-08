namespace sampleApiBlog.Models
{
    public class BaseEntity
    {
        public long ID { get; set; }
        public DateTime CREATEDATE { get; set; }
        public bool ISACTIVE { get; set; }
    }
}
