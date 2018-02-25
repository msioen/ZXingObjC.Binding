using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

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
        }

        public override void Close()
        {
            base.Close();
            _capture.Layer.RemoveFromSuperLayer();
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
