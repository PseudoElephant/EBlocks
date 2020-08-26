using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PEStack<T>
{
    List<T> stack = new List<T>();
    private int size = 0;

    /// <summary>
    /// removes and returns top item in stack
    /// </summary>
    /// <returns>Top item in stack</returns>
    public T Pop()
    {
        T item = stack[size - 1];
        stack.RemoveAt(size - 1);
        size--;
        return item;
    }

    /// <summary>
    /// Shows top item in stack
    /// </summary>
    /// <returns>Last item in stack</returns>
    public T Peek()
    {
        return stack[size-1];
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
}