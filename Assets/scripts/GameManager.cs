using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float SpawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOver;
    public bool isGameActive;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

         
        }
    }

    // Update is called once per frame
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score = " + score;
    }

    public void Gameover()
    {
        GameOver.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        SpawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
    }

}
