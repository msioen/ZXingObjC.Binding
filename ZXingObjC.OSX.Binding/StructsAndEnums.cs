using System.Runtime.InteropServices;
using Foundation;

#if __MACOS__
namespace ZXingObjC.OSX.Binding
#else
namespace ZXingObjC.iOS.Binding
#endif
{
	public enum ZXBarcodeFormat : uint
	{
		Aztec,
		Codabar,
		Code39,
		Code93,
		Code128,
		DataMatrix,
		Ean8,
		Ean13,
		Itf,
		MaxiCode,
		Pdf417,
		QRCode,
		Rss14,
		RSSExpanded,
		Upca,
		Upce,
		UPCEANExtension
	}

	public enum ZXDataMatrixSymbolShapeHint : uint
	{
		None,
		Square,
		Rectangle
	}

	public enum ZXPDF417Compaction : uint
	{
		Auto,
		Text,
		Byte,
		Numeric
	}

	public enum Zx : uint
	{
		ChecksumError = 1000,
		FormatError = 1001,
		NotFoundError = 1002,
		ReedSolomonError = 1003,
		ReaderError = 1004,
		WriterError = 1005
	}

	//static class CFunctions
	//{
	//	// extern NSError * ZXChecksumErrorInstance ();
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSError ZXChecksumErrorInstance ();

	//	// extern NSError * ZXFormatErrorInstance ();
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSError ZXFormatErrorInstance ();

	//	// extern NSError * ZXNotFoundErrorInstance ();
	//	[DllImport ("__Internal")]
	//	[Verify (PlatformInvoke)]
	//	static extern NSError ZXNotFoundErrorInstance ();
	//}

	public enum ZXResultMetadataType : uint
	{
		Other,
		Orientation,
		ByteSegments,
		ErrorCorrectionLevel,
		IssueNumber,
		SuggestedPrice,
		PossibleCountry,
		UPCEANExtension,
		PDF417ExtraMetadata,
		StructuredAppendSequence,
		StructuredAppendParity
	}

	public enum ZxRssPatterns : uint
	{
		ZxRssPatternsRss14Patterns = 0,
		ExpandedPatterns
	}

	public enum ZxUpcEanPatterns : uint
	{
		Patterns = 0,
		AndGPatterns
	}

	public enum ZXParsedResultType : uint
	{
		AddressBook,
		EmailAddress,
		Product,
		Uri,
		Text,
		AndroidIntent,
		Geo,
		Tel,
		Sms,
		Calendar,
		Wifi,
		NDEFSMartPoster,
		MobiletagRichWeb,
		Isbn,
		Vin
	}
}
