using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class AccountRole
{
    public string Role { get; set; }

    public string RoleId { get; set; }

    public virtual ICollection<Accountss> Accountsses { get; set; } = new List<Accountss>();
}
