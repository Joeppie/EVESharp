﻿using System;
using System.Collections;
using System.Collections.Generic;
using EVESharp.Types.Serialization;
using EVESharp.Types.Unit.Marshaling.MarshalData;
using NUnit.Framework;

namespace EVESharp.Types.Unit.Marshaling;

public class PackedRowMarshallingTests
{
    public static IEnumerable<PyPackedRow> GetRows()
    {
        FieldType[] types = Enum.GetValues<FieldType>();
            
        for (int i = 0; i < 100; i++)
        {
            DBRowDescriptor                descriptor = new DBRowDescriptor();
            Dictionary<string, PyDataType> values     = new Dictionary<string, PyDataType>();

            // create 300 columns
            for (int c = 0; c < 500; c++)
            {
                string columnName = $"column{c}";
                // get a type from the list
                FieldType currentType = types[((i+1) * (c+1)) % types.Length];

                if (currentType == FieldType.Error || currentType == FieldType.Null || currentType == FieldType.Empty)
                    currentType = FieldType.UI4;

                values[columnName] = currentType switch
                {
                    FieldType.I1       => 50,
                    FieldType.UI1      => 60,
                    FieldType.I2       => 30000,
                    FieldType.UI2      => 65400,
                    FieldType.I4       => 70000,
                    FieldType.UI4      => 100000,
                    FieldType.I8       => long.MaxValue,
                    FieldType.UI8      => ulong.MaxValue,
                    FieldType.Bool     => c % 2 == 0,
                    FieldType.Bytes    => new byte[] {0x00, 0x50, 0x80},
                    FieldType.WStr     => new PyString("Wórld", true),
                    FieldType.Str      => new PyString("Hello World!"),
                    FieldType.R4       => 100.0,
                    FieldType.R8       => double.MaxValue,
                    FieldType.FileTime => 0,
                    FieldType.CY       => 0,
                    _                  => values[columnName]
                };
                    
                descriptor.Columns.Add(new DBRowDescriptor.Column(columnName, currentType));
            }

            yield return new PyPackedRow(descriptor, values);
        }
    }

    private static IEnumerable Marshal_Arguments()
    {
        IEnumerator first  = new PackedRowMarshalData().GetEnumerator();
        IEnumerator second = GetRows().GetEnumerator();

        while (first.MoveNext() && second.MoveNext())
            yield return new object[] {first.Current, second.Current};
    }

    private static IEnumerable Unmarshal_Arguments()
    {
        IEnumerator first  = GetRows().GetEnumerator();
        IEnumerator second = new PackedRowMarshalData().GetEnumerator();

        while (first.MoveNext() && second.MoveNext())
            yield return new object[] {first.Current, second.Current};
    }
        
    [TestCaseSource(nameof(Marshal_Arguments))]
    public void PackedRowMarshal_Test(byte[] marshalData, PyPackedRow entry)
    {
        byte[] data = Marshal.ToByteArray(entry);

        // helper to generate the file for updating the test data
        // FileStream fp = File.Open(@"C:\development\output.txt", FileMode.Append);
        // StringWriter writer = new StringWriter();
        //
        // writer.Write("yield return new byte [] { 0x");
        //
        // string[] bytes = new string[data.Length];
        //
        // int i = 0;
        //
        // foreach (byte byteEntry in data)
        //     bytes[i++] = byteEntry.ToString("X2");
        //
        // writer.Write(string.Join(", 0x", bytes));
        // writer.Write("};" + Environment.NewLine);
        //
        // fp.Write(Encoding.ASCII.GetBytes(writer.ToString()));
        // fp.Close();
            
        Assert.AreEqual(marshalData, data);
    }
        
    [TestCaseSource(nameof(Unmarshal_Arguments))]
    public void PackedRowUnmarshal_Test(PyPackedRow originalRow, byte[] marshalData)
    {
        PyDataType result = Unmarshal.ReadFromByteArray(marshalData);
            
        Assert.IsInstanceOf<PyPackedRow>(result);
        PyPackedRow row = result as PyPackedRow;
            
        Assert.AreEqual(originalRow.Header.Columns.Count, row.Header.Columns.Count);

        for (int i = 0; i < row.Header.Columns.Count; i++)
        {
            DBRowDescriptor.Column original  = originalRow.Header.Columns[i];
            DBRowDescriptor.Column unmarshal = row.Header.Columns[i];
                
            Assert.AreEqual(original.Name, unmarshal.Name);
            Assert.AreEqual(original.Type, unmarshal.Type);

            Assert.True(originalRow[original.Name] == row[unmarshal.Name]);
        }
    }
}