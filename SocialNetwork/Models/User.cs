using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class User
    {

        public int UserId { get; set; }

        public bool Active { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }


        // Profile relationship
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }


        // User Friends Relationship
        public ICollection<User> Friends { get; set; }

    }
}
