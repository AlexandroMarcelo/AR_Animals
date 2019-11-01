using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {

    public GameObject tiger;
    public Vector3 spawnValues;
    public Transform spawnPoint;

    void Start()
    {
        
    }

	private void OnTriggerEnter(Collision collision)
	{
        if (collision.gameObject.tag == "animal")
        {
            Instantiate(tiger, spawnPoint.position, spawnPoint.rotation); //Ininialize the object
        }
	}
}
