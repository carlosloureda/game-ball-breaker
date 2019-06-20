using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
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
        bool isBreakable = this.tag == "Breakable";
        if (isBreakable) this.HandleBrickHit();
        // this.checkForWin();
    }
    private void HandleBrickHit()
    {

        this.timesHit++;
        if (this.timesHit >= this.maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed(); //handle level change
            Destroy(gameObject);
        }
        else
        {
            this.LoadSprites();
        }
    }
    private void LoadSprites()
    {
        int spriteIndex = this.timesHit - 1;
        /* sometimes if fails to load and loads an empty sprite with colliders,
        so we make sure this dosen't happen */
        if (this.hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = this.hitSprites[spriteIndex];

        }

    }

    // private void checkForWin()
    // {
    //     levelManager.LoadNextLevel();
    // }

}
