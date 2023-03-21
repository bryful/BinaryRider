using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryRider
{
	public class BSize
	{
		// *******************************************************
		private EditBinary? m_BE = null;
		public void SetEditBinary(EditBinary be)
		{
			m_BE = be;
			if (m_BE != null)
			{
				//ChkSize();
			}
		}
		// *******************************************************
		/// <summary>
		/// １行のピクセル数
		/// </summary>
		public int LineHeight { get; set; } = 18;
		/// <summary>
		/// 絶対アドレス表示の横幅
		/// </summary>
		public int AdrWidth1 { get; set; } = 50;
		/// <summary>
		/// 相対アドレス表示の横幅
		/// </summary>
		public int AdrWidth2 { get; set; } = 30;
		/// <summary>
		/// アドレスの横幅
		/// </summary>
		public int AdrWidthAll
		{
			get
			{
				return AdrWidth1 + AdrWidth2;
			}
		}   
		/// <summary>
		/// アドレスとバイト表示の間の幅
		/// </summary>
		public int AdrSide { get; set; } = 5;
		/// <summary>
		/// バイト表示の横幅
		/// </summary>
		public int ByteWidth { get; set; } = 24;
		/// <summary>
		/// バイトと文字の間の幅
		/// </summary>
		public int ByteSide { get; set; } = 24;
		/// <summary>
		/// 文字表示の横幅
		/// </summary>
		public int CharWidth { get; set; } = 12;

		public int ByteLeft
		{
			get { return AdrWidth1 + AdrWidth2 + AdrSide; }
		}
		public int CharLeft
		{
			get 
			{
				int x = 0x10;
				if (m_BE != null)
				{
					x = (int)m_BE.BDisp.DispMode;
				}
				return  (ByteWidth * x) + ByteSide;
			}
		}
		public int HeaderWidth
		{
			get 
			{
				int x = 16;
				if(m_BE!=null)
				{
					x = (int)m_BE.BDisp.DispMode;
				}
				return (ByteWidth + CharWidth) * x + ByteSide;
			}
		}

	}
}
