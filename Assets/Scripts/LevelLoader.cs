using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
   public void Reload()
    {
        Scene  scene= SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
