using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
            _instance = FindObjectOfType<GameManager>();
            }
        return _instance;
        }
    }


    private int score;

    [SerializeField]
    private Text scoreTxT;


    [SerializeField]
    
    private GameObject poop;
    [SerializeField]
    private Text BestScore;
   
    [SerializeField]
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public bool stopTrigger = true;

    public void GameOver()
    {
        stopTrigger = false;

        if (score >= PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", score);

        BestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        panel.SetActive(true);
    }

    public void GameStart()
    {
        scoreTxT.text = "Score : 0"; // 게임 끝나고 재시작할 때 점수는 0으로 표시 
        score = 0; // 점수 값을 0으로 대입 
        stopTrigger = true;
        StartCoroutine(CreatepoopRoutine());
        panel.SetActive(false);
    }

    public void Score()
    {
        if(stopTrigger)
        score++;

        Debug.Log("score: " + score);
        scoreTxT.text = "Score : " +score;

        poop.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

        if (score >= 30)
        {
            poop.GetComponent<Rigidbody2D>().gravityScale = 1.3f;
        }else if(score >= 50)
        {
            poop.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
        }else if (score >= 100)
        {
            poop.GetComponent<Rigidbody2D>().gravityScale = 1.7f;
        }
    }

    IEnumerator CreatepoopRoutine()
    {
        while (stopTrigger)
        {
            CreatePoop();
            yield return  new WaitForSeconds(0.5f);
        }
    }

    private void CreatePoop()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.05f, 0.95f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(poop, pos, Quaternion.identity);
    }
}

