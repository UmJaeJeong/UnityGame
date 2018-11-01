using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour {

    private float scrollSpeed = 0.7f;

    private Material m_cMat;

    private void Start()
    {
        m_cMat = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        Vector2 newOffset = m_cMat.mainTextureOffset;

        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));
        m_cMat.mainTextureOffset = newOffset;
    }
}
