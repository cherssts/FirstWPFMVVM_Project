using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace TreeView
{
    /// <summary>
    /// A view model for each directory item
    /// </summary>
    public class DirectoryIViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// The Type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        /// <summary>
        /// The full Path
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory item
        /// </summary>

        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : Directory_structure.GetFileFolderName(this.FullPath); } }

        /// <summary>
        /// A lsit of all children contained inside this item
        /// </summary>
        public ObservableCollection<DirectoryIViewModel> Children { get; set; }

        /// <summary>
        /// Indicates if this item can be expanded.
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }



        /// <summary>
        /// Indicates if the current item is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                //If the UI tells us to expand...
                if (value == true)
                    //Find all children
                    Expand();
                //if the UI tells us to close
                else
                    this.ClaerChildren();
            }
        }

        #endregion

        #region Public Commands
        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// The default Constructor
        /// </summary>
        /// <param name="fullPath"> The full path of this item</param>
        /// <param name="type">The type of Item</param>
        public DirectoryIViewModel( string fullPath, DirectoryItemType type)
        {
            //Create commands
            this.ExpandCommand = new RelayCommand(Expand);

            //Set path and type
            this.FullPath = fullPath;
            this.Type = type;

            //Setup the Children as needed
            this.ClaerChildren();
        }
        #endregion

        #region Helper Method
        /// <summary>
        /// Removes all children from the list, adding a dummy item to show the expand icon if required
        /// </summary>
        private void ClaerChildren()
        {
            //Clear Items
            this.Children = new ObservableCollection<DirectoryIViewModel>();

            //Show the expand arrow if we are not a file
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);

        }

        #endregion

        private void Expand()
        {
            if (this.Type == DirectoryItemType.File)
                return;

            //Find all children
            var children = Directory_structure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryIViewModel>
                                (children.Select(content => new DirectoryIViewModel(content.FullPath, content.Type)));

        }
    }
}
