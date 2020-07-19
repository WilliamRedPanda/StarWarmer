using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class SceneSwitch : MonoBehaviour
{
    public int index;
    public string levelName;
    public Image black;
    public Animator anim;
    void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene(3);
        if (other.CompareTag ("Player"))
        {
            StartCoroutine(Fading());
        }
}
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(levelName);
    }
}




