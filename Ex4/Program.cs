//Завдання 4

//Створіть програму за шаблоном Console Application.
//Створіть контекст синхронізації, який зможе обробляти помилки,
//що виникли в асинхронних методах з типом void, що повертається.
//Встановіть створений контекст синхронізації та
//перевірте виклик асинхронного методу з типом void,
//чи обробляється ваша помилка в контексті. Встановіть контекст синхронізації.
//Зробіть висновки щодо використання асинхронних методів з типом void.
namespace Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new ConsoleSynchronizationContext());

            AsyncMethod("Vlad");
            SynchronizationContext.Current.Send(m =>
            {
                Method(m);
            }, "Andrey");

        }
        public static void Method(object name)
        {
            Console.WriteLine($"Name is :{name as string}");
            //return new string($"Name is :{name}");
            Console.WriteLine(Thread.CurrentThread.Name);
            throw new NotImplementedException();
        }

        public static async void AsyncMethod(string name)
        {
            Task task = new Task(() => Method(name));
            task.Start();
            await task;
            throw new Exception();
        }
    }
}