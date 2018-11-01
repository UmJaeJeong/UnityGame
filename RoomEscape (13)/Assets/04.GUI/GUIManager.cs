using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {
    public List<GameObject> m_listScenes = new List<GameObject>();
    eSceneStatus m_eCurStatus;
    public enum eSceneStatus{
        TITLE, PLAY, INVENTORY, GAMEOVER, THEEND
    };
    private bool count = false;

	void Start () {
        SetStatus(eSceneStatus.TITLE);
        //ShowScene(m_eCurStatus);

    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SetStatus(eSceneStatus.INVENTORY);
            ShowScene(m_eCurStatus);
        }
	}

    public void SetStatus(eSceneStatus status)
    {
        m_eCurStatus = status;
    }

    public void UpdataStatus()
    {
        switch (m_eCurStatus)
        {
            case eSceneStatus.TITLE:
				m_listScenes[(int)m_eCurStatus].SetActive(true);
                break;
            case eSceneStatus.PLAY:

				m_listScenes[(int)m_eCurStatus].SetActive(true);
                m_listScenes[(int)m_eCurStatus].GetComponent<GUIPlay>().SetTime(0,180);
                break;
            case eSceneStatus.INVENTORY:
                if (count == false)
                {
                    m_listScenes[(int)m_eCurStatus].SetActive(true);
                    count = true;
                }
                else
                {
                    m_listScenes[(int)m_eCurStatus].SetActive(false);
                    count = false;
                }
                break;
            case eSceneStatus.GAMEOVER:
				m_listScenes[(int)m_eCurStatus].SetActive(true);
				break;

            case eSceneStatus.THEEND:
				m_listScenes[(int)m_eCurStatus].SetActive(true);
                break;
        }
    }

    //상태에 따른 GUI 만들기
    public GameObject GetScene(eSceneStatus scenestaus)
    {
        return m_listScenes[(int)scenestaus];
    }


    public void ShowScene(eSceneStatus scenestaus)
    {
        UpdataStatus();
    }

    public void OnStartClick()
    {
        m_listScenes[(int)m_eCurStatus].SetActive(false);
        SetStatus(eSceneStatus.PLAY);
        ShowScene(m_eCurStatus);
		

	}

    public void OnEndClick()
    {
        m_listScenes[(int)m_eCurStatus].SetActive(false);
        SetStatus(eSceneStatus.THEEND);
		ShowScene(m_eCurStatus);


	}

	public void OnRetryClick()
    {
		//Player 위치 처음으로 복귀 
		////GameManager.GetInstance().Player.transform.position = Vector3.zero;
		//if (GameManager.GetInstance().m_cPlayer.CheckInventory(0) == true) { 
		//////GUI인벤토리 아이템 삭제
		//m_listScenes[(int)eSceneStatus.INVENTORY].GetComponentInChildren<GUIItemList>().ReleaseItem();
		////Player인벤토리 아이템 삭제 
		//GameManager.GetInstance().m_cPlayer.DeletInventory();
		//}
		m_listScenes[(int)eSceneStatus.GAMEOVER].SetActive(false);
		SetStatus(eSceneStatus.PLAY);
		ShowScene(m_eCurStatus);


	}


}
