using System;

namespace DigitalLibrary
{
    public class BookView
    {
        public void Show()
        {
            InfoMessage.Show("\n\t<<< ЭЛЕКТРОННАЯ БИБЛИОТЕКА >>>\n");
            Console.WriteLine("Добавить книгу (нажмите 1)");
            Console.WriteLine("Показать список книг по алфавиту (нажмите 2)");
            Console.WriteLine("Редактировать данные книги (нажмите 3)");
            Console.WriteLine("Удалить книгу (нажмите 4)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.bookAddingView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.bookFindingAllView.Show();
                        break;
                    }

                case "3":
                    {
                        Program.bookUpdatingView.Show();
                        break;
                    }

                case "4":
                    {
                        Program.bookDeletingView.Show();
                        break;
                    }
            }
        }
    }
}
