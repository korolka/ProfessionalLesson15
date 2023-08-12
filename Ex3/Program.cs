//Завдання 3

//Створіть програму за шаблоном Console Application.
//Візьміть попередній приклад (Завдання 2), не прибираючи/не змінюючи контекст синхронізації,
//виконайте продовження оператора await в контексті робочого потоку пула потоків.
using ProfessinalLesson15;
namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());
            MethodAsync();
        }

        public static async Task MethodAsync()
        {
            Console.WriteLine($"AsyncMethod from thread {Thread.CurrentThread.ManagedThreadId}; name of thread: {Thread.CurrentThread.Name}. is thread from poolThread? {Thread.CurrentThread.IsThreadPoolThread} before");
            await Task.Run(() => Factorial(5)).ContinueWith((a) =>
            {
                Console.WriteLine($"AsyncMethod from thread {Thread.CurrentThread.ManagedThreadId}; name of thread: {Thread.CurrentThread.Name}. is thread from poolThread? {Thread.CurrentThread.IsThreadPoolThread} after");
            });

            
        }

        public static void Factorial(int a)
        {

            int result = a--;
            for (int i = 0; i < a; a--)
            {
                result = result * a;
            }
            Console.WriteLine($" method from thread{Thread.CurrentThread.ManagedThreadId} : {Thread.CurrentThread.Name}");
            Console.WriteLine("Factorial" + result);
        }
    }
}