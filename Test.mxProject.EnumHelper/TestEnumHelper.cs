using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using mxProject;

namespace Test.mxProject.EnumHelpers
{

    [TestClass]
    public class TestEnumHelper
    {

        #region IsFlag

        [TestMethod]
        public void Enum_IsFlag()
        {
            Assert.AreEqual(false, EnumHelper.IsFlag<SampleEnum>());
        }

        [TestMethod]
        public void Flag_IsFlag()
        {
            Assert.AreEqual(true, EnumHelper.IsFlag<SampleFlag>());
        }

        #endregion

        #region IsZero

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_IsZero()
        {

            bool result = EnumHelper.IsZero(SampleEnum.None);
            Assert.AreEqual(result, true);

            result = EnumHelper.IsZero(SampleEnum.Left);
            Assert.AreEqual(result, false);

            result = EnumHelper.IsZero(SampleEnum.All);
            Assert.AreEqual(result, false);

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_IsZero()
        {

            bool result = EnumHelper.IsZero(SampleFlag.None);
            Assert.AreEqual(result, true);

            result = EnumHelper.IsZero(SampleFlag.Left);
            Assert.AreEqual(result, false);

            result = EnumHelper.IsZero(SampleFlag.All);
            Assert.AreEqual(result, false);

        }

        #endregion

        #region And

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_And()
        {
            Assert.AreEqual(SampleEnum.None, EnumHelper.And(SampleEnum.Left, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.Right, EnumHelper.And(SampleEnum.LeftRight, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.Right, EnumHelper.And(SampleEnum.Right, SampleEnum.LeftRight));
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.And(SampleEnum.All, SampleEnum.LeftRight));
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.And(SampleEnum.All, SampleEnum.RightLeft));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_And()
        {
            Assert.AreEqual(SampleFlag.None, EnumHelper.And(SampleFlag.Left, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.Right, EnumHelper.And(SampleFlag.LeftRight, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.Right, EnumHelper.And(SampleFlag.Right, SampleFlag.LeftRight));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.And(SampleFlag.All, SampleFlag.LeftRight));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.And(SampleFlag.All, SampleFlag.RightLeft));
        }

        #endregion

        #region Or

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_Or()
        {
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.Or(SampleEnum.Left, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.Or(SampleEnum.LeftRight, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.Or(SampleEnum.Right, SampleEnum.LeftRight));
            Assert.AreEqual(SampleEnum.Left | SampleEnum.Center, EnumHelper.Or(SampleEnum.Center, SampleEnum.Left));
            Assert.AreEqual(SampleEnum.All, EnumHelper.Or(SampleEnum.Center, SampleEnum.LeftRight));
            Assert.AreEqual(SampleEnum.All, EnumHelper.Or(SampleEnum.All, SampleEnum.RightLeft));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_Or()
        {
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.Or(SampleFlag.Left, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.Or(SampleFlag.LeftRight, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.Or(SampleFlag.Right, SampleFlag.LeftRight));
            Assert.AreEqual(SampleFlag.Left | SampleFlag.Center, EnumHelper.Or(SampleFlag.Center, SampleFlag.Left));
            Assert.AreEqual(SampleFlag.All, EnumHelper.Or(SampleFlag.Center, SampleFlag.LeftRight));
            Assert.AreEqual(SampleFlag.All, EnumHelper.Or(SampleFlag.All, SampleFlag.RightLeft));
        }

        #endregion

        #region Xor

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_Xor()
        {
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.Xor(SampleEnum.Left, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.Left, EnumHelper.Xor(SampleEnum.LeftRight, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.Left, EnumHelper.Xor(SampleEnum.Right, SampleEnum.LeftRight));
            Assert.AreEqual(SampleEnum.None, EnumHelper.Xor(SampleEnum.LeftRight, SampleEnum.RightLeft));
            Assert.AreEqual(SampleEnum.Left | SampleEnum.Center, EnumHelper.Xor(SampleEnum.All, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.Center, EnumHelper.Xor(SampleEnum.All, SampleEnum.RightLeft));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_Xor()
        {
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.Xor(SampleFlag.Left, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.Left, EnumHelper.Xor(SampleFlag.LeftRight, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.Left, EnumHelper.Xor(SampleFlag.Right, SampleFlag.LeftRight));
            Assert.AreEqual(SampleFlag.None, EnumHelper.Xor(SampleFlag.LeftRight, SampleFlag.RightLeft));
            Assert.AreEqual(SampleFlag.Left | SampleFlag.Center, EnumHelper.Xor(SampleFlag.All, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.Center, EnumHelper.Xor(SampleFlag.All, SampleFlag.RightLeft));
        }

        #endregion

        #region Remove

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_Remove()
        {
            Assert.AreEqual(SampleEnum.Left, EnumHelper.Remove(SampleEnum.Left, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.Left, EnumHelper.Remove(SampleEnum.LeftRight, SampleEnum.Right));
            Assert.AreEqual(SampleEnum.None, EnumHelper.Remove(SampleEnum.Right, SampleEnum.LeftRight));
            Assert.AreEqual(SampleEnum.Center, EnumHelper.Remove(SampleEnum.Left | SampleEnum.Center, SampleEnum.Left));
            Assert.AreEqual(SampleEnum.Center, EnumHelper.Remove(SampleEnum.All, SampleEnum.RightLeft));
            Assert.AreEqual(SampleEnum.Right | SampleEnum.Center, EnumHelper.Remove(SampleEnum.All, SampleEnum.Left));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_Remove()
        {
            Assert.AreEqual(SampleFlag.Left, EnumHelper.Remove(SampleFlag.Left, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.Left, EnumHelper.Remove(SampleFlag.LeftRight, SampleFlag.Right));
            Assert.AreEqual(SampleFlag.None, EnumHelper.Remove(SampleFlag.Right, SampleFlag.LeftRight));
            Assert.AreEqual(SampleFlag.Center, EnumHelper.Remove(SampleFlag.Left | SampleFlag.Center, SampleFlag.Left));
            Assert.AreEqual(SampleFlag.Center, EnumHelper.Remove(SampleFlag.All, SampleFlag.RightLeft));
            Assert.AreEqual(SampleFlag.Right | SampleFlag.Center, EnumHelper.Remove(SampleFlag.All, SampleFlag.Left));
        }

        #endregion

        #region HasFlag

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_HasFlag()
        {
            Assert.AreEqual(false, EnumHelper.HasFlag(SampleEnum.Left, SampleEnum.Right));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleEnum.LeftRight, SampleEnum.Right));
            Assert.AreEqual(false, EnumHelper.HasFlag(SampleEnum.Right, SampleEnum.LeftRight));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleEnum.Left | SampleEnum.Center, SampleEnum.Left));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleEnum.All, SampleEnum.RightLeft));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleEnum.All, SampleEnum.Left));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_HasFlag()
        {
            Assert.AreEqual(false, EnumHelper.HasFlag(SampleFlag.Left, SampleFlag.Right));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleFlag.LeftRight, SampleFlag.Right));
            Assert.AreEqual(false, EnumHelper.HasFlag(SampleFlag.Right, SampleFlag.LeftRight));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleFlag.Left | SampleFlag.Center, SampleFlag.Left));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleFlag.All, SampleFlag.RightLeft));
            Assert.AreEqual(true, EnumHelper.HasFlag(SampleFlag.All, SampleFlag.Left));
        }

