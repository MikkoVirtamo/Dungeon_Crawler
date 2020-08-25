using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMaterial : MonoBehaviour
{
    Renderer rend;
    float scrollSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, offset);
    }
}
