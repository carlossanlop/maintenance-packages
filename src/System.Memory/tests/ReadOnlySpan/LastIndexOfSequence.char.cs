// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Xunit;

namespace System.SpanTests
{
    public static partial class ReadOnlySpanTests
    {
        [Fact]
        public static void LastIndexOfSequenceMatchAtStart_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '5', '1', '7', '2', '3', '7', '7', '4', '5', '7', '7', '7', '8', '6', '6', '7', '7', '8', '9' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '5', '1', '7' });
            int index = span.LastIndexOf(value);
            Assert.Equal(0, index);
        }

        [Fact]
        public static void LastIndexOfSequenceMultipleMatch_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '1', '2', '3', '1', '2', '3', '1', '2', '3', '1' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '2', '3' });
            int index = span.LastIndexOf(value);
            Assert.Equal(7, index);
        }

        [Fact]
        public static void LastIndexOfSequenceRestart_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '5', '1', '7', '2', '3', '7', '7', '4', '5', '7', '7', '7', '8', '6', '6', '7', '7', '6', '9', '7', '0', '1' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '7', '7', '8' });
            int index = span.LastIndexOf(value);
            Assert.Equal(10, index);
        }

        [Fact]
        public static void LastIndexOfSequenceNoMatch_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '7', '2', '3', '7', '7', '4', '5', '7', '7', '7', '8', '6', '6', '7', '7', '8', '9' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '7', '7', '8', 'X' });
            int index = span.LastIndexOf(value);
            Assert.Equal(-1, index);
        }

        [Fact]
        public static void LastIndexOfSequenceNotEvenAHeadMatch_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '7', '2', '3', '7', '7', '4', '5', '7', '7', '7', '8', '6', '6', '7', '7', '8', '9' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { 'X', '7', '8', '9' });
            int index = span.LastIndexOf(value);
            Assert.Equal(-1, index);
        }

        [Fact]
        public static void LastIndexOfSequenceMatchAtVeryEnd_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '2', '3', '4', '5' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '3', '4', '5' });
            int index = span.LastIndexOf(value);
            Assert.Equal(3, index);
        }

        [Fact]
        public static void LastIndexOfSequenceJustPastVeryEnd_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '2', '3', '4', '5' }, 0, 5);
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '3', '4', '5' });
            int index = span.LastIndexOf(value);
            Assert.Equal(-1, index);
        }

        [Fact]
        public static void LastIndexOfSequenceZeroLengthValue_Char()
        {
            // A zero-length value is always "found" at the start of the span.
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '7', '2', '3', '7', '7', '4', '5', '7', '7', '7', '8', '6', '6', '7', '7', '8', '9' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(Array.Empty<char>());
            int index = span.LastIndexOf(value);
            Assert.Equal(0, index);
        }

        [Fact]
        public static void LastIndexOfSequenceZeroLengthSpan_Char()
        {
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(Array.Empty<char>());
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '1', '2', '3' });
            int index = span.LastIndexOf(value);
            Assert.Equal(-1, index);
        }

        [Fact]
        public static void LastIndexOfSequenceLengthOneValue_Char()
        {
            // A zero-length value is always "found" at the start of the span.
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '2', '3', '4', '5' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '2' });
            int index = span.LastIndexOf(value);
            Assert.Equal(2, index);
        }

        [Fact]
        public static void LastIndexOfSequenceLengthOneValueAtVeryEnd_Char()
        {
            // A zero-length value is always "found" at the start of the span.
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '2', '3', '4', '5' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '5' });
            int index = span.LastIndexOf(value);
            Assert.Equal(5, index);
        }

        [Fact]
        public static void LastIndexOfSequenceLengthOneValueMultipleTimes_Char()
        {
            // A zero-length value is always "found" at the start of the span.
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '5', '3', '4', '5' });
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '5' });
            int index = span.LastIndexOf(value);
            Assert.Equal(5, index);
        }

        [Fact]
        public static void LastIndexOfSequenceLengthOneValueJustPasttVeryEnd_Char()
        {
            // A zero-length value is always "found" at the start of the span.
            ReadOnlySpan<char> span = new ReadOnlySpan<char>(new char[] { '0', '1', '2', '3', '4', '5' }, 0, 5);
            ReadOnlySpan<char> value = new ReadOnlySpan<char>(new char[] { '5' });
            int index = span.LastIndexOf(value);
            Assert.Equal(-1, index);
        }
    }
}
