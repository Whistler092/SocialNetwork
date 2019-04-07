using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public string Names { get; set; }

        public string LastNames { get; set; }

        public string Photo { get; set; }

        public DateTime BirthDate { get; set; }

        public string Sex { get; set; }


        // Publications Relationship
        public ICollection<Publication> Publications { get; set; }
    }
}