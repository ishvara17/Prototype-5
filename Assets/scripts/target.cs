using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minspeed = 12;
    private float maxspeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gameManager;
    public int PointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);
        transform.position = randomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minspeed, maxspeed);
    }

    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 randomSpawnPos ()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

  
    private void OnMouseDown()
    {
        if (gameManager.isGameActive) {
            Destroy(gameObject);
            gameManager.UpdateScore(PointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("bad"))
        {
            gameManager.Gameover();
        }
    }
}
