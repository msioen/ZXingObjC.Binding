using System;
using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using ZXingObjC;

namespace ZXingObjC.OSX.Binding
{
    // @interface ZXCapture : NSObject <AVCaptureVideoDataOutputSampleBufferDelegate, CAAction, CALayerDelegate>
    [BaseType(typeof(NSObject))]
    interface ZXCapture : IAVCaptureVideoDataOutputSampleBufferDelegate, ICAAction, ICALayerDelegate
    {
        // @property (assign, nonatomic) int camera;
        [Export("camera")]
        int Camera { get; set; }

        // @property (nonatomic, strong) AVCaptureDevice * captureDevice;
        [Export("captureDevice", ArgumentSemantic.Strong)]
        AVCaptureDevice CaptureDevice { get; set; }

        // @property (copy, nonatomic) NSString * captureToFilename;
        [Export("captureToFilename")]
        string CaptureToFilename { get; set; }

        [Wrap("WeakDelegate")]
        ZXCaptureDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ZXCaptureDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) AVCaptureFocusMode focusMode;
        [Export("focusMode", ArgumentSemantic.Assign)]
        AVCaptureFocusMode FocusMode { get; set; }

        // @property (nonatomic, strong) ZXDecodeHints * hints;
        [Export("hints", ArgumentSemantic.Strong)]
        ZXDecodeHints Hints { get; set; }

        // @property (assign, nonatomic) CGImageRef lastScannedImage;
        [Export("lastScannedImage", ArgumentSemantic.Assign)]
        unsafe CGImage LastScannedImage { get; set; }

        // @property (assign, nonatomic) BOOL invert;
        [Export("invert")]
        bool Invert { get; set; }

        // @property (readonly, nonatomic, strong) CALayer * layer;
        [Export("layer", ArgumentSemantic.Strong)]
        CALayer Layer { get; }

        // @property (assign, nonatomic) BOOL mirror;
        [Export("mirror")]
        bool Mirror { get; set; }

        // @property (readonly, nonatomic, strong) AVCaptureVideoDataOutput * output;
        [Export("output", ArgumentSemantic.Strong)]
        AVCaptureVideoDataOutput Output { get; }

        // @property (nonatomic, strong) id<ZXReader> reader;
        [Export("reader", ArgumentSemantic.Strong)]
        IZXReader Reader { get; set; }

        // @property (assign, nonatomic) CGFloat rotation;
        [Export("rotation")]
        nfloat Rotation { get; set; }

        // @property (readonly, assign, nonatomic) BOOL running;
        [Export("running")]
        bool Running { get; }

        // @property (assign, nonatomic) CGRect scanRect;
        [Export("scanRect", ArgumentSemantic.Assign)]
        CGRect ScanRect { get; set; }

        // @property (copy, nonatomic) NSString * sessionPreset;
        [Export("sessionPreset")]
        string SessionPreset { get; set; }

        // @property (assign, nonatomic) BOOL torch;
        [Export("torch")]
        bool Torch { get; set; }

        // @property (assign, nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }

        // -(int)back;
        [Export("back")]
        int Back { get; }

        // -(int)front;
        [Export("front")]
        int Front { get; }

        // -(BOOL)hasBack;
        [Export("hasBack")]
        bool HasBack { get; }

        // -(BOOL)hasFront;
        [Export("hasFront")]
        bool HasFront { get; }

        // -(BOOL)hasTorch;
        [Export("hasTorch")]
        bool HasTorch { get; }

        // -(CALayer *)binary;
        [Export("binary")]
        CALayer Binary { get; }

        // -(void)setBinary:(BOOL)on_off;
        [Export("setBinary:")]
        void SetBinary(bool on_off);

        // -(CALayer *)luminance;
        [Export("luminance")]
        CALayer Luminance { get; }

        // -(void)setLuminance:(BOOL)on_off;
        [Export("setLuminance:")]
        void SetLuminance(bool on_off);

        // -(void)hard_stop;
        [Export("hard_stop")]
        void Hard_stop();

