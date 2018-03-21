using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RainbowPoop.Tests
{
    [TestClass]
    public class EmojiPluginTest
    {

        [TestMethod]
        public void It_inserts_Smiling()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :Smiling:");
            Assert.AreEqual("hello world ☺", result);
        }
    }
}
