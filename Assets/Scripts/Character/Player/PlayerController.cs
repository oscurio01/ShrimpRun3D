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

    public int level;

    [SerializeField] private float speed;
    [SerializeField] private float lateralSpeed;

    float leftSide = -8f;
    float rightSide = 8f;

    float m_Input;
    Vector3 velocity;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(InstructionsScript.begin == true)
        {
            Move();
        }

    }

    #region Move
    void Move()
    {
        m_Input = Input.GetAxisRaw("Horizontal");

        if(!GameOverMenu.gameOverIsON && !TriggerGoal.StageComplete)
        {
            velocity = rb.velocity;

            if (m_Input < -0.01)
            {
                if (this.gameObject.transform.position.x > leftSide)
                {
                    velocity = SetLateralMove(1);
                }
                else
                {
                    velocity = SetVelocityForward();
                }

            }
            else if (m_Input > 0.01)
            {
                if (this.gameObject.transform.position.x < rightSide)
                {
                    velocity = SetLateralMove(-1);
                }
                else
                {
                    velocity = SetVelocityForward();
                }

            }
            else if (m_Input == 0)
            {
                velocity = SetVelocityForward();
            }

        }
        else
        {
            velocity = Vector3.zero;
        }

        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Time.deltaTime);
        rb.velocity = velocity;
    }

    Vector3 SetLateralMove(float leftOrRight)
    {
        Vector3 newVelocity = new Vector3(-1 * lateralSpeed * leftOrRight * Time.deltaTime, rb.velocity.y, rb.velocity.z);
        return newVelocity;
    }

    Vector3 SetVelocityForward()
    {
        Vector3 newVelocity =  new Vector3(0, rb.velocity.y, 1 * speed * Time.deltaTime);
        return newVelocity;
    }
    #endregion


}
