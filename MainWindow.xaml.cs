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

namespace Ugadayka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClassGame classGame;

        public MainWindow()
        {
            //New test comment
            //Add 1 conflict
            InitializeComponent();
            classGame = new ClassGame(5);
            StartGame();
        }

        private void StartGame()
        {
            classGame.StartGame();

            counterText.Inlines.Clear();
            counterText.Inlines.Add(new Run("Кол-во попыток:") {
                FontWeight = FontWeights.Bold,
                FontSize = 20
            });
            counterText.Inlines.Add(new Run(classGame.Counter.ToString())
            {
                FontWeight = FontWeights.Black,
                FontSize = 44,
                Foreground = Brushes.Red
            });
        }

        private void ButtonRestartClick(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void ButtonNumberClick(object sender, RoutedEventArgs e)
        {
            int codeStatus = classGame.checkGameStatus();
            MessageBoxResult msgResult;

            if (codeStatus != 3)
            {
                msgResult = MessageBox.Show("Запустить игру?", "Запустить игру?", MessageBoxButton.OKCancel);
                if(msgResult == MessageBoxResult.OK)
                {
                    StartGame();
                }
            }
            else
            {
                string curVal = (string)((Button)e.OriginalSource).Content;
                classGame.NextStep(Int32.Parse(curVal));

                counterText.Inlines.Clear();
                counterText.Inlines.Add(new Run("Кол-во попыток:")
                {
                    FontWeight = FontWeights.Bold,
                    FontSize = 20
                });
                counterText.Inlines.Add(new Run(classGame.Counter.ToString())
                {
                    FontWeight = FontWeights.Black,
                    FontSize = 44,
                    Foreground = Brushes.Red
                });

                codeStatus = classGame.checkGameStatus();

                if(codeStatus == 1)
                {
                    msgResult = MessageBox.Show("ПОБЕДА :) \n Запустить игру?", "ПОБЕДА :)", MessageBoxButton.OKCancel);
                    if (msgResult == MessageBoxResult.OK)
                    {
                        StartGame();
                    }
                }
                else if(codeStatus == 2)
                {
                    msgResult = MessageBox.Show("ПОРАЖЕНИЕ :( \n Запустить игру?", "ПОРАЖЕНИЕ :(", MessageBoxButton.OKCancel);
                    if (msgResult == MessageBoxResult.OK)
                    {
                        StartGame();
                    }
                }

            }
        }

    }
}
