using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public List<Pool> pools = new List<Pool>();

    public GuitarString[] strings;

    private Transform spawn;

    private GuitarString lastGoodNoteGuitarString;

    private float difficulty;
    private void Start()
    {
        if (DifficultyController.instance == null)
        {
            difficulty = 0.4f;
        }
        else
        {
            difficulty = DifficultyController.instance.currentDifficulty.difficulty;
        }

        AudioController.beat.AddListener(Spawn);
    }
    public void Spawn()
    {
        if (ShouldSpawn())
        {
            GameObject go = GetRandomObject(GetRandomPool());            

            if (go != null)
            {
                Entity entity = go.GetComponent<Entity>();

                go.transform.position = spawn.transform.position;

                if (entity.isFlipped)
                {
                    Vector3 scale = go.transform.localScale;

                    go.transform.localScale = new Vector3(scale.x, -scale.y, scale.z);
                }
                go.SetActive(true);
            }
        }    
    }
    public GameObject GetRandomObject(Pool pool)
    {
        Entity e;

        if (!pool.IsPoolEmpty())
        {
             e = pool.GetEntity();
        }
        else
        {
            return null;
        }

        GuitarString gs = GetRandomString();

        spawn = gs.GetSpawn();

        e.isAvailable = false;

        if (e is GoodNote)
        {
            if (lastGoodNoteGuitarString != null)
            {
                gs = GetCloseGuitarString(lastGoodNoteGuitarString);
            }

            lastGoodNoteGuitarString = gs;
        }
        if (e is Chord)
        {
            spawn = GetRandomString().spawnCenter;
        }

        SetIsFlipped(e, spawn.name);

        e.guitarString = gs;

        return e.gameObject;
    }

    public void SetIsFlipped(Entity e, string spawnName)
    {
        e.isFlipped = spawnName.Contains("down") ? true : false;
    }

    public bool ShouldSpawn()
    {
        float randomRange = Random.Range(0f, 1f);

        return randomRange < difficulty ? true : false;
    }

    public GuitarString GetRandomString()
    {
        return strings[Random.Range(0, strings.Length)];
    }

    public GuitarString GetCloseGuitarString(GuitarString gs)   //return 3 adjacent strings 
    {
        int index = strings.ToList().IndexOf(gs);

        if (index == 0)
        {
            return strings[Random.Range(0, 2)];
        }
        else if(index == strings.Length - 1)
        {
            return strings[Random.Range(strings.Length - 2, strings.Length)];
        }
        else
        {
            return strings[Random.Range(index - 1, index + 2)];
        }
    }

    public Pool GetRandomPool()
    {
        Shuffle(pools);

        for (int i = 0; i < pools.Count; i++)
        {
            float rnd = Random.Range(0f, 1f);

            if(rnd < pools[i].spawnRate)
            {
                return pools[i];
            }
        }
        return GetRandomPool();
    }

    public static void Shuffle(List<Pool> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;

        while (n > 1)
        {
            n--;

            int k = rng.Next(n + 1);

            Pool value = list[k];

            list[k] = list[n];

            list[n] = value;
        }
    }
}
