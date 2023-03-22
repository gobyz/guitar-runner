using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject goodNote;

    public GameObject evilNote;

    public Transform spawn;

    public void Spawn()
    {
        if (ShouldSpawn())
        {
            Instantiate(GetRandomObject(), spawn);
        }    
    }

    public GameObject GetRandomObject()
    {
        int random = Random.Range(0, 2);

        GameObject result = new GameObject();

        if(random == 0)
        {
            result = goodNote;
        }
        else if(random == 1)
        {
            result = evilNote;
        }

        return result;
    }

    public bool ShouldSpawn()
    {
        int randomRange = Random.Range(0, 5);

        return randomRange < 2 ? false : true;
    }
}
