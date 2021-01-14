using CSHTGT.Data.Models;
using CSHTGT.Service.IService;
using CSHTGT.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.UnitTest.ServiceTest
{
    [TestClass]
    class LoaiPhuongTienServiceTest
    {
        private Mock<ILoaiPhuongTienService> _mockloaiPhuongTienService;
        private List<LoaiPhuongTien> listLoaiPhuongTien;
        
        [TestInitialize]
        public void Initialize()
        {
            _mockloaiPhuongTienService = new Mock<ILoaiPhuongTienService>();
            

        }
        [TestMethod]
        public void LoaiPhuongTien_Service_GetAll()
        {
           
        }
        [TestMethod]
        public void LoaiPhuongTien_Service_Create()
        {
            
        }
    }
}
