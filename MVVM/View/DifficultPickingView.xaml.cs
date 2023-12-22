 using System;
using System.Collections.Generic;
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

namespace WordsQuizWPF.MVVM.View
{
    /// <summary>
    /// Interaction logic for DifficultPickingView.xaml
    /// </summary>
    public partial class DifficultPickingView : UserControl
    {
        public DifficultPickingView()
        {
            InitializeComponent();
            DataContext = ((App)Application.Current).MainViewModel;
        }
    }
}
