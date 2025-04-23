using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public float score = 0;
    public float MaxScore = 0;

    public GameObject player;
    [SerializeField] public TextMeshProUGUI ScoreText;
    [SerializeField] public TextMeshProUGUI MaxScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Puntuacion:" + score;
        MaxScoreText.text = "Puntuacion Maxima:" + MaxScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (MaxScore <= score)
        {
            MaxScore = score;
            UpdateMaxScoreText();
        }
        score = player.transform.position.y;
        ScoreText.text = "Puntuacion:" + score;
    }
    void UpdateMaxScoreText()
    {
        MaxScoreText.text = "Puntuación: " + MaxScore; 
    }
    
    void ClearScore()
    {
        score = 0;
    }
}
