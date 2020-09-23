using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_auto_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (var item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupsDialogue(dialogue);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        private Window OpenGroupsDialogue()
        {
            _manager.MainWindow.Get<Button>("groupButton").Click();
            return _manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public void Remove(int index)
        {
            Window dialogue = OpenGroupsDialogue();
            InitGroupRemoving(dialogue, index);
            SubmitGroupRemoving();
            CloseGroupsDialogue(dialogue);
        }

        private void SubmitGroupRemoving()
        {
            _manager.MainWindow.Get<Button>("uxOKAddressButton").Click();
        }

        private void InitGroupRemoving(Window dialogue, int index)
        {
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            var item = tree.Nodes[0].Nodes[index];
            
            item.Click();

            _manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
        }
    }
}