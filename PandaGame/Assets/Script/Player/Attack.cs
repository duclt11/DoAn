using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public State statePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (statePlayer.state != State.StatePlayer.Attack && !collision.GetComponent<EnemyRunning>().isDead)
            {
                Debug.Log("Die");
                UnityEditor.EditorApplication.isPlaying = false;
            }
            else
            {
                if (collision.transform.localScale.x < -1)
                {
                    collision.transform.position = new Vector3(collision.transform.position.x - collision.transform.position.x / 10, collision.transform.position.y, collision.transform.position.z);
                }
                else
                    collision.transform.position = new Vector3(collision.transform.position.x + collision.transform.position.x / 10, collision.transform.position.y, collision.transform.position.z);
                collision.GetComponent<EnemyRunning>().isDead = true;
                collision.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
            }
        }
       
        
    }
}
