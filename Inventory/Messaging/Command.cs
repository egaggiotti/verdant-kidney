
using System;
namespace Inventory.Messaging
{
    public class Command : IMessage
    {
        public Guid InventoryItemId { get; set; }
        public string Name { get; set; }
        public int OriginalVersion { get; set; }
        public string NewName { get; set; }
        public int Count { get; set; }
    }

    public class DeactivateInventoryItem : Command
    {
        public DeactivateInventoryItem(Guid inventoryItemId, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            OriginalVersion = originalVersion;
        }
    }

    public class CreateInventoryItem : Command
    {
        public CreateInventoryItem(Guid inventoryItemId, string name)
        {
            InventoryItemId = inventoryItemId;
            Name = name;
        }
    }

    public class RenameInventoryItem : Command
    {
        public RenameInventoryItem(Guid inventoryItemId, string newName, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            NewName = newName;
            OriginalVersion = originalVersion;
        }
    }

    public class CheckInItemsToInventory : Command
    {
        public CheckInItemsToInventory(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }

    public class RemoveItemsFromInventory : Command
    {
        public RemoveItemsFromInventory(Guid inventoryItemId, int count, int originalVersion)
        {
            InventoryItemId = inventoryItemId;
            Count = count;
            OriginalVersion = originalVersion;
        }
    }

}
