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

            RemoveDeletedItems(inventoryDTO);

            AddNewItems(inventoryDTO);

            AddNewEntries(inventory.Items, inventoryDTO);
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

                items.Add(new InventoryItem(item.InventoryId, new ECommerceDomain.InventoryManagement.Product.Product(item.Product.Product.SKU, item.Product.Description, item.Product.Category), item.UnitCost, itemEntries));
            }

            return items;
        }

        private List<InventoryItemEntry> ConvertInventoryItemEntries(IEnumerable<InventoryItemEntryDTO> itemEntryDTOs)
        {
            return itemEntryDTOs.Select(itemEntry => new InventoryItemEntry(itemEntry.DateOccurred, itemEntry.Type, itemEntry.Quantity)).ToList();
        }

        private void RemoveDeletedItems(InventoryDTO inventoryDTO)
        {
            var inventoryItemsToDelete = inventoryDTO.InventoryItems.Except(inventoryDTO.InventoryItems, new InventoryItemDTOComparer()).ToList();

            foreach (var itemToDelete in inventoryItemsToDelete)
            {
                inventoryDTO.InventoryItems.RemoveAll(item => item.InventoryId == itemToDelete.InventoryId && item.Product.Product.SKU == itemToDelete.Product.Product.SKU);
            }
        }

        private void AddNewItems(InventoryDTO inventoryDTO)
        {
            var inventoryItemsToAdd = inventoryDTO.InventoryItems.Except(inventoryDTO.InventoryItems, new InventoryItemDTOComparer()).ToList();

            foreach (var inventoryItem in inventoryItemsToAdd)
            {
                var storedDTO = inventoryDTO.InventoryItems.Find(d => d.InventoryId == inventoryItem.InventoryId && d.Product.Product.SKU == inventoryItem.Product.Product.SKU);

                if (storedDTO == null)
                {
                    storedDTO = new InventoryItemDTO();

                    inventoryDTO.InventoryItems.Add(storedDTO);
                }

                storedDTO.UnitCost = inventoryItem.UnitCost;
            }
        }

        private void AddNewEntries(IEnumerable<InventoryItem> items, InventoryDTO inventoryDTO)
        {
            foreach (var item in items)
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

        private readonly ECommerceContext _eCommerceContext;
    }

    internal class InventoryItemDTOComparer : IEqualityComparer<InventoryItemDTO>
    {
        public bool Equals(InventoryItemDTO x, InventoryItemDTO y)
        {
            if (ReferenceEquals(x, y))
                return true;

            return x != null && y != null && x.Product.Product.SKU == y.Product.Product.SKU && x.Product.InventoryId == y.Product.InventoryId;
        }

        public int GetHashCode(InventoryItemDTO obj)
        {
            return obj.Id.GetHashCode();
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
