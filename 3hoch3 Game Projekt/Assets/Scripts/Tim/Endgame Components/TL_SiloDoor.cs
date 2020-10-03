using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class TL_SiloDoor : MonoBehaviour
{
    public float rotSpeed = 200f;
    private Quaternion startRot, endRot;
    bool targetHit = false;
    private float smooth;

    //PlayableDirector
    public GameObject timelineManger;

    //Vogelscheuche
    GameObject vogelscheuche;

    //Canvas Text und Health Bar
    public GameObject canvasText;
    public GameObject canvasHealthBar;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Egg")
        {
            targetHit = true;
            StartCoroutine("startCutscene");
            ib_StaticVar._score += 100;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        startRot = transform.parent.parent.rotation;
        endRot = Quaternion.AngleAxis(-85, Vector3.up);

        //Vogelscheuche
        vogelscheuche = GameObject.Find("Vogelscheuche");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHit && transform.parent.parent.localEulerAngles.y > 300 || targetHit && transform.parent.parent.localEulerAngles.y == 0)
        {
            transform.parent.parent.Rotate(-Vector3.up * (10 * Time.deltaTime));
        }
    }
    IEnumerator startCutscene()
    {
        yield return new WaitForSeconds(5f);
        PlayableDirector playableDirector = timelineManger.GetComponent<PlayableDirector>();
        playableDirector.Play();
        yield return new WaitForSeconds(11f);
        canvasText.SetActive(true);
        yield return new WaitForSeconds(5.5f);
        canvasText.SetActive(false);
        canvasHealthBar.SetActive(true);
        vogelscheuche.GetComponent<NavMeshAgent>().enabled = true;
    }
}
