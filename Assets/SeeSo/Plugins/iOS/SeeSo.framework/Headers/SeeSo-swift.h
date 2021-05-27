// Generated by Apple Swift version 5.3.2 (swiftlang-1200.0.45 clang-1200.0.32.28)
#ifndef SEESO_SWIFT_H
#define SEESO_SWIFT_H
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Wgcc-compat"

#if !defined(__has_include)
# define __has_include(x) 0
#endif
#if !defined(__has_attribute)
# define __has_attribute(x) 0
#endif
#if !defined(__has_feature)
# define __has_feature(x) 0
#endif
#if !defined(__has_warning)
# define __has_warning(x) 0
#endif

#if __has_include(<swift/objc-prologue.h>)
# include <swift/objc-prologue.h>
#endif

#pragma clang diagnostic ignored "-Wauto-import"
#include <Foundation/Foundation.h>
#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>

#if !defined(SWIFT_TYPEDEFS)
# define SWIFT_TYPEDEFS 1
# if __has_include(<uchar.h>)
#  include <uchar.h>
# elif !defined(__cplusplus)
typedef uint_least16_t char16_t;
typedef uint_least32_t char32_t;
# endif
typedef float swift_float2  __attribute__((__ext_vector_type__(2)));
typedef float swift_float3  __attribute__((__ext_vector_type__(3)));
typedef float swift_float4  __attribute__((__ext_vector_type__(4)));
typedef double swift_double2  __attribute__((__ext_vector_type__(2)));
typedef double swift_double3  __attribute__((__ext_vector_type__(3)));
typedef double swift_double4  __attribute__((__ext_vector_type__(4)));
typedef int swift_int2  __attribute__((__ext_vector_type__(2)));
typedef int swift_int3  __attribute__((__ext_vector_type__(3)));
typedef int swift_int4  __attribute__((__ext_vector_type__(4)));
typedef unsigned int swift_uint2  __attribute__((__ext_vector_type__(2)));
typedef unsigned int swift_uint3  __attribute__((__ext_vector_type__(3)));
typedef unsigned int swift_uint4  __attribute__((__ext_vector_type__(4)));
#endif

#if !defined(SWIFT_PASTE)
# define SWIFT_PASTE_HELPER(x, y) x##y
# define SWIFT_PASTE(x, y) SWIFT_PASTE_HELPER(x, y)
#endif
#if !defined(SWIFT_METATYPE)
# define SWIFT_METATYPE(X) Class
#endif
#if !defined(SWIFT_CLASS_PROPERTY)
# if __has_feature(objc_class_property)
#  define SWIFT_CLASS_PROPERTY(...) __VA_ARGS__
# else
#  define SWIFT_CLASS_PROPERTY(...)
# endif
#endif

