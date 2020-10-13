using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAndRespawn : MonoBehaviour
{
    public Collider2D collider;
    public GameObject gameObject;
    public string scene;

    private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isDead = true;
        }
    }

    private void Update()
    {
        if (isDead == true)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
