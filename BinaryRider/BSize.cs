using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

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
		public bool GetSizeFromFont()
		{
			bool ret = false;
			if (m_BE == null) return ret;

			using (StringFormat format = new StringFormat(StringFormat.GenericTypographic))
			using (Bitmap bmp = new Bitmap(200,50,PixelFormat.Format32bppArgb))
			{
				Graphics g = Graphics.FromImage(bmp);
				SizeF szF = g.MeasureString("FFFF", m_BE.Font, 100, format);
				int w = (int)(szF.Width/4+0.5);
				int h = (int)(szF.Height+0.5);

				LineHeight = h;
				AdrWidth1 = w * 10;
				AdrWidth2 = w * 1;
				ByteWidth = (int)((double)w * 4);
				CharWidth = (int)((double)w * 1.5);
				ret = true;
			}
			return ret;
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
		public int ByteSide { get; set; } = 10;
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
				return  (ByteWidth * BDisp.HexC) + ByteSide;
			}
		}
		public int HeaderWidth
		{
			get 
			{
				return (ByteWidth + CharWidth) * BDisp.HexC + ByteSide + CharWidth;
			}
		}

	}
}
