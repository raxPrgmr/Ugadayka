using System;
using System.Collections.Generic;
using System.Text;

namespace Ugadayka
{
    class ClassGame
    {

        // Текущее значение жизни
        private int counter;

        public int Counter
        {
            get
            {
                return counter;
            }
            private set
            {
                counter = value;
            }
        }


        // Состояние запуска игры
        private bool isGameStart = false;

        public bool IsGameStart
        {
            get
            {
                return isGameStart;
            }
            private set
            {
                isGameStart = value;
            }
        }

        // Если победа
        private bool isWin = false;

        // Если проигрыш
        private bool isLose = false;

        // Кол-во жизней
        private int lives;

        public int Lives
        {
            get
            {
                return lives;
            }
            set
            {
                lives = value;
            }
        }

        // Задуманное число
        private int desired;

        public int Desired
        {
            get
            {
                return desired;
            }
            private set
            {
                desired = value;
            }
        }

        public ClassGame(int lives)
        {
            Lives = lives;
        }

        private void LiveDown()
        {
            counter--;
            if (counter < 0)
                counter = 0;
        }

        private void GenerateNumber()
        {
            Random rnd = new Random();
            Desired = rnd.Next(1, 10);
        }

        public void StartGame()
        {
            counter = Lives;
            GenerateNumber();
            isGameStart = true;
            isWin = false;
            isLose = false;
        }

        public void NextStep(int val)
        {
            if(val != Desired)
            {
                LiveDown();

                if(counter == 0)
                {
                    isGameStart = false;
                    isLose = true;
                }
            }
            else
            {
                isGameStart = false;
                isWin = true;
            }
        }


        public int checkGameStatus()
        {
            int code = 0;

            if(isWin)
            {
                code = 1;
            }
            else if(isLose)
            {
                code = 2;
            }
            else if(isGameStart)
            {
                code = 3;
            }

            return code;
        }
    }
}
