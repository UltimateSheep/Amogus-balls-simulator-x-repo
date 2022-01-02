using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour
{
    GameManager gameManager;
    GameObject replace;
    public bool breakable = false;
    bool canBreak = true;
    Material currentMaterial;
    // Start is called before the first frame update
    private void Start()
    {
        currentMaterial = GetComponent<MeshRenderer>().material;
        gameManager = FindObjectOfType<GameManager>();
        replace = gameManager.replacement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude >= 35f)
        {
            if (breakable && canBreak)
            {
                GameObject newBroken = Instantiate(replace);
                newBroken.transform.position = transform.position;
                newBroken.transform.SetParent(gameManager.Balls.transform);
                for (int i = 0; i < newBroken.transform.childCount; i++)
                {
                    newBroken.transform.GetChild(i).GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                }
                Destroy(gameObject);
                canBreak = false;
                return;
                //StartCoroutine(DeletePart(newBroken));
            }
        }
    }
    
    //private IEnumerator DeletePart(GameObject ins)
    //{
    //    for (int i = 0; i < ins.transform.childCount; i++)
    //    {
    //        yield return new WaitForSecondsRealtime(5f);
    //        Destroy(ins.transform.GetChild(i).gameObject);
    //    }
    //}
}
