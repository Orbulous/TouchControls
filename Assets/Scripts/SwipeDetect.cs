using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetect : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;

    public bool isSwiping;

    public Vector2 startPos;      // Pos where swipe starts.
    public Vector2 endPos;        // Pos where swipe ends.
    public Vector2 swipeVector;   // Vector from start to end.

    public float swipeMin;        // The minimum magnitude to be a swipe.
    public float moveForce;       // How  much force to move when swiped.



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
                isSwiping = true;
                startPos = touchPos;


            }
            else if(touch.phase== TouchPhase.Ended && isSwiping)
            {
                isSwiping = false;
                endPos = touchPos;
                Swipe();

            }
           

        }




    }
    public void Swipe()
    {
        swipeVector = endPos - startPos;

        if (swipeVector.magnitude >= swipeMin)
        {
            // Determine if the swipe was horizontal or vertical

            if (Mathf.Abs(swipeVector.x) > Mathf.Abs(swipeVector.y))
            {
                // means I am swiping Left or Right

                if (swipeVector.x> 0)
                {
                    rb.AddForce(Vector2.right * moveForce, ForceMode2D.Impulse);


                }
                else
                {
                    rb.AddForce(Vector2.left * moveForce, ForceMode2D.Impulse);


                }
            }
            else
            {
                //means I am swiping Up or Down
                if(swipeVector.y>0)
                {
                    rb.AddForce(Vector2.up * moveForce, ForceMode2D.Impulse);


                }
                else
                {
                    rb.AddForce(Vector2.down * moveForce, ForceMode2D.Impulse);
                }


            }


        }


    }



}
