using System.Data.Common;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playerName;
    //public string nameDisplay;
    public int playerHighScore;
    //public int highScoreDisplay;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    [System.Serializable] // Passo 1
    class DataToSave
    {
        public string playerName;
        public int playerHighScore;
    }

    public void SaveName(string playerName) // Passo 2
    {
        DataToSave data = new DataToSave();

        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playernamesavefile.json", json);
    }
    public void SaveScore() // Passo 2
    {
        DataToSave data = new DataToSave();

        data.playerHighScore = playerHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/highscoresavefile.json", json);
    }

    public void LoadName() // Passo 3
    {
        string path = Application.persistentDataPath + "/playernamesavefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            playerName = data.playerName;

        }

    }
    public void LoadScore() // Passo 3
    {
        string path = Application.persistentDataPath + "/highscoresavefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            playerHighScore = data.playerHighScore;

        }

    }

    public void DeleteName()
    {
        string path = Application.persistentDataPath + "/playernamesavefile.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("File deleted");
        }
    }
    public void DeleteHighScore()
    {
        string path = Application.persistentDataPath + "/highscoresavefile.json";

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("File deleted");
        }
    }

    // TUTORIAL 3000 PASSO A PASSO PARA SALVAR DE SESSÃO P/ SESSÃO
    //
    // 1# Criar uma Classe {Class SaveData} (Struct) abaixo de um [System.Serializable] - Que faz com que seja possivel
    // transformar o campo em JSON.
    // Essa Classe deve conter variaveis que serão correspondentes as informações que serão salvas e carregadas.
    // 2# Criar uma função que ira salvar as informações em uma instancia da Classe que foi criada,
    // e então preencher os atributos dessa instancia com tais informações.
    // Apos os atributos serem preenchidos, ultilize "JsonUtility.ToJson()" para transformar essa instancia em uma string no formato JSON
    // e a armazene dentro de uma variavel.
    // Por fim, use a função: File.WriteAllText(Application.persistentDataPath + "/savefile.json", json)
    // sendo seu primeiro parametro, o caminho onde o arquivo sera salvo + o nome do arquivo "savefile.json";
    // {OBS: Application.persistentDataPath, ira lhe dar uma pasta para salvar informações que resistente tanto a atualizações de arquivos
    // quanto a instalações e re-instalações.
    // E seu segundo parametro, o texto que desaja salvar no arquivo (que havia sido previamente salvo em uma variavel,
    // que contia a class formatada para json).}
    // 3# Criar um funçao que ira carregar as informações de uma instacia para dentro das variaveis necessarias.
    // Para isso primeiro e preciso dizer para o programa onde é o caminho, então armazene o caminho usado anteriormente em uma variavel.
    // Depois cheque se o caminho existe.
    // Se existir, utilize File.ReadAllText(), para ler as informações contidas dentro do arquivo presente no caminho indicado,
    // e então, armazenalas em uma string.
    // {OBS: O parametro dessa função é o caminho que ela deve ler (ou seja a variavel string que contem o caminho).}
    // Agora utilize JsonUtility.FromJson<>() para armazenar os arquivos contidos na nova string dentro de uma instancia da Class que criamos
    // {OBS: Entre <> deve conter o tipo da class que os arquivos irão ser amazenados, neste casso <SaveData>, e como parametro 
    // passamos para a função a variavel string que contem as informações que serão passadas para a instacia da nossa class.}
    // Por fim, armazene nas variaves necessarias, as informaçoes contidas na class recem preenchida.
    

}
