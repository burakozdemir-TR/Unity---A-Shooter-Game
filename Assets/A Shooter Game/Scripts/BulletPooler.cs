using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletPooler : MonoBehaviourSingleton<BulletPooler>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<IPooledObject>> poolDictionary;
    IPooledObject objectToSpawn;
    void Start()
    {
        SpawnObjects();
    }
    private void SpawnObjects()
    {
        poolDictionary = new Dictionary<string, Queue<IPooledObject>>();
        foreach (Pool pool in pools)
        {
            Queue<IPooledObject> objectPool = new Queue<IPooledObject>();
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public IPooledObject GetFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        if (poolDictionary[tag].Count > 0 && poolDictionary[tag].Peek().IsAvailable)
            objectToSpawn = poolDictionary[tag].Dequeue();
        else
        {
            var prefab = pools.Where(p => p.tag == tag).Select(p => p.prefab).FirstOrDefault();
            objectToSpawn = Instantiate(prefab).GetComponent<IPooledObject>();
        }
        objectToSpawn.OnObjectSpawn();
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
    public T GetFromPool<T>(string tag) where T : IPooledObject
    {
        var obj = GetFromPool(tag);

        return (T)obj;
    }
}
