using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StageController : MonoBehaviour
{
    public GameObject[] stages;
    public int numOfStages;

    public Vector3 distance;

    GameObject actualStage;
    
    public void CreateLevel()
    {
        int numRandom = Random.Range(0, stages.Length-1);
        actualStage = Instantiate(stages[numRandom], gameObject.transform.position, stages[numRandom].transform.rotation);
        actualStage.transform.SetParent(gameObject.transform);

        for (int i = 1; i < numOfStages; i++)
        {
            int numRandom2 = Random.Range(0, stages.Length - 1);

            actualStage = Instantiate(stages[numRandom2], actualStage.transform.position + distance, stages[numRandom2].transform.rotation);

            actualStage.transform.SetParent(gameObject.transform);
        }
        
    }


#if UNITY_EDITOR
[CustomEditor(typeof(StageController))]
public class MyEditorScript : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        StageController stageC = (StageController)target;

        if (GUILayout.Button("Create Stages"))
        {
            stageC.CreateLevel();
        }

    }
}
#endif
}
