using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SimpleJSON;

public static class SaveSystem
{
    //TODO: Work out how this shit works and fix method heads

    /// <summary>
    /// Returns all data from specified JSON in path as a JSONNode.
    /// </summary>
    /// <param name="path">File from which to load from</param>
    /// <returns></returns>
    public static JSONNode LoadFromJSON(string path) //Check what it returns, might be able to return JSONObject
    {
        //string destination = Application.persistentDataPath + path;
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Saves current level layout to JSON format.
    /// </summary>
    /// <param name="path">Path to which to write to</param>
    public static void SaveToJSON(LevelManager level, string fileName)
    {
        Serialize("name");
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Converts data from file into binary as if it was all String
    /// </summary>
    /// <param name="path">Path to which to write to</param>
    private static void Serialize(string path)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// Converts binary from given file back to a String
    /// </summary>
    /// <param name="path">Path from which to read from</param>
    /// <returns></returns>
    private static string Desirialize(string path)
    {
        throw new System.NotImplementedException();
    }
}
