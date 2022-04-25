using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            animation.SetBool("IsExplode", true);
            Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1.0f);
            Debug.Log("OK ban ei");
        }
    }
}
