using System.Collections;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class ButtonActiveManager : MonoBehaviour, IFocusable
{
    public GameObject Environment;
    public GameObject ProgressBar;

    private bool isFocus;

    public void OnFocusEnter()
    {
        isFocus = true;
        StartCoroutine(ProgressBarTimer());
    }

    public void OnFocusExit()
    {
        isFocus = false;
        // progressBar go back to Zero
        ProgressBar.transform.localScale =
            new Vector3(ProgressBar.transform.localScale.x,
                        0,
                        ProgressBar.transform.localScale.z);

        StartCoroutine(ProgressBarTimer());
    }

    IEnumerator ProgressBarTimer()
    {
        // progressBar grow up: 如果光标矮于2.4就一直以每0.1秒0.1高的单位进行加载
        while (ProgressBar.transform.localScale.y <= 2.4f && isFocus == true)
        {
            ProgressBar.transform.localScale = ProgressBar.transform.localScale + new Vector3(0, 0.1f, 0);
            yield return new WaitForSeconds(0.1f);
        }

        if (isFocus)
        {
            // progressBar grow up finish then implimente the OnClickBt()，to let the button implement sth
            Environment.GetComponent<EnvironmentManager>().OnClickBt();
        }
    }
}
