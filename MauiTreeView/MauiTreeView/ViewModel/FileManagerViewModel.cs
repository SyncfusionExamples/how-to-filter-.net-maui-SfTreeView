using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace MauiTreeView
{
    public class FileManagerViewModel:INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<FileManager> imageNodeInfo;

        #endregion

        #region Constructor

        public FileManagerViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<FileManager> ImageNodeInfo
        {
            get{ return imageNodeInfo; }
            set{ this.imageNodeInfo = value;RaisedOnPropertyChanged("ImageNodeInfo"); }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            var nodeImageInfo = new ObservableCollection<FileManager>();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var doc = new FileManager() { ItemName = "Documents", ImageIcon = "treeview_folder.png"};
            var download = new FileManager() { ItemName = "Downloads", ImageIcon = "treeview_folder.png" };
            var mp3 = new FileManager() { ItemName = "Music", ImageIcon = "treeview_folder.png" };
            var pictures = new FileManager() { ItemName = "Pictures", ImageIcon = "treeview_folder.png"  };
            var video = new FileManager() { ItemName = "Videos", ImageIcon = "treeview_folder.png"  };

            var pollution = new FileManager() { ItemName = "Environmental Pollution.docx", ImageIcon = "treeview_word.png"  };
            var globalWarming = new FileManager() { ItemName = "Global Warming.ppt", ImageIcon = "treeview_ppt.png"  };
            var sanitation = new FileManager() { ItemName = "Sanitation.docx", ImageIcon = "treeview_word.png"  };
            var socialNetwork = new FileManager() { ItemName = "Social Network.pdf", ImageIcon = "treeview_pdf.png"  };
            var youthEmpower = new FileManager() { ItemName = "Youth Empowerment.pdf", ImageIcon = "treeview_pdf.png"  };

            var games = new FileManager() { ItemName = "Game.exe", ImageIcon = "treeview_exe.png"  };
            var tutorials = new FileManager() { ItemName = "Tutorials.zip", ImageIcon = "treeview_zip.png"  };
            var typeScript = new FileManager() { ItemName = "TypeScript.7z", ImageIcon = "treeview_zip.png"  };
            var uiGuide = new FileManager() { ItemName = "UI-Guide.pdf", ImageIcon = "treeview_pdf.png"  };

            var song = new FileManager() { ItemName = "Gouttes", ImageIcon = ".treeview_mp3.png"  };

            var camera = new FileManager() { ItemName = "Camera Roll", ImageIcon = "treeview_folder.png"  };
            var stone = new FileManager() { ItemName = "Stone.jpg", ImageIcon = "treeview_png.png"  };
            var wind = new FileManager() { ItemName = "Wind.jpg", ImageIcon = "treeview_png.png"  };

            var img0 = new FileManager() { ItemName = "WIN_20160726_094117.JPG", ImageIcon = "treeview_img0.png"  };
            var img1 = new FileManager() { ItemName = "WIN_20160726_094118.JPG", ImageIcon = "treeview_img1.png"  };

            var video1 = new FileManager() { ItemName = "Naturals.mp4", ImageIcon = "treeview_video.png"  };
            var video2 = new FileManager() { ItemName = "Wild.mpeg", ImageIcon = "treeview_video.png"  };

            doc.SubFiles = new ObservableCollection<FileManager>
            {
                pollution,
                globalWarming,
                sanitation,
                socialNetwork,
                youthEmpower
            };

            download.SubFiles = new ObservableCollection<FileManager>
            {
                games,
                tutorials,
                typeScript,
                uiGuide
            };

            mp3.SubFiles = new ObservableCollection<FileManager>
            {
                song
            };

            pictures.SubFiles = new ObservableCollection<FileManager>
            {
                camera,
                stone,
                wind
            };
            camera.SubFiles = new ObservableCollection<FileManager>
            {
                img0,
                img1
            };

            video.SubFiles = new ObservableCollection<FileManager>
            {
                video1,
                video2
            };

            nodeImageInfo.Add(doc);
            nodeImageInfo.Add(download);
            nodeImageInfo.Add(mp3);
            nodeImageInfo.Add(pictures);
            nodeImageInfo.Add(video);
            imageNodeInfo = nodeImageInfo;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}