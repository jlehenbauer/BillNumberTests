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
            Assert.Equal(Chamber.H, billNumber.BillChamber);
            Assert.Equal(BillType.B, billNumber.BillType);
            Assert.Equal(4, billNumber.Number);
            Assert.Equal("HB00004", billNumber.BillNumberLong());
            Assert.Equal("HB4", billNumber.BillNumberShort());
            Assert.Equal("House Bill 4", billNumber.BillFullName());
        }

        [Fact]
        public void SR123_SenateResolution_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("SR123");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.S, billNumber.BillChamber);
            Assert.Equal(BillType.R, billNumber.BillType);
            Assert.Equal(123, billNumber.Number);
            Assert.Equal("SR00123", billNumber.BillNumberLong());
            Assert.Equal("SR123", billNumber.BillNumberShort());
            Assert.Equal("Senate Resolution 123", billNumber.BillFullName());
        }

        [Fact]
        public void HJR_EmbeddedWhitespace_IsParsedCorrectly()
        {
            BillNumber billNumber = new BillNumber("HJR 01374");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.H, billNumber.BillChamber);
            Assert.Equal(BillType.JR, billNumber.BillType);
            Assert.Equal(1374, billNumber.Number);
            Assert.Equal("HJR01374", billNumber.BillNumberLong());
            Assert.Equal("HJR1374", billNumber.BillNumberShort());
            Assert.Equal("House Joint Resolution 1374", billNumber.BillFullName());
        }

        [Fact]
        public void HCR12_CRType_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("SCR12");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.S, billNumber.BillChamber);
            Assert.Equal(BillType.CR, billNumber.BillType);
            Assert.Equal(12, billNumber.Number);
            Assert.Equal("SCR00012", billNumber.BillNumberLong());
            Assert.Equal("SCR12", billNumber.BillNumberShort());
            Assert.Equal("Senate Concurrent Resolution 12", billNumber.BillFullName());
        }

        [Fact]
        public void SB007_SenateBill_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("SB007");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.S, billNumber.BillChamber);
            Assert.Equal(BillType.B, billNumber.BillType);
            Assert.Equal(7, billNumber.Number);
            Assert.Equal("SB00007", billNumber.BillNumberLong());
            Assert.Equal("SB7", billNumber.BillNumberShort());
            Assert.Equal("Senate Bill 7", billNumber.BillFullName());
        }

        [Fact]
        public void SJR045_Lowercase_WithWhitespace_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("  sjr045  ");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.S, billNumber.BillChamber);
            Assert.Equal(BillType.JR, billNumber.BillType);
            Assert.Equal(45, billNumber.Number);
            Assert.Equal("SJR00045", billNumber.BillNumberLong());
            Assert.Equal("SJR45", billNumber.BillNumberShort());
            Assert.Equal("Senate Joint Resolution 45", billNumber.BillFullName());
        }

        [Fact]
        public void HCR9_HouseConcurrentResolution_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber("HCR9");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.H, billNumber.BillChamber);
            Assert.Equal(BillType.CR, billNumber.BillType);
            Assert.Equal(9, billNumber.Number);
            Assert.Equal("HCR00009", billNumber.BillNumberLong());
            Assert.Equal("HCR9", billNumber.BillNumberShort());
            Assert.Equal("House Concurrent Resolution 9", billNumber.BillFullName());
        }

        [Fact]
        public void HR100_MixedCase_WithWhitespace_IsParsedCorrectly()
        {
            // Arrange
            BillNumber billNumber = new BillNumber(" hr100 ");

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.H, billNumber.BillChamber);
            Assert.Equal(BillType.R, billNumber.BillType);
            Assert.Equal(100, billNumber.Number);
            Assert.Equal("HR00100", billNumber.BillNumberLong());
            Assert.Equal("HR100", billNumber.BillNumberShort());
            Assert.Equal("House Resolution 100", billNumber.BillFullName());
        }

        [Fact]
        public void HR100_MixedCase_WithWhitespace_IsInstantiated()
        {
            // Arrange
            BillNumber billNumber = new BillNumber(Chamber.H, BillType.R, 100);

            // Assert
            Assert.True(billNumber.IsValidBillNumber());
            Assert.True(billNumber.IsValid);
            Assert.Equal(Chamber.H, billNumber.BillChamber);
            Assert.Equal(BillType.R, billNumber.BillType);
            Assert.Equal(100, billNumber.Number);
            Assert.Equal("HR00100", billNumber.BillNumberLong());
            Assert.Equal("HR100", billNumber.BillNumberShort());
            Assert.Equal("House Resolution 100", billNumber.BillFullName());
        }

        [Fact]
        public void Repeated_Valid_Characters_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BillNumber("HHHHBBBBBBB02"));
        }

        [Fact]
        public void HB00_NumberZero_ThrowsArgumentException()
        {
            // Zero is not a valid bill number
            Assert.Throws<ArgumentException>(() => new BillNumber("HB00"));
        }

        [Fact]
        public void HB00_NumberZero_Constructor_ThrowsArgumentException()
        {
            // Zero is not a valid bill number
            Assert.Throws<ArgumentException>(() => new BillNumber(Chamber.H, BillType.B, 0));
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
