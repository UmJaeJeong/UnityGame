using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float moveSpeed = 6.0f;
    public GameObject explosionPrefab;
    public GameObject FirePos;
    public GameObject Bullet;

    public bool canShoot = true;
    const float shootDelay = 0.1f;
    float ShootTimer = 0;



    private Animator m_cAnim;

    private void Start()
    {
        m_cAnim = this.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        MoveControl();
        ShootControl();

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
    }

    public void MoveControl()
    {
        if (Input.GetKey(KeyCode.A))
        {
            m_cAnim.SetTrigger("IsLeft");
        }
		if(Input.GetKey(KeyCode.D))
		{
			m_cAnim.SetTrigger("IsRight");
		}
	
        float distanceX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float distanceY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        gameObject.transform.Translate(distanceX, distanceY, 0);
    }
    public void ShootControl()
    {
        if (canShoot)
        {
            if(ShootTimer > shootDelay && Input.GetKey(KeyCode.Space))
            {
                Instantiate(Bullet, FirePos.transform.position, Quaternion.identity);
                ShootTimer = 0;
            }
            ShootTimer += Time.deltaTime;
        }
          
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Instantiate(explosionPrefab, this.gameObject.transform.position, Quaternion.identity);
            Instantiate(explosionPrefab, other.gameObject.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
