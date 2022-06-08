

using System.Collections.ObjectModel;
using System.Linq;

namespace TreeView
{

    /// <summary>
    /// The view model for the application main directory view
    /// </summary>
    public class DirectoryStructureViewModel : BaseViewModel
    {

        #region Public Properties
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryIViewModel> Item { get; set; }


        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            var children = Directory_structure.GetLogicalDrives();
            this.Item = new ObservableCollection<DirectoryIViewModel>(children.Select(drive => new DirectoryIViewModel(drive.FullPath, DirectoryItemType.Drive)));
        }

        #endregion
    }
}
