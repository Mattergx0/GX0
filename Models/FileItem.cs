namespace FileTaggerApp.Models
{
    public class FileItem
    {
        public string Id { get; set; }
        public string FolderId { get; set; }
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string[] Tags { get; set; }
    }
}
