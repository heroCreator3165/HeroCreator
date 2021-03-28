using System.IO;

namespace FileHandling.Loading.BMP
{
    public class BitStreamReader
    {
        BinaryReader m_Reader;
        byte m_Data = 0;
        int m_Bits = 0;

        public BitStreamReader(BinaryReader aReader)
        {
            m_Reader = aReader;
        }
        public BitStreamReader(Stream aStream) : this(new BinaryReader(aStream)) { }

        public byte ReadBit()
        {
            if (m_Bits <= 0)
            {
                m_Data = m_Reader.ReadByte();
                m_Bits = 8;
            }
            return (byte)((m_Data >> --m_Bits) & 1);
        }

        public ulong ReadBits(int aCount)
        {
            ulong val = 0UL;
            if (aCount <= 0 || aCount > 32)
                throw new System.ArgumentOutOfRangeException("aCount", "aCount must be between 1 and 32 inclusive");
            for (int i = aCount - 1; i >= 0; i--)
                val |= ((ulong)ReadBit() << i);
            return val;
        }
        public void Flush()
        {
            m_Data = 0;
            m_Bits = 0;
        }
    }
}