#if __has_attribute(objc_runtime_name)
# define SWIFT_RUNTIME_NAME(X) __attribute__((objc_runtime_name(X)))
#else
# define SWIFT_RUNTIME_NAME(X)
#endif
#if __has_attribute(swift_name)
# define SWIFT_COMPILE_NAME(X) __attribute__((swift_name(X)))
#else
# define SWIFT_COMPILE_NAME(X)
#endif
#if __has_attribute(objc_method_family)
# define SWIFT_METHOD_FAMILY(X) __attribute__((objc_method_family(X)))
#else
# define SWIFT_METHOD_FAMILY(X)
#endif
#if __has_attribute(noescape)
# define SWIFT_NOESCAPE __attribute__((noescape))
#else
# define SWIFT_NOESCAPE
#endif
#if __has_attribute(ns_consumed)
# define SWIFT_RELEASES_ARGUMENT __attribute__((ns_consumed))
#else
# define SWIFT_RELEASES_ARGUMENT
#endif
#if __has_attribute(warn_unused_result)
# define SWIFT_WARN_UNUSED_RESULT __attribute__((warn_unused_result))
#else
# define SWIFT_WARN_UNUSED_RESULT
#endif
#if __has_attribute(noreturn)
# define SWIFT_NORETURN __attribute__((noreturn))
#else
# define SWIFT_NORETURN
#endif
#if !defined(SWIFT_CLASS_EXTRA)
# define SWIFT_CLASS_EXTRA
#endif
#if !defined(SWIFT_PROTOCOL_EXTRA)
# define SWIFT_PROTOCOL_EXTRA
#endif
#if !defined(SWIFT_ENUM_EXTRA)
# define SWIFT_ENUM_EXTRA
#endif
#if !defined(SWIFT_CLASS)
# if __has_attribute(objc_subclassing_restricted)
#  define SWIFT_CLASS(SWIFT_NAME) SWIFT_RUNTIME_NAME(SWIFT_NAME) __attribute__((objc_subclassing_restricted)) SWIFT_CLASS_EXTRA
#  define SWIFT_CLASS_NAMED(SWIFT_NAME) __attribute__((objc_subclassing_restricted)) SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_CLASS_EXTRA
# else
#  define SWIFT_CLASS(SWIFT_NAME) SWIFT_RUNTIME_NAME(SWIFT_NAME) SWIFT_CLASS_EXTRA
#  define SWIFT_CLASS_NAMED(SWIFT_NAME) SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_CLASS_EXTRA
# endif
#endif
#if !defined(SWIFT_RESILIENT_CLASS)
# if __has_attribute(objc_class_stub)
#  define SWIFT_RESILIENT_CLASS(SWIFT_NAME) SWIFT_CLASS(SWIFT_NAME) __attribute__((objc_class_stub))
#  define SWIFT_RESILIENT_CLASS_NAMED(SWIFT_NAME) __attribute__((objc_class_stub)) SWIFT_CLASS_NAMED(SWIFT_NAME)
# else
#  define SWIFT_RESILIENT_CLASS(SWIFT_NAME) SWIFT_CLASS(SWIFT_NAME)
#  define SWIFT_RESILIENT_CLASS_NAMED(SWIFT_NAME) SWIFT_CLASS_NAMED(SWIFT_NAME)
# endif
#endif

#if !defined(SWIFT_PROTOCOL)
# define SWIFT_PROTOCOL(SWIFT_NAME) SWIFT_RUNTIME_NAME(SWIFT_NAME) SWIFT_PROTOCOL_EXTRA
# define SWIFT_PROTOCOL_NAMED(SWIFT_NAME) SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_PROTOCOL_EXTRA
#endif

#if !defined(SWIFT_EXTENSION)
# define SWIFT_EXTENSION(M) SWIFT_PASTE(M##_Swift_, __LINE__)
#endif

#if !defined(OBJC_DESIGNATED_INITIALIZER)
# if __has_attribute(objc_designated_initializer)
#  define OBJC_DESIGNATED_INITIALIZER __attribute__((objc_designated_initializer))
# else
#  define OBJC_DESIGNATED_INITIALIZER
# endif
#endif
#if !defined(SWIFT_ENUM_ATTR)
# if defined(__has_attribute) && __has_attribute(enum_extensibility)
#  define SWIFT_ENUM_ATTR(_extensibility) __attribute__((enum_extensibility(_extensibility)))
# else
#  define SWIFT_ENUM_ATTR(_extensibility)
# endif
#endif
#if !defined(SWIFT_ENUM)
# define SWIFT_ENUM(_type, _name, _extensibility) enum _name : _type _name; enum SWIFT_ENUM_ATTR(_extensibility) SWIFT_ENUM_EXTRA _name : _type
# if __has_feature(generalized_swift_name)
#  define SWIFT_ENUM_NAMED(_type, _name, SWIFT_NAME, _extensibility) enum _name : _type _name SWIFT_COMPILE_NAME(SWIFT_NAME); enum SWIFT_COMPILE_NAME(SWIFT_NAME) SWIFT_ENUM_ATTR(_extensibility) SWIFT_ENUM_EXTRA _name : _type
# else
#  define SWIFT_ENUM_NAMED(_type, _name, SWIFT_NAME, _extensibility) SWIFT_ENUM(_type, _name, _extensibility)
# endif
#endif
#if !defined(SWIFT_UNAVAILABLE)
# define SWIFT_UNAVAILABLE __attribute__((unavailable))
#endif
#if !defined(SWIFT_UNAVAILABLE_MSG)
# define SWIFT_UNAVAILABLE_MSG(msg) __attribute__((unavailable(msg)))
#endif
#if !defined(SWIFT_AVAILABILITY)
# define SWIFT_AVAILABILITY(plat, ...) __attribute__((availability(plat, __VA_ARGS__)))
#endif
#if !defined(SWIFT_WEAK_IMPORT)
# define SWIFT_WEAK_IMPORT __attribute__((weak_import))
#endif
#if !defined(SWIFT_DEPRECATED)
# define SWIFT_DEPRECATED __attribute__((deprecated))
#endif
#if !defined(SWIFT_DEPRECATED_MSG)
# define SWIFT_DEPRECATED_MSG(...) __attribute__((deprecated(__VA_ARGS__)))
#endif
#if __has_feature(attribute_diagnose_if_objc)
# define SWIFT_DEPRECATED_OBJC(Msg) __attribute__((diagnose_if(1, Msg, "warning")))
#else
# define SWIFT_DEPRECATED_OBJC(Msg) SWIFT_DEPRECATED_MSG(Msg)
#endif
#if !defined(IBSegueAction)
# define IBSegueAction
#endif
#if __has_feature(modules)
#if __has_warning("-Watimport-in-framework-header")
#pragma clang diagnostic ignored "-Watimport-in-framework-header"
#endif
@import CoreGraphics;
@import CoreMedia;
@import ObjectiveC;
#endif

