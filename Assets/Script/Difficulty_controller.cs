using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty_controller : MonoBehaviour

{
    public float _DificultySpawnRate;
    //public float _DificultyNbMiss;
    public GameController gameController;
    private Button button;
    public TextMeshProUGUI StartUI;
    public TextMeshProUGUI _score;
    public int _DificultyMalusValue;
    public int DificulyValue;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was clicked");
        gameController.SpawnRate = _DificultySpawnRate;
        gameController.StartCoroutine("SpawnTarget");

        //Xiao Xiao HUD

        StartUI.gameObject.SetActive(false);
        _score.gameObject.SetActive(true);

    }
}
