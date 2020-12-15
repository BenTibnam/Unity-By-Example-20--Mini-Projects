using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private static int spawnedTargets = 0;
    private bool destroyedByPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnedTargets++;
        if(gameObject.tag == "NegativeTarget") Invoke("DestroyedAfterTime", 10);
        Debug.Log("Tag: " + gameObject.tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DestroyedAfterTime()
    {
        destroyedByPlayer = false;
        Destroy(gameObject);
        Debug.Log("DESTROYED BY TIMER");
    }

    private void OnMouseDown()
    {
        destroyedByPlayer = true;
        Destroy(gameObject);
        Debug.Log(gameObject.tag);
    }

    public static int GetSpawnedTargets()
    {
        return spawnedTargets;
    }

    private void OnDestroy()
    {
        if(destroyedByPlayer) gameManager.IncrementScore(gameObject.tag);
        spawnedTargets--;
        GameObject.Find("ScoreText").GetComponent<Text>().text = gameManager.GetScore().ToString();
    }
}
