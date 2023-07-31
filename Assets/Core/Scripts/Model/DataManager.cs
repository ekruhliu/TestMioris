using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Core.Scripts.Model
{
    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public List<AnswerData> questionItemArray;
    }

    [System.Serializable]
    public class AnswerData
    {
        public string answer_1;
        public string answer_2;
        public string answer_3;
    }
    
    public static class DataManager
    {
        public static QuestionData questionData;

        static DataManager()
        {
            LoadQuestionData();
        }

        private static void LoadQuestionData()
        {
            string filePath = Application.streamingAssetsPath + "/Task_1_UK.json";

            string jsonData = "";

            #if UNITY_ANDROID && !UNITY_EDITOR
                    LoadQuestionDataAndroid(filePath, out jsonData);
            #else
                jsonData = File.ReadAllText(filePath);
            #endif

            questionData = JsonUtility.FromJson<QuestionData>(jsonData);
        }

        #if UNITY_ANDROID && !UNITY_EDITOR
        private static void LoadQuestionDataAndroid(string filePath, out string jsonData)
        {
            jsonData = "";

            using (UnityWebRequest www = UnityWebRequest.Get(filePath))
            {
                www.SendWebRequest();

                while (!www.isDone)
                {
                }

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError("Не удалось загрузить данные из файла: " + filePath);
                }
                else
                {
                    jsonData = www.downloadHandler.text;
                }
            }
        }
        #endif
    }
}