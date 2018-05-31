namespace Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public enum ResourceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
    public class Resource
    {
        public Resource()
        {
            Licenses = new HashSet<License>();
        }
        //•	Resources: id, name, type of resource(video / presentation / document / other), URL
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public ResourceType Type { get; set; }

        [Required]
        public string URL { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }

    }
}
