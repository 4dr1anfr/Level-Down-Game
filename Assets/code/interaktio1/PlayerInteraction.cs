using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerInteraction : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Linksklick
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("ButtonSceneLoad"))
                {
                    Debug.Log("Button geklickt! Lade Level2...");

                    if (SceneExists("Level2"))
                    {
                        SceneManager.LoadScene("Level2");
                    }
                    else
                    {
                        Debug.LogError("⚠ Szene 'Level2' existiert NICHT in den Build Settings!");
                        Debug.LogError("🔍 Szenen in den Build Settings:");
                        
                        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
                        {
                            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
                            Debug.Log("📝 " + Path.GetFileNameWithoutExtension(scenePath));
                        }
                    }
                }
            }
        }
    }

    bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string scene = Path.GetFileNameWithoutExtension(scenePath);
            if (scene == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
