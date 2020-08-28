using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEStack<T>
    where T : class
{
    List<T> stack = new List<T>();
    private int size = 0;

    /// <summary>
    /// removes and returns top item in stack
    /// </summary>
    /// <returns>Top item in stack</returns>
    public T Pop()
    {
        if (!IsEmpty())
        {
            T item = stack[size - 1];
            stack.RemoveAt(size - 1);
            size--;
            return item;
        }

        return null;
    }

    /// <summary>
    /// removes a specific amount of items
    /// </summary>
    /// <returns>Top item in stack</returns>
    public void Pop(int quantity)
    {
        while(size > 0 || quantity == 0)
        {
            Pop();
            quantity--;
        }
    }

    /// <summary>
    /// Shows top item in stack, if empty returns null
    /// </summary>
    /// <returns>Last item in stack</returns>
    public T Peek()
    {
        if (!IsEmpty())
        {
            return stack[size - 1];
        }

        return null;
    }

    /// <summary>
    /// Add an item to the top of the stack
    /// </summary>
    /// <param name="item">Item you want to add</param>
    public void Push(T item)
    {
        stack.Add(item);
        size++;
    }

    /// <summary>
    /// Add an item to the top of the stack
    /// </summary>
    /// <param name="item">Item you want to add</param>
    public void Push(T item, int quantity)
    {
        while (quantity>0)
        {
            quantity--;
            Push(item);
        }
    }

    /// <summary>
    /// Returns the size of the current stack
    /// </summary>
    /// <returns></returns>
    public int Size()
    {
        return size;
    }

    /// <summary>
    /// Removes all items in the stack
    /// </summary>
    public void Wipe()
    {
        stack = new List<T>();
    }

    /// <summary>
    /// Returns true if stack is empty
    /// </summary>
    /// <returns><see cref="bool"/></returns>
    public bool IsEmpty()
    {
        return (size == 0);
    }
}