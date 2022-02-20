using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    public static bool inmortal = false;

    [SerializeField] GameObject powerUpGameObject;
    Animator powerUpAnimator;

    int totalShrimps;
    int force;

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

        powerUpAnimator = powerUpGameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //for (int i = 0; i < pointerClass.Count; i++)
            //{
            //    Debug.Log("id: " + i + " Length " + pointerClass[i].ocuped);
            //}

            Debug.Log(" Subscribers: " + totalShrimps + " Force " + force);
        }
    }

    #region Shrimps
    public void SetListAlly(int ally)
    {
        totalShrimps += ally;

        SetPositionToAlly();

        if (totalShrimps % 19 == 1 && totalShrimps != 1)
        {
            Debug.Log(" Subscribers: " + totalShrimps);

            DisappearAllShrimps();

            powerUpAnimator.SetTrigger("LevelUp");

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
        if (totalShrimps > 0 && !inmortal)
        {
            totalShrimps -= 1;
        }
        else
        {
            return;
        }

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
        if (totalShrimps > 0 && !inmortal)
        {
            totalShrimps -= 1;
        }
        else
        {
            return;
        }


        for (int i = pointerClass.Count - 1; i > -1; i--)
        {

            if (pointerClass[i].ocuped == true)
            {
                pointerClass[i].pointer.GetComponentInChildren<Animator>().SetBool("Disappear", true);
                pointerClass[i].ocuped = false;

                break;
            }
        }

        DecreaseForce();

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

    public void DecreaseForce()
    {
        if (totalShrimps % 19 == 0 && totalShrimps != 0)
        {
            powerUpAnimator.SetTrigger("LevelDown");

            force -= 1;

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
    }
    public int GetForce()
    {
        return force;
    }

    #endregion

}
