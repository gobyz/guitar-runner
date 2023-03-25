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

    private void Start()
    {
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

        GuitarString gs = null;

        e.isAvailable = false;

        if (pool.prefab.GetComponent<Entity>() is GoodNote)
        {        
            if (lastGoodNoteGuitarString == null)
            {
                gs = GetRandomString();

                lastGoodNoteGuitarString = gs;

                spawn = gs.GetSpawn();
            }
            else
            {
                gs = GetCloseGuitarString(lastGoodNoteGuitarString);

                spawn = gs.GetSpawn();

                lastGoodNoteGuitarString = gs;
            }

            SetIsFlipped(e, spawn.name);
        }
        else if(pool.prefab.GetComponent<Entity>() is EvilNote)
        {
            gs = GetRandomString();

            spawn = gs.GetSpawn();        
        }
     
        if (pool.prefab.GetComponent<Entity>() is Chord)
        {
            gs = GetRandomString();

            spawn = gs.spawnCenter;
        }

        if (pool.prefab.GetComponent<Entity>() is Heal)
        {
            gs = GetRandomString();

            spawn = gs.GetSpawn();
        }

        if (pool.prefab.GetComponent<Entity>() is Score)
        {
            gs = GetRandomString();

            spawn = gs.GetSpawn();
        }

        if (pool.prefab.GetComponent<Entity>() is Lick)
        {
            gs = GetRandomString();

            spawn = gs.GetSpawn();
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
        int randomRange = Random.Range(0, 5);

        return randomRange < 2 ? false : true;
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
