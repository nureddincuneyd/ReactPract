namespace sampleApiBlog.Models
{
    public class Blogs:BaseEntity
    {
        public string BLGTITLE { get; set; }
        public string BLGCONTENT { get; set; }
        public string BLGTHUMB { get; set; }
        public long BLGUSRID { get; set; }

    }
}
