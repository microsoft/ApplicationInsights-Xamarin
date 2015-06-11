using System;
using ObjCRuntime;

[assembly: LinkWith ("libExamplePlugin.a", LinkTarget.Simulator | LinkTarget.Simulator64 | LinkTarget.ArmV7 | LinkTarget.Arm64, SmartLink = true, ForceLoad = true)]
