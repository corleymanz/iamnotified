using IAmNotified.IAmNotifiedService.Implementation;

namespace IAmNotified.IAmNotifiedService.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            controller.Receive();
        }
    }
}