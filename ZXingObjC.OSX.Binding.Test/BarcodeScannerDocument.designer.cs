using Foundation;

namespace ZXingObjC.OSX.Binding.Test
{

    // Should subclass AppKit.NSDocument
    [Foundation.Register("BarcodeScannerDocument")]
    public partial class BarcodeScannerDocument
    {
        [Outlet]
        AppKit.NSView previewView { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (previewView != null)
            {
                previewView.Dispose();
                previewView = null;
            }
        }
    }
}
