using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Color unitColor;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        loadColor();
    }

    class saveData
    {
        public Color _unitColor;
    }

    public void saveColor()
    {
        saveData data = new saveData();
        data._unitColor = unitColor;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void loadColor()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");

        saveData data = JsonUtility.FromJson<saveData>(jsonData);

        unitColor = data._unitColor;
    }
}
