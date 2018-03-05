using System;
using AudioToolbox;
using AVFoundation;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace ZXingObjC.iOS.Binding.Test
{
    public partial class ViewController : UIViewController
    {
        private const int NSEC_PER_SEC = 1000000000;

        ZXCapture _capture;
        CGAffineTransform _captureSizeTransform;
        CaptureListener _captureDelegate;

        public ViewController() : base("ViewController", null)
        {
        }

        ~ViewController()
        {
            _capture.Layer.RemoveFromSuperLayer();

            _captureDelegate.CapturedResult -= CaptureDelegate_CapturedResult;
            _captureDelegate = null;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _capture = new ZXCapture();
            _capture.Camera = _capture.Back;
            _capture.FocusMode = AVFoundation.AVCaptureFocusMode.ContinuousAutoFocus;

            _captureDelegate = new CaptureListener();
            _captureDelegate.CapturedResult += CaptureDelegate_CapturedResult;

            View.Layer.AddSublayer(_capture.Layer);

            View.BringSubviewToFront(scanRectView);
            View.BringSubviewToFront(decodedLabel);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            _capture.Delegate = _captureDelegate;
            ApplyOrientation();
        }

        public override bool ShouldAutorotateToInterfaceOrientation(UIInterfaceOrientation toInterfaceOrientation)
        {
            return toInterfaceOrientation == UIInterfaceOrientation.Portrait;
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);
            ApplyOrientation();
        }

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);
            coordinator.AnimateAlongsideTransition(null, (obj) => ApplyOrientation());
        }

        void ApplyOrientation()
        {
            var orientation = UIApplication.SharedApplication.StatusBarOrientation;
            float scanRectRotation;
            float captureRotation;

            switch (orientation)
            {
                case UIInterfaceOrientation.Portrait:
                    captureRotation = 0;
                    scanRectRotation = 90;
                    break;
                case UIInterfaceOrientation.LandscapeLeft:
                    captureRotation = 90;
                    scanRectRotation = 180;
                    break;
                case UIInterfaceOrientation.LandscapeRight:
                    captureRotation = 270;
                    scanRectRotation = 0;
                    break;
                case UIInterfaceOrientation.PortraitUpsideDown:
                    captureRotation = 180;
                    scanRectRotation = 270;
                    break;
                default:
                    captureRotation = 0;
                    scanRectRotation = 90;
                    break;
            }

            ApplyRectOfInterest(orientation);
            var transform = CGAffineTransform.MakeRotation((nfloat)(captureRotation / 180 * Math.PI));
            _capture.Transform = transform;
            _capture.Rotation = scanRectRotation;
            _capture.Layer.Frame = View.Frame;
        }

        void ApplyRectOfInterest(UIInterfaceOrientation orientation)
        {
            nfloat scaleVideo, scaleVideoX, scaleVideoY;
            nfloat videoSizeX, videoSizeY;
            CGRect transformedVideoRect = scanRectView.Frame;
            if (string.Equals(_capture.SessionPreset, AVCaptureSession.Preset1920x1080))
            {
                videoSizeX = 1080;
                videoSizeY = 1920;
            }
            else
            {
                videoSizeX = 720;
                videoSizeY = 1280;
            }
            if (orientation == UIInterfaceOrientation.Portrait || orientation == UIInterfaceOrientation.PortraitUpsideDown)
            {
                scaleVideoX = View.Frame.Size.Width / videoSizeX;
                scaleVideoY = View.Frame.Size.Height / videoSizeY;
                scaleVideo = (nfloat)Math.Max(scaleVideoX, scaleVideoY);
                if (scaleVideoX > scaleVideoY)
                {
                    transformedVideoRect.Y += (scaleVideo * videoSizeY - View.Frame.Size.Height) / 2;
                }
                else
                {
                    transformedVideoRect.X += (scaleVideo * videoSizeX - View.Frame.Size.Width) / 2;
                }
            }
            else
            {
                scaleVideoX = View.Frame.Size.Width / videoSizeY;
                scaleVideoY = View.Frame.Size.Height / videoSizeX;
                scaleVideo = (nfloat)Math.Max(scaleVideoX, scaleVideoY);
                if (scaleVideoX > scaleVideoY)
                {
                    transformedVideoRect.Y += (scaleVideo * videoSizeX - View.Frame.Size.Height) / 2;
                }
                else
                {
                    transformedVideoRect.X += (scaleVideo * videoSizeY - View.Frame.Size.Width) / 2;
                }
            }
            _captureSizeTransform = CGAffineTransform.MakeScale(1 / scaleVideo, 1 / scaleVideo);
            _capture.ScanRect = CGAffineTransform.CGRectApplyAffineTransform(transformedVideoRect, _captureSizeTransform);
        }

        void CaptureDelegate_CapturedResult(object sender, Test.ViewController.CaptureEventArgs e)
        {
            if (e?.Result == null)
                return;

            var format = e.Result.BarcodeFormat;
            var text = e.Result.Text;

            InvokeOnMainThread(() =>
            {
                decodedLabel.Text = $"Scanned!{Environment.NewLine}{Environment.NewLine} Format:{format}{Environment.NewLine}{Environment.NewLine} Contents:{text}";
            });

            SystemSound.Vibrate.PlaySystemSound();

            _capture.Stop();

            DispatchQueue.MainQueue.DispatchAfter(new DispatchTime(DispatchTime.Now, 2 * NSEC_PER_SEC), _capture.Start);
        }

        public class CaptureEventArgs : EventArgs
        {
            public ZXCapture Capture { get; }
            public ZXResult Result { get; set; }

            public CaptureEventArgs(ZXCapture capture, ZXResult result)
            {
                Capture = capture;
                Result = result;
            }
        }

        public class CaptureListener : ZXCaptureDelegate
        {
            public event EventHandler<CaptureEventArgs> CapturedResult;

            public override void CaptureResult(ZXCapture capture, ZXResult result)
            {
                CapturedResult?.Invoke(this, new CaptureEventArgs(capture, result));
            }
        }
    }
}

