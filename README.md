OS X binding: [![NuGet Status](http://img.shields.io/nuget/v/ZXingObjC.OSX.Binding.svg?style=flat)](https://www.nuget.org/packages/ZXingObjC.OSX.Binding/)

iOS binding: [![NuGet Status](http://img.shields.io/nuget/v/ZXingObjC.iOS.Binding.svg?style=flat)](https://www.nuget.org/packages/ZXingObjC.iOS.Binding/)

# ZXingObjC.Binding

Xamarin binding for the [ZXingObjC library](https://github.com/TheLevelUp/ZXingObjC)

# ZXingObjC

ZXingObjC is a full Objective-C port of [ZXing](https://github.com/zxing/zxing) ("Zebra Crossing"), a Java barcode image processing library. It is designed to be used on both iOS devices and in Mac applications.

The following barcodes are currently supported for both encoding and decoding:

* UPC-A and UPC-E
* EAN-8 and EAN-13
* Code 39
* Code 93 (not implemented yet)
* Code 128
* ITF
* Codabar
* RSS-14 (all variants)
* QR Code
* Data Matrix
* Aztec ('beta' quality)
* PDF 417 ('alpha' quality)

ZXingObjC currently has feature parity with ZXing version 3.0.

## Usage

Encoding:

```c#
NSError error;
var writer = new ZXMultiFormatWriter();
var result = writer.Format(
    contents: "A string to encode",
    format: ZXBarcodeFormat.QRCode,
    width: 500,
    height: 500,
    error: out error
);

if (result != null)
{
    var image = ZXImage.ImageWithMatrix(result).Cgimage;
}
else
{
    var errorMessage = error.LocalizedDescription;
}
```

Decoding:

```c#
var source = new ZXCGImageLuminanceSource(imageToDecode);
var bitmap = ZXBinaryBitmap.BinaryBitmapWithBinarizer(ZXHybridBinarizer.BinarizerWithSource(source));

NSError error;

// There are a number of hints we can give to the reader, including
// possible formats, allowed lengths, and the string encoding.
var hints = new ZXDecodeHints();

var reader = new ZXMultiFormatReader();
var result = reader.Decode(image: bitmap, hints: hints, error: out error);

if (result != null)
{
    // The coded result as a string. The raw data can be accessed with
    // result.rawBytes and result.length.
    var text = result.Text;
    var format = result.BarcodeFormat;
    Console.WriteLine($"scanned code with format {format} and content {text}");

    return text;
}
else
{
    // Use error to determine why we didn't get a result, such as a barcode
    // not being found, an invalid checksum, or a format inconsistency.
    return null;
}
```

## License

ZXingObjC is available under the [Apache 2.0 license](http://www.apache.org/licenses/LICENSE-2.0.html).
