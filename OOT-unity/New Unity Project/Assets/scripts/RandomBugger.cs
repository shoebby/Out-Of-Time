using System.Collections;
using UnityEngine;

public class RandomBugger : Singleton<RandomBugger>
{
    [SerializeField] private float timer_max;
    [SerializeField] private float timer_current;
    [SerializeField] private Material placeholderMat;

    private int bugsAmount = 5;

    private void Start()
    {
        gameObject.SetActive(false);
        ResetTimer();
    }

    private void Update()
    {
        timer_current -= Time.deltaTime;

        if (timer_current <= 0)
        {
            PickRandomBug();
            ResetTimer();
        }
    }

    private void ResetTimer()
    {
        timer_max = Random.Range(5, 20);
        timer_current = timer_max;
    }

    private void PickRandomBug()
    {
        int chosenBug = Random.Range(0, bugsAmount);

        switch(chosenBug)
        {
            case 0:
                StartCoroutine(Bug1());
                break;
            case 1:
                StartCoroutine(Bug2());
                break;
            case 2:
                StartCoroutine(Bug3());
                break;
            case 3:
                StartCoroutine(Bug4());
                break;
            case 4:
                StartCoroutine(Bug5());
                break;
        }
    }

    private IEnumerator Bug1()
    {
        float originalSpeed = PlayerScript.Instance.walkSpeed;
        PlayerScript.Instance.walkSpeed = 100f;
        ConsoleLogger.Instance.MakeLog("'PlayerScript.walkSpeed' float point calculation went wrong - attempting hotfix", LogType.Warning);
        yield return new WaitForSeconds(Random.Range(1,4));
        PlayerScript.Instance.walkSpeed = originalSpeed;
    }
    private IEnumerator Bug2()
    {
        PlayerScript.Instance.GetComponent<Animator>().speed = 100;
        ConsoleLogger.Instance.MakeLog("<Animator> component in GameObject 'Player' could not find 'player_wlak.anim'", LogType.Log);
        yield return new WaitForSeconds(Random.Range(1, 4));
        PlayerScript.Instance.GetComponent<Animator>().speed = 1;
    }
    private IEnumerator Bug3()
    {
        ConsoleLogger.Instance.MakeLog("could not call 'eyes_idle.anim', calling next state: 'eyes_close.anim'", LogType.Warning);
        
        CanvasController.Instance.eyesAnim.Play("eyes_close");
        yield return new WaitForSeconds(Random.Range(1, 4));

        ConsoleLogger.Instance.MakeLog("'eyes_idle.anim' found!", LogType.Warning);
        CanvasController.Instance.eyesAnim.Play("eyes_open");
    }

    private IEnumerator Bug4()
    {
        GameObject camQuad = GameObject.FindGameObjectWithTag("CamQuad");
        MeshRenderer camQuad_mr = camQuad.GetComponent<MeshRenderer>();
        Material camQuad_mr_defaultMat = camQuad_mr.material;

        ConsoleLogger.Instance.MakeLog("TargetTexture in <Camera> component of <Game Object> tagged 'MainCamera' undefined, retracing last known RenderTexture", LogType.Warning);
        camQuad_mr.material = placeholderMat;
        yield return new WaitForSeconds(Random.Range(0f, 2f));
        camQuad_mr.material = camQuad_mr_defaultMat;
    }

    private IEnumerator Bug5()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerBodySMR");
        SkinnedMeshRenderer player_smr = player.GetComponent<SkinnedMeshRenderer>();
        Material[] player_smr_mats = player_smr.materials;
        Material defaultFur = player_smr_mats[2];

        ConsoleLogger.Instance.MakeLog("'fur.mat' has been lost to the void, sending a voyager to reclaim now", LogType.Error);
        player_smr_mats[2] = placeholderMat;
        player_smr.materials = player_smr_mats;
        yield return new WaitForSeconds(Random.Range(3,6));
        ConsoleLogger.Instance.MakeLog("'fur.mat' has been reclaimed with minimal casualties", LogType.Log);
        player_smr_mats[2] = defaultFur;
        player_smr.materials = player_smr_mats;
    }
}
