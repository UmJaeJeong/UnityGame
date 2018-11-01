using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public float m_fSpeed = 10;
    public float m_fOpenAngle = 90;
    float m_fMoveAngle = -1;
    bool m_bOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (m_fMoveAngle == -1)
            return;

        if (Mathf.Abs(m_fMoveAngle) < Mathf.Abs(m_fOpenAngle))
        {
            transform.Rotate(0, m_fSpeed * Time.deltaTime, 0);
            m_fMoveAngle += m_fSpeed * Time.deltaTime;
        }
        else
        {
            if (m_bOpen)
                m_bOpen = false;
            else
                m_bOpen = true;

            m_fMoveAngle = -1;
        }

	}

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 20), ""))
        {
            Open();
        }
    }

    public bool CheckOpen()
    {
        return m_bOpen;
    }

    public void Open()
    {
        if (m_fMoveAngle == -1)
        {
            if (!m_bOpen)
            {
                m_fSpeed *= -1;
                m_fMoveAngle = 0;
            }
            else
            {
                m_fSpeed = Mathf.Abs(m_fSpeed);
                m_fMoveAngle = 0;
            }
        }

    } 
}
