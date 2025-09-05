# how-to-filter-.net-maui-SfTreeView
This repository demonstrates how to implement filtering in the .NET MAUI TreeView (SfTreeView) control. It provides a sample implementation that uses a SearchBar and custom behavior to filter and display TreeView nodes based on user input, supporting both root and child node filtering for a dynamic and responsive user experience.

## Sample

### XAML

```xaml
<ContentPage.Behaviors>
    <local:Behavior/>
</ContentPage.Behaviors>
<Grid RowDefinitions="50,*">
    <SearchBar Placeholder="Search to filter" Grid.Row="0" x:Name="searchBar"/>
    <syncfusion:SfTreeView x:Name="treeView" Grid.Row="1"
                           ChildPropertyName="SubFiles" 
                           ItemTemplateContextType="Node"  
                           NotificationSubscriptionMode="CollectionChange"
                           AutoExpandMode="AllNodesExpanded" 
                           ItemsSource="{Binding ImageNodeInfo}">
        ...
    </syncfusion:SfTreeView>
</Grid>
```

### Behavior

```csharp
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
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements).

Make sure that you have the compatible versions of [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/ ) with the Dot NET MAUI workload and [.NET Core SDK 7.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) or later version in your machine before starting to work on this project.

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.
