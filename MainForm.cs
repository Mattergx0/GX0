using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using FileTaggerApp.Models;

namespace FileTaggerApp
{
    public partial class MainForm : Form
    {
        private List<FolderItem> folders = new List<FolderItem>();
        private List<FileItem> files = new List<FileItem>();

        private const string FolderDataFile = "Data/folders.json";
        private const string FileDataFile = "Data/files.json";

        public MainForm()
        {
            InitializeComponent();
            LoadData();
            UpdateFolderList();
        }

        private void LoadData()
        {
            if (File.Exists(FolderDataFile))
            {
                var json = File.ReadAllText(FolderDataFile);
                folders = JsonSerializer.Deserialize<List<FolderItem>>(json) ?? new List<FolderItem>();
            }

            if (File.Exists(FileDataFile))
            {
                var json = File.ReadAllText(FileDataFile);
                files = JsonSerializer.Deserialize<List<FileItem>>(json) ?? new List<FileItem>();
            }
        }

        private void SaveData()
        {
            Directory.CreateDirectory("Data");
            File.WriteAllText(FolderDataFile, JsonSerializer.Serialize(folders, new JsonSerializerOptions { WriteIndented = true }));
            File.WriteAllText(FileDataFile, JsonSerializer.Serialize(files, new JsonSerializerOptions { WriteIndented = true }));
        }

        // Voeg nieuw mapje toe
        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            string folderName = txtNewFolderName.Text.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Vul een naam in voor het mapje.");
                return;
            }

            if (folders.Any(f => f.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Dit mapje bestaat al.");
                return;
            }

            folders.Add(new FolderItem { Id = Guid.NewGuid().ToString(), Name = folderName });
            SaveData();
            UpdateFolderList();
            txtNewFolderName.Clear();
        }

        // Toon mapjes in ListBox
        private void UpdateFolderList()
        {
            listBoxFolders.Items.Clear();
            foreach (var f in folders)
                listBoxFolders.Items.Add(f.Name);

            if (listBoxFolders.Items.Count > 0)
                listBoxFolders.SelectedIndex = 0;
        }

        // Wanneer mapje geselecteerd wordt, toon bestanden
        private void listBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFileList();
        }

        // Toon bestanden van geselecteerde map
        private void UpdateFileList()
        {
            listBoxFiles.Items.Clear();
            var selectedFolder = GetSelectedFolder();
            if (selectedFolder == null) return;

            var filesInFolder = files.Where(f => f.FolderId == selectedFolder.Id);

            foreach (var file in filesInFolder)
            {
                listBoxFiles.Items.Add($"{file.Name} [{string.Join(", ", file.Tags ?? Array.Empty<string>())}]");
            }
        }

        // Helper: haal geselecteerd mapje op
        private FolderItem GetSelectedFolder()
        {
            if (listBoxFolders.SelectedIndex < 0) return null;
            string name = listBoxFolders.SelectedItem.ToString();
            return folders.FirstOrDefault(f => f.Name == name);
        }

        // Voeg bestand toe aan geselecteerd mapje
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var selectedFolder = GetSelectedFolder();
            if (selectedFolder == null)
            {
                MessageBox.Show("Selecteer eerst een mapje.");
                return;
            }

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileItem = new FileItem()
                {
                    Id = Guid.NewGuid().ToString(),
                    FolderId = selectedFolder.Id,
                    FilePath = dlg.FileName,
                    Name = Path.GetFileName(dlg.FileName),
                    Tags = txtFileTags.Text.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                };
                files.Add(fileItem);
                SaveData();
                UpdateFileList();
                txtFileTags.Clear();
            }
        }

        // Optioneel: bestanden openen op dubbelklik
        private void listBoxFiles_DoubleClick(object sender, EventArgs e)
        {
            var selectedIndex = listBoxFiles.SelectedIndex;
            var selectedFolder = GetSelectedFolder();
            if (selectedIndex < 0 || selectedFolder == null) return;

            var filesInFolder = files.Where(f => f.FolderId == selectedFolder.Id).ToList();
            if (selectedIndex >= filesInFolder.Count) return;

            var file = filesInFolder[selectedIndex];
            if (File.Exists(file.FilePath))
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(file.FilePath) { UseShellExecute = true });
            else
                MessageBox.Show("Bestand bestaat niet meer op de originele locatie.");
        }
    }
}
