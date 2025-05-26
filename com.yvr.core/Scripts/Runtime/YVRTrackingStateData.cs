using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YVR.Core
{
    public partial class YVRTrackingStateManager
    {
        /// <summary>
        /// Initial camera height
        /// </summary>
        public enum TrackingSpace
        {
            /// <summary>
            /// camera default high is 0.
            /// </summary>
            EyeLevel = 2,
            /// <summary>
            /// The default height of the camera is the height of the boundary setting.
            /// </summary>
            FloorLevel = 1000426000,
            /// <summary>
            /// Not affected by Recenter
            /// </summary>
            Stage = 3,
        }
    }
}