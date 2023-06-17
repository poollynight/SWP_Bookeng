using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class Hotel
{
    public string AccountId { get; set; }

    public string HotelId { get; set; }

    public string HotelName { get; set; }

    public string HotelAddress { get; set; }

    public string Province { get; set; }

    public string StartPrice { get; set; }  

    public string HotelInfo { get; set; }

    public string Avartar { get; set; }

    public virtual Accountss Account { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
