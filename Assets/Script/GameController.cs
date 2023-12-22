using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour
{
    public List<GameObject> targets;
    public float SpawnRate;

    //variable qui va contenir notre TPM (textmeshpro) text
    public TextMeshProUGUI scoreTxt;
    public int Score;
    public int ScoreToAdd;

    public TextMeshProUGUI gameOverUi;

    public bool isGamePlaying;

    public AudioSource _audioSource;
    public AudioClip _winSound;
    public AudioClip _gameOverSound;
    private int winScore;

    public AudioSource _backgroundMusic;
    public AudioClip _MusicMenu;

    // public 
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SpawnTarget());
        UpdateScore(0);
        gameOverUi.gameObject.SetActive(false);
        isGamePlaying = true;
        //ici jouer le son du menu
        _backgroundMusic.clip = _MusicMenu;
        _backgroundMusic.Play();

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
            
            //Debug.Log("the random index name is : " + targets[index].name);
            //Debug.Log("the random index :" + index);


        }
        
    }

    public void UpdateScore(int ScoreToAdd)
    {
        Score += ScoreToAdd;
        scoreTxt.text = "Score : " + Score;
        if (Score / 100 > winScore)
        {
            _audioSource.clip = _winSound;
            _audioSource.Play();
            winScore = Score / 100;
        }
        else
        {
            winScore = Score / 100;
        }
    }

    public void GameOver()
    {
        gameOverUi.gameObject.SetActive(true);
        //ici stopper le son d'ambiance + jouer le son de game over
        _backgroundMusic.Stop();
        _audioSource.clip = _gameOverSound;
        _audioSource.Play();

        isGamePlaying = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //ICi mettre le son du menu
        _backgroundMusic.clip = _MusicMenu;
        _backgroundMusic.Play();

    }
}
