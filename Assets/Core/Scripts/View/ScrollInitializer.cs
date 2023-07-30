using System;
using Core.Scripts.Model;
using UnityEngine;

namespace Core.Scripts.View
{
    public class ScrollInitializer : MonoBehaviour
    {
        public enum AnswerNumbers
        {
            Answer_1,
            Answer_2,
            Answer_3
        }
        
        [SerializeField] private AnswerNumbers _answerNumber;
        [SerializeField] private GameObject _answerItemPrefab;
        [SerializeField] private RectTransform _container;
        
        private QuestionData _questionData;
        private int _repeatCount = 2;
        private void Awake()
        {
            _questionData = DataManager.questionData;
            InitializeAnswerItems();
        }

        private void InitializeAnswerItems()
        {
            for (int j = 0; j < _repeatCount; j++)
            {
                for (int i = 0; i < _questionData.questionItemArray.Count; i++)
                {
                    GameObject obj = Instantiate(_answerItemPrefab, _container);
                    if (obj.TryGetComponent(out AnswerItem item))
                    {
                        String answer = String.Empty;
                        switch (_answerNumber)
                        {
                            case AnswerNumbers.Answer_1:
                                answer = _questionData.questionItemArray[i].answer_1;
                                break;
                            case AnswerNumbers.Answer_2:
                                answer = _questionData.questionItemArray[i].answer_2;
                                break;
                            case AnswerNumbers.Answer_3:
                                answer = _questionData.questionItemArray[i].answer_3;
                                break;
                        }

                        item.AnswerData = _questionData.questionItemArray[i];
                        item.SetText(answer);
                    }
                }
            }
            ChangeContainerSize();
        }

        private void ChangeContainerSize()
        {
            Vector2 offsetMin = _container.offsetMin;
            offsetMin.y -= 320 * (_questionData.questionItemArray.Count * _repeatCount - 3);
            _container.offsetMin = offsetMin;
        }
    }
}