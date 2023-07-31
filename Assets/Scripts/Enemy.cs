using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4f;
    // Start is called before the first frame update
    private Player _player;
    Animator m_animator;
    private Collider2D m_collider;
    [SerializeField]
    private AudioSource _Explode;
    [SerializeField]
    private GameObject _enemyLaser;
    [SerializeField]
    private AudioSource enemylasersound;
    [SerializeField]
    private GameObject _Thruster;
    void Start()
    {
        StartCoroutine(FireCooldown());
        _player = GameObject.Find("Player").GetComponent<Player>();
        m_animator = gameObject.GetComponent<Animator>();
        m_collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -10)
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
            m_animator.SetTrigger("OnEnemyDeath");
            _Explode.Play();
            _Thruster.SetActive(false);
            m_collider.enabled = false;
        }
        else if (other.CompareTag("Laser")) // Check if the collider belongs to the laser.
        {
            // Destroy the specific laser that collided with the enemy.
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(30);
            }
            m_animator.SetTrigger("OnEnemyDeath");
            _Explode.Play();
            _Thruster.SetActive(false);
            m_collider.enabled = false;
        }
    }
    IEnumerator FireCooldown()
    {
        while (true)
        {
            enemylasersound.Play();
            Instantiate(_enemyLaser,
                new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z),
                Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 3));
            enemylasersound.Play();
            Instantiate(_enemyLaser,
                new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z),
                Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1, 3));
        }
    }


}
