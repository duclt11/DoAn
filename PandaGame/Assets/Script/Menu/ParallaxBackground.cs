using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    //public float velocity = 0;
    //private float width;
    //private BoxCollider2D boxCollider2D;
    //private Rigidbody2D rb;

    //void Start()
    //{

    //    boxCollider2D = GetComponent<BoxCollider2D>();
    //    rb = GetComponent<Rigidbody2D>();
    //    width = boxCollider2D.size.x;
    //    rb.velocity = new Vector2(-3f, 0);
    //}

    //private void FixedUpdate()
    //{


    //    //transform.position = new Vector3(transform.position.x + velocity*Time.deltaTime, transform.position.y, transform.position.z);

    //    if(transform.position.x < -width)
    //    {
    //        Reposition();
    //    }
    //}
    //private void Reposition()
    //{
    //    Vector2 vt = new Vector2(width * 2.0f, 0);
    //    transform.position = (Vector2)transform.position + vt;

    //}
   
    public float velocity;
    private Transform[] layers;
   
    //private int rightIndex;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        
        //rightIndex = layers.Length - 1;
        
    }



    
    private void ScrollRight()
    {
       for(int i=0; i<transform.childCount; i++)
       {
            layers[i].position = new Vector3(layers[i].position.x + velocity * Time.deltaTime, layers[i].position.y, layers[i].position.z);
            
            
       }

       for(int i=0; i<transform.childCount; i++)
        {
            float temp = layers[i].position.x - layers[i].GetComponent<SpriteRenderer>().size.x *layers[i].transform.localScale.x;
            Vector3 viewPos = camera.WorldToViewportPoint(layers[i].position);
            if (temp >= camera.transform.position.x + camera.orthographicSize)
            {
                
                if (i == transform.childCount - 1)
                {
                    layers[i].position = new Vector3(layers[i - 1].position.x - layers[i].GetComponent<SpriteRenderer>().size.x * layers[i].transform.localScale.x, layers[i].position.y, layers[i].position.z);
                }
                else
                {
                    layers[i].position = new Vector3(layers[i + 1].position.x - layers[i].GetComponent<SpriteRenderer>().size.x *layers[i].transform.localScale.x, layers[i].position.y, layers[i].position.z);
                }
            }
           
            Debug.Log(i + " " + temp);
        }
       //if()
       
    }
    private void Update()
    {
        ScrollRight();
    }

}

