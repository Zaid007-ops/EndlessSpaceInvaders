using System.Windows.Forms;
using EndlessSpaceInvasion;

var dataStoreService = new DataStoreService();

Application.Run(new MainMenu(dataStoreService));
