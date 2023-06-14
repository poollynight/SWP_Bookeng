using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class Accountss
{
    public string AccountId { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual AccountRole RoleNavigation { get; set; }
}
