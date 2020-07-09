using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Question Add(Question newQuestion)
        {
            int count = 0;
            foreach (var answer in newQuestion.Answers)
            {
                if (answer.IsCorrect == true)
                {
                    count++;
                }
            }
            if (count == 1)
            {
                return _questionRepository.Add(newQuestion);
            }
            else
            {
                throw new ApplicationException("A question can only have 1 correct answer.");
            }
        }

        public Question Get(int id)
        {
            return _questionRepository.Get(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public void Remove(int id)
        {
            var removedQuestion = _questionRepository.Get(id);
            _questionRepository.Remove(removedQuestion);
        }

        public Question Update(Question updatedQuestion)
        {
            int count = 0;
            foreach(var answer in updatedQuestion.Answers)
            {
                if(answer.IsCorrect == true)
                {
                    count++;
                }
            }
            if (count == 1)
            {
                return _questionRepository.Update(updatedQuestion);
            }
            else
            {
                throw new ApplicationException("A question can only have 1 correct answer.");
            }
        }
    }
}
