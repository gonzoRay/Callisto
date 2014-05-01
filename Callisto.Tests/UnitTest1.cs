using System;
using Callisto.Data;
using Callisto.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Callisto.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IReleaseNoteService releaseNoteService = new ReleaseNoteService();

            var notes = releaseNoteService.GetAllReleaseNotes();
            Assert.IsNotNull(notes);
        }
    }
}
