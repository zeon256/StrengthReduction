using StrengthReduction;

namespace StrengthReductionTest;

public class StrengthReduceTest
{
    [Test]
    public void TestWrappingMul()
    {
        Assert.AreEqual((byte)(12 * 10), (byte)120);
        Assert.AreEqual(unchecked((byte)(25 * 12)), (byte)44);
    }

    [Test]
    public void TestEq()
    {
        StrengthReduceU8 a = 3;
        StrengthReduceU8 b = 3;
        Console.WriteLine(a);
        Assert.AreEqual(a, b);
        StrengthReduceU16 c = 3;
        StrengthReduceU16 d = 3;
        Assert.AreEqual(c, d);
        StrengthReduceU32 e = 3;
        StrengthReduceU32 f = 3;
        Assert.AreEqual(e, f);
        StrengthReduceU64 g = 3;
        StrengthReduceU64 h = 3;
        Assert.AreEqual(g, h);
    }

    [Test]
    public void TestByte()
    {
        const byte max = byte.MaxValue;
        byte[] divisors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, max - 1, max };
        byte[] numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        foreach (var divisor in divisors)
        {
            StrengthReduceU8 reduced = divisor;
            foreach (var numerator in numerators)
            {
                Console.WriteLine($"Testing {numerator} / {divisor}");
                var expectedDiv = (byte)(numerator / divisor);
                var expectedRem = (byte)(numerator % divisor);
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
                var (reducedCombinedDiv, reducedCombinedRem) = StrengthReduceU8.DivRem(numerator, reduced);
                Assert.AreEqual(expectedDiv, reducedDiv);
                Assert.AreEqual(expectedRem, reducedRem);
                Assert.AreEqual(expectedDiv, reducedCombinedDiv);
                Assert.AreEqual(expectedRem, reducedCombinedRem);
            }
        }
    }

    [Test]
    public void TestUShort()
    {
        const ushort max = ushort.MaxValue;
        ushort[] divisors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, max - 1, max };
        ushort[] numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        foreach (var divisor in divisors)
        {
            StrengthReduceU16 reduced = divisor;
            foreach (var numerator in numerators)
            {
                Console.WriteLine($"Testing {numerator} / {divisor}");
                var expectedDiv = (ushort)(numerator / divisor);
                var expectedRem = (ushort)(numerator % divisor);
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
                var (reducedCombinedDiv, reducedCombinedRem) = StrengthReduceU16.DivRem(numerator, reduced);
                Assert.AreEqual(expectedDiv, reducedDiv);
                Assert.AreEqual(expectedRem, reducedRem);
                Assert.AreEqual(expectedDiv, reducedCombinedDiv);
                Assert.AreEqual(expectedRem, reducedCombinedRem);
            }
        }
    }

    [Test]
    public void TestU32()
    {
        const uint max = uint.MaxValue;
        uint[] divisors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, max - 1, max };
        uint[] numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        foreach (var divisor in divisors)
        {
            StrengthReduceU32 reduced = divisor;
            foreach (var numerator in numerators)
            {
                Console.WriteLine($"Testing {numerator} / {divisor}");
                var expectedDiv = numerator / divisor;
                var expectedRem = numerator % divisor;
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
                var (reducedCombinedDiv, reducedCombinedRem) = StrengthReduceU32.DivRem(numerator, reduced);
                Assert.AreEqual(expectedDiv, reducedDiv);
                Assert.AreEqual(expectedRem, reducedRem);
                Assert.AreEqual(expectedDiv, reducedCombinedDiv);
                Assert.AreEqual(expectedRem, reducedCombinedRem);
            }
        }
    }

    [Test]
    public void TestU64()
    {
        const ulong max = ulong.MaxValue;
        ulong[] divisors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, max - 1, max };
        ulong[] numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        foreach (var divisor in divisors)
        {
            StrengthReduceU64 reduced = divisor;
            foreach (var numerator in numerators)
            {
                Console.WriteLine($"Testing {numerator} / {divisor}");
                var expectedDiv = numerator / divisor;
                var expectedRem = numerator % divisor;
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
                var (reducedCombinedDiv, reducedCombinedRem) = StrengthReduceU64.DivRem(numerator, reduced);
                Assert.AreEqual(expectedDiv, reducedDiv);
                Assert.AreEqual(expectedRem, reducedRem);
                Assert.AreEqual(expectedDiv, reducedCombinedDiv);
                Assert.AreEqual(expectedRem, reducedCombinedRem);
            }
        }
    }
}