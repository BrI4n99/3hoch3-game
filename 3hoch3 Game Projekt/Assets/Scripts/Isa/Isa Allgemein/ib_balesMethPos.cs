using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ib_balesMethPos : MonoBehaviour
{
    // GameObjects
    public GameObject hayBale;
    public GameObject hayBaleVar;
    public GameObject carrot;
    public GameObject failCarrot;
    public GameObject fence;
    public GameObject mushroom;

    private static float carHoehe;

    // Möhren
    public static Vector3[] carPos = new Vector3[] {    new Vector3(-40f, 1f , 0f),
                                                        new Vector3(-24f, 1f , 0f),
                                                        new Vector3(-8f, 1f , 0f),
                                                        new Vector3(-40f, 1f , -9f),
                                                        new Vector3(-24f, 1f , -9f),
                                                        new Vector3(-8f, 1f, -9f) };



    public static int index1 = 0;
    public static int index2 = 0;
    public static bool randBool;

    #region Singleton

    public static ib_balesMethPos Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Daten zu den Heuballen

    // Automatisiertes Ersetzen ----------------------------------------------------------------------------------------------------
    // posX[0] = -8        // posX[1] = -24             // posX[2] = -40           // posX[3] = -16           // posX[4] = -32
    public static float[] posX = { -ib_hayBale.baleWidth * 1, -ib_hayBale.baleWidth * 3, -ib_hayBale.baleWidth * 5, -ib_hayBale.baleWidth * 2, -ib_hayBale.baleWidth * 4 };       // Breite, nach links --> Minusrichtung
                                                                                                                                                                                  // posY[0] = 0    // posY[1] = 3  // posY[2] = 6       
    public static float[] posY = { 0, ib_hayBale.baleHeight * 1, ib_hayBale.baleHeight * 2 };   // Höhe, nach oben --> Plusrichtung;
                                                                                                // posZ[0] = 24        // posZ[1] = 28             // posZ[2] = 32           // posZ[3] = 36           // posZ[4] = 40
    public static float[] posZ = { ib_hayBale.baleWidth * 3f, ib_hayBale.baleWidth * 3.5f, ib_hayBale.baleWidth * 4f, ib_hayBale.baleWidth * 4.5f, ib_hayBale.baleWidth * 5f };

    public static float abstand = 28f;

    public static float ballen = 6f;
    // -----------------------------------------------------------------------------------------------------------------------------------


    // Start is called before the first frame update
    void Start()
    {
        carHoehe = Random.Range(0.1f, 2f);
        // Random Bool
        int rand = Random.Range(0, 2);

        if (rand == 1)
        {
            randBool = true;
        }
        else randBool = false;



    }




    // Update is called once per frame
    void Update()
    {
    }

    public GameObject fake() {

        int rand = Random.Range(0, 3);
        GameObject fakeObj;

        if (rand == 0) fakeObj = failCarrot;
        else
        {
            fakeObj = mushroom; 
        }

        return fakeObj;

    }

    // Methoden für Heuballen-Konstruktionen

    public void basic(float x, float y, float z)
    {
        if (x == -8 || x == -24 || x == -40)
        {
            Vector3 pos = new Vector3(x, y, z);
            GameObject bale = Instantiate(hayBale, pos, gameObject.transform.rotation); bale.name = string.Format("bale");
        }
        else
            Debug.Log("falsche Position eingeben");

    }


    // ------------------

    public GameObject basisVar(float x, float y, float z, GameObject parentObj)
    {
        GameObject bale = new GameObject();

        if (x == -8 || x == -24 || x == -40)
        {
            Vector3 pos = new Vector3(x, y, z);
            bale = Instantiate(hayBaleVar, parentObj.transform, false); bale.name = string.Format("bale");
            bale.transform.Translate(pos);
        }
        else
            Debug.Log("falsche Position eingeben");

        return bale;
    }

    public GameObject basis(float x, float y, float z, GameObject parentObj)
    {
        GameObject bale = new GameObject();
        if (x == -8 || x == -24 || x == -40)
        {
            Vector3 pos = new Vector3(x, y, z);
            bale = Instantiate(hayBaleVar, parentObj.transform, false); bale.name = string.Format("bale");

            bale.transform.Translate(pos);
        }
        else
            Debug.Log("falsche Position eingeben");

        return bale;
    }

    //----
    public void basic2(float x, float y, float z)
    {
        if (x == -8 || x == -24 || x == -40)
        {
            Vector3 pos = new Vector3(x, y, z);
            GameObject bale = Instantiate(hayBaleVar, pos, gameObject.transform.rotation); bale.name = string.Format("bale");
        }
        else
            Debug.Log("falsche Position eingeben");
    }
//--------

    public GameObject einfach(float x, float y, float z, bool car, bool fail, GameObject parentObj)
    {
        GameObject bale = new GameObject();
        bale.transform.parent = parentObj.transform;
        
        index1 = Random.Range(0, 6);
        index2 = 0;
        float hoehe = 0;
        // float hoehe2 = 0f;

        void instanzCar(GameObject child, GameObject neu, string name, int index)
        {
            float pX = carPos[index].x; float pY = carPos[index].y; float pZ = carPos[index].z;
            Vector3 realPos = new Vector3(pX, pY + hoehe + carHoehe, pZ + z);
            GameObject neuesObjekt = Instantiate(child, parentObj.transform, false);
            neuesObjekt.transform.Translate(realPos);
            neuesObjekt.name = string.Format(name);
            neuesObjekt.transform.parent = parentObj.transform;
        }



        if (x == -8 || x == -24 || x == -40)
        {
            Vector3 pos = new Vector3(x, y, z);
            bale = Instantiate(hayBaleVar, parentObj.transform, false); bale.name = string.Format("bale");
            bale.transform.Translate(pos);
            bale.transform.parent = parentObj.transform;

            if (car)
            {
                GameObject collCarrot = new GameObject();
                if (x == -8)
                {
                    if (index1 == 2 || index1 == 5) hoehe = 3f ;
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
                }
                if (x == -24)
                {
                    if (index1 == 1 || index1 == 4) hoehe = 3f;
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
                }
                if (x == -40)
                {
                    if (index1 == 0 || index1 == 3) hoehe = 3f ;
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
                }
            }
            if (fail)
            {
                GameObject fakeCarrot = new GameObject();
                index2 = Random.Range(0, 6);
                while (index2 == index1) index2 = Random.Range(0, 6);

                if (x == -8)
                {
                    if (index2 == 2 || index2 == 5) hoehe = 3f;
                    instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                }
                if (x == -24)
                {
                    if (index2 == 1 || index2 == 4) hoehe = 3f;
                    instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                }
                if (x == -40)
                {
                    if (index2 == 0 || index2 == 3) hoehe = 3f;
                    instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                }
                hoehe = 0;
            }
        }
        else
        {
            Debug.Log("falsche Position eingeben");

        }
        return bale;
    }


    public GameObject breit(float x, float y, float z, bool car, bool fail, GameObject parentObj)
    {
        GameObject bale = new GameObject();

        index1 = Random.Range(0, 6);
        index2 = 0;
        float hoehe = 0;

        void instanzCar(GameObject child, GameObject neu, string name, int index)
        {
            float pX = carPos[index].x; float pY = carPos[index].y; float pZ = carPos[index].z;
            Vector3 realPos = new Vector3(pX, pY + hoehe, pZ + z);
            GameObject neuesObjekt = Instantiate(child, parentObj.transform, false);
            neuesObjekt.transform.Translate(realPos);
            neuesObjekt.name = string.Format(name);
        }

        // Ballen 1
        basis(x, y, z, parentObj); 

        // Ballen 2
        if (x == -8 || x == -40)
        {
            basis(-24, y, z, parentObj);  

            if (car)
            {
                 GameObject collCarrot = new GameObject();
                if (index1 < 3) hoehe = 4f;

                if (x == -8)
                {
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
                }
                if (x == -24)
                {
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
        
                }
                if (x == -40)
                {
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
                }

                }
                if (fail)
                {
                    GameObject fakeCarrot = new GameObject();
                    index2 = Random.Range(0, 6);

                    while (index2 == index1) index2 = Random.Range(0, 6);

                    if (index2 < 3) hoehe = 3f;

                    if (x == -8)
                    {
                        instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                    }
                    if (x == -24)
                    {
                        instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                    }
                    if (x == -40)
                    {
                        instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                    }
                    hoehe = 0;
                }
            }
            else
            {
                if (car)
                {
                    basis(-24, y, z, parentObj);
                }
                else
                    basis(-24, y, z, parentObj);
            }
            return bale;
        }




        public GameObject hoch(float x, float y, float z, bool car, bool fail, GameObject parentObj)
        {
            basis(x, y, z, parentObj);
            basis(x, 3f, z, parentObj);


            //  Möhren
            GameObject leer = new GameObject();

            index1 = Random.Range(3, 6);
            index2 = 0;
           /*float hoehe = 0f;

            if (index1 <= 2) hoehe = 3f;

            
            void instanzCar(GameObject child, GameObject neu, string name, int index)
            {
                float pX = carPos[index].x; float pY = carPos[index].y; float pZ = carPos[index].z;
                Vector3 realPos = new Vector3(pX, pY + hoehe, pZ + z);
                GameObject neuesObjekt = Instantiate(child, parentObj.transform, false);
                neuesObjekt.transform.Translate(realPos);
                neuesObjekt.name = string.Format(name);
            } */

            if (car)
            {
                 GameObject collCarrot = new GameObject();
                if (x == -8 || x == -24 || x== -40)
                {
                   // instanzCar(carrot, collCarrot, "collCarrot", index1);
                }
                return collCarrot;

            }
            if (fail)
            {
                GameObject fakeCarrot = new GameObject();
                index2 = Random.Range(3, 6);

                while (index2 == index1)
                {
                    index2 = Random.Range(0, 6);
                }

                if (index2 <= 2)
                {
                   // hoehe = 3f;
                }

                if (x == -8 || x == -24 || x== -40)
                {
                    // instanzCar(fake(), fakeCarrot, "fakeCarrot", index2);
                }
              // hoehe = 0;
                return failCarrot;
            }

            else return leer;


        }

        public GameObject lang(float x, float y, float z, bool car, bool fail, GameObject parentObj)
        {
            basis(-8, y, z, parentObj);
            basis(-24, y, z, parentObj);
            basis(-40, y, z, parentObj);

            // Möhren
             GameObject leer = new GameObject();
             

            index1 = Random.Range(0, 6);
            index2 = 0;
            float hoehe = 0f;

            if (index1 <= 2) hoehe = 3f;

            void instanzCar(GameObject child, GameObject neu, string name, int index)
            {
                float pX = carPos[index].x; float pY = carPos[index].y; float pZ = carPos[index].z;
                Vector3 realPos = new Vector3(pX, pY + hoehe, pZ + z);
                GameObject neuesObjekt = Instantiate(child, parentObj.transform, false);
                neuesObjekt.transform.Translate(realPos);
                neuesObjekt.name = string.Format(name);
            }


            if (car)
            {
                 GameObject collCarrot = new GameObject();
                if (x == -8 || x == -24 || x== -40)
                {
                    instanzCar(carrot, collCarrot, "collCarrot", index1);
                }
                return collCarrot;

            }
            if (fail)
            {
                GameObject fakeCarrot = new GameObject();
                index2 = Random.Range(0, 6);

                while (index2 == index1)
                {
                    index2 = Random.Range(0, 6);
                }

                if (index2 <= 2)
                {
                    hoehe = 3f;
                }

                if (x == -8 || x == -24 || x== -40)
                {
                    instanzCar(failCarrot, fakeCarrot, "fakeCarrot", index2);
                }
                hoehe = 0;
                return failCarrot;
            }

            else { 
                return leer;
            }
           
        }


        public void doppelt(float x, float y, float z, GameObject parentObj)
        {
            if (x == -8 || x == -24)
            {
                breit(x, y, z, false, false, parentObj);
                breit(x, 3f, z, false, false, parentObj);
            }
            else
            {
                hoch(x, y, z, false, false, parentObj);
            }
            // keine Möhren
        }


        public void fuenf(float x, float y, float z, GameObject parentObj)
        {

            lang(x, y, z, false, false, parentObj);
            if (x == -8)
            {
                basis(-40f, 3f, z, parentObj);
                basis(-24f, 3f, z, parentObj);
            }
            if (x == -24)
            {
                basis(-40f, 3f, z, parentObj);
                basis(-8f, 3f, z, parentObj);
            }

            if (x == -40)
            {
                basis(-24f, 3f, z, parentObj);
                basis(-8f, 3f, z, parentObj);
            }
        }


        public void vier(float x, float y, float z, GameObject parentObj)
        {
            lang(x, y, z, false, false, parentObj);
            if (x == -8)
            {
                basis(-40f, 3f, z, parentObj);
            }
            if (x == -24)
            {
                basis(-24f, 3f, z, parentObj);
            }
            if (x == -40)
            {
                basis(-8f, 3f, z, parentObj);
            }
        }

        public void drei(float x, float y, float z, GameObject parentObj)
        {
            if (x == -8 || x == -40)
            {
                hoch(x, y, z, false, false, parentObj);
                basis(-24, y, z, parentObj);
            }

            else
            {
                hoch(x, y, z, false, false, parentObj);
            }
        }



    }
