using Transliteration.Tools;

namespace Transliteration.Managers
{
    /// <summary>
    /// Singleton manager used to help with navigation betwean controls
    /// </summary>
    public class NavigationManager
    {
        #region static
        /// <summary>
        /// This field is used only in lock to synchronize threads
        /// </summary>
        private static readonly object Lock = new object();
        /// <summary>
        /// Singelton Object of a manager
        /// </summary>
        private static NavigationManager _instance;
        
        /// <summary>
        /// Singelton Object of a manager
        /// </summary>
        public static NavigationManager Instance
        {
            get
            {
                //If object is already initialized, then return it
                if (_instance != null)
                    return _instance;
                //Lock operator for threads synchrnization, in case few threads 
                //will try to initialize Instance at the same time
                lock (Lock)
                {
                    //Initialize Singleton instance and return its object
                    return _instance = new NavigationManager();
                }
            }
        } 
        #endregion
        /// <summary>
        /// Current NavigationModel field
        /// </summary>
        private NavigationModel _navigationModel;
        /// <summary>
        /// This methos is used to switch to another navigation model
        /// </summary>
        /// <param name="navigationModel">New NavigationModel</param>
        public void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }
        /// <summary>
        /// This method performs switch betwean different controls
        /// </summary>
        /// <param name="mode">Enum value of corresponding control</param>
        public void Navigate(ModesEnum mode)
        {
            //If _navigationModel is null, nothing will happen
            _navigationModel?.Navigate(mode);
        }

    }
}
