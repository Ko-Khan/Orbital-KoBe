using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform[] tpPoints;
    private int counts;
    [SerializeField] private float downTime;
    [SerializeField] private GameObject minion;
    private float waitTime;
    public GameObject SceneTransition;

    // Start is called before the first frame update
    void Start()
    {
        counts = 3;
        waitTime = downTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > waitTime)
        {
            Teleport();
            waitTime = Time.time + downTime;
        }
    }

    void Teleport()
    {
        int num = UnityEngine.Random.Range(0,tpPoints.Length);
        transform.position = tpPoints[num].position;

        foreach (Transform t in spawnPoints)
        {
            Debug.Log("Mwahahahah");
            Instantiate(minion, t.position, t.rotation);
        }

    }

    void SpawnNextSceneTransition() {
        SceneTransition.SetActive(true);
    }
}
