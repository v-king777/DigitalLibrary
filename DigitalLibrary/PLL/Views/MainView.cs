using System;

namespace DigitalLibrary
{
    public class MainView
    {
        public void Show()
        {
            InfoMessage.Show("\n\t<<< ЭЛЕКТРОННАЯ БИБЛИОТЕКА >>>\n");
            Console.WriteLine("Для работы с пользователями введите 1");
            Console.WriteLine("Для работы с книгами введите 2");
            
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.userView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.bookView.Show();
                        break;
                    }
            }
        }
    }
}
