using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;
    string scoreStr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreStr = score.ToString();
        scoreText.text = "Score = " + scoreStr;
    }

    // Update is called once per frame
    void Update()
    {
        scoreStr = score.ToString();
        scoreText.text = "Score = " + scoreStr;
    }
}
