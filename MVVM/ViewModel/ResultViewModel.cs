using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WordsQuizWPF.MVVM.Model;

namespace WordsQuizWPF.MVVM.ViewModel
{
    public class ResultViewModel : BaseViewModel
    {
        public ObservableCollection<QuizResultItem> Results { get; set; } = new ObservableCollection<QuizResultItem>();
        public int Score { get; set; }  
        public ResultViewModel(QuizViewModel QuizVM) 
        {
            Score = QuizVM.score;
            for (int i = 0; i < QuizVM.answers_history.Count; i++)
            {
                Results.Add(new QuizResultItem
                {
                    Word = QuizVM.answers_history[i][0],
                    CorrectTranslation = QuizVM.answers_history[i][1],
                    YourChoice = QuizVM.answers_history[i][2]
                });
             }
        }
    }
}
