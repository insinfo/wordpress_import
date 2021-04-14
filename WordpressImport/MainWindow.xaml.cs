using ExcelDataReader;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WordpressImport
{    
    public partial class MainWindow : Window
    {
        private string imputFile;
        private OpenFileDialog openFileDialog;
        private Rss wordPressXML = null;
        
        public MainWindow()
        {
            openFileDialog = new OpenFileDialog();
            InitializeComponent();
        }
        
        private async void BtnGenFile_Click(object sender, RoutedEventArgs e)
        {
            Process();
        }

        private string Process()
        {
            var count = 0;
            wordPressXML = new Rss();
            using (var stream = File.Open(@"c:\input.xls", FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var listItem = new List<Item>();
                    do
                    {
                        while (reader.Read())
                        {                            
                            var item = new Item();

                            var id = reader.GetValue(0);
                            var dataPublicacao = reader.GetValue(1);
                            var titulo = reader.GetValue(2);
                          
                            var fotoUrl = reader.GetValue(3);
                            var textoNoticia = reader.GetValue(4);
                            var fotoDescrcao = reader.GetValue(5);
                                           
                            if (titulo != null)
                            {
                                var dataPubURL = "02/04/2018";
                                if (dataPublicacao != null)
                                {
                                    dataPubURL = dataPublicacao.ToString();                                    
                                }
                                DateTime myDate1;
                                var isDa = DateTime.TryParseExact(dataPubURL, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault,out myDate1);

                                if (isDa)
                                {
                                    dataPubURL = string.Format("{0:yyyy/MM/dd}", myDate1);
                                }
                                else
                                {
                                    dataPubURL = "2018/04/02";
                                }

                                string pattern = @"(?i)[^0-9a-záéíóúàèìòùâêîôûãõç\s]";

                                var tituloURL = RemoveAccents(titulo.ToString());
                                //remove caracter especial
                                tituloURL = Regex.Replace(tituloURL.Trim(), "[^0-9A-Za-z ,]", "");
                                tituloURL = Regex.Replace(tituloURL, @"\s+", "-");
                                
                                tituloURL = tituloURL.ToLower();

                                Debug.WriteLine(tituloURL);

                                item.Title = titulo.ToString();
                                item.Link = "http://www.riodasostras.rj.gov.br/" + tituloURL+"/";
                                item.Creator = "admin";
                                item.Guid = new Guid()
                                {
                                    IsPermaLink = "false",
                                    Text = "http://www.riodasostras.rj.gov.br/index.php/"
                                    + dataPubURL
                                    + "/"+tituloURL+"/"
                                };
                                item.Description = "";
                                item.Comment_status = "open";
                                item.Ping_status = "open";
                                item.Post_name = titulo.ToString();
                                item.Status = "publish";
                                item.Post_parent = "0";
                                item.Menu_order = "315";
                                item.Post_type = "post";
                                item.Post_password = "";
                                item.Is_sticky = "0";
                                item.Category = new Category2() { Text= "Notícias",Nicename= "noticias",Domain= "category" };
                                }
                            
                            if (textoNoticia != null)
                            {
                                var pho = "";
                                if(fotoUrl != null)
                                {
                                    pho = "<img class='alignnone size-full wp - image - 3104' src='"+ fotoUrl.ToString()+ "' alt=''/>";
                                }
                                
                                item.Encoded = textoNoticia.ToString()+ pho;
                            }

                            if (id != null)
                            {
                                item.Post_id = id.ToString();
                            }

                            var dataPub = "14/09/1987";

                            if (dataPublicacao != null)
                            {
                                dataPub = dataPublicacao.ToString();  
                            }

                            DateTime myDate;
                            var postDate = "2017-01-01 13:00:00";
                            var isDate = DateTime.TryParseExact(dataPub, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.NoCurrentDateDefault, out myDate);
                            if (isDate)
                            {
                                //Mon, 02 Apr 2018 13:16:49 +0000
                                dataPub = string.Format("{0:ddd, dd MMM yyyy hh:mm:ss +0000}", myDate);
                                postDate = string.Format("{0:yyyy-MM-dd hh:mm:ss}", myDate);
                            }
                            else
                            {
                                dataPub = "Mon, 02 Apr 2018 13:16:49 +0000";
                            }
                            Debug.WriteLine(dataPub);

                            item.PubDate = dataPub;
                            item.Post_date = postDate;
                            item.Post_date_gmt = postDate;                                                        
                           
                            if (titulo != null)
                            {
                                listItem.Add(item);
                                var channel = new Channel();
                                channel.Item = listItem;
                                wordPressXML.Channel = channel;
                                count++;
                            }
                            
                            //http://www.riodasostras.rj.gov.br/wp-content/themes/pmro/img/noticias/
                            //http://200.222.101.115/portal2018/wp-content/themes/pmro/img/noticias/
                        }

                    } while (reader.NextResult());
                   
                }
                //Debug.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\out.xml");
                wordPressXML.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\out.xml");
            }

            return "sdf";
        }

        private void BtnInputFile_Click(object sender, RoutedEventArgs e)
        {            
            if (openFileDialog.ShowDialog() == true)
            {
                imputFile = openFileDialog.FileName;             
            }
        }

        private string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
        
}
