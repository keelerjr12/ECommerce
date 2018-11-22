using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Inventory.Inventory FindById(int id)
        {
            var inventoryDTO = _eCommerceContext.Inventory.Where(i => i.Id == id).Include(i => i.InventoryItems).FirstOrDefault();

            var inventoryItems = new List<InventoryItem>();

            foreach (var item in inventoryDTO.InventoryItems)
            {
                var product = new ECommerceDomain.Inventory.InventoryProduct(item.ProductSKU, item.Description, item.Category);
                inventoryItems.Add(new InventoryItem(item.Id, product, item.Stock, 10m));
            }

            var inventory = new ECommerceDomain.Inventory.Inventory(inventoryDTO.Id, inventoryItems);

            return inventory;
        }

        public void Update(ECommerceDomain.Inventory.Inventory inventory)
        {
            var inventoryItemDTOs = ToInventoryItemDTOList(inventory.Items);
            var storedInventoryDTO = _eCommerceContext.Inventory.First(i => i.Id == 1);

            var inventoryItemsToAdd = inventoryItemDTOs.Except(storedInventoryDTO.InventoryItems, new InventoryItemDTOComparer());
            var inventoryItemsToDelete = storedInventoryDTO.InventoryItems.Except(inventoryItemDTOs, new InventoryItemDTOComparer()).ToList();

            foreach (var itemToDelete in inventoryItemsToDelete)
            {
                storedInventoryDTO.InventoryItems.RemoveAll(item => item.ProductSKU == itemToDelete.ProductSKU);
            }

            foreach (var inventoryItem in inventoryItemsToAdd)
            {
                var storedDTO = storedInventoryDTO.InventoryItems.Find(d => d.ProductSKU == inventoryItem.ProductSKU);

                if (storedDTO == null)
                {
                    storedDTO = new InventoryItemDTO();

                    storedInventoryDTO.InventoryItems.Add(storedDTO);
                }

                storedDTO.Id = inventoryItem.Id;
                storedDTO.ProductSKU = inventoryItem.ProductSKU;
                storedDTO.Description = inventoryItem.Description;
                storedDTO.Category = inventoryItem.Category;
                storedDTO.Stock = inventoryItem.Stock;
                storedDTO.UnitCost = inventoryItem.UnitCost;
            }
        }

        private IList<InventoryItemDTO> ToInventoryItemDTOList(IReadOnlyList<InventoryItem> items)
        {
            return items.Select(item => new InventoryItemDTO
                {
                    Id = item.Id,
                    ProductSKU = item.Product.SKU,
                    Description = item.Product.Description,
                    Category = item.Product.Category,
                    Stock = item.Stock,
                    UnitCost = item.UnitCost
                })
                .ToList();
        }

        private readonly ECommerceContext _eCommerceContext;
    }

    internal class InventoryItemDTOComparer : IEqualityComparer<InventoryItemDTO>
    {
        public bool Equals(InventoryItemDTO x, InventoryItemDTO y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.Id == y.Id && x.InventoryId == y.InventoryId;
        }

        public int GetHashCode(InventoryItemDTO obj)
        {
            return obj.GetHashCode();
        }
    }
}
