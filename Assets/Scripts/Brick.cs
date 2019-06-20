using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    public AudioClip crack;
    public GameObject smoke;
    private int timesHit;
    private int maxHits;
    private LevelManager levelManager;

    private bool isBreakable;
    // Start is called before the first frame update
    void Start()
    {
        this.isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        timesHit = 0;
        this.LinkPrefabs();
        this.maxHits = this.hitSprites.Length + 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    /**
   * We can link prefabs with FindObjectOfType programatically as Unity doesn't
   * let us use nested prefabs (but we want them)
   */
    private void LinkPrefabs()
    {
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (this.isBreakable) this.HandleBrickHit();
        // this.checkForWin();
    }
    public bool IsFinalHit()
    {
        return this.timesHit >= this.maxHits;
    }
    private void HandleBrickHit()
    {

        this.timesHit++;
        if (this.IsFinalHit())
        {
            breakableCount--;
            AudioSource.PlayClipAtPoint(crack, transform.position);
            levelManager.BrickDestroyed(); //handle level change
            this.PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            this.LoadSprites();
        }
    }

    private void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    private void LoadSprites()
    {
        int spriteIndex = this.timesHit - 1;
        /* sometimes if fails to load and loads an empty sprite with colliders,
        so we make sure this dosen't happen */
        if (this.hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = this.hitSprites[spriteIndex];

        }
        else
        {
            Debug.LogError(("Brick sprite missing"));
        }

    }

    // private void checkForWin()
    // {
    //     levelManager.LoadNextLevel();
    // }

}
