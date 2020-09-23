using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_auto_white
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count==1)
            {
                app.Groups.Add(new GroupData(){Name = "newnew"});
                oldGroups = app.Groups.GetGroupList();
            }
            
            app.Groups.Remove(0);
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups,newGroups);
        }
    }
}