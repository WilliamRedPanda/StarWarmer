using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Depleter : MonoBehaviour
{
    public Image hp_current; //hp mostrati
    public Image hp_damaged; //barra rossa per mostrare il danno causato/subito nel tempo

    public GameObject eyes;
    public GameObject eyes_low_hp;
    public GameObject eyes_50;
    public GameObject eyes_damaged;

    private float previousHp;
    private GameObject activeEyes;
    void Start()
    {
        previousHp = hp_current.fillAmount;
        if (hp_current.fillAmount > 0.5f) { 
            activeEyes = eyes;
        } else if (hp_current.fillAmount <= 0.5f && activeEyes != eyes_50) {
            activeEyes = eyes_50;
        } else if(hp_current.fillAmount <= 0.25f && activeEyes != eyes_low_hp) { 
            activeEyes = eyes_low_hp;
        }
        disableEyes();
        setActiveEyes();
    }

    void Update()
    {
        if (hp_current.fillAmount < hp_damaged.fillAmount) //riduce la barra rossa nel tempo
        {
            hp_damaged.fillAmount -= Time.deltaTime / 10;
        }

        if(hp_current.fillAmount < previousHp)
        {
            previousHp = hp_current.fillAmount;
            StartCoroutine(damageFeedback());
        }

        if (hp_current.fillAmount <= 0.5f && hp_current.fillAmount > 0.25f && activeEyes != eyes_50)
        {
            activeEyes = eyes_50;
            disableEyes();
            setActiveEyes();
        }
        else if (hp_current.fillAmount <= 0.25f && activeEyes != eyes_low_hp)
        {
            activeEyes = eyes_low_hp;
            disableEyes();
            setActiveEyes();
        }
        // PER ORA NON NE ABBIAMO BISOGNO, SE IL GIOCATORE RECUPERA VITA VA IMPLEMENTATO
        //else if(hp_current.fillAmount > 0.25f)
        //{
        //    activeEyes = eyes;
        //    disableEyes();
        //    setActiveEyes();
        //}

    }

    public IEnumerator damageFeedback ()
    {
        disableEyes();
        eyes_damaged.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        eyes_damaged.gameObject.SetActive(false);
        setActiveEyes();
    }

    public void disableEyes()
    {
        eyes.gameObject.SetActive(false);
        eyes_50.gameObject.SetActive(false);
        eyes_low_hp.gameObject.SetActive(false);
    }

    public void setActiveEyes()
    {
        activeEyes.gameObject.SetActive(true);
    }
}
