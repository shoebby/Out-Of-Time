using UnityEngine;

public class EventsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] volumes;

    private void Awake()
    {
        for (int i = 0; i < volumes.Length; i++)
            volumes[i].SetActive(false);

        volumes[0].SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
