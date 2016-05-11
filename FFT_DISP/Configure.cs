using System.IO;
using System.Text;
using System.Xml;



namespace FFT_DISP
{
    /// <summary>
    /// Класс для работы с конфиг файлом просмотрщика
    /// </summary>
    public class ViewerConfig
    {

        private string configPath = Directory.GetCurrentDirectory() + "\\ViewerConfig.xml";
        /// <summary>
        /// Правильно ли заполнен конфиг и есть ли в нем данные
        /// </summary>
        public bool ConfigHasConfiguration
        {
            get;
            set;
        }
        /// <summary>
        /// Путь до файла
        /// </summary>
        public string FilesPath
        {
            get;
            set;
        }


        /// <summary>
        /// Path to config
        /// </summary>
        /// <returns>Path to config</returns>
        public string GetConfigPath()
        {
            return configPath;
        }

        public ViewerConfig()
        {
            InitConfig();
            // ConfigHasConfiguration = false;

        }

        /// <summary>
        /// Первоначальная конфигурация
        /// </summary>
        private void InitConfig()
        {
            if (File.Exists(GetConfigPath()))
            {
                //parse xml
                ///Temporary!!!!!
                //CreateConfigFile();

                ConfigHasConfiguration = ParseXMLConfig();
                if (!ConfigHasConfiguration)
                {
                    CreateConfigFile();
                }

                ///!!!!!
            }
            else
            {
                ConfigHasConfiguration = false;
                CreateConfigFile();
            }

        }

        private bool ParseXMLConfig()
        {
            XmlDocument XML = new XmlDocument();
            XML.Load(GetConfigPath());
            XmlNode Node = XML.DocumentElement.SelectSingleNode("//PathFiles");
            if (null == Node)
            {
                return false;
            }
            FilesPath = Node.Attributes["Path"].Value;
            if (!File.Exists(FilesPath))
            {
                FilesPath = "";
                return false;
            }
            return true;
        }



        private void CreateConfigFile()
        {
            using (XmlTextWriter XWriter = new XmlTextWriter(GetConfigPath(), Encoding.UTF8))
            {
                XWriter.Formatting = Formatting.Indented;
                XWriter.WriteStartDocument();
                XWriter.WriteStartElement("head");
                XWriter.WriteEndElement();
            }

            XmlDocument XML = new XmlDocument();
            {
                //Load XML CONFIG
                XML.Load(GetConfigPath());
                {
                    //CREATE node
                    XmlNode Node = XML.CreateElement("PathFiles");
                    //Добавили ветку к документу
                    XML.DocumentElement.AppendChild(Node);
                    //Создали атрибут, заполнили его и добавили к ветви
                    XmlAttribute attr = XML.CreateAttribute("Path");
                    //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    //    attr.Value = dialog.SelectedPath;
                    //else
                    attr.Value = "";
                    Node.Attributes.Append(attr);
                }
                //Сохранили все безобразие
                XML.Save(GetConfigPath());
                //CreateWell(XML.BaseURI,"",10);
            }
        }

        /// <summary>
        /// Создает путь до папки с файлами
        /// </summary>
        /// <param name="XMLUri"></param>
        /// <param name="Path"></param>
        public void SetPath(string XMLUri, string Path)
        {
            XmlDocument XML = new XmlDocument();
            XML.Load(XMLUri);
            XmlNode Node = XML.DocumentElement.SelectSingleNode("//PathFiles");
            if (null != Node)
            {

                if (Node.Attributes["Path"].Value != Path)
                {
                    Node.Attributes["Path"].Value = Path;
                    this.FilesPath = Path;
                }
                XML.Save(XMLUri);
            }
        }

    }
    /// <summary>
    /// Класс с полным набором конфигов для БПФ в удобной форме
    /// </summary>
    public class FFTConfig
    {
        public enum FFTFileState
        {
            Binary,
            Float,
            Uint
        }
        /// <summary>
        /// Type of data in file
        /// </summary>
        public FFTFileState FFTType
        {
            get;
            set;
        }
        /// <summary>
        /// Sampling Freq
        /// </summary>
        public int SampleRate
        {
            get;
            set;
        }
        /// <summary>
        /// Number of FFTPoints
        /// </summary>
        public int NumOfPoints
        {
            get;
            set;
        }
        /// <summary>
        /// Conversion start point
        /// </summary>
        public int StartPoint
        { get;
            set;
        }
        /// <summary>
        /// Conversion stop point
        /// </summary>
        public int StopPoint
        {
            get;
            set;
        }
        /// <summary>
        /// Total points in file
        /// </summary>
        public int TotalPoints
        {
            get;
            set;
        }
        /// <summary>
        /// Actualy minimal value of ADC
        /// </summary>
        public float ADCStep
        { get;
            set;
        }
        /// <summary>
        /// Constructor. Defines start parameters
        /// </summary>
        public FFTConfig()
        {
            this.FFTType = FFTFileState.Binary;
            this.SampleRate = 0;
            this.NumOfPoints = 0;
            this.StartPoint = 0;
            this.StopPoint = 0;
            this.TotalPoints = 0;
            this.ADCStep = 1;
        }
        public float GetFreqByHarm(int Harm)
        {
            return (float)(Harm * (float)((float)SampleRate / (float)this.NumOfPoints));
        }
    }
}
