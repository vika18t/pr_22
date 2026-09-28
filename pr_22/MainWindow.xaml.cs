using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pr_22
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<Book> books = new ObservableCollection<Book>();

		Book selectedBook = new Book();

		  public MainWindow()
        {
            InitializeComponent();

            books.Add(new Book { Title = "Война и мир", Author = "Л.Н. Толстой", Cover = "Images/book1.jpg", Count = 2, Taken = 1 });
            books.Add(new Book { Title = "Преступление и наказание", Author = "Ф.М. Достоевский", Cover = "Images/book2.jpg", Count = 1, Taken = 0 });
            books.Add(new Book { Title = "Мастер и Маргарита", Author = "М.А. Булгаков", Cover = "Images/book3.jpg", Count = 3, Taken = 2 });
            books.Add(new Book { Title = "Анна Каренина", Author = "Л.Н. Толстой", Cover = "Images/book4.jpg", Count = 2, Taken = 0 });
            books.Add(new Book { Title = "Идиот", Author = "Ф.М. Достоевский", Cover = "Images/book5.jpg", Count = 3, Taken = 0 });
            books.Add(new Book { Title = "Отцы и дети", Author = "И.С. Тургенев", Cover = "Images/book6.jpg", Count = 1, Taken = 1 });
            books.Add(new Book { Title = "Собачье сердце", Author = "М.А. Булгаков", Cover = "Images/book7.jpg", Count = 2, Taken = 1 });

            BookPanel.ItemsSource = books;
        }

		private void Book_Click(object sender, MouseButtonEventArgs e)
		{
			
			if ((sender as Border).DataContext is Book book)
			{
				selectedBook = book;

				TitleBox.Text = book.Title;
				AuthorBox.Text = book.Author;
				CoverBox.Text = book.Cover;
				CountBox.Text = book.Count.ToString();
				TakenBox.Text = book.Taken.ToString();
				StatusText.Text = book.Status;

				selectedBook = book;
			}
			
		}

		private void RefreshInfo()
		{
			if (selectedBook == null) 
			return;
			CountBox.Text = selectedBook.Count.ToString();
			TakenBox.Text = selectedBook.Taken.ToString();
			StatusText.Text = selectedBook.Status;
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(TitleBox.Text))
			{
				MessageBox.Show("Введите название книги!");
				return;
			}

			int.TryParse(CountBox.Text, out int count);
			int.TryParse(CountBox.Text, out int taken);

			Book newBook = new Book
			{
				Title = TitleBox.Text,
				Author = AuthorBox.Text,
				Cover = CoverBox.Text,
				Count = count,  
				Taken = taken
			};

			books.Add(newBook);
			selectedBook = newBook;
			RefreshInfo();
		}

		private void Del_Click(object sender, RoutedEventArgs e)
		{
			if (selectedBook == null)
			{
				MessageBox.Show("Сначала выберите книгу!");
				return;
			}

			books.Remove(selectedBook);
			selectedBook = null;

			TitleBox.Text = "";
			AuthorBox.Text = "";
			CoverBox.Text = "";
			CountBox.Text = "";
			TakenBox.Text = "";
			StatusText.Text = "";
		}

		private void Give_Click(object sender, RoutedEventArgs e)
		{
			if (selectedBook == null)
			{
				MessageBox.Show("Сначала выберите книгу!");
				return;
			}
			if (selectedBook.Count <= 0)
			{
				MessageBox.Show("Нет книг в наличии!");
				return;
			}

			selectedBook.Count = selectedBook.Count - 1;
			selectedBook.Taken = selectedBook.Taken + 1;
			RefreshInfo();
		}

		private void Return_Click(object sender, RoutedEventArgs e)
		{
			if (selectedBook == null)
			{
				MessageBox.Show("Сначала выберите книгу!");
				return;
			}
			if (selectedBook.Taken <= 0)
			{
				MessageBox.Show("Нет книг на руках!");
				return;
			}

			selectedBook.Taken = selectedBook.Taken - 1;
			selectedBook.Count = selectedBook.Count + 1;
			RefreshInfo();
		}
	}
}
