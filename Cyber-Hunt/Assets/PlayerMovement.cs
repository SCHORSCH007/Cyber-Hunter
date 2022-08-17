using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    public GameObject mapGreenPrefab;
    public GameObject mapRedPrefab;

    Vector2 movement;
    float pixelbreite = 1f;
    float renderDistance_y = 10f;
    float renderDistance_x = 10f;
    float lastPositionX;
    float lastPositionY;



    void Start()
    {
        Vector2 positionrb  = rb.position; //hier noch auf ganz zahlen runden habe aber kp wie das geht
        
        for (float i = -1* renderDistance_x; i < 1+ renderDistance_x; i++)
        {
            for (float  f = -1* renderDistance_y; f < 1+ renderDistance_y; f++)
            {
                randomEinfügen(i*pixelbreite, f*pixelbreite);
            }
        }
        positionrb.x = lastPositionX;
        positionrb.y = lastPositionY;
    }

    // Update is called once per frame
    void Update()
    {
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        // for (float i = lastPositionX - rb.position.x; i + 1 < 0; i++)
        //{
        //    randomEinfügen(, float yPlayerEntfernt)
        // }
        if (lastPositionX - rb.position.x < 0.5f *pixelbreite)
        {
            for (float f = -1 * renderDistance_y; f < 1 + renderDistance_y; f++)
            {
                randomEinfügen((lastPositionX + 0.5f + renderDistance_x) * pixelbreite, f * pixelbreite);
            }
            lastPositionX = lastPositionX + 0.5f;
        }
        if (lastPositionX - rb.position.x > 0.5f * pixelbreite)
        {
            for (float f = -1 * renderDistance_y; f < 1 + renderDistance_y; f++)
            {
                randomEinfügen((lastPositionX - 0.5f - renderDistance_x) * pixelbreite, f * pixelbreite);
            }
            lastPositionX = lastPositionX - 0.5f;
        }




    }

    private void randomEinfügen(float xPlayerEntfernt, float yPlayerEntfernt)
    {
        Quaternion q = new Quaternion();
        float rnd = Random.Range(0f, 100f);
        if (rnd > 50f)
        {
            Instantiate(mapGreenPrefab, rb.position + new Vector2(xPlayerEntfernt, yPlayerEntfernt), q);
        }
        else
        {
            Instantiate(mapRedPrefab, rb.position + new Vector2(xPlayerEntfernt, yPlayerEntfernt), q);
        }
    }

}
