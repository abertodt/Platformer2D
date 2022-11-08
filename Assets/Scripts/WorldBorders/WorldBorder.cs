using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : MonoBehaviour
{
    public void KillPlayer()
    {
        SceneManagerSingleton.Instance.ReloadScene();
    }
}