#pragma clang diagnostic ignored "-Wproperty-attribute-mismatch"
#pragma clang diagnostic ignored "-Wduplicate-method-arg"
#if __has_warning("-Wpragma-clang-attribute")
# pragma clang diagnostic ignored "-Wpragma-clang-attribute"
#endif
#pragma clang diagnostic ignored "-Wunknown-pragmas"
#pragma clang diagnostic ignored "-Wnullability"

#if __has_attribute(external_source_symbol)
# pragma push_macro("any")
# undef any
# pragma clang attribute push(__attribute__((external_source_symbol(language="Swift", defined_in="SeeSo",generated_declaration))), apply_to=any(function,enum,objc_interface,objc_category,objc_protocol))
# pragma pop_macro("any")
#endif

typedef SWIFT_ENUM(NSInteger, AccuracyCriteria, closed) {
  AccuracyCriteriaDEFAULT = 0,
  AccuracyCriteriaLOW = 1,
  AccuracyCriteriaHIGH = 2,
};


SWIFT_PROTOCOL("_TtP5SeeSo19GazeTrackerDelegate_")
@protocol GazeTrackerDelegate
@end


SWIFT_PROTOCOL("_TtP5SeeSo19CalibrationDelegate_")
@protocol CalibrationDelegate <GazeTrackerDelegate>
- (void)onCalibrationNextPointWithX:(double)x y:(double)y;
- (void)onCalibrationProgressWithProgress:(double)progress;
- (void)onCalibrationFinishedWithCalibrationData:(NSArray<NSNumber *> * _Nonnull)calibrationData;
@end

typedef SWIFT_ENUM(NSInteger, CalibrationMode, closed) {
  CalibrationModeDEFAULT = 0,
  CalibrationModeONE_POINT = 1,
  CalibrationModeFIVE_POINT = 5,
  CalibrationModeSIX_POINT = 6,
};

typedef SWIFT_ENUM(NSInteger, EyeMovementState, closed) {
  EyeMovementStateFIXATION = 0,
  EyeMovementStateSACCADE = 2,
  EyeMovementStateUNKONW = 3,
};

@class GazeInfo;

SWIFT_PROTOCOL("_TtP5SeeSo12GazeDelegate_")
@protocol GazeDelegate <GazeTrackerDelegate>
- (void)onGazeWithGazeInfo:(GazeInfo * _Nonnull)gazeInfo;
@end

enum TrackingState : NSInteger;
enum ScreenState : NSInteger;

