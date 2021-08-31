﻿using System;

namespace DigitalLibrary
{
    public class UserView
    {
        public void Show()
        {
            InfoMessage.Show("\n\t<<< ЭЛЕКТРОННАЯ БИБЛИОТЕКА >>>\n");
            Console.WriteLine("Добавить пользователя (нажмите 1)");
            Console.WriteLine("Показать список пользователей (нажмите 2)");
            Console.WriteLine("Редактировать данные пользователя (нажмите 3)");

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
                        Program.userUpdatingView.Show();
                        break;
                    }
            }
        }
    }
}