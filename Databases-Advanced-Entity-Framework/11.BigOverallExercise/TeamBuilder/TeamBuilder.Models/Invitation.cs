﻿namespace TeamBuilder.Models
{
    public class Invitation
    {
        public Invitation()
        {
            IsActive = true;
        }
        public int Id { get; set; }

        public int InvitedUserId { get; set; }

        public int TeamId { get; set; }

        public bool  IsActive { get; set; }

        public virtual Team Team { get; set; }

        public virtual User InvitedUser { get; set; }
    }
}
