using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (DialogueSystem.getGlobalCollected() == 11 && !DialogueSystem.getMissionComplete())
        {
            SceneManager.LoadScene("Scene 2");
        }
    }
}
