using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeController : Components {

    public Text speedText;

	void Start () {
        InvokeRepeating("IncreaseSpeed", 10f, 10f);
    }

    private void Update()
    {
        speedText.text = "Speed " + GetComponent<Animator>().speed.ToString();
    }

    public void LayerChange(int i)
    {
        GetComponent<SpriteRenderer>().sortingOrder = i;
    }

    public void IncreaseSpeed()
    {
        if (pc.isActive)
        {
            if(an.speed < 3)
            {
                an.speed = an.speed + 0.15f;
                am.IncreasePitch();
            }
            else
            {
                an.speed = 3;
            }
        }
        else
        {
            an.speed = 0.85f;
            am.source.pitch = 1;
        }
    }
}
