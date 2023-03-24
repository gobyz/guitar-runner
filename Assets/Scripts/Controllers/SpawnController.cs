using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Pool goodNotesPool;

    public Pool evilNotesPool;

    public Pool evilNotesJumpingPool;

    public Pool goodNotesJumpingPool;

    public GuitarString[] strings;

    private Transform spawn;

    private GuitarString lastGoodNoteGuitarString;

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
        }
        else if(pool.prefab.GetComponent<Entity>() is EvilNote)
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
        e.isFlipped = spawnName.Contains("flip") ? true : false;
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
        int random = Random.Range(0, 2);

        if(random == 0)
        {
            random = Random.Range(0, 5);

            if (random != 4) // 20% good jumping spawn
            {
                return goodNotesPool;
            }
            else
            {
                return goodNotesJumpingPool;
            }
        }
        else
        {
            random = Random.Range(0, 5);

            if(random != 4) // 20% evil jumping spawn
            {
                return evilNotesPool;
            }
            else
            {
                return evilNotesJumpingPool;
            }
        }
    }
}