        #endregion

        #region numeric string

        [TestMethod]
        public void Enum_ToNumericString()
        {
            Assert.AreEqual("1", EnumHelper.ToNumericString(ByteEnum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(Int16Enum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(Int32Enum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(Int64Enum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(SByteEnum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(UInt16Enum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(UInt32Enum.One));
            Assert.AreEqual("1", EnumHelper.ToNumericString(UInt64Enum.One));
        }

        [TestMethod]
        public void Enum_ToNumericString_2()
        {
            Assert.AreEqual("01", EnumHelper.ToNumericString(ByteEnum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(Int16Enum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(Int32Enum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(Int64Enum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(SByteEnum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(UInt16Enum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(UInt32Enum.One, "d2"));
            Assert.AreEqual("01", EnumHelper.ToNumericString(UInt64Enum.One, "d2"));
        }

        [TestMethod]
        public void Enum_ToNumericString_3()
        {
            Assert.AreEqual("5", EnumHelper.ToNumericString(SampleEnum.Left | SampleEnum.Center));
            Assert.AreEqual("5", EnumHelper.ToNumericString(SampleFlag.Left | SampleFlag.Center));
        }

        [TestMethod]
        public void Enum_FromNumericString()
        {
            Assert.AreEqual(ByteEnum.One, EnumHelper.FromNumericString<ByteEnum>("01"));
            Assert.AreEqual(Int16Enum.One, EnumHelper.FromNumericString<Int16Enum>("01"));
            Assert.AreEqual(Int32Enum.One, EnumHelper.FromNumericString<Int32Enum>("01"));
            Assert.AreEqual(Int64Enum.One, EnumHelper.FromNumericString<Int64Enum>("01"));
            Assert.AreEqual(SByteEnum.One, EnumHelper.FromNumericString<SByteEnum>("01"));
            Assert.AreEqual(UInt16Enum.One, EnumHelper.FromNumericString<UInt16Enum>("01"));
            Assert.AreEqual(UInt32Enum.One, EnumHelper.FromNumericString<UInt32Enum>("01"));
            Assert.AreEqual(UInt64Enum.One, EnumHelper.FromNumericString<UInt64Enum>("01"));
        }

        [TestMethod]
        public void Enum_FromNumberString_2()
        {
            Assert.AreEqual(SampleEnum.Right | SampleEnum.Center, EnumHelper.FromNumericString<SampleEnum>("6"));
            Assert.AreEqual(SampleFlag.Right | SampleFlag.Center, EnumHelper.FromNumericString<SampleFlag>("6"));
        }

        [TestMethod]
        public void Enum_TryFromNumberString()
        {
            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out ByteEnum byteEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out byteEnum));
            Assert.AreEqual(ByteEnum.One, byteEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out Int16Enum shortEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out shortEnum));
            Assert.AreEqual(Int16Enum.One, shortEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out Int32Enum intEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out intEnum));
            Assert.AreEqual(Int32Enum.One, intEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out Int64Enum longEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out longEnum));
            Assert.AreEqual(Int64Enum.One, longEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out SByteEnum sbyteEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out sbyteEnum));
            Assert.AreEqual(SByteEnum.One, sbyteEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out UInt16Enum ushortEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out ushortEnum));
            Assert.AreEqual(UInt16Enum.One, ushortEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out UInt32Enum uintEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out uintEnum));
            Assert.AreEqual(UInt32Enum.One, uintEnum);

            Assert.AreEqual(false, EnumHelper.TryFromNumericString("02", out UInt64Enum ulongEnum));
            Assert.AreEqual(true, EnumHelper.TryFromNumericString("01", out ulongEnum));
            Assert.AreEqual(UInt64Enum.One, ulongEnum);
        }

        #endregion

        #region Alias

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_FromAlias()
        {
            Assert.AreEqual(SampleEnum.None, EnumHelper.FromAlias<SampleEnum>("N"));
            Assert.AreEqual(SampleEnum.Left, EnumHelper.FromAlias<SampleEnum>("L"));
            Assert.AreEqual(SampleEnum.Right, EnumHelper.FromAlias<SampleEnum>("R"));
            Assert.AreEqual(SampleEnum.Center, EnumHelper.FromAlias<SampleEnum>("C"));
            Assert.AreEqual(SampleEnum.LeftRight, EnumHelper.FromAlias<SampleEnum>("LR"));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Enum_FromAlias_Failed()
        {
            SampleEnum value = EnumHelper.FromAlias<SampleEnum>("X");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Enum_FromAlias_Failed_2()
        {
            SampleEnum value = EnumHelper.FromAlias<SampleEnum>("RL");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_FromAlias()
        {
            Assert.AreEqual(SampleFlag.Left, EnumHelper.FromAlias<SampleFlag>("L"));
            Assert.AreEqual(SampleFlag.Right, EnumHelper.FromAlias<SampleFlag>("R"));
            Assert.AreEqual(SampleFlag.Center, EnumHelper.FromAlias<SampleFlag>("C"));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.FromAlias<SampleFlag>("LR"));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.FromAlias<SampleFlag>("L,R"));
            Assert.AreEqual(SampleFlag.LeftRight, EnumHelper.FromAlias<SampleFlag>("R,L"));
            Assert.AreEqual(SampleFlag.Left | SampleFlag.Center, EnumHelper.FromAlias<SampleFlag>("L,C"));
            Assert.AreEqual(SampleFlag.All, EnumHelper.FromAlias<SampleFlag>("L,R,C"));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Flag_FromAlias_Failed()
        {
            SampleFlag value = EnumHelper.FromAlias<SampleFlag>("X");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Flag_FromAlias_Failed_2()
        {
            SampleFlag value = EnumHelper.FromAlias<SampleFlag>("L,R,X");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_TryFromAlias()
        {
            bool result = EnumHelper.TryFromAlias("L", out SampleEnum enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleEnum.Left, enumValue);

            result = EnumHelper.TryFromAlias("R", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleEnum.Right, enumValue);

            result = EnumHelper.TryFromAlias("C", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleEnum.Center, enumValue);

            result = EnumHelper.TryFromAlias("LR", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleEnum.LeftRight, enumValue);

            result = EnumHelper.TryFromAlias("RL", out enumValue);
            Assert.AreEqual(false, result);

            result = EnumHelper.TryFromAlias("X", out enumValue);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_TryFromAlias()
        {
            bool result = EnumHelper.TryFromAlias("L", out SampleFlag enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleFlag.Left, enumValue);

            result = EnumHelper.TryFromAlias("R", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual( SampleFlag.Right, enumValue);

            result = EnumHelper.TryFromAlias("C", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual( SampleFlag.Center, enumValue);

            result = EnumHelper.TryFromAlias("L,R", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleFlag.LeftRight, enumValue);

            result = EnumHelper.TryFromAlias("R,L", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleFlag.LeftRight, enumValue);

            result = EnumHelper.TryFromAlias("L,C", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual(SampleFlag.Left | SampleFlag.Center, enumValue);

            result = EnumHelper.TryFromAlias("L,R,C", out enumValue);
            Assert.AreEqual(true, result);
            Assert.AreEqual( SampleFlag.All, enumValue);
            Assert.AreEqual(SampleFlag.Left | SampleFlag.Right | SampleFlag.Center, enumValue);

            result = EnumHelper.TryFromAlias("X", out enumValue);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_GetAlias()
        {
            Assert.AreEqual("N", EnumHelper.GetAlias(SampleEnum.None));
            Assert.AreEqual("L", EnumHelper.GetAlias(SampleEnum.Left));
            Assert.AreEqual("R", EnumHelper.GetAlias(SampleEnum.Right));
            Assert.AreEqual("C", EnumHelper.GetAlias(SampleEnum.Center));
            Assert.AreEqual("LR", EnumHelper.GetAlias(SampleEnum.LeftRight));
            Assert.AreEqual("LR", EnumHelper.GetAlias(SampleEnum.RightLeft));
            Assert.AreEqual(null, EnumHelper.GetAlias(SampleEnum.Left | SampleEnum.Center));
            Assert.AreEqual(null, EnumHelper.GetAlias(SampleEnum.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_GetAlias()
        {
            Assert.AreEqual("N", EnumHelper.GetAlias(SampleFlag.None));
            Assert.AreEqual("L", EnumHelper.GetAlias(SampleFlag.Left));
            Assert.AreEqual("R", EnumHelper.GetAlias(SampleFlag.Right));
            Assert.AreEqual("C", EnumHelper.GetAlias(SampleFlag.Center));
            Assert.AreEqual("LR", EnumHelper.GetAlias(SampleFlag.LeftRight));
            Assert.AreEqual("LR", EnumHelper.GetAlias(SampleFlag.RightLeft));
            Assert.AreEqual("L,C", EnumHelper.GetAlias(SampleFlag.Left | SampleFlag.Center));
            Assert.AreEqual("L,R,C,LR", EnumHelper.GetAlias(SampleFlag.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_TryGetAlias()
        {
            bool result = EnumHelper.TryGetAlias(SampleEnum.Left, out string alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("L", alias);

            result = EnumHelper.TryGetAlias(SampleEnum.Right, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("R", alias);

            result = EnumHelper.TryGetAlias(SampleEnum.Center, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("C", alias);

            result = EnumHelper.TryGetAlias(SampleEnum.LeftRight, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("LR", alias);

            result = EnumHelper.TryGetAlias(SampleEnum.RightLeft, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("LR", alias);

            result = EnumHelper.TryGetAlias(SampleEnum.None, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("N", alias);

            result = EnumHelper.TryGetAlias(SampleEnum.All, out alias);
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_TryGetAlias()
        {
            bool result = EnumHelper.TryGetAlias(SampleFlag.Left, out string alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("L", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.Right, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("R", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.Center, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("C", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.LeftRight, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("LR", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.RightLeft, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("LR", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.Left | SampleFlag.Center, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("L,C", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.None, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("N", alias);

            result = EnumHelper.TryGetAlias(SampleFlag.All, out alias);
            Assert.AreEqual(true, result);
            Assert.AreEqual("L,R,C,LR", alias);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_HasAlias()
        {
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleEnum.None));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleEnum.Left));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleEnum.Right));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleEnum.Center));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleEnum.LeftRight));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleEnum.RightLeft));
            Assert.AreEqual(false, EnumHelper.HasAlias(SampleEnum.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_HasAlias()
        {
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.None));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.Left));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.Right));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.Center));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.LeftRight));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.RightLeft));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.Left | SampleFlag.Center));
            Assert.AreEqual(true, EnumHelper.HasAlias(SampleFlag.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_RegistAlias()
        {

            EnumHelper.RegistAlias<SampleEnum>(enumValue =>
            {
                return new EnumAliasInfo(enumValue.ToString().ToUpper());
            }
            );

            bool result = EnumHelper.HasAlias(SampleEnum.Left);
            Assert.AreEqual(result, true);

            SampleEnum value = EnumHelper.FromAlias<SampleEnum>("LEFT");
            Assert.AreEqual(value, SampleEnum.Left);

            string alias = EnumHelper.GetAlias(SampleEnum.Right);
            Assert.AreEqual(alias, "RIGHT");

            EnumHelper.UnregistAlias<SampleEnum>();

            result = EnumHelper.HasAlias(SampleEnum.Left);
            Assert.AreEqual(result, true);

            value = EnumHelper.FromAlias<SampleEnum>("L");
            Assert.AreEqual(value, SampleEnum.Left);

            alias = EnumHelper.GetAlias(SampleEnum.Right);
            Assert.AreEqual(alias, "R");

        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_RegistAlias()
        {

            EnumHelper.RegistAlias<SampleFlag>(enumValue =>
            {
                return new EnumAliasInfo(enumValue.ToString().ToUpper());
            }
            );

            bool result = EnumHelper.HasAlias(SampleFlag.Left);
            Assert.AreEqual(result, true);

            SampleFlag value = EnumHelper.FromAlias<SampleFlag>("LEFT");
            Assert.AreEqual(value, SampleFlag.Left);

            string alias = EnumHelper.GetAlias(SampleFlag.Right);
            Assert.AreEqual(alias, "RIGHT");

            EnumHelper.UnregistAlias<SampleFlag>();

            result = EnumHelper.HasAlias(SampleFlag.Left);
            Assert.AreEqual(result, true);

            value = EnumHelper.FromAlias<SampleFlag>("L");
            Assert.AreEqual(value, SampleFlag.Left);

            alias = EnumHelper.GetAlias(SampleFlag.Right);
            Assert.AreEqual(alias, "R");

        }

        #endregion

        #region DisplayName

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_GetDisplayName()
        {
            Assert.AreEqual("None", EnumHelper.GetDisplayName(SampleEnum.None));
            Assert.AreEqual("左", EnumHelper.GetDisplayName(SampleEnum.Left));
            Assert.AreEqual("右", EnumHelper.GetDisplayName(SampleEnum.Right));
            Assert.AreEqual("中央", EnumHelper.GetDisplayName(SampleEnum.Center));
            Assert.AreEqual("左右", EnumHelper.GetDisplayName(SampleEnum.LeftRight));
            Assert.AreEqual("左右", EnumHelper.GetDisplayName(SampleEnum.RightLeft));
            Assert.AreEqual(null, EnumHelper.GetDisplayName(SampleEnum.Left | SampleEnum.Center));
            Assert.AreEqual("All", EnumHelper.GetDisplayName(SampleEnum.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_GetDisplayName()
        {
            Assert.AreEqual("None", EnumHelper.GetDisplayName(SampleFlag.None));
            Assert.AreEqual("左", EnumHelper.GetDisplayName(SampleFlag.Left));
            Assert.AreEqual("右", EnumHelper.GetDisplayName(SampleFlag.Right));
            Assert.AreEqual("中央", EnumHelper.GetDisplayName(SampleFlag.Center));
            Assert.AreEqual("左右", EnumHelper.GetDisplayName(SampleFlag.LeftRight));
            Assert.AreEqual("左右", EnumHelper.GetDisplayName(SampleFlag.RightLeft));
            Assert.AreEqual("左,中央", EnumHelper.GetDisplayName(SampleFlag.Left | SampleFlag.Center));
            Assert.AreEqual("All", EnumHelper.GetDisplayName(SampleFlag.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_RegistDisplayInfo()
        {

            EnumHelper.RegistDisplayInfo<SampleEnum>(enumValue =>
            {
                return new EnumDisplayInfo(enumValue.ToString().ToUpper(), (int)enumValue);
            }
            );

            string displayName = EnumHelper.GetDisplayName(SampleEnum.Right);
            Assert.AreEqual(displayName, "RIGHT");

            int displayOrder = EnumHelper.GetDisplayOrder(SampleEnum.Right);
            Assert.AreEqual(displayOrder, (int)SampleEnum.Right);

            EnumHelper.UnregistDisplayInfo<SampleEnum>();

            displayName = EnumHelper.GetDisplayName(SampleEnum.Right);
            Assert.AreEqual(displayName, "右");

            displayOrder = EnumHelper.GetDisplayOrder(SampleEnum.Right);
            Assert.AreEqual(displayOrder, 1);

        }

        #endregion

        #region DisplayOrder

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_GetDisplayOrder()
        {
            Assert.AreEqual(0, EnumHelper.GetDisplayOrder(SampleEnum.None));
            Assert.AreEqual(2, EnumHelper.GetDisplayOrder(SampleEnum.Left));
            Assert.AreEqual(1, EnumHelper.GetDisplayOrder(SampleEnum.Right));
            Assert.AreEqual(3, EnumHelper.GetDisplayOrder(SampleEnum.Center));
            Assert.AreEqual(4, EnumHelper.GetDisplayOrder(SampleEnum.LeftRight));
            Assert.AreEqual(4, EnumHelper.GetDisplayOrder(SampleEnum.RightLeft));
            Assert.AreEqual(0, EnumHelper.GetDisplayOrder(SampleEnum.Left | SampleEnum.Center));
            Assert.AreEqual(0, EnumHelper.GetDisplayOrder(SampleEnum.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_GetDisplayOrder()
        {
            Assert.AreEqual(0, EnumHelper.GetDisplayOrder(SampleFlag.None));
            Assert.AreEqual(2, EnumHelper.GetDisplayOrder(SampleFlag.Left));
            Assert.AreEqual(1, EnumHelper.GetDisplayOrder(SampleFlag.Right));
            Assert.AreEqual(3, EnumHelper.GetDisplayOrder(SampleFlag.Center));
            Assert.AreEqual(4, EnumHelper.GetDisplayOrder(SampleFlag.LeftRight));
            Assert.AreEqual(4, EnumHelper.GetDisplayOrder(SampleFlag.RightLeft));
            Assert.AreEqual(0, EnumHelper.GetDisplayOrder(SampleFlag.Left | SampleFlag.Center));
            Assert.AreEqual(0, EnumHelper.GetDisplayOrder(SampleFlag.All));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_GetOrderedValues()
        {
            IList<SampleEnum> values = EnumHelper.GetOrderedValues<SampleEnum>(false);

            for (int i = 0; i < values.Count; ++i)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("[{0}] {1}", i, values[i]));
            }
            Assert.AreEqual(7, values.Count);
            Assert.AreEqual(SampleEnum.None, values[0]);
            Assert.AreEqual(SampleEnum.All, values[1]);
            Assert.AreEqual(SampleEnum.Right, values[2]);
            Assert.AreEqual(SampleEnum.Left, values[3]);
            Assert.AreEqual(SampleEnum.Center, values[4]);
            Assert.AreEqual(SampleEnum.LeftRight, values[5]);
            Assert.AreEqual(SampleEnum.RightLeft, values[6]);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Enum_GetOrderedValues_2()
        {
            IList<SampleEnum> values = EnumHelper.GetOrderedValues<SampleEnum>(true);
            Assert.AreEqual(3, values.Count);
            Assert.AreEqual(SampleEnum.Right, values[0]);
            Assert.AreEqual(SampleEnum.Left, values[1]);
            Assert.AreEqual(SampleEnum.Center, values[2]);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_GetOrderedValues()
        {
            IList<SampleFlag> values = EnumHelper.GetOrderedValues<SampleFlag>(false);
            Assert.AreEqual(7, values.Count);
            Assert.AreEqual(SampleFlag.None, values[0]);
            Assert.AreEqual(SampleFlag.All, values[1]);
            Assert.AreEqual(SampleFlag.Right, values[2]);
            Assert.AreEqual(SampleFlag.Left, values[3]);
            Assert.AreEqual(SampleFlag.Center, values[4]);
            Assert.AreEqual(SampleFlag.LeftRight, values[5]);
            Assert.AreEqual(SampleFlag.RightLeft, values[6]);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Flag_GetOrderedValues_2()
        {
            IList<SampleFlag> values = EnumHelper.GetOrderedValues<SampleFlag>(true);
            Assert.AreEqual(3, values.Count);
            Assert.AreEqual(SampleFlag.Right, values[0]);
            Assert.AreEqual(SampleFlag.Left, values[1]);
            Assert.AreEqual(SampleFlag.Center, values[2]);
        }

        #endregion


    }
}
