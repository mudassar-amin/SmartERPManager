using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class InventoryItem
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public int? ReorderLevel { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
}
