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
        public static BookUpdatingView bookUpdatingView;
        public static UserDeletingView userDeletingView;
        public static BookDeletingView bookDeletingView;
        public static BookHandOveringView bookHandOveringView;
        public static BookReturningView bookReturningView;
        public static UserBooksCountingView userBooksCountingView;
        public static BookFindingByGenreAndYearView bookFindingByGenreAndYearView;
        public static BookFindingLastYearView bookFindingLastYearView;
        public static BookCountingByAuthorView bookCountingByAuthorView;
        public static BookCountingByGenreView bookCountingByGenreView;
        public static BookFullDescriptionView bookFullDescriptionView;

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
            bookUpdatingView = new BookUpdatingView(bookService);
            userDeletingView = new UserDeletingView(userService);
            bookDeletingView = new BookDeletingView(bookService);
            bookHandOveringView = new BookHandOveringView(bookService);
            bookReturningView = new BookReturningView(bookService);
            userBooksCountingView = new UserBooksCountingView(userService);
            bookFindingByGenreAndYearView = new BookFindingByGenreAndYearView(bookService);
            bookFindingLastYearView = new BookFindingLastYearView(bookService);
            bookCountingByAuthorView = new BookCountingByAuthorView(bookService);
            bookCountingByGenreView = new BookCountingByGenreView(bookService);
            bookFullDescriptionView = new BookFullDescriptionView(bookService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}
