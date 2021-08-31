namespace DigitalLibrary
{
    class Program
    {
        static MainView mainView;
        static UserService userService;
        static BookService bookService;
        public static UserView userView;
        public static BookView bookView;
        public static UserAddingView userAddingView;
        public static BookAddingView bookAddingView;
        public static UserFindingAllView userFindingAllView;
        public static BookFindingAllView bookFindingAllView;
        public static UserUpdatingView userUpdatingView;

        static void Main(string[] args)
        {
            mainView = new MainView();
            userService = new UserService();
            bookService = new BookService();
            userView = new UserView();
            bookView = new BookView();
            userAddingView = new UserAddingView(userService);
            bookAddingView = new BookAddingView(bookService);
            userFindingAllView = new UserFindingAllView(userService);
            bookFindingAllView = new BookFindingAllView(bookService);
            userUpdatingView = new UserUpdatingView(userService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}
