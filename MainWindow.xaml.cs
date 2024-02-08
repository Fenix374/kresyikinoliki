using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace krestikiNloiki
{
    public partial class MainWindow : Window
    {
        private List<Button> buttons; 
        private bool isPlayerX = true; 
        private bool isGameOver = false;

        public MainWindow()
        {
            InitializeComponent();
            InitializeButtonsList(); 
        }

        private void InitializeButtonsList()
        {
            buttons = new List<Button>
            {
                btn1, btn2, btn3,
                btn4, btn5, btn6,
                btn7, btn8, btn9
            };
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {


            foreach (var button in buttons)
            {
                button.Content = "";
                button.IsEnabled = true;
            }
            isPlayerX = true;
            isGameOver = false;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!isGameOver && button.IsEnabled)
            {
                button.Content = isPlayerX ? "X" : "O"; 
                button.IsEnabled = false; 
                if (WinnerCheck())
                {
                    string winner = isPlayerX ? "X" : "O";
                    MessageBox.Show($"Победил.: {winner}");
                    isGameOver = true;
                }
                else if (Boardisfull())
                {
                    MessageBox.Show("Ну не доработал.Не круто .");
                    isGameOver = true;
                }
                else
                {
     
                    isPlayerX = !isPlayerX;
                    if (!isPlayerX)
                    {
                        ComputerTurn();
                    }
                }
            }
        }


        private bool WinnerCheck()
        {
            string[] symbols = new string[9];
            for (int i = 0; i < 9; i++)
            {
               
                if (buttons[i].Content != null)
                {
                    symbols[i] = buttons[i].Content.ToString();
                }
                else
                {
                    symbols[i] = ""; 
                }
            }


            if ((symbols[0] == symbols[1] && symbols[1] == symbols[2] && symbols[0] != "") ||
                (symbols[3] == symbols[4] && symbols[4] == symbols[5] && symbols[3] != "") ||
                (symbols[6] == symbols[7] && symbols[7] == symbols[8] && symbols[6] != "") ||
                (symbols[0] == symbols[3] && symbols[3] == symbols[6] && symbols[0] != "") ||
                (symbols[1] == symbols[4] && symbols[4] == symbols[7] && symbols[1] != "") ||
                (symbols[2] == symbols[5] && symbols[5] == symbols[8] && symbols[2] != "") ||
                (symbols[0] == symbols[4] && symbols[4] == symbols[8] && symbols[0] != "") ||
                (symbols[2] == symbols[4] && symbols[4] == symbols[6] && symbols[2] != ""))
            {

                return true; 
            }

            return false; 
        }


        private bool Boardisfull()
        {
            foreach (var button in buttons)
            {
                if (button.Content != null && button.Content.ToString() == "")
                {
                    return false;
                }
            }
            return true;
        }



        private void ComputerTurn()
        {

            Random random = new Random();
            int randomIndex;
            do
            {
                randomIndex = random.Next(1, 10); 
            } while (!buttons[randomIndex - 1].IsEnabled); 

            Button button = buttons[randomIndex - 1];
            button.Content = isPlayerX ? "X" : "O";
            button.IsEnabled = false; 
            if (WinnerCheck())
            {
                string winner = isPlayerX ? "X" : "O";
                MessageBox.Show($"Победил.: {winner}");
                isGameOver = true;
            }
            else if (Boardisfull())
            {
                MessageBox.Show("Игра окончена. Ничья.");
                isGameOver = true;
            }
            else
            {
                isPlayerX = !isPlayerX;
            }
        }
    }
}
