using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowChangeColor : MonoBehaviour {
   
    public float Speed = 1;

    // Use this for initialization
    void Start () {
         
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Image>().color = HSBColor.ToColor(new HSBColor(Mathf.PingPong(Time.unscaledTime*Speed, 1), 1, 1));
    }
}
