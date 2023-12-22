using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WordsQuizWPF.MVVM.ViewModel;

namespace WordsQuizWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : UserControl
    {
        public QuizViewModel CurrentViewModel { get; private set; } = ((App)Application.Current).MainViewModel.CurrentView as QuizViewModel;
        public QuizView()
        {
            InitializeComponent();
            DataContext = CurrentViewModel;
        }

        private void ResetAnimationClick(object sender, RoutedEventArgs e)
        {
            lineAnimation.Stop();
            CurrentViewModel.timer.Stop();
            TimerLine.X2 = 460;
            CurrentViewModel.timer.Start();
            lineAnimation.Begin();
        }
    }
}