namespace _0._0.DataTransfer.DtoAdditional
{
    public class DtoMessage
    {
        public List<string> listMessage { get; set; }
        public string type { get; set; }

        public DtoMessage()
        {
            listMessage = new();
            error();
        }

        public bool existsMessage()
        {
            return listMessage.Count > 0;
        }

        public void success()
        {
            type = "success";
        }

        public void warning()
        {
            type = "warning";
        }

        public void error()
        {
            type = "error";
        }

        public void exception()
        {
            type = "exception";
        }
    }
}
