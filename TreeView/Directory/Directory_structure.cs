using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeView
{
    /// <summary>
    /// A helper clas to query information about directories
    /// </summary>
    public static class Directory_structure
    {
        /// <summary>
        /// Gets all logical drives from the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
           //Get every drive on the computer
           return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();

        }

        /// <summary>
        /// Gets the directories top- level content
        /// </summary>
        /// <param name="fullpath">The full path to the directory</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullpath)
        {
            var items =  new List<DirectoryItem>();
            #region Get Folders

            //Try and get diretories form the folder
            //ignoring any ussyes doing so
            try
            {
                var directoryPath = Directory.GetDirectories(fullpath);

                if (directoryPath.Length > 0)
                {
                    items.AddRange(directoryPath.Select(directoryPath => new DirectoryItem{FullPath = directoryPath, Type = DirectoryItemType.Folder}));
                }
            }
            catch { }

            #endregion

            #region Get Files

            //Try and get diretories form the files
            //ignoring any ussyes doing so
            try
            {
                var fs = Directory.GetFiles(fullpath);

                if (fs.Length > 0)
                {
                    items.AddRange(fs.Select(file => new DirectoryItem {FullPath = file , Type = DirectoryItemType.File}));
                }
            }
            catch { }

            return items;
            #endregion
        }

        #region Helpers
        /// <summary>
        /// Dind the file or Folder name from full path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            //If we have no path. return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            var normalizedPath = path.Replace('/', '\\');

            //Find the last backlash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            //If we dont find a balcklash, return the path it self
            if (lastIndex <= 0)
            {
                return path;
            }
            //return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }
        #endregion
    }
}
