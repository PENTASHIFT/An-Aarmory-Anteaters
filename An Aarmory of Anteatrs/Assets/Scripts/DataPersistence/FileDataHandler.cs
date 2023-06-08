
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileDataHandler
{
    private string dataDirPath;
    private string fileStorageName;

    public FileDataHandler(string dataDirPath, string fileStorageName){
        this.dataDirPath = dataDirPath;
        this.fileStorageName = fileStorageName;
    }

    public GameData Load(){
        string fullPath = Path.Combine(dataDirPath, fileStorageName);
        Debug.Log(fullPath);
        GameData data = null;
        if(File.Exists(fullPath)){
            try{
                data = JsonConvert.DeserializeObject<GameData>(File.ReadAllText(fullPath));
            }catch(Exception e){
                Debug.LogError($"Failed to lead data due to: {e.Message} {e.StackTrace}");
            }
        }else{Debug.LogError($"Cannot Load file at path: {fullPath}. File does not exist");}
        return data;

    }
    public bool Save(GameData data){
        string fullPath = Path.Combine(dataDirPath, fileStorageName);
        try{
            if(File.Exists(fullPath)){
                Debug.Log("Data Exists. Deleting old file and writing a new one!");
                // File.Delete(fullPath);
            }else{
                Debug.Log("Writing File for the first time!");
            }
            using FileStream stream = File.Create(fullPath);
            stream.Close();
            File.WriteAllText(fullPath, JsonConvert.SerializeObject(data));
            // File.WriteAllText(fullPath, "");
            return true;
        }
        catch(Exception e){
            Debug.LogError($"Unable to save data due to: {e.Message} {e.StackTrace}");
            return false;
        }
    }
}
