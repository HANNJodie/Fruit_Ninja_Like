using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<GameObject> targets;
    private float SpawnRate = 1.0f;

    //variable qui va contenir notre TPM (textmeshpro) text
    public TextMeshProUGUI scoreTxt;
    public int Score;
    public int ScoreToAdd;

    public TextMeshProUGUI gameOverUi;

    public bool isGamePlaying;

    // public 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        gameOverUi.gameObject.SetActive(false);
        isGamePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGamePlaying)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            Debug.Log("the random index name is : " + targets[index].name);
            Debug.Log("the random index :" + index);
        }
        
    }

    public void UpdateScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        scoreTxt.text = "Score : " + Score;
    }

    public void GameOver()
    {
        gameOverUi.gameObject.SetActive(true);
        isGamePlaying = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
