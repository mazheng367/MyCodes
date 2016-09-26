using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkNet.Common.Model;
using LinkNet.Model;
using Newtonsoft.Json;

namespace ConsoleApplication1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetCompilerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GenDbFieldTest()
        {
            var fileStream = File.OpenRead(@"C:\Users\mazhe\documents\visual studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\新建文本文档.txt");
            string str = null;
            using (StreamReader sr = new StreamReader(fileStream, Encoding.UTF8))
            {
                str = sr.ReadToEnd();
            }
            fileStream.Close();
            fileStream.Dispose();


            DBField field = new DBField();

            var o = JsonConvert.DeserializeObject<List<DBEntity>>(str);
          
        }
    }
}