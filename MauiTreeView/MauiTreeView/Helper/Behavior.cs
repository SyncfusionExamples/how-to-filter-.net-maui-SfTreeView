using Syncfusion.Maui.TreeView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MauiTreeView
{
    public class Behavior : Behavior<ContentPage>
    {
        #region Fields

        SearchBar SearchBar;
        SfTreeView TreeView;
        FileManagerViewModel ViewModel;
        List<FileManager> FilteredSource;
        #endregion

        #region Overrrides

        protected override void OnAttachedTo(ContentPage bindable)
        {
            SearchBar = bindable.FindByName<SearchBar>("searchBar");
            TreeView = bindable.FindByName<SfTreeView>("treeView");

            ViewModel = bindable.BindingContext as FileManagerViewModel;
            FilteredSource = new List<FileManager>();

            SearchBar.TextChanged += SearchBar_TextChanged;

            base.OnAttachedTo(bindable);
        }

        #endregion

        #region Events
        
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                TreeView.ItemsSource = ViewModel.ImageNodeInfo;
            }
            else
            {
                FilteredSource = ViewModel.ImageNodeInfo.Where(x => (x.ItemName.ToLower()).StartsWith(e.NewTextValue.ToLower())).ToList<FileManager>();


                if (FilteredSource.Count == 0)
                {
                    foreach (var node in ViewModel.ImageNodeInfo)
                        this.GetChildNode(node, e.NewTextValue);
                }
                
                TreeView.ItemsSource = FilteredSource;
            }
        }

        private void GetChildNode(FileManager node, string searchText)
        {
            if (node.SubFiles.Count < 0) return;

            foreach (var child in node.SubFiles)
            {
                if (child.ItemName.ToLower().StartsWith(searchText.ToLower()))
                {
                    FilteredSource.Add(child);
                }
                if (child.SubFiles != null)
                {
                    this.GetChildNode(child, searchText);
                }
            }
        }
        #endregion
    }
}
