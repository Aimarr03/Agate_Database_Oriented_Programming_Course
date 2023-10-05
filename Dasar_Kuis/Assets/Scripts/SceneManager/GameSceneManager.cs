using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameSceneManager : MonoBehaviour
{
    public float delay;
    public void ChangeScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
    public void ChangeSceneWithDelay(int indexScene)
    {
        StartCoroutine(DelayTransition(delay, indexScene));
        
    }
    private IEnumerator DelayTransition(float delay, int indexScene)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(indexScene);
    }
}
