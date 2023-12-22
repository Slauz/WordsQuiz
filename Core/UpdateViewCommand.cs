using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WordsQuizWPF.MVVM.ViewModel;

namespace WordsQuizWPF.Core
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel MainVM;

        public UpdateViewCommand(MainViewModel MainVM)
        {
            this.MainVM = MainVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter) 
        {
            if (parameter.ToString() == "Menu")
            {
                MainVM.CurrentView = new MenuViewModel();
            }
            else if (parameter.ToString() == "QuizEasy")
            {
                DifficultyManager.Difficulty = "Easy";
                MainVM.CurrentView = new QuizViewModel();           
            }
            else if (parameter.ToString() == "QuizMedium")
            {
                DifficultyManager.Difficulty = "Medium";
                MainVM.CurrentView = new QuizViewModel();
            }
            else if (parameter.ToString() == "QuizHard")
            {
                DifficultyManager.Difficulty = "Hard";
                MainVM.CurrentView = new QuizViewModel();
            }
            else if (parameter.ToString() == "Difficulty")
            {
                MainVM.CurrentView = new DifficultPickingViewModel();
            }
            else if (parameter.ToString() == "Result")
            {
                var view = MainVM.CurrentView as QuizViewModel;
                MainVM.CurrentView = new ResultViewModel(view);
            }
        }
    }
}
