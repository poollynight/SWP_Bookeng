using Microsoft.AspNetCore.Mvc;

namespace SWP_template.Models
{
    public class SubmitRoomModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public string QuatityRoom { get; set; }
        public string Bed { get; set; }
        public string Adults { get; set; }
        public string Childs { get; set; }
        public string PayMethod { get; set; }
    }

}