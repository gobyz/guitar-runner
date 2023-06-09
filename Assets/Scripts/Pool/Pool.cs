using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public GameObject prefab;

    public List<Entity> entities = new List<Entity>();

    public float spawnRate;

    public int size;
    private void Start()
    {
       InitiatePool();
    }
    public void InitiatePool()
    {
        for(int i = 0; i < size; i++)
        {
            GameObject go = Instantiate(prefab, transform);

            go.SetActive(false);

            Entity e = go.GetComponent<Entity>();

            e.isAvailable = true;

            entities.Add(e);
        }
    }
    public Entity GetEntity()
    {
        return entities.Find(e => e.isAvailable);
    }
    public bool IsPoolEmpty()
    {
        foreach (Entity e in entities)
        {
            if (e.isAvailable)
            {
                return false;
            }
        }
        return true;
    }
}
