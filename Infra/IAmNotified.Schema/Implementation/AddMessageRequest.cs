namespace IAmNotified.Schema
{
    public class AddMessageRequest
    {
        private string AppId { get; set; }
        private string Quename { get; set; }
        private string Message { get; set; }
        private string MessageType { get; set; }
    }
}
