using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.InventoryManagement.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.Inventory.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.InventoryManagement.Inventory.Inventory Get()
        {
            var items = GetAllInventoryItemDTOs();

            var inventoryItems = ConvertToInventoryItems(items);

            var inventory = new ECommerceDomain.InventoryManagement.Inventory.Inventory(inventoryItems);

            return inventory;
        }

        public void Save(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory)
        {
            RemoveDeletedItems(inventory);

            AddNewItems(inventory);

            UpdateItems(inventory.Items);
        }

        private List<InventoryItem> ConvertToInventoryItems(IQueryable<InventoryItemDTO> inventoryItemDTOs)
        {
            var items = new List<InventoryItem>();

            foreach (var item in inventoryItemDTOs)
            {
                var itemEntries = ConvertToInventoryItemEntries(item.Entries);

                items.Add(new InventoryItem(new ECommerceDomain.InventoryManagement.Product.Product(item.Product.Product.SKU, item.Product.Description, item.Product.Category), item.UnitCost, itemEntries));
            }

            return items;
        }

        private List<InventoryItemEntry> ConvertToInventoryItemEntries(List<InventoryItemEntryDTO> itemEntryDTOs)
        {
            return itemEntryDTOs.Select(itemEntry => new InventoryItemEntry(itemEntry.DateOccurred, itemEntry.Type, itemEntry.Quantity)).ToList();
        }

        private void RemoveDeletedItems(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory)
        {
            var itemDTOs = GetAllInventoryItemDTOs();

            var items = ConvertToInventoryItems(itemDTOs);
            var itemsToDelete = items.Except(inventory.Items, new InventoryItemComparer()).ToList();

            foreach (var itemToDelete in itemsToDelete)
            {
                var dtoToDelete = _eCommerceContext.InventoryItems.First(item => item.Product.Product.SKU == itemToDelete.SKU);
                _eCommerceContext.InventoryItems.Remove(dtoToDelete);
            }
        }

        private void AddNewItems(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory)
        {
            var itemsDTOs = GetAllInventoryItemDTOs();

            var inventoryItemDTOsToItems = ConvertToInventoryItems(itemsDTOs);
            var inventoryItemsToAdd = inventory.Items.Except(inventoryItemDTOsToItems, new InventoryItemComparer()).ToList();

            foreach (var inventoryItem in inventoryItemsToAdd)
            {
                var storedDTO = new InventoryItemDTO
                {
                    Id = _eCommerceContext.InventoryProducts.First(i => i.Product.SKU == inventoryItem.SKU).Id,
                    Entries = new List<InventoryItemEntryDTO>(),
                    UnitCost = inventoryItem.UnitCost
                };

                _eCommerceContext.InventoryItems.Add(storedDTO);
            }
        }

        private void UpdateItems(IReadOnlyList<InventoryItem> items)
        {
            var itemDTOs = GetAllInventoryItemDTOs();

            foreach (var item in items)
            {
                var itemDTO = itemDTOs.First(i => i.Product.Product.SKU == item.SKU);
                itemDTO.UnitCost = item.UnitCost;

                AddNewEntries(item);
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
            return _eCommerceContext.InventoryItems.Include(i => i.Entries).Include(i => i.Product).ThenInclude(p => p.Product);
        }

        private InventoryItemDTO GetInventoryItemDTOBySKU(string sku)
        {
            return GetAllInventoryItemDTOs().First(i => i.Product.Product.SKU == sku);
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
