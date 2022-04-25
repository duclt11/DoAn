using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBetweenTrees : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    //private State statePlayer;
    private List<GameObject> listPositionToJump;
    private KeyCode keyPress;
    private int indexIsStay;
    private Vector3 target;
    void Start()
    {
        GameObject[] positionToJump = GameObject.FindGameObjectsWithTag("Respawn");
        foreach(var item in positionToJump)
        {
            listPositionToJump.Add(item);
        }
        listPositionToJump.Sort((IComparer<GameObject>)new sort());

        for(int i=0; i<listPositionToJump.Count; i++)
        {
            //Debug.Log("Toa do x:"+ i +" " + listPositionToJump[i].transform.position.x);
        }
        indexIsStay = listPositionToJump.Count / 2;
        transform.position = new Vector3(listPositionToJump[indexIsStay].transform.position.x, 0 ,
            transform.position.z);
        target = transform.position;
        HandleSideStay();
       // Debug.Log("Vi tri dang dung:" + indexIsStay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, transform.position.y, transform.position.z), 0.02f);
        if(transform.position.x != target.x)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            if (indexIsStay + 1 < listPositionToJump.Count)
            {
                transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
                //transform.position = new Vector3(listPositionToJump[++indexIsStay].transform.position.x , transform.position.y , transform.position.z);
                target = new Vector3(listPositionToJump[++indexIsStay].transform.position.x, transform.position.y, transform.position.z);
                
                HandleSideStay();
            }
            
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            
            if (indexIsStay - 1 >= 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
                target = new Vector3(listPositionToJump[--indexIsStay].transform.position.x, transform.position.y, transform.position.z);
                //transform.position = new Vector3(listPositionToJump[--indexIsStay].transform.position.x, transform.position.y, transform.position.z);
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
}
