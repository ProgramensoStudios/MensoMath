using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public GameObject prefabToCreate;
    public int initialPoolSize = 10;
    private List<GameObject> _createdObjects = new List<GameObject>();
    [SerializeField] private Transform spawnPos;
    private FallingNumbers _number;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            var createdObject = Instantiate(prefabToCreate, Vector3.zero, Quaternion.identity);
            createdObject.SetActive(false);
            _createdObjects.Add(createdObject);
        }
    }

    public GameObject AskForObject(int val)
    {
        foreach (GameObject obj in _createdObjects)
        {
            if (!obj.activeInHierarchy)
            {
                _number = obj.GetComponent<FallingNumbers>();
                _number.value = val;
                obj.transform.position = new Vector3(spawnPos.position.x, spawnPos.position.y, 0) ;
                obj.SetActive(true);
                return obj;
            }
        }
        
        var newObject = Instantiate(prefabToCreate, spawnPos.position, Quaternion.identity);
        _createdObjects.Add(newObject);
        return newObject;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = spawnPos.position;
    }
}