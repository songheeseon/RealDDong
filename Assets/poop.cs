using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            GameManager.instance.Score();
            animator.SetTrigger("poop");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 0.3f);
        }
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.GameOver();
            animator.SetTrigger("poop");
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 0.3f);
        }


    }
}
