using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WF_VLC
{
    public partial class Form1 : Form
    {
        private VlcControl vlcControl;
        string vlcPath = "";
        private string lastSelectedDevice = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeVlcControl();
        }

        private void InitializeVlcControl()
        {
            vlcControl = new VlcControl();
            vlcControl.Dock = DockStyle.Fill;
            this.Controls.Add(vlcControl);

            var vlcLibDirectory = new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC");

            // Configurar opciones de reproducción
            var options = new string[]
            {
                ":network-caching=300", // Aumentar el buffer de red
                ":file-caching=300",    // Aumentar el buffer de archivo
                ":no-video-title-show", // Ocultar el título del video
                ":no-audio",            // Desactivar audio si no es necesario
                ":rtsp-tcp",              // Usar TCP para transmisiones RTSP

                ":avcodec-hw=dxva2", // Habilitar aceleración por hardware con DXVA2
                ":network-caching=300",
                ":file-caching=300",

                ":verbose=2", // Nivel de verbosidad del log
                ":logfile=vlc_log.txt" // Guardar logs en un archivo
            };

            vlcControl.BeginInit();
            vlcControl.VlcLibDirectory = vlcLibDirectory;
            vlcControl.VlcMediaplayerOptions = options; // Aplicar las opciones
            vlcControl.EndInit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tsbtn_play_Click(object sender, EventArgs e)
        {
            PlayVideo();
        }
        private void PlayVideo()
        {
            // Reproducir un archivo de video
            vlcControl.SetMedia(new Uri(@"C:\Videos\full_REPRO_00.mp4"));
            vlcControl.Play();
        }

        private void tsbtn_stop_Click(object sender, EventArgs e)
        {
            StopVideo();
        }
        private void StopVideo()
        {
            // Detener la reproducción
            vlcControl.Stop();
        }

        private void tsbtn_find_capturadora_Click(object sender, EventArgs e)
        {
            // Valida VLC
            vlcPath = GetVLCPath();

            if (!string.IsNullOrEmpty(vlcPath))
            {
                LoadVideoDevices();
            }
            else
            {
                MessageBox.Show("VLC no está instalado.", "VLC No Instalado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string GetVLCPath()
        {
            string registryPath = @"SOFTWARE\VideoLAN\VLC";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
            {
                if (key != null)
                {
                    object installDir = key.GetValue("InstallDir");
                    if (installDir != null)
                    {
                        return installDir.ToString();
                    }
                }
            }

            return null;
        }
        private void LoadVideoDevices()
        {
            try
            {
                // Ejecutar el comando FFmpeg para obtener los dispositivos de video
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C ffmpeg -list_devices true -f dshow -i dummy 2>&1",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    // Expresión regular para extraer nombres de dispositivos de video
                    Regex regex = new Regex(@"""(.*?)"" \(video\)");
                    MatchCollection matches = regex.Matches(output);

                    ts_cmbDevices.Items.Clear();
                    foreach (Match match in matches)
                    {
                        ts_cmbDevices.Items.Add(match.Groups[1].Value);
                    }

                    if (ts_cmbDevices.Items.Count > 0)
                        ts_cmbDevices.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener dispositivos de video: " + ex.Message);
            }
        }
        private void ts_cmbDevices_DropDownClosed(object sender, EventArgs e)
        {
            if (ts_cmbDevices.Items.Count > 0 && ts_cmbDevices.SelectedItem != null)
            {
                string selectedDevice = ts_cmbDevices.SelectedItem.ToString();

                // Solo ejecutar si el dispositivo seleccionado es diferente al anterior
                if (selectedDevice != lastSelectedDevice)
                {
                    lastSelectedDevice = selectedDevice; // Actualizar el último seleccionado
                    PlayCaptureDevice(selectedDevice);
                }
            }
        }
        private void PlayCaptureDevice(string deviceName)
        {
            //Reproducir la señal de un dispositivo de captura
            string mediaOptions = $":dshow-vdev={deviceName}";

            vlcControl.SetMedia(new Uri("dshow://"), mediaOptions);
            vlcControl.Play();
        }

    }
}
