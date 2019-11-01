using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomlyMove : MonoBehaviour
{
    private float speed = 0.02f;
    Animator anim;
    public float accion = 2.3f;//setear a lo que tarda cada accion de cada animal
    public float idle = 7.21f;//setear a lo que tarda el idle de cada animal
    public float timer = 0;
    public float rand;
    private int aux = 0; 

    public GameObject tiger;
    public Transform spawnPoint;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("walk", true);
        rand = Random.Range(idle+3, 15);
    }

    public void Update(){
        timer += Time.deltaTime;
        if (timer >= rand){
            rest();
            timer = 0;
        }
        else if(anim.GetBool("walk") == true && anim.GetBool("touch") == false){
            transform.position += transform.forward * Time.deltaTime * speed;
        }

    }
	void OnTriggerEnter(Collider col)
	{
        if (col.gameObject.tag == "wall")
        {
            
            if (aux == 0)
            {
                Debug.Log("ptnaskdafinjdewrfoi");
                GameObject ani = (GameObject)Instantiate(tiger, spawnPoint.position, spawnPoint.rotation); //Ininialize the object
                ani.transform.parent = transform;
            }
            aux++;
            Debug.Log("ME LLEVA LA PISTOLA");
            rotate(60,120);
        }
	}

	void rotate(float min, float max){
        transform.Rotate(0, Random.Range(min,max), 0);
    }

    void rest(){
        speed = 0;
        anim.SetBool("walk", false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait(){
        if (anim.GetBool("walk") == false)
        {
            speed = 0;
            yield return new WaitForSeconds(idle);//para el idle del animal 7.21 o lo que dure la presentación del animal
            speed = 0.02f;
            anim.SetBool("walk", true);
            anim.SetBool("touch", false);
        }
        else if (anim.GetBool("touch") == true)
        {
            yield return new WaitForSeconds(accion);//hacer una variable publica para que dependiendo de cada accion de cada animal se ponga lo que corresponde (rugido al presionaer del tigre)
            anim.SetBool("touch", false);
            anim.SetBool("walk", false);
            yield return new WaitForSeconds(idle);//para el idle del animal 7.21 o lo que dure la presentación del animal
            speed = 0.02f;
            anim.SetBool("walk", true);
            rotate(-30, 30);
        }
    }

    void OnMouseDown()
    {
        timer = 0;
        anim.SetBool("touch", true);
        speed = 0;
        StartCoroutine(Wait());
    }
}