using System.Threading.Tasks;
using System.Windows;

namespace Ex5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<int> task = new Task<int>(() => Addition(2, 3));
            task.Start();
            await task.ConfigureAwait(true);
            int result = await task;
            Text1.Text = result.ToString();

        }

        public int Addition(int a, int b)
        {
            return a + b;
        }
    }
}
