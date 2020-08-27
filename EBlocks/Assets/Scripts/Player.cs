using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// Represents the player inventory, contains all data of placeable blocks and quantities.
    /// Check <see cref="Inventory"/>.
    /// </summary>
    Inventory inventory;

    /// <summary>
    /// Coooldown duration for Hop Move, and step duration for Normal Move
    /// </summary>
    public  float stepDuration = 0.25f;

    /// <summary>
    /// Wether the player is using hops or smooth movement
    /// </summary>
    public bool hopMove = false;

    /// <summary>
    /// Represent the coroutine that will be called on player movement
    /// </summary>
    private Coroutine playerMovement;

    /// <summary>
    /// Blue print for a Move function
    /// </summary>
    /// <param name="direction">Direction in which the player is moving</param>
    /// <returns></returns>
    private delegate IEnumerator Move(Vector3 direction);

    /// <summary>
    /// Contains the move method coroutine
    /// </summary>
    Move moveMethod;

    /// <summary>
    /// Grid reference
    /// </summary>
    public Grid grid;

    /// <summary>
    /// Max pushable blocks player can push at once
    /// </summary>
    public int maxPush;

    /// <summary>
    /// Checks if player can move and moves him, also pushes blocks
    /// </summary>
    /// <param name="direction">Direction to move to</param>
    private void MoveInDirection(Grid.Direction direction)
    {
        Vector3 posPlayer = transform.position;
        Container neighboringContainer = grid.GetNeighbors(posPlayer.x, posPlayer.y)[(int)direction];
        
        if(neighboringContainer != null) //Check that its not void
        {
            if(neighboringContainer.IsEmpty()) //Check that container is empty
            {
                MovePlayer(direction);
            } else //If container holds something:
            {
                if(neighboringContainer.blockHeld.isPushable) //Check if its pushable
                {
                    if(RecursiveCheck(neighboringContainer, direction))
                    {
                        MovePlayer(direction);
                    }
                } 
            }
        }
    }

    /// <summary>
    /// Recursivly searches for the next neighbor to see if the player can move. Also pushes objects if possible.
    /// </summary>
    /// <param name="container">Current container</param>
    /// <param name="direction">Direction in which to check</param>
    /// <returns></returns>
    private bool RecursiveCheck(Container container, Grid.Direction direction, int currentDepth = 0)
    {
        bool canMove = false;

        //Base Cases
        if (container == null || currentDepth > maxPush)
        {
            return false;
        }
        else if (container.IsEmpty())
        {
            return true;
        }
        else if (container.blockHeld.actsAsWall)
        {
            return false;
        }

        //Rest of code
        canMove = RecursiveCheck(container.GetNeighbor(direction), direction, currentDepth+1);
        
        if(canMove)
        {
            container.blockHeld.Move(direction);
            return canMove;
        } else
        {
            return false;
        }
    }

    public void MovePlayer(Grid.Direction direction)
    {
        switch (direction)
        {
            case Grid.Direction.UP:
                transform.Translate(Vector3.up);
                break;

            case Grid.Direction.RIGHT:
                transform.Translate(Vector3.right);
                break;

            case Grid.Direction.DOWN:
                transform.Translate(Vector3.down);
                break;

            case Grid.Direction.LEFT:
                transform.Translate(Vector3.left);
                break;
        }
    }

    private void Start() {
        //if (hopMove)
        //    moveMethod = HopMove;
        //else
        //    moveMethod = MovePlayer;
    }

    private void Update()
    {
        if (playerMovement == null)
        {
            if (Input.GetKeyDown(KeyCode.W))        //In general not a good idea to use Input.GetKey; use Input.GetButton instead
                //playerMovement = StartCoroutine(moveMethod(Vector3.up));
                MoveInDirection(Grid.Direction.UP);
            else if (Input.GetKeyDown(KeyCode.S))
                //playerMovement = StartCoroutine(moveMethod(Vector3.down));
                MoveInDirection(Grid.Direction.DOWN);
            else if (Input.GetKeyDown(KeyCode.D))
                //playerMovement = StartCoroutine(moveMethod(Vector3.right));
                MoveInDirection(Grid.Direction.RIGHT);
            else if (Input.GetKeyDown(KeyCode.A))
                //playerMovement = StartCoroutine(moveMethod(Vector3.left));
                MoveInDirection(Grid.Direction.LEFT);
        }
    }

    /// <summary>
    /// Moves the player and interpolates between his position and the next
    /// </summary>
    /// <param name="direction">Direction in which the player is moving</param>
    /// <returns><see cref="IEnumerator"/></returns>
    //private IEnumerator MovePlayer(Vector3 direction)
    //{
    //    Vector2 startPosition = transform.position;
    //    Vector2 destinationPosition = transform.position + direction;
    //    float t = 0.0f;

    //    while (t < 1.0f)
    //    {
    //        transform.position = Vector2.Lerp(startPosition, destinationPosition, t);
    //        t += Time.deltaTime / stepDuration;
    //        yield return new WaitForEndOfFrame();
    //    }

    //    transform.position = destinationPosition;

    //    playerMovement = null;
    //}

    /// <summary>
    /// Moves the player by teleporting to the next block and delaying 
    /// </summary>
    /// <param name="direction">Direction in which the player is moving</param>
    /// <returns></returns>
    private IEnumerator HopMove(Vector3 direction)
    {
 
            transform.position += direction; 
        
            yield return new WaitForSeconds(stepDuration);
    
        playerMovement = null;
    }


    /// <summary>
    /// Tries to place a <see cref="BaseBlock"/> at a x and y position.
    /// </summary>
    /// <param name="x">X Coordinate</param>
    /// <param name="y">Y Coordinate</param>
    /// <returns><see cref="bool"/></returns>
    public bool PlaceBlockAt(float x,float y)
    {
        throw new System.NotImplementedException();
    }     
   
    /// <summary>
    /// Tries to place a <see cref="BaseBlock"/> one block into the direction specified.
    /// </summary>
    /// <param name="direction">Direction in which the block will be placed.</param>
    /// <returns></returns>
    public bool PlaceBlockAt(Grid.Direction direction)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns boolean indicating if a block can be placed in position x,y
    /// </summary>
    /// <param name="x">Coordinate X</param>
    /// <param name="y">Coordinate Y</param>
    /// <returns><see cref="bool"/></returns>
    public bool CanPlaceBlockAt(float x, float y)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Returns boolean indicating if a block can be placed in a given direction (<see cref="Grid.Direction")/>
    /// </summary>
    /// <param name="direction">Direction in wich the player is trying to place a block</param>
    /// <returns><see cref="bool"/></returns>
    public bool CanPlaceBlockAt(Grid.Direction direction)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Player tries picks up a block and stores it in its inventory.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool PickUpBlockAt(float x,float y)
    {
        throw new System.NotImplementedException();
    }


    /// <summary>
    /// Player tries to pick up a block in the direction specified in respect to the player (1 unit)
    /// </summary>
    /// <param name="direction">Direction specified by the player</param>
    /// <returns><see cref="bool"/></returns>
    public bool PickUpBlockAt(Grid.Direction direction)
    {
        throw new System.NotImplementedException();
    }
}
