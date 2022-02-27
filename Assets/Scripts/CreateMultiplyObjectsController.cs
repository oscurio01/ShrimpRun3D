using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CreateMultiplyObjectsController : MonoBehaviour
{
    public GameObject[] stages;
    public int numOfObjects;

    public Vector3 distance;

    GameObject actualStage;

    [ExecuteInEditMode]
    public void CreateLevel()
    {

        if(transform.childCount > 1)
        {

            var tempArray = new GameObject[transform.childCount];

            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = transform.GetChild(i).gameObject;
            }

            foreach (var child in tempArray)
            {
                DestroyImmediate(child);
            }
        }

        int numRandom = Random.Range(0, stages.Length);
        actualStage = Instantiate(stages[numRandom], gameObject.transform.position, stages[numRandom].transform.rotation);
        actualStage.transform.SetParent(gameObject.transform);

        actualStage.name = actualStage.name + " " + 0;

        for (int i = 1; i < numOfObjects; i++)
        {
            int numRandom2 = Random.Range(0, stages.Length);

            actualStage = Instantiate(stages[numRandom2], actualStage.transform.position + distance, stages[numRandom2].transform.rotation);

            actualStage.transform.SetParent(gameObject.transform);
            actualStage.name = actualStage.name + " " + i;
        }
        
    }


#if UNITY_EDITOR
[CustomEditor(typeof(CreateMultiplyObjectsController))]
public class MyEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CreateMultiplyObjectsController CreateObjectC = (CreateMultiplyObjectsController)target;

        if (GUILayout.Button("Create Stages"))
        {
            CreateObjectC.CreateLevel();
        }

    }
}
#endif
}
