using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    public LevelManager levelManager;

    private void OnCollisionEnter2D (Collision2D other) {
        Debug.Log ("collision");
    }
    private void OnTriggerEnter2D (Collider2D other) {
        Debug.Log ("trigger");
        levelManager.LoadLevel ("GameOver");
    }
}