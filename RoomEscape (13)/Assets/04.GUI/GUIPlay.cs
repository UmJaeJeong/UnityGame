using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlay : MonoBehaviour {
    public Text m_cTimeText;
    private int MaxTime= 180;
    private float CurTime = 0.0f;


	void Start () {
		
	}
	
	void Update () {
        //SetTime(CurTime, MaxTime);
        CurTime += Time.deltaTime;


	}

    public void SetTime(float curtime, int maxtime)
    {

		if (maxtime > 0)
        {
            int extraTime;
            extraTime = MaxTime - (int)curtime;
            if (extraTime % 60 > 9)
            {
                m_cTimeText.text = "남은 시간 : " + (extraTime / 60) + ":" + (extraTime % 60);
            }
            else m_cTimeText.text = "남은 시간 : " + (extraTime / 60) + ":" +"0"+(extraTime % 60);

        }
    }
}
