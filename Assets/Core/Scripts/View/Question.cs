using System;
using Core.Scripts.Model;
using TMPro;
using UnityEngine;

namespace Core.Scripts.View
{
    public class Question : MonoBehaviour
    {
        private TextMeshProUGUI _questionText;

        private void Awake()
        {
            _questionText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            _questionText.text = DataManager.questionData.question;
        }
    }
}