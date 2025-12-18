using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playerName;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
