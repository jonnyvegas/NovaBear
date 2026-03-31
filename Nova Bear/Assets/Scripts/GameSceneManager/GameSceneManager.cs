using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    IEnumerator ReloadLevel()
    {
        Debug.Log("reload level?");
        yield return new WaitForSeconds(3.0f);
        int levelIdx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(levelIdx);
    }

    public void BeginReloadLevel()
    {
        Debug.Log("Start reload");
        StartCoroutine(ReloadLevel());
    }    
}
