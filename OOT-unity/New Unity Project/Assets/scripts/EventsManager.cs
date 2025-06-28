using TMPro;
using UnityEngine;

public class EventsManager : Singleton<EventsManager>
{
    [SerializeField] private TextMeshProUGUI currentTaskTMP;
    [SerializeField] private AudioClip taskCompletedClip;
    [SerializeField] private GameObject[] volumes;
    [SerializeField] private string firstTask;

    private int activeTask;


    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < volumes.Length; i++)
            volumes[i].SetActive(false);

        activeTask = 0;
        volumes[activeTask].SetActive(true);
    }

    private void Start()
    {
        currentTaskTMP.text = firstTask;
    }

    public void NextTask()
    {
        volumes[activeTask].SetActive(false);
        activeTask += 1;
        volumes[activeTask].SetActive(true);
        AudioManager.Instance.PlaySFX(taskCompletedClip);
    }
}
