using ApplicationLayer.DTO;
using ApplicationLayer.Iservices;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Irepository
{
    public class InvoiceRepository: IInvoicerepository
    {


        private readonly InvoiceDbContext _context;

        public InvoiceRepository(InvoiceDbContext context)
        {
            _context = context;
        }
        public async Task<InvoiceDto> CreateInvoiceAsync(InvoiceCreateDto dto, string createdBy = null)
        {

            try
            {

                if (dto.Items == null || !dto.Items.Any())
                    throw new System.ArgumentException("Invoice must contain at least one item.");

                var entity = new Invoice
                {
                    InvoiceNo = dto.InvoiceNo,
                    InvoiceDate = dto.InvoiceDate,
                    StoreId = dto.StoreId,
                    Total = dto.Total,
                    Taxes = dto.Taxes,
                    Net = dto.Net,
                    CreatedById = createdBy,
                    Items = dto.Items.Select(i => new InvoiceItem
                    {
                        ItemId = i.ItemId,
                        UnitId = i.UnitId,
                        Price = i.Price,
                        Qty = i.Qty,
                        Total = i.Total,       
                        Discount = i.Discount,
                        Net = i.Net            
                    }).ToList()
                };

                _context.Invoices.Add(entity);
                await _context.SaveChangesAsync();

                var result = new InvoiceDto
                {
                    InvoiceNo = entity.InvoiceNo,
                    InvoiceDate = entity.InvoiceDate,
                    StoreId = entity.StoreId,
                    Total = entity.Total,
                    Taxes = entity.Taxes,
                    Net = entity.Net,
                    Items = entity.Items.Select(ii => new InvoiceItemDto
                    {
                        ItemId = ii.ItemId,
                        UnitId = ii.UnitId,
                        Price = ii.Price,
                        Qty = ii.Qty,
                        Total = ii.Total,
                        Discount = ii.Discount,
                        Net = ii.Net
                    }).ToList()
                };

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var list = await _context.Invoices.Include(i => i.Items).ToListAsync();

            return list.Select(inv => new InvoiceDto
            {
                InvoiceNo = inv.InvoiceNo,
                InvoiceDate = inv.InvoiceDate,
                StoreId = inv.StoreId,
                Total = inv.Total,
                Taxes = inv.Taxes,
                Net = inv.Net,
                Items = inv.Items.Select(ii => new InvoiceItemDto
                {
                    ItemId = ii.ItemId,
                    UnitId = ii.UnitId,
                    Price = ii.Price,
                    Qty = ii.Qty,
                    Total = ii.Total,
                    Discount = ii.Discount,
                    Net = ii.Net
                }).ToList()
            });
        }

        public async Task<InvoiceDto> GetByIdAsync(int id)
        {
            var inv = await _context.Invoices
                          .Include(i => i.Items)
                          .FirstOrDefaultAsync(i => i.Id == id);

            if (inv == null) return null;

            return new InvoiceDto
            {
                InvoiceNo = inv.InvoiceNo,
                InvoiceDate = inv.InvoiceDate,
                StoreId = inv.StoreId,
                Total = inv.Total,
                Taxes = inv.Taxes,
                Net = inv.Net,
                Items = inv.Items.Select(ii => new InvoiceItemDto
                {
                    ItemId = ii.ItemId,
                    UnitId = ii.UnitId,
                    Price = ii.Price,
                    Qty = ii.Qty,
                    Total = ii.Total,
                    Discount = ii.Discount,
                    Net = ii.Net
                }).ToList()
            };
        }
    }
}
