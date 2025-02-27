using System.Collections.Generic;
using YVR.Utilities;
using UnityEngine;

namespace YVR.Core
{
    public class YVRSDKSettingAsset : ScriptableObject
    {
        public bool ignoreSDKSetting = false;
        public bool appIDChecked = false;
        public List<ManifestTagInfo> manifestTagInfosList = new();
        public List<AssetInfo> assetInfoList;
    }
}