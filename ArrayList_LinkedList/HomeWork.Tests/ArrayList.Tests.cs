using NUnit.Framework;
using System;

namespace HomeWorks.Tests
{
    [TestFixture]

    class ArrayListTests
    {
        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 5 }, 1)]
        [TestCase(new int[] { -10 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 11)]
        public void SizeTest(int[] original, int expected)
        {
            ArrayList list = new ArrayList(original);
            Assert.AreEqual(expected, list.Size());
        }
        [TestCase(new int[] { 12 }, 1, new int[] { 12, 1 })]
        [TestCase(new int[] { 12 }, 0, new int[] { 12, 0 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 11, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        public void AddTest(int[] original, int addValue, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.Add(addValue);
            Assert.AreEqual(expected, list.GetArrayList());
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, -1, new int[] { -1, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, -1, new int[] { 1, 2, -1, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, -1, new int[] { 1, 2, -1, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddOnIndexTest(int[] original, int index, int addValue, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.Add(index, addValue);
            Assert.AreEqual(expected, list.GetArrayList());
        }


         [TestCase(new int[] { }, 0, 1)]
         [TestCase(new int[] { 1, 2, 3 }, 5, -1)]
        public void AddOnIndexTestException(int[] original, int index, int addValue)
        {
            ArrayList list = new ArrayList(original);
            try
            {
                list.Add(index, addValue);
            }
            catch (ArgumentException e)
            {
                return;
            }
            Assert.Fail();//тест не проходит если блок catch не срабатывает
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, -1, new int[] { -1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, -2, new int[] { 1, -2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, -3, new int[] { 1, 2, -3 })]
        public void SetTest(int[] original, int index, int addValue, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.Set(index, addValue);
            Assert.AreEqual(expected, list.GetArrayList());
        }

        [TestCase(new int[] { }, 0, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 3, -1)]
        [TestCase(new int[] { 1, 2, 3 }, -1, -1)]
        public void SetTestException(int[] original, int index, int addValue)
        {
            ArrayList list = new ArrayList(original);
            try
            {
                list.Set(index, addValue);
            }catch(ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, 0, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 1, 2)]
        [TestCase(new int[] { 1, 2, 3 }, 2, 3)]
        public void GetTest(int[] original, int index, int expected)
        {
            ArrayList list = new ArrayList(original);
            Assert.AreEqual(expected, list.Get(index));
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void GetTestException(int[] original, int index)
        {
            ArrayList list = new ArrayList(original);
            try
            {
                int idx = list.Get(index);
            }
            catch(ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1 }, new int[] { 1, 2, 3, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 11 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddAllTest(int[] original, int[] values, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.AddAll(values);
            Assert.AreEqual(expected, list.GetArrayList());
        }

        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 1 }, new int[] { 1, 2, 3, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 10, new int[] { 11 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new int[] { 11, 12 }, new int[] { 1, 2, 11, 12, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new int[] { 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 11, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddAllToIndexTest(int[] original, int index, int[] values, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.AddAll(index, values);
            Assert.AreEqual(expected, list.GetArrayList());
        }

        [TestCase(new int[] { 1, 2, 3 }, -1, new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1 })]
        public void AddAllToIndexTestException(int[] original, int index, int[] values)
        {
            ArrayList list = new ArrayList(original);
            try
            {
                list.AddAll(index, values);

            }catch(ArgumentException e)
            {
                return;
            }
            
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, true)]
        [TestCase(new int[] { 1, 2, 3 }, -1, false)]
        [TestCase(new int[] { 1, 2, 3 }, 0, false)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, true)]
        public void ContainsTest(int[] original, int value, bool expected)
        {
            ArrayList list = new ArrayList(original);
            Assert.AreEqual(expected, list.Contains(value));
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 0)]
        [TestCase(new int[] { 1, 2, 3 }, 2, 1)]
        [TestCase(new int[] { 1, 2, 3 }, 333, -1)]
        [TestCase(new int[] { }, 0, -1)]
        public void IndexOfTest(int[] original, int value, int expected)
        {
            ArrayList list = new ArrayList(original);
            Assert.AreEqual(expected, list.IndexOf(value));
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 0 })]
        [TestCase(new int[] { 1, 1, 1 }, 1, new int[] { 0, 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 5, new int[] { })]
        public void SearchTest(int[] original, int value, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            Assert.AreEqual(expected, list.Search(value));
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12 })]
        public void RemoveIdxTest(int[] original, int index, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.RemoveIdx(index);
            Assert.AreEqual(expected, list.GetArrayList());
        }
        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        public void RemoveIdxTestException(int[] original, int index)
        {
            ArrayList list = new ArrayList(original);
            try
            {
                list.RemoveIdx(index);
            }catch(ArgumentException e)
            {
                return;
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 2, 2, 3 }, 2, new int[] { 1, 2, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 3, 8, 9, 10, 11, 12 }, 3, new int[] { 1, 2, 4, 5, 6, 3, 8, 9, 10, 11, 12 })]
        [TestCase(new int[] { 1, 2, 3 }, 5, new int[] { 1, 2, 3 })]
        public void RemoveTest(int[] original, int val, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.Remove(val);
            Assert.AreEqual(expected, list.GetArrayList());
        }



        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 2, 2, 3 }, 2, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2, 3, 2, 9, 2, 11, 2 }, 2, new int[] { 1, 3, 5, 3, 9, 11 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, 2, new int[] { 1 })]

        public void RemoveAllTest(int[] original, int val, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.RemoveAll(val);
            Assert.AreEqual(expected, list.GetArrayList());
        }

        [TestCase(new int[] { 1, 2, 3 }, 3, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 2, 2, 3 }, 2, new int[] { 1, 3 })]
        [TestCase(new int[] { 1, 2, 3, 2, 5, 2, 3, 2, 9, 2, 11, 2 }, 2, new int[] { 1, 3, 5, 3, 9, 11 })]
        [TestCase(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3 })]
        public void RemoveAllFastTest(int[] original, int val, int[] expected)
        {
            ArrayList list = new ArrayList(original);
            list.RemoveAllFast(val);
            Assert.AreEqual(expected, list.GetArrayList());
        }

    }
}
