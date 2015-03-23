

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading;
using ProyectoIA.Lib;
using System.Drawing.Imaging;

namespace ProyectoIA
{
    public partial class RedNeuronal : Form
    {

        private NeuralNetwork<string> NeuralNet = null;


        private Dictionary<string, double[]> SetEntrenamiento = null;
        private int av_imgH = 0;
        private int av_imgW = 0;
        private int numeroPatrones = 0;
        

        private delegate bool TrainingCallBack();
        private delegate void ReconocimientoRedPatron(Bitmap ImagenAbuscar, Bitmap Imgbusqueda  , int estado);
        private AsyncCallback LlamadaAsincrona = null;
        private IAsyncResult res = null;
        private ManualResetEvent ResetManual = null;

        private DateTime DTStart;
        private string ruta = "";
        private string err = "";
        private string Eunidad = "";
        private string Sunidad = "";
        private string Nunidad = "";
        private string Mascara = "";
        private string[] ImgDirecciones;
        private Bitmap ImgAbuscar;
        private List<Bitmap> ImgBits = new List<Bitmap>();
        private System.Threading.Thread hilo;

        public RedNeuronal()
        {
            InitializeComponent();
            InitializeSettings();

            GenerarSetEntrenamiento();
            CrearRedNeural();
            
            LlamadaAsincrona = new AsyncCallback(EntrenamientoCompleto);
            ResetManual = new ManualResetEvent(false);
        }

        private void ReconocimientoRedPatronEnRed(Bitmap ImagenAbuscar,Bitmap Imgbusqueda , int estado)
        {
            bool Comparar = ComparadorDeImagen(ImagenAbuscar, Imgbusqueda);
            if (!Comparar)
            {
                pictureBoxImgLocalizando.Image = Imgbusqueda;
            }
            if (estado == 1)
            {
                try
                {
                    pictureBoxImgLocalizando.Image = ImagenAbuscar;
                    hilo.Abort();
                }
                catch { }
            }
            //pictureBoxImgLocalizando.Image = (Bitmap) Imgbusqueda;
        }

