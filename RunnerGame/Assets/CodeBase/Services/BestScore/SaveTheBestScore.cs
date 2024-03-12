using System;
using System.IO;
using CodeBase.Services.CoinService;
using UnityEngine;


namespace CodeBase.Services.BestScore
{
    public class SaveTheBestScore : ISaveTheBestScore
    {
        private readonly ICoinService _coinService;

        private string _savePath = "Data/Score.json";
        private string _fileName = "TheHighestScore.json";
        
        public int TheBestScore { get; private set; }

        public SaveTheBestScore(ICoinService coinService)
        {
            _coinService = coinService;
            
#if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
            _savePath = Path.Combine(Application.dataPath, _fileName);
#endif
        }
        
        public void Save()
        {
            if (_coinService.Count < TheBestScore)
                return;

            Data.BestScore bestScore = new Data.BestScore()
            {
                Score = _coinService.Count
            };

            try
            {
                string json = JsonUtility.ToJson(bestScore, true);
                File.WriteAllText(_savePath,json);
            }
            catch (Exception)
            {
                Debug.Log("Load problem");
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