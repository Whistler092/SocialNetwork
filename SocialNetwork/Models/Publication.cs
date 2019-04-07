using System;

namespace SocialNetwork.Models
{
    public class Publication
    {
        public int PublicationId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}