        public static bool ComparadorDeImagen(System.Drawing.Bitmap IMG1, System.Drawing.Bitmap IMG2)
        {
            MemoryStream ms = new MemoryStream();
            IMG1.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String I1 = Convert.ToBase64String(ms.ToArray());
            ms.Position = 0;

            IMG2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            String I2 = Convert.ToBase64String(ms.ToArray());
            
            if (I1.Equals(I2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        void neuralNetwork_IterationChanged(object o, NeuralEventArgs args)
        {
            UpdateError(args.CurrentError);
            UpdateIteration(args.CurrentIteration);            

            if (ResetManual.WaitOne(0, true))
                args.Stop = true;
        }     
           
        private void buttonTrain_Click(object sender, EventArgs e)
        {

            SetBotones(false);
            ResetManual.Reset();

            TrainingCallBack TR = new TrainingCallBack(NeuralNet.Train);
            res = TR.BeginInvoke(LlamadaAsincrona, TR);
            DTStart = DateTime.Now;
            timer1.Start();
            try
            {
                t = 0;
                hilo = new Thread(delegate()
                {
                    ReconocimientoRedPatron patron__ = new ReconocimientoRedPatron(ReconocimientoRedPatronEnRed);
                    while (true)
                    {
                        for (int i = 0; i < ImgBits.Count; i++)
                        {
                            Bitmap bit = ImgBits[i];
                            try
                            {
                                this.Invoke(patron__, new object[] { ImgAbuscar, bit , t});
                            }
                            catch { }
                            System.Threading.Thread.Sleep(20);
                        }
                    }
                });
                hilo.Start();
            }
            catch { }
        }

        private void EntrenamientoCompleto(IAsyncResult result)
        { 
            if(result.AsyncState is TrainingCallBack)
            {
                TrainingCallBack TR = (TrainingCallBack)result.AsyncState;
                bool isSuccess = TR.EndInvoke(res);
                SetBotones(true);
                timer1.Stop();
                t = 1;
            }
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            string MatchedHigh = "?", MatchedLow = "?";
            double OutputValueHight = 0, OutputValueLow = 0;

            double[] input = ProcesamientoImagen.ToMatrix(drawingPanel1.ImageOnPanel,
                av_imgH, av_imgW);

            NeuralNet.Recognize(input, ref MatchedHigh, ref OutputValueHight,
                ref MatchedLow, ref OutputValueLow);

            ShowRecognitionResults(MatchedHigh, MatchedLow, OutputValueHight, OutputValueLow);

        }

        private void ShowRecognitionResults(string EncontradoMasAlto, string EncontradoMasBajo, double SalidaAlta, double SalidaBaja)
        {
            labelMatchedHigh.Text = "Alto: " + EncontradoMasAlto + " (%" + ((int)100 * SalidaAlta).ToString("##") + ")";
            labelMatchedLow.Text = "Bajo: " + EncontradoMasBajo + " (%" + ((int)100 * SalidaBaja).ToString("##") + ")";

            pictureBoxEntrada.Image = new Bitmap(drawingPanel1.ImageOnPanel,
                pictureBoxEntrada.Width, pictureBoxEntrada.Height);

            if (EncontradoMasAlto != "?")
                pictureBoxAlto.Image = new Bitmap(new Bitmap(ruta + "\\" + EncontradoMasAlto + ".bmp"),
                    pictureBoxAlto.Width, pictureBoxAlto.Height);

            if (EncontradoMasBajo != "?")
                pictureBoxBajo.Image = new Bitmap(new Bitmap(ruta + "\\" + EncontradoMasBajo + ".bmp"),
                    pictureBoxBajo.Width, pictureBoxBajo.Height);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            drawingPanel1.Clear();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "Imagen mapa de bits (*.bmp)|*.bmp";
            FD.InitialDirectory = ruta;

            if (FD.ShowDialog() == DialogResult.OK)
            {
                string FileName = FD.FileName;
                if (Path.GetExtension(FileName) == ".bmp")
                {
                    textBoxBrowse.Text = FileName;
                    ImgAbuscar = new Bitmap(new Bitmap(FileName), drawingPanel1.Width, drawingPanel1.Height);
                    drawingPanel1.ImageOnPanel = ImgAbuscar;
                }
            }
            FD.Dispose();

        }

        private void buttonTrainingBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FD = new FolderBrowserDialog();
            FD.SelectedPath = ruta;

            if (FD.ShowDialog() == DialogResult.OK)
            {
                ruta = FD.SelectedPath;
            }
            FD.Dispose();
        }

        private void GenerarSetEntrenamiento()
        {

            ImgBits = new List<Bitmap>();
            ImgDirecciones = Directory.GetFiles(ruta, "*.bmp");
            SetEntrenamiento = new Dictionary<string, double[]>(ImgDirecciones.Length);
            foreach (string s in ImgDirecciones)
            {
                Bitmap Temp = new Bitmap(s);
                ImgBits.Add(new Bitmap(new Bitmap(s), drawingPanel1.Width, drawingPanel1.Height));
                SetEntrenamiento.Add(Path.GetFileNameWithoutExtension(s),
                    ProcesamientoImagen.ToMatrix(Temp, av_imgH, av_imgW));
                Temp.Dispose();
            }

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
           

            string[] Images = Directory.GetFiles(ruta, "*.bmp");
            numeroPatrones = Images.Length;

            av_imgH = 0;
            av_imgW = 0;

            foreach (string s in Images)
            {
                Bitmap Temp = new Bitmap(s);
                av_imgH += Temp.Height;
                av_imgW += Temp.Width;
                Temp.Dispose();
            }
            av_imgH /= numeroPatrones;
            av_imgW /= numeroPatrones;

            int networkInput = av_imgH * av_imgW;


            Sunidad = numeroPatrones.ToString();


            cmdreconocer.Enabled = false;

            GenerarSetEntrenamiento();
            CrearRedNeural();
        }

        private void InitializeSettings()
        {
            

            try
            {
                NameValueCollection AppSettings = ConfigurationManager.AppSettings;

                Mascara = (Int16.Parse(AppSettings["NCapas"]) - 1).ToString();
                ruta = Path.GetFullPath(AppSettings["DirPatrones"]);
                err = AppSettings["MaxError"];

                string[] Images = Directory.GetFiles(ruta, "*.bmp");
                numeroPatrones = Images.Length;

                av_imgH = 0;
                av_imgW = 0;

                foreach (string s in Images)
                {
                    Bitmap Temp = new Bitmap(s);
                    av_imgH += Temp.Height;
                    av_imgW += Temp.Width;
                    Temp.Dispose();
                }
                av_imgH /= numeroPatrones;
                av_imgW /= numeroPatrones;

                int networkInput = av_imgH * av_imgW;

                Eunidad = ((int)((double)(networkInput + numeroPatrones) * .33)).ToString();
                Nunidad = ((int)((double)(networkInput + numeroPatrones) * .11)).ToString();
                Sunidad = numeroPatrones.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error iniciando... " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearRedNeural()
        {
            if (SetEntrenamiento == null)
                throw new Exception("No se pudo entrenar la red neuronal ... ");

            if (int.Parse(Mascara) == 0)
            {

                NeuralNet = new NeuralNetwork<string>
                    (new BP1Layer<string>(av_imgH * av_imgW, numeroPatrones), SetEntrenamiento);

            }
            else if (int.Parse(Mascara) == 1)
            {
                int InputNum = Int16.Parse(Eunidad);

                NeuralNet = new NeuralNetwork<string>
                    (new BP2Layer<string>(av_imgH * av_imgW, InputNum, numeroPatrones), SetEntrenamiento);

            }
            else if (int.Parse(Mascara) == 2)
            {
                int InputNum = Int16.Parse(Eunidad);
                int HiddenNum = Int16.Parse(Nunidad);

                NeuralNet = new NeuralNetwork<string>
                    (new BP3Layer<string>(av_imgH * av_imgW, InputNum, HiddenNum, numeroPatrones), SetEntrenamiento);

            }

            NeuralNet.IterationChanged +=
                new NeuralNetwork<string>.IterationChangedCallBack(neuralNetwork_IterationChanged);

            NeuralNet.MaximumError = Double.Parse(err);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            ResetManual.Set();
        }

        int t = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan TSElapsed = DateTime.Now.Subtract(DTStart);
            UpdateTimer(TSElapsed.Hours.ToString("D2") + ":" +
                TSElapsed.Minutes.ToString("D2") + ":" +
                TSElapsed.Seconds.ToString("D2"));
           /* if (t == (ImgBits.Count - 1))
            {
                t = 0;
            }
            else
            {
                ReconocimientoRedPatronEnRed(ImgAbuscar, ImgBits[t]);
                t++;
            }*/
        }



        private delegate void UpdateUI(object o);
        private void SetBotones(object o)
        {

            if (buttonStop.InvokeRequired)
            {
                buttonStop.Invoke(new UpdateUI(SetBotones), o);
            }
            else
            {
                bool b = (bool)o;
                buttonStop.Enabled = !b;
                cmdreconocer.Enabled = b;
                cmdentrenar.Enabled = b;
            }
        }
        private void UpdateError(object o)
        {
            if (labelError.InvokeRequired)
            {
                labelError.Invoke(new UpdateUI(UpdateError), o);
            }
            else
            {
                labelError.Text = "Error: " + ((double)o).ToString(".###");
            }
        }
        private void UpdateIteration(object o)
        {
            if (labelIteration.InvokeRequired)
            {
                labelIteration.Invoke(new UpdateUI(UpdateIteration), o);
            }
            else
            {
                labelIteration.Text = "Iteracion: " + ((int)o).ToString();
            }
        }


        private void UpdateTimer(object o)
        {
            if (labelTimer.InvokeRequired)
            {
                labelTimer.Invoke(new UpdateUI(UpdateTimer), o);
            }
            else
            {
                labelTimer.Text = (string)o;
            }
        }
       

        private void Neural_Load(object sender, EventArgs e)
        {
         
            textBoxBrowse.Enabled = true;
            buttonBrowse.Enabled = true;
            drawingPanel1.Enabled = false;
        }
                    
      
    }
}