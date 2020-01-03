using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXControl : MonoBehaviour {
    public GameObject sfxx;
    public Sprite on, off;
    private Image im;

	// Use this for initialization
	void Start () {
        sfxx = GameObject.FindGameObjectWithTag("Main Music");
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        on = Resources.Load <Sprite>("on 1");
        off = Resources.Load <Sprite>("off 1");
        im = this.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnClick()
    {
        if (sfxx.GetComponent<SFXChecker>().sfx == true)
        {
            sfxx.GetComponent<SFXChecker>().sfx = false;
            im.sprite = off;
        }
        else
        {
            sfxx.GetComponent<SFXChecker>().sfx = true;
            im.sprite = on;
        }
        //sfxx.GetComponent<BackgroundMusicChecker>().sfx = !sfxx.GetComponent<BackgroundMusicChecker>().sfx;
    }
}
