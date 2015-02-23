using IAmNotified.IAmNotifiedService.Implementation;

namespace IAmNotified.IAmNotifiedService.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Receive();
        }
    }
}
