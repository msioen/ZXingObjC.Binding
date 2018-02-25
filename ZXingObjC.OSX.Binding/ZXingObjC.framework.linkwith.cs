using ObjCRuntime;

[assembly: LinkWith("ZXingObjC.framework", LinkTarget.x86_64, IsCxx = true, SmartLink = true, ForceLoad = true, Frameworks = "AVFoundation Cocoa CoreMedia QuartzCore", WeakFrameworks = "", LinkerFlags = "")]
