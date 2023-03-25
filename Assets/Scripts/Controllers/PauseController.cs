using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public SpawnController spawnController;

    public AudioController audioController;

    private Vector2 velocityOnPause;

    public void Pause()
    {
        foreach(Pool p in spawnController.pools)
        {
            foreach(Entity e in p.entities)
            {
                velocityOnPause = e.velocity;

                e.velocity = Vector3.zero;
            }
        }

        audioController.isPaused = true;
    }

    public void Unpause()
    {
        foreach (Pool p in spawnController.pools)
        {
            foreach (Entity e in p.entities)
            {
                e.velocity = velocityOnPause;
            }
        }

        audioController.isPaused = false;
    }
}
