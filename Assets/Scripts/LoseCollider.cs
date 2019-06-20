using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager; // on other prefab

    private void Start()
    {
        this.LinkPrefabs();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        this.levelManager.LoadLevel("LoseScreen");
    }
    /**
    * We can link prefabs with FindObjectOfType programatically as Unity doesn't
    * let us use nested prefabs (but we want them)
     */
    private void LinkPrefabs()
    {
        this.levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
}