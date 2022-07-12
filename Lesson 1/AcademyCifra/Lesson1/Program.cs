namespace Lesson1
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Как Вас зовут?");
            string? name = Console.ReadLine();
            Console.WriteLine($"Доброго времени суток \n {name}");
            Console.ReadKey();
        }
    }

}