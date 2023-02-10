using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldDetect : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;

    public bool isHolding = false;
    public float jumpForce;
    public float holdTime = 0;
    public float holdLimit;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
       if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began && boxCollider.OverlapPoint(touchPos))
            {
                holdTime = 0;
                isHolding = true;


            }
            else if (touch.phase == TouchPhase.Stationary && isHolding)
            {
                holdTime += Time.deltaTime;


            }
            if (holdTime >= holdLimit)
            {
                holdTime = 0;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

        }


    }
}
