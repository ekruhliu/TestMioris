using System.Collections.Generic;
using Core.Scripts.View;
using UnityEngine;

namespace Core.Scripts.Controller
{
    public class AnswerChecker : MonoBehaviour
    {
        [SerializeField] private AnswerFinder _answerFinder;
        
        public void CheckButtonEvent()
        {
            CheckAnswer(_answerFinder.ShootRaycastToFindAnswers());
        }

        private void CheckAnswer(List<AnswerItem> answers)
        {
            if(answers.Count < 3)
                return;
            if (answers[0].AnswerData.Equals(answers[2].AnswerData)
                && answers[1].ItemText.Equals(answers[0].AnswerData.answer_2))
            {
                foreach (var answer in answers)
                {
                    answer.SetAnswerState(AnswerItem.AnswerItemState.Correct);
                }
            }
            else
            {
                foreach (var answer in answers)
                {
                    answer.SetAnswerState(AnswerItem.AnswerItemState.Wrong);
                } 
            }
        }
    }
}