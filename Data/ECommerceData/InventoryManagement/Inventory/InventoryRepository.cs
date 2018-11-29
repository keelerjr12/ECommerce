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
            var inventoryDTO = _eCommerceContext.Inventory.Where(i => i.Id == id).Include(i => i.InventoryItems).ThenInclude(i => i.Entries).FirstOrDefault();

            var inventoryItems = new List<InventoryItem>();

            foreach (var item in inventoryDTO.InventoryItems)
            {
                var itemEntries = new List<InventoryItemEntry>();

                foreach (var itemEntry in item.Entries)
                {
                    itemEntries.Add(new InventoryItemEntry(itemEntry.Id, itemEntry.SKU, itemEntry.DateOccurred, itemEntry.Type, itemEntry.Quantity));    
                }
                inventoryItems.Add(new InventoryItem(inventoryDTO.Id, new ECommerceDomain.InventoryManagement.Product.Product(item.SKU, item.Product.Description, item.Product.Category), item.UnitCost, itemEntries));
            }

            var inventory = new ECommerceDomain.InventoryManagement.Inventory.Inventory(inventoryDTO.Id, inventoryItems);

            return inventory;
        }

        public void Update(ECommerceDomain.InventoryManagement.Inventory.Inventory inventory)
        {
            var inventoryItemDTOs = ToInventoryItemDTOList(inventory.Items);
            var storedInventoryDTO = _eCommerceContext.Inventory.First(i => i.Id == 1);

            var inventoryItemsToAdd = inventoryItemDTOs.Except(storedInventoryDTO.InventoryItems, new InventoryItemDTOComparer()).ToList();
            var inventoryItemsToDelete = storedInventoryDTO.InventoryItems.Except(inventoryItemDTOs, new InventoryItemDTOComparer()).ToList();

            foreach (var itemToDelete in inventoryItemsToDelete)
            {
                storedInventoryDTO.InventoryItems.RemoveAll(item => item.SKU == itemToDelete.SKU);
            }

            foreach (var inventoryItem in inventoryItemsToAdd)
            {
                var storedDTO = storedInventoryDTO.InventoryItems.Find(d => d.SKU == inventoryItem.SKU);

                if (storedDTO == null)
                {
                    storedDTO = new InventoryItemDTO();

                    storedInventoryDTO.InventoryItems.Add(storedDTO);
                }

                storedDTO.SKU = inventoryItem.SKU;
                storedDTO.Entries = inventoryItem.Entries;
                storedDTO.UnitCost = inventoryItem.UnitCost;
            }

            foreach (var item in inventory.Items)
            {
                var itemEntryDTO = ToInventoryItemEntryDTOList(item.Entries);
                var storedInventoryEntries = storedInventoryDTO.InventoryItems
                    .First(i => i.InventoryId == item.InventoryId && i.SKU == item.SKU).Entries;

                var itemEntriesToAdd = itemEntryDTO.Except(storedInventoryEntries, new InventoryItemEntryDTOComparer()).ToList();

                foreach (var itemEntryToAdd in itemEntriesToAdd)
                {
                    storedInventoryEntries.Add(itemEntryToAdd);
                }
            }
        }

        private IList<InventoryItemDTO> ToInventoryItemDTOList(IReadOnlyList<InventoryItem> items)
        {
            return items.Select(item => new InventoryItemDTO
                {
                    InventoryId = item.InventoryId,
                    SKU = item.SKU,
                    Entries = item.Entries.Select(
                        entry => new InventoryItemEntryDTO()
                        {
                        Id = entry.Id,
                        SKU = entry.SKU,
                        DateOccurred =  entry.DateOccured,
                        Type = entry.Type,
                        Quantity = entry.Quantity
                        }).ToList(),
                    UnitCost = item.UnitCost
                })
                .ToList();
        }

        private IList<InventoryItemEntryDTO> ToInventoryItemEntryDTOList(IReadOnlyList<InventoryItemEntry> entries)
        {
            return entries.Select(item => new InventoryItemEntryDTO
                {
                    Id = item.Id,
                    SKU = item.SKU,
                    DateOccurred = item.DateOccured,
                    Type = item.Type,
                    Quantity = item.Quantity
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

            return x != null && y != null && x.SKU == y.SKU && x.InventoryId == y.InventoryId;
        }

        public int GetHashCode(InventoryItemDTO obj)
        {
            return obj.InventoryId.GetHashCode() ^ obj.SKU.GetHashCode();
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
