using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
public  float stepDuration = 0.25f;
public bool hopMove = false;
private Coroutine playerMovement;

private delegate IEnumerator Move(Vector3 direction);
 Move moveMethod;
private void Start() {
    if (hopMove)
        moveMethod = HopMove;
    else
        moveMethod = MovePlayer;
}
private void Update()
{
    if (playerMovement == null)
    {
        if (Input.GetKey(KeyCode.W))        //In general not a good idea to use Input.GetKey; use Input.GetButton instead
            playerMovement = StartCoroutine(moveMethod(Vector3.up));
        else if (Input.GetKey(KeyCode.S))
            playerMovement = StartCoroutine(moveMethod(Vector3.down));
        else if (Input.GetKey(KeyCode.D))
            playerMovement = StartCoroutine(moveMethod(Vector3.right));
        else if (Input.GetKey(KeyCode.A))
            playerMovement = StartCoroutine(moveMethod(Vector3.left));
    }
}

    private IEnumerator MovePlayer(Vector3 direction)
    {
        Vector2 startPosition = transform.position;
        Vector2 destinationPosition = transform.position + direction;
        float t = 0.0f;

        while (t < 1.0f)
        {
            transform.position = Vector2.Lerp(startPosition, destinationPosition, t);
            t += Time.deltaTime / stepDuration;
            yield return new WaitForEndOfFrame();
        }

        transform.position = destinationPosition;

        playerMovement = null;
    }

    private IEnumerator HopMove(Vector3 direction)
    {
 
            transform.position += direction; 
        
            yield return new WaitForSeconds(stepDuration);
    
        playerMovement = null;
    }
}
