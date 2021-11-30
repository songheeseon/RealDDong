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
    public ObjectManager objectManager;
    public string[] poopObjs;
    //public string[] poopObjs1;
    //public string[] poopObjs2;

    [SerializeField]
    private Text scoreTxT;


    [SerializeField]
    private GameObject poop;

    [SerializeField]
    private GameObject poop_red;

    [SerializeField]
    private GameObject poop_yellow;

    [SerializeField]
    private Text BestScore;
   
    [SerializeField]
    private GameObject panel;

    // Start is called before the first frame update
     void Awake()
    {
        poopObjs = new string[] {"poop", "poop_red", "poop_yellow"};
        //poopObjs1 = new string[] { "poop_red" };
        //poopObjs2 = new string[] {"poop_yellow"};
    }

    public bool stopTrigger = true;

    public void GameOver()
    {
        stopTrigger = false;

        

        if (score >= PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", score);

        BestScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();

        score = 0;
        poop.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

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

    IEnumerator AddScore()
    {
        while (stopTrigger)
        {
            score++;
            scoreTxT.text = score.ToString();
           
            yield return new WaitForSeconds(0.5f);

            Debug.Log("score: " + score);
            scoreTxT.text = "Score: "+score;

            poop.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

            if (score >= 500)
            {
                poop.GetComponent<Rigidbody2D>().gravityScale = 1.5f;
             
                if(score >= 1000)
                {
                    poop.GetComponent<Rigidbody2D>().gravityScale = 2.0f;

                    if(score >= 2000)
                    {
                        poop.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
                    }
                }

            }
        }
    }

    public void Score()
    {
        StartCoroutine(AddScore());
    }

    IEnumerator CreatepoopRoutine()
    {
        while (stopTrigger)
        {
            CreatePoop();
            //CreateRedPoop();
            //CreateYellowPoop();

            yield return  new WaitForSeconds(0.5f);
        }
    }

    private void CreatePoop()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.05f, 0.95f), 1.1f, 0));
        pos.z = 0.0f;
        GameObject poop = objectManager.MakeObj(poopObjs[0]);
        poop.transform.position = pos;
        poop.transform.rotation = Quaternion.identity;

       //Instantiate(poop, pos, Quaternion.identity);

        Vector3 pos1 = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.05f, 0.95f), 1.1f, 0));
        pos1.z = 0.0f;
        GameObject poop_red = objectManager.MakeObj(poopObjs[1]);
        poop_red.transform.position = pos1;
        poop_red.transform.rotation = Quaternion.identity;

        //Instantiate(poop_red, pos1, Quaternion.identity);

        Vector3 pos2 = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.05f, 0.95f), 1.1f, 0));
        pos2.z = 0.0f;
        GameObject poop_yellow = objectManager.MakeObj(poopObjs[2]);
        poop_yellow.transform.position = pos2;
        poop_yellow.transform.rotation = Quaternion.identity;

        //Instantiate(poop_yellow, pos, Quaternion.identity);
    }

    //void CreateRedPoop()
    //{
    //    Vector3 pos1 = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.05f, 0.95f), 1.1f, 0));
    //    pos1.z = 0.0f;
    //    GameObject poop_red = objectManager.MakeObj(poopObjs[1]);
    //    poop_red.transform.position = pos1;
    //    //Instantiate(poop_red, pos1, Quaternion.identity);
    //}

    //void CreateYellowPoop()
    //{
    //    Vector3 pos2 = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.05f, 0.95f), 1.1f, 0));
    //    pos2.z = 0.0f;
    //    GameObject poop_yellow = objectManager.MakeObj(poopObjs[2]);
    //    poop_yellow.transform.position = pos2;
    //    //Instantiate(poop_yellow, pos, Quaternion.identity);
    //}

}

