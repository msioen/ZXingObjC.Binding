using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CoreGraphics;
using System.IO;
using ImageIO;
using MobileCoreServices;

namespace ZXingObjC.OSX.Binding.Test
{
    public partial class BarcodeScannerDocument : AppKit.NSDocument
    {
        ZXCapture _capture;

        public override string WindowNibName { get { return "BarcodeScannerDocument"; } }

        // Called when created from unmanaged code
        public BarcodeScannerDocument(IntPtr handle) : base(handle)
        {
        }

        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);

            _capture = new ZXCapture();
            _capture.Reader = new ZXMultiFormatReader();
            _capture.Rotation = 90.0f;

            _capture.Layer.Frame = previewView.Bounds;
            previewView.Layer.AddSublayer(_capture.Layer);

            _capture.Delegate = new CaptureListener();

            //var image = TestEncode("This is my input");
            //var result = TestDecode(image);
        }

        public override void Close()
        {
            base.Close();
            _capture.Layer.RemoveFromSuperLayer();
        }

        CGImage TestEncode(string contents)
        {
            NSError error;
            var writer = new ZXMultiFormatWriter();
            var result = writer.Format(
                contents: contents,
                format: ZXBarcodeFormat.QRCode,
                width: 500,
                height: 500,
                error: out error
            );

            if (result != null)
            {
                var image = ZXImage.ImageWithMatrix(result).Cgimage;
                return image;
            }
            else
            {
                var errorMessage = error.LocalizedDescription;
                return null;
            }
        }

        string TestDecode(CGImage imageToDecode)
        {
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
        }

        public class CaptureListener : ZXCaptureDelegate
        {
            public override void CaptureResult(ZXCapture capture, ZXResult result)
            {
                if (result != null)
                {
                    var format = result.BarcodeFormat;
                    var text = result.Text;
                    Console.WriteLine($"scanned code with format {format} and content {text}");
                }
            }
        }


    }
}
