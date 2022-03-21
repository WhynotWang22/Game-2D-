using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gamecontroller : MonoBehaviour
{
    public GameObject bitmap71;
    public float spawnTime;
    float m_spanwnTime;

    ///
    public GameObject sound;
    AudioSource audioSource;
    int score = 0;
    public Text textScore;
    public Vector2 post;
    // Start is called before the first frame update
    void Start()
    {
        m_spanwnTime = 0;
        audioSource = sound.GetComponent<AudioSource>();
        textScore = GameObject.Find("txtTextScore").GetComponent<Text>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "tien")
        {

            score++;
            Destroy(col.gameObject);
            textScore.text = "Score:" + score.ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

    }
    // Update is called once per frame
    void Update()

    {
        m_spanwnTime -= Time.deltaTime;
        if (m_spanwnTime <= 0)
        {
            SpawnBall();
            m_spanwnTime = spawnTime;

        }
        

        dichuyenbia();
    }
    public void dichuyenbia()
    {

        post = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(post.x, post.y);

    }
    public void SpawnBall()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-87, -16), 4);
        if (bitmap71)
        {
            Instantiate(bitmap71, spawnPos, Quaternion.identity);
        }
    }

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
