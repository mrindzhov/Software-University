using WeddingsPlanner.Models.Enums;

namespace ImportJSON.Dtos
{
    class GuestDto
    {
        public string Name { get; set; }
        public bool RSVP { get; set; }
        public Family Family { get; set; }
    }
}