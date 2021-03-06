using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunning : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    public bool isDead;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -(screenBounds.y * 2))
        {
            Destroy(this.gameObject);
        }
        
        //transform.Translate(0, -speed * Time.deltaTime, 0);
        
    }
}
