namespace IAmNotified.IAmNotifiedService.Implementation.Handler
{
    class HandlerFactory
    {
        public IHandler GiveHandler()
        {
            //TOOD : process to give back right handler
            return new MailHandler();
        }
    }

}
