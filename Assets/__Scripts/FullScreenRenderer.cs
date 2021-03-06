using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenRenderer : MonoBehaviour {

    private void Awake()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        //find the height 
        float cameraHeight = Camera.main.orthographicSize * 2;

        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);

        Vector2 spriteSize = renderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        //if height is greater than width
        if(cameraSize.x >= cameraSize.y)
        {
            scale *= cameraSize.x / spriteSize.x;            
        }
        else
        {
            scale *= cameraSize.y / spriteSize.y;
        }
        transform.localScale = scale;
    }
}
