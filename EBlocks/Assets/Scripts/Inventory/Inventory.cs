using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Attributes
    /// <summary>
    /// Size of the Inventory
    /// </summary>
    private const int SIZE = 10;

    /// <summary>
    /// Currently available slots in the inventory
    /// </summary>
    private int availableSlots = SIZE;

    /// <summary>
    /// Array of Stacks
    /// </summary>
    private PEStack<BaseItem>[] slots = new PEStack<BaseItem>[SIZE];

    /// <summary>
    /// Currently selected slot, from 0 to SIZE-1
    /// </summary>
    private int currentlySelected;
    #endregion

    #region Methods
    /// <summary>
    /// Returns true if succesfully added; Otherwise false.
    /// </summary>
    /// <param name="item">Item to add</param>
    public bool AddItemToInventory(BaseItem item)
    {
        return AddItemsToInventory(item, 1);
    }

    /// <summary>
    /// Adds given items to inventory. Returns true if succesfully added; Otherwise false.
    /// </summary>
    /// <param name="item">Item to add</param>
    /// <param name="quantity">Amount of items to add</param>
    /// <returns>Returns true if succesfully added; Otherwise false. </returns>
    public bool AddItemsToInventory(BaseItem item, int quantity)
    {
        int firstEmpty = -1;

        for (int i = 0; i < SIZE; i++)
        {
            if (slots[i].IsEmpty() && firstEmpty == -1)
            {
                firstEmpty = i;
            }

            if (slots[i]?.Peek().itemName == item.itemName)
            {
                slots[i].Push(item,quantity);
                return true;
            }
        }

        if (firstEmpty != -1)
        {
            slots[firstEmpty].Push(item,quantity);
            return true;
        }

        return false;
    }

    public bool AddItemToInventorySlot(int inventorySlot, BaseItem item)
    {
        return AddItemsToInventorySlot(inventorySlot, item, 1);
    }

    /// <summary>
    /// Adds specified items to given slot. 
    /// </summary>
    /// <param name="inventorySlot"></param>
    /// <param name="item"></param>
    /// <param name="quantity"></param>
    /// <returns>Returns true if succesfully added, otherwise false</returns>
    public bool AddItemsToInventorySlot(int inventorySlot, BaseItem item, int quantity)
    {
        inventorySlot = Mathf.Clamp(inventorySlot, 0, SIZE - 1);

        if (slots[inventorySlot]?.Peek().itemName == item.itemName || slots[inventorySlot].IsEmpty())
        {
            slots[inventorySlot].Push(item, quantity);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Removes item from inventory in the given slot
    /// </summary>
    /// <param name="inventorySlot"></param>
    public void RemoveItemFromInventorySlot(int inventorySlot)
    {
        inventorySlot = Mathf.Clamp(inventorySlot, 0, SIZE - 1);

        slots[inventorySlot].Pop();
    }

    /// <summary>
    /// Removes specified number of items from slot
    /// </summary>
    /// <param name="inventorySlot">Inventory slot</param>
    /// <param name="quantity">Number of items to remove</param>
    public void RemoveItemsFromInventorySlot(int inventorySlot, int quantity)
    {
        inventorySlot = Mathf.Clamp(inventorySlot, 0, SIZE - 1);

        slots[inventorySlot].Pop(quantity);
    }

    /// <summary>
    /// Removes item from the currently selected slot
    /// </summary>
    public void RemoveItemFromInventory()
    {
        slots[currentlySelected].Pop();
    }

    /// <summary>
    /// Removes specified number of items from currently selected slot
    /// </summary>
    /// <param name="quantity">Number of items to remove</param>
    public void RemoveItemsFromInventory(int quantity)
    {
        slots[currentlySelected].Pop(quantity);
    }

    /// <summary>
    /// Returns if the inventory is full
    /// </summary>
    /// <returns></returns>
    public bool IsFull()
    {
        foreach(PEStack<BaseItem> slot in slots)
        {
            if (slot.IsEmpty())
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Returns if true if given slot is empty; Otherwise false.
    /// </summary>
    /// <param name="slot">Slot to check</param>
    /// <returns>Returns <see cref="bool"/></returns>
    public bool IsSlotEmpty(int inventorySlot)
    {
        inventorySlot = Mathf.Clamp(inventorySlot, 0, SIZE - 1);

        return slots[inventorySlot].IsEmpty();
    }

    /// <summary>
    /// Returns the number of held items in the specified slot
    /// </summary>
    /// <param name="inventorySlot"></param>
    /// <returns></returns>
    public int NumberOfItemsInSlot(int inventorySlot)
    {
        inventorySlot = Mathf.Clamp(inventorySlot, 0, SIZE - 1);

        return slots[inventorySlot].Size();
    }
    #endregion
}