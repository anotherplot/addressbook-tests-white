using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_auto_white
{
    public class ApplicationManager
    {
        private AutoItX3.Interop.AutoItX3 aux;
        private GroupHelper _groupHelper;
        public static string WINTITLE = "Free Address Book";

        public ApplicationManager()
        {
            Application app = Application.Launch(@"C:\Users\oimez\Downloads\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);
            _groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public Window MainWindow { get; }

        public GroupHelper Groups => _groupHelper;
    }
}