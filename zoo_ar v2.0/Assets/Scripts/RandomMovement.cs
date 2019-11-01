using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{

    public float speed = 0.02f;
    Animator anim;
    public float accion = 2.3f;//setear a lo que tarda cada accion de cada animal
    public float idle = 7.21f;//setear a lo que tarda el idle de cada animal
    public float timer = 0;
    public float rand;
    public AudioSource myclip;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        myclip = GetComponent<AudioSource>();
        anim.SetBool("walk", true);
        rand = Random.Range(idle + 3, 15);
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if (timer >= rand)
        {
            rest();
            timer = 0;
        }
        else if (anim.GetBool("walk") == true && anim.GetBool("touch") == false)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        
            
    }

    void rotate(float min, float max)
    {
        transform.Rotate(0, Random.Range(min, max), 0);
    }

    void rest()
    {
        speed = 0;
        anim.SetBool("walk", false);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        if (anim.GetBool("walk") == false)
        {
            speed = 0;
            yield return new WaitForSeconds(idle);//para el idle del animal 7.21 o lo que dure la presentación del animal
            speed = 0.02f;
            anim.SetBool("walk", true);
            anim.SetBool("touch", false);
            rotate(-30, 30);
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

    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "wall")
        {
            Debug.Log("Choque");
            rotate(90, 270);
        }

    }
    void OnMouseDown()
    {
        myclip.Play(0);
        timer = 0;
        anim.SetBool("touch", true);
        speed = 0;
        StartCoroutine(Wait());

    }

}
