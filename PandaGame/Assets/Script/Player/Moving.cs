using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Moving : MonoBehaviour
{
    [SerializeField]
    public State statePlayer;
    private Vector2 screenBounds;
    public JoystickMovement joystick;
    private Rigidbody2D rigid;
    //public Joystick joystick;
    void Start()
    {
         screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
         rigid = GetComponent<Rigidbody2D>();
         
    }
    // public float velocity;
    // Update is called once per frame
   
    
    void Update()
    {
        if (!statePlayer.isProcessing)
        {
            if (Input.anyKey)
            {
                if(statePlayer.state != State.StatePlayer.Attack)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        //rigid.velocity = new Vector2(Time.deltaTime * statePlayer.velocity, transform.position.y);
                        transform.Translate(Vector3.up * Time.deltaTime * statePlayer.velocity);
                        statePlayer.state = State.StatePlayer.Move;
                        //MoveUp();

                    }

                }

                if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.K))
                {
                    //transform.Translate(Vector3.down * Time.deltaTime * statePlayer.velocity);
                    //animator.SetBool("IsMoving", true);
                    //MoveUp(false);
                    Attack();
                    //this.transform.Translate(Vector3.down * Time.deltaTime * statePlayer.velocity * 2);
                    statePlayer.state = State.StatePlayer.Attack;

                }


                //if (Input.GetKey(KeyCode.K))
                //{
                //    Attack();
                //}
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space))
                {
                    statePlayer.state = State.StatePlayer.Idle;
                }
            }
            else if (Input.touchCount >= 1)
            {
                if (joystick.joystickVec.y != 0)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * statePlayer.velocity);

                }
                Debug.Log("Process");
                if (joystick.joystickVec.x > -0.5f && joystick.joystickVec.x < 0.5f && joystick.joystickVec.y > 0 && joystick.joystickVec.y <= 1)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * statePlayer.velocity);

                    //MoveUp();
                }
                if (joystick.joystickVec.x > -0.5f && joystick.joystickVec.x < 0.5f && joystick.joystickVec.y >= -1 && joystick.joystickVec.y < 0)
                {
                    transform.Translate(Vector3.down * Time.deltaTime * statePlayer.velocity);

                    //MoveUp(false);
                }
                Debug.Log("Joystick X:" + joystick.joystickVec.x + " y: " + joystick.joystickVec.y);



            }
            else
            {
                statePlayer.state = State.StatePlayer.Idle;
            }
        }
       
        

    } 
    private void MoveUp(bool isUp = true)
    {
        if (!isUp)
        {
            transform.Translate(Vector3.down * Time.deltaTime * statePlayer.velocity);
            
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * statePlayer.velocity);
            if (transform.position.y <= -screenBounds.y)
            {

            }
            
        }
    }
    private void Attack()
    {
        this.transform.Translate(Vector3.down * Time.deltaTime * statePlayer.velocity * 2);
        
    }
    private void Jump()
    {

    }
}
