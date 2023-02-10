using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;
    public bool isDragging;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began && boxCollider.OverlapPoint(touchPos))
            {
                isDragging = true;

                rb.isKinematic = true;
                rb.velocity=Vector2.zero;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                gameObject.transform.position = touchPos;


            }
            else if(touch.phase == TouchPhase.Ended && isDragging)
            {
                isDragging = false;
                rb.isKinematic = false;
            }


        }
    }
}
