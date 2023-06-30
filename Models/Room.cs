using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class Room
{
    public string HotelId { get; set; }

    public string RoomId { get; set; }

    public string RoomName { get; set; }

    public string RoomInfo { get; set; }

    public string RoomPrice { get; set; }

    public string BedQuantity { get; set; }

    public string Wifi { get; set; }

    public string Window { get; set; }

    public string Smoking { get; set; }

    public string RoomImage { get; set; }

    public int RoomAvailable { get; set; }

    public virtual Hotel Hotel { get; set; }
}
