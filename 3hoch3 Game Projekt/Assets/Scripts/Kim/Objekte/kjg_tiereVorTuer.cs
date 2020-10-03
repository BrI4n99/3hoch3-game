using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kjg_tiereVorTuer : MonoBehaviour
{
    public GameObject kuh;
    public GameObject schwein;
    public static bool kuhVorTuer;
    public static bool schweinVorTuer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SheepWhite" && kjg_kuh.hasKuh) {
            kjg_kuh.folgen = false;
            kjg_kuh.hasKuh = false;
            kuhVorTuer = true;
            StartCoroutine(tierInactive(kuh));

        }
        if (other.gameObject.name == "SheepWhite" && kjg_schwein.hasSchwein)
        {
            kjg_schwein.folgen = false;
            kjg_schwein.hasSchwein = false;
            schweinVorTuer = true;
            StartCoroutine(tierInactive(schwein));

        }
    }

    IEnumerator tierInactive(GameObject otherObject) {
        yield return new WaitForSeconds(5f);
        otherObject.SetActive(false);
    }
}
