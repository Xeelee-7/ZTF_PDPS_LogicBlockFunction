// 
//Version:2
//ZhangTengfei
//Change Dialog: ----------------------------------------------------------
// 1.Add Byte <-> Word  Byte <-> DWord               Data:20220128
// 2.Merge DWord2WordL/H into DWord2Word  etc.       Data:20220128
// 3.Add Measure distance\Visual                     Data:20221011
// 4.Add DWord2Real Function                         Data:20221025
// 5.Measure version3.0                              Data:20230819
// 6.RFID--Set&Get identifiter                       Data:20230819
// 7.Rewrite logic with class ：BitConvert           Data:20231224      
//-------------------------------------------------------------------------
//
using System;
using System.Collections;
using System.Collections.Generic;
using Tecnomatix.Engineering;
using Tecnomatix.Engineering.PrivateImplementationDetails;

namespace SignalConverter
{
    [TxPlcLogicBehaviorFunction("Word2Dword")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Merge two Word into one Dword")]
    public class Word2Dword : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Word2Dword()
        {
            m_typesArray.Add(TxPlcSignalDataType.Word);
            m_typesArray.Add(TxPlcSignalDataType.Word);
            m_namesArray.Add("Word_Index0");
            m_namesArray.Add("Word_Index1");
            m_returnValueType = TxPlcSignalDataType.DWord;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue3 = (TxPlcValue)parameters[1];
            ulong dWordValue = txPlcValue.DWordValue;
            uint wordValue = txPlcValue2.WordValue;
            uint wordValue2 = txPlcValue3.WordValue;
            wordValue2 *= 65536;
            dWordValue = (txPlcValue.DWordValue = wordValue + wordValue2);
            return txPlcValue;
        }
    }

    [TxPlcLogicBehaviorFunction("DWord2Word")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("DWord into two Word.Word_Index must be 0 or 1!")]
    public class DWord2Word : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public DWord2Word()
        {
            m_typesArray.Add(TxPlcSignalDataType.DWord);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("DWORD");
            m_namesArray.Add("Word_Indexnum");
            m_returnValueType = TxPlcSignalDataType.Word;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[1];
            TxPlcValue txPlcValue3 = new TxPlcValue();
            ulong num = txPlcValue.DWordValue;
            ushort wordValue = Convert.ToUInt16(num & 0xFFFF);
            ushort wordValue2 = Convert.ToUInt16((num & 4294901760u) >> 16);
            int indexnum = txPlcValue2.IntValue;
            if (indexnum == 0)
            {
                txPlcValue3.WordValue = wordValue;
            }
            if (indexnum == 1)
            {
                txPlcValue3.WordValue = wordValue2;
            }


