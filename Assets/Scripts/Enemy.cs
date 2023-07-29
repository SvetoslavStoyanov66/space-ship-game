using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player script1Reference;
    private float _speed = 4f;
    // Start is called before the first frame update
    private Player _player;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
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
        if (other.CompareTag("Player"))
        {
            Player playerHealth = other.GetComponent<Player>();
            if (playerHealth != null)
            {
                _player.TakeDamage(1);
            }
            _player.AddScore(50);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Laser")) // Check if the collider belongs to the laser.
        {
            // Destroy the specific laser that collided with the enemy.
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(30);
            }
            Destroy(gameObject);
        }
    }

}
