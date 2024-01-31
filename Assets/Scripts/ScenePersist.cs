using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    private void Awake()
    {
        // dem xem co bao nhieu phien ban game
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;
        if (numScenePersists > 1)
        {
            // loai bo game Object
            Destroy(gameObject);
        }
        else
        {
            /// giu lai canh xung quanh
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScenesOerSist(){
        Destroy(gameObject);
    }
}
