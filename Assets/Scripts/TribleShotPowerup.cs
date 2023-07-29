using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribleShotPowerup : MonoBehaviour
{
    [SerializeField]
    private int powerupID; 
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                if (powerupID == 1) 
                {
                    player.TribleShotActive();
                }
                else if (powerupID == 2)
                {
                    player.SpeedActive();
                }
                else if (powerupID == 3)
                {
                    player.ShieldActive();
                }
            }
            var PlayerObject = GameObject.FindWithTag("Player");
            Destroy(gameObject);
        }
    }
}
