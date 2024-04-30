﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BenchmarkDotNet.Attributes;

namespace PerformanceAnalyzer.Comparison
{
    [MemoryDiagnoser]
    public class CompareMethods
    {
        public int number = 5;

        [Benchmark]
        public string WithStringBUilder()
        {
            // Create StringBuilder object
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                output.Append("Bilal").Append(i);
            }
            return output.ToString();
        }

        [Benchmark]
        public string WithString()
        {
            string strOutput = string.Empty;
            for (int i = 0; i < number; i++)
            {
                strOutput = $"{strOutput}Bilal{i}";
            }
            return strOutput;
        }
    }
}