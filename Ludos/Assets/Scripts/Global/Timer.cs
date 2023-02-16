using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    [SerializeField] private Image uiFillImage;
    [SerializeField] private int time;

    public int Duration { get; private set; }

    public bool IsPaused { get; private set; }

    private int remainingDuration;

    // Events --
    private UnityAction onTimerBeginAction;
    private UnityAction<int> onTimerChangeAction;
    private UnityAction onTimerEndAction;
    private UnityAction<bool> onTimerPauseAction;

    MathTowerUiManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        Awake();
        SetDuration(time).Begin();   
        uiManager = GameObject.Find("Canvas").GetComponent<MathTowerUiManager>();
    }

    private void Awake()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        uiFillImage.fillAmount = 0f;

        Duration = remainingDuration = 0;

        onTimerBeginAction = null;
        onTimerChangeAction = null;
        onTimerEndAction = null;
        onTimerPauseAction = null;

        IsPaused = false;
    }

    public void SetPaused(bool paused)
    {
        IsPaused = paused;

        if (onTimerPauseAction != null)
            onTimerPauseAction.Invoke(IsPaused);
    }

    public Timer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        
        //if()
        //{
        //    uiManager.updateStars();
        //}

        return this;
    }

    public void Begin()
    {
        if (onTimerBeginAction != null)
            onTimerBeginAction.Invoke();

        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration > 0)
        {
            if (!IsPaused)
            {
                if (onTimerChangeAction != null)
                    onTimerChangeAction.Invoke(remainingDuration);

                UpdateUI(remainingDuration);
                remainingDuration--;
            }
            yield return new WaitForSeconds(1f);
        }
        End();
    }

    private void UpdateUI(int seconds)
    {
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    public void End()
    {
        if (onTimerEndAction != null)
            onTimerEndAction.Invoke();

        ResetTimer();
    }

    private void OnDestroy()
    {
        StopCoroutine(UpdateTimer());
    }
}