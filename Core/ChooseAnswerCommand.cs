using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordsQuizWPF.MVVM.ViewModel;

namespace WordsQuizWPF.Core
{
    public class ChooseAnswerCommand : ICommand
    {
        private QuizViewModel QuizVM;

        public ChooseAnswerCommand(QuizViewModel QuizVM)
        {
            this.QuizVM = QuizVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter) 
        {
            if (parameter.ToString() == "A_answer")
            {
                QuizVM.CheckChoosenAnswer("A");
            }
            else if (parameter.ToString() == "B_answer")
            {
                QuizVM.CheckChoosenAnswer("B");
            }
            else if (parameter.ToString() == "C_answer")
            {
                QuizVM.CheckChoosenAnswer("C");
            }
            else return;
        }
        
    }
}
