using System;
using System.Collections;
using Core.Scripts.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Scripts.View
{
    public class AnswerItem : MonoBehaviour
    {
        public enum AnswerItemState
        {
            Default,
            Correct,
            Wrong
        }

        public AnswerData AnswerData
        {
            get
            {
                return _answerData;
            }
            set
            {
                _answerData = value;
            }
        }

        public String ItemText
        {
            get
            {
                return _answerText.text;
            }
        }
        
        [SerializeField] private Sprite _correctAnswer;
        [SerializeField] private Sprite _wrongAnswer;
        [SerializeField] private Sprite _default;
        
        private TextMeshProUGUI _answerText;
        private Image _image;
        private AnswerData _answerData;

        private void Awake()
        {
            _answerText = GetComponentInChildren<TextMeshProUGUI>();
            _image = GetComponent<Image>();
        }

        public void SetText(string text)
        {
            _answerText.text = text;
        }

        public void SetAnswerState(AnswerItemState state)
        {
            switch (state)
            {
                case AnswerItemState.Default:
                    _image.sprite = _default;
                    break;
                case AnswerItemState.Correct:
                    _image.sprite = _correctAnswer;
                    break;
                case AnswerItemState.Wrong:
                    _image.sprite = _wrongAnswer;
                    break;
            }

            StartCoroutine(SetDefaultWithDelay());
        }

        private IEnumerator SetDefaultWithDelay()
        {
            yield return new WaitForSecondsRealtime(0.5f);
            _image.sprite = _default;
        }
    }
}