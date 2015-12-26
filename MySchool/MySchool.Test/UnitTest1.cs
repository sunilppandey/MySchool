using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySchool.Model.Entities;
using MySchool.Shared;
using MySchool.Data;

namespace MySchool.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanAddComboList()
        {
            var createdDate = DateTime.Now;
            var obj = new ComboList
            {
                CTComboListId = 1,
                ListDesc = "Board Name",
                CreatedBy = Constant.ANONYMOUS,
                CreatedDate = createdDate
            };
            var context = new ApplicationDbContext();
            
        }
    }
}
