using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TL_Obstacle1_EntryTrigger : MonoBehaviour
{   
    //PlayableDirector
    public GameObject timelineManger;

    int countTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Egg" && countTriggerEntered == 0)
        {
            return;
        }
        print("entered Obstacle1");

        PlayableDirector playableDirector = timelineManger.GetComponent<PlayableDirector>();
        playableDirector.Play();

        countTriggerEntered++;
    }
}
