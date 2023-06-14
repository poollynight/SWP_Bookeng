using System;
using System.Collections.Generic;

namespace SWP_template.Models;

public partial class InfoAccount
{
    public string AccountId { get; set; }

    public string Name { get; set; }

    public string Age { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Birthday { get; set; }

    public string Nation { get; set; }

    public string Gender { get; set; }

    public string Identitycard { get; set; }

    public virtual Accountss Account { get; set; }
}
