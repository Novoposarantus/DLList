﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoublyLinkingListLibrary;
using System.Collections.Generic;

namespace TestDoublyLinking
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateNewList()
        {
            var dlLits = new DoublyLinkingList<int>(4);
            Assert.AreEqual(4, dlLits[0]);
        }
        [TestMethod]
        public void TestAddToHead()
        {
            var dlLits = new DoublyLinkingList<int>(1);
            dlLits.AddToHead(0);
            Assert.AreEqual(0, dlLits[0]);
            Assert.AreEqual(1, dlLits[1]);
        }
        [TestMethod]
        public void TestAddToEnd()
        {
            var dlLits = new DoublyLinkingList<int>(0);
            dlLits.AddToEnd(1);
            Assert.AreEqual(0, dlLits[0]);
            Assert.AreEqual(1, dlLits[1]);
        }
        [TestMethod]
        public void TestGoForwardForThreeSteps()
        {
            var dlLits = new DoublyLinkingList<int>(0,1,2,3,4);
            dlLits.ChangeCurrent(3);
            Assert.AreEqual(3, dlLits.Current);
        }
        [TestMethod]
        public void TestGoForwardForOneStep()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.ChangeCurrent();
            Assert.AreEqual(1, dlLits.Current);
        }
        [TestMethod]
        public void TestGoBackForThreeSteps()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.GoToEnd();
            dlLits.ChangeCurrent(-3);
            Assert.AreEqual(1, dlLits.Current);
        }
        [TestMethod]
        public void TestGoBackForOneStep()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.GoToEnd();
            dlLits.ChangeCurrent(-1);
            Assert.AreEqual(3, dlLits.Current);
        }
        [TestMethod]
        [ExpectedException(typeof(MoveExeption),
                "Error. Go to Null.")]
        public void TestGoBackOutOfRange()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.ChangeCurrent(-2);
        }
        [TestMethod]
        [ExpectedException(typeof(MoveExeption),
                "Error. Go to Null.")]
        public void TestGoForwardOutOfRange()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.GoToEnd();
            dlLits.ChangeCurrent(2);
        }
        [TestMethod]
        public void TestGetLength()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            Assert.AreEqual(5, dlLits.Length);
        }
        [TestMethod]
        public void TestGoToEnd()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.GoToEnd();
            Assert.AreEqual(4, dlLits.Current);
        }
        [TestMethod]
        public void TestGoToHead()
        {
            var dlLits = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlLits.GoToHead();
            Assert.AreEqual(0, dlLits.Current);
        }
        [TestMethod]
        public void TestAddBeforeSelected()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlList.ChangeCurrent(2);
            dlList.AddBeforeSelected(6);
            Assert.AreEqual(6, dlList[2]);
        }
        [TestMethod]
        public void TestAddBeforeSelectedHead()
        {
            var dlList = new DoublyLinkingList<int>(1);
            try
            {
                dlList.AddBeforeSelected(4);
            }
            catch (NullReferenceException)
            {
                Assert.AreEqual(1, 2);
            }
            Assert.AreEqual(4, dlList[0]);
            Assert.AreEqual(1, dlList[1]);
        }
        [TestMethod]
        public void TestDeleteHead()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlList.DeleteCurrent();
            Assert.AreEqual(1, dlList[0]);
        }
        [TestMethod]
        public void TestDeleteEnd()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlList.GoToEnd();
            dlList.DeleteCurrent();
            Assert.AreEqual(3, dlList[dlList.Length - 1]);
        }
        [TestMethod]
        public void TestDeleteSelected()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlList.ChangeCurrent(2);
            dlList.DeleteCurrent();
            Assert.AreEqual(3, dlList[2]);
        }
        [TestMethod]
        public void DeleteWithontElement()
        {
            var dlList = new DoublyLinkingList<int>(1);
            dlList.DeleteCurrent();
            Assert.AreEqual(0, dlList.Length);
        }
        [TestMethod]
        public void TestForEachAll()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            int i = 0;
            foreach (var value in dlList.AsEnumerable(false))
            {
                Assert.AreEqual(dlList[i++], value);

            }
        }
        [TestMethod]
        public void TestForEachAllReverse()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            int i = dlList.Length;
            foreach (var value in dlList.AsEnumerable(true))
            {
                Assert.AreEqual(dlList[--i], value);

            }
        }
        [TestMethod]
        public void TestParams()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4, 5);
            for (int i = 0; i < dlList.Length; ++i)
            {
                Assert.AreEqual(i, dlList[i]);
            }
        }
        [TestMethod]
        public void TestZeroParams()
        {
            var dlList = new DoublyLinkingList<int>();
            Assert.AreEqual(0, dlList.Length);
        }
        [TestMethod]
        public void TestAddToNullList()
        {
            var dlList = new DoublyLinkingList<int>();
            dlList.AddToHead(4);
            dlList.AddToEnd(5);
            Assert.AreEqual(4, dlList.Current);
            Assert.AreEqual(4, dlList[0]);
            Assert.AreEqual(5, dlList[dlList.Length - 1]);
        }
        [TestMethod]
        [ExpectedException(typeof(DeleteNullExeption),
                "Error. Null current deleted")]
        public void TestNullDelite()
        {
            var dlList = new DoublyLinkingList<int>();
            dlList.DeleteCurrent();
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException),
                "Error.Index in Range.")]
        public void TestIndexOutOfRange()
        {
            var dlList = new DoublyLinkingList<int>();
            var dl = dlList[100];
        }
        [TestMethod]
        public void TestIndexer()
        {
            var dlList = new DoublyLinkingList<int>(1, 2, 3, 4, 5);
            for (var i = 0; i < dlList.Length; ++i)
            {
                Assert.AreEqual(i + 1, dlList[i]);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullContructor()
        {
            var dlList = new DoublyLinkingList<int>(null);

        }
        [TestMethod]
        public void TestGetIndexOfCurrent()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            Assert.AreEqual(0, dlList.GetIndexOfCurrent());
            dlList.ChangeCurrent(2);
            Assert.AreEqual(2, dlList.GetIndexOfCurrent());
        }
        [TestMethod]
        [ExpectedException(typeof(MoveExeption))]
        public void TestChangeCurrentToNegative()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlList.ChangeCurrent(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(MoveExeption))]
        public void TestChangeCurrentToOutOfLength()
        {
            var dlList = new DoublyLinkingList<int>(0, 1, 2, 3, 4);
            dlList.ChangeCurrent(5);
        }
    }
}
