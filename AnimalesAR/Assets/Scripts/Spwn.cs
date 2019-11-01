using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwn : MonoBehaviour {

    public Transform spwnpoint;
    public GameObject Prefab;
    int cont = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SPWNEAR()
    {
        if (cont < 3)
        {
            GameObject clone = (GameObject)Instantiate(Prefab, spwnpoint.position, spwnpoint.rotation);
            clone.transform.parent = transform;
            cont++;
        }

    }
}
