using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PooledItems
{
    public string Name;
    public GameObject objectToPool;
    public int amount;
}

public class PoolingManager : MonoBehaviour
{

    private static PoolingManager _instance;
    public static PoolingManager Instance {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();

            }
            return _instance;

        }
    }

    [SerializeField]
    private List<PooledItems> poolList = new List<PooledItems>();


    [SerializeField]
    private Dictionary<string, List<GameObject>> _items =
        new Dictionary<string, List<GameObject>>();


    private void Awake()
    {
        for(int i = 0; i < poolList.Count; i++) // Para cada lista de objetos
        {
            PooledItems l = poolList[i];
            _items.Add(l.Name, new List<GameObject>()); // Creamos una entrada de
                                                        //el Dictionary
            for(int j = 0; j < l.amount; j++) // y añadimos las copias
            {
                GameObject tmp;
                tmp = Instantiate(l.objectToPool); // Aqui creamos la copia
                tmp.transform.SetParent(transform); // ponemos los objetos como hijos
                                                    // del poolingObject
                tmp.SetActive(false); // la desactivamos 
                _items[l.Name].Add(tmp); // y la añadimos a la lista
            }
        }
    }

    public GameObject GetPooledObject(string name)
    { // Busca un objeto que esté desactivado y lo retorna
        List<GameObject> tmp = _items[name];

        for (int i = 0; i < tmp.Count; i++)
        {
            if (!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;
    }

    //void Start()
    //{ // Instancia todos los objetos y los mete en la lista desactivados 
    //    pooledObjects = new List<GameObject>();
    //    GameObject tmp;
    //    for(int i = 0; i<amount; i++)
    //    {
    //        tmp = Instantiate(objectToPool);
    //        tmp.SetActive(false);
    //        pooledObjects.Add(tmp);
    //    }

    //}



    ////// Update is called once per frame
    ////void Update()
    ////{

    ////}


}
