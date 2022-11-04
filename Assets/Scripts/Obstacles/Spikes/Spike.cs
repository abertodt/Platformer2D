using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    
    public void KillPlayer()
    {
        SceneManagerSingleton.Instance.ReloadScene();
    }
}
