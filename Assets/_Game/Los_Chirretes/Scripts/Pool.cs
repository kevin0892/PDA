using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pool : MonoBehaviour
{
    public List<PoolObject> Items;

    public List<Transform> instanced = new List<Transform>();
    public void Initialize()
    {
        Transform tr = transform;
        foreach (PoolObject item in Items)
        {
            instanced.AddRange(item.Instantiate(tr));
        }
    }
    
    public Transform GetRandom()
    {
        var actived = instanced.Where(t => !t.gameObject.activeSelf).ToArray();
        return actived[Random.Range(0, actived.Length)];
    }

}

[System.Serializable]
public class PoolObject
{
    public Transform Prefab;
    public int Qtty;

    public Transform[] Instantiate(Transform parent)
    {
        Transform[] transforms = new Transform[Qtty];

        for (int i = 0; i < Qtty; i++)
        {
            transforms[i] = GameObject.Instantiate(Prefab, parent);
            transforms[i].gameObject.SetActive(false);
            
        }
        return transforms;
    }
}
