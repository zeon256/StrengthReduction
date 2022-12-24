using StrengthReduction;

namespace StrengthReductionBencher;

public class StrengthReduceTest
{
    [Test]
    public void TestWrappingMul()
    {
        Assert.AreEqual((byte)(12 * 10), (byte)120);
        Assert.AreEqual(unchecked((byte)(25 * 12)), (byte)44);
    }

    [Test]
    public void TestByte()
    {
        const byte max = byte.MaxValue;
        byte[] divisors = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, max - 1, max };
        byte[] numerators = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        foreach (var divisor in divisors)
        {
            var reduced = new StrengthReduceByte(divisor);
            foreach (var numerator in numerators)
            {
                Console.WriteLine($"Testing {numerator} / {divisor}");
                var expectedDiv = (byte)(numerator / divisor);
                var expectedRem = (byte)(numerator % divisor);
                var reducedDiv = numerator / reduced;
                var reducedRem = numerator % reduced;
                var (reducedCombinedDiv, reducedCombinedRem) = StrengthReduceByte.DivRem(numerator, reduced);
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
            var reduced = new StrengthReduceU16(divisor);
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
            var reduced = new StrengthReduceU32(divisor);
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
            var reduced = new StrengthReduceU64(divisor);
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