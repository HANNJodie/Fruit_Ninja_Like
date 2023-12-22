using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;

    // force d'impulsion
    public float minImpulse = 12f;
    public float maxImpulse = 16f;
    public float maxTorque = 10f;
    private float maxSpawnX = 4f;
    private float pointSpawnY = -1f;

    private float LifeTime = 3;

    public GameObject destroyParticle;

    public GameController gameController;

    public int scoreItemEasy;
    //public int scoreItemMedium;
    //public int scoreItemHard;
    //public Difficulty_controller _difficulty_Controller;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyTime", LifeTime);

        // Debug.Log("Wouf");

        // Recuperrer auto le rigidbody
        targetRb = GetComponent<Rigidbody>();

        // faire une impulsion vers le haut
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // faire tourner de maniere random
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);

        //Pour eviter 
        transform.position = RandomSpawn();

        gameController = GameObject.Find("GameManager").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("DingDong");
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minImpulse, maxImpulse);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-maxSpawnX, maxSpawnX), pointSpawnY);
    }

    private void OnMouseEnter()
    {
        if (!gameController.isGamePlaying)
        {
            return;
        }

       if (Input.GetMouseButton(0))
        {
            //if (_difficulty_Controller.DificulyValue == 1)
            //    gameController.UpdateScore(scoreItemEasy);
            //if (_difficulty_Controller.DificulyValue == 2)
            //    gameController.UpdateScore(scoreItemMedium);
            //if (_difficulty_Controller.DificulyValue == 3)
            //    gameController.UpdateScore(scoreItemHard);

            gameController.UpdateScore(scoreItemEasy);
            Instantiate(destroyParticle, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }

    private void DestroyTime()
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Good"))
        {
            gameController.GameOver();
        }
    }


}