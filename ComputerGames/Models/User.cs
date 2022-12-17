using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public int UserGroup { get; set; }

    public string UserPassword { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual Usergroup UserGroupNavigation { get; set; } = null!;
}
