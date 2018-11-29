CREATE TABLE [dbo].[InventoryItem]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NewId(),
    [UnitCost] MONEY NULL
)
