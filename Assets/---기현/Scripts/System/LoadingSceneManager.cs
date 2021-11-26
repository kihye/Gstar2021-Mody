using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    [SerializeField] Image progressBar;
    [SerializeField] Text infoText;
    [SerializeField] Text loadingText;
    void Start()
    {
        infoText.text = InfoText();
        StartCoroutine(LoadScene());
    }
    private void Update()
    {
        loadingText.text = ProgressBarPerecent(progressBar.fillAmount) + " %";
    }
    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    IEnumerator LoadScene()
    {
        yield return null; 
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); 
        op.allowSceneActivation = false;
        float timer = 0.0f; 
        while (!op.isDone) 
        { 
            yield return null; 
            timer += Time.deltaTime; 
            if (op.progress < 0.9f) 
            { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                
                if (progressBar.fillAmount >= op.progress) 
                { 
                    timer = 0f; 
                } 
            } 
            else 
            { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer); 
                if (progressBar.fillAmount == 1.0f) 
                { 
                    op.allowSceneActivation = true;
                    loadingText.text = ProgressBarPerecent(progressBar.fillAmount) + " %";
                    yield break; 
                } 
            } 
        }
    }
    private int ProgressBarPerecent(float progFill)
    {
        return (int)(progFill * 100);
    }
    private string InfoText()
    {
        int infoRand = Random.Range(0, 5);
        string str = "";
        switch (infoRand)
        {
            case 0:
                str = "더 강한 적은 더 많은 보상을 줍니다.";
                break;
            case 1:
                str = "전투에서 사망 시 모든 체력 회복 후처음 시작 지점으로 이동합니다.";
                break;
            case 2:
                str = "맵 발판들의 위치를 잘 활용하여 원하는 곳으로 이동합시다.";
                break;
            case 3:
                str = "맵에서 이동 후, 이동한 경로 그대로 되돌아 갈 때 이동 포인트가 회복됩니다.";
                break;
            case 4:
                str = "하루가 지나는 때는 발판을 밟았을 때 입니다.";
                break;
        }
        return str;
    }
}
