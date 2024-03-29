using System;
using System.IO;
using Scripts.Architecture.Services.Interfaces;
using UnityEngine;

namespace Scripts.Architecture.Services
{
    public class SaveTheBestScore : ISaveTheBestScore
    {
        private readonly IDistanceTrackerService _distanceTracker;
        private readonly string _savePath = "Data/Score.json";
        private readonly string _fileName = "TheHighestScore.json";
        
        public float TheBestScore { get; private set; }
        public SaveTheBestScore(IDistanceTrackerService distanceTracker)
        {
            _distanceTracker = distanceTracker;
            
        #if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, _fileName);
        #else
            _savePath = Path.Combine(Application.dataPath, _fileName);
        #endif
        }
        
        public void Save()
        {
            if (_distanceTracker.Distance < TheBestScore)
                return;

            Data.BestScore bestScore = new Data.BestScore()
            {
                Score = _distanceTracker.Distance
            };

            try
            {
                string json = JsonUtility.ToJson(bestScore, true);
                File.WriteAllText(_savePath,json);
            }
            catch (Exception)
            {
                Debug.Log("Save problem");
            }
        }

        public void Load()
        {
            if (!File.Exists(_savePath))
                return;

            try
            {
                string json = File.ReadAllText(_savePath);

                Data.BestScore bestScore = JsonUtility.FromJson<Data.BestScore>(json);
                TheBestScore = bestScore.Score;
            }
            catch (Exception)
            {
                Debug.Log("Load problem");
            }
        }
    }
}