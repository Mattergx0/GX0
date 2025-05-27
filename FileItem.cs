namespace FileTaggerApp.Models
{
    public class FileItem
    {
        public string Id { get; set; } // Uniek id
        public string FolderId { get; set; } // Mapje waarin dit bestand hoort
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string[] Tags { get; set; }
    }
}
