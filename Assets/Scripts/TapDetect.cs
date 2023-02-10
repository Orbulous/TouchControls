using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDetect : MonoBehaviour
{
    public BoxCollider2D boxCollider;





    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began && boxCollider.OverlapPoint(touchPos))
            {
                Destroy(gameObject);

            }
        }
    }
}
