using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -4)
        {
            int spownpointx = Random.Range(-9, 9);
            transform.position = (new Vector3(spownpointx, 8));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            } 
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Laser"))
        {
            var Laser = GameObject.FindWithTag("Laser");
            Destroy(Laser);
            Destroy(gameObject);
        }
        
    }
}
