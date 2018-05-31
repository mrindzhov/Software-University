namespace ImportJSON.Dtos
{
    using System;
    using System.Collections.Generic;

    class WeddingDto
    {
        public string Bride { get; set; }
        public string Bridegroom { get; set; }
        public DateTime Date { get; set; }
        public string Agency { get; set; }
        public virtual ICollection<GuestDto> Guests { get; set; }
    }
}
