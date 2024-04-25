using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    //public float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    /*void Update()
    {
        transform.Translate(0, Time.deltaTime * speed, 0);
    }*/
}
