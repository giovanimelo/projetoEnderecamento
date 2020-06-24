namespace WebService.Controllers
{
    public class MyDialog
    {
        public enum DialogType : short
        {
            Info = 0,
            Success = 1,
            Warning = 2,
            Error = 3
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public DialogType @Type { get; set; }

        public override string ToString() => $"{{ \"title\": \"{Title}\", \"content\": \"{Content}\", \"type\": \"{@Type.ToString().ToLower()}\" }}";
    }
}