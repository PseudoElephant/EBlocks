using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer spriteRenderer;
    public Sprite sprite;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
         if (Input.GetMouseButton(0)){
            spriteRenderer.sprite = sprite;
         }
      
    }
}
