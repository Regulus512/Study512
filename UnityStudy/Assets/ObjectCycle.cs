using UnityEngine;

public class ObjectCycle : MonoBehaviour
{
    private void Start()
    {
        Invoke("quit", 1.0f);
    }
    private void quit()
    {
        Time.timeScale = 0;
    }

    private int index = 0;
    private void FixedUpdate()
    {
        index++;
        print(string.Format("{0:D3}. FixedUpdate", index));
    }
    /*
    private void Update()
    {
        index++;
        //001
        print(string.Format("{0:D3}. Update", index));
    }
    */
    /*
    private void LateUpdate()
    {
        print(string.Format("{0:D3}. LateUpdate", index));
        index--;
    }
    */


    /*
    private void Awake()
    {
        print(Constant.STEP + ". Awake");
    }   

    // Start is called before the first frame update
    void Start()
    {
        print(Constant.STEP + ". Start");
    }

    private void OnEnable()
    {
        print(Constant.STEP + ". OnEnable");
    }

    private void OnDisable()
    {
        print(Constant.STEP + ". OnDisable");
    }

    */
}
