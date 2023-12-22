using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsQuizWPF.MVVM.Model
{
    public class QuizResultItem
    {
        public string Word { get; set; }
        public string CorrectTranslation { get; set; }
        public string YourChoice { get; set; }
        public bool AreValuesEqual
        {
            get { return string.Equals(CorrectTranslation, YourChoice, StringComparison.OrdinalIgnoreCase); }
        }
    }
}
