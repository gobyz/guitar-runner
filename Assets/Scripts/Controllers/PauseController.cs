using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool isPaused;

    public SpawnController spawnController;

    public AudioController audioController;

    private Vector2 velocityOnPause;
    public void Pause()
    {
        isPaused = true;

        foreach (Pool p in spawnController.pools)
        {
            foreach(Entity e in p.entities)
            {
                if (!e.isAvailable)
                {
                    StopVelocity(e);

                    if (e is Chord)
                    {
                        Chord chord = (Chord)e;

                        foreach (ChordPart chordPart in chord.chordParts)
                        {
                            StopVelocity(chordPart);
                        }
                    }
                }          
            }
        }
        audioController.isPaused = true;
    }
    public void Unpause()
    {
        isPaused = false;

        foreach (Pool p in spawnController.pools)
        {
            foreach (Entity e in p.entities)
            {
                if (!e.isAvailable)
                {
                    ResetVelocity(e);

                    if (e is Chord)
                    {
                        Chord chord = (Chord)e;

                        foreach (ChordPart chordPart in chord.chordParts)
                        {
                            ResetVelocity(chordPart);
                        }
                    }
                }
            }
        }
        audioController.isPaused = false;
    }

    public void StopVelocity(Entity e)
    {
        velocityOnPause = e.velocity;

        e.velocity = Vector3.zero;
    }

    public void ResetVelocity(Entity e)
    {
        e.velocity = velocityOnPause;
    }
}
