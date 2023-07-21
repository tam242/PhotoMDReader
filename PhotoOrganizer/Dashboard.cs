using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Dapper;
using System.Configuration;

namespace PhotoOrganizer
{
    public partial class Dashboard : Form
    {
        List<Photo> photos = DbAccess.GetPhotos();
        ImageList images = new ImageList();
        int i = 0;
        List<Image> loadedImages = new List<Image>();

        public Dashboard()
        {
            InitializeComponent();
            photoView.SizeMode = PictureBoxSizeMode.StretchImage;
            images.ImageSize = new Size(128, 72);


            foreach (Photo photo in photos)
            {
                Image photoFile = Image.FromFile(photo.path);
                images.Images.Add(photoFile);
                loadedImages.Add(photoFile);

                photosListView.LargeImageList = images;
                photosListView.Items.Add(new ListViewItem(photo.imageName, i));
                i += 1;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Images (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.JPG;*.JPEG;*.PNG;*.GIF;*.BMP";
            openFileDialog1.Multiselect = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xDoc = new XmlDocument();
                List<string> pathsList = new List<string>();
                foreach (Photo photo in photos)
                {
                    pathsList.Add(photo.path);
                }

                foreach (string fileName in openFileDialog1.FileNames)
                {
                    Photo photo = new Photo();
                    if (!pathsList.Contains(fileName))
                    {

                        photo.path = fileName;
                        photo.dateTaken = Photo.GetDateTakenFromImage(fileName);
                        photo.imageName = Path.GetFileName(fileName);

                        //Latitude Longitude (Have to replace , with . for api)
                        string Lat = Photo.GetLatitude(fileName).ToString().Replace(",", ".");
                        string Long = Photo.GetLongitude(fileName).ToString().Replace(",", ".");

                        //Gmaps geocoding api gets city name from latitude longitude (if not unknown)
                        if (Lat != "unknown" && Long != "unknown")
                        {
                            xDoc.Load("https://maps.googleapis.com/maps/api/geocode/xml?latlng=" + Lat + "," + Long +
                                ConfigurationManager.AppSettings.Get("gmapsApiKey"));
                            XmlNodeList xNodelst = xDoc.GetElementsByTagName("result");
                            XmlNode xNode = xNodelst.Item(0);
                            photo.location = xNode.ChildNodes[4].SelectSingleNode("long_name").InnerText;
                        }
                        else
                        {
                            photo.location = "Unknown location";
                        }

                        //idk
                        photos.Add(photo);
                        DbAccess.InsertPhoto(photo);

                        Image photoFile = Image.FromFile(photo.path);
                        images.Images.Add(photoFile);
                        loadedImages.Add(photoFile);
                        photosListView.LargeImageList = images;
                        photosListView.Items.Add(new ListViewItem(photo.imageName, i));
                        i += 1;

                    }
                }
            }
        }

        private void photosListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (photosListView.SelectedIndices.Count > 0)
            {
                var selectedIndex = photosListView.SelectedIndices[0];
                Image selectedImage = loadedImages[selectedIndex];
                photoView.Image = selectedImage;

                foundPhotosLb.Items.Clear();
                foundPhotosLb.Items.Add(photos[selectedIndex].path);
                foundPhotosLb.Items.Add(photos[selectedIndex].location);
                if (photos[selectedIndex].dateTaken != DateTime.Parse("1801.01.01. 00:01")) 
                {
                    foundPhotosLb.Items.Add(photos[selectedIndex].dateTaken);
                }
                else
                {
                    foundPhotosLb.Items.Add("Unknown date");
                }
                foundPhotosLb.Items.Add(photos[selectedIndex].imageName);
                if (photos[selectedIndex].people  != null)
                {
                    peopleTextBox.Text = photos[selectedIndex].people;
                }
                else
                {
                    peopleTextBox.Text = photos[selectedIndex].people;
                }
            }
        }

        private void addPeopleBtn_Click(object sender, EventArgs e)
        {
            if (photosListView.SelectedIndices.Count > 0)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PhotoOrgDB")))
                {
                    photos[photosListView.SelectedIndices[0]].people = peopleTextBox.Text;
                    connection.Execute("dbo.AddPeople @path, @people", photos[photosListView.SelectedIndices[0]]);
                }
            }
        }

        private void sortListView_Click(object sender, EventArgs e)
        {
            string LFPeople = LFPeopleTB.Text;
            string LFLoc = LFLocTB.Text;
            DateTime LFDateB;
            DateTime LFDateA;
            DateTime godhelpme;
            if (DateTime.TryParse(LFDateBTB.Text, out godhelpme))
            {
                LFDateB = godhelpme;
            }
            else
            {
                LFDateB = DateTime.Parse("1800.01.01.");
            }
            if (DateTime.TryParse(LFDateATB.Text, out godhelpme))
            {
                LFDateA = godhelpme;
            }
            else
            {
                LFDateA = DateTime.Parse("9999.01.01.");
            }

            photosListView.Items.Clear();
            images.Images.Clear();
            loadedImages.Clear();
            i = 0;

            foreach (Photo photo in photos)
            {
                if ((photo.dateTaken == DateTime.Parse("1801.01.01. 00:01") || photo.dateTaken > LFDateB) && 
                    photo.dateTaken < LFDateA && 
                    (LFPeople == "" || LFPeople == photo.people) && 
                    (LFLoc == "" || LFLoc == photo.location))
                {
                    Image photoFile = Image.FromFile(photo.path);
                    images.Images.Add(photoFile);
                    loadedImages.Add(photoFile);

                    photosListView.LargeImageList = images;
                    photosListView.Items.Add(new ListViewItem(photo.imageName, i));
                    i += 1;
                }
            };
        }

        private void exportDbAsXml_Click(object sender, EventArgs e)
        {
            DataTable datatable = DbAccess.PullData();
            datatable.TableName = "Photo";
            datatable.WriteXml("..\\..\\..\\..\\Photos.Xml");

        }
    }
}
