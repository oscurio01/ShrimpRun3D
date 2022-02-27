using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelController : MonoBehaviour
{
    public static bool inmortal = false;

    public event Action<int> CallForce = delegate { };
    public event Action<int, int> CallFollower = delegate { };

    [SerializeField] GameObject powerUpGameObject;
    Animator powerUpAnimator;

    [SerializeField] GameObject[] powerUps;

    int totalShrimps;
    int maxShrimps;
    int force;

    [SerializeField] List<PointerClass> pointerClass = new List<PointerClass>();

    private void OnEnable()
    {
        OpenCheat.IncreaseShrimpsEvent += AddFollower;
        OpenCheat.DecreaseShrimpsEvent += DecreaseShrimp;
    }

    private void OnDisable()
    {
        OpenCheat.IncreaseShrimpsEvent -= AddFollower;
        OpenCheat.DecreaseShrimpsEvent -= DecreaseShrimp;
    }
    private void Awake()
    {
        maxShrimps = 0;
        totalShrimps = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Pointer"))
            {
                var p = new PointerClass();
                p.pointer = transform.GetChild(i).gameObject;
                p.ocuped = false;

                maxShrimps += 1;

                pointerClass.Add(p);

            }
        }

        CallFollower(totalShrimps % (maxShrimps + 1), maxShrimps);

        powerUpAnimator = powerUpGameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < pointerClass.Count; i++)
            {
                if(pointerClass[i].ocuped) Debug.Log("id: " + i + " Length " + pointerClass[i].ocuped);
            }

            Debug.Log(" Subscribers: " + totalShrimps + " Force " + force);
        }

        for(int i = 0; i < pointerClass.Count; i++)
        {
            if(pointerClass[i].ocuped && !pointerClass[i].pointer.activeInHierarchy)
            {
                pointerClass[i].pointer.SetActive(true);
            }
        }
        
    }

    #region Shrimps
    public void AddFollower()
    {
        totalShrimps += 1;

        

        SetPositionToFollower();

        CallFollower(totalShrimps % (maxShrimps + 1), maxShrimps);

        if (totalShrimps % (maxShrimps+1) == 0 && totalShrimps != 1)
        {

            DisappearAllShrimps();

            powerUpAnimator.SetTrigger("LevelUp");

            AudioManager.instance.PlayAudioSelected("EffectOhYeah");

            force += 1;

            if (force <= powerUps.Length) { if(powerUps[force] != null) powerUps[force].SetActive(true); Debug.Log("s " + force); }

            CallForce(force);
        }

    }

    void SetPositionToFollower()
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

        CallFollower(totalShrimps % (maxShrimps + 1), maxShrimps);

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
            if (totalShrimps <= 0 && force <= 0)
            {
                GameOverMenu.gameOverIsON = true;
            }

            return;
        }



        for (int i = pointerClass.Count - 1; i >= 0; i--)
        {

            if (pointerClass[i].ocuped == true)
            {
                pointerClass[i].pointer.GetComponentInChildren<Animator>().SetBool("Disappear", true);
                pointerClass[i].ocuped = false;

                break;
            }
        }

        CallFollower(totalShrimps % (maxShrimps + 1), maxShrimps);

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
    
    public int GetMaxFollowersShrimps()
    {
        return maxShrimps;
    }

    public void DecreaseForce()
    {
        if (totalShrimps % maxShrimps == 0 && totalShrimps != 0)
        {
            powerUpAnimator.SetTrigger("LevelDown");

            AudioManager.instance.PlayAudioSelected("EffectOhNo");

            if (force <= powerUps.Length && powerUps[force] != null) powerUps[force].SetActive(false);

            force -= 1;

            Debug.Log("Force " + force);

            CallForce(force);

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