        // -(void)order_skip;
        [Export("order_skip")]
        void Order_skip();

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();
    }

    public interface IZXCaptureDelegate { }

    // @protocol ZXCaptureDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ZXCaptureDelegate
    {
        // @required -(void)captureResult:(ZXCapture *)capture result:(ZXResult *)result;
        [Abstract]
        [Export("captureResult:result:")]
        void CaptureResult(ZXCapture capture, ZXResult result);

        // @optional -(void)captureSize:(ZXCapture *)capture width:(NSNumber *)width height:(NSNumber *)height;
        [Export("captureSize:width:height:")]
        void CaptureSize(ZXCapture capture, NSNumber width, NSNumber height);

        // @optional -(void)captureCameraIsReady:(ZXCapture *)capture;
        [Export("captureCameraIsReady:")]
        void CaptureCameraIsReady(ZXCapture capture);
    }

    // @interface ZXLuminanceSource : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXLuminanceSource
    {
        // @property (readonly, assign, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // @property (readonly, assign, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        // @property (readonly, assign, nonatomic) BOOL cropSupported;
        [Export("cropSupported")]
        bool CropSupported { get; }

        // @property (readonly, assign, nonatomic) BOOL rotateSupported;
        [Export("rotateSupported")]
        bool RotateSupported { get; }

        // -(id)initWithWidth:(int)width height:(int)height;
        [Export("initWithWidth:height:")]
        IntPtr Constructor(int width, int height);

        // -(ZXByteArray *)rowAtY:(int)y row:(ZXByteArray *)row;
        [Export("rowAtY:row:")]
        ZXByteArray RowAtY(int y, ZXByteArray row);

        // -(ZXByteArray *)matrix;
        [Export("matrix")]
        ZXByteArray Matrix { get; }

        // -(ZXLuminanceSource *)crop:(int)left top:(int)top width:(int)width height:(int)height;
        [Export("crop:top:width:height:")]
        ZXLuminanceSource Crop(int left, int top, int width, int height);

        // -(ZXLuminanceSource *)invert;
        [Export("invert")]
        ZXLuminanceSource Invert { get; }

        // -(ZXLuminanceSource *)rotateCounterClockwise;
        [Export("rotateCounterClockwise")]
        ZXLuminanceSource RotateCounterClockwise { get; }

        // -(ZXLuminanceSource *)rotateCounterClockwise45;
        [Export("rotateCounterClockwise45")]
        ZXLuminanceSource RotateCounterClockwise45 { get; }
    }

    // @interface ZXCGImageLuminanceSource : ZXLuminanceSource
    [BaseType(typeof(ZXLuminanceSource))]
    interface ZXCGImageLuminanceSource
    {
        // +(CGImageRef)createImageFromBuffer:(CVImageBufferRef)buffer __attribute__((cf_returns_retained));
        [Static]
        [Export("createImageFromBuffer:")]
        unsafe CGImage CreateImageFromBuffer(CVImageBuffer buffer);

        // +(CGImageRef)createImageFromBuffer:(CVImageBufferRef)buffer left:(size_t)left top:(size_t)top width:(size_t)width height:(size_t)height __attribute__((cf_returns_retained));
        [Static]
        [Export("createImageFromBuffer:left:top:width:height:")]
        unsafe CGImage CreateImageFromBuffer(CVImageBuffer buffer, nuint left, nuint top, nuint width, nuint height);

        // -(id)initWithZXImage:(ZXImage *)image left:(size_t)left top:(size_t)top width:(size_t)width height:(size_t)height;
        [Export("initWithZXImage:left:top:width:height:")]
        IntPtr Constructor(ZXImage image, nuint left, nuint top, nuint width, nuint height);

        // -(id)initWithZXImage:(ZXImage *)image;
        [Export("initWithZXImage:")]
        IntPtr Constructor(ZXImage image);

        // -(id)initWithCGImage:(CGImageRef)image left:(size_t)left top:(size_t)top width:(size_t)width height:(size_t)height;
        [Export("initWithCGImage:left:top:width:height:")]
        unsafe IntPtr Constructor(CGImage image, nuint left, nuint top, nuint width, nuint height);

        // -(id)initWithCGImage:(CGImageRef)image;
        [Export("initWithCGImage:")]
        unsafe IntPtr Constructor(CGImage image);

        // -(id)initWithBuffer:(CVPixelBufferRef)buffer left:(size_t)left top:(size_t)top width:(size_t)width height:(size_t)height;
        [Export("initWithBuffer:left:top:width:height:")]
        unsafe IntPtr Constructor(CVPixelBuffer buffer, nuint left, nuint top, nuint width, nuint height);

        // -(id)initWithBuffer:(CVPixelBufferRef)buffer;
        [Export("initWithBuffer:")]
        unsafe IntPtr Constructor(CVPixelBuffer buffer);

        // -(CGImageRef)image;
        [Export("image")]
        unsafe CGImage Image { get; }
    }

    // @interface ZXImage : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXImage
    {
        // @property (readonly, assign, nonatomic) CGImageRef cgimage;
        [Export("cgimage", ArgumentSemantic.Assign)]
        unsafe CGImage Cgimage { get; }

        // -(ZXImage *)initWithCGImageRef:(CGImageRef)image;
        [Export("initWithCGImageRef:")]
        unsafe IntPtr Constructor(CGImage image);

        // -(ZXImage *)initWithURL:(const NSURL *)url;
        [Export("initWithURL:")]
        IntPtr Constructor(NSUrl url);

        // -(size_t)width;
        [Export("width")]
        nuint Width { get; }

        // -(size_t)height;
        [Export("height")]
        nuint Height { get; }

        // +(ZXImage *)imageWithMatrix:(ZXBitMatrix *)matrix;
        [Static]
        [Export("imageWithMatrix:")]
        ZXImage ImageWithMatrix(ZXBitMatrix matrix);

        // +(ZXImage *)imageWithMatrix:(ZXBitMatrix *)matrix onColor:(CGColorRef)onColor offColor:(CGColorRef)offColor;
        [Static]
        [Export("imageWithMatrix:onColor:offColor:")]
        unsafe ZXImage ImageWithMatrix(ZXBitMatrix matrix, CGColor onColor, CGColor offColor);
    }

    // @interface ZXBitArray : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface ZXBitArray : INSCopying
    {
        //// @property (readonly, assign, nonatomic) int32_t * bits;
        //[Export("bits", ArgumentSemantic.Assign)]
        //unsafe int* Bits { get; }

        // @property (readonly, assign, nonatomic) int size;
        [Export("size")]
        int Size { get; }

        // -(id)initWithSize:(int)size;
        [Export("initWithSize:")]
        IntPtr Constructor(int size);

        // -(int)sizeInBytes;
        [Export("sizeInBytes")]
        int SizeInBytes { get; }

        // -(BOOL)get:(int)i;
        [Export("get:")]
        bool Get(int i);

        // -(void)set:(int)i;
        [Export("set:")]
        void Set(int i);

        // -(void)flip:(int)i;
        [Export("flip:")]
        void Flip(int i);

        // -(int)nextSet:(int)from;
        [Export("nextSet:")]
        int NextSet(int from);

        // -(int)nextUnset:(int)from;
        [Export("nextUnset:")]
        int NextUnset(int from);

        // -(void)setBulk:(int)i newBits:(int32_t)newBits;
        [Export("setBulk:newBits:")]
        void SetBulk(int i, int newBits);

        // -(void)setRange:(int)start end:(int)end;
        [Export("setRange:end:")]
        void SetRange(int start, int end);

        // -(void)clear;
        [Export("clear")]
        void Clear();

        // -(BOOL)isRange:(int)start end:(int)end value:(BOOL)value;
        [Export("isRange:end:value:")]
        bool IsRange(int start, int end, bool value);

        // -(void)appendBit:(BOOL)bit;
        [Export("appendBit:")]
        void AppendBit(bool bit);

        // -(void)appendBits:(int32_t)value numBits:(int)numBits;
        [Export("appendBits:numBits:")]
        void AppendBits(int value, int numBits);

        // -(void)appendBitArray:(ZXBitArray *)other;
        [Export("appendBitArray:")]
        void AppendBitArray(ZXBitArray other);

        // -(void)xor:(ZXBitArray *)other;
        [Export("xor:")]
        void Xor(ZXBitArray other);

        // -(void)toBytes:(int)bitOffset array:(ZXByteArray *)array offset:(int)offset numBytes:(int)numBytes;
        [Export("toBytes:array:offset:numBytes:")]
        void ToBytes(int bitOffset, ZXByteArray array, int offset, int numBytes);

        // -(ZXIntArray *)bitArray;
        [Export("bitArray")]
        ZXIntArray BitArray { get; }

        // -(void)reverse;
        [Export("reverse")]
        void Reverse();
    }

    // @interface ZXBitMatrix : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface ZXBitMatrix : INSCopying
    {
        // @property (readonly, assign, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // @property (readonly, assign, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        //// @property (readonly, assign, nonatomic) int32_t * bits;
        //[Export("bits", ArgumentSemantic.Assign)]
        //unsafe int* Bits { get; }

        // @property (readonly, assign, nonatomic) int rowSize;
        [Export("rowSize")]
        int RowSize { get; }

        // -(id)initWithDimension:(int)dimension;
        [Export("initWithDimension:")]
        IntPtr Constructor(int dimension);

        // -(id)initWithWidth:(int)width height:(int)height;
        [Export("initWithWidth:height:")]
        IntPtr Constructor(int width, int height);

        // +(ZXBitMatrix *)parse:(NSString *)stringRepresentation setString:(NSString *)setString unsetString:(NSString *)unsetString;
        [Static]
        [Export("parse:setString:unsetString:")]
        ZXBitMatrix Parse(string stringRepresentation, string setString, string unsetString);

        // -(BOOL)getX:(int)x y:(int)y;
        [Export("getX:y:")]
        bool GetX(int x, int y);

        // -(void)setX:(int)x y:(int)y;
        [Export("setX:y:")]
        void SetX(int x, int y);

        // -(void)unsetX:(int)x y:(int)y;
        [Export("unsetX:y:")]
        void UnsetX(int x, int y);

        // -(void)flipX:(int)x y:(int)y;
        [Export("flipX:y:")]
        void FlipX(int x, int y);

        // -(void)xor:(ZXBitMatrix *)mask;
        [Export("xor:")]
        void Xor(ZXBitMatrix mask);

        // -(void)clear;
        [Export("clear")]
        void Clear();

        // -(void)setRegionAtLeft:(int)left top:(int)top width:(int)width height:(int)height;
        [Export("setRegionAtLeft:top:width:height:")]
        void SetRegionAtLeft(int left, int top, int width, int height);

        // -(ZXBitArray *)rowAtY:(int)y row:(ZXBitArray *)row;
        [Export("rowAtY:row:")]
        ZXBitArray RowAtY(int y, ZXBitArray row);

        // -(void)setRowAtY:(int)y row:(ZXBitArray *)row;
        [Export("setRowAtY:row:")]
        void SetRowAtY(int y, ZXBitArray row);

        // -(void)rotate180;
        [Export("rotate180")]
        void Rotate180();

        // -(ZXIntArray *)enclosingRectangle;
        [Export("enclosingRectangle")]
        ZXIntArray EnclosingRectangle { get; }

        // -(ZXIntArray *)topLeftOnBit;
        [Export("topLeftOnBit")]
        ZXIntArray TopLeftOnBit { get; }

        // -(ZXIntArray *)bottomRightOnBit;
        [Export("bottomRightOnBit")]
        ZXIntArray BottomRightOnBit { get; }

        // -(NSString *)descriptionWithSetString:(NSString *)setString unsetString:(NSString *)unsetString;
        [Export("descriptionWithSetString:unsetString:")]
        string DescriptionWithSetString(string setString, string unsetString);

        // -(NSString *)descriptionWithSetString:(NSString *)setString unsetString:(NSString *)unsetString lineSeparator:(NSString *)lineSeparator __attribute__((deprecated("")));
        [Export("descriptionWithSetString:unsetString:lineSeparator:")]
        string DescriptionWithSetString(string setString, string unsetString, string lineSeparator);
    }

    // @interface ZXBitSource : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXBitSource
    {
        // @property (readonly, assign, nonatomic) int bitOffset;
        [Export("bitOffset")]
        int BitOffset { get; }

        // @property (readonly, assign, nonatomic) int byteOffset;
        [Export("byteOffset")]
        int ByteOffset { get; }

        // -(id)initWithBytes:(ZXByteArray *)bytes;
        [Export("initWithBytes:")]
        IntPtr Constructor(ZXByteArray bytes);

        // -(int)readBits:(int)numBits;
        [Export("readBits:")]
        int ReadBits(int numBits);

        // -(int)available;
        [Export("available")]
        int Available { get; }
    }

    // @interface ZXBoolArray : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXBoolArray
    {
        //// @property (readonly, assign, nonatomic) BOOL * array;
        //[Export("array", ArgumentSemantic.Assign)]
        //unsafe bool* Array { get; }

        // @property (readonly, assign, nonatomic) unsigned int length;
        [Export("length")]
        uint Length { get; }

        // -(id)initWithLength:(unsigned int)length;
        [Export("initWithLength:")]
        IntPtr Constructor(uint length);
    }

    // @interface ZXByteArray : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXByteArray
    {
        //// @property (readonly, assign, nonatomic) int8_t * array;
        //[Export("array", ArgumentSemantic.Assign)]
        //unsafe sbyte* Array { get; }

        // @property (readonly, assign, nonatomic) unsigned int length;
        [Export("length")]
        uint Length { get; }

        // -(id)initWithLength:(unsigned int)length;
        [Export("initWithLength:")]
        IntPtr Constructor(uint length);

        // -(id)initWithBytes:(int)byte1, ...;
        [Internal]
        [Export("initWithBytes:", IsVariadic = true)]
        IntPtr Constructor(int byte1, IntPtr varArgs);
    }

    // @interface ZXCharacterSetECI : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXCharacterSetECI
    {
        // @property (readonly, assign, nonatomic) NSStringEncoding encoding;
        [Export("encoding")]
        nuint Encoding { get; }

        // @property (readonly, assign, nonatomic) int value;
        [Export("value")]
        int Value { get; }

        // +(ZXCharacterSetECI *)characterSetECIByValue:(int)value;
        [Static]
        [Export("characterSetECIByValue:")]
        ZXCharacterSetECI CharacterSetECIByValue(int value);

        // +(ZXCharacterSetECI *)characterSetECIByEncoding:(NSStringEncoding)encoding;
        [Static]
        [Export("characterSetECIByEncoding:")]
        ZXCharacterSetECI CharacterSetECIByEncoding(nuint encoding);
    }

    // @interface ZXDecoderResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXDecoderResult
    {
        // @property (readonly, nonatomic, strong) ZXByteArray * rawBytes;
        [Export("rawBytes", ArgumentSemantic.Strong)]
        ZXByteArray RawBytes { get; }

        // @property (readonly, copy, nonatomic) NSString * text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, nonatomic, strong) NSMutableArray * byteSegments;
        [Export("byteSegments", ArgumentSemantic.Strong)]
        NSMutableArray ByteSegments { get; }

        // @property (readonly, copy, nonatomic) NSString * ecLevel;
        [Export("ecLevel")]
        string EcLevel { get; }

        // @property (copy, nonatomic) NSNumber * errorsCorrected;
        [Export("errorsCorrected", ArgumentSemantic.Copy)]
        NSNumber ErrorsCorrected { get; set; }

        // @property (copy, nonatomic) NSNumber * erasures;
        [Export("erasures", ArgumentSemantic.Copy)]
        NSNumber Erasures { get; set; }

        // @property (nonatomic, strong) id other;
        [Export("other", ArgumentSemantic.Strong)]
        NSObject Other { get; set; }

        // @property (readonly, assign, nonatomic) int structuredAppendParity;
        [Export("structuredAppendParity")]
        int StructuredAppendParity { get; }

        // @property (readonly, assign, nonatomic) int structuredAppendSequenceNumber;
        [Export("structuredAppendSequenceNumber")]
        int StructuredAppendSequenceNumber { get; }

        // -(id)initWithRawBytes:(ZXByteArray *)rawBytes text:(NSString *)text byteSegments:(NSMutableArray *)byteSegments ecLevel:(NSString *)ecLevel;
        [Export("initWithRawBytes:text:byteSegments:ecLevel:")]
        IntPtr Constructor(ZXByteArray rawBytes, string text, NSMutableArray byteSegments, string ecLevel);

        // -(id)initWithRawBytes:(ZXByteArray *)rawBytes text:(NSString *)text byteSegments:(NSMutableArray *)byteSegments ecLevel:(NSString *)ecLevel saSequence:(int)saSequence saParity:(int)saParity;
        [Export("initWithRawBytes:text:byteSegments:ecLevel:saSequence:saParity:")]
        IntPtr Constructor(ZXByteArray rawBytes, string text, NSMutableArray byteSegments, string ecLevel, int saSequence, int saParity);

        // -(BOOL)hasStructuredAppend;
        [Export("hasStructuredAppend")]
        bool HasStructuredAppend { get; }
    }

    // @interface ZXGridSampler : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXGridSampler
    {
        // +(void)setGridSampler:(ZXGridSampler *)newGridSampler;
        [Static]
        [Export("setGridSampler:")]
        void SetGridSampler(ZXGridSampler newGridSampler);

        // +(ZXGridSampler *)instance;
        [Static]
        [Export("instance")]
        ZXGridSampler Instance { get; }

        // -(ZXBitMatrix *)sampleGrid:(ZXBitMatrix *)image dimensionX:(int)dimensionX dimensionY:(int)dimensionY p1ToX:(float)p1ToX p1ToY:(float)p1ToY p2ToX:(float)p2ToX p2ToY:(float)p2ToY p3ToX:(float)p3ToX p3ToY:(float)p3ToY p4ToX:(float)p4ToX p4ToY:(float)p4ToY p1FromX:(float)p1FromX p1FromY:(float)p1FromY p2FromX:(float)p2FromX p2FromY:(float)p2FromY p3FromX:(float)p3FromX p3FromY:(float)p3FromY p4FromX:(float)p4FromX p4FromY:(float)p4FromY error:(NSError **)error;
        [Export("sampleGrid:dimensionX:dimensionY:p1ToX:p1ToY:p2ToX:p2ToY:p3ToX:p3ToY:p4ToX:p4ToY:p1FromX:p1FromY:p2FromX:p2FromY:p3FromX:p3FromY:p4FromX:p4FromY:error:")]
        ZXBitMatrix SampleGrid(ZXBitMatrix image, int dimensionX, int dimensionY, float p1ToX, float p1ToY, float p2ToX, float p2ToY, float p3ToX, float p3ToY, float p4ToX, float p4ToY, float p1FromX, float p1FromY, float p2FromX, float p2FromY, float p3FromX, float p3FromY, float p4FromX, float p4FromY, out NSError error);

        // -(ZXBitMatrix *)sampleGrid:(ZXBitMatrix *)image dimensionX:(int)dimensionX dimensionY:(int)dimensionY transform:(ZXPerspectiveTransform *)transform error:(NSError **)error;
        [Export("sampleGrid:dimensionX:dimensionY:transform:error:")]
        ZXBitMatrix SampleGrid(ZXBitMatrix image, int dimensionX, int dimensionY, ZXPerspectiveTransform transform, out NSError error);

        //// +(BOOL)checkAndNudgePoints:(ZXBitMatrix *)image points:(float *)points pointsLen:(int)pointsLen error:(NSError **)error;
        //[Static]
        //[Export("checkAndNudgePoints:points:pointsLen:error:")]
        //unsafe bool CheckAndNudgePoints(ZXBitMatrix image, float* points, int pointsLen, out NSError error);
    }

    // @interface ZXDefaultGridSampler : ZXGridSampler
    [BaseType(typeof(ZXGridSampler))]
    interface ZXDefaultGridSampler
    {
    }

    // @interface ZXDetectorResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXDetectorResult
    {
        // @property (readonly, nonatomic, strong) ZXBitMatrix * bits;
        [Export("bits", ArgumentSemantic.Strong)]
        ZXBitMatrix Bits { get; }

        // @property (readonly, nonatomic, strong) NSArray * points;
        [Export("points", ArgumentSemantic.Strong)]
        NSObject[] Points { get; }

        // -(id)initWithBits:(ZXBitMatrix *)bits points:(NSArray *)points;
        [Export("initWithBits:points:")]
        IntPtr Constructor(ZXBitMatrix bits, NSObject[] points);
    }

    // @interface ZXGenericGFPoly : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXGenericGFPoly
    {
        // - (id)initWithField:(ZXGenericGF *)field coefficients:(ZXIntArray *)coefficients;
        [Export("initWithField:coefficients:")]
        IntPtr Constructor(ZXGenericGF field, ZXIntArray coefficients);

        [Export("degree")]
        int Degree { get; }

        [Export("zero")]
        bool Zero { get; }

        [Export("coefficient:")]
        int Coefficient(int degree);

        [Export("evaluateAt:")]
        int EvaluateAt(int a);
    }

    // @interface ZXGenericGF : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXGenericGF
    {
        // @property (readonly, nonatomic, strong) ZXGenericGFPoly * zero;
        [Export("zero", ArgumentSemantic.Strong)]
        ZXGenericGFPoly Zero { get; }

        // @property (readonly, nonatomic, strong) ZXGenericGFPoly * one;
        [Export("one", ArgumentSemantic.Strong)]
        ZXGenericGFPoly One { get; }

        // @property (readonly, assign, nonatomic) int32_t size;
        [Export("size")]
        int Size { get; }

        // @property (readonly, assign, nonatomic) int32_t generatorBase;
        [Export("generatorBase")]
        int GeneratorBase { get; }

        // +(ZXGenericGF *)AztecData12;
        [Static]
        [Export("AztecData12")]
        ZXGenericGF AztecData12 { get; }

        // +(ZXGenericGF *)AztecData10;
        [Static]
        [Export("AztecData10")]
        ZXGenericGF AztecData10 { get; }

        // +(ZXGenericGF *)AztecData6;
        [Static]
        [Export("AztecData6")]
        ZXGenericGF AztecData6 { get; }

        // +(ZXGenericGF *)AztecParam;
        [Static]
        [Export("AztecParam")]
        ZXGenericGF AztecParam { get; }

        // +(ZXGenericGF *)QrCodeField256;
        [Static]
        [Export("QrCodeField256")]
        ZXGenericGF QrCodeField256 { get; }

        // +(ZXGenericGF *)DataMatrixField256;
        [Static]
        [Export("DataMatrixField256")]
        ZXGenericGF DataMatrixField256 { get; }

        // +(ZXGenericGF *)AztecData8;
        [Static]
        [Export("AztecData8")]
        ZXGenericGF AztecData8 { get; }

        // +(ZXGenericGF *)MaxiCodeField64;
        [Static]
        [Export("MaxiCodeField64")]
        ZXGenericGF MaxiCodeField64 { get; }

        // -(id)initWithPrimitive:(int)primitive size:(int)size b:(int)b;
        [Export("initWithPrimitive:size:b:")]
        IntPtr Constructor(int primitive, int size, int b);

        // -(ZXGenericGFPoly *)buildMonomial:(int)degree coefficient:(int)coefficient;
        [Export("buildMonomial:coefficient:")]
        ZXGenericGFPoly BuildMonomial(int degree, int coefficient);

        // +(int32_t)addOrSubtract:(int32_t)a b:(int32_t)b;
        [Static]
        [Export("addOrSubtract:b:")]
        int AddOrSubtract(int a, int b);

        // -(int32_t)exp:(int)a;
        [Export("exp:")]
        int Exp(int a);

        // -(int32_t)log:(int)a;
        [Export("log:")]
        int Log(int a);

        // -(int32_t)inverse:(int)a;
        [Export("inverse:")]
        int Inverse(int a);

        // -(int32_t)multiply:(int)a b:(int)b;
        [Export("multiply:b:")]
        int Multiply(int a, int b);
    }

    // @interface ZXBinarizer : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXBinarizer
    {
        // @property (readonly, nonatomic, strong) ZXLuminanceSource * luminanceSource;
        [Export("luminanceSource", ArgumentSemantic.Strong)]
        ZXLuminanceSource LuminanceSource { get; }

        // @property (readonly, assign, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // @property (readonly, assign, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        // -(id)initWithSource:(ZXLuminanceSource *)source;
        [Export("initWithSource:")]
        IntPtr Constructor(ZXLuminanceSource source);

        // +(id)binarizerWithSource:(ZXLuminanceSource *)source;
        [Static]
        [Export("binarizerWithSource:")]
        ZXBinarizer BinarizerWithSource(ZXLuminanceSource source);

        // -(ZXBitArray *)blackRow:(int)y row:(ZXBitArray *)row error:(NSError **)error;
        [Export("blackRow:row:error:")]
        ZXBitArray BlackRow(int y, ZXBitArray row, out NSError error);

        // -(ZXBitMatrix *)blackMatrixWithError:(NSError **)error;
        [Export("blackMatrixWithError:")]
        ZXBitMatrix BlackMatrixWithError(out NSError error);

        // -(ZXBinarizer *)createBinarizer:(ZXLuminanceSource *)source;
        [Export("createBinarizer:")]
        ZXBinarizer CreateBinarizer(ZXLuminanceSource source);

        // -(CGImageRef)createImage __attribute__((cf_returns_retained));
        [Export("createImage")]
        unsafe CGImage CreateImage { get; }
    }

    // @interface ZXGlobalHistogramBinarizer : ZXBinarizer
    [BaseType(typeof(ZXBinarizer))]
    interface ZXGlobalHistogramBinarizer
    {
        [Static]
        [Export("binarizerWithSource:")]
        ZXGlobalHistogramBinarizer BinarizerWithSource(ZXLuminanceSource source);

        // -(ZXBitArray *)blackRow:(int)y row:(ZXBitArray *)row error:(NSError **)error;
        [Export("blackRow:row:error:")]
        ZXBitArray BlackRow(int y, ZXBitArray row, out NSError error);

        // -(ZXBinarizer *)createBinarizer:(ZXLuminanceSource *)source;
        [Export("createBinarizer:")]
        ZXGlobalHistogramBinarizer CreateBinarizer(ZXLuminanceSource source);
    }

    // @interface ZXHybridBinarizer : ZXGlobalHistogramBinarizer
    [BaseType(typeof(ZXGlobalHistogramBinarizer))]
    interface ZXHybridBinarizer
    {
        [Static]
        [Export("binarizerWithSource:")]
        ZXHybridBinarizer BinarizerWithSource(ZXLuminanceSource source);

        [Export("createBinarizer:")]
        ZXHybridBinarizer CreateBinarizer(ZXLuminanceSource source);
    }

    // @interface ZXIntArray : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface ZXIntArray : INSCopying
    {
        //// @property (readonly, assign, nonatomic) int32_t * array;
        //[Export("array", ArgumentSemantic.Assign)]
        //unsafe int* Array { get; }

        // @property (readonly, assign, nonatomic) unsigned int length;
        [Export("length")]
        uint Length { get; }

        // -(id)initWithLength:(unsigned int)length;
        [Export("initWithLength:")]
        IntPtr Constructor(uint length);

        // -(id)initWithInts:(int32_t)int1, ...;
        [Internal]
        [Export("initWithInts:", IsVariadic = true)]
        IntPtr Constructor(int int1, IntPtr varArgs);

        // -(void)clear;
        [Export("clear")]
        void Clear();

        // -(int)sum;
        [Export("sum")]
        int Sum { get; }
    }

    // @interface ZXMathUtils : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXMathUtils
    {
        // +(int)round:(float)d;
        [Static]
        [Export("round:")]
        int Round(float d);

        // +(float)distance:(float)aX aY:(float)aY bX:(float)bX bY:(float)bY;
        [Static]
        [Export("distance:aY:bX:bY:")]
        float Distance(float aX, float aY, float bX, float bY);

        // +(float)distanceInt:(int)aX aY:(int)aY bX:(int)bX bY:(int)bY;
        [Static]
        [Export("distanceInt:aY:bX:bY:")]
        float DistanceInt(int aX, int aY, int bX, int bY);
    }

    // @interface ZXMonochromeRectangleDetector : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXMonochromeRectangleDetector
    {
        // -(id)initWithImage:(ZXBitMatrix *)image;
        [Export("initWithImage:")]
        IntPtr Constructor(ZXBitMatrix image);

        // -(NSArray *)detectWithError:(NSError **)error;
        [Export("detectWithError:")]
        NSObject[] DetectWithError(out NSError error);
    }

    // @interface ZXPerspectiveTransform : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXPerspectiveTransform
    {
        // +(ZXPerspectiveTransform *)quadrilateralToQuadrilateral:(float)x0 y0:(float)y0 x1:(float)x1 y1:(float)y1 x2:(float)x2 y2:(float)y2 x3:(float)x3 y3:(float)y3 x0p:(float)x0p y0p:(float)y0p x1p:(float)x1p y1p:(float)y1p x2p:(float)x2p y2p:(float)y2p x3p:(float)x3p y3p:(float)y3p;
        [Static]
        [Export("quadrilateralToQuadrilateral:y0:x1:y1:x2:y2:x3:y3:x0p:y0p:x1p:y1p:x2p:y2p:x3p:y3p:")]
        ZXPerspectiveTransform QuadrilateralToQuadrilateral(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3, float x0p, float y0p, float x1p, float y1p, float x2p, float y2p, float x3p, float y3p);

        //// -(void)transformPoints:(float *)points pointsLen:(int)pointsLen;
        //[Export("transformPoints:pointsLen:")]
        //unsafe void TransformPoints(float* points, int pointsLen);

        //// -(void)transformPoints:(float *)xValues yValues:(float *)yValues pointsLen:(int)pointsLen;
        //[Export("transformPoints:yValues:pointsLen:")]
        //unsafe void TransformPoints(float* xValues, float* yValues, int pointsLen);

        // +(ZXPerspectiveTransform *)squareToQuadrilateral:(float)x0 y0:(float)y0 x1:(float)x1 y1:(float)y1 x2:(float)x2 y2:(float)y2 x3:(float)x3 y3:(float)y3;
        [Static]
        [Export("squareToQuadrilateral:y0:x1:y1:x2:y2:x3:y3:")]
        ZXPerspectiveTransform SquareToQuadrilateral(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3);

        // +(ZXPerspectiveTransform *)quadrilateralToSquare:(float)x0 y0:(float)y0 x1:(float)x1 y1:(float)y1 x2:(float)x2 y2:(float)y2 x3:(float)x3 y3:(float)y3;
        [Static]
        [Export("quadrilateralToSquare:y0:x1:y1:x2:y2:x3:y3:")]
        ZXPerspectiveTransform QuadrilateralToSquare(float x0, float y0, float x1, float y1, float x2, float y2, float x3, float y3);

        // -(ZXPerspectiveTransform *)buildAdjoint;
        [Export("buildAdjoint")]
        ZXPerspectiveTransform BuildAdjoint { get; }

        // -(ZXPerspectiveTransform *)times:(ZXPerspectiveTransform *)other;
        [Export("times:")]
        ZXPerspectiveTransform Times(ZXPerspectiveTransform other);
    }

    // @interface ZXReedSolomonDecoder : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXReedSolomonDecoder
    {
        // -(id)initWithField:(ZXGenericGF *)field;
        [Export("initWithField:")]
        IntPtr Constructor(ZXGenericGF field);

        // -(BOOL)decode:(ZXIntArray *)received twoS:(int)twoS error:(NSError **)error;
        [Export("decode:twoS:error:")]
        bool Decode(ZXIntArray received, int twoS, out NSError error);
    }

    // @interface ZXReedSolomonEncoder : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXReedSolomonEncoder
    {
        // -(id)initWithField:(ZXGenericGF *)field;
        [Export("initWithField:")]
        IntPtr Constructor(ZXGenericGF field);

        // -(void)encode:(ZXIntArray *)toEncode ecBytes:(int)ecBytes;
        [Export("encode:ecBytes:")]
        void Encode(ZXIntArray toEncode, int ecBytes);
    }

    // @interface ZXStringUtils : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXStringUtils
    {
        // +(NSStringEncoding)guessEncoding:(ZXByteArray *)bytes hints:(ZXDecodeHints *)hints;
        [Static]
        [Export("guessEncoding:hints:")]
        nuint GuessEncoding(ZXByteArray bytes, ZXDecodeHints hints);
    }

    // @interface ZXResultPoint : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface ZXResultPoint : INSCopying
    {
        // @property (readonly, assign, nonatomic) float x;
        [Export("x")]
        float X { get; }

        // @property (readonly, assign, nonatomic) float y;
        [Export("y")]
        float Y { get; }

        // -(id)initWithX:(float)x y:(float)y;
        [Export("initWithX:y:")]
        IntPtr Constructor(float x, float y);

        // +(id)resultPointWithX:(float)x y:(float)y;
        [Static]
        [Export("resultPointWithX:y:")]
        NSObject ResultPointWithX(float x, float y);

        // +(void)orderBestPatterns:(NSMutableArray *)patterns;
        [Static]
        [Export("orderBestPatterns:")]
        void OrderBestPatterns(NSMutableArray patterns);

        // +(float)distance:(ZXResultPoint *)pattern1 pattern2:(ZXResultPoint *)pattern2;
        [Static]
        [Export("distance:pattern2:")]
        float Distance(ZXResultPoint pattern1, ZXResultPoint pattern2);
    }

    // @interface ZXWhiteRectangleDetector : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXWhiteRectangleDetector
    {
        // -(id)initWithImage:(ZXBitMatrix *)image error:(NSError **)error;
        [Export("initWithImage:error:")]
        IntPtr Constructor(ZXBitMatrix image, out NSError error);

        // -(id)initWithImage:(ZXBitMatrix *)image initSize:(int)initSize x:(int)x y:(int)y error:(NSError **)error;
        [Export("initWithImage:initSize:x:y:error:")]
        IntPtr Constructor(ZXBitMatrix image, int initSize, int x, int y, out NSError error);

        // -(NSArray *)detectWithError:(NSError **)error;
        [Export("detectWithError:")]
        NSObject[] DetectWithError(out NSError error);
    }

    // @interface ZXBinaryBitmap : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXBinaryBitmap
    {
        // @property (readonly, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // @property (readonly, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        // @property (readonly, nonatomic) BOOL cropSupported;
        [Export("cropSupported")]
        bool CropSupported { get; }

        // @property (readonly, nonatomic) BOOL rotateSupported;
        [Export("rotateSupported")]
        bool RotateSupported { get; }

        // -(id)initWithBinarizer:(ZXBinarizer *)binarizer;
        [Export("initWithBinarizer:")]
        IntPtr Constructor(ZXBinarizer binarizer);

        // +(id)binaryBitmapWithBinarizer:(ZXBinarizer *)binarizer;
        [Static]
        [Export("binaryBitmapWithBinarizer:")]
        ZXBinaryBitmap BinaryBitmapWithBinarizer(ZXBinarizer binarizer);

        // -(ZXBitArray *)blackRow:(int)y row:(ZXBitArray *)row error:(NSError **)error;
        [Export("blackRow:row:error:")]
        ZXBitArray BlackRow(int y, ZXBitArray row, out NSError error);

        // -(ZXBitMatrix *)blackMatrixWithError:(NSError **)error;
        [Export("blackMatrixWithError:")]
        ZXBitMatrix BlackMatrixWithError(out NSError error);

        // -(ZXBinaryBitmap *)crop:(int)left top:(int)top width:(int)width height:(int)height;
        [Export("crop:top:width:height:")]
        ZXBinaryBitmap Crop(int left, int top, int width, int height);

        // -(ZXBinaryBitmap *)rotateCounterClockwise;
        [Export("rotateCounterClockwise")]
        ZXBinaryBitmap RotateCounterClockwise { get; }

        // -(ZXBinaryBitmap *)rotateCounterClockwise45;
        [Export("rotateCounterClockwise45")]
        ZXBinaryBitmap RotateCounterClockwise45 { get; }
    }

    // @interface ZXByteMatrix : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXByteMatrix
    {
        //// @property (readonly, assign, nonatomic) int8_t ** array;
        //[Export("array", ArgumentSemantic.Assign)]
        //unsafe sbyte** Array { get; }

        // @property (readonly, assign, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        // @property (readonly, assign, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // -(id)initWithWidth:(int)width height:(int)height;
        [Export("initWithWidth:height:")]
        IntPtr Constructor(int width, int height);

        // -(int8_t)getX:(int)x y:(int)y;
        [Export("getX:y:")]
        sbyte GetX(int x, int y);

        // -(void)setX:(int)x y:(int)y byteValue:(int8_t)value;
        [Export("setX:y:byteValue:")]
        void SetX(int x, int y, sbyte value);

        // -(void)setX:(int)x y:(int)y intValue:(int32_t)value;
        [Export("setX:y:intValue:")]
        void SetX(int x, int y, int value);

        // -(void)setX:(int)x y:(int)y boolValue:(BOOL)value;
        [Export("setX:y:boolValue:")]
        void SetX(int x, int y, bool value);

        // -(void)clear:(int8_t)value;
        [Export("clear:")]
        void Clear(sbyte value);
    }

    // @interface ZXDecodeHints : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface ZXDecodeHints : INSCopying
    {
        // +(id)hints;
        [Static]
        [Export("hints")]
        NSObject Hints { get; }

        // @property (assign, nonatomic) BOOL assumeCode39CheckDigit;
        [Export("assumeCode39CheckDigit")]
        bool AssumeCode39CheckDigit { get; set; }

        // @property (assign, nonatomic) BOOL assumeGS1;
        [Export("assumeGS1")]
        bool AssumeGS1 { get; set; }

        // @property (nonatomic, strong) NSArray * allowedLengths;
        [Export("allowedLengths", ArgumentSemantic.Strong)]
        NSObject[] AllowedLengths { get; set; }

        // @property (assign, nonatomic) NSStringEncoding encoding;
        [Export("encoding")]
        nuint Encoding { get; set; }

        // @property (nonatomic, strong) id other;
        [Export("other", ArgumentSemantic.Strong)]
        NSObject Other { get; set; }

        // @property (assign, nonatomic) BOOL pureBarcode;
        [Export("pureBarcode")]
        bool PureBarcode { get; set; }

        // @property (assign, nonatomic) BOOL returnCodaBarStartEnd;
        [Export("returnCodaBarStartEnd")]
        bool ReturnCodaBarStartEnd { get; set; }

        // @property (nonatomic, strong) id<ZXResultPointCallback> resultPointCallback;
        [Export("resultPointCallback", ArgumentSemantic.Strong)]
        ZXResultPointCallback ResultPointCallback { get; set; }

        // @property (assign, nonatomic) BOOL tryHarder;
        [Export("tryHarder")]
        bool TryHarder { get; set; }

        // @property (nonatomic, strong) ZXIntArray * allowedEANExtensions;
        [Export("allowedEANExtensions", ArgumentSemantic.Strong)]
        ZXIntArray AllowedEANExtensions { get; set; }

        // -(void)addPossibleFormat:(ZXBarcodeFormat)format;
        [Export("addPossibleFormat:")]
        void AddPossibleFormat(ZXBarcodeFormat format);

        // -(BOOL)containsFormat:(ZXBarcodeFormat)format;
        [Export("containsFormat:")]
        bool ContainsFormat(ZXBarcodeFormat format);

        // -(int)numberOfPossibleFormats;
        [Export("numberOfPossibleFormats")]
        int NumberOfPossibleFormats { get; }

        // -(void)removePossibleFormat:(ZXBarcodeFormat)format;
        [Export("removePossibleFormat:")]
        void RemovePossibleFormat(ZXBarcodeFormat format);
    }

    // @interface ZXDimension : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXDimension
    {
        // @property (readonly, assign, nonatomic) int height;
        [Export("height")]
        int Height { get; }

        // @property (readonly, assign, nonatomic) int width;
        [Export("width")]
        int Width { get; }

        // -(id)initWithWidth:(int)width height:(int)height;
        [Export("initWithWidth:height:")]
        IntPtr Constructor(int width, int height);
    }

    // @interface ZXEncodeHints : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXEncodeHints
    {
        // +(id)hints;
        [Static]
        [Export("hints")]
        NSObject Hints { get; }

        // @property (assign, nonatomic) NSStringEncoding encoding;
        [Export("encoding")]
        nuint Encoding { get; set; }

        // @property (assign, nonatomic) ZXDataMatrixSymbolShapeHint dataMatrixShape;
        [Export("dataMatrixShape", ArgumentSemantic.Assign)]
        ZXDataMatrixSymbolShapeHint DataMatrixShape { get; set; }

        // @property (nonatomic, strong) ZXDimension * minSize __attribute__((deprecated("")));
        [Export("minSize", ArgumentSemantic.Strong)]
        ZXDimension MinSize { get; set; }

        // @property (nonatomic, strong) ZXDimension * maxSize __attribute__((deprecated("")));
        [Export("maxSize", ArgumentSemantic.Strong)]
        ZXDimension MaxSize { get; set; }

        // @property (nonatomic, strong) ZXQRCodeErrorCorrectionLevel * errorCorrectionLevel;
        [Export("errorCorrectionLevel", ArgumentSemantic.Strong)]
        ZXQRCodeErrorCorrectionLevel ErrorCorrectionLevel { get; set; }

        // @property (nonatomic, strong) NSNumber * errorCorrectionPercent;
        [Export("errorCorrectionPercent", ArgumentSemantic.Strong)]
        NSNumber ErrorCorrectionPercent { get; set; }

        // @property (nonatomic, strong) NSNumber * margin;
        [Export("margin", ArgumentSemantic.Strong)]
        NSNumber Margin { get; set; }

        // @property (assign, nonatomic) BOOL pdf417Compact;
        [Export("pdf417Compact")]
        bool Pdf417Compact { get; set; }

        // @property (assign, nonatomic) ZXPDF417Compaction pdf417Compaction;
        [Export("pdf417Compaction", ArgumentSemantic.Assign)]
        ZXPDF417Compaction Pdf417Compaction { get; set; }

        // @property (nonatomic, strong) ZXPDF417Dimensions * pdf417Dimensions;
        [Export("pdf417Dimensions", ArgumentSemantic.Strong)]
        ZXPDF417Dimensions Pdf417Dimensions { get; set; }

        // @property (nonatomic, strong) NSNumber * aztecLayers;
        [Export("aztecLayers", ArgumentSemantic.Strong)]
        NSNumber AztecLayers { get; set; }
    }

    // @interface ZXInvertedLuminanceSource : ZXLuminanceSource
    [BaseType(typeof(ZXLuminanceSource))]
    interface ZXInvertedLuminanceSource
    {
        // -(id)initWithDelegate:(ZXLuminanceSource *)delegate;
        [Export("initWithDelegate:")]
        IntPtr Constructor(ZXLuminanceSource @delegate);
    }

    // @interface ZXPlanarYUVLuminanceSource : ZXLuminanceSource
    [BaseType(typeof(ZXLuminanceSource))]
    interface ZXPlanarYUVLuminanceSource
    {
        // @property (readonly, assign, nonatomic) int thumbnailWidth;
        [Export("thumbnailWidth")]
        int ThumbnailWidth { get; }

        // @property (readonly, assign, nonatomic) int thumbnailHeight;
        [Export("thumbnailHeight")]
        int ThumbnailHeight { get; }

        //// -(id)initWithYuvData:(int8_t *)yuvData yuvDataLen:(int)yuvDataLen dataWidth:(int)dataWidth dataHeight:(int)dataHeight left:(int)left top:(int)top width:(int)width height:(int)height reverseHorizontal:(BOOL)reverseHorizontal;
        //[Export("initWithYuvData:yuvDataLen:dataWidth:dataHeight:left:top:width:height:reverseHorizontal:")]
        //unsafe IntPtr Constructor(sbyte* yuvData, int yuvDataLen, int dataWidth, int dataHeight, int left, int top, int width, int height, bool reverseHorizontal);

        //// -(int32_t *)renderThumbnail;
        //[Export("renderThumbnail")]
        //unsafe int* RenderThumbnail { get; }
    }

    public interface IZXReader { }

    // @protocol ZXReader <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ZXReader
    {
        // @required -(ZXResult *)decode:(ZXBinaryBitmap *)image error:(NSError **)error;
        [Abstract]
        [Export("decode:error:")]
        ZXResult Decode(ZXBinaryBitmap image, out NSError error);

        // @required -(ZXResult *)decode:(ZXBinaryBitmap *)image hints:(ZXDecodeHints *)hints error:(NSError **)error;
        [Abstract]
        [Export("decode:hints:error:")]
        ZXResult Decode(ZXBinaryBitmap image, ZXDecodeHints hints, out NSError error);

        // @required -(void)reset;
        [Abstract]
        [Export("reset")]
        void Reset();
    }

    // @interface ZXResult : NSObject
    [BaseType(typeof(NSObject))]
    interface ZXResult
    {
        // @property (readonly, copy, nonatomic) NSString * text;
        [Export("text")]
        string Text { get; }

        // @property (readonly, nonatomic, strong) ZXByteArray * rawBytes;
        [Export("rawBytes", ArgumentSemantic.Strong)]
        ZXByteArray RawBytes { get; }

        // @property (readonly, nonatomic, strong) NSMutableArray * resultPoints;
        [Export("resultPoints", ArgumentSemantic.Strong)]
        NSMutableArray ResultPoints { get; }

        // @property (readonly, assign, nonatomic) ZXBarcodeFormat barcodeFormat;
        [Export("barcodeFormat", ArgumentSemantic.Assign)]
        ZXBarcodeFormat BarcodeFormat { get; }

        // @property (readonly, nonatomic, strong) NSMutableDictionary * resultMetadata;
        [Export("resultMetadata", ArgumentSemantic.Strong)]
        NSMutableDictionary ResultMetadata { get; }

        // @property (readonly, assign, nonatomic) long timestamp;
        [Export("timestamp")]
        nint Timestamp { get; }

        // -(id)initWithText:(NSString *)text rawBytes:(ZXByteArray *)rawBytes resultPoints:(NSArray *)resultPoints format:(ZXBarcodeFormat)format;
        [Export("initWithText:rawBytes:resultPoints:format:")]
        IntPtr Constructor(string text, ZXByteArray rawBytes, NSObject[] resultPoints, ZXBarcodeFormat format);

        // -(id)initWithText:(NSString *)text rawBytes:(ZXByteArray *)rawBytes resultPoints:(NSArray *)resultPoints format:(ZXBarcodeFormat)format timestamp:(long)timestamp;
        [Export("initWithText:rawBytes:resultPoints:format:timestamp:")]
        IntPtr Constructor(string text, ZXByteArray rawBytes, NSObject[] resultPoints, ZXBarcodeFormat format, nint timestamp);

        // +(id)resultWithText:(NSString *)text rawBytes:(ZXByteArray *)rawBytes resultPoints:(NSArray *)resultPoints format:(ZXBarcodeFormat)format;
        [Static]
        [Export("resultWithText:rawBytes:resultPoints:format:")]
        NSObject ResultWithText(string text, ZXByteArray rawBytes, NSObject[] resultPoints, ZXBarcodeFormat format);

        // +(id)resultWithText:(NSString *)text rawBytes:(ZXByteArray *)rawBytes resultPoints:(NSArray *)resultPoints format:(ZXBarcodeFormat)format timestamp:(long)timestamp;
        [Static]
        [Export("resultWithText:rawBytes:resultPoints:format:timestamp:")]
        NSObject ResultWithText(string text, ZXByteArray rawBytes, NSObject[] resultPoints, ZXBarcodeFormat format, nint timestamp);

        // -(void)putMetadata:(ZXResultMetadataType)type value:(id)value;
        [Export("putMetadata:value:")]
        void PutMetadata(ZXResultMetadataType type, NSObject value);

        // -(void)putAllMetadata:(NSMutableDictionary *)metadata;
        [Export("putAllMetadata:")]
        void PutAllMetadata(NSMutableDictionary metadata);

        // -(void)addResultPoints:(NSArray *)newPoints;
        [Export("addResultPoints:")]
        void AddResultPoints(NSObject[] newPoints);
    }

    public interface IZXResultPointCallback { }

    // @protocol ZXResultPointCallback <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ZXResultPointCallback
    {
        // @required -(void)foundPossibleResultPoint:(ZXResultPoint *)point;
        [Abstract]
        [Export("foundPossibleResultPoint:")]
        void FoundPossibleResultPoint(ZXResultPoint point);
    }

    // @interface ZXRGBLuminanceSource : ZXLuminanceSource
    [BaseType(typeof(ZXLuminanceSource))]
    interface ZXRGBLuminanceSource
    {
        //// -(id)initWithWidth:(int)width height:(int)height pixels:(int32_t *)pixels pixelsLen:(int)pixelsLen;
        //[Export("initWithWidth:height:pixels:pixelsLen:")]
        //unsafe IntPtr Constructor(int width, int height, int* pixels, int pixelsLen);
    }

    public interface IZXWriter { }

    // @protocol ZXWriter <NSObject>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ZXWriter
    {
        // @required -(ZXBitMatrix *)encode:(NSString *)contents format:(ZXBarcodeFormat)format width:(int)width height:(int)height error:(NSError **)error;
        [Abstract]
        [Export("encode:format:width:height:error:")]
        ZXBitMatrix Format(string contents, ZXBarcodeFormat format, int width, int height, out NSError error);

        // @required -(ZXBitMatrix *)encode:(NSString *)contents format:(ZXBarcodeFormat)format width:(int)width height:(int)height hints:(ZXEncodeHints *)hints error:(NSError **)error;
        [Abstract]
        [Export("encode:format:width:height:hints:error:")]
        ZXBitMatrix Format(string contents, ZXBarcodeFormat format, int width, int height, ZXEncodeHints hints, out NSError error);
    }

    // @interface ZXByQuadrantReader : NSObject <ZXReader>
    [BaseType(typeof(NSObject))]
    interface ZXByQuadrantReader : ZXReader
    {
        // -(id)initWithDelegate:(id<ZXReader>)delegate;
        [Export("initWithDelegate:")]
        IntPtr Constructor(ZXReader @delegate);
    }

    public interface IZXMultipleBarcodeReader {}

	// @protocol ZXMultipleBarcodeReader <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    interface ZXMultipleBarcodeReader
	{
		// @required -(NSArray *)decodeMultiple:(ZXBinaryBitmap *)image error:(NSError **)error;
		[Abstract]
		[Export ("decodeMultiple:error:")]
		NSObject[] Error (ZXBinaryBitmap image, out NSError error);

		// @required -(NSArray *)decodeMultiple:(ZXBinaryBitmap *)image hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Abstract]
		[Export ("decodeMultiple:hints:error:")]
		NSObject[] Hints (ZXBinaryBitmap image, ZXDecodeHints hints, out NSError error);
	}

	// @interface ZXGenericMultipleBarcodeReader : NSObject <ZXMultipleBarcodeReader>
	[BaseType (typeof(NSObject))]
	interface ZXGenericMultipleBarcodeReader : IZXMultipleBarcodeReader
	{
		// -(id)initWithDelegate:(id<ZXReader>)delegate;
		[Export ("initWithDelegate:")]
		IntPtr Constructor (ZXReader @delegate);
	}

	// @interface ZXAztecCode : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAztecCode
	{
		// @property (assign, nonatomic) int codeWords;
		[Export ("codeWords")]
		int CodeWords { get; set; }

		// @property (getter = isCompact, assign, nonatomic) BOOL compact;
		[Export ("compact")]
		bool Compact { [Bind ("isCompact")] get; set; }

		// @property (assign, nonatomic) int layers;
		[Export ("layers")]
		int Layers { get; set; }

		// @property (nonatomic, strong) ZXBitMatrix * matrix;
		[Export ("matrix", ArgumentSemantic.Strong)]
		ZXBitMatrix Matrix { get; set; }

		// @property (assign, nonatomic) int size;
		[Export ("size")]
		int Size { get; set; }
	}

	// @interface ZXAztecDecoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAztecDecoder
	{
		// -(ZXDecoderResult *)decode:(ZXAztecDetectorResult *)detectorResult error:(NSError **)error;
		[Export ("decode:error:")]
		ZXDecoderResult Decode (ZXAztecDetectorResult detectorResult, out NSError error);

		// +(NSString *)highLevelDecode:(ZXBoolArray *)correctedBits;
		[Static]
		[Export ("highLevelDecode:")]
		string HighLevelDecode (ZXBoolArray correctedBits);
	}

	// @interface ZXAztecPoint : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAztecPoint
	{
		// @property (readonly, assign, nonatomic) int x;
		[Export ("x")]
		int X { get; }

		// @property (readonly, assign, nonatomic) int y;
		[Export ("y")]
		int Y { get; }

		// -(id)initWithX:(int)x y:(int)y;
		[Export ("initWithX:y:")]
		IntPtr Constructor (int x, int y);
	}

	// @interface ZXAztecDetector : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAztecDetector
	{
		// -(id)initWithImage:(ZXBitMatrix *)image;
		[Export ("initWithImage:")]
		IntPtr Constructor (ZXBitMatrix image);

		// -(ZXAztecDetectorResult *)detectWithError:(NSError **)error;
		[Export ("detectWithError:")]
		ZXAztecDetectorResult DetectWithError (out NSError error);

		// -(ZXAztecDetectorResult *)detectWithMirror:(BOOL)isMirror error:(NSError **)error;
		[Export ("detectWithMirror:error:")]
		ZXAztecDetectorResult DetectWithMirror (bool isMirror, out NSError error);
	}

	// @interface ZXAztecDetectorResult : ZXDetectorResult
	[BaseType (typeof(ZXDetectorResult))]
	interface ZXAztecDetectorResult
	{
		// @property (readonly, getter = isCompact, assign, nonatomic) BOOL compact;
		[Export ("compact")]
		bool Compact { [Bind ("isCompact")] get; }

		// @property (readonly, assign, nonatomic) int nbDatablocks;
		[Export ("nbDatablocks")]
		int NbDatablocks { get; }

		// @property (readonly, assign, nonatomic) int nbLayers;
		[Export ("nbLayers")]
		int NbLayers { get; }

		// -(id)initWithBits:(ZXBitMatrix *)bits points:(NSArray *)points compact:(BOOL)compact nbDatablocks:(int)nbDatablocks nbLayers:(int)nbLayers;
		[Export ("initWithBits:points:compact:nbDatablocks:nbLayers:")]
		IntPtr Constructor (ZXBitMatrix bits, NSObject[] points, bool compact, int nbDatablocks, int nbLayers);
	}

	[Static]
	partial interface Constants
	{
		//// extern const int ZX_AZTEC_DEFAULT_EC_PERCENT;
		//[Field ("ZX_AZTEC_DEFAULT_EC_PERCENT")]
		//int ZX_AZTEC_DEFAULT_EC_PERCENT { get; }

		//// extern const int ZX_AZTEC_DEFAULT_LAYERS;
		//[Field ("ZX_AZTEC_DEFAULT_LAYERS")]
		//int ZX_AZTEC_DEFAULT_LAYERS { get; }

        //// extern NSArray * ZX_AZTEC_MODE_NAMES;
        //[Field("ZX_AZTEC_MODE_NAMES")]
        //NSObject[] ZX_AZTEC_MODE_NAMES { get; }

        //// extern const int ZX_AZTEC_MODE_UPPER;
        //[Field("ZX_AZTEC_MODE_UPPER")]
        //int ZX_AZTEC_MODE_UPPER { get; }

        //// extern const int ZX_AZTEC_MODE_LOWER;
        //[Field("ZX_AZTEC_MODE_LOWER")]
        //int ZX_AZTEC_MODE_LOWER { get; }

        //// extern const int ZX_AZTEC_MODE_DIGIT;
        //[Field("ZX_AZTEC_MODE_DIGIT")]
        //int ZX_AZTEC_MODE_DIGIT { get; }

        //// extern const int ZX_AZTEC_MODE_MIXED;
        //[Field("ZX_AZTEC_MODE_MIXED")]
        //int ZX_AZTEC_MODE_MIXED { get; }

        //// extern const int ZX_AZTEC_MODE_PUNCT;
        //[Field("ZX_AZTEC_MODE_PUNCT")]
        //int ZX_AZTEC_MODE_PUNCT { get; }

        //// extern const int [][5] ZX_AZTEC_LATCH_TABLE;
        //[Field("ZX_AZTEC_LATCH_TABLE")]
        //int[][] ZX_AZTEC_LATCH_TABLE { get; }

        //// extern int [6][6] ZX_AZTEC_SHIFT_TABLE;
        //[Field("ZX_AZTEC_SHIFT_TABLE")]
        //int[][] ZX_AZTEC_SHIFT_TABLE { get; }

        //// extern const int [][7] ZX_CODE128_CODE_PATTERNS;
        //[Field("ZX_CODE128_CODE_PATTERNS")]
        //int[][] ZX_CODE128_CODE_PATTERNS { get; }

        //// extern const int ZX_CODE128_CODE_START_B;
        //[Field("ZX_CODE128_CODE_START_B")]
        //int ZX_CODE128_CODE_START_B { get; }

        //// extern const int ZX_CODE128_CODE_START_C;
        //[Field("ZX_CODE128_CODE_START_C")]
        //int ZX_CODE128_CODE_START_C { get; }

        //// extern const int ZX_CODE128_CODE_CODE_B;
        //[Field("ZX_CODE128_CODE_CODE_B")]
        //int ZX_CODE128_CODE_CODE_B { get; }

        //// extern const int ZX_CODE128_CODE_CODE_C;
        //[Field("ZX_CODE128_CODE_CODE_C")]
        //int ZX_CODE128_CODE_CODE_C { get; }

        //// extern const int ZX_CODE128_CODE_STOP;
        //[Field("ZX_CODE128_CODE_STOP")]
        //int ZX_CODE128_CODE_STOP { get; }

        //// extern const int ZX_CODE128_CODE_FNC_1;
        //[Field("ZX_CODE128_CODE_FNC_1")]
        //int ZX_CODE128_CODE_FNC_1 { get; }

        //// extern const int ZX_CODE128_CODE_FNC_2;
        //[Field("ZX_CODE128_CODE_FNC_2")]
        //int ZX_CODE128_CODE_FNC_2 { get; }

        //// extern const int ZX_CODE128_CODE_FNC_3;
        //[Field("ZX_CODE128_CODE_FNC_3")]
        //int ZX_CODE128_CODE_FNC_3 { get; }

        //// extern const int ZX_CODE128_CODE_FNC_4_A;
        //[Field("ZX_CODE128_CODE_FNC_4_A")]
        //int ZX_CODE128_CODE_FNC_4_A { get; }

        //// extern const int ZX_CODE128_CODE_FNC_4_B;
        //[Field("ZX_CODE128_CODE_FNC_4_B")]
        //int ZX_CODE128_CODE_FNC_4_B { get; }

        //// extern unichar [] ZX_CODE39_ALPHABET;
        //[Field("ZX_CODE39_ALPHABET")]
        //ushort[] ZX_CODE39_ALPHABET { get; }

        //// extern NSString * ZX_CODE39_ALPHABET_STRING;
        //[Field("ZX_CODE39_ALPHABET_STRING")]
        //NSString ZX_CODE39_ALPHABET_STRING { get; }

        //// extern const int [] ZX_CODE39_CHARACTER_ENCODINGS;
        //[Field("ZX_CODE39_CHARACTER_ENCODINGS")]
        //int[] ZX_CODE39_CHARACTER_ENCODINGS { get; }

        //// extern const int ZX_UPC_EAN_START_END_PATTERN_LEN;
        //[Field("ZX_UPC_EAN_START_END_PATTERN_LEN")]
        //int ZX_UPC_EAN_START_END_PATTERN_LEN { get; }

        //// extern const int [] ZX_UPC_EAN_START_END_PATTERN;
        //[Field("ZX_UPC_EAN_START_END_PATTERN")]
        //int[] ZX_UPC_EAN_START_END_PATTERN { get; }

        //// extern const int ZX_UPC_EAN_MIDDLE_PATTERN_LEN;
        //[Field("ZX_UPC_EAN_MIDDLE_PATTERN_LEN")]
        //int ZX_UPC_EAN_MIDDLE_PATTERN_LEN { get; }

        //// extern const int [] ZX_UPC_EAN_MIDDLE_PATTERN;
        //[Field("ZX_UPC_EAN_MIDDLE_PATTERN")]
        //int[] ZX_UPC_EAN_MIDDLE_PATTERN { get; }

        //// extern const int ZX_UPC_EAN_L_PATTERNS_LEN;
        //[Field("ZX_UPC_EAN_L_PATTERNS_LEN")]
        //int ZX_UPC_EAN_L_PATTERNS_LEN { get; }

        //// extern const int ZX_UPC_EAN_L_PATTERNS_SUB_LEN;
        //[Field("ZX_UPC_EAN_L_PATTERNS_SUB_LEN")]
        //int ZX_UPC_EAN_L_PATTERNS_SUB_LEN { get; }

        //// extern const int [][4] ZX_UPC_EAN_L_PATTERNS;
        //[Field("ZX_UPC_EAN_L_PATTERNS")]
        //int[][] ZX_UPC_EAN_L_PATTERNS { get; }

        //// extern const int ZX_UPC_EAN_L_AND_G_PATTERNS_LEN;
        //[Field("ZX_UPC_EAN_L_AND_G_PATTERNS_LEN")]
        //int ZX_UPC_EAN_L_AND_G_PATTERNS_LEN { get; }

        //// extern const int ZX_UPC_EAN_L_AND_G_PATTERNS_SUB_LEN;
        //[Field("ZX_UPC_EAN_L_AND_G_PATTERNS_SUB_LEN")]
        //int ZX_UPC_EAN_L_AND_G_PATTERNS_SUB_LEN { get; }

        //// extern const int [][4] ZX_UPC_EAN_L_AND_G_PATTERNS;
        //[Field("ZX_UPC_EAN_L_AND_G_PATTERNS")]
        //int[][] ZX_UPC_EAN_L_AND_G_PATTERNS { get; }

        //// extern const int [] ZX_EAN13_FIRST_DIGIT_ENCODINGS;
        //[Field("ZX_EAN13_FIRST_DIGIT_ENCODINGS")]
        //int[] ZX_EAN13_FIRST_DIGIT_ENCODINGS { get; }

        //// extern const int [][5] ZX_ITF_PATTERNS;
        //[Field("ZX_ITF_PATTERNS")]
        //int[][] ZX_ITF_PATTERNS { get; }

        //// extern const int [] CHECK_DIGIT_ENCODINGS;
        //[Field("CHECK_DIGIT_ENCODINGS")]
        //int[] CHECK_DIGIT_ENCODINGS { get; }

        //// extern const int ZX_UPCE_MIDDLE_END_PATTERN_LEN;
        //[Field("ZX_UPCE_MIDDLE_END_PATTERN_LEN")]
        //int ZX_UPCE_MIDDLE_END_PATTERN_LEN { get; }

        //// extern const int [] ZX_UPCE_MIDDLE_END_PATTERN;
        //[Field("ZX_UPCE_MIDDLE_END_PATTERN")]
        //int[] ZX_UPCE_MIDDLE_END_PATTERN { get; }

        //// extern NSString *const ZX_KILOGRAM;
        //[Field("ZX_KILOGRAM")]
        //NSString ZX_KILOGRAM { get; }

        //// extern NSString *const ZX_POUND;
        //[Field("ZX_POUND")]
        //NSString ZX_POUND { get; }

        //// extern const int [] ZX_PDF417_SYMBOL_TABLE;
        //[Field("ZX_PDF417_SYMBOL_TABLE")]
        //int[] ZX_PDF417_SYMBOL_TABLE { get; }

        //// extern const int ZX_PDF417_NUMBER_OF_CODEWORDS;
        //[Field("ZX_PDF417_NUMBER_OF_CODEWORDS")]
        //int ZX_PDF417_NUMBER_OF_CODEWORDS { get; }

        //// extern const int ZX_PDF417_MIN_ROWS_IN_BARCODE;
        //[Field("ZX_PDF417_MIN_ROWS_IN_BARCODE")]
        //int ZX_PDF417_MIN_ROWS_IN_BARCODE { get; }

        //// extern const int ZX_PDF417_MAX_ROWS_IN_BARCODE;
        //[Field("ZX_PDF417_MAX_ROWS_IN_BARCODE")]
        //int ZX_PDF417_MAX_ROWS_IN_BARCODE { get; }

        //// extern const int ZX_PDF417_MAX_CODEWORDS_IN_BARCODE;
        //[Field("ZX_PDF417_MAX_CODEWORDS_IN_BARCODE")]
        //int ZX_PDF417_MAX_CODEWORDS_IN_BARCODE { get; }

        //// extern const int ZX_PDF417_MODULES_IN_CODEWORD;
        //[Field("ZX_PDF417_MODULES_IN_CODEWORD")]
        //int ZX_PDF417_MODULES_IN_CODEWORD { get; }

        //// extern const int ZX_PDF417_MODULES_IN_STOP_PATTERN;
        //[Field("ZX_PDF417_MODULES_IN_STOP_PATTERN")]
        //int ZX_PDF417_MODULES_IN_STOP_PATTERN { get; }

        //// extern const int ZX_NUM_MASK_PATTERNS;
        //[Field("ZX_NUM_MASK_PATTERNS")]
        //int ZX_NUM_MASK_PATTERNS { get; }

        //// extern const NSStringEncoding ZX_DEFAULT_BYTE_MODE_ENCODING;
        //[Field("ZX_DEFAULT_BYTE_MODE_ENCODING")]
        //nuint ZX_DEFAULT_BYTE_MODE_ENCODING { get; }

        //// extern const int ZX_FINDER_PATTERN_MIN_SKIP;
        //[Field("ZX_FINDER_PATTERN_MIN_SKIP")]
        //int ZX_FINDER_PATTERN_MIN_SKIP { get; }

        //// extern const int ZX_FINDER_PATTERN_MAX_MODULES;
        //[Field("ZX_FINDER_PATTERN_MAX_MODULES")]
        //int ZX_FINDER_PATTERN_MAX_MODULES { get; }

        //// extern const int ZX_CODA_ALPHABET_LEN;
        //[Field("ZX_CODA_ALPHABET_LEN")]
        //int ZX_CODA_ALPHABET_LEN { get; }

        //// extern const unichar [] ZX_CODA_ALPHABET;
        //[Field("ZX_CODA_ALPHABET")]
        //ushort[] ZX_CODA_ALPHABET { get; }

        //// extern const int [] ZX_CODA_CHARACTER_ENCODINGS;
        //[Field("ZX_CODA_CHARACTER_ENCODINGS")]
        //int[] ZX_CODA_CHARACTER_ENCODINGS { get; }
	}

	// @interface ZXAztecEncoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAztecEncoder
	{
		// +(ZXAztecCode *)encode:(ZXByteArray *)data;
		[Static]
		[Export ("encode:")]
		ZXAztecCode Encode (ZXByteArray data);

		// +(ZXAztecCode *)encode:(ZXByteArray *)data minECCPercent:(int)minECCPercent userSpecifiedLayers:(int)userSpecifiedLayers;
		[Static]
		[Export ("encode:minECCPercent:userSpecifiedLayers:")]
		ZXAztecCode Encode (ZXByteArray data, int minECCPercent, int userSpecifiedLayers);
	}

	// @interface ZXAztecHighLevelEncoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAztecHighLevelEncoder
	{
		// -(id)initWithText:(ZXByteArray *)text;
		[Export ("initWithText:")]
		IntPtr Constructor (ZXByteArray text);

		// -(ZXBitArray *)encode;
		[Export ("encode")]
		ZXBitArray Encode { get; }
	}

	// @interface ZXAztecReader : NSObject <ZXReader>
	[BaseType (typeof(NSObject))]
	interface ZXAztecReader : ZXReader
	{
	}

	// @interface ZXAztecWriter : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXAztecWriter : ZXWriter
	{
	}

	// @interface ZXDataMatrixDecoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixDecoder
	{
		// -(ZXDecoderResult *)decode:(NSArray *)image error:(NSError **)error;
		[Export ("decode:error:")]
		ZXDecoderResult Decode (NSObject[] image, out NSError error);

		// -(ZXDecoderResult *)decodeMatrix:(ZXBitMatrix *)bits error:(NSError **)error;
		[Export ("decodeMatrix:error:")]
		ZXDecoderResult DecodeMatrix (ZXBitMatrix bits, out NSError error);
	}

	// @interface ZXDataMatrixDefaultPlacement : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixDefaultPlacement
	{
		// @property (readonly, copy, nonatomic) NSString * codewords;
		[Export ("codewords")]
		string Codewords { get; }

		// @property (readonly, assign, nonatomic) int numrows;
		[Export ("numrows")]
		int Numrows { get; }

		// @property (readonly, assign, nonatomic) int numcols;
		[Export ("numcols")]
		int Numcols { get; }

		//// @property (readonly, assign, nonatomic) int8_t * bits;
		//[Export ("bits", ArgumentSemantic.Assign)]
		//unsafe sbyte* Bits { get; }

		// @property (readonly, assign, nonatomic) int bitsLen;
		[Export ("bitsLen")]
		int BitsLen { get; }

		// -(id)initWithCodewords:(NSString *)codewords numcols:(int)numcols numrows:(int)numrows;
		[Export ("initWithCodewords:numcols:numrows:")]
		IntPtr Constructor (string codewords, int numcols, int numrows);

		// -(BOOL)bitAtCol:(int)col row:(int)row;
		[Export ("bitAtCol:row:")]
		bool BitAtCol (int col, int row);

		// -(void)setBitAtCol:(int)col row:(int)row bit:(BOOL)bit;
		[Export ("setBitAtCol:row:bit:")]
		void SetBitAtCol (int col, int row, bool bit);

		// -(BOOL)hasBitAtCol:(int)col row:(int)row;
		[Export ("hasBitAtCol:row:")]
		bool HasBitAtCol (int col, int row);

		// -(void)place;
		[Export ("place")]
		void Place ();
	}

	// @interface ZXDataMatrixDetector : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixDetector
	{
		// -(id)initWithImage:(ZXBitMatrix *)image error:(NSError **)error;
		[Export ("initWithImage:error:")]
		IntPtr Constructor (ZXBitMatrix image, out NSError error);

		// -(ZXDetectorResult *)detectWithError:(NSError **)error;
		[Export ("detectWithError:")]
		ZXDetectorResult DetectWithError (out NSError error);
	}

    public interface IZXDataMatrixEncoder {}

	// @protocol ZXDataMatrixEncoder <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
    interface ZXDataMatrixEncoder
	{
		// @required -(int)encodingMode;
		[Abstract]
		[Export ("encodingMode")]
		int EncodingMode { get; }

		// @required -(void)encode:(ZXDataMatrixEncoderContext *)context;
		[Abstract]
		[Export ("encode:")]
		void Encode (ZXDataMatrixEncoderContext context);
	}

	// @interface ZXDataMatrixEdifactEncoder : NSObject <ZXDataMatrixEncoder>
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixEdifactEncoder : ZXDataMatrixEncoder
	{
	}

	// @interface ZXDataMatrixEncoderContext : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixEncoderContext
	{
		// @property (readonly, copy, nonatomic) NSMutableString * codewords;
		[Export ("codewords", ArgumentSemantic.Copy)]
		NSMutableString Codewords { get; }

		// @property (readonly, copy, nonatomic) NSString * message;
		[Export ("message")]
		string Message { get; }

		// @property (assign, nonatomic) int newEncoding;
		[Export ("newEncoding")]
		int NewEncoding { get; set; }

		// @property (assign, nonatomic) int pos;
		[Export ("pos")]
		int Pos { get; set; }

		// @property (assign, nonatomic) int skipAtEnd;
		[Export ("skipAtEnd")]
		int SkipAtEnd { get; set; }

		// @property (assign, nonatomic) ZXDataMatrixSymbolShapeHint symbolShape;
		[Export ("symbolShape", ArgumentSemantic.Assign)]
		ZXDataMatrixSymbolShapeHint SymbolShape { get; set; }

		// @property (nonatomic, strong) ZXDataMatrixSymbolInfo * symbolInfo;
		[Export ("symbolInfo", ArgumentSemantic.Strong)]
		ZXDataMatrixSymbolInfo SymbolInfo { get; set; }

		// -(id)initWithMessage:(NSString *)msg;
		[Export ("initWithMessage:")]
		IntPtr Constructor (string msg);

		// -(void)setSizeConstraints:(ZXDimension *)minSize maxSize:(ZXDimension *)maxSize;
		[Export ("setSizeConstraints:maxSize:")]
		void SetSizeConstraints (ZXDimension minSize, ZXDimension maxSize);

		// -(unichar)currentChar;
		[Export ("currentChar")]
		ushort CurrentChar { get; }

		// -(unichar)current;
		[Export ("current")]
		ushort Current { get; }

		// -(void)writeCodewords:(NSString *)codewords;
		[Export ("writeCodewords:")]
		void WriteCodewords (string codewords);

		// -(void)writeCodeword:(unichar)codeword;
		[Export ("writeCodeword:")]
		void WriteCodeword (ushort codeword);

		// -(int)codewordCount;
		[Export ("codewordCount")]
		int CodewordCount { get; }

		// -(void)signalEncoderChange:(int)encoding;
		[Export ("signalEncoderChange:")]
		void SignalEncoderChange (int encoding);

		// -(void)resetEncoderSignal;
		[Export ("resetEncoderSignal")]
		void ResetEncoderSignal ();

		// -(BOOL)hasMoreCharacters;
		[Export ("hasMoreCharacters")]
		bool HasMoreCharacters { get; }

		// -(int)totalMessageCharCount;
		[Export ("totalMessageCharCount")]
		int TotalMessageCharCount { get; }

		// -(int)remainingCharacters;
		[Export ("remainingCharacters")]
		int RemainingCharacters { get; }

		// -(void)updateSymbolInfo;
		[Export ("updateSymbolInfo")]
		void UpdateSymbolInfo ();

		// -(void)updateSymbolInfoWithLength:(int)len;
		[Export ("updateSymbolInfoWithLength:")]
		void UpdateSymbolInfoWithLength (int len);

		// -(void)resetSymbolInfo;
		[Export ("resetSymbolInfo")]
		void ResetSymbolInfo ();
	}

	// @interface ZXDataMatrixErrorCorrection : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixErrorCorrection
	{
		// +(NSString *)encodeECC200:(NSString *)codewords symbolInfo:(ZXDataMatrixSymbolInfo *)symbolInfo;
		[Static]
		[Export ("encodeECC200:symbolInfo:")]
		string EncodeECC200 (string codewords, ZXDataMatrixSymbolInfo symbolInfo);
	}

	// @interface ZXDataMatrixHighLevelEncoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixHighLevelEncoder
	{
		// +(unichar)latchToC40;
		[Static]
		[Export ("latchToC40")]
		ushort LatchToC40 { get; }

		// +(unichar)latchToBase256;
		[Static]
		[Export ("latchToBase256")]
		ushort LatchToBase256 { get; }

		// +(unichar)upperShift;
		[Static]
		[Export ("upperShift")]
		ushort UpperShift { get; }

		// +(unichar)macro05;
		[Static]
		[Export ("macro05")]
		ushort Macro05 { get; }

		// +(unichar)macro06;
		[Static]
		[Export ("macro06")]
		ushort Macro06 { get; }

		// +(unichar)latchToAnsiX12;
		[Static]
		[Export ("latchToAnsiX12")]
		ushort LatchToAnsiX12 { get; }

		// +(unichar)latchToText;
		[Static]
		[Export ("latchToText")]
		ushort LatchToText { get; }

		// +(unichar)latchToEdifact;
		[Static]
		[Export ("latchToEdifact")]
		ushort LatchToEdifact { get; }

		// +(unichar)c40Unlatch;
		[Static]
		[Export ("c40Unlatch")]
		ushort C40Unlatch { get; }

		// +(unichar)x12Unlatch;
		[Static]
		[Export ("x12Unlatch")]
		ushort X12Unlatch { get; }

		// +(int)asciiEncodation;
		[Static]
		[Export ("asciiEncodation")]
		int AsciiEncodation { get; }

		// +(int)c40Encodation;
		[Static]
		[Export ("c40Encodation")]
		int C40Encodation { get; }

		// +(int)textEncodation;
		[Static]
		[Export ("textEncodation")]
		int TextEncodation { get; }

		// +(int)x12Encodation;
		[Static]
		[Export ("x12Encodation")]
		int X12Encodation { get; }

		// +(int)edifactEncodation;
		[Static]
		[Export ("edifactEncodation")]
		int EdifactEncodation { get; }

		// +(int)base256Encodation;
		[Static]
		[Export ("base256Encodation")]
		int Base256Encodation { get; }

		// +(NSString *)encodeHighLevel:(NSString *)msg;
		[Static]
		[Export ("encodeHighLevel:")]
		string EncodeHighLevel (string msg);

		// +(NSString *)encodeHighLevel:(NSString *)msg shape:(ZXDataMatrixSymbolShapeHint)shape minSize:(ZXDimension *)minSize maxSize:(ZXDimension *)maxSize;
		[Static]
		[Export ("encodeHighLevel:shape:minSize:maxSize:")]
		string EncodeHighLevel (string msg, ZXDataMatrixSymbolShapeHint shape, ZXDimension minSize, ZXDimension maxSize);

		// +(int)lookAheadTest:(NSString *)msg startpos:(int)startpos currentMode:(int)currentMode;
		[Static]
		[Export ("lookAheadTest:startpos:currentMode:")]
		int LookAheadTest (string msg, int startpos, int currentMode);

		// +(int)determineConsecutiveDigitCount:(NSString *)msg startpos:(int)startpos;
		[Static]
		[Export ("determineConsecutiveDigitCount:startpos:")]
		int DetermineConsecutiveDigitCount (string msg, int startpos);

		// +(BOOL)isDigit:(unichar)ch;
		[Static]
		[Export ("isDigit:")]
		bool IsDigit (ushort ch);

		// +(BOOL)isExtendedASCII:(unichar)ch;
		[Static]
		[Export ("isExtendedASCII:")]
		bool IsExtendedASCII (ushort ch);

		// +(void)illegalCharacter:(unichar)c;
		[Static]
		[Export ("illegalCharacter:")]
		void IllegalCharacter (ushort c);
	}

	// @interface ZXDataMatrixReader : NSObject <ZXReader>
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixReader : ZXReader
	{
	}

	// @interface ZXDataMatrixSymbolInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixSymbolInfo
	{
		// @property (readonly, assign, nonatomic) BOOL rectangular;
		[Export ("rectangular")]
		bool Rectangular { get; }

		// @property (readonly, assign, nonatomic) int errorCodewords;
		[Export ("errorCodewords")]
		int ErrorCodewords { get; }

		// @property (readonly, assign, nonatomic) int dataCapacity;
		[Export ("dataCapacity")]
		int DataCapacity { get; }

		// @property (readonly, assign, nonatomic) int dataRegions;
		[Export ("dataRegions")]
		int DataRegions { get; }

		// @property (readonly, assign, nonatomic) int matrixWidth;
		[Export ("matrixWidth")]
		int MatrixWidth { get; }

		// @property (readonly, assign, nonatomic) int matrixHeight;
		[Export ("matrixHeight")]
		int MatrixHeight { get; }

		// @property (readonly, assign, nonatomic) int rsBlockData;
		[Export ("rsBlockData")]
		int RsBlockData { get; }

		// @property (readonly, assign, nonatomic) int rsBlockError;
		[Export ("rsBlockError")]
		int RsBlockError { get; }

		// +(void)overrideSymbolSet:(NSArray *)override;
		[Static]
		[Export ("overrideSymbolSet:")]
		void OverrideSymbolSet (NSObject[] @override);

		// +(NSArray *)prodSymbols;
		[Static]
		[Export ("prodSymbols")]
		NSObject[] ProdSymbols { get; }

		// -(id)initWithRectangular:(BOOL)rectangular dataCapacity:(int)dataCapacity errorCodewords:(int)errorCodewords matrixWidth:(int)matrixWidth matrixHeight:(int)matrixHeight dataRegions:(int)dataRegions;
		[Export ("initWithRectangular:dataCapacity:errorCodewords:matrixWidth:matrixHeight:dataRegions:")]
		IntPtr Constructor (bool rectangular, int dataCapacity, int errorCodewords, int matrixWidth, int matrixHeight, int dataRegions);

		// -(id)initWithRectangular:(BOOL)rectangular dataCapacity:(int)dataCapacity errorCodewords:(int)errorCodewords matrixWidth:(int)matrixWidth matrixHeight:(int)matrixHeight dataRegions:(int)dataRegions rsBlockData:(int)rsBlockData rsBlockError:(int)rsBlockError;
		[Export ("initWithRectangular:dataCapacity:errorCodewords:matrixWidth:matrixHeight:dataRegions:rsBlockData:rsBlockError:")]
		IntPtr Constructor (bool rectangular, int dataCapacity, int errorCodewords, int matrixWidth, int matrixHeight, int dataRegions, int rsBlockData, int rsBlockError);

		// +(ZXDataMatrixSymbolInfo *)lookup:(int)dataCodewords;
		[Static]
		[Export ("lookup:")]
		ZXDataMatrixSymbolInfo Lookup (int dataCodewords);

		// +(ZXDataMatrixSymbolInfo *)lookup:(int)dataCodewords shape:(ZXDataMatrixSymbolShapeHint)shape;
		[Static]
		[Export ("lookup:shape:")]
		ZXDataMatrixSymbolInfo Lookup (int dataCodewords, ZXDataMatrixSymbolShapeHint shape);

		// +(ZXDataMatrixSymbolInfo *)lookup:(int)dataCodewords allowRectangular:(BOOL)allowRectangular fail:(BOOL)fail;
		[Static]
		[Export ("lookup:allowRectangular:fail:")]
		ZXDataMatrixSymbolInfo Lookup (int dataCodewords, bool allowRectangular, bool fail);

		// +(ZXDataMatrixSymbolInfo *)lookup:(int)dataCodewords shape:(ZXDataMatrixSymbolShapeHint)shape fail:(BOOL)fail;
		[Static]
		[Export ("lookup:shape:fail:")]
		ZXDataMatrixSymbolInfo Lookup (int dataCodewords, ZXDataMatrixSymbolShapeHint shape, bool fail);

		// +(ZXDataMatrixSymbolInfo *)lookup:(int)dataCodewords shape:(ZXDataMatrixSymbolShapeHint)shape minSize:(ZXDimension *)minSize maxSize:(ZXDimension *)maxSize fail:(BOOL)fail;
		[Static]
		[Export ("lookup:shape:minSize:maxSize:fail:")]
		ZXDataMatrixSymbolInfo Lookup (int dataCodewords, ZXDataMatrixSymbolShapeHint shape, ZXDimension minSize, ZXDimension maxSize, bool fail);

		// -(int)horizontalDataRegions;
		[Export ("horizontalDataRegions")]
		int HorizontalDataRegions { get; }

		// -(int)verticalDataRegions;
		[Export ("verticalDataRegions")]
		int VerticalDataRegions { get; }

		// -(int)symbolDataWidth;
		[Export ("symbolDataWidth")]
		int SymbolDataWidth { get; }

		// -(int)symbolDataHeight;
		[Export ("symbolDataHeight")]
		int SymbolDataHeight { get; }

		// -(int)symbolWidth;
		[Export ("symbolWidth")]
		int SymbolWidth { get; }

		// -(int)symbolHeight;
		[Export ("symbolHeight")]
		int SymbolHeight { get; }

		// -(int)codewordCount;
		[Export ("codewordCount")]
		int CodewordCount { get; }

		// -(int)interleavedBlockCount;
		[Export ("interleavedBlockCount")]
		int InterleavedBlockCount { get; }

		// -(int)dataLengthForInterleavedBlock:(int)index;
		[Export ("dataLengthForInterleavedBlock:")]
		int DataLengthForInterleavedBlock (int index);

		// -(int)errorLengthForInterleavedBlock:(int)index;
		[Export ("errorLengthForInterleavedBlock:")]
		int ErrorLengthForInterleavedBlock (int index);
	}

	// @interface ZXDataMatrixECBlocks : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixECBlocks
	{
		// @property (readonly, nonatomic, strong) NSArray * ecBlocks;
		[Export ("ecBlocks", ArgumentSemantic.Strong)]
		NSObject[] EcBlocks { get; }

		// @property (readonly, assign, nonatomic) int ecCodewords;
		[Export ("ecCodewords")]
		int EcCodewords { get; }
	}

	// @interface ZXDataMatrixECB : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixECB
	{
		// @property (readonly, assign, nonatomic) int count;
		[Export ("count")]
		int Count { get; }

		// @property (readonly, assign, nonatomic) int dataCodewords;
		[Export ("dataCodewords")]
		int DataCodewords { get; }
	}

	// @interface ZXDataMatrixVersion : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixVersion
	{
		// @property (readonly, nonatomic, strong) ZXDataMatrixECBlocks * ecBlocks;
		[Export ("ecBlocks", ArgumentSemantic.Strong)]
		ZXDataMatrixECBlocks EcBlocks { get; }

		// @property (readonly, assign, nonatomic) int dataRegionSizeColumns;
		[Export ("dataRegionSizeColumns")]
		int DataRegionSizeColumns { get; }

		// @property (readonly, assign, nonatomic) int dataRegionSizeRows;
		[Export ("dataRegionSizeRows")]
		int DataRegionSizeRows { get; }

		// @property (readonly, assign, nonatomic) int symbolSizeColumns;
		[Export ("symbolSizeColumns")]
		int SymbolSizeColumns { get; }

		// @property (readonly, assign, nonatomic) int symbolSizeRows;
		[Export ("symbolSizeRows")]
		int SymbolSizeRows { get; }

		// @property (readonly, assign, nonatomic) int totalCodewords;
		[Export ("totalCodewords")]
		int TotalCodewords { get; }

		// @property (readonly, assign, nonatomic) int versionNumber;
		[Export ("versionNumber")]
		int VersionNumber { get; }

		// +(ZXDataMatrixVersion *)versionForDimensions:(int)numRows numColumns:(int)numColumns;
		[Static]
		[Export ("versionForDimensions:numColumns:")]
		ZXDataMatrixVersion VersionForDimensions (int numRows, int numColumns);
	}

	// @interface ZXDataMatrixWriter : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXDataMatrixWriter : ZXWriter
	{
	}

	// @interface ZXMaxiCodeDecoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXMaxiCodeDecoder
	{
		// -(ZXDecoderResult *)decode:(ZXBitMatrix *)bits error:(NSError **)error;
		[Export ("decode:error:")]
		ZXDecoderResult Decode (ZXBitMatrix bits, out NSError error);

		// -(ZXDecoderResult *)decode:(ZXBitMatrix *)bits hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("decode:hints:error:")]
		ZXDecoderResult Decode (ZXBitMatrix bits, ZXDecodeHints hints, out NSError error);
	}

	// @interface ZXMaxiCodeReader : NSObject <ZXReader>
	[BaseType (typeof(NSObject))]
	interface ZXMaxiCodeReader : ZXReader
	{
	}

    [BaseType (typeof(NSObject))]
    interface ZXRSSExpandedGeneralAppIdDecoder
    {
        
    }

	// @interface ZXAbstractExpandedDecoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXAbstractExpandedDecoder
	{
		// @property (readonly, nonatomic, strong) ZXRSSExpandedGeneralAppIdDecoder * generalDecoder;
		[Export ("generalDecoder", ArgumentSemantic.Strong)]
		ZXRSSExpandedGeneralAppIdDecoder GeneralDecoder { get; }

		// @property (readonly, nonatomic, strong) ZXBitArray * information;
		[Export ("information", ArgumentSemantic.Strong)]
		ZXBitArray Information { get; }

		// -(id)initWithInformation:(ZXBitArray *)information;
		[Export ("initWithInformation:")]
		IntPtr Constructor (ZXBitArray information);

		// -(NSString *)parseInformationWithError:(NSError **)error;
		[Export ("parseInformationWithError:")]
		string ParseInformationWithError (out NSError error);

		// +(ZXAbstractExpandedDecoder *)createDecoder:(ZXBitArray *)information;
		[Static]
		[Export ("createDecoder:")]
		ZXAbstractExpandedDecoder CreateDecoder (ZXBitArray information);
	}

	// @interface ZXOneDReader : NSObject <ZXReader>
	[BaseType (typeof(NSObject))]
	interface ZXOneDReader : ZXReader
	{
		// +(BOOL)recordPattern:(ZXBitArray *)row start:(int)start counters:(ZXIntArray *)counters;
		[Static]
		[Export ("recordPattern:start:counters:")]
		bool RecordPattern (ZXBitArray row, int start, ZXIntArray counters);

		// +(BOOL)recordPatternInReverse:(ZXBitArray *)row start:(int)start counters:(ZXIntArray *)counters;
		[Static]
		[Export ("recordPatternInReverse:start:counters:")]
		bool RecordPatternInReverse (ZXBitArray row, int start, ZXIntArray counters);

		//// +(float)patternMatchVariance:(ZXIntArray *)counters pattern:(const int *)pattern maxIndividualVariance:(float)maxIndividualVariance;
		//[Static]
		//[Export ("patternMatchVariance:pattern:maxIndividualVariance:")]
		//float PatternMatchVariance (ZXIntArray counters, int[] pattern, float maxIndividualVariance);

		// -(ZXResult *)decodeRow:(int)rowNumber row:(ZXBitArray *)row hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("decodeRow:row:hints:error:")]
		ZXResult DecodeRow (int rowNumber, ZXBitArray row, ZXDecodeHints hints, out NSError error);
	}

	// @interface ZXAbstractRSSReader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXAbstractRSSReader
	{
		// @property (readonly, nonatomic, strong) ZXIntArray * decodeFinderCounters;
		[Export ("decodeFinderCounters", ArgumentSemantic.Strong)]
		ZXIntArray DecodeFinderCounters { get; }

		// @property (readonly, nonatomic, strong) ZXIntArray * dataCharacterCounters;
		[Export ("dataCharacterCounters", ArgumentSemantic.Strong)]
		ZXIntArray DataCharacterCounters { get; }

		//// @property (readonly, assign, nonatomic) float * oddRoundingErrors;
		//[Export ("oddRoundingErrors", ArgumentSemantic.Assign)]
		//unsafe float* OddRoundingErrors { get; }

		// @property (readonly, assign, nonatomic) unsigned int oddRoundingErrorsLen;
		[Export ("oddRoundingErrorsLen")]
		uint OddRoundingErrorsLen { get; }

		//// @property (readonly, assign, nonatomic) float * evenRoundingErrors;
		//[Export ("evenRoundingErrors", ArgumentSemantic.Assign)]
		//unsafe float* EvenRoundingErrors { get; }

		// @property (readonly, assign, nonatomic) unsigned int evenRoundingErrorsLen;
		[Export ("evenRoundingErrorsLen")]
		uint EvenRoundingErrorsLen { get; }

		// @property (readonly, nonatomic, strong) ZXIntArray * oddCounts;
		[Export ("oddCounts", ArgumentSemantic.Strong)]
		ZXIntArray OddCounts { get; }

		// @property (readonly, nonatomic, strong) ZXIntArray * evenCounts;
		[Export ("evenCounts", ArgumentSemantic.Strong)]
		ZXIntArray EvenCounts { get; }

		// +(int)parseFinderValue:(ZXIntArray *)counters finderPatternType:(ZX_RSS_PATTERNS)finderPatternType;
		[Static]
		[Export ("parseFinderValue:finderPatternType:")]
        int ParseFinderValue (ZXIntArray counters, ZxRssPatterns finderPatternType);

		// +(int)count:(ZXIntArray *)array;
		[Static]
		[Export ("count:")]
		int Count (ZXIntArray array);

		//// +(void)increment:(ZXIntArray *)array errors:(float *)errors;
		//[Static]
		//[Export ("increment:errors:")]
		//unsafe void Increment (ZXIntArray array, float* errors);

		//// +(void)decrement:(ZXIntArray *)array errors:(float *)errors;
		//[Static]
		//[Export ("decrement:errors:")]
		//unsafe void Decrement (ZXIntArray array, float* errors);

		// +(BOOL)isFinderPattern:(ZXIntArray *)counters;
		[Static]
		[Export ("isFinderPattern:")]
		bool IsFinderPattern (ZXIntArray counters);
	}

	// @interface ZXCodaBarReader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXCodaBarReader
	{
		//// +(BOOL)arrayContains:(const unichar *)array length:(unsigned int)length key:(unichar)key;
		//[Static]
		//[Export ("arrayContains:length:key:")]
		//unsafe bool ArrayContains (ushort* array, uint length, ushort key);
	}

	// @interface ZXOneDimensionalCodeWriter : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXOneDimensionalCodeWriter : ZXWriter
	{
		// -(ZXBoolArray *)encode:(NSString *)contents;
		[Export ("encode:")]
		ZXBoolArray Encode (string contents);

		//// -(int)appendPattern:(ZXBoolArray *)target pos:(int)pos pattern:(const int *)pattern patternLen:(int)patternLen startColor:(BOOL)startColor;
		//[Export ("appendPattern:pos:pattern:patternLen:startColor:")]
		//int AppendPattern (ZXBoolArray target, int pos, int[] pattern, int patternLen, bool startColor);

		// -(int)defaultMargin;
		[Export ("defaultMargin")]
		int DefaultMargin { get; }
	}

	// @interface ZXCodaBarWriter : ZXOneDimensionalCodeWriter
	[BaseType (typeof(ZXOneDimensionalCodeWriter))]
	interface ZXCodaBarWriter
	{
	}

	// @interface ZXCode128Reader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXCode128Reader
	{
	}

	// @interface ZXCode128Writer : ZXOneDimensionalCodeWriter
	[BaseType (typeof(ZXOneDimensionalCodeWriter))]
	interface ZXCode128Writer
	{
	}

	// @interface ZXCode39Reader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXCode39Reader
	{
		// -(id)initUsingCheckDigit:(BOOL)usingCheckDigit;
		[Export ("initUsingCheckDigit:")]
		IntPtr Constructor (bool usingCheckDigit);

		// -(id)initUsingCheckDigit:(BOOL)usingCheckDigit extendedMode:(BOOL)extendedMode;
		[Export ("initUsingCheckDigit:extendedMode:")]
		IntPtr Constructor (bool usingCheckDigit, bool extendedMode);
	}

	// @interface ZXCode39Writer : ZXOneDimensionalCodeWriter
	[BaseType (typeof(ZXOneDimensionalCodeWriter))]
	interface ZXCode39Writer
	{
	}

	// @interface ZXCode93Reader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXCode93Reader
	{
	}

	// @interface ZXUPCEANReader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXUPCEANReader
	{
		// +(NSRange)findStartGuardPattern:(ZXBitArray *)row error:(NSError **)error;
		[Static]
		[Export ("findStartGuardPattern:error:")]
		NSRange FindStartGuardPattern (ZXBitArray row, out NSError error);

		// -(ZXResult *)decodeRow:(int)rowNumber row:(ZXBitArray *)row startGuardRange:(NSRange)startGuardRange hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("decodeRow:row:startGuardRange:hints:error:")]
		ZXResult DecodeRow (int rowNumber, ZXBitArray row, NSRange startGuardRange, ZXDecodeHints hints, out NSError error);

		// -(BOOL)checkChecksum:(NSString *)s error:(NSError **)error;
		[Export ("checkChecksum:error:")]
		bool CheckChecksum (string s, out NSError error);

		// +(BOOL)checkStandardUPCEANChecksum:(NSString *)s;
		[Static]
		[Export ("checkStandardUPCEANChecksum:")]
		bool CheckStandardUPCEANChecksum (string s);

		// -(NSRange)decodeEnd:(ZXBitArray *)row endStart:(int)endStart error:(NSError **)error;
		[Export ("decodeEnd:endStart:error:")]
		NSRange DecodeEnd (ZXBitArray row, int endStart, out NSError error);

		//// +(NSRange)findGuardPattern:(ZXBitArray *)row rowOffset:(int)rowOffset whiteFirst:(BOOL)whiteFirst pattern:(const int *)pattern patternLen:(int)patternLen error:(NSError **)error;
		//[Static]
		//[Export ("findGuardPattern:rowOffset:whiteFirst:pattern:patternLen:error:")]
		//NSRange FindGuardPattern (ZXBitArray row, int rowOffset, bool whiteFirst, int[] pattern, int patternLen, out NSError error);

		//// +(NSRange)findGuardPattern:(ZXBitArray *)row rowOffset:(int)rowOffset whiteFirst:(BOOL)whiteFirst pattern:(const int *)pattern patternLen:(int)patternLen counters:(ZXIntArray *)counters error:(NSError **)error;
		//[Static]
		//[Export ("findGuardPattern:rowOffset:whiteFirst:pattern:patternLen:counters:error:")]
		//NSRange FindGuardPattern (ZXBitArray row, int rowOffset, bool whiteFirst, int[] pattern, int patternLen, ZXIntArray counters, out NSError error);

		// +(int)decodeDigit:(ZXBitArray *)row counters:(ZXIntArray *)counters rowOffset:(int)rowOffset patternType:(ZX_UPC_EAN_PATTERNS)patternType error:(NSError **)error;
		[Static]
		[Export ("decodeDigit:counters:rowOffset:patternType:error:")]
        int DecodeDigit (ZXBitArray row, ZXIntArray counters, int rowOffset, ZxUpcEanPatterns patternType, out NSError error);

		// -(ZXBarcodeFormat)barcodeFormat;
		[Export ("barcodeFormat")]
		ZXBarcodeFormat BarcodeFormat { get; }

		// -(int)decodeMiddle:(ZXBitArray *)row startRange:(NSRange)startRange result:(NSMutableString *)result error:(NSError **)error;
		[Export ("decodeMiddle:startRange:result:error:")]
		int DecodeMiddle (ZXBitArray row, NSRange startRange, NSMutableString result, out NSError error);
	}

	// @interface ZXEAN13Reader : ZXUPCEANReader
	[BaseType (typeof(ZXUPCEANReader))]
	interface ZXEAN13Reader
	{
	}

	// @interface ZXUPCEANWriter : ZXOneDimensionalCodeWriter
	[BaseType (typeof(ZXOneDimensionalCodeWriter))]
	interface ZXUPCEANWriter
	{
	}

	// @interface ZXEAN13Writer : ZXUPCEANWriter
	[BaseType (typeof(ZXUPCEANWriter))]
	interface ZXEAN13Writer
	{
	}

	// @interface ZXEAN8Reader : ZXUPCEANReader
	[BaseType (typeof(ZXUPCEANReader))]
	interface ZXEAN8Reader
	{
	}

	// @interface ZXEAN8Writer : ZXUPCEANWriter
	[BaseType (typeof(ZXUPCEANWriter))]
	interface ZXEAN8Writer
	{
	}

	// @interface ZXITFReader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXITFReader
	{
		// -(ZXIntArray *)decodeStart:(ZXBitArray *)row;
		[Export ("decodeStart:")]
		ZXIntArray DecodeStart (ZXBitArray row);

		// -(ZXIntArray *)decodeEnd:(ZXBitArray *)row;
		[Export ("decodeEnd:")]
		ZXIntArray DecodeEnd (ZXBitArray row);
	}

	// @interface ZXITFWriter : ZXOneDimensionalCodeWriter
	[BaseType (typeof(ZXOneDimensionalCodeWriter))]
	interface ZXITFWriter
	{
	}

	// @interface ZXMultiFormatOneDReader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXMultiFormatOneDReader
	{
		// -(id)initWithHints:(ZXDecodeHints *)hints;
		[Export ("initWithHints:")]
		IntPtr Constructor (ZXDecodeHints hints);
	}

	// @interface ZXMultiFormatUPCEANReader : ZXOneDReader
	[BaseType (typeof(ZXOneDReader))]
	interface ZXMultiFormatUPCEANReader
	{
		// -(id)initWithHints:(ZXDecodeHints *)hints;
		[Export ("initWithHints:")]
		IntPtr Constructor (ZXDecodeHints hints);
	}

	// @interface ZXRSS14Reader : ZXAbstractRSSReader
	[BaseType (typeof(ZXAbstractRSSReader))]
	interface ZXRSS14Reader
	{
	}

	// @interface ZXRSSDataCharacter : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXRSSDataCharacter
	{
		// @property (readonly, assign, nonatomic) int value;
		[Export ("value")]
		int Value { get; }

		// @property (readonly, assign, nonatomic) int checksumPortion;
		[Export ("checksumPortion")]
		int ChecksumPortion { get; }

		// -(id)initWithValue:(int)value checksumPortion:(int)checksumPortion;
		[Export ("initWithValue:checksumPortion:")]
		IntPtr Constructor (int value, int checksumPortion);
	}

	// @interface ZXRSSExpandedReader : ZXAbstractRSSReader
	[BaseType (typeof(ZXAbstractRSSReader))]
	interface ZXRSSExpandedReader
	{
		// @property (readonly, nonatomic, strong) NSMutableArray * rows;
		[Export ("rows", ArgumentSemantic.Strong)]
		NSMutableArray Rows { get; }

		// -(ZXRSSDataCharacter *)decodeDataCharacter:(ZXBitArray *)row pattern:(ZXRSSFinderPattern *)pattern isOddPattern:(BOOL)isOddPattern leftChar:(BOOL)leftChar;
		[Export ("decodeDataCharacter:pattern:isOddPattern:leftChar:")]
		ZXRSSDataCharacter DecodeDataCharacter (ZXBitArray row, ZXRSSFinderPattern pattern, bool isOddPattern, bool leftChar);
	}

	// @interface ZXRSSFinderPattern : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXRSSFinderPattern
	{
		// @property (readonly, assign, nonatomic) int value;
		[Export ("value")]
		int Value { get; }

		// @property (readonly, nonatomic, strong) ZXIntArray * startEnd;
		[Export ("startEnd", ArgumentSemantic.Strong)]
		ZXIntArray StartEnd { get; }

		// @property (readonly, nonatomic, strong) NSMutableArray * resultPoints;
		[Export ("resultPoints", ArgumentSemantic.Strong)]
		NSMutableArray ResultPoints { get; }

		// -(id)initWithValue:(int)value startEnd:(ZXIntArray *)startEnd start:(int)start end:(int)end rowNumber:(int)rowNumber;
		[Export ("initWithValue:startEnd:start:end:rowNumber:")]
		IntPtr Constructor (int value, ZXIntArray startEnd, int start, int end, int rowNumber);
	}

	// @interface ZXRSSUtils : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXRSSUtils
	{
		// +(int)rssValue:(ZXIntArray *)widths maxWidth:(int)maxWidth noNarrow:(BOOL)noNarrow;
		[Static]
		[Export ("rssValue:maxWidth:noNarrow:")]
		int RssValue (ZXIntArray widths, int maxWidth, bool noNarrow);
	}

	// @interface ZXUPCAReader : ZXUPCEANReader
	[BaseType (typeof(ZXUPCEANReader))]
	interface ZXUPCAReader
	{
	}

	// @interface ZXUPCAWriter : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXUPCAWriter : ZXWriter
	{
	}

	// @interface ZXUPCEReader : ZXUPCEANReader
	[BaseType (typeof(ZXUPCEANReader))]
	interface ZXUPCEReader
	{
		// +(NSString *)convertUPCEtoUPCA:(NSString *)upce;
		[Static]
		[Export ("convertUPCEtoUPCA:")]
		string ConvertUPCEtoUPCA (string upce);
	}

	// @interface ZXUPCEWriter : ZXUPCEANWriter
	[BaseType (typeof(ZXUPCEANWriter))]
	interface ZXUPCEWriter
	{
	}

	// @interface ZXResultParser : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXResultParser
	{
		// -(ZXParsedResult *)parse:(ZXResult *)result;
		[Export ("parse:")]
		ZXParsedResult Parse (ZXResult result);

		// +(NSString *)massagedText:(ZXResult *)result;
		[Static]
		[Export ("massagedText:")]
		string MassagedText (ZXResult result);

		// +(ZXParsedResult *)parseResult:(ZXResult *)theResult;
		[Static]
		[Export ("parseResult:")]
		ZXParsedResult ParseResult (ZXResult theResult);

		// -(void)maybeAppend:(NSString *)value result:(NSMutableString *)result;
		[Export ("maybeAppend:result:")]
		void MaybeAppend (string value, NSMutableString result);

		// -(void)maybeAppendArray:(NSArray *)value result:(NSMutableString *)result;
		[Export ("maybeAppendArray:result:")]
		void MaybeAppendArray (NSObject[] value, NSMutableString result);

		// -(NSArray *)maybeWrap:(NSString *)value;
		[Export ("maybeWrap:")]
		NSObject[] MaybeWrap (string value);

		// +(BOOL)isStringOfDigits:(NSString *)value length:(unsigned int)length;
		[Static]
		[Export ("isStringOfDigits:length:")]
		bool IsStringOfDigits (string value, uint length);

		// +(BOOL)isSubstringOfDigits:(NSString *)value offset:(int)offset length:(int)length;
		[Static]
		[Export ("isSubstringOfDigits:offset:length:")]
		bool IsSubstringOfDigits (string value, int offset, int length);

		// +(int)parseHexDigit:(unichar)c;
		[Static]
		[Export ("parseHexDigit:")]
		int ParseHexDigit (ushort c);

		// -(NSMutableDictionary *)parseNameValuePairs:(NSString *)uri;
		[Export ("parseNameValuePairs:")]
		NSMutableDictionary ParseNameValuePairs (string uri);

		// +(NSString *)urlDecode:(NSString *)encoded;
		[Static]
		[Export ("urlDecode:")]
		string UrlDecode (string encoded);

		// +(NSArray *)matchPrefixedField:(NSString *)prefix rawText:(NSString *)rawText endChar:(unichar)endChar trim:(BOOL)trim;
		[Static]
		[Export ("matchPrefixedField:rawText:endChar:trim:")]
		NSObject[] MatchPrefixedField (string prefix, string rawText, ushort endChar, bool trim);

		// +(NSString *)matchSinglePrefixedField:(NSString *)prefix rawText:(NSString *)rawText endChar:(unichar)endChar trim:(BOOL)trim;
		[Static]
		[Export ("matchSinglePrefixedField:rawText:endChar:trim:")]
		string MatchSinglePrefixedField (string prefix, string rawText, ushort endChar, bool trim);
	}

	// @interface ZXAddressBookAUResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXAddressBookAUResultParser
	{
	}

	// @interface ZXAbstractDoCoMoResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXAbstractDoCoMoResultParser
	{
		// +(NSArray *)matchDoCoMoPrefixedField:(NSString *)prefix rawText:(NSString *)rawText trim:(BOOL)trim;
		[Static]
		[Export ("matchDoCoMoPrefixedField:rawText:trim:")]
		NSObject[] MatchDoCoMoPrefixedField (string prefix, string rawText, bool trim);

		// +(NSString *)matchSingleDoCoMoPrefixedField:(NSString *)prefix rawText:(NSString *)rawText trim:(BOOL)trim;
		[Static]
		[Export ("matchSingleDoCoMoPrefixedField:rawText:trim:")]
		string MatchSingleDoCoMoPrefixedField (string prefix, string rawText, bool trim);
	}

	// @interface ZXAddressBookDoCoMoResultParser : ZXAbstractDoCoMoResultParser
	[BaseType (typeof(ZXAbstractDoCoMoResultParser))]
	interface ZXAddressBookDoCoMoResultParser
	{
	}

	// @interface ZXParsedResult : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXParsedResult
	{
		// @property (readonly, assign, nonatomic) ZXParsedResultType type;
		[Export ("type", ArgumentSemantic.Assign)]
		ZXParsedResultType Type { get; }

		// -(id)initWithType:(ZXParsedResultType)type;
		[Export ("initWithType:")]
		IntPtr Constructor (ZXParsedResultType type);

		// +(id)parsedResultWithType:(ZXParsedResultType)type;
		[Static]
		[Export ("parsedResultWithType:")]
		NSObject ParsedResultWithType (ZXParsedResultType type);

		// -(NSString *)displayResult;
		[Export ("displayResult")]
		string DisplayResult { get; }

		// +(void)maybeAppend:(NSString *)value result:(NSMutableString *)result;
		[Static]
		[Export ("maybeAppend:result:")]
		void MaybeAppend (string value, NSMutableString result);

		// +(void)maybeAppendArray:(NSArray *)value result:(NSMutableString *)result;
		[Static]
		[Export ("maybeAppendArray:result:")]
		void MaybeAppendArray (NSObject[] value, NSMutableString result);
	}

	// @interface ZXAddressBookParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXAddressBookParsedResult
	{
		// @property (readonly, nonatomic, strong) NSArray * names;
		[Export ("names", ArgumentSemantic.Strong)]
		NSObject[] Names { get; }

		// @property (readonly, nonatomic, strong) NSArray * nicknames;
		[Export ("nicknames", ArgumentSemantic.Strong)]
		NSObject[] Nicknames { get; }

		// @property (readonly, copy, nonatomic) NSString * pronunciation;
		[Export ("pronunciation")]
		string Pronunciation { get; }

		// @property (readonly, nonatomic, strong) NSArray * phoneNumbers;
		[Export ("phoneNumbers", ArgumentSemantic.Strong)]
		NSObject[] PhoneNumbers { get; }

		// @property (readonly, nonatomic, strong) NSArray * phoneTypes;
		[Export ("phoneTypes", ArgumentSemantic.Strong)]
		NSObject[] PhoneTypes { get; }

		// @property (readonly, nonatomic, strong) NSArray * emails;
		[Export ("emails", ArgumentSemantic.Strong)]
		NSObject[] Emails { get; }

		// @property (readonly, nonatomic, strong) NSArray * emailTypes;
		[Export ("emailTypes", ArgumentSemantic.Strong)]
		NSObject[] EmailTypes { get; }

		// @property (readonly, copy, nonatomic) NSString * instantMessenger;
		[Export ("instantMessenger")]
		string InstantMessenger { get; }

		// @property (readonly, copy, nonatomic) NSString * note;
		[Export ("note")]
		string Note { get; }

		// @property (readonly, nonatomic, strong) NSArray * addresses;
		[Export ("addresses", ArgumentSemantic.Strong)]
		NSObject[] Addresses { get; }

		// @property (readonly, nonatomic, strong) NSArray * addressTypes;
		[Export ("addressTypes", ArgumentSemantic.Strong)]
		NSObject[] AddressTypes { get; }

		// @property (readonly, copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, copy, nonatomic) NSString * org;
		[Export ("org")]
		string Org { get; }

		// @property (readonly, nonatomic, strong) NSArray * urls;
		[Export ("urls", ArgumentSemantic.Strong)]
		NSObject[] Urls { get; }

		// @property (readonly, copy, nonatomic) NSString * birthday;
		[Export ("birthday")]
		string Birthday { get; }

		// @property (readonly, nonatomic, strong) NSArray * geo;
		[Export ("geo", ArgumentSemantic.Strong)]
		NSObject[] Geo { get; }

		// -(id)initWithNames:(NSArray *)names phoneNumbers:(NSArray *)phoneNumbers phoneTypes:(NSArray *)phoneTypes emails:(NSArray *)emails emailTypes:(NSArray *)emailTypes addresses:(NSArray *)addresses addressTypes:(NSArray *)addressTypes;
		[Export ("initWithNames:phoneNumbers:phoneTypes:emails:emailTypes:addresses:addressTypes:")]
		IntPtr Constructor (NSObject[] names, NSObject[] phoneNumbers, NSObject[] phoneTypes, NSObject[] emails, NSObject[] emailTypes, NSObject[] addresses, NSObject[] addressTypes);

		// -(id)initWithNames:(NSArray *)names nicknames:(NSArray *)nicknames pronunciation:(NSString *)pronunciation phoneNumbers:(NSArray *)phoneNumbers phoneTypes:(NSArray *)phoneTypes emails:(NSArray *)emails emailTypes:(NSArray *)emailTypes instantMessenger:(NSString *)instantMessenger note:(NSString *)note addresses:(NSArray *)addresses addressTypes:(NSArray *)addressTypes org:(NSString *)org birthday:(NSString *)birthday title:(NSString *)title urls:(NSArray *)urls geo:(NSArray *)geo;
		[Export ("initWithNames:nicknames:pronunciation:phoneNumbers:phoneTypes:emails:emailTypes:instantMessenger:note:addresses:addressTypes:org:birthday:title:urls:geo:")]
		IntPtr Constructor (NSObject[] names, NSObject[] nicknames, string pronunciation, NSObject[] phoneNumbers, NSObject[] phoneTypes, NSObject[] emails, NSObject[] emailTypes, string instantMessenger, string note, NSObject[] addresses, NSObject[] addressTypes, string org, string birthday, string title, NSObject[] urls, NSObject[] geo);

		// +(id)addressBookParsedResultWithNames:(NSArray *)names phoneNumbers:(NSArray *)phoneNumbers phoneTypes:(NSArray *)phoneTypes emails:(NSArray *)emails emailTypes:(NSArray *)emailTypes addresses:(NSArray *)addresses addressTypes:(NSArray *)addressTypes;
		[Static]
		[Export ("addressBookParsedResultWithNames:phoneNumbers:phoneTypes:emails:emailTypes:addresses:addressTypes:")]
		NSObject AddressBookParsedResultWithNames (NSObject[] names, NSObject[] phoneNumbers, NSObject[] phoneTypes, NSObject[] emails, NSObject[] emailTypes, NSObject[] addresses, NSObject[] addressTypes);

		// +(id)addressBookParsedResultWithNames:(NSArray *)names nicknames:(NSArray *)nicknames pronunciation:(NSString *)pronunciation phoneNumbers:(NSArray *)phoneNumbers phoneTypes:(NSArray *)phoneTypes emails:(NSArray *)emails emailTypes:(NSArray *)emailTypes instantMessenger:(NSString *)instantMessenger note:(NSString *)note addresses:(NSArray *)addresses addressTypes:(NSArray *)addressTypes org:(NSString *)org birthday:(NSString *)birthday title:(NSString *)title urls:(NSArray *)urls geo:(NSArray *)geo;
		[Static]
		[Export ("addressBookParsedResultWithNames:nicknames:pronunciation:phoneNumbers:phoneTypes:emails:emailTypes:instantMessenger:note:addresses:addressTypes:org:birthday:title:urls:geo:")]
		NSObject AddressBookParsedResultWithNames (NSObject[] names, NSObject[] nicknames, string pronunciation, NSObject[] phoneNumbers, NSObject[] phoneTypes, NSObject[] emails, NSObject[] emailTypes, string instantMessenger, string note, NSObject[] addresses, NSObject[] addressTypes, string org, string birthday, string title, NSObject[] urls, NSObject[] geo);
	}

	// @interface ZXBizcardResultParser : ZXAbstractDoCoMoResultParser
	[BaseType (typeof(ZXAbstractDoCoMoResultParser))]
	interface ZXBizcardResultParser
	{
	}

	// @interface ZXBookmarkDoCoMoResultParser : ZXAbstractDoCoMoResultParser
	[BaseType (typeof(ZXAbstractDoCoMoResultParser))]
	interface ZXBookmarkDoCoMoResultParser
	{
	}

	// @interface ZXCalendarParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXCalendarParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * summary;
		[Export ("summary")]
		string Summary { get; }

		// @property (readonly, nonatomic, strong) NSDate * start;
		[Export ("start", ArgumentSemantic.Strong)]
		NSDate Start { get; }

		// @property (readonly, assign, nonatomic) BOOL startAllDay;
		[Export ("startAllDay")]
		bool StartAllDay { get; }

		// @property (readonly, nonatomic, strong) NSDate * end;
		[Export ("end", ArgumentSemantic.Strong)]
		NSDate End { get; }

		// @property (readonly, assign, nonatomic) BOOL endAllDay;
		[Export ("endAllDay")]
		bool EndAllDay { get; }

		// @property (readonly, copy, nonatomic) NSString * location;
		[Export ("location")]
		string Location { get; }

		// @property (readonly, copy, nonatomic) NSString * organizer;
		[Export ("organizer")]
		string Organizer { get; }

		// @property (readonly, nonatomic, strong) NSArray * attendees;
		[Export ("attendees", ArgumentSemantic.Strong)]
		NSObject[] Attendees { get; }

		// @property (readonly, copy, nonatomic) NSString * resultDescription;
		[Export ("resultDescription")]
		string ResultDescription { get; }

		// @property (readonly, assign, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, assign, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }

		// -(id)initWithSummary:(NSString *)summary startString:(NSString *)startString endString:(NSString *)endString durationString:(NSString *)durationString location:(NSString *)location organizer:(NSString *)organizer attendees:(NSArray *)attendees description:(NSString *)description latitude:(double)latitude longitude:(double)longitude;
		[Export ("initWithSummary:startString:endString:durationString:location:organizer:attendees:description:latitude:longitude:")]
		IntPtr Constructor (string summary, string startString, string endString, string durationString, string location, string organizer, NSObject[] attendees, string description, double latitude, double longitude);

		// +(id)calendarParsedResultWithSummary:(NSString *)summary startString:(NSString *)startString endString:(NSString *)endString durationString:(NSString *)durationString location:(NSString *)location organizer:(NSString *)organizer attendees:(NSArray *)attendees description:(NSString *)description latitude:(double)latitude longitude:(double)longitude;
		[Static]
		[Export ("calendarParsedResultWithSummary:startString:endString:durationString:location:organizer:attendees:description:latitude:longitude:")]
		NSObject CalendarParsedResultWithSummary (string summary, string startString, string endString, string durationString, string location, string organizer, NSObject[] attendees, string description, double latitude, double longitude);
	}

	// @interface ZXEmailAddressParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXEmailAddressParsedResult
	{
		// @property (readonly, copy, nonatomic) NSArray * tos;
		[Export ("tos", ArgumentSemantic.Copy)]
		NSObject[] Tos { get; }

		// @property (readonly, copy, nonatomic) NSArray * ccs;
		[Export ("ccs", ArgumentSemantic.Copy)]
		NSObject[] Ccs { get; }

		// @property (readonly, copy, nonatomic) NSArray * bccs;
		[Export ("bccs", ArgumentSemantic.Copy)]
		NSObject[] Bccs { get; }

		// @property (readonly, copy, nonatomic) NSString * subject;
		[Export ("subject")]
		string Subject { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[Export ("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSString * emailAddress __attribute__((deprecated("")));
		[Export ("emailAddress")]
		string EmailAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * mailtoURI __attribute__((deprecated("")));
		[Export ("mailtoURI")]
		string MailtoURI { get; }

		// -(id)initWithTo:(NSString *)to;
		[Export ("initWithTo:")]
		IntPtr Constructor (string to);

		// -(id)initWithTos:(NSArray *)tos ccs:(NSArray *)ccs bccs:(NSArray *)bccs subject:(NSString *)subject body:(NSString *)body;
		[Export ("initWithTos:ccs:bccs:subject:body:")]
		IntPtr Constructor (NSObject[] tos, NSObject[] ccs, NSObject[] bccs, string subject, string body);
	}

	// @interface ZXEmailAddressResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXEmailAddressResultParser
	{
	}

	// @interface ZXEmailDoCoMoResultParser : ZXAbstractDoCoMoResultParser
	[BaseType (typeof(ZXAbstractDoCoMoResultParser))]
	interface ZXEmailDoCoMoResultParser
	{
		// +(BOOL)isBasicallyValidEmailAddress:(NSString *)email;
		[Static]
		[Export ("isBasicallyValidEmailAddress:")]
		bool IsBasicallyValidEmailAddress (string email);
	}

	// @interface ZXExpandedProductParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXExpandedProductParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * rawText;
		[Export ("rawText")]
		string RawText { get; }

		// @property (readonly, copy, nonatomic) NSString * productID;
		[Export ("productID")]
		string ProductID { get; }

		// @property (readonly, copy, nonatomic) NSString * sscc;
		[Export ("sscc")]
		string Sscc { get; }

		// @property (readonly, copy, nonatomic) NSString * lotNumber;
		[Export ("lotNumber")]
		string LotNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * productionDate;
		[Export ("productionDate")]
		string ProductionDate { get; }

		// @property (readonly, copy, nonatomic) NSString * packagingDate;
		[Export ("packagingDate")]
		string PackagingDate { get; }

		// @property (readonly, copy, nonatomic) NSString * bestBeforeDate;
		[Export ("bestBeforeDate")]
		string BestBeforeDate { get; }

		// @property (readonly, copy, nonatomic) NSString * expirationDate;
		[Export ("expirationDate")]
		string ExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NSString * weight;
		[Export ("weight")]
		string Weight { get; }

		// @property (readonly, copy, nonatomic) NSString * weightType;
		[Export ("weightType")]
		string WeightType { get; }

		// @property (readonly, copy, nonatomic) NSString * weightIncrement;
		[Export ("weightIncrement")]
		string WeightIncrement { get; }

		// @property (readonly, copy, nonatomic) NSString * price;
		[Export ("price")]
		string Price { get; }

		// @property (readonly, copy, nonatomic) NSString * priceIncrement;
		[Export ("priceIncrement")]
		string PriceIncrement { get; }

		// @property (readonly, copy, nonatomic) NSString * priceCurrency;
		[Export ("priceCurrency")]
		string PriceCurrency { get; }

		// @property (readonly, nonatomic, strong) NSMutableDictionary * uncommonAIs;
		[Export ("uncommonAIs", ArgumentSemantic.Strong)]
		NSMutableDictionary UncommonAIs { get; }

		// -(id)initWithRawText:(NSString *)rawText productID:(NSString *)productID sscc:(NSString *)sscc lotNumber:(NSString *)lotNumber productionDate:(NSString *)productionDate packagingDate:(NSString *)packagingDate bestBeforeDate:(NSString *)bestBeforeDate expirationDate:(NSString *)expirationDate weight:(NSString *)weight weightType:(NSString *)weightType weightIncrement:(NSString *)weightIncrement price:(NSString *)price priceIncrement:(NSString *)priceIncrement priceCurrency:(NSString *)priceCurrency uncommonAIs:(NSMutableDictionary *)uncommonAIs;
		[Export ("initWithRawText:productID:sscc:lotNumber:productionDate:packagingDate:bestBeforeDate:expirationDate:weight:weightType:weightIncrement:price:priceIncrement:priceCurrency:uncommonAIs:")]
		IntPtr Constructor (string rawText, string productID, string sscc, string lotNumber, string productionDate, string packagingDate, string bestBeforeDate, string expirationDate, string weight, string weightType, string weightIncrement, string price, string priceIncrement, string priceCurrency, NSMutableDictionary uncommonAIs);

		// +(id)expandedProductParsedResultWithRawText:(NSString *)rawText productID:(NSString *)productID sscc:(NSString *)sscc lotNumber:(NSString *)lotNumber productionDate:(NSString *)productionDate packagingDate:(NSString *)packagingDate bestBeforeDate:(NSString *)bestBeforeDate expirationDate:(NSString *)expirationDate weight:(NSString *)weight weightType:(NSString *)weightType weightIncrement:(NSString *)weightIncrement price:(NSString *)price priceIncrement:(NSString *)priceIncrement priceCurrency:(NSString *)priceCurrency uncommonAIs:(NSMutableDictionary *)uncommonAIs;
		[Static]
		[Export ("expandedProductParsedResultWithRawText:productID:sscc:lotNumber:productionDate:packagingDate:bestBeforeDate:expirationDate:weight:weightType:weightIncrement:price:priceIncrement:priceCurrency:uncommonAIs:")]
		NSObject ExpandedProductParsedResultWithRawText (string rawText, string productID, string sscc, string lotNumber, string productionDate, string packagingDate, string bestBeforeDate, string expirationDate, string weight, string weightType, string weightIncrement, string price, string priceIncrement, string priceCurrency, NSMutableDictionary uncommonAIs);
	}

	// @interface ZXExpandedProductResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXExpandedProductResultParser
	{
	}

	// @interface ZXGeoParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXGeoParsedResult
	{
		// @property (readonly, assign, nonatomic) double latitude;
		[Export ("latitude")]
		double Latitude { get; }

		// @property (readonly, assign, nonatomic) double longitude;
		[Export ("longitude")]
		double Longitude { get; }

		// @property (readonly, assign, nonatomic) double altitude;
		[Export ("altitude")]
		double Altitude { get; }

		// @property (readonly, copy, nonatomic) NSString * query;
		[Export ("query")]
		string Query { get; }

		// -(id)initWithLatitude:(double)latitude longitude:(double)longitude altitude:(double)altitude query:(NSString *)query;
		[Export ("initWithLatitude:longitude:altitude:query:")]
		IntPtr Constructor (double latitude, double longitude, double altitude, string query);

		// +(id)geoParsedResultWithLatitude:(double)latitude longitude:(double)longitude altitude:(double)altitude query:(NSString *)query;
		[Static]
		[Export ("geoParsedResultWithLatitude:longitude:altitude:query:")]
		NSObject GeoParsedResultWithLatitude (double latitude, double longitude, double altitude, string query);

		// -(NSString *)geoURI;
		[Export ("geoURI")]
		string GeoURI { get; }
	}

	// @interface ZXGeoResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXGeoResultParser
	{
	}

	// @interface ZXISBNParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXISBNParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * isbn;
		[Export ("isbn")]
		string Isbn { get; }

		// -(id)initWithIsbn:(NSString *)isbn;
		[Export ("initWithIsbn:")]
		IntPtr Constructor (string isbn);

		// +(id)isbnParsedResultWithIsbn:(NSString *)isbn;
		[Static]
		[Export ("isbnParsedResultWithIsbn:")]
		NSObject IsbnParsedResultWithIsbn (string isbn);
	}

	// @interface ZXISBNResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXISBNResultParser
	{
	}

	// @interface ZXProductParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXProductParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * normalizedProductID;
		[Export ("normalizedProductID")]
		string NormalizedProductID { get; }

		// @property (readonly, copy, nonatomic) NSString * productID;
		[Export ("productID")]
		string ProductID { get; }

		// -(id)initWithProductID:(NSString *)productID;
		[Export ("initWithProductID:")]
		IntPtr Constructor (string productID);

		// -(id)initWithProductID:(NSString *)productID normalizedProductID:(NSString *)normalizedProductID;
		[Export ("initWithProductID:normalizedProductID:")]
		IntPtr Constructor (string productID, string normalizedProductID);

		// +(id)productParsedResultWithProductID:(NSString *)productID;
		[Static]
		[Export ("productParsedResultWithProductID:")]
		NSObject ProductParsedResultWithProductID (string productID);

		// +(id)productParsedResultWithProductID:(NSString *)productID normalizedProductID:(NSString *)normalizedProductID;
		[Static]
		[Export ("productParsedResultWithProductID:normalizedProductID:")]
		NSObject ProductParsedResultWithProductID (string productID, string normalizedProductID);
	}

	// @interface ZXProductResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXProductResultParser
	{
	}

	// @interface ZXSMSMMSResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXSMSMMSResultParser
	{
	}

	// @interface ZXSMSParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXSMSParsedResult
	{
		// @property (readonly, nonatomic, strong) NSArray * numbers;
		[Export ("numbers", ArgumentSemantic.Strong)]
		NSObject[] Numbers { get; }

		// @property (readonly, nonatomic, strong) NSArray * vias;
		[Export ("vias", ArgumentSemantic.Strong)]
		NSObject[] Vias { get; }

		// @property (readonly, copy, nonatomic) NSString * subject;
		[Export ("subject")]
		string Subject { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[Export ("body")]
		string Body { get; }

		// -(id)initWithNumber:(NSString *)number via:(NSString *)via subject:(NSString *)subject body:(NSString *)body;
		[Export ("initWithNumber:via:subject:body:")]
		IntPtr Constructor (string number, string via, string subject, string body);

		// -(id)initWithNumbers:(NSArray *)numbers vias:(NSArray *)vias subject:(NSString *)subject body:(NSString *)body;
		[Export ("initWithNumbers:vias:subject:body:")]
		IntPtr Constructor (NSObject[] numbers, NSObject[] vias, string subject, string body);

		// +(id)smsParsedResultWithNumber:(NSString *)number via:(NSString *)via subject:(NSString *)subject body:(NSString *)body;
		[Static]
		[Export ("smsParsedResultWithNumber:via:subject:body:")]
		NSObject SmsParsedResultWithNumber (string number, string via, string subject, string body);

		// +(id)smsParsedResultWithNumbers:(NSArray *)numbers vias:(NSArray *)vias subject:(NSString *)subject body:(NSString *)body;
		[Static]
		[Export ("smsParsedResultWithNumbers:vias:subject:body:")]
		NSObject SmsParsedResultWithNumbers (NSObject[] numbers, NSObject[] vias, string subject, string body);

		// -(NSString *)sMSURI;
		[Export ("sMSURI")]
		string SMSURI { get; }
	}

	// @interface ZXSMSTOMMSTOResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXSMSTOMMSTOResultParser
	{
	}

	// @interface ZXSMTPResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXSMTPResultParser
	{
	}

	// @interface ZXTelParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXTelParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * number;
		[Export ("number")]
		string Number { get; }

		// @property (readonly, copy, nonatomic) NSString * telURI;
		[Export ("telURI")]
		string TelURI { get; }

		// @property (readonly, copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// -(id)initWithNumber:(NSString *)number telURI:(NSString *)telURI title:(NSString *)title;
		[Export ("initWithNumber:telURI:title:")]
		IntPtr Constructor (string number, string telURI, string title);

		// +(id)telParsedResultWithNumber:(NSString *)number telURI:(NSString *)telURI title:(NSString *)title;
		[Static]
		[Export ("telParsedResultWithNumber:telURI:title:")]
		NSObject TelParsedResultWithNumber (string number, string telURI, string title);
	}

	// @interface ZXTelResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXTelResultParser
	{
	}

	// @interface ZXTextParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXTextParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; }

		// @property (readonly, copy, nonatomic) NSString * language;
		[Export ("language")]
		string Language { get; }

		// -(id)initWithText:(NSString *)text language:(NSString *)language;
		[Export ("initWithText:language:")]
		IntPtr Constructor (string text, string language);

		// +(id)textParsedResultWithText:(NSString *)text language:(NSString *)language;
		[Static]
		[Export ("textParsedResultWithText:language:")]
		NSObject TextParsedResultWithText (string text, string language);
	}

	// @interface ZXURIParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXURIParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * uri;
		[Export ("uri")]
		string Uri { get; }

		// @property (readonly, copy, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// -(id)initWithUri:(NSString *)uri title:(NSString *)title;
		[Export ("initWithUri:title:")]
		IntPtr Constructor (string uri, string title);

		// +(id)uriParsedResultWithUri:(NSString *)uri title:(NSString *)title;
		[Static]
		[Export ("uriParsedResultWithUri:title:")]
		NSObject UriParsedResultWithUri (string uri, string title);

		// -(BOOL)possiblyMaliciousURI;
		[Export ("possiblyMaliciousURI")]
		bool PossiblyMaliciousURI { get; }
	}

	// @interface ZXURIResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXURIResultParser
	{
		// +(BOOL)isBasicallyValidURI:(NSString *)uri;
		[Static]
		[Export ("isBasicallyValidURI:")]
		bool IsBasicallyValidURI (string uri);
	}

	// @interface ZXURLTOResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXURLTOResultParser
	{
	}

	// @interface ZXVCardResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXVCardResultParser
	{
		// +(NSArray *)matchSingleVCardPrefixedField:(NSString *)prefix rawText:(NSString *)rawText trim:(BOOL)trim parseFieldDivider:(BOOL)parseFieldDivider;
		[Static]
		[Export ("matchSingleVCardPrefixedField:rawText:trim:parseFieldDivider:")]
		NSObject[] MatchSingleVCardPrefixedField (string prefix, string rawText, bool trim, bool parseFieldDivider);

		// +(NSMutableArray *)matchVCardPrefixedField:(NSString *)prefix rawText:(NSString *)rawText trim:(BOOL)trim parseFieldDivider:(BOOL)parseFieldDivider;
		[Static]
		[Export ("matchVCardPrefixedField:rawText:trim:parseFieldDivider:")]
		NSMutableArray MatchVCardPrefixedField (string prefix, string rawText, bool trim, bool parseFieldDivider);
	}

	// @interface ZXVEventResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXVEventResultParser
	{
	}

	// @interface ZXVINParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXVINParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * vin;
		[Export ("vin")]
		string Vin { get; }

		// @property (readonly, copy, nonatomic) NSString * worldManufacturerID;
		[Export ("worldManufacturerID")]
		string WorldManufacturerID { get; }

		// @property (readonly, copy, nonatomic) NSString * vehicleDescriptorSection;
		[Export ("vehicleDescriptorSection")]
		string VehicleDescriptorSection { get; }

		// @property (readonly, copy, nonatomic) NSString * vehicleIdentifierSection;
		[Export ("vehicleIdentifierSection")]
		string VehicleIdentifierSection { get; }

		// @property (readonly, copy, nonatomic) NSString * countryCode;
		[Export ("countryCode")]
		string CountryCode { get; }

		// @property (readonly, copy, nonatomic) NSString * vehicleAttributes;
		[Export ("vehicleAttributes")]
		string VehicleAttributes { get; }

		// @property (readonly, assign, nonatomic) int modelYear;
		[Export ("modelYear")]
		int ModelYear { get; }

		// @property (readonly, assign, nonatomic) unichar plantCode;
		[Export ("plantCode")]
		ushort PlantCode { get; }

		// @property (readonly, copy, nonatomic) NSString * sequentialNumber;
		[Export ("sequentialNumber")]
		string SequentialNumber { get; }

		// -(id)initWithVIN:(NSString *)vin worldManufacturerID:(NSString *)worldManufacturerID vehicleDescriptorSection:(NSString *)vehicleDescriptorSection vehicleIdentifierSection:(NSString *)vehicleIdentifierSection countryCode:(NSString *)countryCode vehicleAttributes:(NSString *)vehicleAttributes modelYear:(int)modelYear plantCode:(unichar)plantCode sequentialNumber:(NSString *)sequentialNumber;
		[Export ("initWithVIN:worldManufacturerID:vehicleDescriptorSection:vehicleIdentifierSection:countryCode:vehicleAttributes:modelYear:plantCode:sequentialNumber:")]
		IntPtr Constructor (string vin, string worldManufacturerID, string vehicleDescriptorSection, string vehicleIdentifierSection, string countryCode, string vehicleAttributes, int modelYear, ushort plantCode, string sequentialNumber);
	}

	// @interface ZXVINResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXVINResultParser
	{
	}

	// @interface ZXWifiParsedResult : ZXParsedResult
	[BaseType (typeof(ZXParsedResult))]
	interface ZXWifiParsedResult
	{
		// @property (readonly, copy, nonatomic) NSString * ssid;
		[Export ("ssid")]
		string Ssid { get; }

		// @property (readonly, copy, nonatomic) NSString * networkEncryption;
		[Export ("networkEncryption")]
		string NetworkEncryption { get; }

		// @property (readonly, copy, nonatomic) NSString * password;
		[Export ("password")]
		string Password { get; }

		// @property (readonly, assign, nonatomic) BOOL hidden;
		[Export ("hidden")]
		bool Hidden { get; }

		// -(id)initWithNetworkEncryption:(NSString *)networkEncryption ssid:(NSString *)ssid password:(NSString *)password;
		[Export ("initWithNetworkEncryption:ssid:password:")]
		IntPtr Constructor (string networkEncryption, string ssid, string password);

		// -(id)initWithNetworkEncryption:(NSString *)networkEncryption ssid:(NSString *)ssid password:(NSString *)password hidden:(BOOL)hidden;
		[Export ("initWithNetworkEncryption:ssid:password:hidden:")]
		IntPtr Constructor (string networkEncryption, string ssid, string password, bool hidden);

		// +(id)wifiParsedResultWithNetworkEncryption:(NSString *)networkEncryption ssid:(NSString *)ssid password:(NSString *)password;
		[Static]
		[Export ("wifiParsedResultWithNetworkEncryption:ssid:password:")]
		NSObject WifiParsedResultWithNetworkEncryption (string networkEncryption, string ssid, string password);

		// +(id)wifiParsedResultWithNetworkEncryption:(NSString *)networkEncryption ssid:(NSString *)ssid password:(NSString *)password hidden:(BOOL)hidden;
		[Static]
		[Export ("wifiParsedResultWithNetworkEncryption:ssid:password:hidden:")]
		NSObject WifiParsedResultWithNetworkEncryption (string networkEncryption, string ssid, string password, bool hidden);
	}

	// @interface ZXWifiResultParser : ZXResultParser
	[BaseType (typeof(ZXResultParser))]
	interface ZXWifiResultParser
	{
	}

    [BaseType(typeof(NSObject))]
    interface ZXModulusPoly
    {
        
    }

	// @interface ZXModulusGF : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXModulusGF
	{
		// @property (readonly, nonatomic, strong) ZXModulusPoly * one;
		[Export ("one", ArgumentSemantic.Strong)]
		ZXModulusPoly One { get; }

		// @property (readonly, nonatomic, strong) ZXModulusPoly * zero;
		[Export ("zero", ArgumentSemantic.Strong)]
		ZXModulusPoly Zero { get; }

		// +(ZXModulusGF *)PDF417_GF;
		[Static]
		[Export ("PDF417_GF")]
		ZXModulusGF PDF417_GF { get; }

		// -(id)initWithModulus:(int)modulus generator:(int)generator;
		[Export ("initWithModulus:generator:")]
		IntPtr Constructor (int modulus, int generator);

		// -(ZXModulusPoly *)buildMonomial:(int)degree coefficient:(int)coefficient;
		[Export ("buildMonomial:coefficient:")]
		ZXModulusPoly BuildMonomial (int degree, int coefficient);

		// -(int)add:(int)a b:(int)b;
		[Export ("add:b:")]
		int Add (int a, int b);

		// -(int)subtract:(int)a b:(int)b;
		[Export ("subtract:b:")]
		int Subtract (int a, int b);

		// -(int)exp:(int)a;
		[Export ("exp:")]
		int Exp (int a);

		// -(int)log:(int)a;
		[Export ("log:")]
		int Log (int a);

		// -(int)inverse:(int)a;
		[Export ("inverse:")]
		int Inverse (int a);

		// -(int)multiply:(int)a b:(int)b;
		[Export ("multiply:b:")]
		int Multiply (int a, int b);

		// -(int)size;
		[Export ("size")]
		int Size { get; }
	}

	// @interface ZXPDF417 : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417
	{
		// @property (readonly, nonatomic, strong) ZXPDF417BarcodeMatrix * barcodeMatrix;
		[Export ("barcodeMatrix", ArgumentSemantic.Strong)]
		ZXPDF417BarcodeMatrix BarcodeMatrix { get; }

		// @property (assign, nonatomic) BOOL compact;
		[Export ("compact")]
		bool Compact { get; set; }

		// @property (assign, nonatomic) ZXPDF417Compaction compaction;
		[Export ("compaction", ArgumentSemantic.Assign)]
		ZXPDF417Compaction Compaction { get; set; }

		// @property (assign, nonatomic) NSStringEncoding encoding;
		[Export ("encoding")]
		nuint Encoding { get; set; }

		// -(id)initWithCompact:(BOOL)compact;
		[Export ("initWithCompact:")]
		IntPtr Constructor (bool compact);

		// -(BOOL)generateBarcodeLogic:(NSString *)msg errorCorrectionLevel:(int)errorCorrectionLevel error:(NSError **)error;
		[Export ("generateBarcodeLogic:errorCorrectionLevel:error:")]
		bool GenerateBarcodeLogic (string msg, int errorCorrectionLevel, out NSError error);

		// -(ZXIntArray *)determineDimensions:(int)sourceCodeWords errorCorrectionCodeWords:(int)errorCorrectionCodeWords error:(NSError **)error;
		[Export ("determineDimensions:errorCorrectionCodeWords:error:")]
		ZXIntArray DetermineDimensions (int sourceCodeWords, int errorCorrectionCodeWords, out NSError error);

		// -(void)setDimensionsWithMaxCols:(int)maxCols minCols:(int)minCols maxRows:(int)maxRows minRows:(int)minRows;
		[Export ("setDimensionsWithMaxCols:minCols:maxRows:minRows:")]
		void SetDimensionsWithMaxCols (int maxCols, int minCols, int maxRows, int minRows);
	}

    [BaseType(typeof(NSObject))]
    interface ZXPDF417BarcodeRow
    {
        
    }

	// @interface ZXPDF417BarcodeMatrix : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417BarcodeMatrix
	{
		// @property (readonly, assign, nonatomic) int height;
		[Export ("height")]
		int Height { get; }

		// @property (readonly, assign, nonatomic) int width;
		[Export ("width")]
		int Width { get; }

		// -(id)initWithHeight:(int)height width:(int)width;
		[Export ("initWithHeight:width:")]
		IntPtr Constructor (int height, int width);

		// -(void)startRow;
		[Export ("startRow")]
		void StartRow ();

		// -(ZXPDF417BarcodeRow *)currentRow;
		[Export ("currentRow")]
		ZXPDF417BarcodeRow CurrentRow { get; }

		// -(NSArray *)matrix;
		[Export ("matrix")]
		NSObject[] Matrix { get; }

		// -(NSArray *)scaledMatrixWithXScale:(int)xScale yScale:(int)yScale;
		[Export ("scaledMatrixWithXScale:yScale:")]
		NSObject[] ScaledMatrixWithXScale (int xScale, int yScale);
	}

	// @interface ZXPDF417Common : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417Common
	{
		// +(int)bitCountSum:(NSArray *)moduleBitCount;
		[Static]
		[Export ("bitCountSum:")]
		int BitCountSum (NSObject[] moduleBitCount);

		// +(ZXIntArray *)toIntArray:(NSArray *)list;
		[Static]
		[Export ("toIntArray:")]
		ZXIntArray ToIntArray (NSObject[] list);

		// +(int)codeword:(int)symbol;
		[Static]
		[Export ("codeword:")]
		int Codeword (int symbol);
	}

	// @interface ZXPDF417Detector : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417Detector
	{
		// +(ZXPDF417DetectorResult *)detect:(ZXBinaryBitmap *)image hints:(ZXDecodeHints *)hints multiple:(BOOL)multiple error:(NSError **)error;
		[Static]
		[Export ("detect:hints:multiple:error:")]
		ZXPDF417DetectorResult Detect (ZXBinaryBitmap image, ZXDecodeHints hints, bool multiple, out NSError error);
	}

	// @interface ZXPDF417DetectorResult : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417DetectorResult
	{
		// @property (readonly, nonatomic, strong) ZXBitMatrix * bits;
		[Export ("bits", ArgumentSemantic.Strong)]
		ZXBitMatrix Bits { get; }

		// @property (readonly, nonatomic, strong) NSArray * points;
		[Export ("points", ArgumentSemantic.Strong)]
		NSObject[] Points { get; }

		// -(id)initWithBits:(ZXBitMatrix *)bits points:(NSArray *)points;
		[Export ("initWithBits:points:")]
		IntPtr Constructor (ZXBitMatrix bits, NSObject[] points);
	}

	// @interface ZXPDF417Dimensions : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417Dimensions
	{
		// @property (readonly, assign, nonatomic) int minCols;
		[Export ("minCols")]
		int MinCols { get; }

		// @property (readonly, assign, nonatomic) int maxCols;
		[Export ("maxCols")]
		int MaxCols { get; }

		// @property (readonly, assign, nonatomic) int minRows;
		[Export ("minRows")]
		int MinRows { get; }

		// @property (readonly, assign, nonatomic) int maxRows;
		[Export ("maxRows")]
		int MaxRows { get; }

		// -(id)initWithMinCols:(int)minCols maxCols:(int)maxCols minRows:(int)minRows maxRows:(int)maxRows;
		[Export ("initWithMinCols:maxCols:minRows:maxRows:")]
		IntPtr Constructor (int minCols, int maxCols, int minRows, int maxRows);
	}

	// @interface ZXPDF417ECErrorCorrection : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417ECErrorCorrection
	{
		// -(int)decode:(ZXIntArray *)received numECCodewords:(int)numECCodewords erasures:(ZXIntArray *)erasures;
		[Export ("decode:numECCodewords:erasures:")]
		int Decode (ZXIntArray received, int numECCodewords, ZXIntArray erasures);
	}

	// @interface ZXPDF417Reader : NSObject <ZXReader, ZXMultipleBarcodeReader>
	[BaseType (typeof(NSObject))]
	interface ZXPDF417Reader : ZXReader, IZXMultipleBarcodeReader
	{
		// -(NSArray *)decodeMultiple:(ZXBinaryBitmap *)image error:(NSError **)error;
		[Export ("decodeMultiple:error:")]
		NSObject[] DecodeMultiple (ZXBinaryBitmap image, out NSError error);

		// -(NSArray *)decodeMultiple:(ZXBinaryBitmap *)image hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("decodeMultiple:hints:error:")]
		NSObject[] DecodeMultiple (ZXBinaryBitmap image, ZXDecodeHints hints, out NSError error);
	}

	// @interface ZXPDF417ResultMetadata : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417ResultMetadata
	{
		// @property (assign, nonatomic) int segmentIndex;
		[Export ("segmentIndex")]
		int SegmentIndex { get; set; }

		// @property (copy, nonatomic) NSString * fileId;
		[Export ("fileId")]
		string FileId { get; set; }

		// @property (nonatomic, strong) NSArray * optionalData;
		[Export ("optionalData", ArgumentSemantic.Strong)]
		NSObject[] OptionalData { get; set; }

		// @property (assign, nonatomic) BOOL lastSegment;
		[Export ("lastSegment")]
		bool LastSegment { get; set; }
	}

	// @interface ZXPDF417ScanningDecoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXPDF417ScanningDecoder
	{
		// +(ZXDecoderResult *)decode:(ZXBitMatrix *)image imageTopLeft:(ZXResultPoint *)imageTopLeft imageBottomLeft:(ZXResultPoint *)imageBottomLeft imageTopRight:(ZXResultPoint *)imageTopRight imageBottomRight:(ZXResultPoint *)imageBottomRight minCodewordWidth:(int)minCodewordWidth maxCodewordWidth:(int)maxCodewordWidth error:(NSError **)error;
		[Static]
		[Export ("decode:imageTopLeft:imageBottomLeft:imageTopRight:imageBottomRight:minCodewordWidth:maxCodewordWidth:error:")]
		ZXDecoderResult Decode (ZXBitMatrix image, ZXResultPoint imageTopLeft, ZXResultPoint imageBottomLeft, ZXResultPoint imageTopRight, ZXResultPoint imageBottomRight, int minCodewordWidth, int maxCodewordWidth, out NSError error);

		// -(NSString *)description:(NSArray *)barcodeMatrix;
		[Export ("description:")]
		string Description (NSObject[] barcodeMatrix);
	}

	// @interface ZXPDF417Writer : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXPDF417Writer : ZXWriter
	{
	}

	// @interface ZXQRCodeDetector : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeDetector
	{
		// @property (readonly, nonatomic, strong) ZXBitMatrix * image;
		[Export ("image", ArgumentSemantic.Strong)]
		ZXBitMatrix Image { get; }

		// @property (readonly, nonatomic, weak) id<ZXResultPointCallback> resultPointCallback;
		[Export ("resultPointCallback", ArgumentSemantic.Weak)]
		ZXResultPointCallback ResultPointCallback { get; }

		// -(id)initWithImage:(ZXBitMatrix *)image;
		[Export ("initWithImage:")]
		IntPtr Constructor (ZXBitMatrix image);

		// -(ZXDetectorResult *)detectWithError:(NSError **)error;
		[Export ("detectWithError:")]
		ZXDetectorResult DetectWithError (out NSError error);

		// -(ZXDetectorResult *)detect:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("detect:error:")]
		ZXDetectorResult Detect (ZXDecodeHints hints, out NSError error);

		// -(ZXDetectorResult *)processFinderPatternInfo:(ZXQRCodeFinderPatternInfo *)info error:(NSError **)error;
		[Export ("processFinderPatternInfo:error:")]
		ZXDetectorResult ProcessFinderPatternInfo (ZXQRCodeFinderPatternInfo info, out NSError error);

		// -(float)calculateModuleSize:(ZXResultPoint *)topLeft topRight:(ZXResultPoint *)topRight bottomLeft:(ZXResultPoint *)bottomLeft;
		[Export ("calculateModuleSize:topRight:bottomLeft:")]
		float CalculateModuleSize (ZXResultPoint topLeft, ZXResultPoint topRight, ZXResultPoint bottomLeft);

		// -(ZXQRCodeAlignmentPattern *)findAlignmentInRegion:(float)overallEstModuleSize estAlignmentX:(int)estAlignmentX estAlignmentY:(int)estAlignmentY allowanceFactor:(float)allowanceFactor error:(NSError **)error;
		[Export ("findAlignmentInRegion:estAlignmentX:estAlignmentY:allowanceFactor:error:")]
		ZXQRCodeAlignmentPattern FindAlignmentInRegion (float overallEstModuleSize, int estAlignmentX, int estAlignmentY, float allowanceFactor, out NSError error);
	}

	// @interface ZXMultiDetector : ZXQRCodeDetector
	[BaseType (typeof(ZXQRCodeDetector))]
	interface ZXMultiDetector
	{
		// -(NSArray *)detectMulti:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("detectMulti:error:")]
		NSObject[] DetectMulti (ZXDecodeHints hints, out NSError error);
	}

	// @interface ZXQRCode : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCode
	{
		// @property (nonatomic, strong) ZXQRCodeMode * mode;
		[Export ("mode", ArgumentSemantic.Strong)]
		ZXQRCodeMode Mode { get; set; }

		// @property (nonatomic, strong) ZXQRCodeErrorCorrectionLevel * ecLevel;
		[Export ("ecLevel", ArgumentSemantic.Strong)]
		ZXQRCodeErrorCorrectionLevel EcLevel { get; set; }

		// @property (nonatomic, strong) ZXQRCodeVersion * version;
		[Export ("version", ArgumentSemantic.Strong)]
		ZXQRCodeVersion Version { get; set; }

		// @property (assign, nonatomic) int maskPattern;
		[Export ("maskPattern")]
		int MaskPattern { get; set; }

		// @property (nonatomic, strong) ZXByteMatrix * matrix;
		[Export ("matrix", ArgumentSemantic.Strong)]
		ZXByteMatrix Matrix { get; set; }

		// +(BOOL)isValidMaskPattern:(int)maskPattern;
		[Static]
		[Export ("isValidMaskPattern:")]
		bool IsValidMaskPattern (int maskPattern);
	}

	// @interface ZXQRCodeAlignmentPattern : ZXResultPoint
	[BaseType (typeof(ZXResultPoint))]
	interface ZXQRCodeAlignmentPattern
	{
		// -(id)initWithPosX:(float)posX posY:(float)posY estimatedModuleSize:(float)estimatedModuleSize;
		[Export ("initWithPosX:posY:estimatedModuleSize:")]
		IntPtr Constructor (float posX, float posY, float estimatedModuleSize);

		// -(BOOL)aboutEquals:(float)moduleSize i:(float)i j:(float)j;
		[Export ("aboutEquals:i:j:")]
		bool AboutEquals (float moduleSize, float i, float j);

		// -(ZXQRCodeAlignmentPattern *)combineEstimateI:(float)i j:(float)j newModuleSize:(float)newModuleSize;
		[Export ("combineEstimateI:j:newModuleSize:")]
		ZXQRCodeAlignmentPattern CombineEstimateI (float i, float j, float newModuleSize);
	}

	// @interface ZXQRCodeDecoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeDecoder
	{
		// -(ZXDecoderResult *)decode:(NSArray *)image error:(NSError **)error;
		[Export ("decode:error:")]
		ZXDecoderResult Decode (NSObject[] image, out NSError error);

		// -(ZXDecoderResult *)decode:(NSArray *)image hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("decode:hints:error:")]
		ZXDecoderResult Decode (NSObject[] image, ZXDecodeHints hints, out NSError error);

		// -(ZXDecoderResult *)decodeMatrix:(ZXBitMatrix *)bits error:(NSError **)error;
		[Export ("decodeMatrix:error:")]
		ZXDecoderResult DecodeMatrix (ZXBitMatrix bits, out NSError error);

		// -(ZXDecoderResult *)decodeMatrix:(ZXBitMatrix *)bits hints:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("decodeMatrix:hints:error:")]
		ZXDecoderResult DecodeMatrix (ZXBitMatrix bits, ZXDecodeHints hints, out NSError error);
	}

	// @interface ZXQRCodeDecoderMetaData : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeDecoderMetaData
	{
		// @property (readonly, assign, nonatomic) BOOL mirrored;
		[Export ("mirrored")]
		bool Mirrored { get; }

		// -(id)initWithMirrored:(BOOL)mirrored;
		[Export ("initWithMirrored:")]
		IntPtr Constructor (bool mirrored);

		// -(void)applyMirroredCorrection:(NSMutableArray *)points;
		[Export ("applyMirroredCorrection:")]
		void ApplyMirroredCorrection (NSMutableArray points);
	}

	// @interface ZXQRCodeEncoder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeEncoder
	{
		// +(ZXQRCode *)encode:(NSString *)content ecLevel:(ZXQRCodeErrorCorrectionLevel *)ecLevel error:(NSError **)error;
		[Static]
		[Export ("encode:ecLevel:error:")]
		ZXQRCode Encode (string content, ZXQRCodeErrorCorrectionLevel ecLevel, out NSError error);

		// +(ZXQRCode *)encode:(NSString *)content ecLevel:(ZXQRCodeErrorCorrectionLevel *)ecLevel hints:(ZXEncodeHints *)hints error:(NSError **)error;
		[Static]
		[Export ("encode:ecLevel:hints:error:")]
		ZXQRCode Encode (string content, ZXQRCodeErrorCorrectionLevel ecLevel, ZXEncodeHints hints, out NSError error);

		// +(int)alphanumericCode:(int)code;
		[Static]
		[Export ("alphanumericCode:")]
		int AlphanumericCode (int code);

		// +(BOOL)terminateBits:(int)numDataBytes bits:(ZXBitArray *)bits error:(NSError **)error;
		[Static]
		[Export ("terminateBits:bits:error:")]
		bool TerminateBits (int numDataBytes, ZXBitArray bits, out NSError error);

		//// +(BOOL)numDataBytesAndNumECBytesForBlockID:(int)numTotalBytes numDataBytes:(int)numDataBytes numRSBlocks:(int)numRSBlocks blockID:(int)blockID numDataBytesInBlock:(int *)numDataBytesInBlock numECBytesInBlock:(int *)numECBytesInBlock error:(NSError **)error;
		//[Static]
		//[Export ("numDataBytesAndNumECBytesForBlockID:numDataBytes:numRSBlocks:blockID:numDataBytesInBlock:numECBytesInBlock:error:")]
		//bool NumDataBytesAndNumECBytesForBlockID (int numTotalBytes, int numDataBytes, int numRSBlocks, int blockID, int[] numDataBytesInBlock, int[] numECBytesInBlock, out NSError error);

		// +(ZXBitArray *)interleaveWithECBytes:(ZXBitArray *)bits numTotalBytes:(int)numTotalBytes numDataBytes:(int)numDataBytes numRSBlocks:(int)numRSBlocks error:(NSError **)error;
		[Static]
		[Export ("interleaveWithECBytes:numTotalBytes:numDataBytes:numRSBlocks:error:")]
		ZXBitArray InterleaveWithECBytes (ZXBitArray bits, int numTotalBytes, int numDataBytes, int numRSBlocks, out NSError error);

		// +(ZXByteArray *)generateECBytes:(ZXByteArray *)dataBytes numEcBytesInBlock:(int)numEcBytesInBlock;
		[Static]
		[Export ("generateECBytes:numEcBytesInBlock:")]
		ZXByteArray GenerateECBytes (ZXByteArray dataBytes, int numEcBytesInBlock);

		// +(void)appendModeInfo:(ZXQRCodeMode *)mode bits:(ZXBitArray *)bits;
		[Static]
		[Export ("appendModeInfo:bits:")]
		void AppendModeInfo (ZXQRCodeMode mode, ZXBitArray bits);

		// +(BOOL)appendLengthInfo:(int)numLetters version:(ZXQRCodeVersion *)version mode:(ZXQRCodeMode *)mode bits:(ZXBitArray *)bits error:(NSError **)error;
		[Static]
		[Export ("appendLengthInfo:version:mode:bits:error:")]
		bool AppendLengthInfo (int numLetters, ZXQRCodeVersion version, ZXQRCodeMode mode, ZXBitArray bits, out NSError error);

		// +(BOOL)appendBytes:(NSString *)content mode:(ZXQRCodeMode *)mode bits:(ZXBitArray *)bits encoding:(NSStringEncoding)encoding error:(NSError **)error;
		[Static]
		[Export ("appendBytes:mode:bits:encoding:error:")]
		bool AppendBytes (string content, ZXQRCodeMode mode, ZXBitArray bits, nuint encoding, out NSError error);

		// +(void)appendNumericBytes:(NSString *)content bits:(ZXBitArray *)bits;
		[Static]
		[Export ("appendNumericBytes:bits:")]
		void AppendNumericBytes (string content, ZXBitArray bits);

		// +(BOOL)appendAlphanumericBytes:(NSString *)content bits:(ZXBitArray *)bits error:(NSError **)error;
		[Static]
		[Export ("appendAlphanumericBytes:bits:error:")]
		bool AppendAlphanumericBytes (string content, ZXBitArray bits, out NSError error);

		// +(void)append8BitBytes:(NSString *)content bits:(ZXBitArray *)bits encoding:(NSStringEncoding)encoding;
		[Static]
		[Export ("append8BitBytes:bits:encoding:")]
		void Append8BitBytes (string content, ZXBitArray bits, nuint encoding);

		// +(BOOL)appendKanjiBytes:(NSString *)content bits:(ZXBitArray *)bits error:(NSError **)error;
		[Static]
		[Export ("appendKanjiBytes:bits:error:")]
		bool AppendKanjiBytes (string content, ZXBitArray bits, out NSError error);
	}

	// @interface ZXQRCodeErrorCorrectionLevel : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeErrorCorrectionLevel
	{
		// @property (readonly, assign, nonatomic) int bits;
		[Export ("bits")]
		int Bits { get; }

		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, assign, nonatomic) int ordinal;
		[Export ("ordinal")]
		int Ordinal { get; }

		// -(id)initWithOrdinal:(int)anOrdinal bits:(int)bits name:(NSString *)name;
		[Export ("initWithOrdinal:bits:name:")]
		IntPtr Constructor (int anOrdinal, int bits, string name);

		// +(ZXQRCodeErrorCorrectionLevel *)forBits:(int)bits;
		[Static]
		[Export ("forBits:")]
		ZXQRCodeErrorCorrectionLevel ForBits (int bits);

		// +(ZXQRCodeErrorCorrectionLevel *)errorCorrectionLevelL;
		[Static]
		[Export ("errorCorrectionLevelL")]
		ZXQRCodeErrorCorrectionLevel ErrorCorrectionLevelL { get; }

		// +(ZXQRCodeErrorCorrectionLevel *)errorCorrectionLevelM;
		[Static]
		[Export ("errorCorrectionLevelM")]
		ZXQRCodeErrorCorrectionLevel ErrorCorrectionLevelM { get; }

		// +(ZXQRCodeErrorCorrectionLevel *)errorCorrectionLevelQ;
		[Static]
		[Export ("errorCorrectionLevelQ")]
		ZXQRCodeErrorCorrectionLevel ErrorCorrectionLevelQ { get; }

		// +(ZXQRCodeErrorCorrectionLevel *)errorCorrectionLevelH;
		[Static]
		[Export ("errorCorrectionLevelH")]
		ZXQRCodeErrorCorrectionLevel ErrorCorrectionLevelH { get; }
	}

	// @interface ZXQRCodeFinderPatternInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeFinderPatternInfo
	{
		// @property (readonly, nonatomic, strong) ZXQRCodeFinderPattern * bottomLeft;
		[Export ("bottomLeft", ArgumentSemantic.Strong)]
		ZXQRCodeFinderPattern BottomLeft { get; }

		// @property (readonly, nonatomic, strong) ZXQRCodeFinderPattern * topLeft;
		[Export ("topLeft", ArgumentSemantic.Strong)]
		ZXQRCodeFinderPattern TopLeft { get; }

		// @property (readonly, nonatomic, strong) ZXQRCodeFinderPattern * topRight;
		[Export ("topRight", ArgumentSemantic.Strong)]
		ZXQRCodeFinderPattern TopRight { get; }

		// -(id)initWithPatternCenters:(NSArray *)patternCenters;
		[Export ("initWithPatternCenters:")]
		IntPtr Constructor (NSObject[] patternCenters);
	}

	// @interface ZXQRCodeFinderPattern : ZXResultPoint
	[BaseType (typeof(ZXResultPoint))]
	interface ZXQRCodeFinderPattern
	{
		// @property (readonly, assign, nonatomic) int count;
		[Export ("count")]
		int Count { get; }

		// @property (readonly, assign, nonatomic) float estimatedModuleSize;
		[Export ("estimatedModuleSize")]
		float EstimatedModuleSize { get; }

		// -(id)initWithPosX:(float)posX posY:(float)posY estimatedModuleSize:(float)estimatedModuleSize;
		[Export ("initWithPosX:posY:estimatedModuleSize:")]
		IntPtr Constructor (float posX, float posY, float estimatedModuleSize);

		// -(id)initWithPosX:(float)posX posY:(float)posY estimatedModuleSize:(float)estimatedModuleSize count:(int)count;
		[Export ("initWithPosX:posY:estimatedModuleSize:count:")]
		IntPtr Constructor (float posX, float posY, float estimatedModuleSize, int count);

		// -(BOOL)aboutEquals:(float)moduleSize i:(float)i j:(float)j;
		[Export ("aboutEquals:i:j:")]
		bool AboutEquals (float moduleSize, float i, float j);

		// -(ZXQRCodeFinderPattern *)combineEstimateI:(float)i j:(float)j newModuleSize:(float)newModuleSize;
		[Export ("combineEstimateI:j:newModuleSize:")]
		ZXQRCodeFinderPattern CombineEstimateI (float i, float j, float newModuleSize);
	}

	// @interface ZXQRCodeFinderPatternFinder : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeFinderPatternFinder
	{
		// @property (readonly, nonatomic, strong) ZXBitMatrix * image;
		[Export ("image", ArgumentSemantic.Strong)]
		ZXBitMatrix Image { get; }

		// @property (readonly, nonatomic, strong) NSMutableArray * possibleCenters;
		[Export ("possibleCenters", ArgumentSemantic.Strong)]
		NSMutableArray PossibleCenters { get; }

		// -(id)initWithImage:(ZXBitMatrix *)image;
		[Export ("initWithImage:")]
		IntPtr Constructor (ZXBitMatrix image);

		// -(id)initWithImage:(ZXBitMatrix *)image resultPointCallback:(id<ZXResultPointCallback>)resultPointCallback;
		[Export ("initWithImage:resultPointCallback:")]
		IntPtr Constructor (ZXBitMatrix image, ZXResultPointCallback resultPointCallback);

		// -(ZXQRCodeFinderPatternInfo *)find:(ZXDecodeHints *)hints error:(NSError **)error;
		[Export ("find:error:")]
		ZXQRCodeFinderPatternInfo Find (ZXDecodeHints hints, out NSError error);

		//// +(BOOL)foundPatternCross:(const int *)stateCount;
		//[Static]
		//[Export ("foundPatternCross:")]
		//bool FoundPatternCross (int[] stateCount);

		//// -(BOOL)handlePossibleCenter:(const int *)stateCount i:(int)i j:(int)j pureBarcode:(BOOL)pureBarcode;
		//[Export ("handlePossibleCenter:i:j:pureBarcode:")]
		//bool HandlePossibleCenter (int[] stateCount, int i, int j, bool pureBarcode);
	}

	// @interface ZXQRCodeMode : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeMode
	{
		// @property (readonly, assign, nonatomic) int bits;
		[Export ("bits")]
		int Bits { get; }

		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// -(id)initWithCharacterCountBitsForVersions:(NSArray *)characterCountBitsForVersions bits:(int)bits name:(NSString *)name;
		[Export ("initWithCharacterCountBitsForVersions:bits:name:")]
		IntPtr Constructor (NSObject[] characterCountBitsForVersions, int bits, string name);

		// +(ZXQRCodeMode *)forBits:(int)bits;
		[Static]
		[Export ("forBits:")]
		ZXQRCodeMode ForBits (int bits);

		// -(int)characterCountBits:(ZXQRCodeVersion *)version;
		[Export ("characterCountBits:")]
		int CharacterCountBits (ZXQRCodeVersion version);

		// +(ZXQRCodeMode *)terminatorMode;
		[Static]
		[Export ("terminatorMode")]
		ZXQRCodeMode TerminatorMode { get; }

		// +(ZXQRCodeMode *)numericMode;
		[Static]
		[Export ("numericMode")]
		ZXQRCodeMode NumericMode { get; }

		// +(ZXQRCodeMode *)alphanumericMode;
		[Static]
		[Export ("alphanumericMode")]
		ZXQRCodeMode AlphanumericMode { get; }

		// +(ZXQRCodeMode *)structuredAppendMode;
		[Static]
		[Export ("structuredAppendMode")]
		ZXQRCodeMode StructuredAppendMode { get; }

		// +(ZXQRCodeMode *)byteMode;
		[Static]
		[Export ("byteMode")]
		ZXQRCodeMode ByteMode { get; }

		// +(ZXQRCodeMode *)eciMode;
		[Static]
		[Export ("eciMode")]
		ZXQRCodeMode EciMode { get; }

		// +(ZXQRCodeMode *)kanjiMode;
		[Static]
		[Export ("kanjiMode")]
		ZXQRCodeMode KanjiMode { get; }

		// +(ZXQRCodeMode *)fnc1FirstPositionMode;
		[Static]
		[Export ("fnc1FirstPositionMode")]
		ZXQRCodeMode Fnc1FirstPositionMode { get; }

		// +(ZXQRCodeMode *)fnc1SecondPositionMode;
		[Static]
		[Export ("fnc1SecondPositionMode")]
		ZXQRCodeMode Fnc1SecondPositionMode { get; }

		// +(ZXQRCodeMode *)hanziMode;
		[Static]
		[Export ("hanziMode")]
		ZXQRCodeMode HanziMode { get; }
	}

	// @interface ZXQRCodeReader : NSObject <ZXReader>
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeReader : ZXReader
	{
		// @property (readonly, nonatomic, strong) ZXQRCodeDecoder * decoder;
		[Export ("decoder", ArgumentSemantic.Strong)]
		ZXQRCodeDecoder Decoder { get; }
	}

	// @interface ZXQRCodeMultiReader : ZXQRCodeReader <ZXMultipleBarcodeReader>
	[BaseType (typeof(ZXQRCodeReader))]
	interface ZXQRCodeMultiReader : IZXMultipleBarcodeReader
	{
	}

	// @interface ZXQRCodeVersion : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeVersion
	{
		// @property (readonly, assign, nonatomic) int versionNumber;
		[Export ("versionNumber")]
		int VersionNumber { get; }

		// @property (readonly, nonatomic, strong) ZXIntArray * alignmentPatternCenters;
		[Export ("alignmentPatternCenters", ArgumentSemantic.Strong)]
		ZXIntArray AlignmentPatternCenters { get; }

		// @property (readonly, nonatomic, strong) NSArray * ecBlocks;
		[Export ("ecBlocks", ArgumentSemantic.Strong)]
		NSObject[] EcBlocks { get; }

		// @property (readonly, assign, nonatomic) int totalCodewords;
		[Export ("totalCodewords")]
		int TotalCodewords { get; }

		// @property (readonly, assign, nonatomic) int dimensionForVersion;
		[Export ("dimensionForVersion")]
		int DimensionForVersion { get; }

		// -(ZXQRCodeECBlocks *)ecBlocksForLevel:(ZXQRCodeErrorCorrectionLevel *)ecLevel;
		[Export ("ecBlocksForLevel:")]
		ZXQRCodeECBlocks EcBlocksForLevel (ZXQRCodeErrorCorrectionLevel ecLevel);

		// +(ZXQRCodeVersion *)provisionalVersionForDimension:(int)dimension;
		[Static]
		[Export ("provisionalVersionForDimension:")]
		ZXQRCodeVersion ProvisionalVersionForDimension (int dimension);

		// +(ZXQRCodeVersion *)versionForNumber:(int)versionNumber;
		[Static]
		[Export ("versionForNumber:")]
		ZXQRCodeVersion VersionForNumber (int versionNumber);

		// +(ZXQRCodeVersion *)decodeVersionInformation:(int)versionBits;
		[Static]
		[Export ("decodeVersionInformation:")]
		ZXQRCodeVersion DecodeVersionInformation (int versionBits);

		// -(ZXBitMatrix *)buildFunctionPattern;
		[Export ("buildFunctionPattern")]
		ZXBitMatrix BuildFunctionPattern { get; }
	}

	// @interface ZXQRCodeECBlocks : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeECBlocks
	{
		// @property (readonly, assign, nonatomic) int ecCodewordsPerBlock;
		[Export ("ecCodewordsPerBlock")]
		int EcCodewordsPerBlock { get; }

		// @property (readonly, assign, nonatomic) int numBlocks;
		[Export ("numBlocks")]
		int NumBlocks { get; }

		// @property (readonly, assign, nonatomic) int totalECCodewords;
		[Export ("totalECCodewords")]
		int TotalECCodewords { get; }

		// @property (readonly, nonatomic, strong) NSArray * ecBlocks;
		[Export ("ecBlocks", ArgumentSemantic.Strong)]
		NSObject[] EcBlocks { get; }

		// -(id)initWithEcCodewordsPerBlock:(int)ecCodewordsPerBlock ecBlocks:(ZXQRCodeECB *)ecBlocks;
		[Export ("initWithEcCodewordsPerBlock:ecBlocks:")]
		IntPtr Constructor (int ecCodewordsPerBlock, ZXQRCodeECB ecBlocks);

		// -(id)initWithEcCodewordsPerBlock:(int)ecCodewordsPerBlock ecBlocks1:(ZXQRCodeECB *)ecBlocks1 ecBlocks2:(ZXQRCodeECB *)ecBlocks2;
		[Export ("initWithEcCodewordsPerBlock:ecBlocks1:ecBlocks2:")]
		IntPtr Constructor (int ecCodewordsPerBlock, ZXQRCodeECB ecBlocks1, ZXQRCodeECB ecBlocks2);

		// +(ZXQRCodeECBlocks *)ecBlocksWithEcCodewordsPerBlock:(int)ecCodewordsPerBlock ecBlocks:(ZXQRCodeECB *)ecBlocks;
		[Static]
		[Export ("ecBlocksWithEcCodewordsPerBlock:ecBlocks:")]
		ZXQRCodeECBlocks EcBlocksWithEcCodewordsPerBlock (int ecCodewordsPerBlock, ZXQRCodeECB ecBlocks);

		// +(ZXQRCodeECBlocks *)ecBlocksWithEcCodewordsPerBlock:(int)ecCodewordsPerBlock ecBlocks1:(ZXQRCodeECB *)ecBlocks1 ecBlocks2:(ZXQRCodeECB *)ecBlocks2;
		[Static]
		[Export ("ecBlocksWithEcCodewordsPerBlock:ecBlocks1:ecBlocks2:")]
		ZXQRCodeECBlocks EcBlocksWithEcCodewordsPerBlock (int ecCodewordsPerBlock, ZXQRCodeECB ecBlocks1, ZXQRCodeECB ecBlocks2);
	}

	// @interface ZXQRCodeECB : NSObject
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeECB
	{
		// @property (readonly, assign, nonatomic) int count;
		[Export ("count")]
		int Count { get; }

		// @property (readonly, assign, nonatomic) int dataCodewords;
		[Export ("dataCodewords")]
		int DataCodewords { get; }

		// -(id)initWithCount:(int)count dataCodewords:(int)dataCodewords;
		[Export ("initWithCount:dataCodewords:")]
		IntPtr Constructor (int count, int dataCodewords);

		// +(ZXQRCodeECB *)ecbWithCount:(int)count dataCodewords:(int)dataCodewords;
		[Static]
		[Export ("ecbWithCount:dataCodewords:")]
		ZXQRCodeECB EcbWithCount (int count, int dataCodewords);
	}

	// @interface ZXQRCodeWriter : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXQRCodeWriter : ZXWriter
	{
	}

	// @interface ZXMultiFormatReader : NSObject <ZXReader>
	[BaseType (typeof(NSObject))]
	interface ZXMultiFormatReader : ZXReader
	{
		// @property (nonatomic, strong) ZXDecodeHints * hints;
		[Export ("hints", ArgumentSemantic.Strong)]
		ZXDecodeHints Hints { get; set; }

		// +(id)reader;
		[Static]
		[Export ("reader")]
		NSObject Reader { get; }

		// -(ZXResult *)decodeWithState:(ZXBinaryBitmap *)image error:(NSError **)error;
		[Export ("decodeWithState:error:")]
		ZXResult DecodeWithState (ZXBinaryBitmap image, out NSError error);
	}

	// @interface ZXMultiFormatWriter : NSObject <ZXWriter>
	[BaseType (typeof(NSObject))]
	interface ZXMultiFormatWriter : ZXWriter
	{
		// +(id)writer;
		[Static]
		[Export ("writer")]
		NSObject Writer { get; }
	}
}
