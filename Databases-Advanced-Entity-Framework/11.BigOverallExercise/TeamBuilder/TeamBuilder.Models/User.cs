namespace TeamBuilder.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.CreatedEvents = new HashSet<Event>();
            this.Teams = new HashSet<Team>();
            this.CreatedTeams = new HashSet<Team>();
            this.ReceivedInvitations = new HashSet<Invitation>();
        }

        public int Id { get; set; }
        //[MinLength(3)]
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        //[MinLength(6)]
        public string Password { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Event> CreatedEvents { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<Team> CreatedTeams { get; set; }

        public ICollection<Invitation> ReceivedInvitations { get; set; }

    }
}
