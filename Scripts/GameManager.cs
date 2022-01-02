using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Transform Spawner;
    [SerializeField, HideInInspector]
    [Range(1, 50)]
    public int maxNumberOfBalls;
    public Material[] textures;
    public GameObject Balls;
    [Space]
    public GameObject replacement;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Balls.transform.childCount < maxNumberOfBalls)
            {
                
                GameObject instance = Instantiate(ball);
                int randomMat = Random.Range(0, textures.Length);
                Material instanceMaterial = textures[randomMat];
                instance.GetComponent<MeshRenderer>().material = instanceMaterial;
                if (Random.Range(0, 20) == 0)
                {
                    instance.GetComponent<Rigidbody>().useGravity = false;
                    instance.transform.GetChild(0).GetComponent<Rigidbody>().useGravity = false;
                    Debug.Log("anti-gravity");
                }
                if (Random.Range(0, 30) == 0)
                {
                    instance.GetComponent<Rigidbody>().drag = 10;
                    instance.transform.GetChild(0).GetComponent<Rigidbody>().drag = 10;
                    Debug.Log("air resistant");
                }
                if (Random.Range(0, 35) == 0)
                {
                    instance.GetComponent<Transform>().localScale = new Vector3(4, 4 , 4);
                    Debug.Log("big ball");
                }
                if (Random.Range(0, 36) == 0)
                {
                    instance.GetComponent<Transform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Debug.Log("small ball");
                }
                if (randomMat == 4)
                    instance.GetComponent<BallManager>().breakable = true;
                instance.transform.position = Spawner.position;
                instance.transform.SetParent(Balls.transform);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
            reset();
    }

    public void reset()
    {
        for (int i = 0; i < Balls.transform.childCount; i++)
        {
            Destroy(Balls.transform.GetChild(i).gameObject);
        }
    }
}
