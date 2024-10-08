using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crowd : MonoBehaviour
{

    public Slider hypeBar;
    
    Vector2 OgPos;

    // Start is called before the first frame update
    void Start()
    {
         
         OgPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hypeBar.value >= 20)
        {
            float newY = OgPos.y + Mathf.Sin(Time.time * 3) * 3;
            transform.position = new Vector2(OgPos.x, newY);
        }
        else if(hypeBar.value >= 30)
        {
            float newY = OgPos.y + Mathf.Sin(Time.time * 3) * 6;
            transform.position = new Vector2(OgPos.x, newY);
        }
        else if(hypeBar.value > 60)
        {
            float newY = OgPos.y + Mathf.Sin(Time.time * 4) * 9;
            transform.position = new Vector2(OgPos.x, newY);
        }
        else
        {
            transform.position = OgPos;
        }

        
    }
}
