using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordsQuizWPF.MVVM.Model;
using WordsQuizWPF.MVVM.ViewModel;

namespace WordsQuizWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : UserControl
    {
        public ResultViewModel CurrentViewModel { get; private set; } = ((App)Application.Current).MainViewModel.CurrentView as ResultViewModel;
        public ResultView()
        {
            InitializeComponent();
            DataContext = CurrentViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultList.Visibility = Visibility.Visible;
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).MainViewModel.UpdateViewCommand.Execute("Menu");
        }
    }
}
