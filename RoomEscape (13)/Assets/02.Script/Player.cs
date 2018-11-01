using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {
    public List<Item> m_InventoryList = new List<Item>();
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    Animator animator;

    

    void Start () {
        animator = GetComponent<Animator>();		
	}

  
    void Update () {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("IsWalk", true);
        }
        else animator.SetBool("IsWalk", false);

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
		//transform.Rotate(-Vector3.right * 100.0F * Time.deltaTime * Input.GetAxis("Mouse Y"));





        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit, 100))
            {
                switch (hit.collider.gameObject.name)
                {
                    case "book":
                        GameManager.GetInstance().Event(GameManager.eItemBox.BOOK);
                        break;
                    case "ToolKit":
                        GameManager.GetInstance().Event(GameManager.eItemBox.TOOL_KIT);
                        break;
					case "Exit":
						GameManager.GetInstance().Event(GameManager.eItemBox.EXIT);
						break;
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }



    }

	//ItemManager에 있는Item을 Player Inventory에 Add하여 추가하는 함수
    public void SetInventory(ItemManager.eItem item)
    {
        m_InventoryList.Add(GameManager.GetInstance().m_cItemManager.GetItem(item));
    }

    public void DeletInventory()
    {
        m_InventoryList.Clear();
    }

   
    public bool CheckInventory(int idx)
    {
        if (m_InventoryList[idx] != null)
        {
            return true;
        }else
        return false;
    }
    //아이템을 얻도록 한다. 충돌을 일으킨 오브젝트를 선택하여 이벤트 함수에 들어감
    private void OnCollisionEnter(Collision collision)
    {
    
        switch (collision.gameObject.name)
        {
            case "bed":
                GameManager.GetInstance().Event(GameManager.eItemBox.BED);
                break;
            case "Desk":
                GameManager.GetInstance().Event(GameManager.eItemBox.DESK);
                break;
            case "Closet":
                GameManager.GetInstance().Event(GameManager.eItemBox.CLOSET);
                break;

        }
        Debug.Log("OnCollisionEnter : "+ collision.gameObject.name);

    }
}
