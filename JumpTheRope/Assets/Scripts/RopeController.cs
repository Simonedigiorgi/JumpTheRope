using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void LayerChange(int i)
    {
        GetComponent<SpriteRenderer>().sortingOrder = i;
    }
}
