using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 3.0f;
    public GameObject explosionPrefab;

    void Start()
    {

    }

    void Update()
    {
        float distanceY = Time.deltaTime * Speed;
        this.gameObject.transform.Translate(0, distanceY, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {

            Instantiate(explosionPrefab, other.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Finish"))
        {
            Debug.Log(other.name);
            Destroy(this.gameObject);


        }
    }

}
