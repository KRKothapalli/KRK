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

        [TestMethod]
        public void It_Still_Inserts_Smiling_When_Upper_Case()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :SMILING:");
            Assert.AreEqual("hello world ☺", result);
        }

        [TestMethod]
        public void It_Still_Inserts_Smiling_When_Lower_Case()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :smiling:");
            Assert.AreEqual("hello world ☺", result);
        }

        [TestMethod]
        public void It_Should_Not_Insert_Smiling_When_Left_Colon_Missing()
        {
            var result = EmojiPlugin.InsertEmoji("hello world Smiling:");
            Assert.AreEqual("hello world Smiling:", result);
        }

        [TestMethod]
        public void It_Should_Not_Insert_Smiling_When_Right_Colon_Missing()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :Smiling");
            Assert.AreEqual("hello world :Smiling", result);
        }

        [TestMethod]
        public void It_Should_Drop_The_Smiley_Tag_Since_There_Is_No_Smiley_Available()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :Smiley:");
            Assert.AreEqual("hello world ", result);
        }

        [TestMethod]
        public void It_Should_Insert_Nothing_If_There_Are_Only_Colons()
        {
            var result = EmojiPlugin.InsertEmoji("hello world ::");
            Assert.AreEqual("hello world ", result);
        }

        [TestMethod]
        public void It_Inserts_Smiling_And_Hibiscus()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :Smiling::Hibiscus:");
            Assert.AreEqual("hello world ☺🌺", result);
        }

        [TestMethod]
        public void It_Inserts_Hibiscus_And_Smiling_At_The_Specified_Locations()
        {
            var result = EmojiPlugin.InsertEmoji(":Hibiscus:hello world :Smiling:");
            Assert.AreEqual("🌺hello world ☺", result);
        }

        [TestMethod]
        public void It_Should_Not_Insert_Smiling_If_Name_Split_In_To_Multiple_Words()
        {
            var result = EmojiPlugin.InsertEmoji("hello world :Smil ing:");
            Assert.AreEqual("hello world :Smil ing:", result);
        }
    }
}
