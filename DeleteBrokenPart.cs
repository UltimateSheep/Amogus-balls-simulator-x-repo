using System.Collections;
using UnityEngine;

public class DeleteBrokenPart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delete());
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSecondsRealtime(2f);
        for (int i = 0; i < transform.childCount; i++)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            transform.GetChild(i).gameObject.SetActive(false);
        }
        Destroy(gameObject);
    }
}
