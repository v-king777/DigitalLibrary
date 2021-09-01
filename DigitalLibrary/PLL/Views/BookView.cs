using System;

namespace DigitalLibrary
{
    public class BookView
    {
        public void Show()
        {
            InfoMessage.Show("\n\t<<< ЭЛЕКТРОННАЯ БИБЛИОТЕКА >>>\n");
            Console.WriteLine("Добавить книгу (введите 1)");
            Console.WriteLine("Поиск книг по жанру и дате (введите 2)");
            Console.WriteLine("Показать список всех книг по алфавиту (введите 3)");
            Console.WriteLine("Показать полное описание книги (введите 4)");
            Console.WriteLine("Показать последнюю вышедшую книгу (введите 5)");
            Console.WriteLine("Показать количество книг определённого автора (введите 6)");
            Console.WriteLine("Показать количество книг определённого жанра (введите 7)");
            Console.WriteLine("Выдать книгу на руки пользователю (введите 8)");
            Console.WriteLine("Вернуть книгу в библиотеку (введите 9)");
            Console.WriteLine("Редактировать данные книги (введите 10)");
            Console.WriteLine("Удалить книгу (введите 11)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.bookAddingView.Show();
                        break;
                    }

                case "2":
                    {
                        Program.bookFindingByGenreAndYearView.Show();
                        break;
                    }

                case "3":
                    {
                        Program.bookFindingAllView.Show();
                        break;
                    }

                case "4":
                    {
                        Program.bookFullDescriptionView.Show();
                        break;
                    }

                case "5":
                    {
                        Program.bookFindingLastYearView.Show();
                        break;
                    }

                case "6":
                    {
                        Program.bookCountingByAuthorView.Show();
                        break;
                    }

                case "7":
                    {
                        Program.bookCountingByGenreView.Show();
                        break;
                    }

                case "8":
                    {
                        Program.bookHandOveringView.Show();
                        break;
                    }

                case "9":
                    {
                        Program.bookReturningView.Show();
                        break;
                    }

                case "10":
                    {
                        Program.bookUpdatingView.Show();
                        break;
                    }

                case "11":
                    {
                        Program.bookDeletingView.Show();
                        break;
                    }
            }
        }
    }
}
