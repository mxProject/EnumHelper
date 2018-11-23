using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mxProject;

namespace Test.mxProject.EnumHelpers
{

    [TestClass]
    public class TestEnumExtensions
    {

        #region underlyingType

        [TestMethod]
        public void Enum_ToByte()
        {
            Assert.AreEqual((byte)ByteEnum.One, ByteEnum.One.ToByte());
        }

        [TestMethod]
        public void Enum_ToInt16()
        {
            Assert.AreEqual((short)Int16Enum.One, Int16Enum.One.ToInt16());
        }

        [TestMethod]
        public void Enum_ToInt32()
        {
            Assert.AreEqual((int)Int32Enum.One, Int32Enum.One.ToInt32());
        }

        [TestMethod]
        public void Enum_ToInt64()
        {
            Assert.AreEqual((long)Int64Enum.One, Int64Enum.One.ToInt64());
        }

        [TestMethod]
        public void Enum_ToSByte()
        {
            Assert.AreEqual((sbyte)ByteEnum.One, SByteEnum.One.ToSByte());
        }

        [TestMethod]
        public void Enum_ToUInt16()
        {
            Assert.AreEqual((ushort)Int16Enum.One, UInt16Enum.One.ToUInt16());
        }

        [TestMethod]
        public void Enum_ToUInt32()
        {
            Assert.AreEqual((uint)Int32Enum.One, UInt32Enum.One.ToUInt32());
        }

        [TestMethod]
        public void Enum_ToUInt64()
        {
            Assert.AreEqual((ulong)Int64Enum.One, UInt64Enum.One.ToUInt64());
        }

        #endregion

        #region numeric string

        [TestMethod]
        public void Enum_ToNumericString()
        {
            Assert.AreEqual("1", ByteEnum.One.ToNumericString());
            Assert.AreEqual("1", Int16Enum.One.ToNumericString());
            Assert.AreEqual("1", Int32Enum.One.ToNumericString());
            Assert.AreEqual("1", Int64Enum.One.ToNumericString());
            Assert.AreEqual("1", SByteEnum.One.ToNumericString());
            Assert.AreEqual("1", UInt16Enum.One.ToNumericString());
            Assert.AreEqual("1", UInt32Enum.One.ToNumericString());
            Assert.AreEqual("1", UInt64Enum.One.ToNumericString());
        }

        [TestMethod]
        public void Enum_ToNumericString_2()
        {
            Assert.AreEqual("01", ByteEnum.One.ToNumericString("d2"));
            Assert.AreEqual("01", Int16Enum.One.ToNumericString("d2"));
            Assert.AreEqual("01", Int32Enum.One.ToNumericString("d2"));
            Assert.AreEqual("01", Int64Enum.One.ToNumericString("d2"));
            Assert.AreEqual("01", SByteEnum.One.ToNumericString("d2"));
            Assert.AreEqual("01", UInt16Enum.One.ToNumericString("d2"));
            Assert.AreEqual("01", UInt32Enum.One.ToNumericString("d2"));
            Assert.AreEqual("01", UInt64Enum.One.ToNumericString("d2"));
        }

        #endregion

        #region Alias

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_GetAlias()
        {
            string alias = SampleEnum.Left.GetAlias();
            Assert.AreEqual(alias, "L");

            alias = SampleEnum.LeftRight.GetAlias();
            Assert.AreEqual(alias, "LR");

            alias = SampleEnum.All.GetAlias();
            Assert.AreEqual(alias, null);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_GetAlias()
        {
            string alias = SampleFlag.Left.GetAlias();
            Assert.AreEqual(alias, "L");

            alias = SampleFlag.LeftRight.GetAlias();
            Assert.AreEqual(alias, "LR");

            alias = SampleFlag.All.GetAlias();
            Assert.AreEqual(alias, "L,R,C,LR");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_TryGetAlias()
        {
            bool result = SampleEnum.Right.TryGetAlias(out string alias);
            Assert.AreEqual(result, true);
            Assert.AreEqual(alias, "R");

            result = SampleEnum.None.TryGetAlias(out alias);
            Assert.AreEqual(result, true);
            Assert.AreEqual(alias, "N");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_TryGetAlias()
        {
            bool result = SampleFlag.Right.TryGetAlias(out string alias);
            Assert.AreEqual(result, true);
            Assert.AreEqual(alias, "R");

            result = SampleFlag.None.TryGetAlias(out alias);
            Assert.AreEqual(result, true);
            Assert.AreEqual(alias, "N");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_HasAlias()
        {
            bool result = SampleEnum.Left.HasAlias();
            Assert.AreEqual(result, true);

            result = SampleEnum.None.HasAlias();
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_HasAlias()
        {
            bool result = SampleFlag.Left.HasAlias();
            Assert.AreEqual(result, true);

            result = SampleFlag.None.HasAlias();
            Assert.AreEqual(result, true);
        }

        #endregion

    }

}
