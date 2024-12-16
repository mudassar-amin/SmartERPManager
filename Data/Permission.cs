﻿using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class Permission
{
    public int PermissionId { get; set; }

    public int RoleId { get; set; }

    public int ModuleId { get; set; }

    public bool? CanView { get; set; }

    public bool? CanEdit { get; set; }

    public virtual Module Module { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}