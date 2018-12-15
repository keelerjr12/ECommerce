using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.Inventory.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Inventory.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.Inventory.Inventory.Inventory Get()
        {
            var items = GetAllInventoryItemDTOs();

            var inventoryItems = ConvertToInventoryItems(items);

            var inventory = new ECommerceDomain.Inventory.Inventory.Inventory(inventoryItems);

            return inventory;
        }

        public void Save(ECommerceDomain.Inventory.Inventory.Inventory inventory)
        {
            RemoveDeletedItems(inventory);

            AddOrUpdateItems(inventory);
        }

        private List<InventoryItem> ConvertToInventoryItems(IQueryable<InventoryItemDTO> inventoryItemDTOs)
        {
            var items = new List<InventoryItem>();

            foreach (var item in inventoryItemDTOs)
            {
                var itemEntries = ConvertToInventoryItemEntries(item.Entries);

                items.Add(new InventoryItem(item.Product.SKU, item.Product.Description, item.Product.ProductCategory.Name, item.UnitCost, itemEntries));
            }

            return items;
        }

        private List<InventoryItemEntry> ConvertToInventoryItemEntries(List<InventoryItemEntryDTO> itemEntryDTOs)
        {
            return itemEntryDTOs.Select(itemEntry => new InventoryItemEntry(itemEntry.DateOccurred, itemEntry.Type, itemEntry.Quantity)).ToList();
        }

        private void RemoveDeletedItems(ECommerceDomain.Inventory.Inventory.Inventory inventory)
        {
            var itemDTOs = GetAllInventoryItemDTOs();

            var items = ConvertToInventoryItems(itemDTOs);
            var itemsToDelete = items.Except(inventory.Items, new InventoryItemComparer()).ToList();

            foreach (var itemToDelete in itemsToDelete)
            {
                var dtoToDelete = _eCommerceContext.InventoryItems.First(item => item.Product.SKU == itemToDelete.SKU);
                _eCommerceContext.InventoryItems.Remove(dtoToDelete);
            }
        }

        private void AddOrUpdateItems(ECommerceDomain.Inventory.Inventory.Inventory inventory)
        {
            var itemsDTOs = GetAllInventoryItemDTOs();

            foreach (var item in inventory.Items)
            {
                if (itemsDTOs.Any(i => i.Product.SKU == item.SKU))
                {
                    //update
                    var itemDTO = itemsDTOs.First(i => i.Product.SKU == item.SKU);
                    itemDTO.Description = item.Description;
                    itemDTO.Category = item.Category;
                    itemDTO.UnitCost = item.UnitCost;

                    AddNewEntries(item);
                }
                else
                {
                    var product = _eCommerceContext.Products.Include(p => p.ProductCategory).First(i => i.SKU == item.SKU);
                    //add
                    var storedDTO = new InventoryItemDTO
                    {
                        Id = product.Id,
                        Description = item.Description,
                        Category = product.ProductCategory.Name,
                        Entries = new List<InventoryItemEntryDTO>(),
                        UnitCost = item.UnitCost
                    };

                    _eCommerceContext.InventoryItems.Add(storedDTO);
                }
            }
        }

        private void AddNewEntries(InventoryItem item)
        {
            if (item.Entries.Count == 0)
                return;

            var itemDTO = GetInventoryItemDTOBySKU(item.SKU);
            var entriesToAdd = GetInventoryItemEntriesToAdd(item, itemDTO);

            foreach (var entry in entriesToAdd)
            {
                var dtoEntry = new InventoryItemEntryDTO
                {
                    InventoryItemId = itemDTO.Id,
                    DateOccurred = entry.DateOccurred,
                    Quantity = entry.Quantity,
                    Type = entry.Type
                };

                itemDTO.Entries.Add(dtoEntry);
            }
        }

        private IEnumerable<InventoryItemEntry> GetInventoryItemEntriesToAdd(InventoryItem item, InventoryItemDTO itemDTO)
        {
            var dtoEntryCount = itemDTO.Entries.Count;

            return item.Entries.Skip(dtoEntryCount);
        }

        private IQueryable<InventoryItemDTO> GetAllInventoryItemDTOs()
        {
            return _eCommerceContext.InventoryItems.Include(i => i.Entries).Include(i => i.Product).ThenInclude(p => p.ProductCategory);
        }

        private InventoryItemDTO GetInventoryItemDTOBySKU(string sku)
        {
            return GetAllInventoryItemDTOs().First(i => i.Product.SKU == sku);
        }

        private readonly ECommerceContext _eCommerceContext;
    }

    internal class InventoryItemComparer : IEqualityComparer<InventoryItem>
    {
        public bool Equals(InventoryItem x, InventoryItem y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.SKU == y.SKU;
        }

        public int GetHashCode(InventoryItem obj)
        {
            return obj.SKU.GetHashCode();
        }
    }
}
