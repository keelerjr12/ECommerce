using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceDomain.InventoryManagement.Inventory;
using Microsoft.EntityFrameworkCore;

namespace ECommerceData.InventoryManagement.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        public InventoryRepository(ECommerceContext eCommerceContext)
        {
            _eCommerceContext = eCommerceContext;
        }

        public ECommerceDomain.InventoryManagement.Inventory.Inventory FindById(int id)
        {
            var inventoryDTO = GetInventoryDTOById(id);

            var inventoryItems = ConvertInventoryItems(inventoryDTO.InventoryItems);

            var inventory = new ECommerceDomain.InventoryManagement.Inventory.Inventory(inventoryDTO.Id, inventoryItems);

            return inventory;
        }

        public void Update(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory)
        {
            var inventoryDTO = GetInventoryDTOById(inventory.Id);

            RemoveDeletedItems(inventory, inventoryDTO);

            AddNewItems(inventory, inventoryDTO);

            AddNewEntries(inventory.Items, inventoryDTO);

            foreach (var item in inventory.Items)
            {
                var itemDTO = inventoryDTO.InventoryItems.First(i =>
                    i.InventoryId == inventory.Id && i.Product.Product.SKU == item.SKU);

                itemDTO.UnitCost = item.UnitCost;
            }
        }
        
        private InventoryDTO GetInventoryDTOById(int id)
        {
            return _eCommerceContext.Inventory.Where(i => i.Id == id).Include(i => i.InventoryItems).ThenInclude(i => i.Entries).Include(i => i.InventoryItems).ThenInclude(i => i.Product).ThenInclude(p => p.Product).FirstOrDefault();
        }

        private List<InventoryItem> ConvertInventoryItems(IEnumerable<InventoryItemDTO> inventoryItemDTOs)
        {
            var items = new List<InventoryItem>();

            foreach (var item in inventoryItemDTOs)
            {
                var itemEntries = ConvertInventoryItemEntries(item.Entries);

                items.Add(new InventoryItem(item.InventoryId, new ECommerceDomain.InventoryManagement.Product.Product(item.InventoryId, item.Product.Product.SKU, item.Product.Description, item.Product.Category), item.UnitCost, itemEntries));
            }

            return items;
        }
        
        private List<InventoryItemEntry> ConvertInventoryItemEntries(IEnumerable<InventoryItemEntryDTO> itemEntryDTOs)
        {
            return itemEntryDTOs.Select(itemEntry => new InventoryItemEntry(itemEntry.DateOccurred, itemEntry.Type, itemEntry.Quantity)).ToList();
        }
        
        private void RemoveDeletedItems(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory, InventoryDTO inventoryDTO)
        {
            var inventoryItemDTOsToItems = convertInventoryItemDTOsToItems(inventoryDTO.InventoryItems);
            var inventoryItemsToDelete = inventoryItemDTOsToItems.Except(inventory.Items, new InventoryItemComparer()).ToList();

            foreach (var itemToDelete in inventoryItemsToDelete)
            {
                inventoryDTO.InventoryItems.RemoveAll(item => item.InventoryId == itemToDelete.InventoryId && item.Product.Product.SKU == itemToDelete.SKU);
            }
        }
        
        private void AddNewItems(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory, InventoryDTO inventoryDTO)
        {
            var inventoryItemDTOsToItems = convertInventoryItemDTOsToItems(inventoryDTO.InventoryItems);
            var inventoryItemsToAdd = inventory.Items.Except(inventoryItemDTOsToItems, new InventoryItemComparer()).ToList();

            foreach (var inventoryItem in inventoryItemsToAdd)
            {
                var storedDTO = new InventoryItemDTO
                {
                    Id = _eCommerceContext.InventoryProducts.First(i => i.Product.SKU == inventoryItem.SKU && i.InventoryId == inventoryItem.InventoryId).Id,
                    Entries = new List<InventoryItemEntryDTO>(),
                    InventoryId = inventory.Id,
                    UnitCost = inventoryItem.UnitCost
                };

                inventoryDTO.InventoryItems.Add(storedDTO);
            }
        }
        
        private List<InventoryItem> convertInventoryItemDTOsToItems(IReadOnlyList<InventoryItemDTO> items)
        {
            var inventoryItems = new List<InventoryItem>();

            foreach (var item in items)
            {
                var productToAdd = new ECommerceDomain.InventoryManagement.Product.Product(item.InventoryId,
                    item.Product.Product.SKU, item.Product.Description, item.Product.Category);
                var itemToAdd = new InventoryItem(item.InventoryId, productToAdd, item.UnitCost, null);

                inventoryItems.Add(itemToAdd);
            }
            return inventoryItems;
        }
    
        private void AddNewEntries(IEnumerable<InventoryItem> items, InventoryDTO inventoryDTO)
        {
            foreach (var item in items)
            {
                if (item.Entries.Count != 0)
                {
                    var dtoEntryCount = inventoryDTO.InventoryItems.First(i => i.Product.Product.SKU == item.SKU).Entries.Count;

                    var entriesToAdd = item.Entries.Skip(dtoEntryCount);

                    foreach (var entry in entriesToAdd)
                    {
                        var dtoEntry = new InventoryItemEntryDTO()
                        {
                            DateOccurred = entry.DateOccured,
                            Quantity = entry.Quantity,
                            Type = entry.Type
                        };

                        var storedInventoryEntries = inventoryDTO.InventoryItems.First(i => i.InventoryId == item.InventoryId && i.Product.Product.SKU == item.SKU).Entries;
                        storedInventoryEntries.Add(dtoEntry);
                    }
                }
            }
        }

        private readonly ECommerceContext _eCommerceContext;
    }

    internal class InventoryItemComparer : IEqualityComparer<InventoryItem>
    {
        public bool Equals(InventoryItem x, InventoryItem y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.SKU == y.SKU && x.InventoryId == y.InventoryId;
        }

        public int GetHashCode(InventoryItem obj)
        {
            return obj.SKU.GetHashCode() ^ obj.InventoryId.GetHashCode();
        }
    }

    internal class InventoryItemEntryDTOComparer : IEqualityComparer<InventoryItemEntryDTO>
    {
        public bool Equals(InventoryItemEntryDTO x, InventoryItemEntryDTO y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null &&  x.Id == y.Id;
        }

        public int GetHashCode(InventoryItemEntryDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
