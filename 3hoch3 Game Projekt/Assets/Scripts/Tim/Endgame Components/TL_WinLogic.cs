using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TL_WinLogic : MonoBehaviour
{
    //PlayableDirector
    public GameObject timelineManger;

    //Platformen
    public GameObject siloAufzug;
    public GameObject stufe1;
    public GameObject stufe2;
    public GameObject stufe3;

    //Balduin
    public GameObject balduin;

    //Trigger Hinweis
    public GameObject triggerHinweis;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("endCutscene");
    }

    IEnumerator endCutscene()
    {
        yield return new WaitForSeconds(2f);
        PlayableDirector playableDirector = timelineManger.GetComponent<PlayableDirector>();
        playableDirector.Play();

        yield return new WaitForSeconds(3f);
        siloAufzug.SetActive(true);
        yield return new WaitForSeconds(3f);
        stufe1.SetActive(true);
        yield return new WaitForSeconds(2f);
        balduin.SetActive(true);
        yield return new WaitForSeconds(1f);
        stufe2.SetActive(true);
        yield return new WaitForSeconds(3f);
        stufe3.SetActive(true);
        yield return new WaitForSeconds(7f);
        triggerHinweis.SetActive(true);
    }
}
