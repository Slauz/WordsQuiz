using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Input;
using WordsQuizWPF.Core;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace WordsQuizWPF.MVVM.ViewModel
{
    public class QuizViewModel : BaseViewModel
    {
        private MainViewModel Current_VM = ((App)Application.Current).MainViewModel;
        private readonly Random random = new Random();

        public DispatcherTimer timer = new DispatcherTimer();

        private List<KeyValuePair<string, string>> word_translation;
        private List<string> translation_list = new List<string>();

        private int question_number = 1;

        private string a_variant;
        private string b_variant;
        private string c_variant;

        private string currentWord = null;
        private string correctAnswer;
        public ICommand ChooseAnswerCommand { get; private set; }
        public int score { get; private set; } = 0;
        public List<List<string>> answers_history { get; private set; } = new List<List<string>>();
        public string CurrentWord
        {
            get
            {
                return currentWord;
            }
            set
            {
                currentWord = value;
                OnPropertyChanged(nameof(CurrentWord));
            }
        }
        public string A_variant
        {
            get
            {
                return a_variant;
            }
            set
            {
                a_variant = value;
                OnPropertyChanged(nameof(A_variant));
            }
        }
        public string B_variant
        {
            get
            {
                return b_variant;
            }
            set
            {
                b_variant = value;
                OnPropertyChanged(nameof(B_variant));
            }
        }
        public string C_variant
        {
            get
            {
                return c_variant;
            }
            set
            {
                c_variant = value;
                OnPropertyChanged(nameof(C_variant));
            }
        }
        public QuizViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(5);

            timer.Tick += TimerTick;

            timer.Start();
            ReadFromFile();
            GenerateWord();
            GenerateVariants();
            ChooseAnswerCommand = new ChooseAnswerCommand(this);          
        }

        private void TimerTick(object sender, EventArgs e)
        {
            timer.Stop();
            CheckChoosenAnswer("-");
            timer.Start();
        }

        public void CheckChoosenAnswer(string variant)
        {

            List<string> current_answer = new List<string>()
            {
                CurrentWord, correctAnswer
            };

            if (!String.IsNullOrEmpty(CurrentWord)) word_translation.RemoveAll(pair => pair.Key == CurrentWord);

            if (variant == "A")
            {
                score += (A_variant == correctAnswer ? 1 : 0);
                current_answer.Add(A_variant);
            }
            else if (variant == "B")
            {
                score += (B_variant == correctAnswer ? 1 : 0);
                current_answer.Add(B_variant);
            }
            else if (variant == "C")
            {
                score += (C_variant == correctAnswer ? 1 : 0);
                current_answer.Add(C_variant);
            }
            else
            {
                score += 0;
                current_answer.Add("No answer");
            }

            answers_history.Add(current_answer);

            if (question_number >= 10)
            {
                timer.Stop();
                ((App)Application.Current).MainViewModel.UpdateViewCommand.Execute("Result");
                return;
            }

            ++question_number;

            GenerateWord();
            GenerateVariants();
         
        }

        public void GenerateWord()
        {
            int index = random.Next(0, word_translation.Count);

            KeyValuePair<string, string> current_word = word_translation[index];

            CurrentWord = current_word.Key;
            correctAnswer = current_word.Value;

            int answer_index = random.Next(1, 4);

            switch (answer_index)
            {
                case 1:
                    A_variant = correctAnswer;
                    break;
                case 2:
                    B_variant = correctAnswer;
                    break;
                case 3:
                    C_variant = correctAnswer;
                    break;
            }
        }

        public void GenerateVariants()
        {
            List<string> randomVariants = new List<string>();

            while (randomVariants.Count < 2)
            {
                int index = random.Next(0, 100);
                if (translation_list[index] != correctAnswer)
                {
                    randomVariants.Add(translation_list[index]);
                }
            }

            if (A_variant == correctAnswer)
            {
                B_variant = randomVariants[0];
                C_variant = randomVariants[1];
            }
            else if (B_variant == correctAnswer)
            {
                A_variant = randomVariants[0];
                C_variant = randomVariants[1];
            }
            else if (C_variant == correctAnswer)
            {
                A_variant = randomVariants[0];
                B_variant = randomVariants[1];
            }
        }

        private void ReadFromFile()
        {
            string words_path = GetWordsPath();
            string translations_path = GetTranslationsPath();

            List<string> words = new List<string>();
            List<string> translations = new List<string>();

            using (StreamReader reader = new StreamReader(words_path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    words.Add(line);
                }
            }
            using (StreamReader reader = new StreamReader(translations_path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    translations.Add(line);
                }
            }
            
            translation_list = translations;

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            for(int i = 0; i < words.Count; i++)
            {
                list.Add(new KeyValuePair<string, string>(words[i], translations[i]));
            }

            word_translation = list;
        }

      

        private string GetWordsPath()
        {
            switch (DifficultyManager.Difficulty)
            {
                case "Easy":
                    {
                        return "EasyWords.txt";
                    }
                case "Medium":
                    {
                        return "MediumWords.txt";
                    }
                case "Hard":
                    {
                        return "HardWords.txt";
                    }
                default:
                    {
                        return "EasyWords.txt";
                    }
            }
        }

        private string GetTranslationsPath()
        {
            switch (DifficultyManager.Difficulty)
            {
                case "Easy":
                    {
                        return "EasyTranslations.txt";
                    }
                case "Medium":
                    {
                        return "MediumTranslations.txt";
                    }
                case "Hard":
                    {
                        return "HardTranslations.txt";
                    }
                default:
                    {
                        return "EasyTranslations.txt";
                    }
            }
        }
    }
}
