//Завдання 2

//Створіть програму за шаблоном Console Application.
//Створіть свій контекст синхронізації та перевизначте метод Post.
//Метод Post повинен виконувати отриманий делегат у контексті потоку (примірник класу Thread).
//Дайте потоку, створеному виконання делегату у методі Post, ім'я.
//Встановіть на початку роботи методу Main створений контекст синхронізації.
//Створіть асинхронний метод, який у контексті завдання розраховує факторіал числа через цикл.
//Використовуйте оператор await для очікування завершення цього завдання.
//До і після оператора await виведіть на екран консолі
//в якому id потоку (ManagedThreadId) виконується ця частина,
//ім'я потоку (Name) і чи є потік потоком з пулу (IsThreadPoolThread).
namespace ProfessinalLesson15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
            MethodAsync();
        }

        public static async Task MethodAsync()
        {
            Console.WriteLine($"AsyncMethod from thread {Thread.CurrentThread.ManagedThreadId}; name of thread: {Thread.CurrentThread.Name}. is thread from poolThread? {Thread.CurrentThread.IsThreadPoolThread} before");
            await Task.Run(() => Factorial(5));
            Console.WriteLine($"AsyncMethod from thread {Thread.CurrentThread.ManagedThreadId}; name of thread: {Thread.CurrentThread.Name}. is thread from poolThread? {Thread.CurrentThread.IsThreadPoolThread} after");
        }

        public static void Factorial(int a)
        {

            int result = a--;
            for (int i = 0; i < a; a--)
            {
                result = result * a;
            }
            Console.WriteLine($" method from thread{Thread.CurrentThread.ManagedThreadId} : {Thread.CurrentThread.Name}");
            Console.WriteLine("Factorial"+ result);
        }
    }
}