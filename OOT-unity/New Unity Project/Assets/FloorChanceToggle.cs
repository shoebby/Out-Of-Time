using System.Collections;
using UnityEngine;

public class FloorChanceToggle : MonoBehaviour
{
    private int num;

    private void Awake()
    {
        num = Random.Range(1, 101);
        if (num == 1)
        {
            StartCoroutine(Hit());
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(Miss());
        }
    }

    IEnumerator Hit()
    {
        while (true)
        {
            for (int i = 0; i < 8; i++)
            {
                Debug.LogError("<3 you got it! <3");
                yield return new WaitForSeconds(.5f);
                Debug.LogError("E> you got it! E>");
                yield return new WaitForSeconds(.5f);
            }
            for (int i = 0; i < 8; i++)
            {
                Debug.LogError("<3 thank you for playing <3");
                yield return new WaitForSeconds(.5f);
                Debug.LogError("E> thank you for playing E>");
                yield return new WaitForSeconds(.5f);
            }
            for (int i = 0; i < 8; i++)
            {
                Debug.LogError("<3 if you're in (creative) schooling good luck <3");
                yield return new WaitForSeconds(.5f);
                Debug.LogError("E> if you're in (creative) schooling good luck E>");
                yield return new WaitForSeconds(.5f);
            }
            for (int i = 0; i < 8; i++)
            {
                Debug.LogError("<3 don't forget to love your work <3");
                yield return new WaitForSeconds(.5f);
                Debug.LogError("E> don't forget to love your work E>");
                yield return new WaitForSeconds(.5f);
            }
            for (int i = 0; i < 8; i++)
            {
                Debug.LogError("<3 you're the only one who could make it <3");
                yield return new WaitForSeconds(.5f);
                Debug.LogError("E> you're the only one who could make it E>");
                yield return new WaitForSeconds(.5f);
            }
        }
    }

    IEnumerator Miss()
    {
        while (true)
        {
            Debug.LogError("error code " + num + ": only " + (num - 1) + " errors away--------");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("-error code " + num + ": only " + (num - 1) + " errors away-------");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("--error code " + num + ": only " + (num - 1) + " errors away------");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("---error code " + num + ": only " + (num - 1) + " errors away-----");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("----error code " + num + ": only " + (num - 1) + " errors away----");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("-----error code " + num + ": only " + (num - 1) + " errors away---");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("------error code " + num + ": only " + (num - 1) + " errors away--");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("-------error code " + num + ": only " + (num - 1) + " errors away-");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("--------error code " + num + ": only " + (num - 1) + " errors away");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("-------error code " + num + ": only " + (num - 1) + " errors away-");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("------error code " + num + ": only " + (num - 1) + " errors away--");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("-----error code " + num + ": only " + (num - 1) + " errors away---");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("----error code " + num + ": only " + (num - 1) + " errors away----");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("---error code " + num + ": only " + (num - 1) + " errors away-----");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("--error code " + num + ": only " + (num - 1) + " errors away------");
            yield return new WaitForSeconds(0.1f);
            Debug.LogError("-error code " + num + ": only " + (num - 1) + " errors away-------");
            yield return new WaitForSeconds(0.1f);
        }
    }
}
