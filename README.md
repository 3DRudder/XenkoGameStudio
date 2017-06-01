![language](https://img.shields.io/badge/Language-C%23-green.svg) 
![dependencies](https://img.shields.io/badge/Dependecies-3dRudderSDK-green.svg)
![Xenko](https://img.shields.io/badge/Xenko-2.0.1.1-green.svg)
![Visual Studio 2015](https://img.shields.io/badge/Visual%20Studio-2015-brightgreen.svg)
![Firmware 3dRudder](https://img.shields.io/badge/Firmware%203dRudder-%3E%20v1.3.5.2-brightgreen.svg)

# Xenko Game Studio VR Sample v0.1

## Download Sample
* [Release](https://github.com/3DRudder/XenkoGameStudio/releases/latest)

## Build Sample
* Clone project
* Clone or download [3dRudderSDK](https://github.com/3DRudder/3DRudderSDK) in the same parent folder
* Start Xenko, browse for existing project and select ```VRSandbox.sln``` or ```VRSandbox.xkpkg```
* Copy the ```/../3dRudderSDK/Bin/Win32/i3DR.dll``` into ```/VRSandbox/Bin/Windows/Debug``` and ```/VRSandbox/Bin/Windows/Release```
* Build (F5)

## Add 3dRudderSDK in your project
* Clone or download [3dRudderSDK](https://github.com/3DRudder/3DRudderSDK) in the same parent folder of your project
* Open your Xenko project
* In Xenko open Visual Studio with "Project -> Open in IDE"
* In Visual Studio right click on Reference -> Add Reference -> Select ```3dRudderSDK\Bin\Win32\3DRudderSDK.net.dll```
* Create a SyncScript class
* Include 
  ```
  using ns3DRudder;
  ```
* Init SDK 
  ```
  private CSdk sdk;
  private CurveArray curves;
  private Axis axis;
  
  public override void Start()
  {
      sdk = i3DR.GetSDK();
      curves = new CurveArray();
      axis = new Axis();
  }
  ```
* Get values of axis:
  ```
  public override void Update()
  {
      ErrorCode error = sdk.GetAxis(0, ModeAxis.ValueWithCurveNonSymmetricalPitch, axis, curves);
      if (error == ErrorCode.Success)
      {
          //axis.GetPhysicalRoll()
          //axis.GetPhysicalPitch()
      }
  }
  ```
 * Free SDK 
  ```
  public override void Cancel()
  {
      i3DR.EndSDK();
  }
 ```
 
## License

3dRudder - All copyrights reserved.


