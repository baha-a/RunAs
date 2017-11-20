using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Ionic.Zip;
using runner;


namespace ExeGenerator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            LoadBackgroundImg();
            LoadData();
        }

        private Bitmap backgroundImg;
        private void LoadBackgroundImg()
        {
            try { backgroundImg = new Bitmap(StreamEmbeddedResource("Resource.img.jpg")); } catch { }
        }
        private static Stream StreamEmbeddedResource(string fileName)
        {
            var type = typeof(Program);
            return 
                type
                .Assembly
                .GetManifestResourceStream(type.Namespace + "." + fileName);
        }

        private void LoadData()
        {
            try
            {
                var config = File.ReadAllLines(Setting.ConfigFile);

                for (int i = 3; i < config.Length; i++)
                {
                    if (string.IsNullOrEmpty(config[i]))
                        continue;

                    tbxCommands.Text += config[i] + "\r\n";
                }

                tbxUsername.Text = config[0].Substring(config[0].IndexOf("\\") + 1);
                tbxDomain.Text = config[0].Substring(0, config[0].IndexOf("\\"));
                tbxIncludeFolder.Text = config[2];
                tbxPassword.Text = StringCipher.Decrypt(config[1], Setting.Password);
            }
            catch
            {

            }
        }


        //private string[] selectedContentFolder;
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            //CommonOpenFileDialog dialog = new CommonOpenFileDialog
            //{
            //    AllowNonFileSystemItems = true,
            //    EnsurePathExists = true,
            //    EnsureFileExists = true,
            //    Multiselect = true,
            //    IsFolderPicker = true,
            //    Title = "Select Items"
            //};

            //if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            //{
            //    selectedContentFolder = dialog.FileNames.ToArray();
            //}

            FolderBrowserDialog f = new FolderBrowserDialog();
            if (f.ShowDialog() != DialogResult.OK)
                return;
            //selectedContentFolder = new []{ f.SelectedPath };
            tbxIncludeFolder.Text = f.SelectedPath;
        }

        private  void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateTextBox() == false)
                return;

            SaveFileDialog save = new SaveFileDialog
            {
                FileName = "RunMe.exe",
                Filter = @"Self Extracted|*.exe|All Files|*.*"
            };
            if (save.ShowDialog() != DialogResult.OK)
                return;

            progressBar.Visible = true;
            btnSave.Enabled = false;
            btnSelectFolder.Enabled = false;
            CreateSelfExtractedFile(tbxIncludeFolder.Text, save.FileName, () =>
            {
                MessageBox.Show("Done", "Success");
                Close();
            });
        }

        private bool ValidateTextBox()
        {
            if (string.IsNullOrEmpty(tbxUsername.Text) ||
                string.IsNullOrEmpty(tbxPassword.Text) ||
                string.IsNullOrEmpty(tbxDomain.Text))
            {
                MessageBox.Show("username, password or domain name missing","Error");
                return false;
            }

            if (IsIncludeFolderValid() == false)
            {
                MessageBox.Show("selected IncludeFolder Path not found", "Error");
                return false;
            }
                
            return true;
        }

        private bool IsIncludeFolderValid()
        {
            return string.IsNullOrEmpty(tbxIncludeFolder.Text) 
                || (!string.IsNullOrEmpty(tbxIncludeFolder.Text) && Directory.Exists(tbxIncludeFolder.Text));
        }

        public delegate void CallBack();
        private void CreateSelfExtractedFile(string path, string savefile, CallBack afterFinish)
        {
            new Thread(() =>
            {
                using (var zip = new ZipFile())
                {
                    zip.AlternateEncoding = Encoding.UTF8;
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.None;
                    zip.AddEntry("Runner.exe", new FileStream("Runner.exe", FileMode.Open, FileAccess.Read));
                    zip.AddEntry(Setting.ConfigFile, ConfigData());

                    //if(paths != null)
                    //    foreach (var path in paths)
                    //    {
                    //        if (File.Exists(path))
                    //            zip.AddFile(path, "");
                    //        else
                    //            zip.AddDirectory(path, path.Replace(Path.GetDirectoryName(path), ""));
                    //    }

                    if (string.IsNullOrEmpty(path) == false)
                        zip.AddDirectory(path, path.Replace(Path.GetDirectoryName(path), ""));

                    zip.ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently;
                    zip.Comment = "by Bahaa in ITech - 2017-11-16";
                    zip.SaveProgress += zip_SaveProgress;

                    string extractedPath = CreateSharedTempFolder();
                    zip.SaveSelfExtractor(savefile, new SelfExtractorSaveOptions
                    {
                        Flavor = SelfExtractorFlavor.ConsoleApplication,
                        ExtractExistingFile = ExtractExistingFileAction.OverwriteSilently,
                        DefaultExtractDirectory = extractedPath,
                        PostExtractCommandLine = extractedPath + "runner.exe",
                        RemoveUnpackedFilesAfterExecute = true,
                        //Quiet = true,
                    });
                }

                afterFinish();
            })
            {
                IsBackground = true
            }.Start();
        }

        private string ConfigData()
        {
            return tbxDomain.Text + "\\" + tbxUsername.Text + "\r\n" +
                   StringCipher.Encrypt(tbxPassword.Text, Setting.Password) + "\r\n" +
                   tbxIncludeFolder.Text + "\r\n" +
                   QutotionIt(tbxCommands.Text);
        }

        private string QutotionIt(string p)
        {
            var lines = p.Split('\n');
            string res = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(" "))
                {
                    if (lines[i].StartsWith("\"") == false)
                        lines[i] = "\"" + lines[i];

                    if (lines[i].EndsWith("\"") == false)
                        lines[i] = lines[i] + "\"";
                }

                res += lines[i] + "\r\n";
            }

            return res;
        }


        void zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_AfterWriteEntry)
                progressBar.Value = (int)(e.EntriesSaved * 100.0 / e.EntriesTotal * 1.0);
        }
        private string CreateSharedTempFolder()
        {
            return "c:\\temp\\" + Path.GetRandomFileName() + "\\";
        }



        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (backgroundImg == null)
                return;

            var x = ClientRectangle;
            x.X -= 100;
            x.Y -= 100;
            x.Width += 200;
            x.Height += 200;
            e.Graphics.DrawImage(backgroundImg, x);
        }

        private void saveConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Setting.ConfigFile, ConfigData());
        }

        private void btnClearIncludeFolder_Click(object sender, EventArgs e)
        {
            tbxIncludeFolder.Text = "";
        }
    }
}
