using System;

namespace DigitalLibrary
{
    public class BookView
    {
        public void Show()
        {
            InfoMessage.Show("\n\t<<< ЭЛЕКТРОННАЯ БИБЛИОТЕКА >>>\n");
            Console.WriteLine("Добавить книгу (нажмите 1)");
            Console.WriteLine("Показать список всех книг по алфавиту (нажмите 2)");
            Console.WriteLine("Показать список книг по жанру и дате (нажмите 3)");
            Console.WriteLine("Редактировать данные книги (нажмите 4)");
            Console.WriteLine("Удалить книгу (нажмите 5)");
            Console.WriteLine("Выдать книгу на руки пользователю (нажмите 6)");
            Console.WriteLine("Вернуть книгу в библиотеку (нажмите 7)");

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
                        Program.bookFindingByGenreAndYearView.Show();
                        break;
                    }

                case "4":
                    {
                        Program.bookUpdatingView.Show();
                        break;
                    }

                case "5":
                    {
                        Program.bookDeletingView.Show();
                        break;
                    }

                case "6":
                    {
                        Program.bookHandOveringView.Show();
                        break;
                    }

                case "7":
                    {
                        Program.bookReturningView.Show();
                        break;
                    }
            }
        }
    }
}
