using ObjCRuntime;

[assembly: LinkWith("ZXingObjC.framework", LinkTarget.x86_64, IsCxx = true, SmartLink = true, ForceLoad = true, Frameworks = "AVFoundation CoreGraphics CoreMedia CoreVideo ImageIO Foundation QuartzCore UIKit", WeakFrameworks = "", LinkerFlags = "")]
