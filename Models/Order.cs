using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string RoomId { get; set; }

    public string RoomName { get; set; }

    public string AccountId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Nation { get; set; }

    public string RoomType { get; set; }

    public int RoomQualtity { get; set; }

    public int BedQualtity { get; set; }

    public int Adult { get; set; }

    public int Child { get; set; }

    public string PayMethod { get; set; }

    public decimal TotalPrice { get; set; }

    public string PaymentStatus { get; set; }

    

}