SWIFT_CLASS("_TtC5SeeSo8GazeInfo")
@interface GazeInfo : NSObject
@property (nonatomic, readonly) double x;
@property (nonatomic, readonly) double y;
@property (nonatomic, readonly) double timestamp;
@property (nonatomic, readonly) enum TrackingState trackingState;
@property (nonatomic, readonly) enum EyeMovementState eyeMovementState;
@property (nonatomic, readonly) enum ScreenState screenState;
- (nonnull instancetype)init SWIFT_UNAVAILABLE;
+ (nonnull instancetype)new SWIFT_UNAVAILABLE_MSG("-init is unavailable");
@end

@protocol StatusDelegate;
@protocol ImageDelegate;
@protocol InitializationDelegate;
@class UIView;

/// A configuration that sets device orientation and uses calibration.
/// Manage the gaze tracking that start, pause, resume and close.
SWIFT_CLASS("_TtC5SeeSo11GazeTracker")
@interface GazeTracker : NSObject
@property (nonatomic, weak) id <StatusDelegate> _Nullable statusDelegate;
@property (nonatomic, weak) id <GazeDelegate> _Nullable gazeDelegate;
@property (nonatomic, weak) id <CalibrationDelegate> _Nullable calibrationDelegate;
@property (nonatomic, weak) id <ImageDelegate> _Nullable imageDelegate;
+ (void)initGazeTrackerWithLicense:(NSString * _Nonnull)license delegate:(id <InitializationDelegate> _Nonnull)delegate SWIFT_METHOD_FAMILY(none);
/// terminate GazeTracker.
+ (void)deinitGazeTrackerWithTracker:(GazeTracker * _Nullable)tracker;
/// Start gaze tracking
- (void)startTracking;
/// stop gaze tracking.
- (void)stopTracking;
- (BOOL)isTracking SWIFT_WARN_UNUSED_RESULT;
- (BOOL)setTrackingFPSWithFps:(NSInteger)fps SWIFT_WARN_UNUSED_RESULT;
- (BOOL)isCalibrating SWIFT_WARN_UNUSED_RESULT;
- (BOOL)startCalibrationWithMode:(enum CalibrationMode)mode criteria:(enum AccuracyCriteria)criteria region:(CGRect)region SWIFT_WARN_UNUSED_RESULT;
- (BOOL)setCalibrationDataWithCalibrationData:(NSArray<NSNumber *> * _Nonnull)calibrationData SWIFT_WARN_UNUSED_RESULT;
- (void)stopCalibration;
- (BOOL)startCollectSamples SWIFT_WARN_UNUSED_RESULT;
/// A configuration that determines whether to show preview display or not.
- (void)setCameraPreviewWithPreview:(UIView * _Nonnull)preview;
- (void)removeCameraPreview;
- (void)setDelegatesWithStatusDelegate:(id <StatusDelegate> _Nullable)statusDelegate gazeDelegate:(id <GazeDelegate> _Nullable)gazeDelegate calibrationDelegate:(id <CalibrationDelegate> _Nullable)calibrationDelegate imageDelegate:(id <ImageDelegate> _Nullable)imageDelegate;
/// Get SDK version
+ (NSString * _Nonnull)getFrameworkVersion SWIFT_WARN_UNUSED_RESULT;
- (nonnull instancetype)init SWIFT_UNAVAILABLE;
+ (nonnull instancetype)new SWIFT_UNAVAILABLE_MSG("-init is unavailable");
@end





SWIFT_PROTOCOL("_TtP5SeeSo13ImageDelegate_")
@protocol ImageDelegate <GazeTrackerDelegate>
- (void)onImageWithTimestamp:(double)timestamp image:(CMSampleBufferRef _Nonnull)image;
@end

enum InitializationError : NSInteger;

SWIFT_PROTOCOL("_TtP5SeeSo22InitializationDelegate_")
@protocol InitializationDelegate <GazeTrackerDelegate>
- (void)onInitializedWithTracker:(GazeTracker * _Nullable)tracker error:(enum InitializationError)error;
@end

