using System;
using System.Collections.Generic;

namespace ComputerGames.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public string CommentContent { get; set; } = null!;

    public int CommentRating { get; set; }

    public int CommentGame { get; set; }

    public int CommentUser { get; set; }

    public virtual Game CommentGameNavigation { get; set; } = null!;

    public virtual User CommentUserNavigation { get; set; } = null!;
}
