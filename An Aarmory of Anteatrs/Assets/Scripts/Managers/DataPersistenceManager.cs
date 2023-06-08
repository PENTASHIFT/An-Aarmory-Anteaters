using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string storageFileName;
    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance {get; private set;}
    //private because we just pass it around. We don't want it being called from the outside
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;


    
    private void Awake(){
        if(instance != null){
            Debug.LogError("There seems to be another instance of DataPersistenceManager");
        }
        instance = this;
    }

    private void Start(){
        dataHandler = new FileDataHandler(Application.persistentDataPath, storageFileName);
        //Initialize list of all DP objects
        dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }
    public void LoadGame(){
        this.gameData = dataHandler.Load();
        if(this.gameData == null){
            Debug.Log("No Load Data Found, starting a new game!");
            NewGame();
        }

        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Loaded Data = " + gameData.currency);
    }
    public void SaveGame(){
        //send gameData obj to all interfaces and make them save data
        foreach(IDataPersistence dataPersistenceObj in dataPersistenceObjects){
            dataPersistenceObj.SaveData(gameData);
        }
        Debug.Log("New Saved Data = " + gameData.currency);

        //write to file
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit() {
        SaveGame();    
    }

    private void OnApplicationPause() {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects(){
        IEnumerable<IDataPersistence> objs = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(objs);
    }


}
