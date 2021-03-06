﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Quiztool;

namespace WISLEY.BLL.Quiz
{
    public class Question
    {
        public int Id { get; set; }
        public string question { get; set; }
        public string number { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string answer { get; set; }
        public string quizId { get; set; }

        public Question()
        {

        }

        public Question(string question, string number, string option1, string option2, string option3, string option4, string answer, string quizId, int Id = -1)
        {
            this.question = question;
            this.number = number;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            this.answer = answer;
            this.quizId = quizId;
            this.Id = Id;
        }

        public int AddQuestion()
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.Insert(this);
        }

        public List<Question> SelectByQuiz(string quizId)
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.SelectByQuiz(quizId);
        }

        public string GetQuestionCount(string quizId)
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.GetQuestionCount(quizId).ToString();
        }

        public int UpdateQuestion(string questionId, string question, string option1, string option2, string option3, string option4, string answer)
        {
            QuestionDAO questiondao = new QuestionDAO();
            return questiondao.UpdateQuestion(questionId, question, option1, option2, option3, option4, answer);
        }
    }
}