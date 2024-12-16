using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string Message { get; set; } = null!;

    public int? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public bool? IsRead { get; set; }

    public virtual User? User { get; set; }
}
