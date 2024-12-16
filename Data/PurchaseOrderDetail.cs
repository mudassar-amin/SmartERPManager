using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class PurchaseOrderDetail
{
    public int PurchaseOrderDetailId { get; set; }

    public int PurchaseOrderId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual InventoryItem Item { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
