using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERPSystem.Data;

namespace ERPSystem.Controllers
{
    public class PurchaseOrderDetailsController : Controller
    {
        private readonly ErpsystemContext _context;

        public PurchaseOrderDetailsController(ErpsystemContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderDetails
        public async Task<IActionResult> Index()
        {
            var erpsystemContext = _context.PurchaseOrderDetails.Include(p => p.Item).Include(p => p.PurchaseOrder);
            return View(await erpsystemContext.ToListAsync());
        }

        // GET: PurchaseOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderDetail = await _context.PurchaseOrderDetails
                .Include(p => p.Item)
                .Include(p => p.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.PurchaseOrderDetailId == id);
            if (purchaseOrderDetail == null)
            {
                return NotFound();
            }

            return View(purchaseOrderDetail);
        }

        // GET: PurchaseOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.InventoryItems, "ItemId", "ItemId");
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "PurchaseOrderId", "PurchaseOrderId");
            return View();
        }

        // POST: PurchaseOrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PurchaseOrderDetailId,PurchaseOrderId,ItemId,Quantity,Price")] PurchaseOrderDetail purchaseOrderDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.InventoryItems, "ItemId", "ItemId", purchaseOrderDetail.ItemId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "PurchaseOrderId", "PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);
            return View(purchaseOrderDetail);
        }

        // GET: PurchaseOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderDetail = await _context.PurchaseOrderDetails.FindAsync(id);
            if (purchaseOrderDetail == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.InventoryItems, "ItemId", "ItemId", purchaseOrderDetail.ItemId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "PurchaseOrderId", "PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);
            return View(purchaseOrderDetail);
        }

        // POST: PurchaseOrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaseOrderDetailId,PurchaseOrderId,ItemId,Quantity,Price")] PurchaseOrderDetail purchaseOrderDetail)
        {
            if (id != purchaseOrderDetail.PurchaseOrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderDetailExists(purchaseOrderDetail.PurchaseOrderDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.InventoryItems, "ItemId", "ItemId", purchaseOrderDetail.ItemId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "PurchaseOrderId", "PurchaseOrderId", purchaseOrderDetail.PurchaseOrderId);
            return View(purchaseOrderDetail);
        }

        // GET: PurchaseOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderDetail = await _context.PurchaseOrderDetails
                .Include(p => p.Item)
                .Include(p => p.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.PurchaseOrderDetailId == id);
            if (purchaseOrderDetail == null)
            {
                return NotFound();
            }

            return View(purchaseOrderDetail);
        }

        // POST: PurchaseOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrderDetail = await _context.PurchaseOrderDetails.FindAsync(id);
            if (purchaseOrderDetail != null)
            {
                _context.PurchaseOrderDetails.Remove(purchaseOrderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderDetailExists(int id)
        {
            return _context.PurchaseOrderDetails.Any(e => e.PurchaseOrderDetailId == id);
        }
    }
}
