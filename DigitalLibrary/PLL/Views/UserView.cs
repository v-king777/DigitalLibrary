using System;

namespace DigitalLibrary
{
    public class UserView
    {
        public void Show()
        {
            InfoMessage.Show("\n\t<<< ЭЛЕКТРОННАЯ БИБЛИОТЕКА >>>\n");
            Console.WriteLine("Добавить пользователя (введите 1)");
            Console.WriteLine("Показать список всех пользователей по алфавиту (введите 2)");
            Console.WriteLine("Показать количество книг у пользователя (введите 3)");
            Console.WriteLine("Редактировать данные пользователя (введите 4)");
            Console.WriteLine("Удалить пользователя (введите 5)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.userAddingView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.userFindingAllView.Show();
                        break;
                    }

                case "3":
                    {
                        Program.userBooksCountingView.Show();
                        break;
                    }

                case "4":
                    {
                        Program.userUpdatingView.Show();
                        break;
                    }

                case "5":
                    {
                        Program.userDeletingView.Show();
                        break;
                    }

                
            }
        }
    }
}
