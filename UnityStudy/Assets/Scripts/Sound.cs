using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audio1 = null;
    public AudioSource audio2 = null;
    public AudioSource audio3 = null;

    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("Sound");
        audio1 = obj.GetComponent<AudioSource>();

        audio2 = gameObject.GetComponent<AudioSource>();

        audio3 = GetComponent<AudioSource>();

        // 주소값이 같은가?
        print(audio1 == audio2);
        print(audio2 == audio3);
    }
}
