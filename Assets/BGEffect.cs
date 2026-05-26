using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGEffect : MonoBehaviour
{

    RawImage ri;
    public float animSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        ri = GetComponent<RawImage>();
     
    }

    // Update is called once per frame
    void Update()
    {

        Rect uv = ri.uvRect;
        uv.x+= animSpeed * Time.deltaTime;
        uv.y+= animSpeed * Time.deltaTime;
        ri.uvRect = uv;

    }
}
