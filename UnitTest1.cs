using Bill_Number_Parser;
using Xunit;

namespace Bill_Number_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void HB04_Uppercase_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("HB04");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.H, billNumber.BillChamber);
            Assert.Equal(BillType.B, billNumber.BillType);
            Assert.Equal(4, billNumber.Number);
            Assert.Equal("HB00004", billNumber.BillNumberLong());
            Assert.Equal("HB4", billNumber.BillNumberShort());
            Assert.Equal("House Bill 4", billNumber.BillFullName());
        }

        [Fact]
        public void Static_Method_Validation_Is_Correct()
        {
            // Assert
            Assert.True(BillNumber.ValidateBillNumber("HB04"));
        }

        [Fact]
        public void HB04_Lowercase_WithWhitespace_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("  hb04  ");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("HB00004", billNumber.BillNumberLong());
            Assert.Equal("HB4", billNumber.BillNumberShort());
        }

        [Fact]
        public void SR123_SenateResolution_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("SR123");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("SR00123", billNumber.BillNumberLong());
            Assert.Equal("SR123", billNumber.BillNumberShort());
        }

        [Fact]
        public void HJR_EmbeddedWhitespace_IsParsedCorrectly()
        {
            BillNumber billNumber = new BillNumber("HJR 01374");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("HJR01374", billNumber.BillNumberLong());
            Assert.Equal("HJR1374", billNumber.BillNumberShort());
        }

        [Fact]
        public void HCR12_CRType_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("SCR12");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("SCR00012", billNumber.BillNumberLong());
            Assert.Equal("SCR12", billNumber.BillNumberShort());
        }

        [Fact]
        public void SB007_SenateBill_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("SB007");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("SB00007", billNumber.BillNumberLong());
            Assert.Equal("SB7", billNumber.BillNumberShort());
        }

        [Fact]
        public void SJR045_Lowercase_WithWhitespace_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("  sjr045  ");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("SJR00045", billNumber.BillNumberLong());
            Assert.Equal("SJR45", billNumber.BillNumberShort());
        }

        [Fact]
        public void HCR9_HouseConcurrentResolution_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("HCR9");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("HCR00009", billNumber.BillNumberLong());
            Assert.Equal("HCR9", billNumber.BillNumberShort());
        }

        [Fact]
        public void HR100_MixedCase_WithWhitespace_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber(" hr100 ");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal("HR00100", billNumber.BillNumberLong());
            Assert.Equal("HR100", billNumber.BillNumberShort());
        }

        [Fact]
        public void HB00_NumberZero_ThrowsArgumentException()
        {
            // Zero is not a valid bill number
            Assert.Throws<ArgumentException>(() => new BillNumber("HB00"));
        }

        [Fact]
        public void XB123_InvalidChamber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BillNumber("XB123"));
        }

        [Fact]
        public void HB100000_NumberTooLarge_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BillNumber("HB100000"));
        }

        [Fact]
        public void OnlyWhitespace_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BillNumber(""));
        }

        [Fact]
        public void MissingBillNumber_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BillNumber("HB"));
        }
    }
}
