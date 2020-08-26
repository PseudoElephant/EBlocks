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
    /// Will place the specified item at the position specified
    /// </summary>
    /// <param name="x">x position</param>
    /// <param name="y">y position</param>
    public void PlaceItemAtMouse(float x, float y)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Will add specified item to the inventory
    /// </summary>
    /// <param name="item">Item to add</param>
    public void AddItemToInventory(BaseItem item)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Adds specified number of items to the inventory
    /// </summary>
    /// <param name="item"></param>
    /// <param name="quantity"></param>
    public void AddItemsToInventory(BaseItem item, int quantity)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Removes item from inventory in the given slot
    /// </summary>
    /// <param name="inventorySlot"></param>
    public void RemoveItemFromInventoryInSlot(int inventorySlot)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Removes specified number of items from slot
    /// </summary>
    /// <param name="inventorySlot">Inventory slot</param>
    /// <param name="quantity">Number of items to remove</param>
    public void RemoveItemsFromInventoryInSlot(int inventorySlot, int quantity)
    {
        throw new System.NotImplementedException();
    }


    /// <summary>
    /// Removes item from the currently selected slot
    /// </summary>
    public void RemoveItemFromInventory()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Removes specified number of items from currently selected slot
    /// </summary>
    /// <param name="quantity">Number of items to remove</param>
    public void RemoveItemsFromInventory(int quantity)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns if the inventory slots are full
    /// </summary>
    /// <returns></returns>
    public bool IsFull()
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns the number of held items in the specified slot
    /// </summary>
    /// <param name="inventorySlot"></param>
    /// <returns></returns>
    public int NumberOfItemsInSlot(int inventorySlot)
    {
        throw new System.NotImplementedException();
    }
    #endregion
}