            return txPlcValue3;
        }
    }


    [TxPlcLogicBehaviorFunction("Bool2Byte")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Bool to Byte ")]
    public class Bool2Byte : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Bool2Byte()
        {
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_namesArray.Add("X0");
            m_namesArray.Add("X1");
            m_namesArray.Add("X2");
            m_namesArray.Add("X3");
            m_namesArray.Add("X4");
            m_namesArray.Add("X5");
            m_namesArray.Add("X6");
            m_namesArray.Add("X7");
            m_returnValueType = TxPlcSignalDataType.Byte;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue val = (TxPlcValue)parameters[0];
            TxPlcValue val2 = (TxPlcValue)parameters[1];
            TxPlcValue val3 = (TxPlcValue)parameters[2];
            TxPlcValue val4 = (TxPlcValue)parameters[3];
            TxPlcValue val5 = (TxPlcValue)parameters[4];
            TxPlcValue val6 = (TxPlcValue)parameters[5];
            TxPlcValue val7 = (TxPlcValue)parameters[6];
            TxPlcValue val8 = (TxPlcValue)parameters[7];
            TxPlcValue val9 = new TxPlcValue();
            sbyte[] array = new sbyte[1];
            BitArray bitArray = new BitArray(8);
            bitArray[0] = val.BooleanValue;
            bitArray[1] = val2.BooleanValue;
            bitArray[2] = val3.BooleanValue;
            bitArray[3] = val4.BooleanValue;
            bitArray[4] = val5.BooleanValue;
            bitArray[5] = val6.BooleanValue;
            bitArray[6] = val7.BooleanValue;
            bitArray[7] = val8.BooleanValue;
            bitArray.CopyTo(array, 0);
            ushort num = 0;
            num = (ushort)array[0];
            val9.ByteValue = num;
            return val9;
        }
    }

    [TxPlcLogicBehaviorFunction("Byte2Bool")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Byte to Bool")]
    public class Byte2Bool : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Byte2Bool()
        {
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("Byte");
            m_namesArray.Add("Bit_Index");
            m_returnValueType = TxPlcSignalDataType.Bool;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = (TxPlcValue)parameters[1];
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue3 = new TxPlcValue();
            int intValue = txPlcValue.IntValue;
            byte value = (byte)txPlcValue2.ByteValue;
            string text = Convert.ToString(value, 2);
            if (intValue < text.Length)
            {
                string a = text.Substring(text.Length - intValue - 1, 1);
                if (a == "1")
                {
                    txPlcValue3.BooleanValue = true;
                }
                else
                {
                    txPlcValue3.BooleanValue = false;
                }
            }
            else
            {
                txPlcValue3.BooleanValue = false;
            }

            return txPlcValue3;
        }
    }
    [TxPlcLogicBehaviorFunction("Bool2Word")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Bool to Word ")]
    public class Bool2Word : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Bool2Word()
        {
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_namesArray.Add("X0");
            m_namesArray.Add("X1");
            m_namesArray.Add("X2");
            m_namesArray.Add("X3");
            m_namesArray.Add("X4");
            m_namesArray.Add("X5");
            m_namesArray.Add("X6");
            m_namesArray.Add("X7");
            m_namesArray.Add("X8");
            m_namesArray.Add("X9");
            m_namesArray.Add("X10");
            m_namesArray.Add("X11");
            m_namesArray.Add("X12");
            m_namesArray.Add("X13");
            m_namesArray.Add("X14");
            m_namesArray.Add("X15");
            m_returnValueType = TxPlcSignalDataType.Word;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue val = (TxPlcValue)parameters[0];
            TxPlcValue val2 = (TxPlcValue)parameters[1];
            TxPlcValue val3 = (TxPlcValue)parameters[2];
            TxPlcValue val4 = (TxPlcValue)parameters[3];
            TxPlcValue val5 = (TxPlcValue)parameters[4];
            TxPlcValue val6 = (TxPlcValue)parameters[5];
            TxPlcValue val7 = (TxPlcValue)parameters[6];
            TxPlcValue val8 = (TxPlcValue)parameters[7];
            TxPlcValue val9 = (TxPlcValue)parameters[8];
            TxPlcValue val10 = (TxPlcValue)parameters[9];
            TxPlcValue val11 = (TxPlcValue)parameters[10];
            TxPlcValue val12 = (TxPlcValue)parameters[11];
            TxPlcValue val13 = (TxPlcValue)parameters[12];
            TxPlcValue val14 = (TxPlcValue)parameters[13];
            TxPlcValue val15 = (TxPlcValue)parameters[14];
            TxPlcValue val16 = (TxPlcValue)parameters[15];
            TxPlcValue val17 = new TxPlcValue();
            byte[] array = new byte[2];
            BitArray bitArray = new BitArray(8);
            bitArray[0] = val.BooleanValue;
            bitArray[1] = val2.BooleanValue;
            bitArray[2] = val3.BooleanValue;
            bitArray[3] = val4.BooleanValue;
            bitArray[4] = val5.BooleanValue;
            bitArray[5] = val6.BooleanValue;
            bitArray[6] = val7.BooleanValue;
            bitArray[7] = val8.BooleanValue;
            BitArray bitArray2 = new BitArray(8);
            bitArray2[0] = val9.BooleanValue;
            bitArray2[1] = val10.BooleanValue;
            bitArray2[2] = val11.BooleanValue;
            bitArray2[3] = val12.BooleanValue;
            bitArray2[4] = val13.BooleanValue;
            bitArray2[5] = val14.BooleanValue;
            bitArray2[6] = val15.BooleanValue;
            bitArray2[7] = val16.BooleanValue;
            bitArray.CopyTo(array, 0);
            bitArray2.CopyTo(array, 1);
            val17.WordValue = BitConverter.ToUInt16(array, 0);
            return val17;
        }
    }
    [TxPlcLogicBehaviorFunction("Bool2DWord")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Bool to DWord ")]
    public class Bool2DWord : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Bool2DWord()
        {
            //IL_0480: Unknown result type (might be due to invalid IL or missing references)
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_namesArray.Add("X0");
            m_namesArray.Add("X1");
            m_namesArray.Add("X2");
            m_namesArray.Add("X3");
            m_namesArray.Add("X4");
            m_namesArray.Add("X5");
            m_namesArray.Add("X6");
            m_namesArray.Add("X7");
            m_namesArray.Add("X8");
            m_namesArray.Add("X9");
            m_namesArray.Add("X10");
            m_namesArray.Add("X11");
            m_namesArray.Add("X12");
            m_namesArray.Add("X13");
            m_namesArray.Add("X14");
            m_namesArray.Add("X15");
            m_namesArray.Add("X16");
            m_namesArray.Add("X17");
            m_namesArray.Add("X18");
            m_namesArray.Add("X19");
            m_namesArray.Add("X20");
            m_namesArray.Add("X21");
            m_namesArray.Add("X22");
            m_namesArray.Add("X23");
            m_namesArray.Add("X24");
            m_namesArray.Add("X25");
            m_namesArray.Add("X26");
            m_namesArray.Add("X27");
            m_namesArray.Add("X28");
            m_namesArray.Add("X29");
            m_namesArray.Add("X30");
            m_namesArray.Add("X31");
            m_returnValueType = TxPlcSignalDataType.Word;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue val = (TxPlcValue)parameters[0];
            TxPlcValue val2 = (TxPlcValue)parameters[1];
            TxPlcValue val3 = (TxPlcValue)parameters[2];
            TxPlcValue val4 = (TxPlcValue)parameters[3];
            TxPlcValue val5 = (TxPlcValue)parameters[4];
            TxPlcValue val6 = (TxPlcValue)parameters[5];
            TxPlcValue val7 = (TxPlcValue)parameters[6];
            TxPlcValue val8 = (TxPlcValue)parameters[7];
            TxPlcValue val9 = (TxPlcValue)parameters[8];
            TxPlcValue val10 = (TxPlcValue)parameters[9];
            TxPlcValue val11 = (TxPlcValue)parameters[10];
            TxPlcValue val12 = (TxPlcValue)parameters[11];
            TxPlcValue val13 = (TxPlcValue)parameters[12];
            TxPlcValue val14 = (TxPlcValue)parameters[13];
            TxPlcValue val15 = (TxPlcValue)parameters[14];
            TxPlcValue val16 = (TxPlcValue)parameters[15];
            TxPlcValue val17 = (TxPlcValue)parameters[16];
            TxPlcValue val18 = (TxPlcValue)parameters[17];
            TxPlcValue val19 = (TxPlcValue)parameters[18];
            TxPlcValue val20 = (TxPlcValue)parameters[19];
            TxPlcValue val21 = (TxPlcValue)parameters[20];
            TxPlcValue val22 = (TxPlcValue)parameters[21];
            TxPlcValue val23 = (TxPlcValue)parameters[22];
            TxPlcValue val24 = (TxPlcValue)parameters[23];
            TxPlcValue val25 = (TxPlcValue)parameters[24];
            TxPlcValue val26 = (TxPlcValue)parameters[25];
            TxPlcValue val27 = (TxPlcValue)parameters[26];
            TxPlcValue val28 = (TxPlcValue)parameters[27];
            TxPlcValue val29 = (TxPlcValue)parameters[28];
            TxPlcValue val30 = (TxPlcValue)parameters[29];
            TxPlcValue val31 = (TxPlcValue)parameters[30];
            TxPlcValue val32 = (TxPlcValue)parameters[31];
            TxPlcValue val33 = new TxPlcValue();
            byte[] array = new byte[4];
            BitArray bitArray = new BitArray(8);
            bitArray[0] = val.BooleanValue;
            bitArray[1] = val2.BooleanValue;
            bitArray[2] = val3.BooleanValue;
            bitArray[3] = val4.BooleanValue;
            bitArray[4] = val5.BooleanValue;
            bitArray[5] = val6.BooleanValue;
            bitArray[6] = val7.BooleanValue;
            bitArray[7] = val8.BooleanValue;
            BitArray bitArray2 = new BitArray(8);
            bitArray2[0] = val9.BooleanValue;
            bitArray2[1] = val10.BooleanValue;
            bitArray2[2] = val11.BooleanValue;
            bitArray2[3] = val12.BooleanValue;
            bitArray2[4] = val13.BooleanValue;
            bitArray2[5] = val14.BooleanValue;
            bitArray2[6] = val15.BooleanValue;
            bitArray2[7] = val16.BooleanValue;
            BitArray bitArray3 = new BitArray(8);
            bitArray3[0] = val17.BooleanValue;
            bitArray3[1] = val18.BooleanValue;
            bitArray3[2] = val19.BooleanValue;
            bitArray3[3] = val20.BooleanValue;
            bitArray3[4] = val21.BooleanValue;
            bitArray3[5] = val22.BooleanValue;
            bitArray3[6] = val23.BooleanValue;
            bitArray3[7] = val24.BooleanValue;
            BitArray bitArray4 = new BitArray(8);
            bitArray4[0] = val25.BooleanValue;
            bitArray4[1] = val26.BooleanValue;
            bitArray4[2] = val27.BooleanValue;
            bitArray4[3] = val28.BooleanValue;
            bitArray4[4] = val29.BooleanValue;
            bitArray4[5] = val30.BooleanValue;
            bitArray4[6] = val31.BooleanValue;
            bitArray4[7] = val32.BooleanValue;
            bitArray.CopyTo(array, 0);
            bitArray2.CopyTo(array, 1);
            bitArray3.CopyTo(array, 2);
            bitArray4.CopyTo(array, 3);
            val17.DWordValue = BitConverter.ToUInt32(array, 0);
            return val17;
        }
    }
    [TxPlcLogicBehaviorFunction("DWord2Bool")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("DWord to Bool ")]
    public class DWord2Bool : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public DWord2Bool()
        {
            m_typesArray.Add((object)(TxPlcSignalDataType)3);
            m_typesArray.Add((object)(TxPlcSignalDataType)4);
            m_namesArray.Add("DWord");
            m_namesArray.Add("Bit_Index");
            m_returnValueType = TxPlcSignalDataType.Bool;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue val = (TxPlcValue)parameters[0];
            TxPlcValue val2 = (TxPlcValue)parameters[1];
            TxPlcValue val3 = (TxPlcValue)(object)new TxPlcValue();
            uint dWordValue = val.DWordValue;
            int intValue = val2.IntValue;
            string text = Convert.ToString(dWordValue, 2);
            if (intValue < text.Length)
            {
                string a = text.Substring(text.Length - intValue - 1, 1);
                if (a == "1")
                {
                    val3.BooleanValue = true;


                }
                else
                {
                    val3.BooleanValue = false;
                }
            }
            else
            {
                val3.BooleanValue = false;
            }

            return val3;
        }
    }
    [TxPlcLogicBehaviorFunction("Word2Bool")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Word to Bool ")]
    public class Word2Bool : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Word2Bool()
        {
            m_typesArray.Add((object)(TxPlcSignalDataType)2);
            m_typesArray.Add((object)(TxPlcSignalDataType)4);
            m_namesArray.Add("Word");
            m_namesArray.Add("Bit_Index");
            m_returnValueType = TxPlcSignalDataType.Bool;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue val = (TxPlcValue)parameters[0];
            TxPlcValue val2 = (TxPlcValue)parameters[1];
            TxPlcValue val3 = new TxPlcValue();
            ushort wordValue = val.WordValue;
            int intValue = val2.IntValue;
            string text = Convert.ToString(wordValue, 2);
            if (intValue < text.Length)
            {
                string a = text.Substring(text.Length - intValue - 1, 1);
                if (a == "1")
                {
                    val3.BooleanValue = true;
                }
                else
                {
                    val3.BooleanValue = false;
                }
            }
            else
            {
                val3.BooleanValue = false;
            }

            return val3;
        }
    }

    [TxPlcLogicBehaviorFunction("Byte2Word")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Merge two Byte into one Word")]
    public class Byte2Word : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Byte2Word()
        {
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_namesArray.Add("Byte_Index0");
            m_namesArray.Add("Byte_Index1");
            m_returnValueType = TxPlcSignalDataType.Word;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue3 = (TxPlcValue)parameters[1];
            string str1 = Convert.ToString(txPlcValue2.ByteValue, 2).PadLeft(8, '0');
            string str2 = Convert.ToString(txPlcValue3.ByteValue, 2).PadLeft(8, '0');
            string str = str2 + str1;
            txPlcValue.WordValue = Convert.ToUInt16(str, 2);
            return txPlcValue;
        }
    }
    [TxPlcLogicBehaviorFunction("Word2Byte")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Word into two Byte.Byte_Index must be 0 or 1!")]
    public class Word2Byte : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Word2Byte()
        {
            m_typesArray.Add(TxPlcSignalDataType.Word);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("Word");
            m_namesArray.Add("Byte_Indexnum");
            m_returnValueType = TxPlcSignalDataType.Byte;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue3 = (TxPlcValue)parameters[1];
            int indexnum = txPlcValue3.IntValue;
            ushort str = Convert.ToUInt16(txPlcValue2.WordValue >> 8);
            ushort str2 = Convert.ToUInt16(txPlcValue2.WordValue & 0xFF);
            if (indexnum == 0)
            {
                txPlcValue.ByteValue = str2;
            }
            if (indexnum == 1)
            {
                txPlcValue.ByteValue = str;
            }
            return txPlcValue;
        }
    }
    [TxPlcLogicBehaviorFunction("Byte2DWord")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Merge four Byte into one DWord")]
    public class Byte2DWord : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Byte2DWord()
        {
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_typesArray.Add(TxPlcSignalDataType.Byte);
            m_namesArray.Add("Byte_Index0");
            m_namesArray.Add("Byte_Index1");
            m_namesArray.Add("Byte_Index2");
            m_namesArray.Add("Byte_Index3");
            m_returnValueType = TxPlcSignalDataType.DWord;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue3 = (TxPlcValue)parameters[1];
            TxPlcValue txPlcValue4 = (TxPlcValue)parameters[2];
            TxPlcValue txPlcValue5 = (TxPlcValue)parameters[3];
            string str1 = Convert.ToString(txPlcValue2.ByteValue, 2).PadLeft(8, '0');
            string str2 = Convert.ToString(txPlcValue3.ByteValue, 2).PadLeft(8, '0');
            string str3 = Convert.ToString(txPlcValue4.ByteValue, 2).PadLeft(8, '0');
            string str4 = Convert.ToString(txPlcValue5.ByteValue, 2).PadLeft(8, '0');
            string str = str4 + str3 + str2 + str1;
            txPlcValue.DWordValue = Convert.ToUInt32(str, 2);
            return txPlcValue;
        }
    }
    [TxPlcLogicBehaviorFunction("DWord2Byte")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("DWord2Byte.Byte_Index must be 0 to 3!")]
    public class DWord2Byte : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public DWord2Byte()
        {
            m_typesArray.Add(TxPlcSignalDataType.DWord);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("DWord");
            m_namesArray.Add("Byte_Indexnum");
            m_returnValueType = TxPlcSignalDataType.Byte;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            TxPlcValue txPlcValue3 = (TxPlcValue)parameters[1];
            string str = Convert.ToString(txPlcValue2.DWordValue, 2).PadLeft(32, '0');
            int num = txPlcValue3.IntValue + 1;

            string a = str.Substring(str.Length - num * 8, 8);
            ushort pbyte = Convert.ToUInt16(a, 2);
            txPlcValue.ByteValue = pbyte;
            return txPlcValue;
        }
    }
    [TxPlcLogicBehaviorFunction("Real2DWord")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Use dword to pass real type data")]
    public class Real2DWord : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public Real2DWord()
        {
            m_typesArray.Add(TxPlcSignalDataType.Real);
            m_namesArray.Add("Real");
            m_returnValueType = TxPlcSignalDataType.DWord;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];            
            byte[] bytes = BitConverter.GetBytes(txPlcValue2.RealValue);
            txPlcValue.DWordValue = BitConverter.ToUInt32(bytes, 0);
            return txPlcValue;
        }
    }
    [TxPlcLogicBehaviorFunction("DWord2Real")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_SignalConverter")]
    [TxPlcLogicBehaviorFunctionDescription("Read the dword data type(bit string) as real")]
    public class
    DWord2Real : ITxPlcLogicBehaviorFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        public DWord2Real()
        {
            m_typesArray.Add(TxPlcSignalDataType.DWord);
            m_namesArray.Add("DWord");
            m_returnValueType = TxPlcSignalDataType.Real;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters)
        {
            TxPlcValue txPlcValue = new TxPlcValue();
            TxPlcValue txPlcValue2 = (TxPlcValue)parameters[0];
            byte[] bytes = BitConverter.GetBytes(txPlcValue2.DWordValue);
            txPlcValue.RealValue = BitConverter.ToSingle(bytes,0);
            return txPlcValue;
        }
    }
}
namespace DisplayBlank
{
    [TxPlcLogicBehaviorFunction("Display/Blank")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_DisplayBlank")]
    [TxPlcLogicBehaviorFunctionDescription("the object will display when Singal is true,otherwise the object will blank")]
    public class DisplayOnSignal : ITxPlcLogicBehaviorInvokingResourceFunction
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        private List<ITxDevice> m_diaplayDevice = new List<ITxDevice>();

        public DisplayOnSignal()
        {
            m_typesArray.Add(TxPlcSignalDataType.Bool);

            m_namesArray.Add("Signal[BOOL]");
            m_returnValueType = TxPlcSignalDataType.Bool;
        }

        public TxPlcValue Evaluate(ArrayList parameters, ITxObject invokingResource)
        {
            TxPlcValue txPlcValue = parameters[0] as TxPlcValue;
            TxPlcValue txPlcValue2 = new TxPlcValue();
            ITxDisplayableObject txObject = (ITxDisplayableObject)invokingResource;
            if (txObject != null)
            {
                if (object.Equals(true, txPlcValue.BooleanValue))
                {
                    txObject.Display();
                    txPlcValue2.BooleanValue = true;
                }
                else
                {
                    txObject.Blank();
                    txPlcValue2.BooleanValue = false;
                }
            }
            return txPlcValue2;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }
    }
}
namespace DistanceMeasurement
{
    [TxPlcLogicBehaviorFunction("DistanceMeasurementV1.0")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_Measurement")]
    [TxPlcLogicBehaviorFunctionDescription("only used to measurement distance with part appearance,you must master the sensor befor measurement")]
    public class DistanceMeasurement : ITxPlcLogicBehaviorFunctionBase, ITxPlcLogicBehaviorInvokingResourceFunction

    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;


        public DistanceMeasurement()
        {
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("MeasurementEnable[BOOL]");
            m_namesArray.Add("RANGE[INT]");
            m_returnValueType = TxPlcSignalDataType.LReal;
        }
        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters, ITxObject invokingResource)
        {
            TxVector tpointOnObject;
            TxVector tpointOnOtherObject;
            TxTransformation txTransformation = null;
            ArrayList distances = new ArrayList();
            bool measEnable = ((TxPlcValue)parameters[0]).BooleanValue;
            float realValue = ((TxPlcValue)parameters[1]).RealValue;
            TxPlcValue result = new TxPlcValue();
            List<TxPartAppearance> CheckedObjects = new List<TxPartAppearance>();
            ITxLocatableObject txLocatableObject = invokingResource as ITxLocatableObject;
            foreach (TxPartAppearance allDescendant in TxApplication.ActiveDocument.PhysicalRoot.GetAllDescendants(new TxTypeFilter(typeof(TxPartAppearance))))
            {
                CheckedObjects.Add(allDescendant);
            }
            if ((txLocatableObject != null) & measEnable)
            {
                for (int i = 0; i < CheckedObjects.Count; i++)
                {

                    if ((CheckedObjects[i] is ITxLocatableObject)&& (CheckedObjects[i]).Visibility==TxDisplayableObjectVisibility.All)
                    {
                        double dis ;
                        bool anv ;
                        try
                        {
                            (CheckedObjects[i] as ITxLocatableObject).GetMinimalDistance(txLocatableObject, out dis, out tpointOnObject, out tpointOnOtherObject);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        txTransformation = new TxTransformation(tpointOnObject, tpointOnOtherObject);
                        double X=Math.Abs(tpointOnObject.X - tpointOnOtherObject.X);
                        double Y = Math.Abs(tpointOnObject.Y - tpointOnOtherObject.Y);
                        double Z = Math.Abs(tpointOnObject.Z - tpointOnOtherObject.Z);
                        if (X<2&&Y<2)
                        {
                           anv = true;
                        }
                        else if (Y<2&&Z<2)
                        {
                            anv = true;
                        }
                        else if(Z<2&&X<2)
                        {
                            anv = true;
                        }
                        else
                        {
                            anv=false;
                        }                        
                        if (dis <= (double)realValue & dis > 0 & anv)
                        {
                            distances.Add(dis);
                        }

                    }
                }
                distances.Sort();
                if (distances.Count > 0)
                {
                    result.LRealValue = (double)distances[0];
                }
                else
                {
                    result.LRealValue = 0;
                }
            }
            else
            {
                distances.RemoveRange(0, distances.Count);
                result.LRealValue = 0;
            }
            return result;
        }
        private double AngleCalc(double A, double B, double C)
        {
            double XY = Math.Sqrt(A * A + B * B);
            double anglee = Math.Asin(XY / C);
            return anglee;
        }
    }
    [TxPlcLogicBehaviorFunction("DistanceMeasurementV3.0[Beta][Useless]")]
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_Measurement")]
    [TxPlcLogicBehaviorFunctionDescription("Beta version,only used to measurement distance with part appearance")]
    public class DistanceMeasurementV3 : ITxPlcLogicBehaviorFunctionBase, ITxPlcLogicBehaviorInvokingResourceFunction

    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        private List<ITxPartAppearance> m_partAppearances = new List<ITxPartAppearance>();

