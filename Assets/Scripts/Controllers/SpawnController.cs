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

    public void Spawn()
    {
        if (ShouldSpawn())
        {
            GameObject go = GetRandomObject(GetRandomPool());

            if(go != null)
            {
                go.transform.position = spawn.transform.position;

                if (spawn.name.Contains("flip"))
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
        Entity e = pool.GetEntity();

        if (e == null)
        {
            return null;
        }
        else
        {
            e.isAvailable = false;
        }
        if (pool.prefab.GetComponent<Entity>() is GoodNote)
        {        
            if(lastGoodNoteGuitarString == null)
            {
                GuitarString gs = GetRandomString();

                lastGoodNoteGuitarString = gs;

                spawn = gs.GetSpawn();
            }
            else
            {
                GuitarString gs = GetCloseGuitarString(lastGoodNoteGuitarString);

                spawn = gs.GetSpawn();

                lastGoodNoteGuitarString = gs;
            }
        }
        else if(pool.prefab.GetComponent<Entity>() is EvilNote)
        {        
            spawn = GetRandomString().GetSpawn();
        }

        return e.gameObject;
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
        return pools[Random.Range(0, pools.Count)];
    }
}
