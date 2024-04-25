using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{


    public AnimationCurve curve;
    float timer = 0;
    bool shineNow = false;
    // Start is called before the first frame update


    void Update()
    {
        if (shineNow)
        {
            timer += Time.deltaTime;
            transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, curve.Evaluate(timer));

            if (timer > 2)
            {
                shineNow = false;
                timer = 0;
            }

        }
    }


    public void Shine()
    {
        shineNow = true;
    }



    public void StopShine()
    {
        shineNow = false;
        timer = 0;
        transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

    }
}
