using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace LogicRundown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //variables
        private int AlphaValue = 0;
        private int BetaValue = 0;

        //property
        private bool Inverter
        {
            get
            {
                return (bool)InvertLogicCheckBox.IsChecked;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AlphaTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AlphaTextBox.Text.Length > 0 && BetaTextBox.Text.Length > 0)
            {
                CheckValuesButton.IsEnabled = true; //Will explain this during refactoring
            }
            else
            {
                CheckValuesButton.IsEnabled = false; //Will explain this during refactoring
            }
        }

        private void BetaTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AlphaTextBox.Text.Length > 0 && BetaTextBox.Text.Length > 0)
            {
                CheckValuesButton.IsEnabled = true; //Will explain this during refactoring
            }
            else
            {
                CheckValuesButton.IsEnabled = false; //Will explain this during refactoring
            }
        }
        private static bool InvertBoolValue(bool shouldInvert, bool assessment)
        {
            return (shouldInvert ? !assessment : assessment);
        }

        private void CheckValuesButton_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(AlphaTextBox.Text, out AlphaValue);
            int.TryParse(BetaTextBox.Text, out BetaValue);
            if (AlphaValue == 0 || BetaValue == 0)
            {
                MessageBox.Show("Change the default values - No divide by zero please.");
            }
            else
            {
                if (LogicCompares.CompareLessThan(AlphaValue, BetaValue, Inverter))
                {
                    LogicCanvasOne.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    LogicCanvasOne.Background = new SolidColorBrush(Colors.Red);
                }

                if (LogicCompares.CompareDividedBy(AlphaValue, BetaValue, Inverter))
                {
                    LogicCanvasTwo.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    LogicCanvasTwo.Background = new SolidColorBrush(Colors.Red);
                }

                if (LogicCompares.ComparePower(AlphaValue, BetaValue, Inverter))
                {
                    LogicCanvasThree.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    LogicCanvasThree.Background = new SolidColorBrush(Colors.Red);
                }

                //Ho ho ho - Now I got a Machine Gun
                if ((AlphaValue * BetaValue) > 10 != ((AlphaValue % 2 == 0) && (BetaValue % 2 == 0)))
                {
                    LogicCanvasXor.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    LogicCanvasXor.Background = new SolidColorBrush(Colors.Red);
                }

                int counter = 0;
                for (int i = 1; i <= AlphaValue; i++)
                {
                    if (AlphaValue % i == 0)
                    {
                        counter++;
                    }

                }
                if (counter == 2)
                {
                    LogicCanvasFive.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    LogicCanvasFive.Background = new SolidColorBrush(Colors.Red);
                }
                if (BetaValue == 69)
                {
                    LogicCanvasSix.Background = new SolidColorBrush(Colors.Green);
                    NiceBlock.Foreground = new SolidColorBrush(Colors.White);
                }
                else
                {
                    LogicCanvasSix.Background = new SolidColorBrush(Colors.Red);
                    NiceBlock.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }






        private void CheckValuesButton_MouseStuff(object sender, MouseEventArgs e)
        {
            backy.Focus();
        }

        private void AlphaTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            AlphaTextBox.Text = string.Empty;
        }

        private void BetaTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            BetaTextBox.Text = string.Empty;
        }
    }
}