using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.3f;
    private float _startFire = -1.0f;
    [SerializeField]
    private bool _tribleActive = false;
    [SerializeField]
    private GameObject _triblePrefab;
    public bool _speedActive = false;
    private GameObject _speedPrefab;
    public int maxHealth = 3;
    private int currentHealth;
    private SpawnManager spawnManager;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private bool shieldActive = false;
    [SerializeField]
    private GameObject Shieldviz;
    [SerializeField]
    private int _score;
    private UImanager Uscore;
    [SerializeField]
    private GameObject _thruster;
    [SerializeField]
    private GameObject fire1;
    [SerializeField]
    private GameObject fire2;
    private bool isFirstObjectShown = false;
    void Start()
    {

        transform.position = new Vector3(0, -1, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        currentHealth = maxHealth;
        Uscore = GameObject.Find("Canvas").GetComponent<UImanager>();
    }
    void Update()
    {
        Movement();
        shootLazer();
        
       
        
    }
    void Movement()
    {
        if (_speedActive == true)
        {
            _speed = 10.0f;
        }
        else
        {
            _speed = 5.0f;
        }
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(_speed * HorizontalInput * Time.deltaTime * Vector3.right);

        float VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(_speed * VerticalInput * Time.deltaTime * Vector3.up);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        } 
        if (transform.position.x > 11.25)
        {
            transform.position = new Vector3(-11.25f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.25)
        {
            transform.position = new Vector3(11.25f, transform.position.y, 0);
        }
    }
    void shootLazer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _startFire)
        {
            _startFire = Time.time + _fireRate;
            if (_tribleActive == false) {
                Instantiate(_laserPrefab, new Vector3(transform.position.x, transform.position.y + 0.9f), Quaternion.identity);
            }
            else
            {
                Instantiate(_triblePrefab, new Vector3(transform.position.x, transform.position.y ), Quaternion.identity);
            }
        }
    }

    public void TribleShotActive()
    {
        _tribleActive = true;
        StartCoroutine(TribleShotTimer());
    }
    IEnumerator TribleShotTimer()
    {
        yield return new WaitForSeconds(3);
        _tribleActive = false;

    }
    public void SpeedActive()
    {
        _speedActive = true;
        StartCoroutine(SpeedTImer());
    }
    IEnumerator SpeedTImer()
    {
        yield return new WaitForSeconds(5);
        _speedActive = false;
    }
    public void TakeDamage(int damageAmount)
    {
        if (shieldActive == true)
        {
            Shieldviz.SetActive(false);
            shieldActive = false;
            return;
        }

        int fire = Random.Range(0, 2);

        currentHealth -= damageAmount;
        if (currentHealth == 2)
        {
            fire1.SetActive(fire == 0);
            fire2.SetActive(fire == 1);
        }
        else if (currentHealth == 1)
        {
            fire1.SetActive(true);
            fire2.SetActive(true);
        }
 
            Uscore.UpdateLives(currentHealth);

        if (currentHealth < 1)
        {    
            Uscore.TextApear();
            spawnManager.OnPlayerDead();
            Destroy(gameObject);
        }

    }
    public void ShieldActive()
    {
        Shieldviz.SetActive(true);
        shieldActive = true;
    }
    public void AddScore(int points)
    {
        _score += points;
        Uscore.ScoreDisplay(_score);
    }
}