        private bool m_shouldRegisterToEvent = true;

        bool isInRange = false;
        double distance = 0;
        double DIS = 0;

        public DistanceMeasurementV3()
        {
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("MeasurementEnable[BOOL]");
            m_namesArray.Add("RANGE[INT]");
            m_returnValueType = TxPlcSignalDataType.LReal;
        }
        private void RegisterToEvenets()
        {
            foreach (ITxPartAppearance allDescendant in TxApplication.ActiveDocument.PhysicalRoot.GetAllDescendants(new TxTypeFilter(typeof(ITxPartAppearance))))
            {
                m_partAppearances.Add(allDescendant);
                allDescendant.Deleted += partApperance_Deleted;
            }
            TxApplication.ActiveDocument.PhysicalRoot.ItemCreated += PhysicalRoot_ItemCreated;
            TxApplication.ActiveDocument.SimulationPlayer.SimulationCleared += SimulationPlayer_SimulationCleared;
        }
        private void PhysicalRoot_ItemCreated(object sender, TxObjectRoot_ItemCreatedEventArgs args)
        {
            if (args.Item is ITxPartAppearance)
            {
                ITxPartAppearance txPartAppearance = args.Item as ITxPartAppearance;
                if (!m_partAppearances.Contains(txPartAppearance))
                {
                    m_partAppearances.Add(txPartAppearance);
                    txPartAppearance.Deleted += partApperance_Deleted;
                }
            }
        }
        private void partApperance_Deleted(object sender, TxObject_DeletedEventArgs args)
        {
            ITxPartAppearance item = sender as ITxPartAppearance;
            if (m_partAppearances.Contains(item))
            {
                m_partAppearances.Remove(item);
            }
        }
        private void SimulationPlayer_SimulationCleared(object sender, TxSimulationPlayer_SimulationClearedEventArgs args)
        {
            TxApplication.ActiveDocument.PhysicalRoot.ItemCreated -= PhysicalRoot_ItemCreated;
            TxApplication.ActiveDocument.SimulationPlayer.SimulationCleared -= SimulationPlayer_SimulationCleared;
            m_partAppearances.Clear();
            m_shouldRegisterToEvent = true;
        }
        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters, ITxObject invokingResource)
        {
            ArrayList distances = new ArrayList();
            if (m_shouldRegisterToEvent)
            {
                m_shouldRegisterToEvent = false;
                RegisterToEvenets();
            }
            bool measEnable = ((TxPlcValue)parameters[0]).BooleanValue;
            float realValue = ((TxPlcValue)parameters[1]).RealValue;
            TxPlcValue result = new TxPlcValue();

            ITxLocatableObject txLocatableObject = (ITxLocatableObject)invokingResource;
            TxFrameCreationData txFrameCreationData = new TxFrameCreationData("POINT", txLocatableObject.AbsoluteLocation);
            TxFrame txFrame = TxApplication.ActiveDocument.PhysicalRoot.CreateFrame(txFrameCreationData);
            
            TxTransformation moveStep = new TxTransformation(new TxVector(0, 0, 1), TxTransformation.TxTransformationType.Translate);
            if (measEnable == true)
            {
                do
                {
                    txFrame.AbsoluteLocation *= moveStep;
                    distance += 1;
                    foreach (ITxLocatableObject item in m_partAppearances)
                    {
                        if (item.IsObjectInRange(txFrame, 0.1))
                        {
                            
                            isInRange = true;
                            DIS = distance;
                        }
                    }
                } while (isInRange == false || distance < realValue);
            }
            txFrame.Delete();
            TxApplication.RefreshDisplay();
            result.RealValue = (float)DIS;
            return result;

        }
    }
    [TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_Measurement")]
    [TxPlcLogicBehaviorFunction("VisualMeasurement[Beta]")]
    [TxPlcLogicBehaviorFunctionDescription("XXX")]
    public class VisualMeasurement : ITxPlcLogicBehaviorInvokingResourceFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        private TxPlcSignalDataType m_returnValueType;

        private List<ITxPartAppearance> m_partAppearances = new List<ITxPartAppearance>();

        private List<ITxPartAppearance> m_doDelete = new List<ITxPartAppearance>();

        private bool m_shouldRegisterToEvent = true;

        public VisualMeasurement()
        {
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add(TxPlcSignalDataType.LReal);
            m_typesArray.Add(TxPlcSignalDataType.LReal);
            m_typesArray.Add(TxPlcSignalDataType.LReal);
            m_typesArray.Add(TxPlcSignalDataType.LReal);
            m_typesArray.Add(TxPlcSignalDataType.LReal);
            m_typesArray.Add(TxPlcSignalDataType.LReal);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_typesArray.Add(TxPlcSignalDataType.Int);
            m_namesArray.Add("VisualEnable[BOOL]");
            m_namesArray.Add("Basic_X[LREAL]");
            m_namesArray.Add("Basic_Y[LREAL]");
            m_namesArray.Add("Basic_Z[LREAL]");
            m_namesArray.Add("Basic_RX[LREAL]");
            m_namesArray.Add("Basic_RY[LREAL]");
            m_namesArray.Add("Basic_RZ[LREAL]");
            m_namesArray.Add("INDEXNUM[INT] 1:X 2:Y 3:Z 4:RX 5:RY 6:RZ");
            m_namesArray.Add("RANGE[INT]");
            m_returnValueType = TxPlcSignalDataType.LReal;
        }

        private void RegisterToEvenets()
        {
            foreach (ITxPartAppearance allDescendant in TxApplication.ActiveDocument.PhysicalRoot.GetAllDescendants(new TxTypeFilter(typeof(ITxPartAppearance))))
            {
                m_partAppearances.Add(allDescendant);
                allDescendant.Deleted += partApperance_Deleted;
            }

            TxApplication.ActiveDocument.PhysicalRoot.ItemCreated += PhysicalRoot_ItemCreated;
            TxApplication.ActiveDocument.SimulationPlayer.SimulationCleared += SimulationPlayer_SimulationCleared;
        }

        private void SimulationPlayer_SimulationCleared(object sender, TxSimulationPlayer_SimulationClearedEventArgs args)
        {
            TxApplication.ActiveDocument.PhysicalRoot.ItemCreated -= PhysicalRoot_ItemCreated;
            TxApplication.ActiveDocument.SimulationPlayer.SimulationCleared -= SimulationPlayer_SimulationCleared;
            m_partAppearances.Clear();
            m_shouldRegisterToEvent = true;
        }

        private void PhysicalRoot_ItemCreated(object sender, TxObjectRoot_ItemCreatedEventArgs args)
        {
            if (args.Item is ITxPartAppearance)
            {
                ITxPartAppearance txPartAppearance = args.Item as ITxPartAppearance;
                if (!m_partAppearances.Contains(txPartAppearance))
                {
                    m_partAppearances.Add(txPartAppearance);
                    txPartAppearance.Deleted += partApperance_Deleted;
                }
            }
        }

        private void partApperance_Deleted(object sender, TxObject_DeletedEventArgs args)
        {
            ITxPartAppearance item = sender as ITxPartAppearance;
            if (m_partAppearances.Contains(item))
            {
                m_partAppearances.Remove(item);
            }
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }

        public TxPlcValue Evaluate(ArrayList parameters, ITxObject invokingResource)
        {
            if (m_shouldRegisterToEvent)
            {
                m_shouldRegisterToEvent = false;
                RegisterToEvenets();
            }

            bool visualEnable = ((TxPlcValue)parameters[0]).BooleanValue;
            double basic_X = ((TxPlcValue)parameters[1]).LRealValue;
            double basic_Y = ((TxPlcValue)parameters[2]).LRealValue;
            double basic_Z = ((TxPlcValue)parameters[3]).LRealValue;
            double basic_RX = ((TxPlcValue)parameters[4]).LRealValue;
            double basic_RY = ((TxPlcValue)parameters[5]).LRealValue;
            double basic_RZ = ((TxPlcValue)parameters[6]).LRealValue;
            short indexNum = ((TxPlcValue)parameters[7]).IntValue;
            short visualRange = ((TxPlcValue)parameters[8]).IntValue;
            TxPlcValue result = new TxPlcValue();
            ArrayList distances = new ArrayList();
            ArrayList rotates = new ArrayList();
            ITxLocatableObject txLocatableObject = invokingResource as ITxLocatableObject;
            if ((txLocatableObject != null) & visualEnable)
            {
                TxTransformation absoluteLocation = txLocatableObject.AbsoluteLocation;
                for (int i = 0; i < m_partAppearances.Count; i++)
                {
                    ITxPartAppearance txPartAppearance = m_partAppearances[i];
                    if (txPartAppearance is ITxLocatableObject)
                    {
                        TxVector translation = (absoluteLocation - (txPartAppearance as ITxLocatableObject).AbsoluteLocation).Translation;
                        if (Lenght(translation) < visualRange)
                        {
                            distances.Add(translation);
                            rotates.Add(((ITxLocatableObject)txPartAppearance).AbsoluteLocation.RotationRPY_XYZ);
                        }
                    }
                }
            }
            else
            {
                distances.Clear();
                rotates.Clear();
            }
            for (int i = distances.Count - 1; i > 0; i--)
            {
                if (Lenght((TxVector)distances[i]) < Lenght((TxVector)distances[i - 1]))
                {
                    distances[i - 1] = distances[i];
                    rotates[i - 1] = rotates[i];
                }
            }
            if (distances.Count > 0)
            {
                switch (indexNum)
                {
                    case 1:
                        result.LRealValue = ((TxVector)distances[0]).X - basic_X;
                        break;
                    case 2:
                        result.LRealValue = ((TxVector)distances[0]).Y - basic_Y;
                        break;
                    case 3:
                        result.LRealValue = ((TxVector)distances[0]).Z - basic_Z;
                        break;
                    case 4:
                        result.LRealValue = ((TxVector)rotates[0]).X - basic_RX;
                        break;
                    case 5:
                        result.LRealValue = ((TxVector)rotates[0]).Y - basic_RY;
                        break;
                    case 6:
                        result.LRealValue = ((TxVector)rotates[0]).Z - basic_RZ;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        private double Lenght(TxVector translation)
        {
            return Math.Sqrt(translation.X * translation.X + translation.Y * translation.Y + translation.Z * translation.Z);
        }
    }
}

namespace DriveDevice
{ 
[TxPlcLogicBehaviorFunctionCategory("ZTFLBFunction_DriveDevice")]
    [TxPlcLogicBehaviorFunction("DriveDevice")]
    [TxPlcLogicBehaviorFunctionDescription("Drive the devices without power,the device name must be \"SKid\"")]
    public class DriveDevice : ITxPlcLogicBehaviorInvokingResourceFunction, ITxPlcLogicBehaviorFunctionBase
    {
        private ArrayList m_typesArray = new ArrayList();

        private ArrayList m_namesArray = new ArrayList();

        bool statue;
        private TxPlcSignalDataType m_returnValueType;

        public DriveDevice()
        {
            m_typesArray.Add("DriveEnable[BOOL]");
            m_typesArray.Add("CheckRang[REAL]");
            m_typesArray.Add(TxPlcSignalDataType.Bool);
            m_typesArray.Add (TxPlcSignalDataType.Real);
            m_returnValueType = TxPlcSignalDataType.Bool;
        }
        public ArrayList ParametersNames()
        {
            return m_namesArray;
        }

        public ArrayList ParametersTypes()
        {
            return m_typesArray;
        }

        public TxPlcSignalDataType ReturnValueType()
        {
            return m_returnValueType;
        }
        public TxPlcValue Evaluate(ArrayList parameters, ITxObject invokingResource)
        {
            ITxObject followDevice = null;
            TxJoint driveJoint = null;
            TxJoint followJoint = null;
            bool enableDrive = ((TxPlcValue)parameters[0]).BooleanValue;
            double range = ((TxPlcValue)parameters[1]).RealValue;
            ITxLocatableObject driveDevice = invokingResource as ITxLocatableObject;
            TxPlcValue returnValue = new TxPlcValue();
            if (enableDrive )
            {
                TxObjectList skids = TxApplication.ActiveDocument.GetObjectsByName("Skid");
                foreach (ITxLocatableObject skid in skids)
                {
                    TxVector txVector = (driveDevice.AbsoluteLocation - skid.AbsoluteLocation).Translation;
                    if (Length(txVector)<range) 
                    { 
                        followDevice = skid;
                        break;
                    }
                }
                if (followDevice != null &&followDevice!=null) 
                {
                    foreach (var joint in ((TxDevice)driveDevice).Joints)
                    {
                        if (joint.Name=="j1")
                        {
                            driveJoint=joint;
                            break;
                        }
                    }
                    foreach (var joint in ((TxDevice)followDevice).Joints)
                    {
                        if (joint.Name == "j1")
                        {
                            followJoint = joint;
                            break;
                        }
                    }
                    followJoint.CurrentValue=driveJoint.CurrentValue;
                    statue = true;
                }
                else 
                {
                    statue = false;
                }
            }
            else
            { 
                statue = false; 
            }
            returnValue.BooleanValue = statue;
            return returnValue;
        }
        private double Length(TxVector txVector)
        {
            return Math.Sqrt(Math.Pow(txVector.X, 2)+Math.Pow(txVector.X, 2)+Math.Pow(txVector.X, 2));
        }
    }
}


