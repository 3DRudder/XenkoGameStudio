// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconStudio.Core.Mathematics;
using SiliconStudio.Xenko.Input;
using SiliconStudio.Xenko.Engine;
using ns3DRudder;

namespace Xenko3dRudder
{
    public class Movement3dRudder : SyncScript
    {
        // Declared public member fields and properties will show in the game studio
        public Entity Camera { get; set; }       
        public uint Port3dRudder { get; set; } = 0;
        public bool Rotate { get; set; } = false;
        public ModeAxis mode { get; set; } = ModeAxis.ValueWithCurveNonSymmetricalPitch;
        public Vector3 Speed { get; set; } = Vector3.One;
        public float SpeedRotation { get; set; } = 1.0f;
        
        // Private
        private CSdk sdk;
        private CurveArray curves;
        private Axis axis;
        
        public override void Start()
        {
            // Initialization of the script.
            sdk = i3DR.GetSDK();
            curves = new CurveArray();
            axis = new Axis();
        }

        public override void Update()
        {
            // 3dRudder connected
            if (sdk.IsDeviceConnected(Port3dRudder))
            {
                // Get values of axis
                ErrorCode error = sdk.GetAxis(Port3dRudder, mode, axis, curves);
                if (error == ErrorCode.Success)
                {
                    Vector3 translation = Vector3.Zero;
                    TransformComponent transform = Camera.Transform;
                    float deltaTime = Game.UpdateTime.Elapsed.Milliseconds / 1000.0f;
                    // Pitch [Forward/Backward]
                    translation += transform.LocalMatrix.Forward * axis.GetPhysicalPitch() * Speed.Z;
                    // Roll [Right/Left]
                    translation += transform.LocalMatrix.Right * axis.GetPhysicalRoll() * Speed.X;
                    // UpDown [Up/Down]
                    translation += transform.LocalMatrix.Up * axis.GetUpDown() * Speed.Y;
                    // Translation
                    transform.Position += translation * deltaTime ;
                    // Yaw (Rotation Right/Left)
                    if (Rotate)
                        transform.Rotation *= Quaternion.RotationY(-axis.GetZRotation() * deltaTime * SpeedRotation);
                }
            }
        }
        
        // Free SDK
        public override void Cancel()
        {
            i3DR.EndSDK();
        }
    }
}
