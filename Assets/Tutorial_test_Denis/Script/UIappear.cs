using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIappear : MonoBehaviour
{
    public GameObject uiObject;
    [SerializeField] Button defaultButton;

    private void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
            defaultButton?.Select();
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
  //    Destroy(uiObject);
        Destroy(gameObject);
    }
}