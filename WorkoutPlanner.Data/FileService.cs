using System;
using System.IO;
using System.Text.Json;
using WorkoutPlanner.Core.Models;


namespace WorkoutPlanner.Data
{
    public class FileService
    {
        private string _filePath = "workoutdata.json";


        public void Save(AppData data)
    {
    try
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(_filePath, json);
        }
            catch (Exception ex)
    {
        throw new Exception("Failed to save data: " + ex.Message);
    }
        }
    }
}

