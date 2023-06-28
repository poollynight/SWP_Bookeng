using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class Order
{
    public string RoomId { get; set; }

    public string RoomName { get; set; }

    public string AccountId { get; set; }

    public string CheckIn { get; set; }

    public string CheckOut { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Nation { get; set; }

    public string RoomType { get; set; }

    public int RoomQualtity { get; set; }

    public int BedQualtity { get; set; }

    public string PayMethod { get; set; }

    public virtual Accountss Account { get; set; }

    public virtual Room Room { get; set; }
}
