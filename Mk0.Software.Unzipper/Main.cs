using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Mk0.Software.Unzipper.Properties;

namespace Mk0.Software.Unzipper
{
    public partial class Main : Form
    {
        private BackgroundWorker _backgroundWorker;
        readonly StringBuilder _logBuilder = new StringBuilder();

        private string zipfile, targetdir;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            _logBuilder.AppendLine(DateTime.Now.ToString("F"));
            _logBuilder.AppendLine();
            _logBuilder.AppendLine("Unzipper mit folgenden Kommandozeilenparametern gestartet.");

            string[] args = Environment.GetCommandLineArgs();
            for (var index = 0; index < args.Length; index++)
            {
                var arg = args[index];
                _logBuilder.AppendLine($"[{index}] {arg}");
            }

            _logBuilder.AppendLine();

            if (args.Length >= 3)
            {
                labelInformation.Visible = true;
                progressBar.Visible = true;
                Extract(args);
            }
            else
            {
                //manuell entpacken
            }
        }

        private void Extract(string[] args)
        {
            // Extract all the files.
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.DoWork += (o, eventArgs) =>
            {
                foreach (var process in Process.GetProcesses())
                {
                    try
                    {
                        if (process.MainModule.FileName.Equals(args[2]))
                        {
                            _logBuilder.AppendLine("Warte auf das Ende des Applikationsprozesses...");

                            _backgroundWorker.ReportProgress(0, "Warte auf das Beenden der Applikation...");
                            process.WaitForExit();
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.Message);
                    }
                }

                _logBuilder.AppendLine("BackgroundWorker erfolgreich gestartet.");

                var path = Path.GetDirectoryName(args[2]);

                // Open an existing zip file for reading.
                ZipStorer zip = ZipStorer.Open(args[1], FileAccess.Read);

                // Read the central directory collection.
                List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

                _logBuilder.AppendLine($"Insgesamt {dir.Count} Dateien und Ordner im ZIP-File gefunden.");

                for (var index = 0; index < dir.Count; index++)
                {
                    if (_backgroundWorker.CancellationPending)
                    {
                        eventArgs.Cancel = true;
                        zip.Close();
                        return;
                    }

                    ZipStorer.ZipFileEntry entry = dir[index];
                    zip.ExtractFile(entry, Path.Combine(path, entry.FilenameInZip));
                    string currentFile = string.Format(Resources.CurrentFileExtracting, entry.FilenameInZip);
                    int progress = (index + 1) * 100 / dir.Count;
                    _backgroundWorker.ReportProgress(progress, currentFile);

                    _logBuilder.AppendLine($"{currentFile} [{progress}%]");
                }

                zip.Close();
            };

            _backgroundWorker.ProgressChanged += (o, eventArgs) =>
            {
                progressBar.Value = eventArgs.ProgressPercentage;
                labelInformation.Text = eventArgs.UserState.ToString();
            };

            _backgroundWorker.RunWorkerCompleted += (o, eventArgs) =>
            {
                try
                {
                    if (eventArgs.Error != null)
                    {
                        throw eventArgs.Error;
                    }

                    if (!eventArgs.Cancelled)
                    {
                        labelInformation.Text = @"Fertig";
                        try
                        {
                            ProcessStartInfo processStartInfo = new ProcessStartInfo(args[2]);
                            if (args.Length > 3)
                            {
                                processStartInfo.Arguments = args[3];
                            }

                            Process.Start(processStartInfo);

                            _logBuilder.AppendLine("Applikation erfolgreich gestartet.");
                        }
                        catch (Win32Exception exception)
                        {
                            if (exception.NativeErrorCode != 1223)
                            {
                                throw;
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    _logBuilder.AppendLine();
                    _logBuilder.AppendLine(exception.ToString());

                    MessageBox.Show(exception.Message, exception.GetType().ToString(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _logBuilder.AppendLine();
                    Application.Exit();
                }
            };

            _backgroundWorker.RunWorkerAsync();
        }

        private void ExtractGUI(string zipfile, string targetdir)
        {
            // Extract all the files.
            _backgroundWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            _backgroundWorker.DoWork += (o, eventArgs) =>
            {
                _logBuilder.AppendLine("BackgroundWorker erfolgreich gestartet.");

                var path = targetdir;

                // Open an existing zip file for reading.
                ZipStorer zip = ZipStorer.Open(zipfile, FileAccess.Read);

                // Read the central directory collection.
                List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

                _logBuilder.AppendLine($"Insgesamt {dir.Count} Dateien und Ordner im ZIP-File gefunden.");

                for (var index = 0; index < dir.Count; index++)
                {
                    if (_backgroundWorker.CancellationPending)
                    {
                        eventArgs.Cancel = true;
                        zip.Close();
                        return;
                    }

                    ZipStorer.ZipFileEntry entry = dir[index];
                    zip.ExtractFile(entry, Path.Combine(path, entry.FilenameInZip));
                    string currentFile = string.Format(Resources.CurrentFileExtracting, entry.FilenameInZip);
                    int progress = (index + 1) * 100 / dir.Count;
                    _backgroundWorker.ReportProgress(progress, currentFile);

                    _logBuilder.AppendLine($"{currentFile} [{progress}%]");
                }

                zip.Close();
            };

            _backgroundWorker.ProgressChanged += (o, eventArgs) =>
            {
                progressBar.Value = eventArgs.ProgressPercentage;
                labelInformation.Text = eventArgs.UserState.ToString();
            };

            _backgroundWorker.RunWorkerCompleted += (o, eventArgs) =>
            {
                try
                {
                    if (eventArgs.Error != null)
                    {
                        throw eventArgs.Error;
                    }

                    if (!eventArgs.Cancelled)
                    {
                        labelInformation.Text = @"Fertig";
                    }
                }
                catch (Exception exception)
                {
                    _logBuilder.AppendLine();
                    _logBuilder.AppendLine(exception.ToString());

                    MessageBox.Show(exception.Message, exception.GetType().ToString(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    _logBuilder.AppendLine();
                    DialogResult res = MessageBox.Show("Alles entpackt." + Environment.NewLine + "Wollen sie ein neues ZIP entpacken?", "Unzipper ist fertig", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(res == DialogResult.Yes)
                    {
                        labelInformation.Visible = false;
                        progressBar.Visible = false;
                        buttonSelectZip.Visible = true;
                        buttonTargetDir.Enabled = false;
                        buttonTargetDir.Visible = true;
                        buttonExtract.Enabled = false;
                        buttonExtract.Visible = true;
                        zipfile = "";
                        targetdir = "";
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            };

            _backgroundWorker.RunWorkerAsync();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _backgroundWorker?.CancelAsync();

            _logBuilder.AppendLine();
            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Unzipper.log"), _logBuilder.ToString());
        }

        private void ButtonSelectZip_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                buttonTargetDir.Enabled = true;
                zipfile = openFileDialog.FileName;
                labelZipFile.Text = "ZIP: " + Path.GetFileName(zipfile);
                labelZipFile.Visible = true;
            }
            else
            {
                zipfile = "";
                targetdir = "";
                buttonTargetDir.Enabled = false;
                labelZipFile.Visible = false;
                labelTarget.Visible = false;
            }
            buttonExtract.Enabled = false;
        }

        private void ButtonTargetDir_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog.ShowDialog();
            if(res == DialogResult.OK)
            {
                buttonExtract.Enabled = true;
                targetdir = folderBrowserDialog.SelectedPath;
                labelTarget.Text = "entpacken nach " + targetdir;
                labelTarget.Visible = true;
            }
            else
            {
                buttonExtract.Enabled = false;
                targetdir = "";
                labelTarget.Visible = false;
            }
        }

        private void ButtonExtract_Click(object sender, EventArgs e)
        {
            buttonSelectZip.Visible = false;
            buttonTargetDir.Visible = false;
            buttonExtract.Visible = false;
            labelZipFile.Visible = false;
            labelTarget.Visible = false;
            labelInformation.Visible = true;
            progressBar.Visible = true;
            ExtractGUI(zipfile, targetdir);
        }
    }
}
