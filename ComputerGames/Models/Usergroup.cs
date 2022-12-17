using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Usergroup
{
    public int UsergroupId { get; set; }

    public string UsergroupName { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