typedef SWIFT_ENUM(NSInteger, InitializationError, closed) {
  InitializationErrorERROR_NONE = 0,
  InitializationErrorERROR_INIT = 1,
  InitializationErrorERROR_CAMERA_PERMISSION = 2,
  InitializationErrorAUTH_INVALID_KEY = 3,
  InitializationErrorAUTH_INVALID_ENV_USED_DEV_IN_PROD = 4,
  InitializationErrorAUTH_INVALID_ENV_USED_PROD_IN_DEV = 5,
  InitializationErrorAUTH_INVALID_PACKAGE_NAME = 6,
  InitializationErrorAUTH_INVALID_APP_SIGNATURE = 7,
  InitializationErrorAUTH_EXCEEDED_FREE_TIER = 8,
  InitializationErrorAUTH_DEACTIVATED_KEY = 9,
  InitializationErrorAUTH_INVALID_ACCESS = 10,
  InitializationErrorAUTH_UNKNOWN_ERROR = 11,
  InitializationErrorAUTH_SERVER_ERROR = 12,
  InitializationErrorAUTH_CANNOT_FIND_HOST = 13,
  InitializationErrorAUTH_WRONG_LOCAL_TIME = 14,
  InitializationErrorAUTH_INVALID_KEY_FORMAT = 15,
};


SWIFT_CLASS("_TtC5SeeSo20OneEuroFilterManager")
@interface OneEuroFilterManager : NSObject
SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly) NSInteger DEFAULT_COUNT;)
+ (NSInteger)DEFAULT_COUNT SWIFT_WARN_UNUSED_RESULT;
SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly) double DEFAULT_FREQUENCY;)
+ (double)DEFAULT_FREQUENCY SWIFT_WARN_UNUSED_RESULT;
SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly) double DEFAULT_MIN_CUT_OFF;)
+ (double)DEFAULT_MIN_CUT_OFF SWIFT_WARN_UNUSED_RESULT;
SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly) double DEFAULT_BETA;)
+ (double)DEFAULT_BETA SWIFT_WARN_UNUSED_RESULT;
SWIFT_CLASS_PROPERTY(@property (nonatomic, class, readonly) double DEFAULT_D_CUT_OFF;)
+ (double)DEFAULT_D_CUT_OFF SWIFT_WARN_UNUSED_RESULT;
- (nonnull instancetype)initWithCount:(NSInteger)count freq:(double)freq minCutOff:(double)minCutOff beta:(double)beta dCutOff:(double)dCutOff OBJC_DESIGNATED_INITIALIZER;
- (BOOL)filterValuesWithTimestamp:(double)timestamp val:(NSArray<NSNumber *> * _Nonnull)val SWIFT_WARN_UNUSED_RESULT;
- (NSArray<NSNumber *> * _Nonnull)getFilteredValues SWIFT_WARN_UNUSED_RESULT;
- (nonnull instancetype)init SWIFT_UNAVAILABLE;
+ (nonnull instancetype)new SWIFT_UNAVAILABLE_MSG("-init is unavailable");
@end

typedef SWIFT_ENUM(NSInteger, ScreenState, closed) {
  ScreenStateINSIDE_OF_SCREEN = 1001,
  ScreenStateOUTSIDE_OF_SCREEN = 1002,
  ScreenStateUNKONW = 9999,
};

enum StatusError : NSInteger;

SWIFT_PROTOCOL("_TtP5SeeSo14StatusDelegate_")
@protocol StatusDelegate <GazeTrackerDelegate>
- (void)onStarted;
- (void)onStoppedWithError:(enum StatusError)error;
@end

typedef SWIFT_ENUM(NSInteger, StatusError, closed) {
  StatusErrorERROR_NONE = 0,
  StatusErrorERROR_CAMERA_START = 1,
  StatusErrorERROR_CAMERA_INTERRUPT = 2,
};

typedef SWIFT_ENUM(NSInteger, TrackingState, closed) {
  TrackingStateSUCCESS = 0,
  TrackingStateLOW_CONFIDENCE = 1,
  TrackingStateUNSUPPORTED = 2,
  TrackingStateFACE_MISSING = 3,
};




#if __has_attribute(external_source_symbol)
# pragma clang attribute pop
#endif
#pragma clang diagnostic pop
#endif