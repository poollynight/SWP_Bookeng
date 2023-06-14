using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class Order
{
    public string AccountId { get; set; }

    public string RoomId { get; set; }

    public string RoomName { get; set; }

    public string CheckIn { get; set; }

    public string CheckOut { get; set; }

    public int? NumberOrder { get; set; }

    public virtual Accountss Account { get; set; }

    public virtual Room Room { get; set; }
}
