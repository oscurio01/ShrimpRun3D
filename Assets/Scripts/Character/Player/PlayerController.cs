using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PointerClass
{
    public GameObject pointer;
    public bool ocuped;
}

public class PlayerController : MonoBehaviour
{

    //public float leftRightSpeed;
    public static bool inmortal;


    public int level;

    [SerializeField] private float speed;
    [SerializeField] private float lateralSpeed;

    int totalShrimps;
    int force;

    float leftSide = -6f;
    float rightSide = 6f;

    float m_Input;
    Vector3 velocity;

    Rigidbody rb;

    [SerializeField] List<PointerClass> pointerClass = new List<PointerClass>();

    private void OnEnable()
    {
        OpenCheat.IncreaseShrimpsEvent += SetListAlly;
        OpenCheat.DecreaseShrimpsEvent += DecreaseShrimp;
    }

    private void OnDisable()
    {
        OpenCheat.IncreaseShrimpsEvent -= SetListAlly;
        OpenCheat.DecreaseShrimpsEvent -= DecreaseShrimp;
    }

    private void Awake()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Pointer"))
            {
                var p = new PointerClass();
                p.pointer = transform.GetChild(i).gameObject;
                p.ocuped = false;

                pointerClass.Add(p);
                
            }
            
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(InstructionsScript.begin == true && !GameOverMenu.gameOverIsON)
        {
            Move();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //for (int i = 0; i < pointerClass.Count; i++)
            //{
            //    Debug.Log("id: " + i + " Length " + pointerClass[i].ocuped);
            //}

            Debug.Log(" Subscribers: " + totalShrimps + " Force " + force );
        }

    }

    #region Move
    void Move()
    {
        m_Input = Input.GetAxisRaw("Horizontal");

        velocity = rb.velocity;

        if (m_Input < -0.01)
        {
            if(this.gameObject.transform.position.x > leftSide)
            {
                velocity = SetLateralMove(1);
            }
            else
            {
                velocity = SetVelocityForward();
            }
            
        }
        else if(m_Input > 0.01)
        {
            if(this.gameObject.transform.position.x < rightSide)
            {
                velocity = SetLateralMove(-1);
            }
            else
            {
                velocity = SetVelocityForward();
            }
            
        }
        else if(m_Input == 0)
        {
            velocity = SetVelocityForward();
        }

        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Time.deltaTime);
        rb.velocity = velocity;
    }

    Vector3 SetLateralMove(float leftOrRight)
    {
        Vector3 newVelocity = new Vector3(-1 * Time.deltaTime * lateralSpeed * leftOrRight, rb.velocity.y, rb.velocity.z);
        return newVelocity;
    }

    Vector3 SetVelocityForward()
    {
        Vector3 newVelocity =  new Vector3(0, rb.velocity.y, 1 * speed * Time.deltaTime);
        return newVelocity;
    }
    #endregion

    #region Shrimps
    public void SetListAlly(int ally)
    {
        totalShrimps += ally;

        SetPositionToAlly();

        if (totalShrimps % 20 == 1 && totalShrimps != 1)
        {
            Debug.Log(" Subscribers: " + totalShrimps);

            DisappearAllShrimps();

            force += 1;
        }
    }

    void SetPositionToAlly()
    {

        for (int i = 0; i < pointerClass.Count; i++)
        {

            if (pointerClass[i].ocuped == false)
            {
                pointerClass[i].pointer.SetActive(true);
                pointerClass[i].ocuped = true;

                break;
            }
        }
    }

    public void EraseShrimp(GameObject shrimpPointer)
    {
        totalShrimps -= 1;

        for (int i = 0; i < pointerClass.Count; i++)
        {

            if (pointerClass[i].pointer == shrimpPointer)
            {
                pointerClass[i].pointer.GetComponentInChildren<Animator>().SetBool("Disappear", true);
                pointerClass[i].ocuped = false;

                break;
            }
        }

    }


    // DebugMode

    public void DecreaseShrimp()
    {
        if(totalShrimps > 0)
        {
            totalShrimps -= 1;
        }


        for (int i = pointerClass.Count-1; i > -1; i--)
        {

            if (pointerClass[i].ocuped == true)
            {
                pointerClass[i].pointer.GetComponentInChildren<Animator>().SetBool("Disappear", true);
                pointerClass[i].ocuped = false;

                break;
            }
        }
    }

    public void DisappearAllShrimps()
    {

        for (int i = pointerClass.Count - 1; i > -1; i--)
        {

            if (pointerClass[i].ocuped == true)
            {
                pointerClass[i].pointer.GetComponentInChildren<Animator>().SetBool("Disappear", true);
                pointerClass[i].ocuped = false;

               
            }
        }

    }

    public int GetTotalShrimps()
    {
        return totalShrimps;
    }

    public void DecreaseForce(int value)
    {
        force -= value;

        Debug.Log("Force " + force);

        for (int i = 0; i < pointerClass.Count; i++)
        {

            if (pointerClass[i].ocuped == false)
            {
                pointerClass[i].pointer.SetActive(true);
                pointerClass[i].ocuped = true;
            }
        }

    }
    public int GetForce()
    {
        return force;
    }

    #endregion
}
