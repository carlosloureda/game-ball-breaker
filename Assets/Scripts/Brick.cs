using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        timesHit = 0;
        this.LinkPrefabs();
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
        this.countBrickHits();
        this.SimulateWin();
        // this.checkForBrickDeath();
    }
    private void countBrickHits()
    {
        this.timesHit++;
    }

    // TODO: remove when win is available
    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

}
