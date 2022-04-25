using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBetweenTrees : MonoBehaviour
{
    // Start is called before the first frame update
    
    public State statePlayer;
    private List<GameObject> listPositionToJump;
    //private KeyCode keyPress;
    private int indexIsStay;
    private Vector3 target;

    private bool spawned = false;
    private float decay;

    void Start()
    {
        listPositionToJump = new List<GameObject>();
        GameObject[] positionToJump = GameObject.FindGameObjectsWithTag("Respawn");
        foreach(var item in positionToJump)
        {
            listPositionToJump.Add(item);
        }
        Debug.Log("Size:" + listPositionToJump.Count);
        listPositionToJump.Sort((IComparer<GameObject>)new sort());

        
        indexIsStay = listPositionToJump.Count / 2;
        transform.position = new Vector3(listPositionToJump[indexIsStay].transform.position.x, 0 ,
            transform.position.z);
        target = transform.position;
        HandleSideStay();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), statePlayer.velocity * Time.deltaTime*3);

        if(transform.position.x != target.x)
        {
            statePlayer.isProcessing = true;
            return;
        }
        else
        {
            statePlayer.isProcessing = false;
            
        }
        Reset();
        if (Input.GetKeyDown(KeyCode.D) && !spawned)
        {
            
            if (indexIsStay + 1 < listPositionToJump.Count)
            {
                decay = 1f;
                target = new Vector3(listPositionToJump[++indexIsStay].transform.position.x, transform.position.y, transform.position.z);
                statePlayer.state = State.StatePlayer.Idle;
                HandleSideStay();
            }
                
        }


        if (Input.GetKeyDown(KeyCode.A) && !spawned)
        {
            decay = 1f;
            if (indexIsStay - 1 >= 0)
            {
                
                target = new Vector3(listPositionToJump[--indexIsStay].transform.position.x, transform.position.y, transform.position.z);
                statePlayer.state = State.StatePlayer.Idle;
                HandleSideStay();
            }
           
        }
    }
    private class sort : IComparer<GameObject>
    {
        int IComparer<GameObject>.Compare(GameObject _objA, GameObject _objB)
        {
            float t1 = _objA.transform.position.x;
            float t2 = _objB.transform.position.x;
            return t1.CompareTo(t2);
        }
    }
    private void HandleSideStay()
    {
        float temp = transform.localScale.x;
        if (listPositionToJump[indexIsStay].name.Equals("Left"))
        {
            
            if (temp < 0)
            {
                transform.localScale = new Vector3(temp, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-temp, transform.localScale.y, transform.localScale.z);
            }

        }
        else
        {
            
            if (temp < 0)
            {
                transform.localScale = new Vector3(-temp, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(temp, transform.localScale.y, transform.localScale.z);
            }
        }
    }
    private void Reset()
    {
        if (spawned && decay > 0)
        {
            decay -= Time.deltaTime;
        }
        if (decay < 0)
        {
            decay = 0;
            spawned = false;
        }
    }
}
